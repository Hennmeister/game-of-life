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
        private const int NUMBER_OF_CACHED_STATES = 5;
        public int CurrentScore { get; set; }
        public int HighestConcurrentScore { get; set; }
        public string Username { get; set; }
        public int GenerationCounter { get; set; }
        public Unit[,] UnitGrid { get; set; }
        public Environment GameEnvironment { get; set; }
        private State[] cachedStates = new State[NUMBER_OF_CACHED_STATES];
        private static int latestID;
        private int currentID;

        public State()
        {
            GenerationCounter = 0;
            currentID = ++latestID;
        }

        public void UpdateBlock(Unit newUnit, int row, int col)
        {
            UnitGrid[row, col] = newUnit;
        }

        //Henning
        //Shifts the list of cached states and adds the current state to the front
        public void AddStateToCache()
        {
            for (int i = 4; i > 0; i--)
            {
                if (cachedStates[i] != null)
                {
                    cachedStates[i] = cachedStates[i - 1];
                }
            }
            cachedStates[0] = this;
        }

        //Henning
        //gets a cached state based off the generation number
        public State LoadCachedState(int genNum)
        {
            for (int i = 0; i < NUMBER_OF_CACHED_STATES; i++)
            {
                if (cachedStates[i] != null && cachedStates[i].GenerationCounter == genNum)
                {
                    return cachedStates[i];
                }
            }
            return null;
        }

        //Henning
        //Checks if the score has stayed the same in all cached states
        public bool isScoreStable(int score)
        {
            //prob refactor
            foreach(State s in cachedStates)
            {
                if(s == null || s.GenerationCounter != score)
                {
                    return false;
                }
            }
            return true;
         //    return new[] {cachedStates[0].GenerationCounter, cachedStates[1].GenerationCounter, cachedStates[2].GenerationCounter,
           //     cachedStates[3].GenerationCounter, cachedStates[4].GenerationCounter }.All(x => x == score);
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
