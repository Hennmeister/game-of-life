// Tiffanie
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Animal : Multicellular
    {
        public Animal() : base( senescence: 32,
                               foodRequirement: 8, waterRequirement: 10,
                               gasRequirement: 8, inputGas: Enums.GasType.Oxygen,
                               outputGas: Enums.GasType.CarbonDioxide, idealTemperature: 30,
                               infectionResistance: 8, decompositionValue: 20, baselineColor: System.Drawing.Color.LightCoral)
        {

        }

        public override Unit Create()
        {
            return new Animal();
        }

        public override int DecreaseVictualRequirements(Unit[,] grid, int row, int col)
        {
            throw new NotImplementedException();
        }

        public override int IncreaseVictualRequirements(Unit[,] grid, int row, int col)
        {
            throw new NotImplementedException();
        }

        public override void Update(Unit[,] grid, int row, int col)
        {

        }

        public void DecreaseIdealTemperature()
        {

        }

        public void EatPlant(Unit[,] grid, int row, int col)
        {

        }

        public void Hibernate()
        {

        }

        public void IncreaseIdealTemperature()
        {

        }

        public bool IsStarving()
        {
            throw new NotImplementedException();
        }

        public bool ShouldThermoregulate()
        {
            throw new NotImplementedException();
        }

        public void Thermoregulate()
        {

        }

        public void Wake()
        {

        }
    }
}
