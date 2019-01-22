/*
 * Tiffanie Truong, Rudy Ariaz, and Nicole Beri
 * January 22, 2019
 * The Virus class encapsulates information regarding Viruses and abstracts operations (such as infections)
 * that a Virus can perform.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    [Serializable]
    class Virus : Unit
    {
        // Store the color with which the Virus is represented
        public static readonly System.Drawing.Color baselineColor = System.Drawing.Color.SlateBlue;


        /// <summary>
        /// Constructor used to instantiate completely new Virus objects.
        /// </summary>
        /// <remarks>
        /// Author: Tiffanie Truong
        /// </remarks>
        /// <param name="row">Row of the Virus in the grid.</param>
        /// <param name="col">Column of the Virus in the grid.</param>
        public Virus(int row = -1, int col = -1) : base(Enums.UnitType.Virus, 0.1, 1, row, col)
        {
        }
        
        /// <summary>
        /// Constructor used to instantiate new Virus objects given the parameters of a saved Virus object.
        /// Used in loading Viruses.
        /// </summary>
        /// <remarks>
        /// Author: Nicole Beri
        /// </remarks>
        /// <param name="parameters">A string parameter array representation of a saved Virus,
        /// following the format described in UnitFileFormat.</param>
        public Virus(string[] parameters) : base(parameters)
        {
            // Set the UnitType of the Virus
            UnitType = Enums.UnitType.Virus;
        }

        /// <summary>
        /// Creates and returns a new Virus object given the row and column. Used in UnitFactory.
        /// </summary>
        /// <remarks>
        /// Author: Tiffanie Truong
        /// </remarks>
        /// <param name="row">Row of the Virus in the grid.</param>
        /// <param name="col">Column of the Virus in the Grid.</param>
        /// <returns>A new Virus object with the given row and column.</returns>
        public override Unit Create(int row, int col)
        {
            // Return the Virus with the given row and column
            return new Virus(row, col);
        }

        /// <summary>
        /// Creates and returns a new Virus object given parameters describing a saved Virus object.
        /// Used in UnitFactory.
        /// </summary>
        /// <remarks>
        /// Author: Nicole Beri
        /// </remarks>
        /// <param name="parameters">A string parameter array representation of a saved
        /// Virus. Follows the format described in UnitFileFormat.</param>
        /// <returns>A new Virus object with the given parameters.</returns>
        public override Unit Create(string[] parameters)
        {
            // Return the Virus with the given parameters
            return new Virus(parameters);
        }

        /// <summary>
        /// Updates a Virus with all operations that must be applied to the Virus every generation.
        /// </summary>
        /// <param name="grid">The grid of Units in which the Virus is.</param>
        /// <param name="gameEnv">The Environment with which the Virus interacts.</param>
        public override void Update(Unit[,] grid, Environment gameEnv)
        {
            // Attempt to infect neighboring living units
            Infect(grid);
        }

        /// <summary>
        /// Simulates infection of a neighboring LivingUnit. Only LivingUnits to the left, right, 
        /// top, and bottom of the Virus. Only infects a single neighbor.
        /// </summary>
        /// <param name="grid">The grid of Units.</param>
        private void Infect(Unit[,] grid)
        {
            // Iterate through each of the directions (left, right, top, bottom)
            foreach(var dir in GridHelper.directions)
            {
                // Calculate the row and column of the neighbor
                int newRow = Location.r + dir.Item1;
                int newCol = Location.c + dir.Item2;
                // Check if the neighbor is within the grid
                if(!grid.InGridBounds(newRow, newCol))
                {
                    // Try a different direction 
                    continue;
                }
                // Otherwise, get the neighbor 
                Unit neighbor = grid[newRow, newCol];
                // Check if there is a non-null LivingUnit in the block
                // Infects a unit even if it is already infected
                if(neighbor != null && neighbor is LivingUnit)
                {
                    // Infect the neighbor
                    (neighbor as LivingUnit).BeInfected();
                    // Do not infect any other neighbors
                    break;
                }
            }
        }
    }
}
