using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Rainforest : Environment
    {
        public Rainforest()
        {
            // assign environmental property values for rainforest
            carbonDioxideLevel = 50;
            foodAvailability = 10000;
            oxygenLevel = 50;
            probabilityOfRain = 50;
            temperature = 30;
            waterAvailability = 50000;
        }

        protected override void EnvironmentalEvent()
        {

        }

        protected override void Rain()
        {
            
        }

    }
}
