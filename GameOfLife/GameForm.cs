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
    public partial class GameForm : Form
    {
        //store game actions and data
        GameManager manager;
        private bool isPaused = true;
        private Enums.GameMode gameMode;
        private Enums.UnitType toolbarSelection = Enums.UnitType.None;
        private const int CELL_SIZE = 10;
        private const int TOOLBAR_SIZE = 6;
        private const int TOOLBAR_SQUARE_LENGTH = 8;
        private Rectangle[,] grid = new Rectangle[50, 50];
        private Rectangle[] toolbar = new Rectangle[TOOLBAR_SIZE];
        private Color[] toolbarColors;
        private Rectangle imageDragBox;

        // State variable to differentiate between choosing to erase units and clicking away from the toolbar
        private bool eraseToolSelected = false;

        public GameForm(GameManager manager, Enums.GameMode gameMode)
        {
            this.gameMode = gameMode;
            this.manager = manager;
            InitializeComponent();
            CreateGrid();
            CreateToolbar();
            imageDragBox = new Rectangle(0, 0, CELL_SIZE, CELL_SIZE);
            UpdateDisplayedParameters();
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
                    // Set initial grid colour to white to represent no unit
                    Color c = Color.White;
                    // Check if for a unit in this grid cell that needs to be drawn
                    if (manager.GetUnit(j, k) != null)
                    {
                        // Determine what type of unit it is to get its corresponding colour
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
                    // Fill the grid with the colour of empty space or the unit as previously determined
                    SolidBrush brush = new SolidBrush(c);
                    e.Graphics.FillRectangle(brush, grid[j, k]);
                    brush.Dispose();
                    // Draw the rectangle around the grid
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

        public void UpdateDisplayedParameters()
        {
            DisplayEnvironmentalParameters();
            DisplayGenerationNumber();
            DisplayCurrentScore();
            DisplayConcurrentHighScore();
        }
        protected void DisplayEnvironmentalParameters()
        {
            lblEnvParams.Text = "Water Availability: " + manager.WaterAvailability.ToString() + "\r\n" + "Food Availability: "
                + manager.FoodAvailability.ToString() +"\r\n" + "Temperature: " + manager.Temperature.ToString() +"\r\n" 
                + "Carbon Dioxide Level: " + manager.CarbonDioxideLevel.ToString() + "\r\n" + "Oxygen Level: " + manager.OxygenLevel.ToString();
        }

        protected void DisplayGenerationNumber()
        {
            lblGenNum.Text = "Generation: " + manager.GenerationCounter.ToString();
        }

        protected void DisplayCurrentScore()
        {
            lblCurrScore.Text = "Score: " + manager.CurrentScore.ToString();
        }

        protected void DisplayConcurrentHighScore()
        {
            lblHighestConcurrentScore.Text = "Highest Concurrent Score: " + manager.HighestConcurrentScore.ToString();
        }

        protected void tmrGeneration_Tick(object sender, EventArgs e)
        {
            manager.NextGeneration();
            UpdateDisplayedParameters();
        }

        protected void tmrRefresh_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void GameForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (toolbarSelection != Enums.UnitType.None || eraseToolSelected)
            {
                //MAY NEED TO FIX LOCATION ACCURACY =
                imageDragBox.Location = new Point(e.Location.X - CELL_SIZE / 4, e.Location.Y - CELL_SIZE / 4);
            }
        }

        private void GameForm_MouseDown(object sender, MouseEventArgs e)
        {
            // Only attempt to interact with the grid if toolbar selection was made
            if (toolbarSelection != Enums.UnitType.None || eraseToolSelected)
            {
                // Loop through all rows in the grid to see if the user clicked in this one
                for (int j = 0; j < grid.GetLength(GridHelper.ROW); j++)
                {
                    // Loop through all columns in the grid to see if the user clicked in this one
                    for (int k = 0; k < grid.GetLength(GridHelper.COLUMN); k++)
                    {
                        // Check if the user clicked the current grid cell to process an action here
                        if (grid[j, k].Contains(e.Location))
                        {
                            if (!isPaused)
                            {
                                MessageBox.Show("Pause game to interact with board");
                                continue;
                            }
                            //CASE 1: user is trying to erase a unit at the clicked location
                            if (manager.GetUnit(j, k) != null && eraseToolSelected)
                            {
                                manager.KillUnit(j, k);
                            }
                            // CASE 2: user is trying to create a new unit
                            else
                            {
                                manager.CreateUnit(j, k, toolbarSelection);
                            }
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
                    else
                    {
                        eraseToolSelected = false;
                    }
                    // Store the current location for a new 'colored' cursor
                    imageDragBox.Location = e.Location;
                    // Stop processing possible mouse down cases
                    return;
                }
            }
            // Show the cursor if it is currently hidden (user has something currently selected)
            if (toolbarSelection != Enums.UnitType.None || eraseToolSelected)
            {
                Cursor.Show();
            }
            // User did not click grid nor a unit in toolbar
            toolbarSelection = Enums.UnitType.None;
            eraseToolSelected = false;
            Refresh();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (isPaused)
            {
                tmrGeneration.Enabled = true;
                isPaused = false;
                btnStart.Text = "Pause";
            }
            else
            {
                tmrGeneration.Enabled = false;
                isPaused = true;
                btnStart.Text = "Unpause";
            }
        }
    }
}
