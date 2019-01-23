/*
 * Rudy Ariaz 
 * (Tiffanie - photosynthesis) (Nicole - ToString()) (Henning - respire)
 * January 21, 2019
 * The Plant class encapsulates information about an Plant and implements operations necessary
 * for an plant to interact with its environment. 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    [Serializable]
    class Plant : Multicellular
    {
        // Store the colour that the Plant unit is represented by
        public static readonly System.Drawing.Color baselineColor = System.Drawing.Color.YellowGreen;
        
        /// <summary>
        /// Gets the amount of water that plants require on their own
        /// </summary>
        protected int BaselineWaterRequirement { get; }

        /// <summary>
        /// A unique toxicity factor used to calculate the toxicity of this plant
        /// </summary>
        private int ToxicityFactor { get; }

        // Store the lowest toxicity factor of a plant
        private const int TOXICITY_FACTOR_LOWER_BOUND = 1;
        // Store the highest toxicity factor of a plant
        private const int TOXICITY_FACTOR_UPPER_BOUND = 100;

        // Store the lowest amount of food that can be made in photosynthesis
        private const int PHOTOSYNTHESIS_RESOURCE_LOWER_BOUND = 1;
        // Store the highest amount of food that can be made in photosynthesis
        private const int PHOTOSYNTHESIS_RESOURCE_UPPER_BOUND = 4;

        /// <summary>
        /// Construct a new Plant unit
        /// </summary>
        /// <param name="row"> The row of the Plant within the grid. </param>
        /// <param name="col"> The column of the Plant within the grid. </param>
        public Plant(int row = -1, int col = -1) : base(Enums.UnitType.Plant, senescence: 50,
                       foodRequirement: 5, waterRequirement: 25,
                       gasRequirement: 4, inputGas: Enums.GasType.CarbonDioxide,
                       outputGas: Enums.GasType.Oxygen, idealTemperature: 35,
                       infectionResistance: 7, decompositionValue: 10, row: row, col: col)
        {
            // Generate a unique toxicity factor for this plant -- used to calculate its toxicity
            ToxicityFactor = ProbabilityHelper.RandomInteger(TOXICITY_FACTOR_LOWER_BOUND, TOXICITY_FACTOR_UPPER_BOUND);
            // Store the minimum water requirement for a plant
            BaselineWaterRequirement = WaterRequirement;
        }

        /// <summary>
        /// Used to construct a new Plant object given parameters of a saved Animal.
        /// </summary>
        /// <remarks> Author: Nicole </remarks>
        /// <param name="parameters">A parameter array formatted according to UnitFileFormat.</param>
        public Plant(string[] parameters) : base(parameters)
        {
            // Set the type of the Unit to Animal
            UnitType = Enums.UnitType.Plant;
            // Convert the string parameters into boolean or numerical values depending on their roles
            int.TryParse(parameters[UnitFileFormat.TOXICITY_FACTOR], out int toxicityFactor);
            int.TryParse(parameters[UnitFileFormat.BASELINE_WATER_REQ], out int baselineWaterReq);

            // Initialize the Plants's fields using the parameters
            ToxicityFactor = toxicityFactor;
            BaselineWaterRequirement = baselineWaterReq;
        }

        /// <summary>
        /// Creates and returns a new Plant object with the given parameters of a saved Plant. Used by UnitFactory.
        /// </summary>
        /// <param name="parameters">A parameter array describing an Plant according to UnitFileFormat.</param>
        /// <returns>A new Animal with the given parameters.</returns>
        public override Unit Create(int row, int col)
        {
            // Return the new Plant with the given parameters
            return new Plant(row, col);
        }
        /// <summary>
        /// Creates and returns a new Plant object with the given row and column. Used by UnitFactory.
        /// </summary>
        /// <param name="row">The row of the Plant.</param>
        /// <param name="col">The column of the Plant.</param>
        /// <returns>A new Plant with the given row and column.</returns>
        public override Unit Create(string[] parameters)
        {
            // Return the new Plant with the given parameters
            return new Plant(parameters);
        }

        /// <summary>
        /// Updates the food requirements of the Plant according to the number of neighbors of the same species
        /// in the 5x5 square neighborhood centered on the Plant.
        /// </summary>
        /// <param name="numNeighbors">the number of neighbors of the same species
        /// in the 5x5 square neighborhood centered on the Plant.</param>
        protected override void UpdateVictualRequirements(int numNeighbors)
        {
            FoodRequirement -= (int)(BaselineWaterRequirement * numNeighbors * VICTUAL_BENEFIT_FOR_COMMUNITY);
        }

        /// <summary>
        /// Updates an Plant with all operations that must be applied to the Plant every generation.
        /// </summary>
        /// <remarks>
        /// Called every generation.
        /// </remarks>
        /// <param name="grid">The grid of Units in which the Plant is.</param>
        /// <param name="gameEnv">The Environment with which the Plant interacts.</param>
        public override void Update(Unit[,] grid, Environment gameEnv)
        {
            ApplyCommunityBenefits(grid);
            UpdateLivingUnit(grid, gameEnv);
            Photosynthesize(gameEnv);
        }

        /// <summary>
        /// Find whether or not the plant is currently toxic. Toxicity can change
        /// and is a semi-random property. 
        /// The plant is toxic with probability (t/100) * (a/50), where:
        ///     t: toxicity factor of the plant, determined upon creation,
        ///     100: the maximum toxicity factor of a plant,
        ///     a: the age of the plant,
        ///     50: the maximum age of a plant.
        /// </summary>
        /// <returns>True if the plant is toxic, false otherwise.</returns>
        public bool IsToxic()
        {
            // Calculate the toxicity probability according to the formula above
            double prob = (((double)ToxicityFactor) / TOXICITY_FACTOR_UPPER_BOUND) * 
                          (((double)Age) / Senescence);
            // Use the probability to determine whether the plant is toxic or not
            return ProbabilityHelper.EvaluateIndependentPredicate(prob);
        }

        /// <summary>
        /// Performs respiration, a basic life function in which a plant converts carbon dioxide to oxygen
        /// </summary>
        /// <remarks> Henning Lindig </remarks>
        /// <param name="gameEnv"> The Environment of the simulation that the plants reside in </param>
        public override void Respire(Environment gameEnv)
        {
            // Plants convert carbon dioxide to oxygen, increasing the amount of oxygen in the background
            gameEnv.IncreaseOxygen(GasRequirement);
        }
        /// <summary>
        /// Performs photosynthesis, consuming a random amount of the carbon dioxide and water to return food to the environment
        /// </summary>
        /// <remarks> Tiffanie Truong </remarks>
        /// <param name="gameEnv"> The Environment of the simulation that the plants reside in </param>
        protected void Photosynthesize(Environment gameEnv)
        {
            // Generate how many carbon dioxide and water units are consumed to turn into food
            int resourceUsage = 
                ProbabilityHelper.RandomInteger(PHOTOSYNTHESIS_RESOURCE_LOWER_BOUND, PHOTOSYNTHESIS_RESOURCE_UPPER_BOUND);
            // Check if there is enough carbon dioxide and water in the environment to create this given amount of food
            if(resourceUsage <= gameEnv.CarbonDioxideLevel && 
               resourceUsage <= gameEnv.WaterAvailability)
            {
                // Perform photosynthesis and create more food
                gameEnv.IncreaseFood(resourceUsage);
                // Consume water and carbon dioxide in the environment
                gameEnv.DecreaseFood(resourceUsage);
                gameEnv.DecreaseWater(resourceUsage);
            }
        }

        /// <summary>
        /// ToString method to serialize properties to string to be saved to file
        /// </summary>
        /// <remarks> Nicole Beri </remarks>
        public override string ToString()
        {
            return base.ToString() + ";" + ToxicityFactor + ";" + BaselineWaterRequirement;
        }
    }
}
