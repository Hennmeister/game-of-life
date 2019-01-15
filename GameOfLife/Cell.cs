// Tiffanie
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Cell : LivingUnit
    {
        /// <summary>
        /// create a new Cell unit
        /// </summary>
        public Cell() : base(speciesComplexity: 2, senescence: 16,
                               foodRequirement: 1, waterRequirement: 1,
                               gasRequirement: 1, inputGas: Enums.GasType.Oxygen,
                               outputGas: Enums.GasType.CarbonDioxide, idealTemperature: 30,
                               infectionResistance: 3, decompositionValue: 0.5, baselineColor: System.Drawing.Color.Turquoise)
        {

        }

        public override Unit Create()
        {
            return new Cell();
        }

        public override void Update(Unit[,] grid, int row, int col)
        {
            Colony test = new Colony();
        }

        public bool CheckMerge(Unit[,] grid, int row, int col)
        {

        }

        public void Merge(Unit[,] grid, int row, int col)
        {

        }
    }
}
