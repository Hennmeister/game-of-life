// (Nicole) - added unitType and constructor for reading from file
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
        // Store the colour plants will be 
        public static readonly System.Drawing.Color baselineColor = System.Drawing.Color.YellowGreen;
        // Store the food generated upon creation
        private const int FOOD_GENERATED_UPON_CREATION = 3;
        // Getter for the base line water requirement
        protected int BaselineWaterRequirement { get; }

        // Getter for toxicity factor
        private int ToxicityFactor { get; }
        // Store the toxicity factor lower bound
        private const int TOXICITY_FACTOR_LOWER_BOUND = 1;
        // Store the toxicity factor upper bound
        private const int TOXICITY_FACTOR_UPPER_BOUND = 100;

        // Store the photosynthesis resource lower bound
        private const int PHOTOSYNTHESIS_RESOURCE_LOWER_BOUND = 1;
        // Store the photosynthesis resource upper bound
        private const int PHOTOSYNTHESIS_RESOURCE_UPPER_BOUND = 4;
        
        // constructor for plant with property values
        public Plant(int row = -1, int col = -1) : base(Enums.UnitType.Plant, senescence: 50,
                       foodRequirement: 5, waterRequirement: 25,
                       gasRequirement: 4, inputGas: Enums.GasType.CarbonDioxide,
                       outputGas: Enums.GasType.Oxygen, idealTemperature: 35,
                       infectionResistance: 7, decompositionValue: 10, row: row, col: col)
        {
            // save the generated toxicity factor
            ToxicityFactor = ProbabilityHelper.RandomInteger(TOXICITY_FACTOR_LOWER_BOUND, TOXICITY_FACTOR_UPPER_BOUND);
            // save base line water requirement
            BaselineWaterRequirement = WaterRequirement;
        }

        // (Nicole) --> constructor for reading files
        public Plant(string[] parameters) : base(parameters)
        {
            // save unit type
            UnitType = Enums.UnitType.Plant;
            // convert all parameters to numerical values
            int.TryParse(parameters[UnitFileFormat.TOXICITY_FACTOR], out int toxicityFactor);
            int.TryParse(parameters[UnitFileFormat.BASELINE_WATER_REQ], out int baselineWaterReq);

            // initialize with new parameters
            ToxicityFactor = toxicityFactor;
            BaselineWaterRequirement = baselineWaterReq;
        }

        public Plant(Environment gameEnv, int row = -1, int col = -1) : this(row, col)
        {
            // increase the food in the environment
            gameEnv.IncreaseFood(FOOD_GENERATED_UPON_CREATION);
        }

        // override plants location
        public override Unit Create(int row, int col)
        {
            return new Plant(row, col);
        }

        // used for loading the plant (pass in its saved parameters)
        public override Unit Create(string[] parameters)
        {
            return new Plant(parameters);
        }

        // decrease food requirement based on location of species
        protected override void UpdateVictualRequirements(int numNeighbors)
        {
            FoodRequirement -= (int)(BaselineWaterRequirement * numNeighbors * VICTUAL_BENEFIT_FOR_COMMUNITY);
        }

        // update the plant
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

        public override void Respire(Environment gameEnv)
        {
            gameEnv.IncreaseOxygen(GasRequirement);
        }

        // photosynthesize method, calculate the resource usage, if it meets the requirement, increase food availability
        protected void Photosynthesize(Environment gameEnv)
        {
            int resourceUsage = 
                ProbabilityHelper.RandomInteger(PHOTOSYNTHESIS_RESOURCE_LOWER_BOUND, PHOTOSYNTHESIS_RESOURCE_UPPER_BOUND);
            if(resourceUsage <= gameEnv.CarbonDioxideLevel && 
               resourceUsage <= gameEnv.WaterAvailability)
            {
                gameEnv.IncreaseFood(resourceUsage);
            }
        }

        // (Nicole) (Nicole) ToString method to serialize properties to string to be saved to file
        public override string ToString()
        {
            return base.ToString() + ";" + ToxicityFactor + ";" + BaselineWaterRequirement;
        }
    }
}
