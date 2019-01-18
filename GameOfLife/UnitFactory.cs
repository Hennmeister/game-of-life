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
            new Colony()
        };

        public static Unit CreateUnit(Enums.UnitType type)
        {
            return modelUnits?.ElementAtOrDefault((int)type);
        }
        
    }
}
