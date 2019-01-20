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
        private const int NUMBER_OF_PREV_STATES = 5;
        public int CurrentScore { get; set; }
        public int HighestConcurrentScore { get; set; }
        public string Username { get; set; }
        public int GenerationCounter { get; set; }
        public Unit[,] UnitGrid { get; set; }
        public Environment GameEnvironment { get; set; }
        private State[] previousStates = new State[NUMBER_OF_PREV_STATES];
        private static int latestID;
        public int CurrentID { get; }

        public State()
        {
            GenerationCounter = 0;
            CurrentID = ++latestID;
        }

        public void UpdateBlock(Unit newUnit, int row, int col)
        {
            UnitGrid[row, col] = newUnit;
        }

        public void AddStateToCache()
        {
            for (int i = 1; i < NUMBER_OF_PREV_STATES; i++)
            {
                previousStates[i] = previousStates[i - 1];
            }
            previousStates[0] = this;
        }

        public State LoadCachedState(int genNum)
        {
            for (int i = 0; i < NUMBER_OF_PREV_STATES; i++)
            {
                if (previousStates[i].GenerationCounter == i)
                {
                    return previousStates[i];
                }
            }
            return null;
        }

        public EnvironmentTypeEnum EnvironmentType
        {
            get
            {
                return GameEnvironment.EnvironmentType;
            }
        }

        public int CarbonDioxideLevel
        {
            set
            {
                GameEnvironment.CarbonDioxideLevel = value;
            }
            get
            {
                return GameEnvironment.CarbonDioxideLevel;
            }
        }

        public bool EnvironmentalEventOccurs
        {
            get
            {
                return GameEnvironment.EventOccurs();
            }
        }

        public int EventGenerationsLeft
        {
            get
            {
                return GameEnvironment.EventGenerationsLeft;
            }
        }
        public Image EnvironmentalImage
        {
            get
            {
                return GameEnvironment.EnvironmentImage;
            }
        }

        public Image EventImage
        {
            set
            {
                
            }
            get
            {
                return GameEnvironment.EventImage;
            }
        }

        public Image RainImage
        {
            set
            {

            }
            get
            {
                return GameEnvironment.RainImage;
            }
        }

        public double FoodAvailability
        {
            set
            {
                GameEnvironment.FoodAvailability = value;
            }
            get
            {
                return GameEnvironment.FoodAvailability;
            }
        }
        
        public double DefaultFood
        {
            get
            {
                return GameEnvironment.DefaultFood;
            }
        }

        public double DefaultWater
        {
            get
            {
                return GameEnvironment.DefaultWater;
            }
        }

        public double WaterAvailability
        {
            set
            {
                GameEnvironment.WaterAvailability = value;
            }
            get
            {
                return GameEnvironment.WaterAvailability;
            }
        }

        public int OxygenLevel
        {
            set
            {
                GameEnvironment.OxygenLevel = value;
            }
            get
            {
                return GameEnvironment.OxygenLevel;
            }
        }

        public int Temperature
        {
            set
            {
                GameEnvironment.Temperature = value;
            }
            get
            {
                return GameEnvironment.Temperature;
            }
        }

        public bool IsEnvironmentCreated()
        {
            return GameEnvironment != null;
        }
        
    }
}


