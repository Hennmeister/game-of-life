using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    static class EnvironmentHelper
    {
        public static int EnvParamHighBound(double param)
        {
            return (int)(1.1 * param);
        }
        public static int EnvParamLowBound(double param)
        {
            return (int)(0.9 * param);
        }
    }
}
