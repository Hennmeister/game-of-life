/*
 * Rudy Ariaz
 * January 22, 2019
 * Calculates the upper and lower bounds for environment parameters
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    static class EnvironmentHelper
    {
        /// <summary>
        /// Calculates the upper bound of a given parameter
        /// </summary>
        /// <param name="param">The value of the parameter for which to calculate the upper bound</param>
        /// <returns>The upper bound</returns>
        public static int EnvParamHighBound(double param)
        {
            return (int)(1.1 * param);
        }

        /// <summary>
        /// Calculates the lower bound of a given parameter
        /// </summary>
        /// <param name="param">The value of the parameter for which to calculate the lower boun</param>
        /// <returns>The lower bound</returns>
        public static int EnvParamLowBound(double param)
        {
            return (int)(0.9 * param);
        }
    }
}
