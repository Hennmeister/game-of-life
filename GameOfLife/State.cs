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
using System.Drawing;

namespace GameOfLife
{
    class State
    {
        public int CurrentScore { get; set; }
        public int HighestConcurrentScore { get; set; }
        public string Username { get; set; }
        public int GenerationCounter { get; set; }
        public Unit[,] UnitGrid { get; set; }
        private Environment gameEnvironment;
        private List<State> previousStates;

        public State()
        {
            GenerationCounter = 0;
        }

        public void UpdateBlock(Unit newUnit, int row, int col)
        {
            UnitGrid[row, col] = newUnit;
        }

        public int CarbonDioxideLevel
        {
            set
            {
                gameEnvironment.
            }
            get
            {
                return gameEnvironment
            }
        }

        public bool EnvironmentalEventOccurs
        {
            set
            {

            }
            get
            {

            }
        }

        public Image EnvironmentalImage
        {
            set
            {

            }
            get
            {

            }
        }

        public Image EventImage
        {
            set
            {
                
            }
            get
            {

            }
        }

        public Image RainImage
        {
            set
            {

            }
            get
            {

            }
        }

        public double FoodAvailability
        {
            set
            {
                
            }
            get
            {

            }
        }

        public int GenerationNumber
        {
            set
            {

            }
            get
            {

            }
        }

        public int HighestConcurrentScore
        {
            set
            {
                
            }
            get
            {

            }
        }

        public int WaterAvailability
        {
            set
            {
                
            }
            get
            {

            }
        }

        public int OxygenLevel
        {
            set
            {

            }
            get
            {

            }
        }

        public int Temperature
        {
            set
            {
                
            }
            get
            {

            }
        }
    }
}
