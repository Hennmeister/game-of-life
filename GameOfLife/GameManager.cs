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

        private string username;
        const int UNIT_GRID_SIZE = 50;
        UnitFactory Factory = new UnitFactory();


        public void CreateEnvironment(Environmenttype ENUM) { }
        public void CreateGrid(int row, int col) { }
        public void CreateUnit(int row, int col, Enums.UnitType type) { }

        public void NextGeneration() { }
        public void ApplyRuleset() { }
        public void CalculateScore() { }
        public void UpdateAllUnits() { }
        public void ShowLeaderBoard() { }
        
        public int GetCarbonDioxideLevel
        {
            get { }
            set { }
        }

        public bool GetEnvironmentalEventOccurs
        {
            get { }
            set { }
        }

        public Image GetEnvironmentImage
        {
            get { }
            set { }
        }

        public Image GetRainImage
        {
            get { }
            set { }
        }

        public double GetFoodAvailability
        {
            get { }
            set { }
        }

        public int GetGenerationCounter
        {
            get { }
            set { }
        }

        public int GetGridSize
        {
            get { }
            set { }
        }

        public int GetHighestConcurrentScore
        {
            get { }
            set { }
        }
        public int GetWaterAvailability
        {
            get { }
            set { }
        }
        public int GetOxygenLevel
        {
            get { }
            set { }
        }
        public int GetScore
        {
            get { }
            set { }
        }
        public int Temperature
        {
            get { }
            set { }
        }
        public Unit GetUnit(int row, int col) { }

        public int GetUsername
        {
            get { }
            set { }
        }

    }
}
