using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    abstract class Unit
    {
        protected System.Drawing.Color baseColor;
        protected double DecompositionValue { get; }

        public Unit(double decompositionValue)
        {
            DecompositionValue = decompositionValue;
        }

        public void Update(Unit[,] grid, int row, int col)
        {

        }

        public abstract Unit Create(); 
    }
}
