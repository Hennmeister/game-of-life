/*
 * Rudy Ariaz
 * January 19, 2019
 * Applies a modified Conway's Game of Life ruleset to a given unit. Abstracts
 * the ruleset from the GameManager.
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
        /// <param name="row">The row of the block to update.</param>
        /// <param name="col">The column of the block to update.</param>
        /// <returns>The new Unit that should occupy the block in this new generation.</returns>
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
            if (thisUnit is Virus)
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
        /// <param name="grid">The grid in which the LivingUnit to compute is.</param>
        /// <param name="foodAvailability">The number of food units available
        /// in the LivingUnit's environment.</param>
        /// <param name="row">The row of the LivingUnit to update.</param>
        /// <param name="col">The column of the LivingUnit to update.</param>
        /// <returns>The new LivingUnit that should occupy the block in this new generation.</returns>
        private static Unit NewLivingState(Unit[,] grid, double foodAvailability, int row, int col)
        {
            // The current Unit in the block to update
            Unit thisUnit = grid[row, col];

            // Count the number of live neighborus 
            int liveNeighbors = CountLiveNeighbors(grid, row, col);
            
            // Check if existing unit dies
            else if (!UnitPersists(thisUnit, liveNeighbors, foodAvailability))
            {
                return null;
            }
            // Otherwise, the unit remains the same
            return thisUnit;
        }
        // TODO: test the dictionary stuff
        private static Unit NewbornUnit(Unit[,] grid, int row, int col)
        {
            // Get all the living neighbors of the unit
            List<Unit> neighbors = GetAllNeighbors(grid, row, col);
            var typeFrequencies = neighbors.ToDictionary(x => x, 
                x => neighbors.Count(u => u.GetType() == x.GetType()));
            // neighbor with the same type as the new child
            Unit modelneighbor = null;
            // Check if any neighbor appears twice
            if (typeFrequencies.ContainsValue(2))
            {
                modelneighbor = typeFrequencies.FirstOrDefault(x => x.Value == 2).Key;
            }
            // Otherwise, probabilistic approach is used
            else
            {
                int speciesComplexitySum = 0;
                foreach(Unit unit in neighbors)
                {
                    speciesComplexitySum += unit.SpeciesComplexity;
                }
                modelneighbor = GetModelNeighbor(CalculateSpeciesProbabilities(speciesComplexitySum, neighbors));
            }
            // Create the unit
            return modelneighbor.Create(row, col);
        }

        private static Dictionary<Unit, double> CalculateSpeciesProbabilities(int complexitySum, List<Unit> neighbors)
        {
            Dictionary<Unit, double> speciesProbabilities = 
                new Dictionary<Unit, double>();
            // Iterate through all the neighbors, and calculate their cumulative probabilities
            for(int i = 0; i < neighbors.Count; i++)
            {
                Unit unit = neighbors[i];
                // Unit probability 
                double prob = 1 - (2 * unit.SpeciesComplexity) / complexitySum;
                double cumulativeProb = i > 0 ? speciesProbabilities[neighbors[i - 1]] : 0;
                speciesProbabilities.Add(unit, prob + cumulativeProb);
            }
            // Return the cumulative probabilities
            return speciesProbabilities;
        }

        // Gets the neighbor to model a new child on given species probabilities
        // TODO: test
        private static Unit GetModelNeighbor(Dictionary<Unit, double> speciesProbabilities)
        {
            // Get the probabilities
            var neighbors = speciesProbabilities.ToList();
            double[] sortedProbabilities = (double[])neighbors.Select(x => x.Value);
            Unit[] correspondingSpecies = (Unit[])neighbors.Select(x => x.Key);


            // Get the first unit to have its predicate be true
            int indexSelected = ProbabilityHelper.EvaluateDependentPredicate(sortedProbabilities);
            return correspondingSpecies[indexSelected];
        }

        private static List<Unit> GetAllNeighbors(Unit[,] grid, int row, int col)
        {
            List<Unit> neighbors = new List<Unit>();
            foreach(var dir in GridHelper.directions)
            {
                int newRow = row + dir.Item1;
                int newCol = col + dir.Item2;
                if (grid.InGridBounds(newRow, newCol) && grid[newRow, newCol] != null)
                {
                    neighbors.Add(grid[newRow, newCol]);
                }
            }
            return neighbors;
        }

        private static int CountAllNeighbors(Unit[,] grid, int row, int col)
        {
            return CountLiveNeighbors(grid, row, col) + CountViralNeighbors(grid, row, col);
        }
        private static Unit NewVirusState(Unit[,] grid, int row, int col)
        {
            int liveNeighbors = CountViralNeighbors(grid, row, col);
            Unit thisUnit = grid[row, col];
            
            // Check if there is no unit in the block  
            if(thisUnit == null)
            {
                // Unit is born
                if(liveNeighbors == OVER_POP)
                {
                    return new Virus();
                }
                return null;
            }

            // Virus dies
            if (!UnitPersists(thisUnit, liveNeighbors : liveNeighbors))
            {
                return null;
            }
            // Otherwise, the unit persists
            return thisUnit;
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
            foreach (var dir in GridHelper.directions)
            {
                int newRow = row + dir.Item1;
                int newCol = col + dir.Item2;
                if (grid.InGridBounds(newRow, newCol))
                {
                    neighbors += (!countViral == IsLiveUnit(grid[newRow, newCol]) ? 1 : 0);
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
