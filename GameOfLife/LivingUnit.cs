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
        public int Age { get; private set; }
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
        private static double MaxResistance { get; set; }
        private bool Infected { get; set; }
        private int CuredGenerationsLeft { get; set; }

        public LivingUnit(int speciesComplexity, int senescence, int foodRequirement,
                          int waterRequirement, int gasRequirement, Enums.GasType inputGas,
                          Enums.GasType outputGas, int idealTemperature, double infectionResistance,
                          double decompositionValue) : base(decompositionValue)
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
            // Update the max resistance if needed
            MaxResistance = Math.Max(MaxResistance, InfectionResistance);
            Infected = false;
            CuredGenerationsLeft = 0;
        }

        // rudy
        public override void Update(Unit[,] grid, Environment gameEnv, int row, int col)
        {
            // Check if the unit is dead
            if (IsDead())
            {
                // Indicate death by deleting the unit from the grid
                grid[row,col] = null;
            }

            if (ShouldAge(gameEnv))
            {
                AgeUp();
            }
            if (Infected)
            {
                CuredGenerationsLeft--;

            }
        }

        // TODO: check if there's anything else to do here
        private bool IsDead()
        {
            UpdateInfection();
            if(CuredGenerationsLeft <= 0)
            {
                return true;
            }
            return false;
        }

        // Updates the infection status every turn
        private void UpdateInfection()
        {
            // Try to cure the infection
            if (!TryCure())
            {
                CuredGenerationsLeft--;
            }
        }
        

        public void BeInfected()
        {
            Infected = true;
            CuredGenerationsLeft = (int)InfectionResistance;
        }

        // Changed Age() to AgeUp() because it has the same name as the property
        private void AgeUp()
        {
            Age++;
        }

        // AgeProbability() could be a bool function ShouldAge()
        // May also be incorporated into Age() itself
        // rudy
        private bool ShouldAge(Environment gameEnv)
        {
            double ageProbability = AgeProbability(gameEnv);
            return ProbabilityHelper.IndependentPredicate(ageProbability);
        }
        
        // rudy
        private double AgeProbability(Environment gameEnv)
        {
            double temperatureTerm = Math.Abs(gameEnv.Temperature - IdealTemperature) / IdealTemperature;
            double foodTerm = FoodRequirement / gameEnv.FoodAvailability;
            double waterTerm = WaterRequirement / gameEnv.WaterAvailabilty;
            double prob = 1 - temperatureTerm - foodTerm - waterTerm;
            return prob;
        }

        private bool TryCure()
        {
            double prob = InfectionResistance / MaxResistance;
            // If cured
            if (ProbabilityHelper.IndependentPredicate(prob))
            {
                Infected = false;
                CuredGenerationsLeft = 0;
                return true;
            }
            return false;
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
