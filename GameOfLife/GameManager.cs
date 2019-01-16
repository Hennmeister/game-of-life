/*
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
        UnitFactory Factory;

        public GameManager()
        {
            Factory = new UnitFactory();
        }

        public void CreateEnvironment(Enums.EnvironmentType envType) { }
        public void CreateGrid(int row, int col) { }
        public void CreateUnit(int row, int col, Enums.UnitType Unittype) { }
        public void CreateState(Environment env) { }

        public void NextGeneration() { }
        public void ApplyRuleset() { }
        public void CalculateScore() { }
        public void UpdateAllUnits() { }
        public void ShowLeaderBoard() { }

        public Unit GetUnit(int row, int col)
        {
            return currentState.UnitGrid[row, col];
        }

        public State LoadState() { }
        public void SaveState() { }

        public int CarbonDioxideLevel
        {
            get { return currentState.CarbonDioxideLevel; }
            set { currentState.CarbonDioxideLevel = value;  }
        }

        public bool EnvironmentalEventOccurs
        {
            get { return currentState.EnvironmentalEventOccurs; }
        }

        public Image EnvironmentImage
        {
            get { return currentState.EnvironmentalImage;  }
        }

        public Image RainImage
        {
            get { return currentState.RainImage; }
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
        public int WaterAvailability
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
        //Returns the grid size
        public int GetGridSize
        {
            get { return UNIT_GRID_SIZE; }
        }
    }
}
