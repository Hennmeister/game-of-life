/*
 * NAME
 * January 21, 2019
 * The Tundra is one of the four possible environments for the user to choose from.
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
    class Tundra : Environment
    {

        /// <summary>
        /// Create a Tundra with its unique environmental parameters for the simulation's environment
        /// </summary>
        public Tundra() : base(defaultFood: 10000, defaultWater: 25000, 
                                oxygenLevel: 75, carbonDioxideLevel: 25, 
                                temperature: 15, probOfRain: 15, 
                                envImage: Properties.Resources.Tundra, eventPic: Properties.Resources.Snowstorm,
                                envType: Enums.EnvironmentType.Tundra)
        {
        }

        /// <summary>
        /// Enacts the Tundra's unique environmental event of a snowstorm
        /// </summary>
        public override void EnvironmentalEvent(Unit[,] units)
        {
            // Snow decreases temperature by 10℃ over 5 generations
            Temperature -= 2;
            // Lose access to 10% of the available water -- answer is rounded to 1 decimal
            WaterAvailability -= Math.Round(0.10 * WaterAvailability, 1);
            // Indicate that the event has stopped once it should not continue for the next generation
            if (--EventGenerationsLeft == 0)
            {
                EnvEventOccurring = false;
            }
        }
    }
}
