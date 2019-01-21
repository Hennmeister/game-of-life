﻿/*
 * Henning Lindig
 * RUDY DID THIS FIRST WITH STATES 
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
        private State startingState;
        private State currentState;
        const int UNIT_GRID_SIZE = 50;

        public GameManager()
        {
            CreateState();
        }

        public void CreateEnvironment(Enums.EnvironmentType envType)
        {
            if (currentState != null)
            {
                currentState.GameEnvironment = EnvironmentFactory.CreateEnvironment(envType);
            }
        }

        public Unit[,] CreateGrid()
        {
            return new Unit[UNIT_GRID_SIZE, UNIT_GRID_SIZE];
        }

        //refactor to have some order
        public void CreateUnit(int row, int col, Enums.UnitType UnitType)
        {
            currentState.UnitGrid[row, col] = UnitFactory.CreateUnit(UnitType, row, col);
        }

        public void CreateState()
        {
            currentState = new State();
            currentState.UnitGrid = CreateGrid();
        }

        public void SetStartingState()
        {
            startingState = currentState;
        }
        
        public void LoadCachedState(int genNum)
        {
            if (currentState.LoadCachedState(genNum) != null)
            {
                currentState = currentState.LoadCachedState(genNum);
                currentState.CachedStates = new State[5];
            }
        }

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

        public void ApplyRuleset()
        {
            //loop through grid and apply the ruleset to each block
            Unit[,] grid = currentState.UnitGrid;
            // Grid representing the new state
            Unit[,] newGrid = new Unit[grid.GetLength(GridHelper.ROW), grid.GetLength(GridHelper.COLUMN)];
            for (int j = 0; j < grid.GetLength(GridHelper.ROW); j++)
            {
                for (int k = 0; k < grid.GetLength(GridHelper.COLUMN); k++)
                {
                    newGrid[j, k] = Ruleset.NewBlockState(grid, j, k);
                }
            }
            // Update the state's grid
            currentState.UnitGrid = newGrid;
        }

        public void CalculateScore()
        {
            Unit[,] grid = currentState.UnitGrid;
            int gridScore = 0;
            for (int j = 0; j < grid.GetLength(GridHelper.ROW); j++)
            {
                for (int k = 0; k < grid.GetLength(GridHelper.COLUMN); k++)
                {
                    //check if block is a virus or not a cell - if so, add the block's species complexity to the total
                    if (!(grid[j, k] is Virus) && grid[j, k] != null)
                    {
                        //add the product of the units 
                        gridScore += Math.Max((grid[j, k] as LivingUnit).SpeciesComplexity * (grid[j, k] as LivingUnit).Age, (grid[j, k] as LivingUnit).SpeciesComplexity);
                    }
                }
            }
            //if the current score of the board is higher than the highest recorded concurrent score, it becomes the new highest concurrent score
            if (gridScore > HighestConcurrentScore) HighestConcurrentScore = gridScore;
            //check if there are any units left on board or if the score has not changed in 5 generations
            if (gridScore == 0 || currentState.isScoreStable(gridScore))
            {
                //if either are true, call gameOver in form and end the current simulation
                var form = System.Windows.Forms.Application.OpenForms.OfType<GameForm>().Single();
                form.GameOver();
            }
            //add the score of the board 
            CurrentScore += gridScore;
        }

        public void UpdateAllUnits()
        {
            Unit[,] grid = currentState.UnitGrid;
            for (int j = 0; j < grid.GetLength(GridHelper.ROW); j++)
            {
                for (int k = 0; k < grid.GetLength(GridHelper.COLUMN); k++)
                {
                    if (grid[j, k] != null)
                    {
                        grid[j, k].Update(grid, currentState.GameEnvironment);
                    }
                }
            }
        }

        //get cached states in consistent with rest of code
        public State[] CachedStates => currentState.CachedStates;

        public Unit GetUnit(int row, int col)
        {
            return currentState.UnitGrid[row, col];
        }

        public void KillUnit(int row, int col)
        {
            currentState.UnitGrid[row, col].Die(currentState.UnitGrid, currentState.GameEnvironment);
        }

        // (Nicole) load current state
        public void LoadState(string statePath)
        {
            Datastore.LoadState(currentState, statePath);
        }

        // save the current state of the game
        public void SaveState(string name)
        {
            Datastore.SaveState(currentState, name);
        }

        public int CarbonDioxideLevel
        {
            get { return currentState.CarbonDioxideLevel; }
            set { currentState.CarbonDioxideLevel = value;  }
        }

        public Image EnvironmentImage
        {
            get { return currentState.EnvironmentalImage;  }
        }

        public Image RainImage
        {
            get { return currentState.RainImage; }
        }

        public Image EventImage
        {
            get { return currentState.EventImage; }
        }

        public double FoodAvailability
        {
            get { return currentState.FoodAvailability; }
            set { currentState.FoodAvailability = value; }
        }

        public int GenerationCounter
        {
            get { return currentState.GenerationCounter; }
            set { currentState.GenerationCounter = value; }
        }

        public int GridSize
        {
            get { return UNIT_GRID_SIZE; }
        }

        public int HighestConcurrentScore
        {
            get { return currentState.HighestConcurrentScore; }
            set { currentState.HighestConcurrentScore = value; }
        }

        public double WaterAvailability
        {
            get { return currentState.WaterAvailability; }
            set { currentState.WaterAvailability = value; }
        }
        public int OxygenLevel
        {
            get { return currentState.OxygenLevel; }
            set { currentState.OxygenLevel = value; }
        }
        public int CurrentScore
        {
            get { return currentState.CurrentScore;  }
            set { currentState.CurrentScore = value; }
        }
        public int Temperature
        {
            get { return currentState.Temperature; }
            set { currentState.Temperature = value; }
        }
        public string Username
        {
            get { return currentState.Username; }
            set { currentState.Username = value; }
        }

        public bool IsRaining
        {
            get { return currentState.GameEnvironment.IsRaining; }
        }

        public bool EnvEventOccurring
        {
            get { return currentState.GameEnvironment.EnvEventOccurring; }
        }

        //Returns the grid size
        public int GetGridSize
        {
            get { return UNIT_GRID_SIZE; }
        }

        public bool IsEnvironmentCreated()
        {
            // (Nicole) checking for object existence before accessing it
            bool bEnvironmentCreated = false;
            if (currentState != null)
            {
                bEnvironmentCreated = currentState.IsEnvironmentCreated();
            }
            return bEnvironmentCreated;
        }
    }
}
