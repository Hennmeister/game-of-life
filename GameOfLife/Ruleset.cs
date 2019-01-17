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
        private static Tuple<int, int>[] directions = new Tuple<int, int>[] {Tuple.Create(-1, 0),
                                                                             Tuple.Create(1, 0),
                                                                             Tuple.Create(0, -1),
                                                                             Tuple.Create(0, 1)};
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
            int liveNeighbours = CountLiveNeighbours(grid, row, col);

            // Check if new unit is born 
            if (thisUnit == null)
            {
                if (liveNeighbours == 3)
                {
                    return NewbornUnit(grid, row, col);
                }
            }
            // Check if existing unit dies
            else if (!UnitPersists(thisUnit, foodAvailability, liveNeighbours))
            {
                return null;
            }
            // Otherwise, the unit remains the same
            return thisUnit;
        }

        // TODO: test the dictionary stuff
        private static LivingUnit NewbornUnit(Unit[,] grid, int row, int col)
        {
            // Get all the living neighbours of the unit
            List<LivingUnit> livingNeighbours = GetLivingNeighbours(grid, row, col);
            var typeFrequencies = livingNeighbours.ToDictionary(x => x, 
                x => livingNeighbours.Count(u => u.GetType() == x.GetType()));
            // Neighbour with the same type as the new child
            LivingUnit modelNeighbour;
            // Check if any neighbour appears twice
            if (typeFrequencies.ContainsValue(2))
            {
                modelNeighbour = typeFrequencies.FirstOrDefault(x => x.Value == 2).Key;
            }
            // Otherwise, probabilistic approach is used
            else
            {
                int speciesComplexitySum = 0;
                foreach(LivingUnit unit in livingNeighbours)
                {
                    speciesComplexitySum += unit.SpeciesComplexity;
                }
                modelNeighbour = GetModelNeighbour(CalculateSpeciesProbabilities(speciesComplexitySum, livingNeighbours));
            }
            // Create the unit
            return (LivingUnit)modelNeighbour.Create();
        }

        private static Dictionary<LivingUnit, double> CalculateSpeciesProbabilities(int complexitySum, List<LivingUnit> neighbours)
        {
            Dictionary<LivingUnit, double> speciesProbabilities = 
                new Dictionary<LivingUnit, double>();
            // Iterate through all the neighbours, and calculate their cumulative probabilities
            for(int i = 0; i < neighbours.Count; i++)
            {
                LivingUnit unit = neighbours[i];
                // Unit probability 
                double prob = 1 - (2 * unit.SpeciesComplexity) / complexitySum;
                double cumulativeProb = i > 0 ? speciesProbabilities[neighbours[i - 1]] : 0;
                speciesProbabilities.Add(unit, prob + cumulativeProb);
            }
            // Return the cumulative probabilities
            return speciesProbabilities;
        }

        // Gets the neighbour to model a new child on given species probabilities
        // TODO: test
        private static LivingUnit GetModelNeighbour(Dictionary<LivingUnit, double> speciesProbabilities)
        {
            // Sort the probabilities
            var sortedProbabilities = 
                from p in speciesProbabilities
                orderby p.Value 
                ascending select p;
            // Get the first unit to have its predicate be true
            return sortedProbabilities.First(p => ProbabilityHelper.Predicate(p.Value)).Key;
        }

        private static List<LivingUnit> GetLivingNeighbours(Unit[,] grid, int row, int col)
        {
            List<LivingUnit> livingNeighbours = new List<LivingUnit>();
            foreach(var dir in directions)
            {
                int newRow = row + dir.Item1;
                int newCol = col + dir.Item2;
                if (InGridBounds(grid, newRow, newCol) && IsLiveUnit(grid[newRow, newCol]))
                {
                    livingNeighbours.Add((LivingUnit)grid[newRow, newCol]);
                }
            }
            return livingNeighbours;
        }
        private static Unit NewVirusState(Unit[,] grid, int row, int col)
        {
            int liveNeighbours = CountLiveNeighbours(grid, row, col);
            Unit thisUnit = grid[row, col];
            
            // Check if there is no unit in the block  
            if(thisUnit == null)
            {
                // Unit is born
                if(liveNeighbours == OVER_POP)
                {
                    return new Virus();
                }
                return null;
            }

            // Virus dies
            if (!UnitPersists(thisUnit, liveNeighbours : liveNeighbours))
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

        private static bool InGridBounds(Unit[,] grid, int row, int col)
        {
            return (row < grid.GetLength(0) && col < grid.GetLength(1) && row >= 0 && col >= 0);
        }

        private static int CountLiveNeighbours(Unit[,] grid, int row, int col)
        {
            return CountNeighbours(grid, row, col, countViral: false);
        }

        private static int CountNeighbours(Unit[,] grid, int row, int col, bool countViral)
        {
            int neighbours = 0;
            foreach (var dir in directions)
            {
                int newRow = row + dir.Item1;
                int newCol = col + dir.Item2;
                if (InGridBounds(grid, newRow, newCol))
                {
                    neighbours += (!countViral == IsLiveUnit(grid[newRow, newCol]) ? 1 : 0);
                }

            }
            return neighbours;
        }

        private static int CountViralNeighbours(Unit[,] grid, int row, int col)
        {
            return CountNeighbours(grid, row, col, countViral: false);
        }

        private static bool HasEnoughFood(LivingUnit unit, double foodAvailability, int liveNeighbours)
        {
            // Check if dies because of food deficiency
            double probability = (unit.FoodRequirement - foodAvailability) / unit.FoodRequirement;
            return ProbabilityHelper.Predicate(probability);
        }

        private static bool UnitPersists(Unit unit, double foodAvailability = 0, int liveNeighbours)
        {
            if (liveNeighbours < UNDER_POP || liveNeighbours > OVER_POP)
            {
                return false;
            }

            if(unit is LivingUnit)
            {
                return HasEnoughFood((LivingUnit)unit, foodAvailability, liveNeighbours);
            }

            return true;
            
        }
        
    }
}
