using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    static class ProbabilityHelper
    {
        private static Random rng = new Random();

        public static bool Predicate(double probability)
        {
            double randomNumber = rng.NextDouble();
            return randomNumber < probability;
        }
    }
}
