// rudy
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    abstract class Multicellular : LivingUnit
    {  
        private const int EXTENDED_NEIGHBORHOOD_SIZE = 5;
        protected const double VICTUAL_BENEFIT_FOR_COMMUNITY = 0.05;
        protected const double INFECTION_RESISTANCE_BENEFIT_FOR_COMMUNITY = 0.5;

        public Multicellular(int senescence, int foodRequirement, int waterRequirement, int gasRequirement, 
                             Enums.GasType inputGas, Enums.GasType outputGas, int idealTemperature, 
                             double infectionResistance, double decompositionValue, int row = -1, int col = -1) 
                                    : base(4, senescence, foodRequirement, waterRequirement, gasRequirement, 
                                      inputGas, outputGas, idealTemperature, infectionResistance, decompositionValue, row, col)
        {

        }

        public Multicellular(string[] parameters) : base(parameters)
        {

        }

        protected void ApplyCommunityBenefits(Unit[,] grid)
        {
            int numNeighbors = NumberOfSameSpeciesNeighbors(grid);
            UpdateVictualRequirements(numNeighbors);
            UpdateInfectionResistance(numNeighbors);

        }

        /// <summary>
        /// Updates the victu
        /// </summary>
        /// <param name="grid"></param>
        protected abstract void UpdateVictualRequirements(int sameSpeciesNeighbors);

        protected void UpdateInfectionResistance(int sameSpeciesNeighbors)
        {
            InfectionResistance += sameSpeciesNeighbors * INFECTION_RESISTANCE_BENEFIT_FOR_COMMUNITY;
        }

        /// <summary>
        /// Gets the number of neighbors of the same type as this Multicellular
        /// in a 5x5 square centered on the organism.
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        protected int NumberOfSameSpeciesNeighbors(Unit[,] grid)
        {
            int numNeighbors = 0;
            int rowLowerBound = Math.Max(0, Location.r - EXTENDED_NEIGHBORHOOD_SIZE / 2),
                colLowerBound = Math.Max(0, Location.c - EXTENDED_NEIGHBORHOOD_SIZE / 2);
            int rowUpperBound = Math.Min(grid.GetLength(GridHelper.ROW), Location.r + EXTENDED_NEIGHBORHOOD_SIZE / 2 + 1),
                colUpperBound = Math.Min(grid.GetLength(GridHelper.COLUMN), Location.c + EXTENDED_NEIGHBORHOOD_SIZE / 2 + 1);
            for(int i = rowLowerBound; i < rowUpperBound; i++)
            {
                for(int j = colLowerBound; j < colUpperBound; j++)
                {
                    if(grid.InGridBounds(i, j) && grid[i,j] != null)
                    {
                        numNeighbors += grid[i, j].GetType() == this.GetType() ? 1 : 0;
                    }
                }
            }
            return numNeighbors;
        }

        
    }
}
