/*
 * Tiffanie Truong
 * January 15, 2018
 * This class stores information for a Cell, one of the basic
 * lifeforms that can populate the grid in the simulation.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Cell : LivingUnit
    {
        public static readonly Color baselineColor = Color.Turquoise;
        /// <summary>
        /// Create a new Cell object
        /// </summary>
        public Cell() : base(speciesComplexity: 2, senescence: 16,
                               foodRequirement: 1, waterRequirement: 1,
                               gasRequirement: 1, inputGas: Enums.GasType.Oxygen,
                               outputGas: Enums.GasType.CarbonDioxide, idealTemperature: 30,
                               infectionResistance: 3, decompositionValue: 0.5)
        {
        }

        /// <summary>
        /// Used by the UnitFactory to create a new Cell
        /// </summary>
        /// <returns> A new Cell object </returns>
        public override Unit Create()
        {
            return new Cell();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grid"> The grid of Units currently in the simulation </param>
        /// <param name="row"> The row of the grid that this Cell resides in </param>
        /// <param name="col"> The column of the grid that this Cell resides in </param>
        public override void Update(Unit[,] grid, int row, int col)
        {
            // If the Cell is in a position to merge into a colony with other cells, do the merge
            if (ShouldMerge(grid, row, col))
            {
                Merge(grid, row, col);
            }
        }

        /// <summary>
        /// Checks if the Cell is in a position to turn into a colony
        /// </summary>
        /// <param name="grid"> The grid of Units currently in the simulation </param>
        /// <param name="row"> The row of the grid that this Cell resides in </param>
        /// <param name="col"> The column of the grid that this Cell resides in </param>
        /// <returns> True if the Cell is the top left of a 2x2 square with other Cells
        ///           and should merge into a colony, and false otherwise </returns>
        public bool ShouldMerge(Unit[,] grid, int row, int col)
        {
            // if the cell is not in a space capable of forming a 2x2 square, it cannot merge
            if (row + 1 >= grid.GetLength(ROW) || col + 1 >= grid.GetLength(COLUMN))
            {
                return false;
            }
            // otherwise, if the surrounding 3 grids are Cells, this cell should merge
            else if (grid[row, col+1] is Cell && grid[row+1, col] is Cell && grid[row+1, col+1] is Cell)
            {
                return true;
            }
            // otherwise, this Cell does not meet the requirements to form a colony
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Merges the current Cell with the 3 other Cells in a 2x2 block with this Cell as the top left
        /// </summary>
        /// <param name="grid"> The grid of Units currently in the simulation </param>
        /// <param name="row"> The row of the grid that this Cell resides in </param>
        /// <param name="col"> The column of the grid that this Cell resides in </param>
        public void Merge(Unit[,] grid, int row, int col)
        {
            // Delete references to the 3 other Cells in the 2x2 block 
            // so they are deleted by the garbage collector
            grid[row, col + 1] = null;
            grid[row + 1, col] = null;
            grid[row + 1, col + 1] = null;
            // Replace the current Cell with a newly created Colony
            grid[row, col] = UnitFactory.CreateUnit(Enums.UnitType.Colony);
        }
    }
}
