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
        GameManager manager = new GameManager();
        protected Enums.UnitType toolbarSelection;
        protected const int CELL_SIZE = 25;
        protected const int TOOLBAR_SIZE = 6;

        public GameForm()
        {
            InitializeComponent();
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

        protected
        private void Test_Click(object sender, EventArgs e)
        {
            //Delete
            manager.CreateUnit(0, 0, 0);
            Test.Text = manager.grid[0, 0].ToString();
        }


    }
}
