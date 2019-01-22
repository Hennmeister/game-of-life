/*
 * Rudy Ariaz, Tiffanie Truong, Nicole Beri
 * January 19, 2019
 * Colony class encapsulates information regarding Colonies and implements operations that a Colony
 * can perform.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    [Serializable]
    class Colony : MergeableUnit
    {
        // Store the color with which the Colony is represented
        public static readonly System.Drawing.Color baselineColor = System.Drawing.Color.LightSkyBlue;

        /// <summary>
        /// Constructor used to instantiate completely new Colony objects.
        /// </summary>
        /// <remarks>
        /// Author: Tiffanie Truong
        /// </remarks>
        /// <param name="row">Row of the Colony in the grid.</param>
        /// <param name="col">Column of the Colony in the grid.</param>
        public Colony(int row = -1, int col = -1) : base(Enums.UnitType.Colony, speciesComplexity: 3, senescence: 16,
                               foodRequirement: 4, waterRequirement: 4,
                               gasRequirement: 2, inputGas: Enums.GasType.Oxygen,
                               outputGas: Enums.GasType.CarbonDioxide, idealTemperature: 32,
                               infectionResistance: 5, decompositionValue: 6, row: row, col: col)
        {
        }

        /// <summary>
        /// Constructor used to instantiate new Colony objects given the parameters of a saved Colony object.
        /// Used in loading Colony.
        /// </summary>
        /// <remarks>
        /// Author: Nicole Beri
        /// </remarks>
        /// <param name="parameters">A string parameter array representation of a saved Colony,
        /// following the format described in UnitFileFormat.</param>
        public Colony(string[] parameters) : base(parameters)
        {
            // Set the UnitType of the Colony
            UnitType = Enums.UnitType.Colony;
        }

        /// <summary>
        /// Creates and returns a new Colony object given the row and column. Used in UnitFactory.
        /// </summary>
        /// <remarks>
        /// Author: Tiffanie Truong
        /// </remarks>
        /// <param name="row">Row of the Colony in the grid.</param>
        /// <param name="col">Column of the Colony in the Grid.</param>
        /// <returns>A new Colony object with the given row and column.</returns>
        public override Unit Create(int row, int col)
        {
            // Return the Colony with the given row and column
            return new Colony(row, col);
        }

        /// <summary>
        /// Creates and returns a new Colony object given parameters describing a saved Colony object.
        /// Used in UnitFactory.
        /// </summary>
        /// <remarks>
        /// Author: Nicole Beri
        /// </remarks>
        /// <param name="parameters">A string parameter array representation of a saved
        /// Colony. Follows the format described in UnitFileFormat.</param>
        /// <returns>A new Colony object with the given parameters.</returns>
        public override Unit Create(string[] parameters)
        {
            // Return the Colony with the given parameters
            return new Colony(parameters);
        }

        /// <summary>
        /// Updates a Colony with all operations that must be applied to the Colony every generation.
        /// Performs merging, splitting, and regular operations that a LivingUnit performs..
        /// </summary>
        /// <remarks>
        /// Author: Rudy Ariaz
        /// </remarks>
        /// <param name="grid">The grid of Units in which the Colony is.</param>
        /// <param name="gameEnv">The Environment with which the Colony interacts.</param>
        public override void Update(Unit[,] grid, Environment gameEnv)
        {
            // Check if there is not enough food in the Environment (food requirement exceeds availability)
            if(FoodRequirement > gameEnv.FoodAvailability)
            {
                // Split up the Colony into multiple cells
                SplitUp(grid, gameEnv);
            }
            // Otherwise, check if the Colony should merge with neighboring Colonies into a Multicellular organism
            else if (ShouldMerge(grid))
            {
                // Merge the Colony 
                Merge(grid, gameEnv);
            }
            // Otherwise, no special operations should be performed
            else
            {
                // Simply update the Colony with the usual LivingUnit operations
                UpdateLivingUnit(grid, gameEnv);
            }
        }
        
        /// <summary>
        /// Compute which Multicellular type a Colony should merge into: Plant or Animal.
        /// This is probabilistically based on the atmosphere of the Environment:
        /// The more carbon dioxide in the atmosphere, the more likely it is for a Plant to be formed. 
        /// </summary>
        /// <remarks>
        /// Author: Rudy Ariaz
        /// </remarks>
        /// <param name="gameEnv">The Environment of the Colony.</param>
        /// <returns>Enums.Animal if an Animal should be formed upon merging, Enums.Plant if a Plant
        /// should be formed upon merging.</returns>
        private Enums.UnitType GetMergeType(Environment gameEnv)
        {
            // The probability to merge into a plant is the normalized percentage
            // of the atmosphere that is carbon dioxide
            double plantProbability = gameEnv.CarbonDioxideLevel / 100.0;

            // Check if a Plant should be formed
            if (ProbabilityHelper.EvaluateIndependentPredicate(plantProbability))
            {
                // Return Plant as the type of Multicellular organism to be formed
                return Enums.UnitType.Plant;
            }
            // Otherwise, an Animal should be formed
            else
            {
                // Return Animal as the type of Multicellular organism to be formed
                return Enums.UnitType.Animal;
            }
        }


        /// <summary>
        /// Merge a Colony with neighboring Colonies into a Multicellular organism.
        /// Precondition: the Colony should be merged (that is, it is the top left block 
        /// in a 2x2 square of neighboring colonies).
        /// </summary>
        /// <remarks>
        /// Author: Rudy Ariaz
        /// </remarks>
        /// <param name="grid">The grid in which the Colony is.</param>
        /// <param name="gameEnv">The Environment of the Colony.</param>
        protected override void Merge(Unit[,] grid, Environment gameEnv)
        {
            // Kill the Colonies that should be merged
            KillMergedUnits(grid, gameEnv);
            // Replace the current Colony with a newly created Plant or Animal, depending 
            // on the environmental conditions
            grid[Location.r, Location.c] =
                UnitFactory.CreateUnit(GetMergeType(gameEnv), Location.r, Location.c);
        }

        /// <summary>
        /// Splits up the Colony into 4 cells in a 2x2 square. Called when there is insufficient
        /// food for the Colony.
        /// </summary>
        /// <remarks>
        /// This is meant to be a rare event.
        /// Author: Rudy Ariaz
        /// </remarks>
        /// <param name="grid">The grid in which the Colony is.</param>
        /// <param name="gameEnv">The Environment of the Colony.</param>
        public void SplitUp(Unit[,] grid, Environment gameEnv)
        {
            // Get the row and column of the Colony
            int row = Location.r, col = Location.c;
            /*
             * Try splitting in each direction, in this order:
                * Cell is in the top left corner
                * Cell is in the bottom left corner
                * Cell is in the top right corner
                * Cell is in the bottom right corner
             */
            // Iterate through the different directions of vertical splitting
            for (int rowDir = 1; rowDir >= -1; rowDir -= 2)
            {
                // Iterate through the different directions of horizontal splitting
                for(int colDir = 1; colDir >= -1; colDir -= 2)
                {
                    // Check if the split is possible in this direction
                    if(IsSplitPossible(grid, rowDir, colDir))
                    {
                        // Kill the exisitng Colony
                        this.Die(grid, gameEnv);
                        // Spread the new Cells out in the current direction
                        grid[row, col] = new Cell(row, col);
                        grid[row, col + colDir] = new Cell(row, col + colDir);
                        grid[row + rowDir, col] = new Cell(row + rowDir, col);
                        grid[row + rowDir, col + colDir] = new Cell(row + rowDir, col + colDir);
                        // Stop searching for valid splitting directions
                        break;
                    }
                }
            }
        }
        
        /// <summary>
        /// Checks if it is possible, given the grid and the Colony's location, for the Colony
        /// to split into 4 Cells in a 2x2 square in the given direction.
        /// </summary>
        /// <remarks>
        /// Author: Rudy Ariaz
        /// </remarks>
        /// <param name="grid">The grid in which the Colony is.</param>
        /// <param name="rowDirection">The vertical direction of splitting. +1 if the split
        /// should occur downwards, -1 if the split should occur upwards.</param>
        /// <param name="colDirection">The horizontal direction of splitting. +1 if the split
        /// should occur to the right, -1 if the split should occur to the left.</param>
        /// <returns>True if the split in the given direction is possible, false otherwise..</returns>
        private bool IsSplitPossible(Unit[,] grid, int rowDirection, int colDirection)
        {
            // Check for invalid arguments (the directions must have an absolute value of 1)
            if(Math.Abs(rowDirection) > 1 || Math.Abs(colDirection) > 1)
            {
                // Indicate that the split is not possible
                return false;
            }
            // Otherwise, get the current row and column
            int row = Location.r, col = Location.c;
            // Check if the farthest newly created cell is still within the grid, in which
            // case the split is possible.
            return grid.InDimension(GridHelper.ROW, row + rowDirection) &&
                   grid.InDimension(GridHelper.COLUMN, col + colDirection);
        }
    }
}
