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
        public Tundra() : base(10000, 25000, 75, 25, 15, 15, Properties.Resources.Tundra, Properties.Resources.Snowstorm)
        {
            // (Nicole) assign the specific environment type
            environmentType = EnvironmentTypeEnum.Tundra;
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
