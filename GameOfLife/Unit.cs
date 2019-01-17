// Tiffanie
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public abstract class Unit
    {
        // Specifies the dimension used for GetLength()
        public const int ROW = 0;
        public const int COLUMN = 1;

        static protected System.Drawing.Color baselineColor;
        protected double DecompositionValue { get; }

        public Unit(double decompositionValue, System.Drawing.Color baselineColor)
        {
            DecompositionValue = decompositionValue;
        }

        public System.Drawing.Color BaselineColor
        {
            get { return baselineColor; }
        }
        public abstract Unit Create();

        public abstract void Update(Unit[,] grid, int row, int col);
    }
}
