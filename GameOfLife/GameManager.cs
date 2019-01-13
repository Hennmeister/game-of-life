using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class GameManager
    {
        //2D array of units in the game grid
        //Need to initialize 
        //MAKE PRIVATE AND ADD A GETUNIT METHOD
        public Unit[,] grid = new Unit[5,5];

        UnitFactory Factory = new UnitFactory();
        public bool CreateUnit(int row, int col, int UnitTypeIndex)
        {
            Unit newUnit = Factory.CreateUnit(UnitTypeIndex);
            if(newUnit != null)
            {
                grid[row, col] = newUnit;

                return true;
            }
            return false;
        }
    }
}
