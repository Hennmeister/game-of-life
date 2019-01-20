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
        public (int r, int c) Location { get; }
        
        protected double DecompositionValue { get; set; }

        public int SpeciesComplexity { get; }

        public Unit(double decompositionValue, int speciesComplexity, int row = -1, int col = -1)
        {
            DecompositionValue = decompositionValue;
            SpeciesComplexity = speciesComplexity;
        }
        

        
        public void Die(Unit[,] grid, Environment gameEnv)
        {
            grid[Location.r, Location.c] = null;
            gameEnv.IncreaseFood(DecompositionValue);
        }

        public abstract Unit Create(int row, int col);

        public abstract void Update(Unit[,] grid, Environment gameEnv);
    }
}
