// Tiffanie
// (Nicole) - added unitType
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Colony : LivingUnit
    {
        public static readonly System.Drawing.Color baselineColor = System.Drawing.Color.LightSkyBlue;

        public Colony(int row = -1, int col = -1) : base(speciesComplexity: 3, senescence: 16,
                               foodRequirement: 4, waterRequirement: 4,
                               gasRequirement: 2, inputGas: Enums.GasType.Oxygen,
                               outputGas: Enums.GasType.CarbonDioxide, idealTemperature: 32,
                               infectionResistance: 5, decompositionValue: 6, row: row, col: col)
        {
            // (Nicole) - added unitType
            unitType = UnitTypeEnum.Colony;
        }

        public override Unit Create(int row, int col)
        {
            return new Colony(row, col);
        }

        public override void Update(Unit[,] grid, Environment gameEnv)
        {

        }

        public bool CheckMerge(Unit[,] grid)
        {
            throw new NotImplementedException();
        }

        public void Merge(Unit[,] grid)
        {

        }

        public void SplitUp(Unit[,] grid)
        {

        }
    }
}
