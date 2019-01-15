/*
 * Rudy Ariaz
 * January 15th, 2019
 * Wraps and encapsulates all information about the game state. 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class State
    {
        public int CurrentScore { get; set; }
        public int HighestConcurrentScore { get; set; }
        public string Username { get; set; }
        public int GenerationCounter { get; set; }
        private Environment gameEnvironment;

        public State()
        {
            GenerationCounter = 0;
        }

        public UpdateBlock(Unit unit, int row, int col)
        {

        }

        public 


    }
}
