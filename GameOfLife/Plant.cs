// (Nicole) - added unitType and constructor for reading from file
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Plant : Multicellular
    {
        public static readonly System.Drawing.Color baselineColor = System.Drawing.Color.YellowGreen;
        private const int FOOD_GENERATED_UPON_CREATION = 3;
        protected int BaselineWaterRequirement { get; }

        private int ToxicityFactor { get; }
        private const int TOXICITY_FACTOR_LOWER_BOUND = 1;
        private const int TOXICITY_FACTOR_UPPER_BOUND = 100;

        private const int PHOTOSYNTHESIS_RESOURCE_LOWER_BOUND = 1;
        private const int PHOTOSYNTHESIS_RESOURCE_UPPER_BOUND = 4;
        

        public Plant(int row = -1, int col = -1) : base(senescence: 50,
                       foodRequirement: 5, waterRequirement: 25,
                       gasRequirement: 4, inputGas: Enums.GasType.CarbonDioxide,
                       outputGas: Enums.GasType.Oxygen, idealTemperature: 35,
                       infectionResistance: 7, decompositionValue: 10, row: row, col: col)
        {
            ToxicityFactor = ProbabilityHelper.RandomInteger(TOXICITY_FACTOR_LOWER_BOUND, TOXICITY_FACTOR_UPPER_BOUND);
            BaselineWaterRequirement = WaterRequirement;
            // (Nicole) - added unitType
            unitType = UnitTypeEnum.Plant;
        }

        // (Nicole) --> constructor for reading files
        public Plant(string[] parameters) : base(parameters)
        {
            unitType = UnitTypeEnum.Plant;
        }

        public Plant(Environment gameEnv, int row = -1, int col = -1) : this(row, col)
        {
            gameEnv.IncreaseFood(FOOD_GENERATED_UPON_CREATION);
        }

        public override Unit Create(int row, int col)
        {
            return new Plant(row, col);
        }

        protected override void UpdateVictualRequirements(int numNeighbors)
        {
            FoodRequirement -= (int)(BaselineWaterRequirement * numNeighbors * VICTUAL_BENEFIT_FOR_COMMUNITY);
        }

        public override void Update(Unit[,] grid, Environment gameEnv)
        {
            ApplyCommunityBenefits(grid);
            Respire(gameEnv);
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
    }
}
