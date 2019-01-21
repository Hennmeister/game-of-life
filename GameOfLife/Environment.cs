/*
 * Nicole Beri
 * January 15, 2019
 * Base class for the environments (subclasses --> tundra, rainforest, greenhouse, desert)
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Used for drawing graphics in the Environment
using System.Drawing; 

namespace GameOfLife
{
    public enum EnvironmentTypeEnum { Rainforest, Tundra, Greenhouse, Desert };

    [Serializable]
    public abstract class Environment
    {
        // **** ENVIRONMENTAL PARAMETERS ****/
        // Atmospheric composition -- used to determine evolution into animal or plant
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
        // visual indicator for the environment
        private Image environmentImage;
        // (Nicole) environment type 
        protected EnvironmentTypeEnum environmentType;

        // (Nicole) getter and setter for environment type
        public EnvironmentTypeEnum EnvironmentType
        {
            get { return environmentType; }
            set { environmentType = value; }
        }

        // **** EVENT INFORMATION ****
        // the chance of rain as a percent
        protected int probabilityOfRain;
        // the chance of an event occurring as a percent
        public const int PROBABILITY_OF_EVENT = 2;
        // state variable for if an event is occurring
        protected bool eventOccurring;
        // determines how many generations left for an occurring event
        public int EventGenerationsLeft { get; set; }
        // images for various events
        private Image eventImage;
        private Image rainImage;

        // generates random numbers to determine if probabalistic events occur
        Random numberGenerator = new Random();

        /// <summary>
        /// (Tiffanie) Create a new Environment with the given values unique to a chosen type of Environment
        /// </summary>
        /// <param name="defaultFood"> The default amount of food in this type of environment </param>
        /// <param name="defaultWater"> The default amount of water in this type of environment </param>
        /// <param name="oxygenLevel"> The oxygen level of this environment </param>
        /// <param name="carbonDioxideLevel"> The carbon dioxide level in this environment </param>
        /// <param name="temperature"> The temperature of this environment </param>
        /// <param name="probOfRain"> The probability of rain in this environment </param>
        public Environment(double defaultFood, int defaultWater,
                           int oxygenLevel, int carbonDioxideLevel,
                           int temperature, int probOfRain)
        {
            // **** INITIALIZE ENVIRONMENT PARAMETERS BASED ON TYPE OF ENVIRONMENT ****
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
            set { this.carbonDioxideLevel = value; }
        }

        // get and set food availability 
        public double FoodAvailability
        {
            get { return this.foodAvailability; }
            set { this.foodAvailability = value; }
        }

        // get and set oxyegen level 
        public int OxygenLevel
        {
            get { return this.oxygenLevel; }
            set { this.oxygenLevel = value; }
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
            set { this.waterAvailability = value; }
        }


        /// <summary>
        /// Decrease the amount of food in the Environment after being consumed by a Unit
        /// </summary>
        /// <param name="consumed"> The amount of food being consumed </param>
        public void DecreaseFood(double consumed)
        {
            FoodAvailability -= consumed;
        }

        /// <summary>
        /// Decrease the amount of water in the Environment after being consumed by a Unit
        /// </summary>
        /// <param name="consumed"> The amount of water being consumed </param>
        public void DecreaseWater(double consumed)
        {
            WaterAvailability -= consumed;
        }

        /// <summary>
        /// Check whether there is enough water for a certain amount to be consumed.
        /// </summary>
        /// <param name="consumed"> The amount to be consumed. </param>
        /// <returns> True if the amount consumed is less than or equal to the water availability,
        /// false otherwise. </returns>
        // TODO: delete if not used
        public bool EnoughWater(double consumed)
        {
            return WaterAvailability >= consumed;
        }


        /// <summary>
        /// Check whether there is enough food for a certain amount to be consumed.
        /// </summary>
        /// <param name="consumed"> The amount to be consumed. </param>
        /// <returns> True if the amount consumed is less than or equal to the food availability,
        /// false otherwise. </returns>
        // TODO: delete if not used
        public bool EnoughFood(double consumed)
        {
            return FoodAvailability >= consumed;
        }

        /// <summary>
        /// Tip the balance of atmospheric composition towards oxygen
        /// </summary>
        /// <param name="change"> The percent increase in oxygen levels </param>
        public void IncreaseOxygen(int change)
        {
            // TO BE DOCUMENTED
            OxygenLevel += change;
            CarbonDioxideLevel -= change;
        }

        /// <summary>
        /// Tip the balance of atmospheric composition towards carbon dioxide
        /// </summary>
        /// <param name="change"> The percent increase in carbon dioxide levels </param>
        public void IncreaseCarbonDioxide(int change)
        {
            // TO BE DOCUMENTED
            CarbonDioxideLevel += change;
            OxygenLevel -= change;
        }

        /// <summary>
        /// Increase the amount of food in the Environment
        /// </summary>
        /// <param name="increase"> The amount of food being returned to the environment </param>
        public void IncreaseFood(double increase)
        {
            FoodAvailability += increase;
        }



        //**** EVENT PROCESSING ****//

        // A unique environmental event that changes the parameters or organisms in the environment
        abstract protected void EnvironmentalEvent(Unit[,] grid);

        /// <summary>
        /// Determine if an event should occur in the environment
        /// </summary>
        /// <returns> True if a new event should start and false otherwise </returns>
        public bool EventOccurs()
        {
            // If an event is already occurring, do not try to start a new event
            if (eventOccurring)
            {
                return false;
            }
            // Otherwise, probabilistically evaluate whether an event occurs
            else
            {
                return ProbabilityHelper.EvaluateIndependentPredicate(PROBABILITY_OF_EVENT / 100.0);
            }
        }

        
        /// <summary>
        /// (Tiffanie) Enact raining in the environment
        /// </summary>
        protected void Rain()
        {
            // Increase water availability in the environment by 10% of the default amount 
            WaterAvailability += 10 * DefaultWater;
        }
    }
}

