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
        //store game actions and data

        public StartForm(GameManager manager)
        {
            this.manager = manager;
            InitializeComponent();
            AddTrackBars();
            ToggleTrackBars(enabled: false);
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
                trackBar.Enabled = enabled;
            }
        }

        // Configures the track bar parameters 
        private void ConfigureTrackBars()
        {
            sldFoodAvailability.SetRange(EnvironmentHelper.EnvParamLowBound(manager.FoodAvailability),
                                         EnvironmentHelper.EnvParamHighBound(manager.FoodAvailability));
            sldWaterAvailability.SetRange(EnvironmentHelper.EnvParamLowBound(manager.WaterAvailability),
                                          EnvironmentHelper.EnvParamHighBound(manager.WaterAvailability));
            sldTemperature.SetRange(EnvironmentHelper.EnvParamLowBound(manager.Temperature),
                                    EnvironmentHelper.EnvParamHighBound(manager.Temperature));
            sldOxygenLevel.SetRange(EnvironmentHelper.EnvParamLowBound(manager.OxygenLevel),
                                    EnvironmentHelper.EnvParamHighBound(manager.OxygenLevel));
            sldCarbonDioxideLevel.SetRange(EnvironmentHelper.EnvParamLowBound(manager.CarbonDioxideLevel),
                                           EnvironmentHelper.EnvParamHighBound(manager.CarbonDioxideLevel));
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

        private void sldFoodAvailability_Scroll(object sender, EventArgs e)
        {

        }

        private void sldFoodAvailability_CursorChanged(object sender, EventArgs e)
        {
            int i = sldFoodAvailability.Value;
        }

        private void cbEnvironmentSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            Enum.TryParse(cbEnvironmentSelection.SelectedValue.ToString(), out Enums.EnvironmentType env);
            manager.CreateEnvironment(env);
        }
    }
}
