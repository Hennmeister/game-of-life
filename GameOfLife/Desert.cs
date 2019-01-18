using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Desert : Environment
    {
        /// <summary>
        /// Create a Desert with its unique environmental parameters for the simulation's environment
        /// </summary>
        public Desert() : base(3000, 1500, 50, 50, 45, 5)
        {

        }

        /// <summary>
        /// Enacts the Desert's unique environmental event of a sandstorm
        /// </summary>
        protected override void EnvironmentalEvent(Unit[,] units)
        {
            // Wind decreases temperature by 5℃
            Temperature -= 5;
            // Lose access to 5% of available food
            FoodAvailability -= 0.10 * FoodAvailability;
        }
    }
}
