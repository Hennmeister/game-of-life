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
        private Label[] scoreLabels;
        private GameManager manager;

        public LeaderboardForm(GameManager manager)
        {
            this.manager = manager;
            InitializeComponent();
            StoreScoreLabels();
            DisplayScores();
        }

        private void StoreScoreLabels()
        {
            scoreLabels = new Label[] { lblScore1, lblScore2, lblScore3, lblScore4, lblScore5 };
        }

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

        private void btnExit_Click(object sender, EventArgs e)
        {
            StartForm startForm = new StartForm(manager);
            startForm.ShowDialog();
            this.Close();
        }
    }
}
