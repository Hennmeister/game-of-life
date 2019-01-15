// rudy 
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
    public abstract partial class GameForm : Form
    {
        //store game actions and data
        GameManager manager;
        protected Enums.UnitType toolbarSelection;
        protected const int CELL_SIZE = 25;
        protected const int TOOLBAR_SIZE = 6;

        public GameForm(GameManager manager)
        {
            InitializeComponent();
            this.manager = manager;
        }

        private void CreateToolbar()
        {

        }

        private void CreateGrid()
        {

        }

        private void DisplayEnvironment()
        {

        }

        protected void DisplayEnvironmentalParameters()
        {

        }

        protected void DisplayGenerationNumber()
        {

        }

        protected void DisplayCurrentScore()
        {

        }

        protected void DisplayConcurrentHighScore()
        {

        }



        private void Test_Click(object sender, EventArgs e)
        {
            //Delete
            manager.CreateUnit(0, 0, 0);
            Test.Text = manager.grid[0, 0].ToString();
        }


    }
}
