/* 
 * Tiffanie Truong
 * Nicole --> added ToString method and constructor to read from file
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
    [Serializable]
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

        public LivingUnit(Enums.UnitType type, int speciesComplexity, int senescence, int foodRequirement,
                          int waterRequirement, int gasRequirement, Enums.GasType inputGas,
                          Enums.GasType outputGas, int idealTemperature, double infectionResistance,
                          double decompositionValue, int row = -1, int col = -1) : base(type, decompositionValue, 
                          speciesComplexity, row, col )
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

        // (Nicole) constructor for living units to load unit
        public LivingUnit(string[] parameters) : base(parameters)
        {
            // convert all parameters to integer
            int.TryParse(parameters[5], out int senescence);

            int.TryParse(parameters[6], out int foodRequirement);

            int.TryParse(parameters[7], out int waterRequirement);

            int.TryParse(parameters[8], out int gasRequirement);

            int.TryParse(parameters[9], out int inputGas);

            int.TryParse(parameters[10], out int outputGas);

            int.TryParse(parameters[11], out int idealTemp);

            double.TryParse(parameters[12], out double infectionResistance);

            // initialize with new parameters
            Senescence = senescence;
            FoodRequirement = foodRequirement;
            WaterRequirement = waterRequirement;
            GasRequirement = gasRequirement;
            InputGas = (Enums.GasType)inputGas;
            OutputGas = (Enums.GasType)outputGas;
            IdealTemperature = idealTemp;
            InfectionResistance = infectionResistance;
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
            Respire(gameEnv);

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
            if (!IsCured())
            {
                CuredGenerationsLeft--;
            }
            // Otherwise, the infection is cured
            else
            {
                Infected = false;
                CuredGenerationsLeft = 0;
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
        

        protected bool IsCured()
        {
            return ProbabilityHelper.EvaluateIndependentPredicate(CureProbabillity());
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

        // (Nicole) ToString method to serialize properties to string to be saved to file
        // 5: senescence
        // 6: food requirement
        // 7: water requirement
        // 8: gas requirement
        // 9: input gas
        // 10: output gas
        // 11: ideal temp
        // 12: infection resistence
        public override string ToString()
        {
            return base.ToString() + ";" + ";" + Senescence + ";" + FoodRequirement
                + ";" + WaterRequirement + ";" + GasRequirement + ";" + (int)InputGas + ";" + (int)OutputGas
                + ";" + IdealTemperature + ";" + InfectionResistance;
        }
    }
}
