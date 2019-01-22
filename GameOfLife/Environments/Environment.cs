/*
 * Tiffanie Truong
 * January 15, 2019
 * The base class for all environment types in the simulation (Rainforest, Tundra, Greenhouse, Desert)
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
        // (Rudy) the default amount of food and water initially available in the environment
        // read-only -- can be initialized in the constructor but nowhere else
        public virtual double DefaultFood { get; set; }
        public virtual int DefaultWater { get; set; }
        // the amount of food and water in the environment during the simulation
        protected double foodAvailability;
        protected double waterAvailability;
        // the current temperature of the environment
        protected int temperature;
        // the background image visually depicting the environment
        private Image environmentImage;
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
        // state variables tracking what event is occuring
        public bool IsRaining { get; set; }
        public bool EnvEventOccurring { get; set; }
        // a counter to determine how many generations are left for an occurring event
        public int EventGenerationsLeft { get; set; }
        // images for various events
        private Image eventImage;
        private Image rainImage;

        /// <summary>
        /// (Tiffanie) Create a new Environment with the given values unique to a chosen type of Environment
        /// </summary>
        /// <param name="defaultFood"> The default amount of food in this type of environment </param>
        /// <param name="defaultWater"> The default amount of water in this type of environment </param>
        /// <param name="oxygenLevel"> The oxygen level of this environment </param>
        /// <param name="carbonDioxideLevel"> The carbon dioxide level in this environment </param>
        /// <param name="temperature"> The temperature of this environment </param>
        /// <param name="probOfRain"> The probability of rain in this environment </param>
        /// /// <param name="envImage"> The background image for this environment </param>
        /// <param name="eventPic"> The image for the unique event of this environment </param>
        public Environment(double defaultFood, int defaultWater,
                           int oxygenLevel, int carbonDioxideLevel,
                           int temperature, int probOfRain, 
                           Image envImage, Image eventPic,
                           Enums.EnvironmentType envType)
        {
            // **** INITIALIZE ENVIRONMENT PARAMETERS BASED ON TYPE OF ENVIRONMENT ****
            // The type of environment (biome)
            environmentType = envType;
            // The default/base amount of food and water in this biome
            DefaultFood = defaultFood;
            DefaultWater = defaultWater;
            // Amount of food and water initially available for the simulation (this can be modified by the user)
            foodAvailability = DefaultFood;
            waterAvailability = DefaultWater;
            // Atmospheric composition
            CarbonDioxideLevel = carbonDioxideLevel;
            OxygenLevel = oxygenLevel;
            // Temperature
            Temperature = temperature;
            // Probability of rain as a percent
            probabilityOfRain = probOfRain;

            // IMAGES
            // Background of the environment
            environmentImage = envImage;
            // Image for the unique environmental event
            eventImage = eventPic;
            // Image for rain event
            rainImage = Properties.Resources.Rain;
        }
        
        // getter for event images
        public Image EventImage
        {
            get { return this.eventImage; }
        }

        // getter for rain images
        public Image RainImage
        {
            get { return this.rainImage; }
        }

        // getter for environment images
        public Image EnvironmentImage
        {
            get { return this.environmentImage; }
        }

        // getter for carbon dioxide level
        public int CarbonDioxideLevel
        {
            get { return this.carbonDioxideLevel; }
            set
            {
                if (value < 0)
                {
                    this.carbonDioxideLevel = 0;
                }
                else
                {
                    this.carbonDioxideLevel = value;
                }
            }
        }

        // get and set food availability 
        public double FoodAvailability
        {
            get { return this.foodAvailability; }
            set {
                if (value < 0) {
                    this.foodAvailability = 0;
                }
                else
                {
                    this.foodAvailability = value;
                }
            }
        }

        // get and set oxygen level 
        public int OxygenLevel
        {
            get { return this.oxygenLevel; }
            set
            {
                if (value < 0)
                {
                    this.oxygenLevel = 0;
                }
                else
                {
                    this.oxygenLevel = value;
                }
            }
        }

        // get and set temperature
        public int Temperature
        {
            get { return this.temperature; }
            set { this.temperature = value; }
        }

        // get and set water availability
        public double WaterAvailability
        {
            get { return this.waterAvailability; }
            set
            {
                if (value < 0)
                {
                    this.waterAvailability = 0;
                }
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
            // Check if there is  enough food for the unit to consume
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
        /// Check whether there is enough water for a certain amount to be consumed
        /// </summary>
        /// <param name="consumed"> The amount to be consumed. </param>
        /// <returns> True if the amount consumed is less than or equal to the water availability,
        /// false otherwise. </returns>
        public bool EnoughWater(double consumed)
        {
            return consumed <= WaterAvailability;
        }


        /// <summary>
        /// Check whether there is enough food for a certain amount to be consumed.
        /// </summary>
        /// <param name="consumed"> The amount to be consumed. </param>
        /// <returns> True if the amount consumed is less than or equal to the food availability,
        /// false otherwise. </returns>
        public bool EnoughFood(double consumed)
        {
            return consumed <= FoodAvailability;
        }

        /// <summary>
        /// Tip the balance of atmospheric composition towards oxygen
        /// </summary>
        /// <param name="change"> The percent increase in oxygen levels </param>
        public void IncreaseOxygen(int change)
        {
            // Ensure that the atmosphere cannot consist of more than 100% oxygen
            if (OxygenLevel + change > 100)
            {
                OxygenLevel = 100;
                CarbonDioxideLevel = 0;
            }
            else
            {
                // Increase the oxygen level by the given change in %
                OxygenLevel += change;
                // Apply the corresponding change to carbon dioxide levels
                CarbonDioxideLevel -= change;
            }
        }

        /// <summary>
        /// Tip the balance of atmospheric composition towards carbon dioxide
        /// </summary>
        /// <param name="change"> The percent increase in carbon dioxide levels </param>
        public void IncreaseCarbonDioxide(int change)
        {
            // Ensure that the atmosphere cannot consist of more than 100% carbon dioxide
            if (CarbonDioxideLevel + change > 100)
            {
                CarbonDioxideLevel = 100;
                OxygenLevel = 0;
            }
            else
            {
                // Increase the carbon dioxide level by the given change in %
                CarbonDioxideLevel += change;
                // Apply the corresponding change to oxygen levels
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
            // Otherwise, it does not start raining so return false
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
                // Indicate that the environmental event will occur for the next generation
                EnvEventOccurring = true;
                EventGenerationsLeft = 5;
                return true;
            }
            // Otherwise, the event does not start
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

