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
            int liveNeighbours = FindLiveNeighbours(grid, row, col);
        }
        private static Enums.UnitType BirthType(Unit[,] grid, int row, int col) { throw new NotImplementedException(); }

        // TODO: check if null objects don't count
        private static bool IsLiveUnit(Unit unit)
        {
            return unit is LivingUnit;
        }

        private static bool InGridBounds(Unit[,] grid, int row, int col)
        {
            return (row < grid.GetLength(0) && col < grid.GetLength(1) && row >= 0 && col >= 0);
        }

        private static int FindLiveNeighbours(Unit[,] grid, int row, int col)
        {
            int liveNeighbours = 0;
            // Check up, down, left, right
            foreach(var dir in directions)
            {
                int newRow = row + dir.Item1;
                int newCol = col + dir.Item2;
                if(InGridBounds(grid, newRow, newCol))
                {
                    liveNeighbours += (IsLiveUnit(grid[newRow, newCol])? 1 : 0);
                }
                
            }
            return liveNeighbours;
        }

        private static bool UnitPersists(LivingUnit unit, double foodAvailability, int liveNeighbours)
        {
            if (liveNeighbours < UNDER_POP || liveNeighbours > 3)
            {
                return false;
            }

            // Check if dies because of food deficiency
            double probability = (unit.FoodRequirement - foodAvailability) / unit.FoodRequirement;
            return ProbabilityHelper.Predicate(probability);
        }
        
    }
}
