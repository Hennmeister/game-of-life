using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public enum GasType
    {
        Oxygen, CarbonDioxide
    }

    abstract class LivingUnit : Unit
    {
        public int SpeciesComplexity { get; }
        public int Senescence { get; }
        public int FoodRequirement { get; }
        public int WaterRequirement { get; }
        public int GasRequirement { get; }
        public GasType InputGas { get; }
        public GasType OutpugGas { get; }
        public int IdealTemperature { get; }
        public double InfectionResistance { get; }
        public bool Infected { get; }

        public LivingUnit(int speciesComplexity, int senescence, int foodRequirement,
                          int waterRequirement, int gasRequirement, GasType inputGas, 
                          GasType outputGas, int idealTemperature, double infectionResistance,
                          double decompositionValue) : base(decompositionValue)
        {
            SpeciesComplexity = speciesComplexity;
            Senescence = senescence;
            FoodRequirement = foodRequirement;
            WaterRequirement = waterRequirement;
            GasRequirement = gasRequirement;
            InputGas = inputGas;
            OutpugGas = outputGas;
            IdealTemperature = idealTemperature;
            InfectionResistance = infectionResistance;
            Infected = false;
        }
    }
}
