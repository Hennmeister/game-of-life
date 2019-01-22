/*
 * Nicole Beri, Rudy Ariaz, Henning Lindig, Tiffanie Truong
 * January 22, 2019
 * Datastore static class enables for saving and loading of past states and scores. Abstracts
 * data storage functionality from the rest of the game.
 */
using System;
using System.Collections.Generic;
using System.IO;

namespace GameOfLife
{
    static class Datastore
    {
        // The suffix of the path of the general states directory
        private const string STATES_DIRECTORY_SUFFIX = @"\PastStates";
        // The suffix of the path of the scores directory
        private const string SCORES_DIRECTORY_SUFFIX = @"\PastScores";
        // The suffix of the path of the scores file
        private const string SCORES_FILE_SUFFIX = @"\Scores.txt";
        // The path to the general states directory
        public static string GeneralStatesDirectoryPath { get; } = 
            Directory.GetCurrentDirectory() + STATES_DIRECTORY_SUFFIX;
        // The path to the general scores directory
        public static string ScoresDirectoryPath { get; } = 
            Directory.GetCurrentDirectory() + SCORES_DIRECTORY_SUFFIX;

        /// <summary>
        /// Saves a given state under a given name in the past states directory.
        /// </summary>
        /// <remarks>
        /// Author: Rudy Ariaz
        /// </remarks>
        /// <param name="state">The state to save.</param>
        /// <param name="sessionName">The name of the session.</param>
        public static void SaveState(State state, string sessionName)
        {
            // The path of the state to save
            string stateDirectoryPath = GeneralStatesDirectoryPath + $@"\{sessionName}";
            // Create the directory that stores this state 
            stateDirectoryPath = CreateCurrentStateDirectory(state, stateDirectoryPath);
            // Save all general information of the state (including username and generation counter)
            SaveGeneralInformation(state, stateDirectoryPath);
            // Save all parameters of the Environment
            SaveEnvironmentalParameters(state, stateDirectoryPath);
            // Save all of the Units of the state
            SaveAllUnits(state, stateDirectoryPath);
        }
        
        /// <summary>
        /// Loads a state stored in a given state path
        /// </summary>
        /// <remarks>
        /// Author: Nicole Beri
        /// </remarks>
        /// <param name="state">State to load into.</param>
        /// <param name="statePath">The path of the state to load.</param>
        public static void LoadState(State state, string statePath)
        {
            // Load all of the environmental parameters
            LoadEnvironmentalParameters(state, statePath);
            // Load Unit parameters
            LoadAllUnits(state, statePath);
            // Load general information
            LoadGeneralInformation(state, statePath);
        }

        /// <summary>
        /// Saves environmental parameters of a state in a given state directory.
        /// </summary>
        /// <remarks>
        /// Authors: Rudy Ariaz, Nicole Beri
        /// </remarks>
        /// <param name="state">State whose environmental parameters should be stored.</param>
        /// <param name="statePath">Path to the state directory.</param>
        private static void SaveEnvironmentalParameters(State state, string statePath)
        {
            // The path to the Environmental parameters file
            string envPath = statePath + @"\EnvironmentalParameters.txt";
            // Open the Environmental parameters file for writing
            using (StreamWriter envFile = new StreamWriter(envPath))
            {
                // Save Environment type
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
                envFile.WriteLine(state.GameEnvironment.EnvEventOccurring); 
                envFile.WriteLine(state.EventGenerationsLeft);
            }
        }
        
        /// <summary>
        /// Loads Environmental parameters stored in the saved state corresponding to statePath
        /// into the given state.
        /// </summary>
        /// <remarks>
        /// Author: Nicole Beri
        /// </remarks>
        /// <param name="state">State to load parameters into.</param>
        /// <param name="statePath">The path of the saved state.</param>
        private static void LoadEnvironmentalParameters (State state, string statePath)
        {
            // The path to the Environmental parameters file 
            string envPath = statePath + @"\EnvironmentalParameters.txt";
            // Open the Environmental parameters file for reading
            using (StreamReader envFile = new StreamReader(envPath))
            {
                // Temporary variable for reading
                int tempInt;

                // Read environment type
                if (int.TryParse(envFile.ReadLine(), out tempInt))
                {
                    state.EnvironmentType = (Enums.EnvironmentType)tempInt;
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
                if (bool.TryParse(envFile.ReadLine(), out bool eventOccuring))
                {
                    state.GameEnvironment.EnvEventOccurring = eventOccuring;
                }
                
                if (int.TryParse(envFile.ReadLine(), out tempInt))
                {
                    state.EventGenerationsLeft = tempInt;
                }
            }
        }
        
        /// <summary>
        /// Saves all the Units of a given State into the State's directory.
        /// </summary>
        /// <remarks>
        /// Author: Tiffanie Truong
        /// </remarks>
        /// <param name="state">State whose Units should be saved.</param>
        /// <param name="statePath">Path of the State directory.</param>
        private static void SaveAllUnits(State state, string statePath)
        {
            // Path to the Units file of the State
            string unitPath = statePath + @"\Units.txt";
            
            // Open the Units file for writing
            using (StreamWriter unitFile = new StreamWriter(unitPath, false))
            {
                // Iterate through the entire unit grid, from top left to bottom right
                // Iterate from the top row to the bottom row
                for (int i = 0; i < state.UnitGrid.GetLength(GridHelper.ROW); i++)
                {
                    // Iterate from the left row to the top row
                    for (int j = 0; j < state.UnitGrid.GetLength(GridHelper.COLUMN); j++)
                    {
                        // Get the current Unit
                        Unit currUnit = state.UnitGrid[i, j];
                        // If the current Unit is not null, write it to the file
                        if (currUnit != null)
                        {
                            unitFile.WriteLine(currUnit);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        /// Loads all Units of a saved State into the given State of the current simulation.
        /// </summary>
        /// <remarks>
        /// Author: Nicole Beri, Tiffanie Truong
        /// </remarks>
        /// <param name="state"> The State to load Units into.</param>
        /// <param name="statePath"> The path to the saved State's directory.</param>
        private static void LoadAllUnits(State state, string statePath)
        { 
            // The path to the Units file of the saved State
            string unitPath = statePath + @"\Units.txt";
            // Try to load the file Units file for reading
            try {
                using (StreamReader unitFile = new StreamReader(unitPath))
                {
                    // Stores the string representing each Unit
                    string unitString = "";
                    // Iterate through the file and save what is read until ReadLine() returns null (end of file)
                    do
                    {
                        // Read the current line (representing the current Unit)
                        unitString = unitFile.ReadLine();
                        // Check that the unitString is not null
                        if (unitString != null)
                        {
                            // Check that there is a Unit and add it to the grid
                            Unit newUnit = LoadUnit(unitString);
                            // Check if a Unit was created successfully 
                            if (newUnit != null)
                            {
                                // Get the row and column of the loaded Unit
                                int r = newUnit.Location.r;
                                int c = newUnit.Location.c;
                                // Check if the Unit has a valid location
                                if (r != -1 && c != -1)
                                {
                                    // Insert the Unit into the correct location in the State's grid
                                    state.UnitGrid[r, c] = newUnit;
                                }
                            }
                        }
                    } while (unitString != null);
                }
            }
            catch (Exception e)
            {
            }
        }

        /// <summary>
        /// Loads a single Unit represented in a string of parameters. 
        /// </summary>
        /// <remarks>
        /// Author: Nicole Beri
        /// </remarks>
        /// <param name="unitString">A string representation of a Unit, according to the format
        /// described in UnitFileFormat.</param>
        /// <returns>The Unit represented by "unitString", or null if the description is not valid.</returns>
        private static Unit LoadUnit(string unitString)
        {
            // The string representation is semicolon-separated, so split the representation into
            // the various parameters
            string[] unitArray = unitString.Split(';');

            // Stores the unit type 
            int u;
            // Get the unit type
            int.TryParse(unitArray[UnitFileFormat.UNIT_TYPE], out u);
            // Cast the unit type from integer to unit ytpe
            Enums.UnitType unitType = (Enums.UnitType)u;
            // Use the UnitFactory to create the Unit with the given parameters
            return UnitFactory.CreateUnit(unitType, unitArray);
        }

        /// <summary>
        /// Saves the state's general information in the following format:
        ///     Username
        ///     Generation Counter
        ///     Current Score
        ///     Highest Concurrent Score
        /// These are saved in a file in the directory of the State to save.
        /// </summary>
        /// <remarks>
        /// Author: Henning Lindig
        /// </remarks>
        /// <param name="state">State whose given information should be saved.</param>
        /// <param name="statePath">The path of the directory of the State to save.</param>
        private static void SaveGeneralInformation(State state, string statePath)
        {
            // The path to the text file that stores the general information
            string infoPath = statePath + @"\GeneralInformation.txt";
            // Open the general information file for writing (creates it if the file did not exist)
            using (StreamWriter infoFile = new StreamWriter(infoPath))
            {
                // Write the username
                infoFile.WriteLine(state.Username);

                // Write the generation counter
                infoFile.WriteLine(state.GenerationCounter);

                // Write the scores (current cumulative score and highest concurrent score)
                infoFile.WriteLine(state.CurrentScore);
                infoFile.WriteLine(state.HighestConcurrentScore);
            }

        }
        
        /// <summary>
        /// Loads general information of a State saved in statePath into the given State.
        /// </summary>
        /// <remarks>
        /// Author: Nicole Beri
        /// </remarks>
        /// <param name="state">The State to load the general information into.</param>
        /// <param name="statePath">The path of the saved State to load from.</param>
        private static void LoadGeneralInformation(State state, string statePath)
        {
            // Path of the general information file
            string infoPath = statePath + @"\GeneralInformation.txt";
            // Open the general information file for reading
            using (StreamReader infoFile = new StreamReader(infoPath))
            {
                // Read username
                state.Username = infoFile.ReadLine();

                // Temporary integer for reading from the file
                int tempInt;
                // Read generation counter
                if (int.TryParse(infoFile.ReadLine(), out tempInt))
                {
                    state.GenerationCounter = tempInt;
                }

                // Read current score
                if (int.TryParse(infoFile.ReadLine(), out tempInt))
                {
                    state.CurrentScore = tempInt;
                }

                // Read highest concurrent score
                if (int.TryParse(infoFile.ReadLine(), out tempInt))
                {
                    state.HighestConcurrentScore = tempInt;
                }
            }
        }
        
        /// <summary>
        /// Creates a directory within the general PastStates directory to 
        /// store all files associatd with the current State. The directory is named with the given
        /// state path, unless a matching directory already exists, in which case a directory of the same name
        /// with a duplicate suffix is created.
        /// </summary>
        /// <remarks>
        /// Author: Rudy Ariaz    
        /// </remarks>
        /// <example>
        /// If the attempted path to create is "C:\...\PastStates\Example" and it already exists,
        /// "C:\...\PastStates\Example (1)" will be created if it does not exist.
        /// </example>
        /// <param name="state">The State to store.</param>
        /// <param name="statePath">The path allotted for the State storage.</param>
        /// <returns>The path of the subdirectory created.</returns>
        private static string CreateCurrentStateDirectory(State state, string statePath)
        {
            // Check if the State subdirectory does not already exist
            if (!Directory.Exists(statePath))
            {
                // Create the subdirectory
                Directory.CreateDirectory(statePath);
                // Return the state path
                return statePath;
            }
            // Otherwise, need to create a subdirectory with a duplicate marker
            else
            {
                // Start with a duplicate marker of 1
                int duplicateNum = 1;
                // Create the duplicate marker string
                string duplicateSuffix = $" ({duplicateNum})";

                // Increase the duplicate marker number until the path no longer matches an existing path
                while (Directory.Exists(statePath + duplicateNum))
                {
                    // Increase the duplicate marker number
                    duplicateSuffix = $" ({++duplicateNum})";
                }
                // Return the first successful path with duplicate marker
                return statePath + duplicateSuffix;
            }
        }

        /// <summary> 
        /// Creates a directory to store any state of the game, if such
        /// a directory does not already exist. The directory will have multiple
        /// child directories, one for each state. The directory path is 
        /// the solution path with "/PastStates" appended to it.
        /// </summary>
        /// <remarks>
        /// To be called at the start of the game.
        /// Author: Rudy Ariaz
        /// </remarks>
        public static void CreateGeneralStateDirectory()
        {
            // Create the directory path if the directory does not already exist
            Directory.CreateDirectory(GeneralStatesDirectoryPath);
        }

        /// <summary>
        /// Appends a given (highest concurrent) score (associated with a username) to the scores file.
        /// </summary>
        /// <remarks>
        /// Author: Rudy Ariaz
        /// </remarks>
        /// <param name="username">Username associated with the score.</param>
        /// <param name="score">(Highest concurrent) score associated with the username.</param>
        public static void AddScore(string username, int score)
        {
            // Open the scores file for writing, in append mode (since there are existing scores already recorded in the file)
            using(StreamWriter scoresFile = new StreamWriter(ScoresDirectoryPath + SCORES_FILE_SUFFIX, true))
            {
                // Write the username and the score to the file
                scoresFile.WriteLine($"{username};{score}");
            }
        }

        /// <summary>
        /// Creates a directory to store scores (if the directory does not already exists). The path of the directory is the 
        /// path of the solution directory with "\PastScores" appended to it.
        /// </summary>
        /// <remarks>
        /// Called at the start of the program. 
        /// Author: Rudy Ariaz
        /// </remarks>
        public static void CreateScoresDirectory()
        {
            // Create the directory with the correct path, if it does not already exist
            Directory.CreateDirectory(ScoresDirectoryPath);
        }

        /// <summary>
        /// Gets all of the highest concurrent scores stored in the PastScores directory, 
        /// associated with the usernames that achieved thoses scores.
        /// </summary>
        /// <remarks>
        /// Authors: Rudy Ariaz, Henning Lindig
        /// </remarks>
        /// <returns>A list of key-value pairs, each storing a string (username) and an associated
        /// integer (highest concurrent score)</returns>
        public static List<KeyValuePair<string, int>> GetAllHighestConcurrentScores()
        {
            // The list that will store all scores
            List<KeyValuePair<string, int>> allScores = new List<KeyValuePair<string, int>>();
            // Open the scores file for reading
            using (StreamReader scoresFile = new StreamReader(ScoresDirectoryPath + SCORES_FILE_SUFFIX))
            {
                // Will store the current line (current username-score pair)
                string line = "";
                // Iterate through the file, reading until end of file is reached
                while ((line = scoresFile.ReadLine()) != null)
                {
                    // Each line is formatted as username;score, so split the line into the components of the score
                    string[] splitScore = line.Split(';');
                    // Convert the score from a string to an integer
                    int.TryParse(splitScore[1], out int score);
                    // Add the current username-score pair to the list
                    allScores.Add(new KeyValuePair<string, int>(splitScore[0], score));
                }
            }
            // Return the list of scores
            return allScores;
        }
    }
}
