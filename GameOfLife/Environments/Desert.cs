/*
 * NAME
 * January 21, 2019
 * The Desert is one of the four possible environments for the user to choose from.
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
    class Desert : Environment
    {
        /// <summary>
        /// Create a Desert with its unique environmental parameters for the simulation's environment
        /// </summary>
        public Desert() : base(defaultFood: 3000, defaultWater: 1500,
                                oxygenLevel: 50, carbonDioxideLevel: 50,
                                temperature: 45, probOfRain: 5,
                                envImage: Properties.Resources.Desert, eventPic: Properties.Resources.Sandstorm,
                                envType: Enums.EnvironmentType.Desert)
        {
        }

        /// <summary>
        /// Enacts the Desert's unique environmental event of a sandstorm
        /// </summary>
        public override void EnvironmentalEvent(Unit[,] units)
        {
            // Wind decreases temperature by 5℃
            Temperature -= 5;
            // Lose access to 5% of available food
            FoodAvailability -= 0.10 * FoodAvailability;
            // Indicate that the event has stopped once it should not continue for the next generation
            if (--EventGenerationsLeft == 0)
            {
                EnvEventOccurring = false;
            }
        }
    }
}
