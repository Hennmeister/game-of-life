/*
 * Henning Lindig
 * January 19, 2019
 * This class coordinates the user's actions with the internals of the program (state, environment, units)
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace GameOfLife
{
    public class GameManager
    {
        // Stores the data for the current simulation
        private State currentState;
        // The size of the grid of units
        const int UNIT_GRID_SIZE = 50;

        /// <summary>
        /// Creates and sets the environment of the current state
        /// </summary>
        /// <param name="envType">The type of the environment</param>
        public void CreateEnvironment(Enums.EnvironmentType envType)
        {
            //check if a state exists
            if (currentState != null)
            {
                //create a new environment using environment factory and assign it to the current states environment
                currentState.GameEnvironment = EnvironmentFactory.CreateEnvironment(envType);
            }
        }

        /// <summary>
        /// Creates the unit grid for the current state
        /// </summary>
        public void CreateGrid()
        {
            currentState.UnitGrid = new Unit[UNIT_GRID_SIZE, UNIT_GRID_SIZE];
        }

        /// <summary>
        /// Creates a new unit of a given type at the given location using unit factory
        /// </summary>
        /// <param name="row"> the row index of the unit's location </param>
        /// <param name="col"> the column index of the unit's location </param>
        /// <param name="UnitType"> the type of unit </param>
        public void CreateUnit(int row, int col, Enums.UnitType UnitType)
        {
            currentState.UnitGrid[row, col] = UnitFactory.CreateUnit(UnitType, row, col);
        }

        /// <summary>
        /// Creates the current state
        /// </summary>
        public void CreateState()
        {
            currentState = new State();
            CreateGrid();
        }

        /// <summary>
        /// Loads a state saved in the current states cached as the new current state
        /// </summary>
        /// <param name="genNum">The generation number of the state to load</param>
        public void LoadCachedState(int genNum)
        {
            //check if a cached state with a given generation number exists
            if (currentState.LoadCachedState(genNum) != null)
            {
                //load the cached state
                currentState = currentState.LoadCachedState(genNum);
                //make the cache of the new state an empty state array
                currentState.CachedStates = new State[5];
            }
        }

        /// <summary>
        /// Call all neccessary operations associated with progressing to the next generation
        /// </summary>
        /// <remarks> Tiffanie </remarks>
        public void NextGeneration()
        {
            // **** UPDATE UNITS **** 
            ApplyRuleset();
            UpdateAllUnits();
            // **** UPDATE ENVIRONMENT **** 
            // case 1: it is currently raining in the environment
            if (currentState.GameEnvironment.IsRaining)
            {
                // Process the next generation of rain
                currentState.GameEnvironment.Rain();
            }
            // case 2: the environment's unique event is currently happening
            else if (currentState.GameEnvironment.EnvEventOccurring)
            {
                // Process the next generation of the environmental event
                currentState.GameEnvironment.EnvironmentalEvent(currentState.UnitGrid);
            }
            // case 3: none of the two events are occurring, so see if an event should start
            else
            {
                // case 3.1: check if probability determines raining to start
                if (currentState.GameEnvironment.WillRain())
                {
                    // Process the first generation with rain
                    currentState.GameEnvironment.Rain();
                }
                // case 3.2: check if probability determines that the environmental event will start
                else if (currentState.GameEnvironment.EventStarts())
                {
                    // Process the first generation with the environmental event
                    currentState.GameEnvironment.EnvironmentalEvent(currentState.UnitGrid);
                }
            }
            // **** UPDATE LOGISTICS **** 
            CalculateScore();
            currentState.AddStateToCache();
            ++currentState.GenerationCounter;
        }

        /// <summary>
        /// Apply the ruleset to all blocks on the grid, either creating a new unit or killing one
        /// </summary>
        public void ApplyRuleset()
        {
            //loop through grid and apply the ruleset to each block
            Unit[,] grid = currentState.UnitGrid;
            // Grid representing the new state
            Unit[,] newGrid = new Unit[grid.GetLength(GridHelper.ROW), grid.GetLength(GridHelper.COLUMN)];
            //loop through the rows and columns of the grid, updating all blocks 
            for (int j = 0; j < grid.GetLength(GridHelper.ROW); j++)
            {
                for (int k = 0; k < grid.GetLength(GridHelper.COLUMN); k++)
                {
                    //get the new state of the block
                    newGrid[j, k] = Ruleset.NewBlockState(grid, j, k);
                }
            }
            // Update the state's grid
            currentState.UnitGrid = newGrid;
        }

        /// <summary>
        /// Calculate the score of the current grid, adding it to the state's cumulative score
        /// and checking if the game is over
        /// </summary>
        /// <returns> The score of the current grid in the simulation </returns>
        public int CalculateScore()
        {
            // get the current grid of units in the simulation
            Unit[,] grid = currentState.UnitGrid;
            //keeps track of the board's current score
            int gridScore = 0;
            //loop through the entire grid
            for (int j = 0; j < grid.GetLength(GridHelper.ROW); j++)
            {
                for (int k = 0; k < grid.GetLength(GridHelper.COLUMN); k++)
                {
                    //check if block is a virus or not a cell - if so, add the block's species complexity to the total
                    if (!(grid[j, k] is Virus) && grid[j, k] != null)
                    {
                        //add the product of the unit's species complexity and age, or just the species complexity if they are new, to the grid score
                        gridScore += Math.Max((grid[j, k] as LivingUnit).SpeciesComplexity * (grid[j, k] as LivingUnit).Age, (grid[j, k] as LivingUnit).SpeciesComplexity);
                    }
                }
            }
            // if the current score of the board is higher than the highest recorded concurrent score, it becomes the new highest concurrent score
            if (gridScore > HighestConcurrentScore)
            {
                HighestConcurrentScore = gridScore;
            }
            // add the score of the board to the tracker of the current board's score
            CurrentScore += gridScore;
            return gridScore;
        }

        /// <summary>
        /// Ends the current simulation and opens leaderboard
        /// </summary>
        /// <returns> True if the user's simulation meets the criteria to end the game and false otherwise </returns>
        public bool GameOver()
        {
            // Calculate the score given the current state of the grid
            int gridScore = CalculateScore();
            // A game over occurs if the grid score is 0 or the score has been stable for the next generations 
            bool gameOver = gridScore == 0 || currentState.isScoreStable(gridScore);
            // Check if a game over occurs
            if (gameOver)
            {
                // Save this user's highest score
                Datastore.AddScore(Username, HighestConcurrentScore);
                return true;
            }
            // Otherwise, the game continues 
            return false;   
        }
        /// <summary>
        /// Tell every unit to update, updating multiple parameters and checking if they merge
        /// </summary>
        public void UpdateAllUnits()
        {
            //the unit grid
            Unit[,] grid = currentState.UnitGrid;
            //loop through the entire grid
            for (int j = 0; j < grid.GetLength(GridHelper.ROW); j++)
            {
                for (int k = 0; k < grid.GetLength(GridHelper.COLUMN); k++)
                {
                    //check if there is a unit in the block being checked
                    if (grid[j, k] != null)
                    {
                        //if there is, tell that unit to update
                        grid[j, k].Update(grid, currentState.GameEnvironment);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the unit at a given location
        /// </summary>
        /// <param name="row">the row index</param>
        /// <param name="col">the column index</param>
        /// <returns>The unit at the given location</returns>
        public Unit GetUnit(int row, int col)
        {
            return currentState.UnitGrid[row, col];
        }

        /// <summary>
        /// Kills a unit at a given location
        /// </summary>
        /// <param name="row">the row index of the unit's location </param>
        /// <param name="col">the column index of the unit's location </param>
        public void KillUnit(int row, int col)
        {
            currentState.UnitGrid[row, col].Die(currentState.UnitGrid, currentState.GameEnvironment);
        }

        /// <summary>
        /// Loads the current state
        /// </summary>
        /// <param name="statePath"></param>
        public void LoadState(string statePath)
        {
            Datastore.LoadState(currentState, statePath);
        }

        /// <summary>
        /// Loads a state with the given name
        /// </summary>
        /// <param name="name"></param>
        public void SaveState(string name)
        {
            Datastore.SaveState(currentState, name);
        }

        /// <summary>
        /// Returns the cached states stored in the current state
        /// </summary>
        public State[] CachedStates
        {
            get { return currentState.CachedStates; }
        }

        /// <summary>
        /// Returns and sets the carbon dioxide level of the current state
        /// </summary>
        public int CarbonDioxideLevel
        {
            get { return currentState.CarbonDioxideLevel; }
            set { currentState.CarbonDioxideLevel = value;  }
        }

        /// <summary>
        /// Returns the enviornment image of the current state
        /// </summary>
        public Image EnvironmentImage
        {
            get { return currentState.EnvironmentalImage;  }
        }

        /// <summary>
        /// Returns the rain image of the current state
        /// </summary>
        public Image RainImage
        {
            get { return currentState.RainImage; }
        }

        /// <summary>
        /// Returns the event image of the current state
        /// </summary>
        public Image EventImage
        {
            get { return currentState.EventImage; }
        }

        /// <summary>
        /// Returns the type of the environment of the current state
        /// </summary>
        public Enums.EnvironmentType EnvironmentType
        {
            get { return currentState.EnvironmentType; }
        }

        /// <summary>
        /// Returns and sets the food availability of the current state
        /// </summary>
        public double FoodAvailability
        {
            get { return currentState.FoodAvailability; }
            set { currentState.FoodAvailability = value; }
        }

        /// <summary>
        /// Returns and sets the generation number of the current state
        /// </summary>
        public int GenerationCounter
        {
            get { return currentState.GenerationCounter; }
            set { currentState.GenerationCounter = value; }
        }

        /// <summary>
        /// Returns the size of the unit grid
        /// </summary>
        public int GridSize
        {
            get { return UNIT_GRID_SIZE; }
        }


        /// <summary>
        /// Returns and sets the highest recorded score at a given time from the current state
        /// </summary>
        public int HighestConcurrentScore
        {
            get { return currentState.HighestConcurrentScore; }
            set { currentState.HighestConcurrentScore = value; }
        }

        /// <summary>
        /// Returns and sets the water availability of the current state
        /// </summary>
        public double WaterAvailability
        {
            get { return currentState.WaterAvailability; }
            set { currentState.WaterAvailability = value; }
        }

        /// <summary>
        /// Returns and sets the oxygen level of the current state
        /// </summary>
        public int OxygenLevel
        {
            get { return currentState.OxygenLevel; }
            set { currentState.OxygenLevel = value; }
        }

        /// <summary>
        /// Returns and sets the score of the current state
        /// </summary>
        public long CurrentScore
        {
            get { return currentState.CurrentScore;  }
            set { currentState.CurrentScore = value; }
        }

        /// <summary>
        /// Returns and sets the temperature of the current state
        /// </summary>
        public int Temperature
        {
            get { return currentState.Temperature; }
            set { currentState.Temperature = value; }
        }

        /// <summary>
        /// Returns and sets the username associated with the current state
        /// </summary>
        public string Username
        {
            get { return currentState.Username; }
            set { currentState.Username = value; }
        }

        /// <summary>
        /// Returns whether it is raining from the current state's environment
        /// </summary>
        public bool IsRaining
        {
            get { return currentState.GameEnvironment.IsRaining; }
        }

        /// <summary>
        /// Returns whether an environmental event is occuring from the current state's environment
        /// </summary>
        public bool EnvEventOccurring
        {
            get { return currentState.GameEnvironment.EnvEventOccurring; }
        }

        /// <summary>
        /// Checks whether the environment exists
        /// </summary>
        /// <returns>
        /// True if it exists
        /// False if it does not exist
        /// </returns>
        public bool IsEnvironmentCreated()
        {
            // (Nicole) checking for object existence before accessing it
            bool bEnvironmentCreated = false;
            //check if the current state exists
            if (currentState != null)
            {
                //check if the environemnt exists 
                bEnvironmentCreated = currentState.IsEnvironmentCreated();
            }
            return bEnvironmentCreated;
        }
    }
}
