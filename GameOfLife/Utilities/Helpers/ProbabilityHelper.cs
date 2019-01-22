/*
 * Rudy Ariaz
 * January 22, 2019
 * ProbabilityHelper static class provides abstraction to probabilistically determine whether
 * an event occurs or not, and to get random integers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    static class ProbabilityHelper
    {
        // Random number generator for probabilistic evaluation
        private static Random rng = new Random();

        /// <summary>
        /// Evaluates whether an event occurs or not, given the probability for it to occur.
        /// </summary>
        /// <param name="probability">The probability of the event occurring, in the interval [0, 1].</param>
        /// <returns>True if the event occurs probabilistically, false otherwise.</returns>
        public static bool EvaluateIndependentPredicate(double probability)
        {
            // Get a random real number in the interval [0, 1)
            double randomNumber = rng.NextDouble();
            // Check if the random number if lower than or equal to the probability.
            // This occurs with probability "probability".
            return randomNumber <= probability;
        }
        

        /// <summary>
        /// Given an array of probabilities of different dependent events, probabilistically
        /// evaluate which of the event occurs.
        /// </summary>
        /// <param name="probabilities">An array of cumulative probabilities, 
        /// each in the interval [0, 1]. The probabilities must be sorted in ascending order.</param>
        /// <returns>An index in the interval [0, length of probabilities) that represents
        /// the event that evaluated as being true.</returns>
        public static int EvaluateDependentPredicate(double[] probabilities)
        {
            // Get a random real number in the interval [0, 1)
            double randomNumber = rng.NextDouble();
            // Will store the index of the chosen event
            int matchingIndex = 0;
            // Iterate through all the probabilities
            for(int i = 0; i < probabilities.Length; i++)
            {
                // Check if the random number is lower than or equal to the current cumulative probability
                if(randomNumber <= probabilities[i])
                {
                    // Set the index of the chosen event to the current index
                    matchingIndex = i;
                    // Stop searching for a true event
                    break;
                }
            }
            // Return the index of the 
            return matchingIndex;
        }

        /// <summary>
        /// Generates a random integer in the inclusive interval between 2 given endpoints.
        /// </summary>
        /// <param name="inclusiveLowerBound">The inclusive lower bound of the integer to be generated.</param>
        /// <param name="inclusiveUpperBound">The inclusive upper bound of the integer to be generated./param>
        /// <returns>A random integer in the interval [inclusiveLowerBound, inclusiveUpperBound].</returns>
        public static int RandomInteger(int inclusiveLowerBound, int inclusiveUpperBound)
        {
            // Return the random integer. inclusiveUpperBound + 1 is used since Next() uses an exclusive
            // upper bound
            return rng.Next(inclusiveLowerBound, inclusiveUpperBound + 1);
        }
    }
}
