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

        Random numberGenerator = new Random();

        private Image eventImage;
        private Image rainImage;
        private Image environmentImage;

        public Environment()
        {

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
            set { }
        }

        // get and set food availability 
        public double FoodAvailability
        {
            get { return this.foodAvailability; }
            set { }
        }

        // get and set oxyegen level 
        public int OxygenLevel
        {
            get { return this.oxygenLevel; }
            set { }
        }

        // get and set temperature
        public int Temperature
        {
            get { return this.temperature; }
            set { }
        }

        // get and set water availability
        public int WaterAvailabilty
        {
            get { return this.waterAvailability; }
            set { }
        }

        // return true if an event occurs in the environment
        public bool EventOccurs()
        {
            // to be changed
            return true;
        }

        abstract protected void EnvironmentalEvent();

        abstract protected void Rain();
    }
}

