// Tiffanie & Rudy
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Animal : Multicellular
    {
        public static readonly System.Drawing.Color baselineColor = System.Drawing.Color.LightCoral;
        private const int THERMOREGULATION_FOOD = 2;
        private const int THERMOREGULATION_WATER = 1;
        private const int HIBERNATION_GENERATIONS = 3;
        private const double HIBERNATION_START_SCALE_FACTOR = 0.5;
        private const double HIBERNATION_END_SCALE_FACTOR = 2.0;

        private bool NeedToEat { get; set; }
        private bool IsHibernating { get; set; }
        private int HibernationGenerationsLeft { get; set; }

        public Animal(int row = -1, int col = -1) : base(senescence: 32,
                               foodRequirement: 8, waterRequirement: 10,
                               gasRequirement: 8, inputGas: Enums.GasType.Oxygen,
                               outputGas: Enums.GasType.CarbonDioxide, idealTemperature: 30,
                               infectionResistance: 8, decompositionValue: 20, row: row, col: col)
        {

        }

        public override Unit Create(int row, int col)
        {
            return new Animal(row, col);
        }

        public override int DecreaseVictualRequirements(Unit[,] grid)
        {
            throw new NotImplementedException();
        }

        public override int IncreaseVictualRequirements(Unit[,] grid)
        {
            throw new NotImplementedException();
        }

        // TODO: check if that's it
        public override void Update(Unit[,] grid, Environment gameEnv)
        {
            UpdateBasicLivingUnit(grid, gameEnv);
            // Check if the animal is hibernating
            if (IsHibernating)
            {
                HibernationGenerationsLeft--;
                TryWake();
            }

            else
            {
                // If the animal is starving, try to eat a plant
                if (IsStarving(gameEnv))
                {
                    CheckPlantsToEat(grid, gameEnv);
                }

                if (ShouldThermoregulate(gameEnv) && CanThermoregulate(gameEnv))
                {
                    Thermoregulate(gameEnv);
                }
            }
        }
        

        private void CheckPlantsToEat(Unit[,] grid, Environment gameEnv)
        {
            int row = Location.r, col = Location.c;
            foreach(var dir in GridHelper.directions)
            {
                int newRow = row + dir.Item1;
                int newCol = col + dir.Item2;
                if(!grid.InGridBounds(newRow, newCol))
                {
                    continue;
                }
                Unit neighbour = grid[newRow, newCol];
                // Check if the neighbour is a plant
                if(neighbour is Plant && neighbour != null)
                {
                    EatPlant(grid, gameEnv, (Plant)neighbour);
                    break;
                }
            }
        }

        private void EatPlant(Unit[,] grid, Environment gameEnv, Plant toEat)
        {
            NeedToEat = false;
            // Kill the plant
            toEat.Die(grid, gameEnv);
            // Check if the plant is toxic
            if (toEat.IsToxic())
            {
                this.Die(grid, gameEnv);
            }
            Hibernate();
        }

        private void Hibernate()
        {
            IsHibernating = true;
            HibernationGenerationsLeft = HIBERNATION_GENERATIONS;
            ScaleAnimalParameters(HIBERNATION_START_SCALE_FACTOR);


        }
        private void TryWake()
        {
            if(HibernationGenerationsLeft <= 0)
            {
                IsHibernating = false;
                ScaleAnimalParameters(HIBERNATION_END_SCALE_FACTOR);
            }
            
        }

        private void ScaleAnimalParameters(double scaleFactor)
        {
            FoodRequirement = (int)(FoodRequirement * scaleFactor);
            WaterRequirement = (int)(WaterRequirement * scaleFactor);
            GasRequirement = (int)(GasRequirement * scaleFactor);
            IdealTemperature = (int)(IdealTemperature * scaleFactor);
            DecompositionValue = DecompositionValue * scaleFactor;
            InfectionResistance = InfectionResistance * scaleFactor;
        }
        
        public bool IsStarving(Environment gameEnv)
        {
            return gameEnv.FoodAvailability < FoodRequirement * 6;
        }

        private bool ShouldThermoregulate(Environment gameEnv)
        {
            double percentageDifference = 100.0 * Math.Abs(gameEnv.Temperature - IdealTemperature) / (IdealTemperature);
            return percentageDifference >= 5.0;
        }

        private bool CanThermoregulate(Environment gameEnv)
        {
            return gameEnv.FoodAvailability >= THERMOREGULATION_FOOD &&
                   gameEnv.WaterAvailability >= THERMOREGULATION_WATER &&
                   !IsHibernating;
        }

        private void Thermoregulate(Environment gameEnv)
        {
            // Should decrease ideal temperature to adjust to environment
            if(IdealTemperature > gameEnv.Temperature)
            {
                IdealTemperature--;                
            }
            else
            {
                IdealTemperature++;
            }

            Eat(gameEnv, THERMOREGULATION_FOOD);
            Drink(gameEnv, THERMOREGULATION_WATER);
        }

        
    }
}
