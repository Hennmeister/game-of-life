// Nicole --> implemented actual saving on top of Rudy's saving framework. 
// Nicole --> implemented file loading 
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
        public static string GeneralStatesDirectoryPath { get; } = 
            Directory.GetCurrentDirectory() + STATES_DIRECTORY_SUFFIX;
        

        public static void SaveState(State state, string sessionName)
        {
            string stateDirectoryPath = GeneralStatesDirectoryPath + $@"\{sessionName}";
            CreateCurrentStateDirectory(state, stateDirectoryPath);
            SaveGeneralInformation(state, stateDirectoryPath);
            SaveEnvironmentalParameters(state, stateDirectoryPath);
            SaveAllUnits(state, stateDirectoryPath);
        }

        // (Nicole) loading state based on current state ID
        public static void LoadState(State state, string statePath)
        {
            LoadEnvironmentalParameters(state, statePath);
            LoadAllUnits(state, statePath);
            LoadGeneralInformation(state, statePath);
        }

        private static void SaveEnvironmentalParameters(State state, string statePath)
        {
            string envPath = statePath + @"\EnvironmentalParameters.txt";
            using (StreamWriter envFile = new StreamWriter(envPath))
            {
                // Save environment type
                // TODO: check if this displays properly 
                envFile.WriteLine((int)state.EnvironmentType);

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
                //envFile.WriteLine(state.EnvironmentalEventOccurs); // (Nicole) cannot save a value returned by a function, can only save properties
                envFile.WriteLine(state.EventGenerationsLeft);
            }
        }

        // (Nicole) reading environmental parameters
        private static void LoadEnvironmentalParameters (State state, string statePath)
        {
            string envPath = statePath + @"\EnvironmentalParameters.txt";
            using (StreamReader envFile = new StreamReader(envPath))
            {
                // temporary variable for reading
                int tempInt;
                // Read environment type
                if (int.TryParse(envFile.ReadLine(), out tempInt))
                {
                    state.EnvironmentType = (EnvironmentTypeEnum)tempInt;
                }

                // Read atmospheric parameters
                if (int.TryParse(envFile.ReadLine(), out tempInt))
                {
                    state.CarbonDioxideLevel = tempInt;
                }

                if (int.TryParse(envFile.ReadLine(), out tempInt))
                {
                    state.OxygenLevel = tempInt;
                }

                // Read default food/water parameters
                double tempDouble;
                if (double.TryParse(envFile.ReadLine(), out tempDouble))
                {
                    state.DefaultFood = tempDouble;
                }

                if (int.TryParse(envFile.ReadLine(), out tempInt))
                {
                    state.DefaultWater = tempInt;
                }

                // Read food/water parameters
                if (double.TryParse(envFile.ReadLine(), out tempDouble))
                {
                    state.FoodAvailability = tempDouble;
                }
                if (double.TryParse(envFile.ReadLine(), out tempDouble))
                {
                    state.WaterAvailability = tempDouble;
                }

                // Read temperature
                if (int.TryParse(envFile.ReadLine(), out tempInt))
                {
                    state.Temperature = tempInt;
                }

                // Read event parameters
                if (int.TryParse(envFile.ReadLine(), out tempInt))
                {
                    state.EventGenerationsLeft = tempInt;
                }
            }
        }

        // (Nicole) refactored code so the file only opens once
        private static void SaveAllUnits(State state, string statePath)
        {
            string unitPath = statePath + @"\Units.txt";
            // Iterate through the entire unit grid, from top left to bottom right
            using (StreamWriter unitFile = new StreamWriter(unitPath, false))
            {
                for (int i = 0; i < state.UnitGrid.GetLength(GridHelper.ROW); i++)
                {
                    for (int j = 0; j < state.UnitGrid.GetLength(GridHelper.COLUMN); j++)
                    {
                        // Save each unit
                        Unit currUnit = state.UnitGrid[i, j];
                        if (currUnit != null)
                        {
                            unitFile.WriteLine(currUnit);
                        }
                    }
                }
            }
        }

        // (Nicole) load all of the units from the file
        private static void LoadAllUnits(State state, string statePath)
        { 
            string unitPath = statePath + @"\Units.txt";
            // open the file
            using (StreamReader unitFile = new StreamReader(unitPath))
            {
                // variable to store what is read from the file
                string unitString;
                // iterate through the file and save what it reads until ReadLine returns null
                do
                {
                    unitString = unitFile.ReadLine();
                    // check that the unitString is not null
                    if (unitString != null)
                    {
                        // check that there is a unit and put it in the grid
                        Unit newUnit = LoadUnit(unitString);
                        if (newUnit != null)
                        {
                            int r = newUnit.Location.r;
                            int c = newUnit.Location.c;
                            if (r != -1 && c != -1)
                            {
                                state.UnitGrid[r, c] = newUnit;
                            }
                        }
                    }
                } while (unitString != null);
            }
        }

        // (Nicole) load unit
        private static Unit LoadUnit(string unitString)
        {
            // split the string that it reads
            string[] unitArray = unitString.Split(';');

            // retrieve unitType 
            int u;
            int.TryParse(unitArray[0], out u);
            Enums.UnitType unitType = (Enums.UnitType)u;

            return UnitFactory.CreateUnit(unitType, unitArray);
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
                // Write the username. If username is null, save it is an empty string.
                infoFile.WriteLine(state.Username);

                // Write the generation counter
                infoFile.WriteLine(state.GenerationCounter);

                // Write the scores
                infoFile.WriteLine(state.CurrentScore);
                infoFile.WriteLine(state.HighestConcurrentScore);
            }

        }

        // (Nicole) load general information
        private static void LoadGeneralInformation(State state, string statePath)
        {
            string infoPath = statePath + @"\GeneralInformation.txt";
            // open the file
            using (StreamReader infoFile = new StreamReader(infoPath))
            {
                // read username
                state.Username = infoFile.ReadLine();

                int tempInt;
                // read generation counter
                if (int.TryParse(infoFile.ReadLine(), out tempInt))
                {
                    state.GenerationCounter = tempInt;
                }

                // read current score
                if (int.TryParse(infoFile.ReadLine(), out tempInt))
                {
                    state.CurrentScore = tempInt;
                }

                // read highest concurrent score
                if (int.TryParse(infoFile.ReadLine(), out tempInt))
                {
                    state.HighestConcurrentScore = tempInt;
                }
            }
        }

        public static Dictionary<int, string> LoadHighScores() { return new Dictionary<int, string>(); }


        /// <summary>
        /// Creates a directory within the general state directory to 
        /// store the current state.
        /// </summary>
        /// <param name="state"> The state to store. </param>
        private static void CreateCurrentStateDirectory(State state, string statePath)
        {
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
        public static void CreateGeneralStateDirectory()
        {
             Directory.CreateDirectory(GeneralStatesDirectoryPath);
        }


        public static Dictionary<string, int> GetAllHighestConcurrentScores()
        {
            Dictionary<string, int> allScores = new Dictionary<string, int>();
            // Get all states
            string[] allStates = Directory.GetDirectories(GeneralStatesDirectoryPath);
            foreach(string statePath in allStates)
            {
                string infoPath = statePath + @"\GeneralInformation.txt";
                string[] generalInfo = File.ReadAllLines(infoPath);
                // The first line of the file is the username, the last one is the highest concurrent score
                allScores.Add(generalInfo[0], int.Parse(generalInfo[3]));
            }
            return allScores;
        }
    }
}
