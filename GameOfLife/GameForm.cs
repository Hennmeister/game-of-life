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
        protected Rectangle[,] grid;
        protected Rectangle[] toolbar = new Rectangle[TOOLBAR_SIZE];

        
        public GameForm(GameManager manager)
        {
            InitializeComponent();
            this.manager = manager;
            CreateGrid();
        }

        private void CreateToolbar()
        {
            for (int i = 0; i < TOOLBAR_SIZE; i++)
            {
                toolbar[i] = new Rectangle(ClientSize.Width - CELL_SIZE, CELL_SIZE * i, CELL_SIZE, CELL_SIZE);
            }
        }

        /// <summary>
        /// Creates the rectangular UI grid.
        /// </summary>
        private void CreateGrid()
        {
            // TODO: need to refactor to parameratize?
            grid = new Rectangle[50, 50];
            for(int j = 0; j < grid.GetLength(0); j++)
            {
                for(int k = 0; k < grid.GetLength(1); k++)
                {
                    grid[j, k] = new Rectangle();
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            for (int j = 0; j < grid.GetLength(0); j++)
            {
                for (int k = 0; k < grid.GetLength(1); k++)
                {
                    SolidBrush brush = new SolidBrush(manager.GetUnit(j, k).BaselineColor);
                    e.Graphics.FillRectangle(brush, grid[j, k]);
                    brush.Dispose();
                }
            }
            //hide cursor and draw box instead
            for(int i = 0; i < TOOLBAR_SIZE; i++)
            {
                e.Graphics.DrawImage(Enums.UnitType, toolbar[i]);
            }
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

        private void tmrGeneration_Tick(object sender, EventArgs e)
        {
            manager.NextGeneration();
            Refresh();
        }
    }
}
