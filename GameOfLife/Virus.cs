// Tiffanie
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Virus : Unit
    {
        public static readonly System.Drawing.Color baselineColor = System.Drawing.Color.SlateBlue;

        public Virus(int row = -1, int col = -1) : base(0.1, row, col)
        {

        }

        public override Unit Create(int row, int col)
        {
            return new Virus(row, col);
        }

        public override void Update(Unit[,] grid, Environment gameEnv)
        {
            
        }

        private void Infect(Unit[,] grid)
        {
            foreach(var dir in GridHelper.directions)
            {
                int newRow = Location.r + dir.Item1;
                int newCol = Location.c + dir.Item2;
                if(!grid.InGridBounds(newRow, newCol))
                {
                    continue;
                }
                Unit neighbor = grid[newRow, newCol];
                // Check if there is a living unit in the cell
                // Infects a unit even if it is already infected
                if(neighbor is LivingUnit && neighbor != null)
                {
                    // Infect 
                    (neighbor as LivingUnit).BeInfected();
                    break;
                }
            }

        }
    }
}
