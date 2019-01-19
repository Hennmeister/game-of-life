using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Plant : Multicellular
    {
        public static readonly System.Drawing.Color baselineColor = System.Drawing.Color.YellowGreen;
        Random numberGenerator = new Random();

        public Plant(int row = -1, int col = -1) : base(senescence: 50,
                       foodRequirement: 5, waterRequirement: 25,
                       gasRequirement: 4, inputGas: Enums.GasType.CarbonDioxide,
                       outputGas: Enums.GasType.Oxygen, idealTemperature: 35,
                       infectionResistance: 7, decompositionValue: 10, row: row, col: col)
        {

        }

        public override Unit Create(int row, int col)
        {
            return new Plant(row, col);
        }

        public override int DecreaseVictualRequirements(Unit[,] grid)
        {
            throw new NotImplementedException();
        }

        public override int IncreaseVictualRequirements(Unit[,] grid)
        {
            throw new NotImplementedException();
        }

        public override void Update(Unit[,] grid, Environment gameEnv)
        {

        }

        public bool IsToxic()
        {
            throw new NotImplementedException();

        }

        public override void Respire(int inputGasLevel, int outputGasLevel)
        {
            // base.Respire(inputGasLevel, outputGasLevel);
        }

        public int Photosynthesize()
        {
            throw new NotImplementedException();
        }
    }
}
