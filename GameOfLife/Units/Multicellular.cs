/*
 * Rudy Ariaz
 * Nicole Beri (constructor for loading data from file)
 * January 19, 2019
 * This is the base class for the two multicellular organisms: Animal and Plant.
 * It contains the common features and actions that only these species can do.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    [Serializable]
    abstract class Multicellular : LivingUnit
    {  
        // The size of the neighbourhood checked around the organism to reduce their survival requirements
        private const int EXTENDED_NEIGHBORHOOD_SIZE = 5;
        // The benefits that other multicellular organisms in the neighbourhood convey onto this organism
        protected const double VICTUAL_BENEFIT_FOR_COMMUNITY = 0.05;
        // save the infection resistance that benefits the community value
        protected const double INFECTION_RESISTANCE_BENEFIT_FOR_COMMUNITY = 0.5;

        /// <summary>
        /// Creates a new multicellular organism
        /// </summary>
        /// <param name="type"> The type of the Unit (Animal or Plant) </param>
        /// <param name="senescence"> The maximum age of the unit </param>
        /// <param name="foodRequirement"> The amount of food required per generation to survive </param>
        /// <param name="waterRequirement"> The amount of water required per generation to survive </param>
        /// <param name="gasRequirement"> The amount of gas converted </param>
        /// <param name="inputGas"> The type of gas that is taken in from the environment </param>
        /// <param name="outputGas"> The type of gas that is returned to the environment </param>
        /// <param name="idealTemperature"> The ideal temperature of this unit </param>
        /// <param name="infectionResistance"> The amount of infection resistance of this unit </param>
        /// <param name="decompositionValue"> The amount of food the unit returns to the environment after death </param>
        /// <param name="row"> The row of the grid the unit resides in </param>
        /// <param name="col"> The column of the grid the unit resides in </param>
        public Multicellular(Enums.UnitType type, int senescence, int foodRequirement, int waterRequirement, int gasRequirement, 
                             Enums.GasType inputGas, Enums.GasType outputGas, int idealTemperature, 
                             double infectionResistance, double decompositionValue, int row = -1, int col = -1) 
                                    : base(type, 4, senescence, foodRequirement, waterRequirement, gasRequirement, 
                                      inputGas, outputGas, idealTemperature, infectionResistance, decompositionValue, row, col)
        {

        }

        /// <summary>
        /// Constructs a new multicellular organism
        /// </summary>
        /// <remarks> Nicole </remarks>
        /// <param name="parameters"> A unit's saved characteristics -- used with loading </param>
        public Multicellular(string[] parameters) : base(parameters)
        {
        }

        /// <summary>
        /// Calculates and confers the benefits given to the current organism based on the other
        /// multicellular organisms of the same species surrounding it
        /// </summary>
        /// <param name="grid"> The grid of Units in the current state of the simulation </param>
        protected void ApplyCommunityBenefits(Unit[,] grid)
        {
            // Count the number of same species around this Unit
            int numNeighbors = NumberOfSameSpeciesNeighbors(grid);
            // Confer the benefits of lower food requirement and higher infection resistance 
            // given by the community based on the number of same species neighbour it has
            UpdateVictualRequirements(numNeighbors);
            UpdateInfectionResistance(numNeighbors);
        }

        /// <summary>
        /// Updates the victual requirements of this multicellular unit based on its community
        /// </summary>
        /// <param name="grid"> The grid of Units in the current state of the simulation </param>
        protected abstract void UpdateVictualRequirements(int sameSpeciesNeighbors);

        /// <summary>
        /// Updates the infection resistance of this multicellular unit based on its community
        /// </summary>
        /// <param name="sameSpeciesNeighbors"> The number of same species neighbours in this unit's community </param>
        protected void UpdateInfectionResistance(int sameSpeciesNeighbors)
        {
            // Increase the infection resistance of this organism by 0.5 for each same species organism
            InfectionResistance += sameSpeciesNeighbors * INFECTION_RESISTANCE_BENEFIT_FOR_COMMUNITY;
            // Update the maximum infection resistance to always be the highest an organism exhibits
            MaxResistance = Math.Max(InfectionResistance, MaxResistance);
        }

        /// <summary>
        /// Gets the number of neighbors of the same type as this Multicellular
        /// in a 5x5 square centered on the organism.
        /// </summary>
        /// <param name="grid"></param>
        /// <returns> an integer representing the number of neighbours of the same species that this unit has </returns>
        protected int NumberOfSameSpeciesNeighbors(Unit[,] grid)
        {
            // Create a counter to store the number of same species neighbours
            int numNeighbors = 0;
            // Compute the boundaries of the area to check for same species neighbours
            int rowLowerBound = Math.Max(0, Location.r - EXTENDED_NEIGHBORHOOD_SIZE / 2),
                colLowerBound = Math.Max(0, Location.c - EXTENDED_NEIGHBORHOOD_SIZE / 2);
            int rowUpperBound = Math.Min(grid.GetLength(GridHelper.ROW), Location.r + EXTENDED_NEIGHBORHOOD_SIZE / 2 + 1),
                colUpperBound = Math.Min(grid.GetLength(GridHelper.COLUMN), Location.c + EXTENDED_NEIGHBORHOOD_SIZE / 2 + 1);
            // Loop through all rows in the area to be checked to check each grid cell
            for (int i = rowLowerBound; i < rowUpperBound; i++)
            {
                // Loop through all columns in the area to be checked to check each grid cell
                for (int j = colLowerBound; j < colUpperBound; j++)
                {
                    // Check if the current grid cell is in the grid and holds a unit
                    if (grid.InGridBounds(i, j) && grid[i,j] != null)
                    {
                        // Increase the number of same species neighbour in the community
                        // only if the type of the unit in the current grid cell matches the type of the current unit
                        numNeighbors += grid[i, j].GetType() == this.GetType() ? 1 : 0;
                    }
                }
            }
            // Return the number of same species neighbours in the area surrounding this unit
            return numNeighbors;
        }
    }
}
