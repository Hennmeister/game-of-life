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

        public static bool EvaluateIndependentPredicate(double probability)
        {
            double randomNumber = rng.NextDouble();
            return randomNumber < probability;
        }

        // Returns an object corresponding to the probability that evaluates true
        // Keys must be unique, values in ascending order
        public static int EvaluateDependentPredicate(double[] probabilities)
        {
            double randomNumber = rng.NextDouble();
            int matchingIndex = 0;
            for(int i = 0; i < probabilities.Length; i++)
            {
                if(randomNumber < probabilities[i])
                {
                    matchingIndex = i;
                    break;
                }
            }
            return matchingIndex;
        }

        public static int RandomInteger(int inclusiveLowerBound, int inclusiveUpperBound)
        {
            return rng.Next(inclusiveLowerBound, inclusiveUpperBound + 1);
        }
    }
}
