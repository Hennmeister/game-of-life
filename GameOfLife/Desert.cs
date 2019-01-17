using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Desert : Environment
    {
        public Desert()
        {
            // assign environmental property values for desert
            carbonDioxideLevel = 50;
            foodAvailability = 3000;
            oxygenLevel = 50;
            probabilityOfRain = 5;
            temperature = 45;
            waterAvailability = 15000;
        }

        protected override void EnvironmentalEvent()
        {

        }

        protected override void Rain()
        {

        }
    }
}
