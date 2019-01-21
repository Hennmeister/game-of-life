using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    static class EnvironmentFactory
    {
        public static Environment CreateEnvironment(Enums.EnvironmentType environmentType)
        {
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
