/*
 * Rudy Ariaz
 * January 22, 2019
 * UnitFileFormat static class stores constants that represents the indices of Unit parameters
 * in a string parameters array that represents a Unit. Used in saving and loading the state of the game.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public static class UnitFileFormat
    {
        // Parameters for any Unit
        public const int UNIT_TYPE = 0, ROW = 1, COLUMN = 2, DECOMPOSITION_VALUE = 3, SPECIES_COMPLEXITY = 4;
        // Parameters for LivingUnits
        public const int AGE = 5, SENESCENCE = 6, FOOD_REQ = 7, WATER_REQ = 8, GAS_REQ = 9, 
            INPUT_GAS = 10, OUTPUT_GAS = 11, IDEAL_TEMP = 12, INFECTION_RESISTANCE = 13,
            MAX_RESISTANCE = 14, INFECTED = 15, CURED_GENERATIONS_LEFT = 16;
        // Parameters for Animals
        public const int IS_HIBERNATING = 17, HIBERNATION_GEN_LEFT = 18, BASELINE_FOOD_REQ = 19;
        // Parameters for Plants
        public const int TOXICITY_FACTOR = 17, BASELINE_WATER_REQ = 18;
    }
}
