using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    abstract class Multicellular : LivingUnit
    {  
        protected int BaselineFoodRequirement { get; }
        protected int BaselineWaterRequirement { get; }
        private const int EXTENDED_NEIGHBORHOOD_SIZE = 5;

        public Multicellular(int senescence, int foodRequirement, int waterRequirement, int gasRequirement, 
                             Enums.GasType inputGas, Enums.GasType outputGas, int idealTemperature, 
                             double infectionResistance, double decompositionValue, int row = -1, int col = -1) 
                                    : base(4, senescence, foodRequirement, waterRequirement, gasRequirement, 
                                      inputGas, outputGas, idealTemperature, infectionResistance, decompositionValue, row, col)
        {
            BaselineFoodRequirement = foodRequirement;
            BaselineWaterRequirement = waterRequirement;
        }

        /// <summary>
        /// Updates the victu
        /// </summary>
        /// <param name="grid"></param>
        protected void UpdateVictualRequirements(Unit[,] grid, )
        {

        }


        /// <summary>
        /// Gets the number of neighbors of the same type as this Multicellular
        /// in a 5x5 square centered on the organism.
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        protected int NumberOfSameSpeciesNeighbors(Unit[,] grid)
        {
            for(int i = )
        }
    }
}
