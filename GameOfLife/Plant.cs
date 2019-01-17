using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Plant : Multicellular
    {
        Random numberGenerator = new Random();

        public Plant() : base(senescence: 50,
                       foodRequirement: 5, waterRequirement: 25,
                       gasRequirement: 4, inputGas: Enums.GasType.CarbonDioxide,
                       outputGas: Enums.GasType.Oxygen, idealTemperature: 35,
                       infectionResistance: 7, decompositionValue: 10, baselineColor: System.Drawing.Color.YellowGreen)
        {

        }

        public override Unit Create()
        {
            return new Plant();
        }

        public override int DecreaseVictualRequirements(Unit[,] grid, int row, int col)
        {
            throw new NotImplementedException();
        }

        public override int IncreaseVictualRequirements(Unit[,] grid, int row, int col)
        {
            throw new NotImplementedException();
        }

        public override void Update(Unit[,] grid, int row, int col)
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
