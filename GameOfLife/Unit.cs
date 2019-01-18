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

        protected double DecompositionValue { get; }

        public Unit(double decompositionValue)
        {
            DecompositionValue = decompositionValue;
        }

        public abstract Unit Create();

        public abstract void Update(Unit[,] grid, int row, int col);
    }
}
