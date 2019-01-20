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
    public partial class StartForm : Form
    {
        private string username;
        private TrackBar[] trackBars;
        private const int NUM_ENV_PARAMETERS = 5;
        //store game actions and data
        private GameManager manager;

        // Used to adjust changes in the oxygen level and carbon dioxide level sliders
        // Needed to calculate change and apply to other slider (balance out to 100%)
        private int oxygenLevel;
        private int carbonDioxideLevel;

        public StartForm(GameManager manager)
        {
            this.manager = manager;
            InitializeComponent();
            AddTrackBars();
            // ToggleTrackBars(enabled: false);
            // Set combobox values
            cbEnvironmentSelection.DataSource = Enum.GetValues(typeof(Enums.EnvironmentType));
        }

        // Keeps track of the trackbars
        private void AddTrackBars()
        {
            trackBars = new TrackBar[NUM_ENV_PARAMETERS];
            // Add the existing trackbars
            trackBars[0] = sldFoodAvailability;
            trackBars[1] = sldWaterAvailability;
            trackBars[2] = sldTemperature;
            trackBars[3] = sldOxygenLevel;
            trackBars[4] = sldCarbonDioxideLevel;
        }
        
        // Toggle all of the trackbars on or off
        private void ToggleTrackBars(bool enabled)
        {
            foreach(TrackBar trackBar in trackBars)
            {
                trackBar.Enabled = !trackBar.Enabled;
            }
        }

        // Configures the track bar parameters 
        private void ConfigureTrackBars()
        {
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
                sldCarbonDioxideLevel.SetRange(100 - EnvironmentHelper.EnvParamHighBound(manager.OxygenLevel),
                                               100 - EnvironmentHelper.EnvParamLowBound(manager.OxygenLevel));
                lblMinCarbonDioxide.Text = (100 - EnvironmentHelper.EnvParamHighBound(manager.OxygenLevel)).ToString() + "%";
                lblMaxCarbonDioxide.Text = (100 - EnvironmentHelper.EnvParamLowBound(manager.OxygenLevel)).ToString() + "%";

                // Update the current value of all sliders to the default middle value
                sldFoodAvailability.Value = (int)manager.FoodAvailability;
                sldWaterAvailability.Value = (int)manager.WaterAvailability;
                sldTemperature.Value = manager.Temperature;
                sldOxygenLevel.Value = manager.OxygenLevel;
                sldCarbonDioxideLevel.Value = manager.CarbonDioxideLevel;
                lblCurrFood.Text = sldFoodAvailability.Value.ToString();
                lblCurrWater.Text = sldWaterAvailability.Value.ToString();
                lblCurrTemp.Text = sldTemperature.Value.ToString() + "°C";
                lblCurrOxygen.Text = sldOxygenLevel.Value.ToString() + "%";
                lblCurrCarbonDioxide.Text = sldCarbonDioxideLevel.Value.ToString() + "%";
                // Keep track of the current oxygen and carbon dioxide levels
                oxygenLevel = sldOxygenLevel.Value;
                carbonDioxideLevel = sldCarbonDioxideLevel.Value;
            }
        }

        private void btnSetEnvParameters_Click(object sender, EventArgs e)
        {
            // Check if an environment has already been set
            if (manager.IsEnvironmentCreated())
            {
                ConfigureTrackBars();
            }
            else
            {
                // Error
                MessageBox.Show("Please select an environment.");
            }
        }

        private void StartGame(Enums.GameMode selectedMode)
        {
            // Check if username has been set
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Please enter a username.");
            }
            // Check if an environment has been selected
            else if (!manager.IsEnvironmentCreated())
            {
                MessageBox.Show("Please select an environment.");
            }
            // Otherwise, can start the game
            else
            {
                //set the current state as the starting state
                manager.SetStartingState();
                // Create the game form 
                GameForm gameForm;
                if(selectedMode == Enums.GameMode.Free)
                {
                    gameForm = new FreeModeGameForm(manager);
                }
                else
                {
                    gameForm = new RealisticModeGameForm(manager);
                }
                // Display the new game form
                gameForm.ShowDialog();
                // Close this form
                this.Close();
            }
        }


        private void btnStartRealistic_Click(object sender, EventArgs e)
        {
            StartGame(Enums.GameMode.Realistic);
        }

        private void btnStartFree_Click(object sender, EventArgs e)
        {
            StartGame(Enums.GameMode.Free);
        }

        // Show instructions
        private void DisplayInstructions()
        {
            InstructionsForm instructions = new InstructionsForm();
            instructions.ShowDialog();
        }

        // Close the program 
        private void StartForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnLoadExample_Click(object sender, EventArgs e)
        {
            // Check that the user has selected an example 
            if (cbExamples.SelectedItem == null)
            {
                MessageBox.Show("Please select an example.");
            }
        }

        private void sldFoodAvailability_CursorChanged(object sender, EventArgs e)
        {
            int i = sldFoodAvailability.Value;
        }

        private void cbEnvironmentSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            Enum.TryParse(cbEnvironmentSelection.SelectedValue.ToString(), out Enums.EnvironmentType env);
            manager.CreateEnvironment(env);
            ConfigureTrackBars();
        }

        //************ SLIDER SCROLLING ************/
        // may do sets to just set the environmental parameters?

        private void sldFoodAvailability_Scroll(object sender, EventArgs e)
        {
            lblCurrFood.Text = sldFoodAvailability.Value.ToString();
            manager.FoodAvailability = sldFoodAvailability.Value;
        }

        private void sldWaterAvailability_Scroll(object sender, EventArgs e)
        {
            lblCurrWater.Text = sldWaterAvailability.Value.ToString();

        }

        private void sldTemperature_Scroll(object sender, EventArgs e)
        {
            lblCurrTemp.Text = sldTemperature.Value.ToString() + "°C";

        }

        private void sldOxygenLevel_Scroll(object sender, EventArgs e)
        {
            lblCurrOxygen.Text = sldOxygenLevel.Value.ToString() + "%";
            // Calculate difference between previous and new oxygen level
            int difference = oxygenLevel - sldOxygenLevel.Value;
            // Apply difference to carbon dioxide level in the opposite direction to ensure they sum to 100%
            sldCarbonDioxideLevel.Value += difference;
            lblCurrCarbonDioxide.Text = sldCarbonDioxideLevel.Value.ToString() + "%";
            // Update current oxygen level
            oxygenLevel = sldOxygenLevel.Value;
        }

        private void sldCarbonDioxideLevel_Scroll(object sender, EventArgs e)
        {
            // Calculate difference between previous and new carbon dioxide level
            int difference = carbonDioxideLevel - sldCarbonDioxideLevel.Value;
            // Apply difference to carbon dioxide level in the opposite direction to ensure they sum to 100%
            sldOxygenLevel.Value += difference;
            lblCurrOxygen.Text = sldCarbonDioxideLevel.Value.ToString() + "%";
            // Update current carbon dioxide level
            carbonDioxideLevel = sldCarbonDioxideLevel.Value;
        }
    }
}
