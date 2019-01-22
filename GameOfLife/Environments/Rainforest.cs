/*
 * Tiffanie Truong
 * January 17, 2018
 * The Rainforest is one of the four possible environments for the user to choose from.
 * It has a unique range of possible starting parameters, probability of rain, and environmental event.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    [Serializable]
    class Rainforest : Environment
    {
        /// <summary>
        /// Create a Rainforest with its unique environmental parameters for the simulation's environment
        /// </summary>
        public Rainforest() : base(defaultFood: 10000, defaultWater: 50000, 
                                    oxygenLevel: 50, carbonDioxideLevel: 50, 
                                    temperature: 30, probOfRain: 50, 
                                    envImage: Properties.Resources.Rainforest, eventPic: Properties.Resources.Deforestation,
                                    envType: Enums.EnvironmentType.Rainforest)

        {
        }

        /// <summary>
        /// Enacts the Rainforest's unique environmental event of deforestation
        /// </summary>
        public override void EnvironmentalEvent(Unit[,] units)
        {
            // Oxygen level decreases by 5% and carbon dioxide level increases by 5% as trees are removed
            OxygenLevel -= 5;
            CarbonDioxideLevel = 100 - OxygenLevel;
            // Lose access to 10% of the available food -- the result is rounded to 1 decimal place
            FoodAvailability -= Math.Round(0.10 * FoodAvailability, 1);
            // Indicate that the event has stopped once the number of remaining generations is 0
            if (--EventGenerationsLeft == 0)
            {
                EnvEventOccurring = false;
            }
        }
    }
}
