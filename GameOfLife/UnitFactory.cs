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
            Enums.UnitTypes myType = (Enums.UnitTypes)UnitTypeIndex;
            switch (myType)
            {
                case Enums.UnitTypes.Cell:
                    return new Cell();
                case Enums.UnitTypes.Colony:
                    return new Colony();
                case Enums.UnitTypes.Animal:
                    return new Animal();
                case Enums.UnitTypes.Plant:
                    return new Plant();
                case Enums.UnitTypes.Virus:
                    return new Virus();
                default:
                    return null;
            }
        }
        
    }
}
