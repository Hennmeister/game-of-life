// rudy 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    static class Ruleset
    {
        
        private const int UNDER_POP = 2, OVER_POP = 3;
        private static Random rng = new Random();

        public static Unit NewBlockState(Unit[,] grid, double foodAvailability, int row, int col)
        {
            Unit thisUnit = grid[row, col];
            // If the unit is a virus
            if (thisUnit is Virus)
            {
                return NewVirusState(grid, row, col);
            }
            int liveneighbors = CountLiveNeighbors(grid, row, col);

            // Check if new unit is born 
            if (thisUnit == null)
            {
                if (liveneighbors == 3)
                {
                    return NewbornUnit(grid, row, col);
                }
            }
            // Check if existing unit dies
            else if (!UnitPersists(thisUnit, liveneighbors, foodAvailability))
            {
                return null;
            }
            // Otherwise, the unit remains the same
            return thisUnit;
        }

        // TODO: test the dictionary stuff
        private static LivingUnit NewbornUnit(Unit[,] grid, int row, int col)
        {
            // Get all the living neighbors of the unit
            List<LivingUnit> livingneighbors = GetLivingNeighbors(grid, row, col);
            var typeFrequencies = livingneighbors.ToDictionary(x => x, 
                x => livingneighbors.Count(u => u.GetType() == x.GetType()));
            // neighbor with the same type as the new child
            LivingUnit modelneighbor;
            // Check if any neighbor appears twice
            if (typeFrequencies.ContainsValue(2))
            {
                modelneighbor = typeFrequencies.FirstOrDefault(x => x.Value == 2).Key;
            }
            // Otherwise, probabilistic approach is used
            else
            {
                int speciesComplexitySum = 0;
                foreach(LivingUnit unit in livingneighbors)
                {
                    speciesComplexitySum += unit.SpeciesComplexity;
                }
                modelneighbor = GetModelNeighbor(CalculateSpeciesProbabilities(speciesComplexitySum, livingneighbors));
            }
            // Create the unit
            return (LivingUnit)modelneighbor.Create(row, col);
        }

        private static Dictionary<LivingUnit, double> CalculateSpeciesProbabilities(int complexitySum, List<LivingUnit> neighbors)
        {
            Dictionary<LivingUnit, double> speciesProbabilities = 
                new Dictionary<LivingUnit, double>();
            // Iterate through all the neighbors, and calculate their cumulative probabilities
            for(int i = 0; i < neighbors.Count; i++)
            {
                LivingUnit unit = neighbors[i];
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
        private static LivingUnit GetModelNeighbor(Dictionary<LivingUnit, double> speciesProbabilities)
        {
            // Get the probabilities
            var neighbors = speciesProbabilities.ToList();
            double[] sortedProbabilities = (double[])neighbors.Select(x => x.Value);
            LivingUnit[] correspondingSpecies = (LivingUnit[])neighbors.Select(x => x.Key);


            // Get the first unit to have its predicate be true
            int indexSelected = ProbabilityHelper.DependentPredicate(sortedProbabilities);
            return correspondingSpecies[indexSelected];
        }

        private static List<LivingUnit> GetLivingNeighbors(Unit[,] grid, int row, int col)
        {
            List<LivingUnit> livingneighbors = new List<LivingUnit>();
            foreach(var dir in GridHelper.directions)
            {
                int newRow = row + dir.Item1;
                int newCol = col + dir.Item2;
                if (grid.InGridBounds(newRow, newCol) && IsLiveUnit(grid[newRow, newCol]))
                {
                    livingneighbors.Add((LivingUnit)grid[newRow, newCol]);
                }
            }
            return livingneighbors;
        }
        private static Unit NewVirusState(Unit[,] grid, int row, int col)
        {
            int liveneighbors = CountLiveNeighbors(grid, row, col);
            Unit thisUnit = grid[row, col];
            
            // Check if there is no unit in the block  
            if(thisUnit == null)
            {
                // Unit is born
                if(liveneighbors == OVER_POP)
                {
                    return new Virus();
                }
                return null;
            }

            // Virus dies
            if (!UnitPersists(thisUnit, liveNeighbors : liveneighbors))
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
            return NumberOfNeighbors(grid, row, col, countViral: false);
        }

        private static bool HasEnoughFood(LivingUnit unit, double foodAvailability, int liveNeighbors)
        {
            // Check if dies because of food deficiency
            double probability = (unit.FoodRequirement - foodAvailability) / unit.FoodRequirement;
            return ProbabilityHelper.IndependentPredicate(probability);
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
