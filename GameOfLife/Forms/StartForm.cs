/*
 * Tiffanie Truong (sliders and instruction form)
 * January 15, 2019
 * This Form allows the user to make pre-game decisions by choosing the
 * the Environment and enviromental parameters or loading a previous save.
 * They may also learn about the game by opening an instructions form.
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
    public partial class StartForm : Form
    {
        private TrackBar[] trackBars;
        private const int NUM_ENV_PARAMETERS = 5;
        // Store game actions and data
        private GameManager manager;

        /// <summary>
        /// Creates a new StartForm
        /// </summary>
        /// <param name="manager"> The manager that processes and coordinates the events of the game </param>
        public StartForm(GameManager manager)
        {
            InitializeComponent();
            // Save the manager used to process the game
            this.manager = manager;
            // Set combobox values given the Environment Type selected by default
            cbEnvironmentSelection.DataSource = Enum.GetValues(typeof(Enums.EnvironmentType));
        }

        /// <summary>
        /// Processes the user's request to start the game
        /// </summary>
        private void btnStart_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        /// <summary>
        /// Moves to the GameForm and starts the simulation is all required information is inputted
        /// </summary>
        private void StartGame()
        {
            // Check if a valid username has been set
            if (txtUsername.Text == "" || txtUsername.Text.Contains("(") || txtUsername.Text.Contains(")"))
            {
                MessageBox.Show("Please enter a valid username.");
            }
            // Check if an environment has been selected
            else if (!manager.IsEnvironmentCreated())
            {
                MessageBox.Show("Please select an environment.");
            }
            // Otherwise, can start the game
            else
            {
                // Create the game form 
                GameForm gameForm = new GameForm(manager, txtUsername.Text);
                //create a new grid for the state 
                manager.CreateGrid();
                // Display the new game form
                this.Hide();
                gameForm.ShowDialog();
                // Close this form
                this.Close();
            }
        }

        /// <summary>
        /// Opens a form displaying instructions and game information as per the user's request
        /// </summary>
        private void btnDisplayInstructions_Click(object sender, EventArgs e)
        {
            // Create a new instance of the form containing the instructions and open it
            InstructionsForm instructions = new InstructionsForm();
            instructions.Show();
        }

        /// <summary>
        /// Creates an Environment given the the user's choice of Environment
        /// </summary>
        private void cbEnvironmentSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Convert the chosen Environment in the combobox to the type of environment
            Enum.TryParse(cbEnvironmentSelection.SelectedValue.ToString(), out Enums.EnvironmentType env);
            // Create an Environment of the chosen type
            manager.CreateEnvironment(env);
            // Reset the possible values of the sliders based on the default parameters of the chosen Environment
            ConfigureTrackBars();
        }

        /// <summary>
        /// Configures the trackbars of the sliders to contain valid values for parameters of the currently selected environment
        /// </summary>
        private void ConfigureTrackBars()
        {
            // Only configure the trackbars if there is an actual environment to base the values off of
            if (manager.IsEnvironmentCreated())
            {
                // Set the possible values for the food slider
                sldFoodAvailability.SetRange(EnvironmentHelper.EnvParamLowBound(manager.FoodAvailability),
                                             EnvironmentHelper.EnvParamHighBound(manager.FoodAvailability));
                lblMaxFood.Text = EnvironmentHelper.EnvParamHighBound(manager.FoodAvailability).ToString();
                lblMinFood.Text = EnvironmentHelper.EnvParamLowBound(manager.FoodAvailability).ToString();

                // Set the possible values for the water slider
                sldWaterAvailability.SetRange(EnvironmentHelper.EnvParamLowBound(manager.WaterAvailability),
                                              EnvironmentHelper.EnvParamHighBound(manager.WaterAvailability));
                lblMinWater.Text = EnvironmentHelper.EnvParamLowBound(manager.WaterAvailability).ToString();
                lblMaxWater.Text = EnvironmentHelper.EnvParamHighBound(manager.WaterAvailability).ToString();

                // Set the possible values for the temperature slider
                sldTemperature.SetRange(EnvironmentHelper.EnvParamLowBound(manager.Temperature),
                                        EnvironmentHelper.EnvParamHighBound(manager.Temperature));
                lblMinTemp.Text = EnvironmentHelper.EnvParamLowBound(manager.Temperature).ToString() + "°C";
                lblMaxTemp.Text = EnvironmentHelper.EnvParamHighBound(manager.Temperature).ToString() + "°C";

                // Set the possible values for the oxygen slider
                sldOxygenLevel.SetRange(EnvironmentHelper.EnvParamLowBound(manager.OxygenLevel),
                                        EnvironmentHelper.EnvParamHighBound(manager.OxygenLevel));
                lblMinOxygen.Text = EnvironmentHelper.EnvParamLowBound(manager.OxygenLevel).ToString() + "%";
                lblMaxOxygen.Text = EnvironmentHelper.EnvParamHighBound(manager.OxygenLevel).ToString() + "%";

                // Set the possible values for the carbon dioxide slider
                sldCarbonDioxideLevel.SetRange(EnvironmentHelper.EnvParamLowBound(manager.CarbonDioxideLevel),
                                               EnvironmentHelper.EnvParamHighBound(manager.CarbonDioxideLevel));
                lblMinCarbonDioxide.Text = EnvironmentHelper.EnvParamLowBound(manager.CarbonDioxideLevel).ToString() + "%";
                lblMaxCarbonDioxide.Text = EnvironmentHelper.EnvParamHighBound(manager.CarbonDioxideLevel).ToString() + "%";

                // Update the current value of all sliders to the default middle value
                sldFoodAvailability.Value = (int)manager.FoodAvailability;
                sldWaterAvailability.Value = (int)manager.WaterAvailability;
                sldTemperature.Value = manager.Temperature;
                sldOxygenLevel.Value = manager.OxygenLevel;
                sldCarbonDioxideLevel.Value = manager.CarbonDioxideLevel;
                // Output the currently selected value
                lblCurrFood.Text = sldFoodAvailability.Value.ToString();
                lblCurrWater.Text = sldWaterAvailability.Value.ToString();
                lblCurrTemp.Text = sldTemperature.Value.ToString() + "°C";
                lblCurrOxygen.Text = sldOxygenLevel.Value.ToString() + "%";
                lblCurrCarbonDioxide.Text = sldCarbonDioxideLevel.Value.ToString() + "%";
            }
        }

        //************ SLIDER SCROLLING ************/

        /// <summary>
        /// Process and saves the user's changes to the food availability slider
        /// </summary>
        private void sldFoodAvailability_Scroll(object sender, EventArgs e)
        {
            // Save the new value of food availability
            manager.FoodAvailability = sldFoodAvailability.Value;
            // Output the new value that the user selected
            lblCurrFood.Text = sldFoodAvailability.Value.ToString();
        }

        /// <summary>
        /// Process and saves the user's changes to the food availability slider
        /// </summary>
        private void sldWaterAvailability_Scroll(object sender, EventArgs e)
        {
            // Save the new value of water availability
            manager.WaterAvailability = sldWaterAvailability.Value;
            // Output the new value that the user selected
            lblCurrWater.Text = sldWaterAvailability.Value.ToString();
        }

        /// <summary>
        /// Process and saves the user's changes to the food availability slider
        /// </summary>
        private void sldTemperature_Scroll(object sender, EventArgs e)
        {
            // Save the new temperature value
            lblCurrTemp.Text = sldTemperature.Value.ToString() + "°C";
            // Output the new value that the user selected
            manager.Temperature = sldTemperature.Value;
        }

        /// <summary>
        /// Process and saves the user's changes to the food availability slider
        /// </summary>
        private void sldOxygenLevel_Scroll(object sender, EventArgs e)
        {
            // Update new oxygen and carbon dioxide levels
            manager.OxygenLevel = sldOxygenLevel.Value;
            sldCarbonDioxideLevel.Value = 100 - manager.OxygenLevel;
            manager.CarbonDioxideLevel = 100 - manager.OxygenLevel;
            // Output new oxygen and carbon dioxide levels
            lblCurrOxygen.Text = sldOxygenLevel.Value.ToString() + "%";
            lblCurrCarbonDioxide.Text = sldCarbonDioxideLevel.Value.ToString() + "%";
        }

        /// <summary>
        /// Process and saves the user's changes to the food availability slider
        /// </summary>
        private void sldCarbonDioxideLevel_Scroll(object sender, EventArgs e)
        {
            // Update new carbon dioxide and oxygen levels
            manager.CarbonDioxideLevel = sldCarbonDioxideLevel.Value;
            manager.OxygenLevel = 100 - sldCarbonDioxideLevel.Value;
            sldOxygenLevel.Value = 100 - sldCarbonDioxideLevel.Value;
            // Output new carbon dioxide and oxygen levels
            lblCurrCarbonDioxide.Text = sldCarbonDioxideLevel.Value.ToString() + "%";
            lblCurrOxygen.Text = sldOxygenLevel.Value.ToString() + "%";
        }

        // ************ LOADING ************ //
        private void btnLoadState_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog browser = new FolderBrowserDialog())
            {
                browser.SelectedPath = Datastore.GeneralStatesDirectoryPath;
                browser.ShowNewFolderButton = false;
                DialogResult result = browser.ShowDialog();
                if(result == DialogResult.OK && string.IsNullOrWhiteSpace(browser.SelectedPath) ||
                   !browser.SelectedPath.Contains(Datastore.GeneralStatesDirectoryPath) || 
                   browser.SelectedPath.Length <= Datastore.GeneralStatesDirectoryPath.Length)
                {
                    MessageBox.Show("Please select a valid directory within the PastStates directory.");
                }
                else if (result == DialogResult.OK)
                {
                    manager.LoadState(browser.SelectedPath);
                    // Create the game form 
                    GameForm gameForm = new GameForm(manager, manager.Username);
                    // Display the new game form
                    this.Hide();
                    gameForm.ShowDialog();
                    // Close this form
                    this.Close();
                }
            }
        }
    }
}
