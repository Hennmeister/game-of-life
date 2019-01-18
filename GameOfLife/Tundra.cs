using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Tundra : Environment
    {
        public Tundra() : base(10000, 250000, 75, 25, 15, 15)
        {
        }

        protected override void EnvironmentalEvent()
        {

        }
    }
}
