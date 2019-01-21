/*
 * Tiffanie Truong
 * January 17, 2018
 * Stores information for the Rainforest biome that the User
 * can choose as an environment for the simulation.
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
        public Rainforest() : base(10000, 50000, 50, 50, 30, 50, Properties.Resources.Rainforest, Properties.Resources.Deforestation)
        {
            // (Nicole) assign the specific environment type
            environmentType = EnvironmentTypeEnum.Rainforest;
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
            // Indicate that the event has stopped once it should not continue for the next generation
            if (--EventGenerationsLeft == 0)
            {
                EnvEventOccurring = false;
            }
        }
    }
}
