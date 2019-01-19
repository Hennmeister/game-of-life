using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    abstract class MergeableUnit : LivingUnit
    {

        public MergeableUnit(int speciesComplexity, int senescence, int foodRequirement,
                          int waterRequirement, int gasRequirement, Enums.GasType inputGas,
                          Enums.GasType outputGas, int idealTemperature, double infectionResistance,
                          double decompositionValue, int row = -1, int col = -1) : base(speciesComplexity: 2, senescence: 16,
                          foodRequirement: 1, waterRequirement: 1,
                          gasRequirement: 1, inputGas: Enums.GasType.Oxygen,
                          outputGas: Enums.GasType.CarbonDioxide, idealTemperature: 30,
                          infectionResistance: 3, decompositionValue: 0.5, row: row, col: col)
        {
        }

        /// <summary>
        /// Checks if the MergeableUnit is in a position to merge (into a Colony if it 
        /// is a cell, or into a Plant or Animal if it is a Colony).
        /// </summary>
        /// <param name="grid"> The grid of Units currently in the simulation </param>
        /// <param name="row"> The row of the grid that this MergeableUnit resides in. </param>
        /// <param name="col"> The column of the grid that this MergeableUnit resides in. </param>
        /// <returns> True if the MergeableUnit is the top left of a 2x2 square with other
        ///           MergeableUnits of the same species and should merge, false otherwise. </returns>
        protected bool ShouldMerge(Unit[,] grid)
        {
            var curType = this.GetType();
            int row = Location.r, col = Location.c;
            // if the cell is not in a space capable of forming a 2x2 square, it cannot merge
            if (!grid.InDimension(GridHelper.ROW, row + 1) || 
                !grid.InDimension(GridHelper.COLUMN, col + 1))
            {
                return false;
            }
            // otherwise, if the surrounding 3 grids are Cells, this cell should merge
            else if (grid[row, col + 1].GetType() == curType && 
                     grid[row + 1, col].GetType() == curType && 
                     grid[row + 1, col + 1].GetType() == curType)
            {
                return true;
            }
            // otherwise, this Cell does not meet the requirements to form a colony
            else
            {
                return false;
            }
        }

        protected abstract void Merge(Unit[,] grid, Environment gameEnv);

        protected void KillMergedUnits(Unit[,] grid, Environment gameEnv)
        {
            int row = Location.r, col = Location.c;
            for (int i = 0; i <= 1; i++)
            {
                for (int j = 0; j <= 1; j++)
                {
                    grid[row + i, col + j].Die(grid, gameEnv);
                }
            }
        }
    }
}
