/*
 * Rudy Ariaz, Tiffanie Truong
 * January 21, 2019
 * The Animal class encapsulates information about an Animal and implements operations necessary
 * for an animal to interact with its environment. 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    [Serializable]
    class Animal : Multicellular
    {
        // Store the colour that the animal is represented by
        public static readonly System.Drawing.Color baselineColor = System.Drawing.Color.LightCoral;
        // Store the amount of food required for thermoregulation
        private const int THERMOREGULATION_FOOD = 2;
        // Store the amount of water required for thermoregulation
        private const int THERMOREGULATION_WATER = 1;
        // Store the percentage difference between ideal temperature and external temperature that
        // beyond which, the Animal should thermoregulate
        private const int THERMOREGULATION_THRESHOLD = 5;
        // Store the number of genereations that hibernation lasts
        private const int HIBERNATION_GENERATIONS = 3;
        // Store the factor by which animal stats are scaled upon the start and end of hibernation
        private const double HIBERNATION_START_SCALE_FACTOR = 0.5;
        private const double HIBERNATION_END_SCALE_FACTOR = 2.0;
        // Store the baseline food requirement of an animal
        protected int BaselineFoodRequirement { get; }
        // Store whether or not the Animal is hibernating
        private bool IsHibernating { get; set; }
        // Store how many generations are left for the Animal to hibernate if it is hibernating
        private int HibernationGenerationsLeft { get; set; }


        /// <summary>
        /// Used to construct a completely new Animal object.
        /// </summary>
        /// <remarks>
        /// Author: Tiffanie Truong
        /// </remarks>
        /// <param name="row">The row of the Animal within the grid.</param>
        /// <param name="col">The column of the Animal within the grid.</param>
        public Animal(int row = -1, int col = -1) : base(Enums.UnitType.Animal, senescence: 32,
                               foodRequirement: 8, waterRequirement: 10,
                               gasRequirement: 8, inputGas: Enums.GasType.Oxygen,
                               outputGas: Enums.GasType.CarbonDioxide, idealTemperature: 30,
                               infectionResistance: 8, decompositionValue: 20, row: row, col: col)
        {
            // Set the baseline food requirement of the Animal
            BaselineFoodRequirement = FoodRequirement;
        }
        
        /// <summary>
        /// Used to construct a new Animal object given parameters of a saved Animal.
        /// </summary>
        /// <remarks>
        /// Author: Nicole Beri
        /// </remarks>
        /// <param name="parameters">A parameter array formatted according to UnitFileFormat.</param>
        public Animal(string[] parameters) : base(parameters)
        {
            // Set the type of the Unit to Animal
            UnitType = Enums.UnitType.Animal;
            // Convert the string parameters into boolean or numerical values depending on their roles
            bool.TryParse(parameters[UnitFileFormat.IS_HIBERNATING], out bool isHibernating);
            int.TryParse(parameters[UnitFileFormat.HIBERNATION_GEN_LEFT], out int hibernationGenerationsLeft);
            int.TryParse(parameters[UnitFileFormat.BASELINE_FOOD_REQ], out int baselineFoodReq);

            // Initialize the Animal's fields using the parameters
            IsHibernating = isHibernating;
            HibernationGenerationsLeft = hibernationGenerationsLeft;
            BaselineFoodRequirement = baselineFoodReq;
        }

        /// <summary>
        /// Creates and returns a new Animal object with the given row and column. Used by UnitFactory.
        /// </summary>
        /// <remarks>
        /// Author: Rudy Ariaz
        /// </remarks>
        /// <param name="row">The row of the Animal.</param>
        /// <param name="col">The column of the Animal.</param>
        /// <returns>A new Animal with the given row and column.</returns>
        public override Unit Create(int row, int col)
        {
            // Return the new Animal with the appropriate row and column
            return new Animal(row, col);
        }

        /// <summary>
        /// Creates and returns a new Animal object with the given parameters of a saved Animal. Used by UnitFactory.
        /// </summary>
        /// <remarks>
        /// Author: Nicole Beri
        /// </remarks>
        /// <param name="parameters">A parameter array describing an Animal according to UnitFileFormat.</param>
        /// <returns>A new Animal with the given parameters.</returns>
        public override Unit Create(string[] parameters)
        {
            // Return the new Animal with the given parameters
            return new Animal(parameters);
        }

        /// <summary>
        /// Updates the food requirements of the Animal according to the number of neighbors of the same species
        /// in the 5x5 square neighborhood centered on the Animal.
        /// </summary>
        /// <remarks>
        /// Author: Rudy Ariaz
        /// </remarks>
        /// <param name="numNeighbors">the number of neighbors of the same species
        /// in the 5x5 square neighborhood centered on the Animal.</param>
        protected override void UpdateVictualRequirements(int numNeighbors)
        {
            // Decrease the food requirement by 5% of the baseline food requirement for each neighbor
            FoodRequirement = BaselineFoodRequirement - (int)(BaselineFoodRequirement * numNeighbors * VICTUAL_BENEFIT_FOR_COMMUNITY);
        }


        /// <summary>
        /// Updates an Animal with all operations that must be applied to the Animal every generation.
        /// </summary>
        /// <remarks>
        /// Called every generation.
        /// </remarks>
        /// <remarks>
        /// Author: Rudy Ariaz
        /// </remarks>
        /// <param name="grid">The grid of Units in which the Animal is.</param>
        /// <param name="gameEnv">The Environment with which the Animal interacts.</param>
        public override void Update(Unit[,] grid, Environment gameEnv)
        {
            // Apply the benefits that a Multicellular organism receives based on being in the vicinity of other
            // multicellular organisms
            ApplyCommunityBenefits(grid);
            // Perform basic operations needed for all LivingUnits
            UpdateLivingUnit(grid, gameEnv);

            // Check if the animal is hibernating
            if (IsHibernating)
            {
                // Reduce the number of generations left for hibernation
                HibernationGenerationsLeft--;
                // Try to wake up from hibernation (if there are no hibernation generations left)
                TryWake();
            }
            // Otherwise, apply the usual Animal operations
            else
            {
                // Check if the animal is starving, try to eat a plant
                if (IsStarving(gameEnv))
                {
                    // Try to eat a Plant
                    CheckPlantsToEat(grid, gameEnv);
                }
                // Check if the Unit should and can thermoregulate
                if (ShouldThermoregulate(gameEnv) && CanThermoregulate(gameEnv))
                {
                    // Thermoregulate if needed
                    Thermoregulate(gameEnv);
                }
            }
        }

        /// <summary>
        /// Checks for Plants to eat (which are in direct contact with the Animal, so 
        /// diagonal Plants are not included). Eats a Plant if a valid one is found (only one Plant can be eaten).
        /// </summary>
        /// <remarks>
        /// Author: Rudy Ariaz
        /// </remarks>
        /// <param name="grid">The Grid to use for finding Plants.</param>
        /// <param name="gameEnv">The Environment with which the Unit interacts.</param>
        private void CheckPlantsToEat(Unit[,] grid, Environment gameEnv)
        {
            // Get the row and column of the Animal
            int row = Location.r, col = Location.c;
            // Iterate through each of the directions (up, down, left, right)
            foreach(var dir in GridHelper.directions)
            {
                // Compute the new row and column of the grid block being checked
                int newRow = row + dir.Item1;
                int newCol = col + dir.Item2;
                // If the block is not within the grid, try a different direction 
                if(!grid.InGridBounds(newRow, newCol))
                {
                    continue;
                }

                // Otherwise, get the neighbor in the block
                Unit neighbor = grid[newRow, newCol];
                // Check if the neighbor is a non-null Plant
                if(neighbor != null && neighbor is Plant)
                {
                    // Eat the Plant
                    EatPlant(grid, gameEnv, (Plant)neighbor);
                    // Stop looking for Plants
                    break;
                }
            }
        }

        /// <summary>
        /// Simulates eating a neighboring Plant. Causes Animal to die if the Plant is toxic.
        /// Animal enters hibernation after eating a Plant.
        /// </summary>
        /// <remarks>
        /// Author: Rudy Ariaz
        /// </remarks>
        /// <param name="grid">The grid in which the Plant and Animal are.</param>
        /// <param name="gameEnv">The Environment with which the Units interact.</param>
        /// <param name="toEat">The Plant to eat.</param>
        private void EatPlant(Unit[,] grid, Environment gameEnv, Plant toEat)
        {
            // Kill the plant
            toEat.Die(grid, gameEnv);
            // Check if the plant is toxic
            if (toEat.IsToxic())
            {
                // The Animal dies if the plant is toxic
                this.Die(grid, gameEnv);
            }
            // Otherwise, enter hibernation
            Hibernate();
        }

        /// <summary>
        /// Simulates hibernation: for 3 generations, most of the Animal's paramters are halved.
        /// </summary>
        /// <remarks>
        /// Called after eating a Plant.
        /// Author: Rudy Ariaz
        /// </remarks>
        private void Hibernate()
        {
            // Note that the Animal is hibernating
            IsHibernating = true;
            // Record the number of hibernation generations left
            HibernationGenerationsLeft = HIBERNATION_GENERATIONS;
            // Halve the Animal's parameters
            ScaleAnimalParameters(HIBERNATION_START_SCALE_FACTOR);
        }

        /// <summary>
        /// Checks whether the Animal can wake up from hibernation.
        /// Precondition: the Animal is currently in hibernation.
        /// </summary>
        /// <remarks>
        /// Author: Rudy Ariaz
        /// </remarks>
        private void TryWake()
        {
            // Check if hibernation should end since there are no hibernation generations left
            if(HibernationGenerationsLeft <= 0)
            {
                // Note that the Animal is no longer hibernating
                IsHibernating = false;
                // Double the Animal's parameters to counteract the 
                ScaleAnimalParameters(HIBERNATION_END_SCALE_FACTOR);
            }
        }

        /// <summary>
        /// Scale some of the Animal parameters for hibernation or the end of hibernation.
        /// Parameters scaled:
        ///     Food Requirement
        ///     Water Requirement
        ///     Gas Requirement
        ///     Ideal Temperature
        ///     Decomposition Value
        ///     Infection Resistance (and possibly Max Resistance)
        /// </summary>
        /// <remarks>
        /// Author: Rudy Ariaz
        /// </remarks>
        /// <param name="scaleFactor">The scale factor (either 0.5 for the start of hibernation,
        /// 2.0 for the end of hibernation) used to scale parameters.</param>
        private void ScaleAnimalParameters(double scaleFactor)
        {
            // Scale the food requirement
            FoodRequirement = (int)(FoodRequirement * scaleFactor);
            // Scale the water requirement
            WaterRequirement = (int)(WaterRequirement * scaleFactor);
            // Scale the gas requirement
            GasRequirement = (int)(GasRequirement * scaleFactor);
            // Scale the ideal temperature
            IdealTemperature = (int)(IdealTemperature * scaleFactor);
            // Scale the decomposition value
            DecompositionValue = DecompositionValue * scaleFactor;
            // Scale the infection resistance
            InfectionResistance = InfectionResistance * scaleFactor;
            // Update the max infection resistance if needed
            MaxResistance = Math.Max(InfectionResistance, MaxResistance);
        }

        /// <summary>
        /// Checks if the Animal is starving. An Animal is starving if the food available to it
        /// is less than 600% of the food requirement.
        /// </summary>
        /// <remarks>
        /// Author: Rudy Ariaz
        /// </remarks>
        /// <param name="gameEnv">The Environment with which the Animal interacts.</param>
        /// <returns>True if the Animal is starving, false otherwise.</returns>
        public bool IsStarving(Environment gameEnv)
        {
            // Check if the food availability is less than 600% of the food requirement
            return gameEnv.FoodAvailability < FoodRequirement * 6;
        }

        /// <summary>
        /// Checks whether or not the Animal should thermoregulate. An Animal should thermoregulate
        /// if the percentage difference between the ideal temperature and external temperature is greater than or
        /// equal to 5 percent.
        /// </summary>
        /// <remarks>
        /// Author: Rudy Ariaz
        /// </remarks>
        /// <param name="gameEnv">The Environment of the Animal.</param>
        /// <returns>True if the Animal should thermoregulate, false, otherwise.</returns>
        private bool ShouldThermoregulate(Environment gameEnv)
        {
            // Calculate the absolute percentage difference between the external temperature and the ideal temperature
            double percentageDifference = 100.0 * Math.Abs(gameEnv.Temperature - IdealTemperature) / (IdealTemperature);
            // Check if the percentage difference is greater than or equal to the threshold (5%)
            return percentageDifference >= THERMOREGULATION_THRESHOLD;
        }

        /// <summary>
        /// Checks whether or not an Animal can thermoregulate. An Animal can thermoregulate if 
        /// the amount of food and water available to it exceeds the amount required for thermoregulation,
        /// and if it is not hibernating.
        /// </summary>
        /// <remarks>
        /// In most cases, an Animal should be able to thermoregulate.
        /// Author: Rudy Ariaz
        /// </remarks>
        /// <param name="gameEnv">The Environment of the Animal.</param>
        /// <returns>True if the Animal has enough resources to thermoregulate, fallse otherwise.</returns>
        private bool CanThermoregulate(Environment gameEnv)
        {
            // Check if the food and water availability is greater than the amount required for thermoregulation,
            // and if the Animal is not hibernating
            return gameEnv.FoodAvailability >= THERMOREGULATION_FOOD &&
                   gameEnv.WaterAvailability >= THERMOREGULATION_WATER &&
                   !IsHibernating;
        }

        /// <summary>
        /// Simulates thermoregulation, increasing or decreasing the Animal's ideal temperature
        /// to adjust to a higher or lower external temperature, respectively. The ideal temperature
        /// only changes by 1 degree Celsius for every call of this method. Thermoregulation consumes
        /// 2 units of food and 1 unit of water.
        /// </summary>
        /// <remarks>
        /// Author: Rudy Ariaz
        /// </remarks>
        /// <param name="gameEnv">The Environment of the Animal.</param>
        private void Thermoregulate(Environment gameEnv)
        {
            // Check if the ideal temperature is greater than the external temperature, so 
            // should decrease ideal temperature to adjust to environment
            if (IdealTemperature > gameEnv.Temperature)
            {
                // Decrease the ideal temperature
                IdealTemperature--;                
            }
            // Otherwise, check if the ideal temperature is less than the external, so
            // should increase ideal temperature to adjust to the environment
            else if(IdealTemperature < gameEnv.Temperature)
            {
                // Increase the ideal temperature
                IdealTemperature++;
            }
            // Consume the amount of food and water required for thermoregulation
            Eat(gameEnv, THERMOREGULATION_FOOD);
            Drink(gameEnv, THERMOREGULATION_WATER);
        }

        /// <summary>
        /// Computes a string representation of the Animal for saving and loading.
        /// Format:
        ///     All of the parameters in the string that a LivingUnit constructs in its ToString()
        ///     Hibernation Status
        ///     Hibernation Generationos Left
        ///     Baseline Food Requirements
        /// </summary>
        /// <remarks>
        /// Author: Nicole Beri
        /// </remarks>
        /// <returns>A string representation of the Animal's parameters.</returns>
        public override string ToString()
        {
            // Construct the string with the important parameters
            return base.ToString() + ";" + IsHibernating + ";" + HibernationGenerationsLeft + ";" + BaselineFoodRequirement;
        }
    }
}
