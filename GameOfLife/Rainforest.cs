/*
 * Tiffanie Truong
 * December 17, 2018
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
    class Rainforest : Environment
    {
        /// <summary>
        /// Create a Rainforest for the simulation's environment
        /// </summary>
        public Rainforest()
        {
            // Assign unique values for the environmental properties of Rainforest
            // Atmospheric composition
            carbonDioxideLevel = 50;
            oxygenLevel = 50;
            // Amount of food and water in the environment
            foodAvailability = 10000;
            waterAvailability = 50000;
            // Temperature
            temperature = 30;
            // Probability of rain as a percent
            probabilityOfRain = 50;
        }

        /// <summary>
        /// Enacts the Rainforest's unique environmental event of deforestation
        /// </summary>
        protected override void EnvironmentalEvent()
        {
            // Reduce food availability by 10%
            this.foodAvailability -= 0.10 * foodAvailability;
            // Reduce oxygen level in the atmosphere by 5% 
            this.oxygenLevel -= 5;
            // Increase carbon dioxide level in the atmosphere by 5%
            this.carbonDioxideLevel += 5;
        }
    }
}
