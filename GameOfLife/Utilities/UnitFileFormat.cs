using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Utilities
{
    public static class UnitFileFormat
    {
        // Parameters for any Unit
        public const int UNIT_TYPE = 0, ROW = 1, COLUMN = 2;
        // Parameters for LivingUnits
        public const int AGE = 3, FOOD_REQ = 4, WATER_REQ = 5, GAS_REQ = 6, IDEAL_TEMP = 7, INFECTION_RESISTANCE = 8,
            MAX_RESISTANCE = 9, INFECTED = 10, CURED_GENERATIONS_LEFT = 11;
        // Parameters for Animals
        public const int IS_HIBERNATING = 12, HIBERNATION_GEN_LEFT = 13;
        // Parameters for Plants
        public const int TOXICITY_FACTOR = 12;
    }
}
