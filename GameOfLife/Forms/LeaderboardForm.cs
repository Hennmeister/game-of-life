/*
 * Rudy Ariaz & Henning Lindig
 * Januray 22, 2019
 * Displays the highest scores and allows the user to return to the main menu
 */ 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class LeaderboardForm : Form
    {
        //Stores the labels used to display scores
        private Label[] scoreLabels;
        //stores the game actions and data
        private GameManager manager;

        /// <summary>
        /// Initializes the leaderboard form
        /// </summary>
        /// <param name="manager"> The GameManager that manages the state of the simulation </param>
        public LeaderboardForm(GameManager manager)
        {
            InitializeComponent();
            // Store the manager 
            this.manager = manager;
            // Display the scores on the Leaderboard form
            StoreScoreLabels();
            DisplayScores();
        }

        /// <summary>
        /// Initializes the score labels
        /// </summary>
        private void StoreScoreLabels()
        {
            scoreLabels = new Label[] { lblScore1, lblScore2, lblScore3, lblScore4, lblScore5 };
        }
        
        /// <summary>
        /// Display the highest recorded concurrent scores
        /// </summary>
        private void DisplayScores()
        {
            // Get all the scores
            List<KeyValuePair<string, int>> allScores = Datastore.GetAllHighestConcurrentScores();
            // Sort the scores in descending order, and only select the top 5
            var sortedScores =
                (from score
                in allScores
                orderby score.Value
                descending
                select score).Take(5);
            // Display the scores
            int curScoreLabel = 0;
            foreach(var score in sortedScores)
            {
                // Go to the next score label while populating the text of this one
                scoreLabels[curScoreLabel++].Text = $"{ score.Key }: { score.Value }";
            }
        }

        /// <summary>
        /// Return to the main menu
        /// </summary>
        private void btnExit_Click(object sender, EventArgs e)
        {
            //Create and show a start form and close the leaderboard form
            StartForm startForm = new StartForm(manager);
            startForm.ShowDialog();
            this.Close();
        }
    }
}
