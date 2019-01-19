using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GameOfLife
{
    static class Datastore
    {
        private const string STATES_DIRECTORY_SUFFIX = @"\PastStates";
        private static bool generalStatesDirectoryExists;
        private static readonly string generalStatesDirectoryPath =
            Directory.GetCurrentDirectory() + STATES_DIRECTORY_SUFFIX;

        public static void SaveState(State state)
        {
            string stateDirectoryPath = generalStatesDirectoryPath + $@"\State-{ state.CurrentID }";
            CreateCurrentStateDirectory(state, stateDirectoryPath);
            SaveGeneralInformation(state, stateDirectoryPath);
            SaveEnvironmentalParameters(state, stateDirectoryPath);
        }

        private static void SaveEnvironmentalParameters(State state, string statePath)
        {
            string envPath = statePath + @"\EnvironmentalParameters.txt";
            using (StreamWriter envFile = new StreamWriter(envPath))
            {
                // Save environment type
                // TODO: check if this displays properly 
                envFile.WriteLine(state.EnvironmentType);

                // Save atmospheric parameters
                envFile.WriteLine(state.CarbonDioxideLevel);
                envFile.WriteLine(state.OxygenLevel);

                // Save default food/water parameters
                envFile.WriteLine(state.DefaultFood);
                envFile.WriteLine(state.DefaultWater);

                // Save food/water parameters
                envFile.WriteLine(state.FoodAvailability);
                envFile.WriteLine(state.WaterAvailability);

                // Save temperature
                envFile.WriteLine(state.Temperature);

                // Save event parameters
                envFile.WriteLine(state.EnvironmentalEventOccurs);
                envFile.WriteLine(state.EventGenerationsLeft);
            }
        }

        private static void SaveUnit(Unit unit, string unitPath)
        {
            // Append onto the existing units
            using (StreamWriter unitFile = new StreamWriter(unitPath, true))
            {
                // Save location information
                unitFile.WriteLine(unit.Location.r);
                unitFile.WriteLine(unit.Location.c);

                // 
            }
        }

        private static void SaveAllUnits(State state, string statePath)
        {
            string unitPath = statePath + @"\Units.txt";
            // Iterate through the entire unit grid, from top left to bottom right
            for (int i = 0; i < state.UnitGrid.GetLength(GridHelper.ROW); i++)
            {
                for(int j = 0; j < state.UnitGrid.GetLength(GridHelper.COLUMN); j++)
                {
                    // Save each unit
                    SaveUnit(state.UnitGrid[i, j], unitPath);
                }
            }
        }

        /// <summary>
        /// Saves the state's general information in the following format:
        ///     Username
        ///     Generation Counter
        ///     Current Score
        ///     Highest Concurrent Score
        /// </summary>
        /// <param name="state"></param>
        private static void SaveGeneralInformation(State state, string statePath)
        {
            string infoPath = statePath + @"\GeneralInformation.txt";
            using (StreamWriter infoFile = new StreamWriter(infoPath))
            {
                // Write the username
                infoFile.WriteLine(state.Username);

                // Write the generation counter
                infoFile.WriteLine(state.GenerationCounter);

                // Write the scores
                infoFile.WriteLine(state.CurrentScore);
                infoFile.WriteLine(state.HighestConcurrentScore);
            }

        }

        public static State LoadState(State state) { return state; }

        public static Dictionary<int, string> LoadHighScores() { return new Dictionary<int, string>(); }


        /// <summary>
        /// Creates a directory within the general state directory to 
        /// store the current state.
        /// </summary>
        /// <param name="state"> The state to store. </param>
        private static void CreateCurrentStateDirectory(State state, string statePath)
        {
            CreateGeneralStateDirectory();
            Directory.CreateDirectory(statePath);
        }

        /// <summary>
        /// Creates a directory to store any state of the game, if such
        /// a directory does not already exist. The directory has multiple
        /// child directories, one for each state. The directory path is 
        /// the solution path with "/PastStates" appended to it.
        /// </summary>
        /// <remarks>
        /// To be called whenever part of the state is saved.
        /// </remarks>
        private static void CreateGeneralStateDirectory()
        {
            if (!generalStatesDirectoryExists)
            {
                Directory.CreateDirectory(generalStatesDirectoryPath);
                generalStatesDirectoryExists = true;
            }
        }
    }
}
