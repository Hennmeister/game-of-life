// Tiffanie
// (Nicole) - added unitType and constructor for loading data from file
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
        public static readonly System.Drawing.Color baselineColor = System.Drawing.Color.LightSkyBlue;

        public Colony(int row = -1, int col = -1) : base(Enums.UnitType.Colony, speciesComplexity: 3, senescence: 16,
                               foodRequirement: 4, waterRequirement: 4,
                               gasRequirement: 2, inputGas: Enums.GasType.Oxygen,
                               outputGas: Enums.GasType.CarbonDioxide, idealTemperature: 32,
                               infectionResistance: 5, decompositionValue: 6, row: row, col: col)
        {
        }

        // (Nicole) constructor for loading data from file
        public Colony(string[] parameters) : base(parameters)
        {
            UnitType = Enums.UnitType.Colony;
        }

        public override Unit Create(int row, int col)
        {
            return new Colony(row, col);
        }

        public override Unit Create(string[] parameters)
        {
            return new Colony(parameters);
        }

        public override void Update(Unit[,] grid, Environment gameEnv)
        {
            if(FoodRequirement > gameEnv.FoodAvailability)
            {
                SplitUp(grid, gameEnv);
            }
            else if (ShouldMerge(grid))
            {
                Merge(grid, gameEnv);
            }
            else
            {
                UpdateLivingUnit(grid, gameEnv);
            }
        }
        

        private Enums.UnitType GetMergeType(Environment gameEnv)
        {
            // The probability to merge into a plant is the normalized percentage
            // of the atmosphere that is carbon dioxide
            double plantProbability = gameEnv.CarbonDioxideLevel / 100.0;
            if (ProbabilityHelper.EvaluateIndependentPredicate(plantProbability))
            {
                return Enums.UnitType.Plant;
            }
            else
            {
                return Enums.UnitType.Animal;
            }
        }

        protected override void Merge(Unit[,] grid, Environment gameEnv)
        {
            KillMergedUnits(grid, gameEnv);
            // Replace the current Colony with a newly created Plant or Animal
            grid[Location.r, Location.c] =
                UnitFactory.CreateUnit(GetMergeType(gameEnv), Location.r, Location.c);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>This is meant to be a rare event.</remarks>
        /// <param name="grid"></param>
        /// <param name="gameEnv"></param>
        public void SplitUp(Unit[,] grid, Environment gameEnv)
        {
            int row = Location.r, col = Location.c;
            /*
             * Try splitting in each direction, in this order:
                * Cell is in the top left corner
                * Cell is in the bottom left corner
                * Cell is in the top right corner
                * Cell is in the bottom right corner
             */
            for (int rowDir = 1; rowDir >= -1; rowDir -= 2)
            {
                for(int colDir = 1; colDir >= -1; colDir -= 2)
                {
                    if(IsSplitPossible(grid, rowDir, colDir))
                    {
                        // Kill the colony
                        this.Die(grid, gameEnv);
                        // Spread the cells
                        grid[row, col] = new Cell(row, col);
                        grid[row, col + colDir] = new Cell(row, col + colDir);
                        grid[row + rowDir, col] = new Cell(row + rowDir, col);
                        grid[row + rowDir, col + colDir] = new Cell(row + rowDir, col + colDir);
                        break;
                    }
                }
            }
        }

        // Checks if it's possible to split in the direction dictated by rowDirection,
        // colDirection
        private bool IsSplitPossible(Unit[,] grid, int rowDirection, int colDirection)
        {
            int row = Location.r, col = Location.c;
            return grid.InDimension(GridHelper.ROW, row + rowDirection) &&
                   grid.InDimension(GridHelper.COLUMN, col + colDirection);
        }
    }
}
