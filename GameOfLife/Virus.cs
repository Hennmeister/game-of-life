﻿// Tiffanie
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

        public Virus() : base(0.1)
        {

        }

        public override Unit Create()
        {
            return new Virus();
        }

        public override void Update(Unit[,] grid, int row, int col)
        {
            
        }

        private bool Infect(Unit[,] grid, int row, int col)
        {
            throw new NotImplementedException();
        }
    }
}
