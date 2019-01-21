/*
 * Rudy Ariaz
 * January 19, 2019
 * Applies a modified Conway's Game of Life ruleset to a given unit. Abstracts
 * the ruleset from the GameManager. Does not apply the units' individual functions.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    static class Ruleset
    {
        // Constants that define what is considered as "underpopulation" and "overpopulation"
        // in term of the number of live neighbours of a unit
        private const int UNDER_POP = 2, OVER_POP = 3;


        /// <summary>
        /// Computes the state of a given "block" in the grid in the new generation
        /// given the grid, the block, and the food availability.
        /// </summary>
        /// <remarks>
        /// Uses row and column instead of Unit since the focus is on 
        /// the location of the Unit, not its parameters.
        /// </remarks>
        /// <param name="grid">The grid in which the block to compute is.</param>
        /// <param name="foodAvailability">The number of food units available
        /// in the block's environment.</param>
        /// <param name="row">The row (within the grid) of the block to update.</param>
        /// <param name="col">The column (within the grid) of the block to update.</param>
        /// <returns>The new Unit that should occupy the block in this new generation. Null if no unit
        /// should occupy the block.</returns>
        public static Unit NewBlockState(Unit[,] grid, double foodAvailability, int row, int col)
        {
            // The current Unit in the block to update
            Unit thisUnit = grid[row, col];

            int allNeighbors = CountAllNeighbors(grid, row, col);

            // Check if the current block is empty
            if(thisUnit == null)
            {
                // Check if a new unit should be born (which happens only
                // if the block has exactly 3 neighbours)
                if(allNeighbors == OVER_POP)
                {
                    // Birth the new unit
                    return NewbornUnit(grid, row, col);
                }
            }

            // Check if the Unit is a Virus
            if (!IsLiveUnit(thisUnit))
            {
                // Update the Virus with separate Virus-oriented computations
                return NewVirusState(grid, row, col);
            }
            // Otherwise, the Unit is a living unit
            else
            {
                // Update the LivingUnit with separate LivingUnit-oriented computations
                return NewLivingState(grid, foodAvailability, row, col);
            }            
        }

        /// <summary>
        /// Computes the state of a given LivingUnit in the grid in the new generation
        /// given the grid, the block, and the food availability.
        /// </summary>
        /// <remarks>
        /// The grid block to update should be non-null.
        /// </remarks>
        /// <param name="grid">The grid in which the LivingUnit to compute is.</param>
        /// <param name="foodAvailability">The number of food units available
        /// in the LivingUnit's environment.</param>
        /// <param name="row">The row (within the grid) of the LivingUnit to update.</param>
        /// <param name="col">The column (within the grid) of the LivingUnit to update.</param>
        /// <returns>The new LivingUnit that should occupy the block in this new generation. Null if
        /// no unit should occupy the block.</returns>
        private static LivingUnit NewLivingState(Unit[,] grid, double foodAvailability, int row, int col)
        {
            // The current Unit in the block to update
            Unit thisUnit = grid[row, col];

            // Count the number of live neighbors 
            int liveNeighbors = CountLiveNeighbors(grid, row, col);
            
            // Check if the existing unit should die next generation
            if (!UnitPersists(thisUnit, liveNeighbors, foodAvailability))
            {
                // Null represents a dead unit
                return null;
            }
            // Otherwise, the unit remains the same
            return (LivingUnit)thisUnit;
        }

        /// <summary>
        /// Computes the state of a given Virus in the grid in the new generation
        /// given the grid and the block.
        /// </summary>
        /// <remarks>
        /// The grid block to update should be non-null.
        /// </remarks>
        /// <param name="grid">The grid in which the Virus to compute is.</param>
        /// <param name="row">The row (within the grid) of the Virus to update.</param>
        /// <param name="col">The column (within the grid) of the Virus to update.</param>
        /// <returns>The new Virus that should occupy the block in this new generation. Null if
        /// no unit should occupy the block.</returns>
        private static Virus NewVirusState(Unit[,] grid, int row, int col)
        {
            // The current Unit in the block to update
            Unit thisUnit = grid[row, col];

            // Count the number of viral neighbors 
            int liveNeighbors = CountViralNeighbors(grid, row, col);

            // Check if the existing unit should die next generation
            if (!UnitPersists(thisUnit, liveNeighbors: liveNeighbors))
            {
                // Null represents a dead unit
                return null;
            }
            // Otherwise, the unit remains the same
            return (Virus)thisUnit;
        }

        /// <summary>
        /// Computes the Unit that should occupy an empty block in the next generation of the game,
        /// due to the rule stating that any empty block with exactly 3 neighbors should contain
        /// a non-null Unit in the next generation.
        /// </summary>
        /// <param name="grid">The grid to use for computations.</param>
        /// <param name="row">The row (within the grid) of the empty block.</param>
        /// <param name="col">The column (within the grid) of the empty block.</param>
        /// <returns>The non-null Unit that should occupy the block.</returns>
        private static Unit NewbornUnit(Unit[,] grid, int row, int col)
        {
            // Get all the neighbors of the block (in the 3x3 square centered on the block - 
            // the Moore neighborhood
            List<Unit> neighbors = GetAllNeighbors(grid, row, col);
            // Will store the neighbor with the same type of the Unit to occupy this empty block
            Unit modelNeighbor = null;

            // Find the neighbor to base the new Unit on 
            modelNeighbor = GetModelNeighbor(CalculateNeighborProbabilities(neighbors));
            // Return the new non-null Unit that should occupy the block in the next generation
            return modelNeighbor.Create(row, col);
        }
        
        /// <summary>
        /// Given probabilities for a new child Unit (a Unit occupying a previously-empty block)
        /// to be of each of its neighbors' species, find the neighbor with the same species as the child Unit.
        /// </summary>
        /// <param name="neighborProbabilities">A mapping between a block's neighbors, and the cumulative probabilities
        /// that each of them will be selected as a model neighbor.</param>
        /// <returns>The non-null Unit (one of the block's neighbors) whose type is the same
        /// as the child Unit's type.</returns>
        private static Unit GetModelNeighbor(Dictionary<Unit, double> neighborProbabilities)
        {
            // Convert the dictionary into an iterable list of key-value pairs, sorted in ascending order
            // since the probabilities are cumulative
            var neighbors =
                (from neighbor
                in neighborProbabilities
                orderby neighbor.Value
                ascending
                select neighbor).ToList();
            // Get just the probabilities of each neighbor being selected as the model neighbor
            double[] sortedProbabilities = neighbors.Select(x => x.Value).ToArray();
            // Keep, in a parallel array, the neighbors corresponding to each probability
            Unit[] correspondingSpecies = neighbors.Select(x => x.Key).ToArray();
            
            // Get the index of the neighbor probabilistically selected to serve as a model neighbor
            int indexSelected = ProbabilityHelper.EvaluateDependentPredicate(sortedProbabilities);
            // Return the model neighbor
            return correspondingSpecies[indexSelected];
        }

        /// <summary>
        /// Calculates the probabilities that each of an empty block's Unit neighbors will be 
        /// selected as a model neighbor for the creation of a new Unit in the empty block. Probabilities
        /// are weighted towards favoring the creation of Units with a lower species complexity (e.g. a Cell
        /// is more likely to be formed than an Animal).
        /// </summary>
        /// <param name="neighbors">The list of all unique non-null neighbors in the Moore's neighborhood
        /// of the empty block. The neighbors can be in any order.</param>
        /// <returns>A mapping between each neighbor and its cumulative probability of being selected as 
        /// a model neighbor. The order of cumulative probabilities is on average irrelevant.</returns>
        private static Dictionary<Unit, double> CalculateNeighborProbabilities(List<Unit> neighbors)
        {
            // The sum of all the species complexities of Units in the block's Moore neighborhood.
            // Will be used to calculate probabilities for which species to birth, since 
            // the ruleset prioritizes simpler Units.
            int speciesComplexitySum = 0;

            // Iterate through all the block's neighbors
            foreach (Unit unit in neighbors)
            {
                // Add the Unit's species complexity to the sum
                speciesComplexitySum += unit.SpeciesComplexity;
            }

            // Prefix sum array to store all the cumulative probabilities of the neighbors
            double[] probs = new double[neighbors.Count];

            // Iterate through all the neighbors, and calculate their cumulative probabilities
            for(int i = 0; i < neighbors.Count; i++)
            {
                // Get the current neighbor
                Unit unit = neighbors[i];
                // Calculate the current probability that this neighbor will be selected
                // as a model neighbor. Since it weighs species complexity negatively, 
                // the species complexity term is negated; the probabilities of all 
                // neighbors sum to 1.
                double prob = 1 - (2 * unit.SpeciesComplexity) / speciesComplexitySum;
                // The cumulative probability up to and excluding the current neighbor.
                // Checks if there is a previous neighbor in the list; if not, the initial cumulative
                // probability must be 0.
                double cumulativeProb = i > 0 ? probs[i-1] : 0;
                // The cumulative probability up to and including this neighbor is the sum
                // of the neighbor's individual probability and previous cumulative probabilities
                probs[i] = prob + cumulativeProb;
            }

            // Return a mapping between the neighbors and their cumulative probabilities
            return neighbors.Zip(probs, (k, v) => new { k, v })
                            .ToDictionary(x => x.k, x => x.v);
        }

        

        private static List<Unit> GetAllNeighbors(Unit[,] grid, int row, int col)
        {
            List<Unit> neighbors = new List<Unit>();
            // Iterate through the Moore neighborhood
            for(int i = row - 1; i <= row + 1; i++)
            {
                for(int j = col - 1; j <= col + 1; j++)
                {
                    if ((i != row || j != col) && grid.InGridBounds(i, j) && grid[i, j] != null)
                    {
                        neighbors.Add(grid[i, j]);
                    }
                }
            }
            return neighbors;
        }

        private static int CountAllNeighbors(Unit[,] grid, int row, int col)
        {
            return CountLiveNeighbors(grid, row, col) + CountViralNeighbors(grid, row, col);
        }
       

        // TODO: check if null objects don't count
        private static bool IsLiveUnit(Unit unit)
        {
            return unit is LivingUnit;
        }
        
        private static int CountLiveNeighbors(Unit[,] grid, int row, int col)
        {
            return NumberOfNeighbors(grid, row, col, countViral: false);
        }

        private static int NumberOfNeighbors(Unit[,] grid, int row, int col, bool countViral)
        {
            int neighbors = 0;
            // Iterate through the Moore neighborhood
            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = col - 1; j <= col + 1; j++)
                {
                    if ((i != row || j != col) && grid.InGridBounds(i, j) && grid[i, j] != null)
                    {
                        neighbors += (!countViral == IsLiveUnit(grid[i, j]) ? 1 : 0);
                    }
                }
            }
            return neighbors;
        }

        private static int CountViralNeighbors(Unit[,] grid, int row, int col)
        {
            return NumberOfNeighbors(grid, row, col, countViral: true);
        }

        private static bool HasEnoughFood(LivingUnit unit, double foodAvailability, int liveNeighbors)
        {
            // Check if dies because of food deficiency
            double probability = (unit.FoodRequirement - foodAvailability) / unit.FoodRequirement;
            return ProbabilityHelper.EvaluateIndependentPredicate(probability);
        }

        private static bool UnitPersists(Unit unit, int liveNeighbors, double foodAvailability = 0)
        {
            if (liveNeighbors < UNDER_POP || liveNeighbors > OVER_POP)
            {
                return false;
            }

            if(unit is LivingUnit)
            {
                return HasEnoughFood((LivingUnit)unit, foodAvailability, liveNeighbors);
            }

            return true;
            
        }
        
    }
}
