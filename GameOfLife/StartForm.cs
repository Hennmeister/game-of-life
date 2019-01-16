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
        private GameManager gameManager;

        public StartForm(GameManager manager)
        {
            InitializeComponent();
            AddTrackBars();
            ToggleTrackBars(enabled: false);
            // Set combobox values
            cbEnvironmentSelection.DataSource = Enum.GetValues(typeof(Enums.EnvironmentType));
            gameManager = manager;
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

        private void btnSaveUsername_Click(object sender, EventArgs e)
        {
            // Check if the username entered is valid 
            if(txtUsername.Text == "")
            {
                // Notify the user
                MessageBox.Show("Please enter a valid username.");
            }
            else
            {
                username = txtUsername.Text;
            }
        }

        private void btnSetEnvParameters_Click(object sender, EventArgs e)
        {
            // No environment selected
            if(cbEnvironmentSelection.SelectedText == "")
            {
                // Error
                MessageBox.Show("Please select an environment.");
            }
            else
            {

            }
        }


        private void btnSelectEnvironment_Click(object sender, EventArgs e)
        {
            string userSelection = cbEnvironmentSelection.SelectedText;

            // No environment selected
            if (userSelection == "")
            {
                // Error
                MessageBox.Show("Please select an environment.");
            }
            else
            {
                // Make the environment
                Enums.EnvironmentType selectedEnvironment;
                Enum.TryParse(cbEnvironmentSelection.SelectedValue.ToString(), out selectedEnvironment);
                gameManager.CreateEnvironment(selectedEnvironment);
            }
        }
    }
}
