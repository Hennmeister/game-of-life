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
        protected static double MaxResistance { get; set; }
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
            // convert all parameters to numerical/Boolean values
            int.TryParse(parameters[UnitFileFormat.AGE], out int age);
            int.TryParse(parameters[UnitFileFormat.SENESCENCE], out int senescence);
            int.TryParse(parameters[UnitFileFormat.FOOD_REQ], out int foodRequirement);
            int.TryParse(parameters[UnitFileFormat.WATER_REQ], out int waterRequirement);
            int.TryParse(parameters[UnitFileFormat.GAS_REQ], out int gasRequirement);
            int.TryParse(parameters[UnitFileFormat.INPUT_GAS], out int inputGas);
            int.TryParse(parameters[UnitFileFormat.OUTPUT_GAS], out int outputGas);
            int.TryParse(parameters[UnitFileFormat.IDEAL_TEMP], out int idealTemp);
            double.TryParse(parameters[UnitFileFormat.INFECTION_RESISTANCE], out double infectionResistance);
            double.TryParse(parameters[UnitFileFormat.MAX_RESISTANCE], out double maxResistance);
            bool.TryParse(parameters[UnitFileFormat.INFECTED], out bool infected);
            int.TryParse(parameters[UnitFileFormat.CURED_GENERATIONS_LEFT], out int curedGenerationsLeft);

            // initialize with new parameters
            Age = age;
            Senescence = senescence;
            FoodRequirement = foodRequirement;
            WaterRequirement = waterRequirement;
            GasRequirement = gasRequirement;
            InputGas = (Enums.GasType)inputGas;
            OutputGas = (Enums.GasType)outputGas;
            IdealTemperature = idealTemp;
            InfectionResistance = infectionResistance;
            MaxResistance = Math.Max(MaxResistance, maxResistance);
            Infected = infected;
            CuredGenerationsLeft = curedGenerationsLeft;
        }


        protected void UpdateLivingUnit(Unit[,] grid, Environment gameEnv)
        {
            // If the unit is dying from infection, cannot eat enough, or cannot drink enough, it dies
            if (WillDie() || !Eat(gameEnv, FoodRequirement) || !Drink(gameEnv, WaterRequirement))
            {
                this.Die(grid, gameEnv);
            }
            Respire(gameEnv);
            if (ShouldAge(gameEnv))
            {
                AgeUp();
            }
        }
        

        // TODO: check if there's anything else to do here
        private bool WillDie()
        {
            if (!Infected)
            {
                return false;
            }
            else
            {
                UpdateInfection();
                if (CuredGenerationsLeft <= 0)
                {
                    return true;
                }
                return false;
            }
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
            if (Age == Senescence) return false; 
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

        protected bool Drink(Environment gameEnv, int toDrink)
        {
            // Return whether the lifeform was able to drink as much water as it needs to survive
            return gameEnv.DecreaseWater(toDrink);

        }

        protected bool Eat(Environment gameEnv, double toEat)
        {
            // Return whether the lifeform was able to eat as much food as it needs to survive
            return gameEnv.DecreaseFood(toEat);
        }
        
        // 
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
            return base.ToString() + ";" + Age + ";" + Senescence + ";" + FoodRequirement + ";" + 
                WaterRequirement + ";" + GasRequirement + ";" + (int)InputGas + ";" + (int)OutputGas + ";" + 
                IdealTemperature + ";" + InfectionResistance + ";" + MaxResistance +
                ";" + Infected + ";" + CuredGenerationsLeft;
        }
    }
}
