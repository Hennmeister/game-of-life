// Tiffanie
// Nicole --> added unitType and methods to save and load
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public enum UnitTypeEnum { Virus, Cell, Colony, Animal, Plant };

    public abstract class Unit
    {
        // (Nicole) --> unitType
        protected UnitTypeEnum unitType;

        public UnitTypeEnum UnitType
        {
            get { return unitType; }
        }

        public (int r, int c) Location { get; }
        
        protected double DecompositionValue { get; set; }

        public int SpeciesComplexity { get; }

        public Unit(double decompositionValue, int speciesComplexity, int row = -1, int col = -1)
        {
            DecompositionValue = decompositionValue;
            SpeciesComplexity = speciesComplexity;
        }
        

        
        public void Die(Unit[,] grid, Environment gameEnv)
        {
            grid[Location.r, Location.c] = null;
            gameEnv.IncreaseFood(DecompositionValue);
        }

        public abstract Unit Create(int row, int col);

        public abstract void Update(Unit[,] grid, Environment gameEnv);

        // (Nicole) refactored code so the file is only opened once. 
        // (Nicole) moved SaveUnit to Unit class.
        // (Nicole) save one line into the file
        public void SaveUnit(StreamWriter unitFile)
        {
            // Save location information
            unitFile.WriteLine(ToString());
        }

        // (Nicole) return a string from class properties
        public override string ToString()
        {
            return unitType + ";" + Location.r + ";" + Location.c + ";" + DecompositionValue + ";";
        }
    }
}
