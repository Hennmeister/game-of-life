using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    static class GridHelper
    {
        // Directions are arranged in the order used by viruses to infect neighbors
        public static readonly Tuple<int, int>[] directions = new Tuple<int, int>[]
        {
            Tuple.Create(-1, 0),
            Tuple.Create(0, 1),
            Tuple.Create(0, -1),
            Tuple.Create(1, 0)
        };

        // Specifies the dimension used for GetLength()
        public const int ROW = 0;
        public const int COLUMN = 1;

        public static bool InGridBounds(this Unit[,] grid, int row, int col)
        {
            return (row < grid.GetLength(0) && col < grid.GetLength(1) && row >= 0 && col >= 0);
        }
    }
}
