using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Colony : LivingUnit
    {
        public Colony() : base(speciesComplexity : 3, senescence : 16,
                               foodRequirement : 4, waterRequirement : 4,
                               gasRequirement: 2, inputGas : GasType.Oxygen, 
                               outputGas : GasType.CarbonDioxide, idealTemperature : 32,
                               decompositionValue : 6, infectionResistance : 5)
        { }
    }
}
