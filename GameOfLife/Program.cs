/*
 * Rudy Ariaz 
 * January 22, 2019
 * Creates the directories required by the application and creates the start form
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Initialize the states directory
            Datastore.CreateGeneralStateDirectory();
            // Initialize the scores directory
            Datastore.CreateScoresDirectory();
            //creates the application's game manager
            Application.Run(new StartForm(new GameManager()));
        }
    }
}
