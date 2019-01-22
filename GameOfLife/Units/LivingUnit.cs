/* 
 * Tiffanie Truong, Rudy Ariaz, Nicole Beri
 * January 22, 2018
 * Base class for all living lifeforms in the simulation (Cells, Colonies, Multicellular Organisms).
 * Encapsulates information and provides methods for performing operations of LivingUnits.
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
        /// <summary>
        /// Gets and sets the age of the Unit.
        /// </summary>
        public int Age { get; private set; }
        /// <summary>
        /// Gets the senescence value of the Unit (age cannot increase past this value).
        /// </summary>
        protected int Senescence { get; }
        
        /// <summary>
        /// Gets and sets the ideal operating temperature of the organism.
        /// </summary>
        protected int IdealTemperature { get; set; }
        
        /// <summary>
        /// Gets and sets food requirement of the Unit.
        /// </summary>
        protected int FoodRequirement { get; set; }
        /// <summary>
        /// Gets and sets water requirement of the Unit.
        /// </summary>
        protected int WaterRequirement { get; set; }
        
        /// <summary>
        /// Gets and sets the gas unit requirement of the Unit.
        /// </summary>
        protected int GasRequirement { get; set; }
        /// <summary>
        /// Gets the type of input gas of the Unit.
        /// </summary>
        private Enums.GasType InputGas { get; }
        /// <summary>
        /// Gets the type of output gas of the Unit.
        /// </summary>
        private Enums.GasType OutputGas { get; }
        
        /// <summary>
        /// Gets and sets the infection resistance of the LivingUnit.
        /// </summary>
        protected double InfectionResistance { get; set; }
        /// <summary>
        /// Gets and sets the maximum resistance of all LivingUnits.
        /// </summary>
        protected static double MaxResistance { get; set; }
        /// <summary>
        /// Gets and sets the infection status of all LivingUnits.
        /// </summary>
        public bool Infected { get; set; }
        /// <summary>
        /// Gets and sets the generations left to be cured.
        /// </summary>
        private int CuredGenerationsLeft { get; set; }

        /// <summary>
        /// Constructor instantiates a new LivingUnit object given required parameters to describe the Unit.
        /// </summary>
        /// <remarks>
        /// Author: Rudy Ariaz
        /// </remarks>
        /// <param name="type">The type of Unit.</param>
        /// <param name="speciesComplexity">The complexity of the Unit's species.</param>
        /// <param name="senescence">The senescence value of the Unit.</param>
        /// <param name="foodRequirement">The food requirement of the Unit.</param>
        /// <param name="waterRequirement">The water requirement of the Unit.</param>
        /// <param name="gasRequirement">The gas requirement of the Unit.</param>
        /// <param name="inputGas">The input gas of the Unit.</param>
        /// <param name="outputGas">The output gas of the Unit.</param>
        /// <param name="idealTemperature">The ideal temperature of the Unit.</param>
        /// <param name="infectionResistance">The infection resistance of the Unit.</param>
        /// <param name="decompositionValue">The decomposition value of the Unit.</param>
        /// <param name="row">Optional: The row of the Unit (within the grid).</param>
        /// <param name="col">Optional: The column of the Unit (within the grid).</param>
        public LivingUnit(Enums.UnitType type, int speciesComplexity, int senescence, int foodRequirement,
                          int waterRequirement, int gasRequirement, Enums.GasType inputGas,
                          Enums.GasType outputGas, int idealTemperature, double infectionResistance,
                          double decompositionValue, int row = -1, int col = -1) : base(type, decompositionValue, 
                          speciesComplexity, row, col )
        {
            // Set the senesence value
            Senescence = senescence;
            // Set the food requirement
            FoodRequirement = foodRequirement;
            // Set the water requirement
            WaterRequirement = waterRequirement;
            // Set the gas requirement
            GasRequirement = gasRequirement;
            // Set the input gas
            InputGas = inputGas;
            // Set the output gas
            OutputGas = outputGas;
            // Set the ideal temperature
            IdealTemperature = idealTemperature;
            // Set the infection resistance
            InfectionResistance = infectionResistance;
            // Update the max resistance if needed
            MaxResistance = Math.Max(MaxResistance, InfectionResistance);
            // Set the infection status to false
            Infected = false;
            // Initialize the number of generations left to be cured
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
