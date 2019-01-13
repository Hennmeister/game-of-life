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
            UnitTypes myType = (UnitTypes)UnitTypeIndex;
            switch (myType)
            {
                case UnitTypes.Cell:
                    return new Cell();
                case UnitTypes.Colony:
                    return new Colony();
                case UnitTypes.Animal:
                    return new Animal();
                case UnitTypes.Plant:
                    return new Plant();
                case UnitTypes.Virus:
                    return new Virus();
                default:
                    return null;
            }
        }
        
    }
}
