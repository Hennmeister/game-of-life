// Tiffanie
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Colony : LivingUnit
    {
        public Colony() : base(speciesComplexity : 3, senescence : 16,
                               foodRequirement : 4, waterRequirement : 4,
                               gasRequirement: 2, inputGas : Enums.GasType.Oxygen, 
                               outputGas : Enums.GasType.CarbonDioxide, idealTemperature : 32,
                               infectionResistance: 5, decompositionValue : 6, baselineColor: System.Drawing.Color.LightSkyBlue)
        { }

        public override Unit Create()
        {
            return new Colony();
        }

        public override void Update(Unit[,] grid, int row, int col)
        {

        }

        public bool CheckMerge(Unit[,] grid, int row, int col)
        {
            throw new NotImplementedException();
        }

        public void Merge(Unit[,] grid, int row, int col)
        {

        }

        public void SplitUp(Unit[,] grid, int row, int col)
        {

        }
    }
}
