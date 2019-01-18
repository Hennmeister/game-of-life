using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Greenhouse : Environment
    {
        public Greenhouse() : base(3000, 50000, 25, 75, 35, 30)
        {
        }

        protected override void EnvironmentalEvent()
        {

        }
      
    }
}
