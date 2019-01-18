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
        public (int row, int col) Location { get; }
        
        protected double DecompositionValue { get; set; }

        public Unit(double decompositionValue, int row, int col)
        {
            DecompositionValue = decompositionValue;
            Location = (row, col);
        }

        
        public void Die(Unit[,] grid, Environment gameEnv, int row, int col)
        {
            grid[row, col] = null;
            gameEnv.IncreaseFood(DecompositionValue);
        }

        public abstract Unit Create();

        public abstract void Update(Unit[,] grid, Environment gameEnv, int row, int col);
    }
}
