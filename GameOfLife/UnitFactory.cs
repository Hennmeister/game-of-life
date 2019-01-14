using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class UnitFactory
    {
        public UnitFactory() { }
        
        public Unit CreateUnit(int UnitTypeIndex)
        {
            Enums.UnitType myType = (Enums.UnitType)UnitTypeIndex;
            switch (myType)
            {
                case Enums.UnitType.Cell:
                    return new Cell();
                case Enums.UnitType.Colony:
                    return new Colony();
                case Enums.UnitType.Animal:
                    return new Animal();
                case Enums.UnitType.Plant:
                    return new Plant();
                case Enums.UnitType.Virus:
                    return new Virus();
                default:
                    return null;
            }
        }
        
    }
}
