using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    abstract class Multicellular : LivingUnit
    {
        public Multicellular(int senescence, int foodRequirement, int waterRequirement, int gasRequirement, 
                             Enums.GasType inputGas, Enums.GasType outputGas, int idealTemperature, 
                             double infectionResistance, double decompositionValue, System.Drawing.Color baselineColor) 
                                    : base(4, senescence, foodRequirement, waterRequirement, gasRequirement, 
                                      inputGas, outputGas, idealTemperature, infectionResistance, decompositionValue, baselineColor)
        {

        }

        public abstract int DecreaseVictualRequirements(Unit[,] grid, int row, int col);

        public abstract int IncreaseVictualRequirements(Unit[,] grid, int row, int col);
    }
}
