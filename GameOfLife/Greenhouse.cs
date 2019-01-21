using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    [Serializable]
    class Greenhouse : Environment
    {
        /// <summary>
        /// Create a Greenhouse with its unique environmental parameters for the simulation's environment
        /// </summary>
        public Greenhouse() : base(3000, 50000, 25, 75, 35, 30)
        {
            // (Nicole) assign the specific environment type
            environmentType = EnvironmentTypeEnum.Greenhouse;
        }

        /// <summary>
        /// Enacts the Greenhouse's unique event of a caretaker coming in
        /// </summary>
        protected override void EnvironmentalEvent(Unit[,] units)
        {
            // Water availability increases by 5%
            WaterAvailability += 0.5 * WaterAvailability;
            // Loop through the all rows of the grid to remove all infected plants
            for (int i = 0; i < units.GetLength(GridHelper.ROW); i++)
            {
                // Loop through the all columns of the grid to remove all infected plants
                for (int j = 0; j < units.GetLength(GridHelper.COLUMN); j++)
                {
                    // Check if an infected plant is inhabiting the current grid cell
                    if (units[i,j] is Plant && (units[i, j] as LivingUnit).Infected)
                    {
                        // Any infected plant units are removed
                        units[i, j].Die(units, this);
                    }
                }
            }
        }
    }
}
