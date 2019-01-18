/*
 * Nicole Beri
 * Januray 15, 2019
 * Base class for the environments (subclasses --> tundra, rainforest, greenhouse, desert)
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing; //document

namespace GameOfLife
{
    public abstract class Environment
    {
        protected int carbonDioxideLevel;
        protected int eventGenerationsLeft;
        protected bool eventOccurring;
        protected double foodAvailability;
        protected int oxygenLevel;
        protected int probabilityOfRain;
        protected int temperature;
        protected int waterAvailability;
        public const int PROBABILITY_OF_EVENT = 2;

        // (Rudy) default food and water values of each biome
        // read-only; can be initialized in the constructor but nowhere else
        public virtual double DefaultFood { get; }
        public virtual int DefaultWater { get; } 

        Random numberGenerator = new Random();

        private Image eventImage;
        private Image rainImage;
        private Image environmentImage;

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
        public int WaterAvailabilty
        {
            get { return this.waterAvailability; }
            set { this.waterAvailability = value; }
        }

        // return true if an event occurs in the environment
        public bool EventOccurs()
        {
            // to be changed
            return true;
        }

        abstract protected void EnvironmentalEvent();

        /// <summary>
        /// (Tiffanie) Enact raining in the environment
        /// </summary>
        protected void Rain()
        {
            // Increase water availab
            this.waterAvailability += 10 * waterAvailability;
        }
    }
}

