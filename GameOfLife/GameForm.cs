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
        protected Enums.UnitType toolbarSelection = Enums.UnitType.None;
        protected const int CELL_SIZE = 10;
        protected const int TOOLBAR_SIZE = 6;
        protected const int TOOLBAR_SQUARE_LENGTH = 8;
        protected Rectangle[,] grid;
        protected Rectangle[] toolbar = new Rectangle[TOOLBAR_SIZE];
        protected Color[] toolbarColors;
        protected Rectangle imageDragBox;

        // State variable to differentiate between choosing to erase units and clicking away from the toolbar
        private bool eraseToolSelected = false;

        public GameForm(GameManager manager)
        {
            this.manager = manager;
            InitializeComponent();
            CreateGrid();
            CreateToolbar();
            imageDragBox = new Rectangle(0, 0, CELL_SIZE, CELL_SIZE);
        }

        private void CreateToolbar()
        {
            for (int i = 0; i < TOOLBAR_SIZE; i++)
            {
                // x, y, width, height
                toolbar[i] = new Rectangle(TOOLBAR_SQUARE_LENGTH * TOOLBAR_SQUARE_LENGTH * i, 
                                            ClientSize.Height - TOOLBAR_SQUARE_LENGTH * TOOLBAR_SQUARE_LENGTH,
                                            TOOLBAR_SQUARE_LENGTH * TOOLBAR_SQUARE_LENGTH, 
                                            TOOLBAR_SQUARE_LENGTH * TOOLBAR_SQUARE_LENGTH);
                toolbarColors = new Color[] { Color.White, Virus.baselineColor, Cell.baselineColor, Colony.baselineColor, Animal.baselineColor, Plant.baselineColor };
            }
            // lblErase.Location = new Point(toolbar[0].X, toolbar[0].Y - 20);
        }

        /// <summary>
        /// Creates the rectangular UI grid.
        /// </summary>
        private void CreateGrid()
        {
            // TODO: need to refactor to parameratize?
            grid = new Rectangle[manager.GridSize, manager.GetGridSize];
            for (int j = 0; j < grid.GetLength(GridHelper.ROW); j++)
            {
                for (int k = 0; k < grid.GetLength(GridHelper.COLUMN); k++)
                {
                    //CENTER
                    grid[j, k] = new Rectangle(((ClientSize.Width/2) - CELL_SIZE * 5) + CELL_SIZE * j, CELL_SIZE*k, CELL_SIZE, CELL_SIZE);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            //draw the units into the grid
            for (int j = 0; j < grid.GetLength(GridHelper.ROW); j++)
            {
                for (int k = 0; k < grid.GetLength(GridHelper.COLUMN); k++)
                {
                    //potentially refactor later
                    Color c = Color.White;
                    if (manager.GetUnit(j, k) != null)
                    {
                        switch (manager.GetUnit(j, k).GetType().Name)
                        {
                            case nameof(Enums.UnitType.Virus):
                                c = Virus.baselineColor;
                                break;
                            case nameof(Enums.UnitType.Plant):
                                c = Plant.baselineColor;
                                break;
                            case nameof(Enums.UnitType.Colony):
                                c = Colony.baselineColor;
                                break;
                            case nameof(Enums.UnitType.Cell):
                                c = Cell.baselineColor;
                                break;
                            case nameof(Enums.UnitType.Animal):
                                c = Animal.baselineColor;
                                break;
                        }
                    }
                    SolidBrush brush = new SolidBrush(c);
                    e.Graphics.FillRectangle(brush, grid[j, k]);
                    brush.Dispose();
                    e.Graphics.DrawRectangle(new Pen(Color.Black, 1), grid[j, k]);
                }
            }

            //draw toolbar
            for (int i = 0; i < TOOLBAR_SIZE; i++)
            {
                e.Graphics.FillRectangle(new SolidBrush(toolbarColors[i]), toolbar[i]);
                e.Graphics.DrawRectangle(new Pen(Color.Black, 1), toolbar[i]);
            }

            //draw 'color' cursor
            if (eraseToolSelected)
            {
                e.Graphics.FillRectangle(new SolidBrush(System.Drawing.Color.White), imageDragBox);
            }
            else if (toolbarSelection != Enums.UnitType.None)
            {
                int i = 0;
                foreach (Enums.UnitType type in Enum.GetValues(typeof(Enums.UnitType)))
                {
                    if (toolbarSelection == type)
                    {
                        e.Graphics.FillRectangle(new SolidBrush(toolbarColors[i]), imageDragBox);
                    }
                    ++i;
                }
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

        protected void tmrGeneration_Tick(object sender, EventArgs e)
        {
            manager.NextGeneration();
        }

        protected void tmrRefresh_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        protected void GameForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (toolbarSelection != Enums.UnitType.None || eraseToolSelected)
            {
                //MAY NEED TO FIX LOCATION ACCURACY =
                imageDragBox.Location = new Point(e.Location.X - CELL_SIZE / 4, e.Location.Y - CELL_SIZE / 4);
            }
        }

        protected virtual void GameForm_MouseDown(object sender, MouseEventArgs e)
        {
            // Only attempt to interact with the grid if toolbar selection was made
            if (toolbarSelection != Enums.UnitType.None || eraseToolSelected)
            {
                for (int j = 0; j < grid.GetLength(GridHelper.ROW); j++)
                {
                    for (int k = 0; k < grid.GetLength(GridHelper.COLUMN); k++)
                    {
                        if (grid[j, k].Contains(e.Location))
                        {
                            //CASE 1: user is trying to erase a unit at the clicked location
                            if (manager.GetUnit(j,k) != null && eraseToolSelected)
                            {
                                manager.KillUnit(j, k);
                            }
                            
                            // NOT ACTUALLY CODE JUST PREVENTING CRASHING FOR NOW
                   //         if (eraseToolSelected)
                     //       {
                       //         return;
                         //   }
                            // CASE 2: user is trying to create a new unit
                            manager.CreateUnit(j, k, toolbarSelection);
                            return;
                        }
                    }
                }
            }
            // Otherwise, check for a selection in the toolbar
            for (int i = 0; i < TOOLBAR_SIZE; i++)
            {
                if (toolbar[i].Contains(e.Location))
                {
                    // Only hide the cursor if it is currently visible (not already hidden due to a previous unit choice)
                    // since the number of calls to Hide() and Show() must be balanced (calls are counted)
                    if (toolbarSelection == Enums.UnitType.None)
                    {
                        Cursor.Hide();
                    }
                    // Save the new Unit that the user selected
                    toolbarSelection = (Enums.UnitType)i;
                    // Record if the user selected the erase tool (used for error checking)
                    if (toolbarSelection == Enums.UnitType.None)
                    {
                        eraseToolSelected = true;
                    }
                    // Store the current location for a new 'colored' cursor
                    imageDragBox.Location = e.Location;
                    // Stop processing possible mouse down cases
                    return;
                }
            }
            // Show the cursor if it is currently hidden (user has a currently selected Unit)
            if (toolbarSelection != Enums.UnitType.None || eraseToolSelected)
            {
                Cursor.Show();
            }
            // User did not click grid nor a unit in toolbar
            toolbarSelection = Enums.UnitType.None;
            eraseToolSelected = false;
            Refresh();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            manager.SaveState();
        }
    }
}
