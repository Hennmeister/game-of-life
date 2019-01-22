/*
 * Tiffanie Truong
 * (Nicole) - added unitType and constructor for loading data from file
 * January 15, 2018
 * This class stores information for a Cell, one of the basic lifeforms that can populate the grid in the simulation.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    [Serializable]
    class Cell : MergeableUnit
    {
        public static readonly Color baselineColor = Color.Turquoise;
        /// <summary>
        /// Create a new Cell object
        /// </summary>
        public Cell(int row = -1, int col = -1) : base(Enums.UnitType.Cell, speciesComplexity: 2, senescence: 16,
                               foodRequirement: 1, waterRequirement: 1,
                               gasRequirement: 1, inputGas: Enums.GasType.Oxygen,
                               outputGas: Enums.GasType.CarbonDioxide, idealTemperature: 30,
                               infectionResistance: 3, decompositionValue: 0.5, row: row, col: col)
        {
        }

        // (Nicole) --> constructor for reading files
        public Cell(string[] parameters) : base(parameters)
        {
            UnitType = Enums.UnitType.Cell;
        }

        /// <summary>
        /// Used by the UnitFactory to create a new Cell
        /// <returns> A new Cell object </returns>
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public override Unit Create(int row = -1, int col = -1)
        {
            return new Cell(row, col);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public override Unit Create(string[] parameters)
        {
            return new Cell(parameters);
        }

        /// <summary>
        /// Updates the Cell for the next generation
        /// </summary>
        /// <param name="grid"> The grid of Units currently in the simulation </param>
        /// <param name="row"> The row of the grid that this Cell resides in </param>
        /// <param name="col"> The column of the grid that this Cell resides in </param>
        public override void Update(Unit[,] grid, Environment gameEnv)
        {
            // If the Cell is in a position to merge into a colony with other cells, do the merge
            if (ShouldMerge(grid))
            {
                Merge(grid, gameEnv);
            }
            // Otherwise, update the Cell as needed
            else
            {
                // Save if the cell is initially infected to determine if it has been cured in this generation 
                bool initiallyInfected = Infected;
                // Process the cell's life functions (i.e. eat, drink, respire, and cure)
                UpdateLivingUnit(grid, gameEnv);
                // Check if the Cell was cured during the generationm
                if (!Infected && initiallyInfected)
                {
                    // Increase its infection resistance
                    InfectionResistance += 0.5;
                    // Ensure the maximum infection resistance is updated if need be
                    MaxResistance = Math.Max(MaxResistance, InfectionResistance);
                }
            }
        }

        /// <summary>
        /// Merges the current Cell with the 3 other Cells in a 2x2 block with this Cell as the top left
        /// </summary>
        /// <param name="grid"> The grid of Units currently in the simulation </param>
        /// <param name="row"> The row of the grid that this Cell resides in </param>
        /// <param name="col"> The column of the grid that this Cell resides in </param>
        protected override void Merge(Unit[,] grid, Environment gameEnv)
        {
            // Remove the 3 other units merged with this Cell
            KillMergedUnits(grid, gameEnv);
            // Replace the current Cell with a newly created Colony from the UnitFactory
            grid[Location.r, Location.c] =
                UnitFactory.CreateUnit(Enums.UnitType.Colony, Location.r, Location.c);
        }
    }
}
