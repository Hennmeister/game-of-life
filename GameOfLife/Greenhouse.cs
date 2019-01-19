using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Greenhouse : Environment
    {
        /// <summary>
        /// Create a Greenhouse with its unique environmental parameters for the simulation's environment
        /// </summary>
        public Greenhouse() : base(3000, 50000, 25, 75, 35, 30)
        {
        }

        /// <summary>
        /// Enacts the Greenhouse's unique event of a caretaker coming in
        /// </summary>
        protected override void EnvironmentalEvent(Unit[,] units)
        {
            // Water availability increases by 5%
            WaterAvailability += 0.5 * WaterAvailability;
            // All infected plants are removed
            for (int i = 0; i < units.GetLength(GridHelper.ROW); i++)
            {
                for (int j = 0; j < units.GetLength(GridHelper.COLUMN); j++)
                {
                    // If an infected plant is inhabiting this grid cell,
                    // it is removed from the simulation
                    if (units[i,j] is Plant && units[i, j].Infected)
                    {
                        units[i, j].Die();
                    }
                }
            }
        }
    }
}
