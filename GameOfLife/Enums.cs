﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public static class Enums
    {
        public enum UnitType
        {
            Cell, Colony, Animal, Plant, Virus
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
