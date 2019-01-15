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
        public Virus() : base(0.1, System.Drawing.Color.SlateBlue) { }

        public override Unit Create()
        {
            return new Virus();
        }

        public override void Update(Unit[,] grid, int row, int col)
        {
            
        }

        private bool Infect(Unit[,] grid, int row, int col)
        {

        }
    }
}
