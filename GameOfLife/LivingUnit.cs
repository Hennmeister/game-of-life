// Tiffanie
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    abstract class LivingUnit : Unit
    {
        // Complexity information
        protected int age = 0;
        public int Age { get { return this.age; } }
        protected int Senescence { get; }
        protected int SpeciesComplexity { get; }

        // Temperature information
        protected int IdealTemperature { get; }

        // Food and water information
        protected int FoodRequirement { get; }
        protected int WaterRequirement { get; }

        // Breathing information
        protected int GasRequirement { get; }
        protected Enums.GasType InputGas { get; }
        protected Enums.GasType OutputGas { get; }

        // Infection information
        protected double InfectionResistance { get; }
        protected bool Infected { get; }


        public LivingUnit(int speciesComplexity, int senescence, int foodRequirement,
                          int waterRequirement, int gasRequirement, Enums.GasType inputGas,
                          Enums.GasType outputGas, int idealTemperature, double infectionResistance,
                          double decompositionValue, System.Drawing.Color baselineColor) : base(decompositionValue, baselineColor)
        {
            SpeciesComplexity = speciesComplexity;
            Senescence = senescence;
            FoodRequirement = foodRequirement;
            WaterRequirement = waterRequirement;
            GasRequirement = gasRequirement;
            InputGas = inputGas;
            OutputGas = outputGas;
            IdealTemperature = idealTemperature;
            InfectionResistance = infectionResistance;
            Infected = false;
        }

        // Changed Age() to AgeUp() because it has the same name as the property
        public void AgeUp()
        {

        }

        // AgeProbability() could be a bool function ShouldAge()
        // May also be incorporated into Age() itself
        public double AgeProbability()
        {

        }

        public void Cure()
        {

        }

        public double CureProbabillity()
        {

        }

        public int Drink(int waterAvailability)
        {

        }

        public double Eat(double foodAvailability)
        {

        }

        // Should have a pair return type
        public virtual void Respire(int inputGasLevel, int outputGasLevel)
        {

        }
    }
}
