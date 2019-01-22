/*
 * Henning Lindig
 * January 19, 2019
 * This form visually displays the current state of the simulation (all units and environmental parameters).
 * The user interacts with this form to control the simulation.
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
    public partial class GameForm : Form
    {
        //store game actions and data
        GameManager manager;
        //keep track of whether the simulation is paused
        private bool isPaused = true;
        //keep track of what is selected by the user
        private Enums.UnitType toolbarSelection = Enums.UnitType.None;
        //The size the each block in pixels
        private const int BLOCK_SIZE = 10;
        //the length of the toolbar
        private const int TOOLBAR_SIZE = 6;
        //size of the toolbar images in pixels
        private const int TOOLBAR_SQUARE_LENGTH = 8;
        //the grid of rectangles which are used for drawing
        private Rectangle[,] grid = new Rectangle[50, 50];
        //toolbar array to display different selection options
        private Rectangle[] toolbar = new Rectangle[TOOLBAR_SIZE];
        //colors of the selections in the toolbar
        private Color[] toolbarColors;
        //the image used to display the cursor selection
        private Rectangle imageDragBox;

        // State variable to differentiate between choosing to erase units and clicking away from the toolbar
        private bool eraseToolSelected = false;


        /// <summary>
        /// constructor
        /// initializes various components and displays graphics
        /// </summary>
        /// <param name="manager">The simulation's game manaager</param>
        public GameForm(GameManager manager, string username)
        {
            this.manager = manager;
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
            CreateGrid();
            CreateToolbar();
            imageDragBox = new Rectangle(0, 0, BLOCK_SIZE, BLOCK_SIZE);
            UpdateDisplayedParameters();
            // Show the environment in the background
            BackgroundImage = manager.EnvironmentImage;
            BackgroundImageLayout = ImageLayout.Stretch;
            ToggleSavingUIVisibility(shown: false);
            manager.Username = username;
        }

        /// <summary>
        /// Initializes the toolbar's rectangles and colors
        /// </summary>
        private void CreateToolbar()
        {
            //loop through the toolbar rectangles and create a row of rectangles
            for (int i = 0; i < TOOLBAR_SIZE; i++)
            {
                // x, y, width, height
                //increment the x by the size of a toolbar rectangle every iteration
                toolbar[i] = new Rectangle(TOOLBAR_SQUARE_LENGTH * TOOLBAR_SQUARE_LENGTH * i, 
                                            ClientSize.Height - TOOLBAR_SQUARE_LENGTH * TOOLBAR_SQUARE_LENGTH,
                                            TOOLBAR_SQUARE_LENGTH * TOOLBAR_SQUARE_LENGTH, 
                                            TOOLBAR_SQUARE_LENGTH * TOOLBAR_SQUARE_LENGTH);
            }
            toolbarColors = new Color[] { Color.White, Virus.baselineColor, Cell.baselineColor, Colony.baselineColor, Animal.baselineColor, Plant.baselineColor };
        }

        /// <summary>
        /// Creates the rectangular UI grid.
        /// </summary>
        private void CreateGrid()
        {
            // TODO: need to refactor to parameratize?
            grid = new Rectangle[manager.GridSize, manager.GridSize];
            //loop through the rows of the grid
            for (int j = 0; j < grid.GetLength(GridHelper.ROW); j++)
            {
                //loop through the columns of the grid
                for (int k = 0; k < grid.GetLength(GridHelper.COLUMN); k++)
                {
                    //create a new rectangle at a location corresponding with the row and column of the rectangle in the grid
                    grid[j, k] = new Rectangle(((ClientSize.Width/2) - BLOCK_SIZE * 5) + BLOCK_SIZE * j, BLOCK_SIZE*k, BLOCK_SIZE, BLOCK_SIZE);
                }                      
            }
        }

        /// <summary>
        /// Draws various graphical components on the form
        /// </summary>
        /// <param name="e">data on paint event</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //draw the units into the grid
            //loop through every row and column of the grid, drawing every block
            for (int j = 0; j < grid.GetLength(GridHelper.ROW); j++)
            {
                for (int k = 0; k < grid.GetLength(GridHelper.COLUMN); k++)
                {
                    Unit u = manager.GetUnit(j, k);
                    // Set initial grid colour to white to represent no unit
                    Color c = Color.White;
                    // Check if for a unit in this grid cell that needs to be drawn
                    if (u != null)
                    {
                        // Determine what type of unit it is to get its corresponding colour
                        switch (u.GetType().Name)
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
                    //Check if there is a unit, that it is not a virus and if it is infected
                    if(u != null && !(u is Virus) && (u as LivingUnit).Infected)
                    {
                        //draw a green rectangle around the unit to indicate it is infected
                        e.Graphics.DrawRectangle(new Pen(Color.DarkGreen, 2), grid[j, k]);
                    }
                    // Draw the rectangle around the grid
                    else e.Graphics.DrawRectangle(new Pen(Color.Black, 1), grid[j, k]);
                }
            }

            //loops through every toolbar element and draw the rectangle and a outline
            for (int i = 0; i < TOOLBAR_SIZE; i++)
            {
                e.Graphics.FillRectangle(new SolidBrush(toolbarColors[i]), toolbar[i]);
                e.Graphics.DrawRectangle(new Pen(Color.Black, 1), toolbar[i]);
            }

            //draw 'color' cursor
            //check if the erase tool is selected
            if (eraseToolSelected)
            {
                //make the cursor box white
                e.Graphics.FillRectangle(new SolidBrush(System.Drawing.Color.White), imageDragBox);
            }
            //oherwise check if there is a toolbar selection
            else if (toolbarSelection != Enums.UnitType.None)
            {
                //keeps track of the index of the color that corresponds with the unit type
                int i = 0;
                //loop through each type of unit
                foreach (Enums.UnitType type in Enum.GetValues(typeof(Enums.UnitType)))
                {
                    //check if the toolbar selection is the same as the current type
                    if (toolbarSelection == type)
                    {
                        //if so, draw the cursor as a box of the corresponding color 
                        e.Graphics.FillRectangle(new SolidBrush(toolbarColors[i]), imageDragBox);
                    }
                    //increment the index
                    ++i;
                }
            }
        }

        /// <summary>
        /// Calls various methods to update the parameters being displayed
        /// </summary>
        public void UpdateDisplayedParameters()
        {
            DisplayEnvironmentalParameters();
            DisplayGenerationNumber();
            DisplayCurrentScore();
            DisplayConcurrentHighScore();
            DisplayPreviousGens();
            DisplayEvent();
        }

        /// <summary>
        /// Display the basic environmental parameters
        /// </summary>
        private void DisplayEnvironmentalParameters()
        {
            lblEnvParams.Text = "Water Availability: " + manager.WaterAvailability.ToString() + "\r\n" + "Food Availability: "
                + manager.FoodAvailability.ToString() +"\r\n" + "Temperature: " + manager.Temperature.ToString() +"\r\n" 
                + "Carbon Dioxide Level: " + manager.CarbonDioxideLevel.ToString() + "\r\n" + "Oxygen Level: " + manager.OxygenLevel.ToString();
        }

        /// <summary>
        /// Display the current generation number
        /// </summary>
        private void DisplayGenerationNumber()
        {
            lblGenNum.Text = "Generation: " + manager.GenerationCounter.ToString();
        }

        /// <summary>
        /// Display the current score
        /// </summary>
        private void DisplayCurrentScore()
        {
            lblCurrScore.Text = "Score: " + manager.CurrentScore.ToString();
        }

        /// <summary>
        /// Display the highest concurrent score of the session
        /// </summary>
        private void DisplayConcurrentHighScore()
        {
            lblHighestConcurrentScore.Text = "Highest Concurrent Score: " + manager.HighestConcurrentScore.ToString();
        }

        /// <summary>
        /// Display the previous generations as possible selecctions in the combobox
        /// </summary>
        private void DisplayPreviousGens()
        {
            //the cached states
            State[] states = manager.CachedStates;
            //erase all current items
            cbGenNums.Items.Clear();
            //loop through all the cached states
            for (int i = 0; i < states.Length; i++)
            {                
                //check if the cached state exists
                if (states[i] != null)
                {
                    //if so, add its generation number as a possible selection
                    cbGenNums.Items.Add(states[i].GenerationCounter);
                }
                //If the state does not exist, add an item indicating that the state is not available
                else cbGenNums.Items.Add("Not Available");
            }
        }

        /// <summary>
        /// Provide user output on what event is occuring in the environment
        /// </summary>
        private void DisplayEvent()
        {
            //check if it is raining
            if (manager.IsRaining)
            {
                //update visual effects to display rain effect
                picEvent.Image = manager.RainImage;
                lblCurrentEvent.Text = "It is raining!";
            }
            //check if an environmental event is occuring
            else if (manager.EnvEventOccurring)
            {
                //update visual effects to display rain effects
                picEvent.Image = manager.EventImage;
                lblCurrentEvent.Text = "The environmental event is occurring!";
            }
            else
            {
                //otherwise, display no event graphics
                picEvent.Image = null;
                lblCurrentEvent.Text = "No event is occurring.";
            }
        }

        /// <summary>
        /// Timer tick event handler for every new generation
        /// </summary>
        private void tmrGeneration_Tick(object sender, EventArgs e)
        {
            manager.NextGeneration();
            if (manager.GameOver())
            {
                GameOver();
            }
            UpdateDisplayedParameters();
        }

        /// <summary>
        /// Timer tick event handler for refreshing graphics
        /// </summary>
        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        /// <summary>
        /// Event handler for mouse move, used to display the selection cursor
        /// </summary>
        private void GameForm_MouseMove(object sender, MouseEventArgs e)
        {
            //check if there is a toolbar selection
            if (toolbarSelection != Enums.UnitType.None || eraseToolSelected)
            {
                //If so, update the imagedragbox location to the cursors location
                imageDragBox.Location = new Point(e.Location.X - BLOCK_SIZE / 4, e.Location.Y - BLOCK_SIZE / 4);
            }
        }
        
        /// <summary>
        /// Event handler for mouse clicking that processes the user's actions
        /// </summary>
        /// <remarks> Tiffanie </remarks>
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
                            //check that the game is not paused
                            if (!isPaused)
                            {
                                //indicate that the game must be paused
                                MessageBox.Show("Pause game to interact with board");
                                continue;
                            }
                            // CASE 1: user is trying to erase a unit at the clicked location
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
            // Redraw form graphics
            Refresh();
        }

        /// <summary>
        /// Starts and pauses/unpauses the simulation
        /// </summary>
        private void btnPlay_Click(object sender, EventArgs e)
        {
            //check if the game is paused
            if (isPaused)
            {
                //if paused, change pause state to unpaused
                ChangePauseState(pause: false);
            }
            else
            {
                //if playing, change pause state to paused
                ChangePauseState(pause: true);
            }
        }

        /// <summary>
        /// Change the pause state
        /// </summary>
        /// <param name="pause"> A boolean representing whether or not the simulation is paused </param>
        private void ChangePauseState(bool pause)
        {
            //Change the enabled state of the generation timer
            tmrGeneration.Enabled = !pause;
            //change the pause state
            isPaused = pause;
            //change the text indicating whether the game is paused or not
            btnPlay.Text = pause ? "Unpause" : "pause";
        }

        /// <summary>
        /// End the simulation and open the leaderboard form
        /// </summary>
        public void GameOver()
        {
            // Show the cursor now that the game is over
            Cursor.Show();
            //disable timers
            tmrGeneration.Enabled = false;
            tmrRefresh.Enabled = false;
            //redraw graphics
            Refresh();
            //Indicate that game is over
            MessageBox.Show("GAME OVER");
            Close();
            // Open the leaderboard form
            LeaderboardForm f = new LeaderboardForm(manager);
            f.ShowDialog();
        }

        /// <summary>
        /// Change whether the saving controls are shown or not
        /// </summary>
        /// <param name="shown">Whether the states are shown</param>
        private void ToggleSavingUIVisibility(bool shown)
        {
            txtSessionName.Visible = shown;
            txtSessionName.Text = string.Empty;
            btnCancelSaving.Visible = shown;
            lblPromptSessionName.Visible = shown;
            btnConfirmSave.Visible = shown;
        }

        /// <summary>
        /// Button handler, saves the state
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Pause the session
            ChangePauseState(pause: true);
            // Show the tools available for session saving
            ToggleSavingUIVisibility(shown: true);
            
        }
        
        /// <summary>
        /// Button handler, loads a cached state
        /// </summary>
        private void btnLoadPrevGen_Click(object sender, EventArgs e)
        {
            //Make sure the game is paused, a generation number is selected and that the selected value is a number
            if (isPaused && cbGenNums.SelectedItem != null && cbGenNums.SelectedText != "Not Available")
            {
                //load the cached state corresponding with the generation number selected in the combobox
                manager.LoadCachedState((int)cbGenNums.SelectedItem);
                //display the new parameters
                UpdateDisplayedParameters();
                //redraw
                Refresh();
            }
        }

        /// <summary>
        /// Button handler, confirm saving the current state to file
        /// </summary>
        private void btnConfirmSave_Click(object sender, EventArgs e)
        {
            // Check if the user has inputted a name for the session
            if(txtSessionName.Text == "")
            {
                MessageBox.Show("Please input a session name.");
            }
            else
            {
                // save the state 
                manager.SaveState(txtSessionName.Text);
                // Hide the saving UI
                ToggleSavingUIVisibility(shown: false);
                // Unpause the simulation
                ChangePauseState(pause: false);
            }
            
        }

        /// <summary>
        /// Button handler, closes the saving UI 
        /// </summary>
        private void btnCancelSaving_Click(object sender, EventArgs e)
        {
            ToggleSavingUIVisibility(false);
        }
    }
}
