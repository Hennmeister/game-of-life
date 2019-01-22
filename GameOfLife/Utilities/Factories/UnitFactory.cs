/*
 * Rudy Ariaz
 * January 22, 2019
 * Factory for environment objects that creates a child of environment given a type
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    static class UnitFactory
    {
        /// <summary>
        /// Initializes the array of possible units that could be created
        /// </summary>
        private static Unit[] modelUnits = new Unit[]
        {
            null,
            new Virus(),
            new Cell(),
            new Colony(),
            new Animal(),
            new Plant()
        };

        /// <summary>
        /// Create a unit of the given type at the given location
        /// </summary>
        /// <param name="type">The type of unit to create</param>
        /// <param name="row">The row index</param>
        /// <param name="col">The column index</param>
        /// <returns>The newly created object of the given type</returns>
        public static Unit CreateUnit(Enums.UnitType type, int row, int col)
        {
            return modelUnits.ElementAtOrDefault((int)type)?.Create(row, col);
        }

        /// <summary>
        /// Create a unit of the given type with the given parameters as its property values
        /// Used for loading Units from file
        /// </summary>
        /// <param name="type">The type of unit to create</param>
        /// <param name="parameters">The values of the unit's properties</param>
        /// <returns></returns>
        public static Unit CreateUnit(Enums.UnitType type, string[] parameters)
        {
            return modelUnits.ElementAtOrDefault((int)type)?.Create(parameters);
        }
        
    }
}
