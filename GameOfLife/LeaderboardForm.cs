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
        private GameManager manger;
        public LeaderboardForm(GameManager manager)
        {           
            this.manger = manager;
            InitializeComponent();
        }

        private void DisplayScores()
        {
            //LOAD HIGH SCORES
        }

        private void SelectScoreState()
        {
            //LOAD A STATE ASSOCIATED WITH A HIGH SCORE
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
