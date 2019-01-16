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
            return currentState.
        }

        public State LoadState() { }
        public void SaveState() { }

        public int CarbonDioxideLevel
        {
            get { }
            set { }
        }

        public bool EnvironmentalEventOccurs
        {
            get { }
            set { }
        }

        public Image EnvironmentImage
        {
            get { }
            set { }
        }

        public Image RainImage
        {
            get { }
            set { }
        }

        public double FoodAvailability
        {
            get { }
            set { }
        }

        public int GenerationCounter
        {
            get { }
            set { }
        }

        public int GridSize
        {
            get { }
            set { }
        }

        public int HighestConcurrentScore
        {
            get { }
            set { }
        }
        public int WaterAvailability
        {
            get { }
            set { }
        }
        public int OxygenLevel
        {
            get { }
            set { }
        }
        public int Score
        {
            get { }
            set { }
        }
        public int Temperature
        {
            get { }
            set { }
        }
        public int Username
        {
            get { }
            set { }
        }
        //Returns the grid size
        public int GetGridSize
        {
            get { return UNIT_GRID_SIZE; }
        }
    }
}
