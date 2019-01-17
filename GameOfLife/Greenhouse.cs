using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Greenhouse : Environment
    {
        public Greenhouse()
        {
            // assign environmental property values for greenhouse
            carbonDioxideLevel = 75;
            foodAvailability = 3000;
            oxygenLevel = 25;
            probabilityOfRain = 30;
            temperature = 35;
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
