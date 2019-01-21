/*
 * Tiffanie Truong, Rudy Ariaz, and Nicole Beri (UnitType and loading and saving methods)
 * January 20, 2019
 * Abstract Unit class encapsulates information about Units and is the base class for all Unit types in the game.
 * Contains basic operations and data that are shared across all Units in the game.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{

    public abstract class Unit
    {
        protected Enums.UnitType UnitType { get; set; }
        // A tuple representing the location of a Unit
        public (int r, int c) Location { get; }
        // The amount of food that a Unit returns to its environment upon death
        protected double DecompositionValue { get; set; }
        // The relative complexity of the Unit's species
        public int SpeciesComplexity { get; }

        /// <summary>
        /// Constructor used by child classes to create a new instance of a child class.
        /// </summary>
        /// <param name="decompositionValue">The decomposition value of the Unit.</param>
        /// <param name="speciesComplexity">The species complexity of the Unit.</param>
        /// <param name="row">Optional: the row of the Unit.</param>
        /// <param name="col">Optional: the column of the Unit.</param>
        public Unit(Enums.UnitType type, double decompositionValue, int speciesComplexity, int row = -1, int col = -1)
        {
            UnitType = type;
            // Set the decomposition value
            DecompositionValue = decompositionValue;
            // Set the species complexity
            SpeciesComplexity = speciesComplexity;
            Location = (row, col);
        }
        
        // (Nicole) constructor for loading from file
        public Unit(string[] parameters)
        {
            // convert all parameters to integer
            int r = -1;
            int.TryParse(parameters[1], out r);

            int c = -1;
            int.TryParse(parameters[2], out c);

            int decomp = 0;
            int.TryParse(parameters[3], out decomp);

            int complexity = 0;
            int.TryParse(parameters[4], out complexity);

            // initialize with new parameters
            DecompositionValue = decomp;
            SpeciesComplexity = complexity;
            Location = (r, c);
        }
               
        /// <summary>
        /// Simulates death of a Unit.
        /// </summary>
        /// <param name="grid">The grid from which the Unit should be removed.</param>
        /// <param name="gameEnv">The Environment to which food should be returned.</param>
        public void Die(Unit[,] grid, Environment gameEnv)
        {
            // Remove the Unit from the grid
            grid[Location.r, Location.c] = null;
            // Add food equal to the decomposition value to the environment
            gameEnv.IncreaseFood(DecompositionValue);
        }

        /// <summary>
        /// Returns a new Unit of the same type as this Unit.
        /// </summary>
        /// <remarks>
        /// Abstract.
        /// </remarks>
        /// <param name="row">The row of the new Unit.</param>
        /// <param name="col">The column of the new Unit.</param>
        /// <returns>The new Unit, with the given row and column as the location.</returns>
        public abstract Unit Create(int row, int col);
        public abstract Unit Create(string[] parameters);

        /// <summary>
        /// Calls all operations (not associated with the basic Game of Life ruleset)
        /// that the Unit can perform. Updates the Unit state.
        /// </summary>
        /// <remarks>
        /// Abstract. Called every generation.
        /// </remarks>
        /// <param name="grid">The grid to use for updating the state.</param>
        /// <param name="gameEnv">The Environment to use for updating the state.</param>
        public abstract void Update(Unit[,] grid, Environment gameEnv);
        

        // (Nicole) ToString method to serialize properties to string to be saved to file
        // 0: unitType
        // 1: row
        // 2: column
        // 3: decomp value
        // 4: species complexity
        public override string ToString()
        {
            return (int)UnitType + ";" + Location.r + ";" + Location.c + ";" + DecompositionValue + ";" + SpeciesComplexity;
        }
    }
}
