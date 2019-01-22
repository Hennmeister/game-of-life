/*
 * Henning Lindig
 * January 15th, 2019
 * Wraps and encapsulates all information about the game state. 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
//Allows for serialziation of objects for deep cloning
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
//Used for queue
using System.Collections;

namespace GameOfLife
{
    [Serializable]
    public class State
    {
        //Keeps track of the number of cached states
        public const int NUMBER_OF_CACHED_STATES = 5;
        //Keeps track of the score
        public long CurrentScore { get; set; }
        //Keeps track of the highest concurrent score of the simulation
        public int HighestConcurrentScore { get; set; }
        //Stores the user's name
        public string Username { get; set; }
        //Keeps track of the generation number
        public int GenerationCounter { get; set; }
        //Stores the unit grid associated with the state
        public Unit[,] UnitGrid { get; set; }
        //Stores the environment associated with the state
        public Environment GameEnvironment { get; set; }
        //Stores the scores of the last 5 versions of the grid
        public Queue<int> gridScores { get; set; } = new Queue<int>();
        //Annotation indicates to not serialize this property
        //Stores deep copies of the last states
        [NonSerialized()]
        private State[] cachedStates = new State[NUMBER_OF_CACHED_STATES];

        /// <summary>
        /// Instantiate the state object
        /// </summary>
        /// <remarks></remarks>
        public State()
        {
        }

        /// <summary>
        /// Shifts the list of cached states and adds the current state to the front
        /// </summary>
        public void AddStateToCache()
        {
            //loop through all the cached states from the back
            for (int i = NUMBER_OF_CACHED_STATES -1; i > 0; i--)
            {
                //check if the state one index to the left exists
                if (cachedStates[i -1] != null)
                {
                    //if so, change the state of the current index to the state one to the left
                    cachedStates[i] = DeepCloneState(cachedStates[i - 1]);
                }
            }
            //make the first cached state a copy of the current state
            cachedStates[0] = DeepCloneState(this);
        }

        /// <summary>
        /// creates a deep copy of the state
        /// </summary>
        /// <param name="state">The state object to deep clone</param>
        /// <returns>A deep clone of the inputted state</returns>
        public static State DeepCloneState<State>(State state)
        {
            //create a stream that reads data from memory
            using (var ms = new MemoryStream())
            {
                //Used to serialize the object in binary format
                var formatter = new BinaryFormatter();
                //Serialize the state to the memory stream
                formatter.Serialize(ms, state);
                //resets the streams index to 0
                ms.Position = 0;
                return (State) formatter.Deserialize(ms);
            }
        }

        /// <summary>
        /// Loads a cached state associated with the given generation number
        /// </summary>
        /// <param name="genNum">The generation number of the cached state to laod</param>
        /// <returns>
        /// The cached state if it finds a cached state with the given generation number
        /// Null if no cached state with the given gen number exists</returns>
        public State LoadCachedState(int genNum)
        {
            //loop through all cached states
            for (int i = 0; i < NUMBER_OF_CACHED_STATES; i++)
            {
                //check that the state exists and if its generation number matches the inputted generation number
                if (cachedStates[i] != null && cachedStates[i].GenerationCounter == genNum)
                {
                    return cachedStates[i];
                }
            }
            return null;
        }

        /// <summary>
        /// Checks if the score has stayed the same in the last 5 generations
        /// </summary>
        /// <param name="score">The score of the current grid</param>
        /// <returns>
        /// True of the scores of the past 5 generations are the same
        /// False if the scores of the past 5 generations are not the same</returns>
        public bool isScoreStable(int score)
        {
            //check if there are 5 stored past scores
            if (gridScores.Count == 5)
            {
                //if there are, remove the oldest one
                gridScores.Dequeue();
            }
            //add the most recent score to the back of saved grid scores
            gridScores.Enqueue(score);
            //return false if there are not 5 stored past scores
            if (gridScores.Count != 5) return false;
            //otherwise, check if all the scores are the same and return the result
            return (gridScores.ToArray().All(x => x == gridScores.Peek()));
        }

        /// <summary>
        /// Get and set the cached states
        /// </summary>
        public State[] CachedStates
        {
            get
            {
                //If the cached states field exists, return it
                if (cachedStates != null)
                {
                    return cachedStates;
                }
                //otherwise return a new, empty array
                else return new State[NUMBER_OF_CACHED_STATES];
            }
            set
            {
                cachedStates = value;
            }
        }

        /// <summary>
        /// Indicate whether the state has an environment object
        /// </summary>
        /// <returns>
        /// True if the state has an environment object
        /// False if the state does not have an environment object
        /// </returns>
        public bool IsEnvironmentCreated()
        {
            return GameEnvironment != null;
        }

        /// <summary>
        /// Get and set the type of environment associated with the state
        /// </summary>
        public Enums.EnvironmentType EnvironmentType
        {
            get
            {
                return GameEnvironment.EnvironmentType;
            }
            set
            {
                GameEnvironment.EnvironmentType = value;
            }
        }

        /// <summary>
        /// Get and set the carbon dioxide level in the environment of the state
        /// </summary>
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

        /// <summary>
        /// Get and set the number of generations left in the current event in the environment of the state
        /// </summary>
        public int EventGenerationsLeft
        {
            get
            {
                return GameEnvironment.EventGenerationsLeft;
            }
            set
            {
                GameEnvironment.EventGenerationsLeft = value;
            }
        }

        /// <summary>
        /// Get the image of the environment of the state
        /// </summary>
        public Image EnvironmentalImage
        {
            get
            {
                return GameEnvironment.EnvironmentImage;
            }
        }

        /// <summary>
        /// Get the image of the event in the environment of the state
        /// </summary>
        public Image EventImage
        {
            get
            {
                return GameEnvironment.EventImage;
            }
        }

        /// <summary>
        /// Get the rain in the environment of the state
        /// </summary>
        public Image RainImage
        {
            get
            {
                return GameEnvironment.RainImage;
            }
        }

        /// <summary>
        /// Get and set the food availability in the environment of the state
        /// </summary>
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

        /// <summary>
        /// Get and set the default amount of food in the environment of the state
        /// </summary>
        public double DefaultFood
        {
            get
            {
                return GameEnvironment.DefaultFood;
            }
            set
            {
                GameEnvironment.DefaultFood = value;
            }
        }

        /// <summary>
        /// Get and set the default amount of water in the environment of the state
        /// </summary>
        public int DefaultWater
        {
            get
            {
                return GameEnvironment.DefaultWater;
            }
            set
            {
                GameEnvironment.DefaultWater = value;
            }
        }

        /// <summary>
        /// Get and set the amount of water available in the environment of the state
        /// </summary>
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

        /// <summary>
        /// Get and set the amount of oxygen in the environment of the state
        /// </summary>
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

        /// <summary>
        /// Get and set the temperature in the environment of the state
        /// </summary>
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
    }
}


