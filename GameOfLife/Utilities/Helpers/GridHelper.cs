/*
 * Rudy Ariaz
 * Janurary 22, 2019
 * Provides functions that assist with calculations concerning the grid
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    static class GridHelper
    {
        /// <summary>
        /// Directions are arranged in the order used by viruses to infect neighbors
        /// </summary>
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

        /// <summary>
        /// Checks whether a given location is within the gird
        /// </summary>
        /// <param name="grid">The unit grid</param>
        /// <param name="row">The row index of the location</param>
        /// <param name="col">The column index of the location</param>
        /// <returns>
        /// True if the location is within the grid
        /// False if the location is not within the grid</returns>
        public static bool InGridBounds(this Unit[,] grid, int row, int col)
        {
            return grid.InDimension(ROW, row) && grid.InDimension(COLUMN, col);
        }

        /// <summary>
        /// Helper method for checking whether a cordiante is within one dimension of the grid
        /// </summary>
        /// <param name="grid">The unit grid</param>
        /// <param name="dimension">The dimension of the grid to check</param>
        /// <param name="coordinate">The coordinate of the point within the given dimension</param>
        /// <returns>
        /// True if the given coordinate is within the given dimension
        /// False if the given coordinate is not within the given dimension</returns>
        public static bool InDimension(this Unit[,] grid, int dimension, int coordinate)
        {
            //check that the given dimension matches either the row or column index
            if(dimension != ROW && dimension != COLUMN)
            {
                //if not, return false
                return false;
            }
            //ohterwise return whether the coordinate is within the size of the dimension
            return coordinate < grid.GetLength(dimension) && coordinate >= 0;
        }
    }
}
