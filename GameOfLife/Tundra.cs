using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Tundra : Environment
    {
        public Tundra()
        {
            // assign environmental property values for tundra
            carbonDioxideLevel = 50;
            foodAvailability = 10000;
            oxygenLevel = 75;
            probabilityOfRain = 15;
            temperature = 25;
            waterAvailability = 25000;
        }

        protected override void EnvironmentalEvent()
        {

        }

        protected override void Rain()
        {

        }
    }
}
