using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing; //document

namespace GameOfLife
{
    abstract class Environment
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

        Image eventImage;
        Image rainImage;
        Image environmentImage;

        public Environment()
        {

        }

        public int CarbonDioxideLevel
        {
            get { return this.carbonDioxideLevel; }
        }

        public double FoodAvailability
        {
            get { return this.foodAvailability; }
            set { }
        }

        public int OxygenLevel
        {
            get { return this.oxygenLevel; }
            set { }
        }

        public int Temperature
        {
            get { return this.temperature; }
            set { }
        }

        public int WaterAvailabilty
        {
            get { return this.waterAvailability; }
            set { }
        }

        public bool EventOccurs()
        {
            // to be changed
            return true;
        }

        protected void EnvironmentalEvent()
        {
        }

        protected void Rain()
        {
        }

    }
}

