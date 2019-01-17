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
        private const string STATES_DIRECTORY_SUFFIX = "/PastStates";
        private static bool stateDirectoryExists;
        public static void SaveState(State stateToSave) { }
        public static State LoadState(State toLoad) { }
        public static Tuple LoadHighScores() { }
        // Creates a state directory
        private static void CreateStateDirectory()
        {
            string solutionPath = Directory.GetCurrentDirectory();
            Directory.CreateDirectory(solutionPath + STATES_DIRECTORY_SUFFIX);
        }
    }
}
