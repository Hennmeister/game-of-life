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
        private const string STATES_SUFFIX = "/PastStates";
        public static void SaveState(State stateToSave) { }
        public static State LoadState(State toLoad) { }
        public static Tuple LoadHighScores() { }
        // Checks if the state folder already exists
        private static void CheckDirectoryExists()
        {
            // Check
            if(File.Exists(Directory.GetCurrentDirectory() + STATES_SUFFIX))
            {

            }
        }
    }
}
