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
        public (int r, int c) Location { get; }
        
        protected double DecompositionValue { get; set; }

        public Unit(double decompositionValue)
        {
            DecompositionValue = decompositionValue;
        }

        public Unit(double decompositionValue, int row = -1, int col = -1) : this(decompositionValue)
        {
            Location = (row, col);
        }

        
        public void Die(Unit[,] grid, Environment gameEnv)
        {
            grid[Location.r, Location.c] = null;
            // TODO: uncomment when IncreaseFood is fixed
            // gameEnv.IncreaseFood(DecompositionValue);
        }

        public abstract Unit Create(int row, int col);

        public abstract void Update(Unit[,] grid, Environment gameEnv);
    }
}
