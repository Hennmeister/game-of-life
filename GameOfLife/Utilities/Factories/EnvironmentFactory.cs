/*
 * Henning Lindig
 * January 22, 2019
 * Factory for environment objects that creates a child of environment given a type
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    static class EnvironmentFactory
    {
        /// <summary>
        /// Creates a new object that is of the given environment type
        /// </summary>
        /// <param name="environmentType">The type of environment to create</param>
        /// <returns>An environment object of the given type</returns>
        public static Environment CreateEnvironment(Enums.EnvironmentType environmentType)
        {
            //check which environment type is given and create the corresponding type of object
            switch (environmentType)
            {
                case Enums.EnvironmentType.Rainforest:
                    return new Rainforest();
                case Enums.EnvironmentType.Greenhouse:
                    return new Greenhouse();
                case Enums.EnvironmentType.Tundra:
                    return new Tundra();
                case Enums.EnvironmentType.Desert:
                    return new Desert();
                default:
                    return null;
            }
        }
    }
}
