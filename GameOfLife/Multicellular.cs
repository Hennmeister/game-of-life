using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    abstract class Multicellular : LivingUnit
    {
        public Multicellular(int senescence, int foodRequirement,
                          int waterRequirement, int gasRequirement, GasType inputGas,
                          GasType outputGas, int idealTemperature, double infectionResistance,
                          double decompositionValue) : base(4, senescence, foodRequirement,
                          waterRequirement, gasRequirement, inputGas,
                          outputGas, idealTemperature, infectionResistance, decompositionValue)
        {

        }

        protected abstract DecreaseVictualRequirements(Unit[,] grid, int row, int col);

        protected abstract IncreaseVictualRequirements(Unit[,] grid, int row, int col);

    }
}
