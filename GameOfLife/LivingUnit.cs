/* 
 * Tiffanie Truong
 * January 19, 2018
 * Base class for all living lifeforms in the simulation (Cells, Viruses, Multicellular Organisms)
 */
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
        public int Age { get; }
        public int Senescence { get; }
        public int SpeciesComplexity { get; }

        // Temperature information
        public int IdealTemperature { get; }

        // Food and water information
        public int FoodRequirement { get; }
        public int WaterRequirement { get; }

        // Breathing information
        public int GasRequirement { get; }
        public Enums.GasType InputGas { get; }
        public Enums.GasType OutputGas { get; }

        // Infection information
        public double InfectionResistance { get; }
        public bool Infected { get; }


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
            throw new NotImplementedException();
        }

        public void Cure()
        {

        }

        public double CureProbabillity()
        {
            throw new NotImplementedException();
        }

        public int Drink(int waterAvailability)
        {
            throw new NotImplementedException();
        }

        public double Eat(double foodAvailability)
        {
            throw new NotImplementedException();
        }

        // Should have a pair return type
        public virtual void Respire(int inputGasLevel, int outputGasLevel)
        {

        }
    }
}
