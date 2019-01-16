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
    public class State
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

        public void SetGameEnvironment(Environment gameEnv)
        {
            gameEnvironment = gameEnv; 
        }
        

        public int CarbonDioxideLevel
        {
            set
            {
                gameEnvironment.CarbonDioxideLevel = value;
            }
            get
            {
                return gameEnvironment.CarbonDioxideLevel;
            }
        }

        public bool EnvironmentalEventOccurs
        {
            get
            {
                return gameEnvironment.EventOccurs();
            }
        }

        public Image EnvironmentalImage
        {
            get
            {
                return gameEnvironment.environment
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
                gameEnvironment.FoodAvailability = value;
            }
            get
            {
                return gameEnvironment.FoodAvailability;
            }
        }
        

        public int WaterAvailability
        {
            set
            {
                gameEnvironment.WaterAvailabilty = value;
            }
            get
            {
                return gameEnvironment.WaterAvailabilty;
            }
        }

        public int OxygenLevel
        {
            set
            {
                gameEnvironment.OxygenLevel = value;
            }
            get
            {
                return gameEnvironment.OxygenLevel;
            }
        }

        public int Temperature
        {
            set
            {
                gameEnvironment.Temperature = value;
            }
            get
            {
                return gameEnvironment.Temperature;
            }
        }
    }
}
