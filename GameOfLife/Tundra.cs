using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Tundra : Environment
    {

        /// <summary>
        /// Create a Tundra with its unique environmental parameters for the simulation's environment
        /// </summary>
        public Tundra() : base(10000, 250000, 75, 25, 15, 15)
        {
            // (Nicole) assign the specific environment type
            environmentType = EnvironmentTypeEnum.Tundra;
        }

        /// <summary>
        /// Enacts the Tundra's unique environmental event of a snowstorm
        /// </summary>
        protected override void EnvironmentalEvent(Unit[,] units)
        {
            // Snow decreases temperature by 12℃
            Temperature -= 12;
            // Lose access to 10% of the available water
            WaterAvailability -= (0.10 * WaterAvailability);
        }
    }
}
