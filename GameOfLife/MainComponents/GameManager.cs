/*
 * Henning Lindig
 * 
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
        //Stores the data for the current simulation
        private State currentState;
        //The size of the grid of units
        const int UNIT_GRID_SIZE = 50;

        //Constructor, creates the current state
        public GameManager()
        {
            CreateState();
        }

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
        /// Creates the unit grid
        /// </summary>
        /// <returns>The unit grid</returns>
        public Unit[,] CreateGrid()
        {
            return new Unit[UNIT_GRID_SIZE, UNIT_GRID_SIZE];
        }

        /// <summary>
        /// Creates a new unit of a given type at the given location using unit factory
        /// </summary>
        /// <param name="row">the row index</param>
        /// <param name="col">the column index</param>
        /// <param name="UnitType">The type of unit</param>
        public void CreateUnit(int row, int col, Enums.UnitType UnitType)
        {
            currentState.UnitGrid[row, col] = UnitFactory.CreateUnit(UnitType, row, col);
        }

        /// <summary>
        /// Creates the current state and assigns a new grid to it 
        /// </summary>
        public void CreateState()
        {
            currentState = new State();
            currentState.UnitGrid = CreateGrid();
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
            //CalculateScore();
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
        public int CalculateScore()
        {
            //the unit grid
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
            //if the current score of the board is higher than the highest recorded concurrent score, it becomes the new highest concurrent score
            if (gridScore > HighestConcurrentScore) HighestConcurrentScore = gridScore;
            //check if there are any units left on board or if the score has not changed in 5 generations
            //if (gridScore == 0 || currentState.isScoreStable(gridScore))
            //{
            //    //end current simulation
            //    GameOver();
            //}
            //add the score of the board 
            CurrentScore += gridScore;
            return gridScore;
        }

        /// <summary>
        /// Ends the current simulation and opens leaderboard
        /// </summary>
        public bool GameOver()
        {
            int gridScore = CalculateScore();
            bool gameOver = gridScore == 0 || currentState.isScoreStable(gridScore);
            if (gameOver)
            {
                Datastore.AddScore(Username, HighestConcurrentScore);
                return true;
            }
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
        /// <param name="row">the row index</param>
        /// <param name="col">the column index</param>
        public void KillUnit(int row, int col)
        {
            currentState.UnitGrid[row, col].Die(currentState.UnitGrid, currentState.GameEnvironment);
        }

        // (Nicole) load current state
        public void LoadState(string statePath)
        {
            Datastore.LoadState(currentState, statePath);
        }

        // (Nicole) save the current state of the game
        public void SaveState(string name)
        {
            Datastore.SaveState(currentState, name);
        }

        //returns the cached states stored in the current state
        public State[] CachedStates
        {
            get { return currentState.CachedStates; }
        }

        //returns and sets the carbon dioxide level of the current stat
        public int CarbonDioxideLevel
        {
            get { return currentState.CarbonDioxideLevel; }
            set { currentState.CarbonDioxideLevel = value;  }
        }

        //returns the enviornment image of the current state
        public Image EnvironmentImage
        {
            get { return currentState.EnvironmentalImage;  }
        }

        //returns the rain image of the current state
        public Image RainImage
        {
            get { return currentState.RainImage; }
        }

        //returns the event image of the current state
        public Image EventImage
        {
            get { return currentState.EventImage; }
        }

        //returns and sets the food availability of the current state
        public double FoodAvailability
        {
            get { return currentState.FoodAvailability; }
            set { currentState.FoodAvailability = value; }
        }

        //returns and sets the generation number of the current state
        public int GenerationCounter
        {
            get { return currentState.GenerationCounter; }
            set { currentState.GenerationCounter = value; }
        }

        //returns the size of the unit grid
        public int GridSize
        {
            get { return UNIT_GRID_SIZE; }
        }


        //returns and sets the highest recorded score at a given time from the current state
        public int HighestConcurrentScore
        {
            get { return currentState.HighestConcurrentScore; }
            set { currentState.HighestConcurrentScore = value; }
        }

        //returns and sets the water availability of the current state
        public double WaterAvailability
        {
            get { return currentState.WaterAvailability; }
            set { currentState.WaterAvailability = value; }
        }

        //returns and sets the oxygen level of the current state
        public int OxygenLevel
        {
            get { return currentState.OxygenLevel; }
            set { currentState.OxygenLevel = value; }
        }

        //returns and sets the score of the current state
        public int CurrentScore
        {
            get { return currentState.CurrentScore;  }
            set { currentState.CurrentScore = value; }
        }

        //returns and sets the temperature of the current state
        public int Temperature
        {
            get { return currentState.Temperature; }
            set { currentState.Temperature = value; }
        }

        //returns and sets the username associated with the current state
        public string Username
        {
            get { return currentState.Username; }
            set { currentState.Username = value; }
        }

        //returns whether it is raining from the current state's environmebt
        public bool IsRaining
        {
            get { return currentState.GameEnvironment.IsRaining; }
        }

        //returns whether an environmental event is occuring from the current state's environment
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
