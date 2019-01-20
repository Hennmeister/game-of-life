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
    public abstract class LivingUnit : Unit
    {
        // Complexity information
        public int Age { get; private set; }
        public int Senescence { get; }
        

        // Temperature information
        public int IdealTemperature { get; protected set; }

        // Food and water information
        public int FoodRequirement { get; protected set; }
        public int WaterRequirement { get; protected set; }

        // Breathing information
        public int GasRequirement { get; protected set; }
        public Enums.GasType InputGas { get; }
        public Enums.GasType OutputGas { get; }

        // Infection information
        protected double InfectionResistance { get; set; }
        private static double MaxResistance { get; set; }
        public bool Infected { get; set; }
        private int CuredGenerationsLeft { get; set; }

        public LivingUnit(int speciesComplexity, int senescence, int foodRequirement,
                          int waterRequirement, int gasRequirement, Enums.GasType inputGas,
                          Enums.GasType outputGas, int idealTemperature, double infectionResistance,
                          double decompositionValue, int row = -1, int col = -1) : base(decompositionValue, speciesComplexity, row, col )
        {
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


        protected void UpdateBasicLivingUnit(Unit[,] grid, Environment gameEnv)
        {
            // Check if the unit is dead
            if (IsDead())
            {
                this.Die(grid, gameEnv);
            }
            // Eat
            Eat(gameEnv, FoodRequirement);
            Drink(gameEnv, WaterRequirement);

            if (ShouldAge(gameEnv))
            {
                AgeUp();
            }
        }
        

        // TODO: check if there's anything else to do here
        private bool IsDead()
        {
            UpdateInfection();
            if(Infected && CuredGenerationsLeft <= 0)
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
            return ProbabilityHelper.EvaluateIndependentPredicate(ageProbability);
        }
        
        // rudy
        private double AgeProbability(Environment gameEnv)
        {
            double temperatureTerm = Math.Abs(gameEnv.Temperature - IdealTemperature) / IdealTemperature;
            double foodTerm = FoodRequirement / gameEnv.FoodAvailability;
            double waterTerm = WaterRequirement / gameEnv.WaterAvailability;
            double prob = 1 - temperatureTerm - foodTerm - waterTerm;
            return prob;
        }
        

        private bool TryCure()
        {
            // If cured
            if (ProbabilityHelper.EvaluateIndependentPredicate(CureProbabillity()))
            {
                Infected = false;
                CuredGenerationsLeft = 0;
                return true;
            }
            return false;
        }

        private double CureProbabillity()
        {
            return InfectionResistance / MaxResistance;
        }

        protected void Drink(Environment gameEnv, int toDrink)
        {
            gameEnv.DecreaseWater(toDrink);
        }

        protected void Eat(Environment gameEnv, double toEat)
        {
            gameEnv.DecreaseFood(toEat);
        }
        
        public virtual void Respire(Environment gameEnv)
        {
            gameEnv.IncreaseCarbonDioxide(GasRequirement);
        }
    }
}
