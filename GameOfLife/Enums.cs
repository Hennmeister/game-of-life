using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public static class Enums
    {
        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
        public enum UnitType
        {
            None, Cell, Colony, Animal, Plant, Virus
        }

        public enum EnvironmentType
        {
            Rainforest, Tundra, Greenhouse, Desert
        }

        public enum GasType
        {
            Oxygen, CarbonDioxide
        }
        
        public enum GameMode
        {
            Realistic, Free
        }
    }
}
