/*
 * Rudy Ariaz and Henning Lindig
 * January 22, 2019
 * Enums static class stores all of the enumerations used in the program.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public static class Enums
    {
        // Enumeration to represent the different types of Units
        public enum UnitType
        {
            None, Virus, Cell, Colony, Animal, Plant 
        }

        // Enumeration to represent the different types of Environments
        public enum EnvironmentType
        {
            Rainforest, Tundra, Greenhouse, Desert
        }

        // Enumerations to represent the different types of gases
        public enum GasType
        {
            Oxygen, CarbonDioxide
        }
    }
}
