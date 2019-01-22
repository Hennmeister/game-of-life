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
    [Serializable]
    public abstract class Unit
    {
        // The type of the Unit
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
            // Set the Unit type
            UnitType = type;
            // Set the decomposition value
            DecompositionValue = decompositionValue;
            // Set the species complexity
            SpeciesComplexity = speciesComplexity;
            // Set the location
            Location = (row, col);
        }
        
        // (Nicole) constructor for loading from file
        /// <summary>
        /// Constructor used by child classes to create a new instance of a child class, given
        /// parameters used to save a given Unit.
        /// </summary>
        /// <remarks>
        /// Author: Nicole
        /// </remarks>
        /// <param name="parameters">An array of parameters describing the Unit in string form.</param>
        public Unit(string[] parameters)
        {
            // convert all parameters to integer
            int.TryParse(parameters[UnitFileFormat.ROW], out int r);
            int.TryParse(parameters[UnitFileFormat.COLUMN], out int c);
            double.TryParse(parameters[UnitFileFormat.DECOMPOSITION_VALUE], out double decompValue);
            int.TryParse(parameters[UnitFileFormat.SPECIES_COMPLEXITY], out int speciesComplexity);

            Location = (r, c);
            DecompositionValue = decompValue;
            SpeciesComplexity = speciesComplexity;
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

        /// <summary>
        /// Returns a new Unit of the same type as this Unit, given parameters
        /// that represent a saved Unit. 
        /// </summary>
        /// <remarks>
        /// Abstract.
        /// </remarks>
        /// <param name="parameters"></param>
        /// <returns>An array of parameters describing the Unit in string form.</returns>
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
