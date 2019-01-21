 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    static class UnitFactory
    {

        private static Unit[] modelUnits = new Unit[]
        {
            null,
            new Virus(),
            new Cell(),
            new Colony(),
            new Animal(),
            new Plant()
        };


        public static Unit CreateUnit(Enums.UnitType type, int row, int col)
        {
            return modelUnits.ElementAtOrDefault((int)type)?.Create(row, col);
        }

        // rudy
        public static Unit CreateUnit(Enums.UnitType type, string[] parameters)
        {
            return modelUnits.ElementAtOrDefault((int)type)?.Create(parameters);
        }
        
    }
}
