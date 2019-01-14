using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    abstract class Unit
    {
        public double DecompositionValue { get; }

        public Unit(double decompositionValue)
        {
            DecompositionValue = decompositionValue;
        }
    }
}
