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

        /// <summary>
        /// Constructor instaniates a new LivingUnit object given an array of parameters used to describe the unit
        /// Used when loading a living unit from file.
        /// </summary>
        /// <remarks>
        /// Author: Nicole Beri
        /// </remarks>
        /// <param name="parameters">The array of parameters used to describe the unit.</param>
        public LivingUnit(string[] parameters) : base(parameters)
        {
            // Convert all parameters to numerical/Boolean values
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

            // Initialize with new parameters
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

        /// <summary>
        /// Updates a living unit with all operations that must be applied to the unit every generation.
        /// </summary>
        /// <remarks>
        /// Author: Tiffanie Truong
        /// </remarks>
        /// <param name="grid">The unit grid.</param>
        /// <param name="gameEnv">The environement of the current state.</param>
        protected void UpdateLivingUnit(Unit[,] grid, Environment gameEnv)
        {
            // If the unit is dying from infection, cannot eat enough, or cannot drink enough, it dies
            if (IsInfectionFatal() || !Eat(gameEnv, FoodRequirement) || !Drink(gameEnv, WaterRequirement))
            {
                this.Die(grid, gameEnv);
            }
            //changes gas levels according to the unit's properties
            Respire(gameEnv);
            // If the unit can get older, increase its age
            if (ShouldAge(gameEnv))
            {
                Age++;
            }
        }
        
        /// <summary>
        /// Checks whether the living unit should die this generation from infection by viruses.
        /// </summary>
        /// <remarks>
        /// Author: Rudy Ariaz
        /// </remarks>
        /// <returns>True if the unit Should die from infection, false if the Unit should not die.</returns>
        private bool IsInfectionFatal()
        {
            // Check if the unit is not infected
            if (!Infected)
            {
                // Return false to indicate that the Unit should not die from infection
                return false;
            }
            // If it is, check if it will die due to being infected
            else
            {
                // Update the infection status
                UpdateInfection();
                // Check if the time the Unit has to cure itself has run out
                if (CuredGenerationsLeft <= 0)
                {
                    // Return true to indicate that the Unit should die from infection
                    return true;
                }
                // The Unit should not die from infection
                return false;
            }
        }

        /// <summary>
        /// Updates the status of the unit's infection.
        /// </summary>
        /// <remarks>
        /// Author: Rudy Ariaz
        /// </remarks>
        private void UpdateInfection()
        {
            // Try to cure the infection, check if it failed
            if (!IsCured())
            {
                // Decrease the number of generations left for curing
                CuredGenerationsLeft--;
            }
            // Otherwise, the infection is cured
            else
            {
                // Set the infection status to false
                Infected = false;
                // Reset the cure generation counter
                CuredGenerationsLeft = 0;
            }
        }
        
        /// <summary>
        /// Infects the living unit
        /// </summary>
        /// <remarks>
        /// Author: Rudy Ariaz
        /// </remarks>
        public void BeInfected()
        {
            // Set infection status to true
            Infected = true;
            // Set the number of generations left to be cured
            CuredGenerationsLeft = (int)InfectionResistance;
        }
        
        /// <summary>
        /// Checks if the unit should increase in age. This is probabilistic. A Unit
        /// cannot age past its age of senescence.
        /// </summary>
        /// <remarks>
        /// Author: Tiffanie Truong
        /// </remarks>
        /// <param name="gameEnv"></param>
        /// <returns>True if the Unit should age, false otherwise.</returns>
        private bool ShouldAge(Environment gameEnv)
        {
            // Calculate the probability that the Unit should age
            double ageProbability = AgeProbability(gameEnv);
            // If the Unit's age is at its max, do not age
            if (Age == Senescence) return false;
            // Otherwise, probabilistically determine if it should age based on its conditions
            return ProbabilityHelper.EvaluateIndependentPredicate(ageProbability);
        }
        
        /// <summary>
        /// Determines the probability that a Unit will age. This depends on:
        ///     The percentage difference between the ideal temperature and the external temperature
        ///     The ratio between the food requirement and food availability
        ///     The ratio between the water requirement and water availability
        /// </summary>
        /// <remarks>
        /// Author: Rudy Ariaz
        /// </remarks>
        /// <param name="gameEnv">The current state's game environment</param>
        /// <returns>The proability that the Unit will increase in age.</returns>
        private double AgeProbability(Environment gameEnv)
        {
            // Calculate the percentage difference of the temperature
            double temperatureTerm = Math.Abs(gameEnv.Temperature - IdealTemperature) / IdealTemperature;
            // Calculate ratios of food/water requirement to food/water availability
            double foodTerm = FoodRequirement / gameEnv.FoodAvailability;
            double waterTerm = WaterRequirement / gameEnv.WaterAvailability;
            // Calculate the probability of aging and return it
            double prob = 1 - temperatureTerm - foodTerm - waterTerm;
            return prob;
        }
        
        /// <summary>
        /// Determine whether the LivingUnit is cured of infection. 
        /// </summary>
        /// <remarks>
        /// Author: Rudy Ariaz
        /// </remarks>
        /// <returns>True if the LivingUnit is cured, false otherwise.</returns>
        protected bool IsCured()
        {
            // Evaluate whether the Unit is cured or not, depending on the cure probability
            return ProbabilityHelper.EvaluateIndependentPredicate(CureProbabillity());
        }

        /// <summary>
        /// Calculate the living unit's probability of curing its infection.
        /// </summary>
        /// <remarks>
        /// Author: Rudy Ariaz
        /// </remarks>
        /// <returns>The probability that the Unit is cured of its infection.</returns>
        private double CureProbabillity()
        {
            // Calculate the probability based on the ratio between the infection resistance
            // and the maximum infection resistance
            return InfectionResistance / MaxResistance;
        }

        /// <summary>
        /// Simulates drinking by the LivingUnit. Consumes water from its Environment (if possible),
        /// and returns whether there was enough water to consume.
        /// </summary>
        /// <remarks>
        /// Author: Rudy Ariaz
        /// </remarks>
        /// <param name="gameEnv">The Unit's Environment.</param>
        /// <param name="toDrink">The amount of water to drink.</param>
        /// <returns>True if there was enough water to consume and the drinking occurred,
        /// false otherwise.</returns>
        protected bool Drink(Environment gameEnv, int toDrink)
        {
            // Return whether the lifeform was able to drink as much water as it needs to survive,
            // and consume the water if possible
            return gameEnv.DecreaseWater(toDrink);
        }
        
        /// <summary>
        /// Simulates eating by the LivingUnit. Consumes food from its Environment (if possible),
        /// and returns whether there was enough food to consume.
        /// </summary>
        /// <remarks>
        /// Author: Rudy Ariaz
        /// </remarks>
        /// <param name="gameEnv">The Unit's Environment.</param>
        /// <param name="toDrink">The amount of food to drink.</param>
        /// <returns>True if there was enough food to consume and the drinking occurred,
        /// false otherwise.</returns>
        protected bool Eat(Environment gameEnv, double toEat)
        {
            // Return whether the lifeform was able to eat as much water as it needs to survive,
            // and consume the food if possible
            return gameEnv.DecreaseFood(toEat);
        }
        
        /// <summary>
        /// Simulates breathing (converting oxygen to carbon dioxide). Overriden in the Plant class.
        /// </summary>
        /// <remarks>
        /// Author: Rudy Ariaz
        /// </remarks>
        /// <param name="gameEnv">Environment of the Unit.</param>
        public virtual void Respire(Environment gameEnv)
        {
            // Increase the Environment's carbon dioxide and decrease oxygen
            gameEnv.IncreaseCarbonDioxide(GasRequirement);
        }
        
        /// <summary>
        /// ToString method to serialize properties to string to be saved to a file. The format is:
        ///     All of the parameters in the string that a Unit constructs in its ToString()
        ///     Age
        ///     Senescence
        ///     FoodRequirement
        ///     WaterRequirement
        ///     GasRequirement
        ///     InputGas
        ///     OutpusGas
        ///     IdealTemperature
        ///     InfectionResistance
        ///     MaxResistance
        ///     Infected
        ///     CuredGenerationsLeft
        /// </summary>
        /// <remarks>
        /// Author: Nicole Beri
        /// </remarks>
        /// <returns>The semicolon-separated string representation of the Unit.</returns>
        public override string ToString()
        {
            // Construct the string representation
            return base.ToString() + ";" + Age + ";" + Senescence + ";" + FoodRequirement + ";" + 
                WaterRequirement + ";" + GasRequirement + ";" + (int)InputGas + ";" + (int)OutputGas + ";" + 
                IdealTemperature + ";" + InfectionResistance + ";" + MaxResistance +
                ";" + Infected + ";" + CuredGenerationsLeft;
        }
    }
}
