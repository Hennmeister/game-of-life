/*
 * Tiffanie Truong
 * Nicole Beri - created class skeleton 
 * Rudy Ariaz - EnoughFood() and EnoughWater()
 * January 15, 2019
 * The base class for all environment types in the simulation (Rainforest, Tundra, Greenhouse, Desert).
 * It acts as a template for the information and events that all Environment types use.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Used for Images in the Environment
using System.Drawing;

namespace GameOfLife
{
    [Serializable]
    public abstract class Environment
    {
        // **** ENVIRONMENTAL PARAMETERS ****/
        // the percentage of the atmosphere that is carbon dioxide or oxygen
        // must sum to 100 and is used to determine evolution into animal or plant
        protected int carbonDioxideLevel;
        protected int oxygenLevel;

        /// <summary>
        /// Accesses and modifies the default amount of food initially available in the environment
        /// <remarks> (Rudy Ariaz) read-only -- can be initialized in the constructor but nowhere else </remarks>
        /// </summary>
        public virtual double DefaultFood { get; set; }

        /// <summary>
        /// Accesses and modifies the default amount of water initially available in the environment
        /// <remarks> (Rudy Ariaz) read-only -- can be initialized in the constructor but nowhere else </remarks>
        /// </summary>
        public virtual int DefaultWater { get; set; }

        // the amount of food and water in the environment during the simulation
        protected double foodAvailability;
        protected double waterAvailability;
        // the current temperature of the environment

        /// <summary>
        /// Accesses and modifies the temperature of the environment
        /// </summary>
        public int Temperature { get; set; }

        /// <summary>
        /// Accesses the image depicting the information (used as a background)
        /// </summary>
        public Image EnvironmentImage { get; }

        // (Nicole) environment type
        protected Enums.EnvironmentType environmentType;

        // (Nicole) getter and setter for environment type
        public Enums.EnvironmentType EnvironmentType
        {
            get { return environmentType; }
            set { environmentType = value; }
        }

        // **** EVENT INFORMATION ****
        // the chance of rain as a percent
        protected int probabilityOfRain;
        // the chance of an environmental event occurring as a percent
        public const int PROBABILITY_OF_ENV_EVENT = 10;
        /// <summary>
        /// Accesses and modifies the state variable tracking whether or not it is raining
        /// </summary>
        public bool IsRaining { get; set; }
        /// <summary>
        /// Accesses and modifies the state variable tracking whether an environmental event is occuring
        /// </summary>
        public bool EnvEventOccurring { get; set; }
        /// <summary>
        /// Accesses and modifies the counter determining the remaining duration of an occuring event
        /// </summary>
        public int EventGenerationsLeft { get; set; }
        /// <summary>
        /// Accesses and modifies the image depicting the environment's unique event
        /// </summary>
        public Image EventImage { get; set; }
        /// <summary>
        /// Accesses and modifies the image depicting rain
        /// </summary>
        public Image RainImage { get; set; }


        /// <summary>
        /// (Tiffanie) Create a new Environment with the given values unique to a chosen type of Environment
        /// </summary>
        /// <param name="defaultFood"> The default amount of food in this type of environment </param>
        /// <param name="defaultWater"> The default amount of water in this type of environment </param>
        /// <param name="oxygenLevel"> The percentage of the atmosphere that is oxygen </param>
        /// <param name="carbonDioxideLevel"> The percentage of the atmosphere that is carbon dioxide </param>
        /// <param name="temperature"> The temperature of this environment </param>
        /// <param name="probOfRain"> The probability of rain in this environment </param>
        /// <param name="envImage"> The background image for this environment </param>
        /// <param name="eventPic"> The image for the unique event of this environment </param>
        /// <param name="envType"> The subclass representing the class or type of the environment </param>
        public Environment(double defaultFood, int defaultWater,
                           int oxygenLevel, int carbonDioxideLevel,
                           int temperature, int probOfRain, 
                           Image envImage, Image eventPic,
                           Enums.EnvironmentType envType)
        {
            // **** INITIALIZE ENVIRONMENT PARAMETERS BASED ON TYPE OF ENVIRONMENT ****
            // Save the type of environment 
            environmentType = envType;
            // Save the default amount of food and water in this biome
            DefaultFood = defaultFood;
            DefaultWater = defaultWater;
            // Initialize the amount of food and water available in the environment to be the default values
            // These values can be modified by the user in the StartForm
            foodAvailability = DefaultFood;
            waterAvailability = DefaultWater;
            // Save the atmospheric composition 
            CarbonDioxideLevel = carbonDioxideLevel;
            OxygenLevel = oxygenLevel;
            // Save the environment's temperature
            Temperature = temperature;
            // Save probability of rain as a percent
            probabilityOfRain = probOfRain;

            // IMAGES
            // Save the background of the environment
            EnvironmentImage = envImage;
            // Save image for the unique environmental event
            EventImage = eventPic;
            // Save image for rain event
            RainImage = Properties.Resources.Rain;
        }

        /// <summary>
        /// Accesses and modifies the percentage of carbon dioxide in the atmosphere
        /// </summary>
        public int CarbonDioxideLevel
        {
            // Gets and returns the carbon dioxoide level of the environment
            get { return this.carbonDioxideLevel; }
            set
            {
                // Ensure that the % of CO2 in the environment is non-negative
                if (value < 0)
                {
                    this.carbonDioxideLevel = 0;
                }
                // Ensure that the % of CO2 in the environment does not exceed the max of 100%
                else if (value > 100)
                {
                    this.carbonDioxideLevel = 100;
                }
                // Save the valid percentage of carbon dioxide 
                else
                {
                    this.carbonDioxideLevel = value;
                }
            }
        }

        /// <summary>
        /// Accesses and modifies the percentage of oxygen in the atmosphere
        /// </summary>
        public int OxygenLevel
        {
            // Gets and returns oxygen level of the environment
            get { return this.oxygenLevel; }
            set
            {
                // Ensure that the % of oxygen in the environment is non-negative
                if (value < 0)
                {
                    this.oxygenLevel = 0;
                }
                // Ensure that the % of oxygen in the environment does not exceed the max of 100%
                else if (value > 100)
                {
                    this.oxygenLevel = 100;
                }
                // Save the valid percentage of oxygen 
                else
                {
                    this.oxygenLevel = value;
                }
            }
        }

        /// <summary>
        /// Accesses and modifies the amount of food in the environment
        /// </summary>
        public double FoodAvailability
        {
            // Gets and returns the amount of food in the environment
            get { return this.foodAvailability; }
            set {
                // Ensure that the amount of food in the environment is non-negative
                if (value < 0)
                {
                    this.foodAvailability = 0;
                }
                // Valid amount of food is passed in, so save the new amount of food 
                else
                {
                    this.foodAvailability = value;
                }
            }
        }

        /// <summary>
        /// Accesses and modifies the amount of water in the environment
        /// </summary>
        public double WaterAvailability
        {
            // Gets and returns the amount of water in the environment
            get { return this.waterAvailability; }
            set
            {
                // Ensure that the amount of water in the environment is non-negative
                if (value < 0)
                {
                    this.waterAvailability = 0;
                }
                // Valid amount of water is passed in, so save the new amount of water 
                else
                {
                    this.waterAvailability = value;
                }
            }
        }

        /// <summary>
        /// Decrease the amount of food in the Environment after being consumed by a Unit
        /// </summary>
        /// <param name="required"> The amount of food required by the Unit to survive </param>
        public bool DecreaseFood(double required)
        {
            // Check if there is enough food for the unit to consume
            if (EnoughFood(required))
            {
                // Consume as much food as required and indicate that the unit has enough to eat
                FoodAvailability -= required;
                return true;
            }
            // Otherwise, there is not enough food in the environment for the unit to eat
            else
            {
                // The unit consumes all remaining food, reducing food availability to 0
                FoodAvailability = 0;
                // Indicate that the unit cannot get enough food to sustain itself
                return false;
            }
        }

        /// <summary>
        /// Decrease the amount of water in the Environment after being consumed by a Unit
        /// </summary>
        /// <param name="consumed"> The amount of water required by the Unit to survive </param>
        public bool DecreaseWater(double required)
        {
            // Check if there is enough water for the unit to consume
            if (EnoughWater(required))
            {
                // Consume as much water as required and indicate that the unit has enough to drink
                WaterAvailability -= required;
                return true;
            }
            // Otherwise, there is not enough water in the environment for the unit to drink
            else
            {
                // The unit consumes all remaining water, reducing water availability to 0
                WaterAvailability = 0;
                // Indicate that the unit cannot get water food to sustain itself
                return false;
            }
        }

        /// <summary>
        /// Checks whether there is enough water for a living unit to consume given its water requirement
        /// </summary>
        /// <param name="consumed"> The amount to be consumed </param>
        /// <remarks> Author: Rudy Ariaz </remarks>
        /// <returns> True if the amount consumed is less than or equal to the water availability and false otherwise </returns>
        public bool EnoughWater(double consumed)
        {
            return consumed <= WaterAvailability;
        }


        /// <summary>
        /// Checks whether there is enough food for a living unit to consume given its food requirement
        /// </summary>
        /// <param name="consumed"> The amount to be consumed </param>
        /// <remarks> Author: Rudy Ariaz </remarks>
        /// <returns> True if the amount consumed is less than or equal to the food availability and false otherwise </returns>
        public bool EnoughFood(double consumed)
        {
            return consumed <= FoodAvailability;
        }

        /// <summary>
        /// Tip the balance of atmospheric composition towards oxygen
        /// </summary>
        /// <param name="change"> The percent increase in oxygen level </param>
        public void IncreaseOxygen(int change)
        {
            // Ensure that the atmosphere cannot consist of more than 100% oxygen
            if (OxygenLevel + change > 100)
            {
                OxygenLevel = 100;
                CarbonDioxideLevel = 0;
            }
            // Otherwise, a valid increase in oxygen is attempted
            else
            {
                // Increase the oxygen level by the given change in %
                OxygenLevel += change;
                // Apply change to carbon dioxide level in the opposite direction to ensure composition sums to 100%
                CarbonDioxideLevel -= change;
            }
        }

        /// <summary>
        /// Tip the balance of atmospheric composition towards carbon dioxide
        /// </summary>
        /// <param name="change"> The percent increase in carbon dioxide level </param>
        public void IncreaseCarbonDioxide(int change)
        {
            // Ensure that the atmosphere cannot consist of more than 100% carbon dioxide
            if (CarbonDioxideLevel + change > 100)
            {
                CarbonDioxideLevel = 100;
                OxygenLevel = 0;
            }
            // Otherwise, a valid increase in carbon dioxide is attempted
            else
            {
                // Increase the carbon dioxide level by the given change in %
                CarbonDioxideLevel += change;
                // Apply change to oxygen level in the opposite direction to ensure composition sums to 100%
                OxygenLevel -= change;
            }
        }

        /// <summary>
        /// Increase the amount of food in the Environment
        /// </summary>
        /// <param name="increase"> The amount of food being returned to the environment </param>
        public void IncreaseFood(double increase)
        {
            FoodAvailability += increase;
        }

        //************ EVENT PROCESSING ************//

        // A unique environmental event that changes the parameters or organisms in the environment
        abstract public void EnvironmentalEvent(Unit[,] grid);

        /// <summary>
        /// Determines if it starts raining in the environment
        /// </summary>
        /// <returns> True if it starts raining in the environment and false otherwise </returns>
        public bool WillRain()
        {
            // Probabilistically evaluate whether it will rain in order to initiate raining
            if (ProbabilityHelper.EvaluateIndependentPredicate(probabilityOfRain / 100.0))
            {
                // Indicate that it is raining for the next 5 generations
                IsRaining = true;
                EventGenerationsLeft = 5;
                return true;
            }
            // If the probability fails, it does not start raining
            return false;
        }

        /// <summary>
        /// Determines if the unique environmental event begins in the environment
        /// </summary>
        /// <returns> True if the environmental event begins and false otherwise </returns>
        public bool EventStarts()
        {
            // Probabilistically evaluate whether the event should occur in order to initiate it
            if (ProbabilityHelper.EvaluateIndependentPredicate(PROBABILITY_OF_ENV_EVENT / 100.0))
            {
                // Indicate that the environmental event will begin occurring for the next 5 generations
                EnvEventOccurring = true;
                EventGenerationsLeft = 5;
                return true;
            }
            // If the probability fails, the event does not start
            return false;
        }

        /// <summary>
        /// Enact raining in the environment to increase water availability
        /// </summary>
        public void Rain()
        {
            // Increase water availability in the environment by 2% of the default amount (10% over 5 generations)
            WaterAvailability += 0.02 * DefaultWater;
            // Reduce the amount of generations left for the event
            EventGenerationsLeft--;
            // Indicate that the rain has stopped once it should not continue for the next generation
            if (EventGenerationsLeft == 0)
            {
                IsRaining = false;
            }
        }
    }
}

