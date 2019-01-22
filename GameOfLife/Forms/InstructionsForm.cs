/*
 * Tiffanie Truong
 * January 21, 2019
 * This form displays information about how the simulation works and the units.
 * It is opened by the user's request in the start screen.
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
    public partial class InstructionsForm : Form
    {
        // Stores the previously clicked button in the form -- used for user output when disabling butons
        Button previouslySelected;

        public InstructionsForm()
        {
            InitializeComponent();
            // Initialize the information on the instructions to show the general rules
            txtInstructions.Text = "This is a single-player game based on John Conway’s famous cellular automaton, the Game of Life. \r\n" +
                                    "Fundamentally, the game consists of a rectangular grid-based environment in which a variety of cells interact. \r\n\r\n" +
                                    "The user is tasked with building a stable ecosystem, measured by a score. \r\n" +
                                    "This can be accomplished by modifying various starting parameters, consisting of both environmental factors and the locations and types of units. \r\n" +
                                    "A game over is reached when the score does not change for 5 generations.\r\n\r\n" +
                                    "Units live and die by the following rules: \r\n" +
                                    "     1. Any live unit with fewer than two live neighbors dies, as if by underpopulation.\r\n" +
                                    "     2. Any live unit with two or three live neighbors lives on to the next generation.\r\n" +
                                    "     3. Any live unit with more than three live neighbors dies, as if by overpopulation.\r\n" +
                                    "     4. Any dead unit with exactly three live neighbors becomes a live cell, as if by reproduction.";
            // Indicate that general rules are being shown
            btnGeneral.Enabled = false;
            previouslySelected = btnGeneral;
        }

        /// <summary>
        /// Displays general information about the game in the textbox
        /// </summary>
        private void btnGeneral_Click(object sender, EventArgs e)
        {
            // Enable and disable buttons to show what instructions are currently shown
            btnGeneral.Enabled = false;
            previouslySelected.Enabled = true;
            previouslySelected = btnGeneral;
            // Display information about the rules of game in the textbox
            txtInstructions.Text = "This is a single-player game based on John Conway’s famous cellular automaton, the Game of Life. \r\n" +
                                    "Fundamentally, the game consists of a rectangular grid-based environment in which a variety of cells interact. \r\n\r\n" +
                                    "The user is tasked with building a stable ecosystem, measured by a score. \r\n" +
                                    "This can be accomplished by modifying various starting parameters, consisting of both environmental factors and the locations and types of units. \r\n" +
                                    "A game over is reached when the score does not change for 5 generations.\r\n\r\n" +
                                    "Units live and die by the following rules: \r\n" +
                                    "     1. Any live unit with fewer than two live neighbors dies, as if by underpopulation.\r\n" +
                                    "     2. Any live unit with two or three live neighbors lives on to the next generation.\r\n" +
                                    "     3. Any live unit with more than three live neighbors dies, as if by overpopulation.\r\n" +
                                    "     4. Any dead unit with exactly three live neighbors becomes a live cell, as if by reproduction.";
        }

        /// <summary>
        /// Displays information about the environments of the simulation
        /// </summary>
        private void btnEnvironment_Click(object sender, EventArgs e)
        {
            // Enable and disable buttons to show what information is currently shown
            btnEnvironment.Enabled = false;
            previouslySelected.Enabled = true;
            previouslySelected = btnEnvironment;
            // Display information about the Environment
            txtInstructions.Text = "The player can choose the environment to be one of four possible biomes: rainforest, tundra, greenhouse, and desert.\r\n\r\n" +
                "Each biome has default values for environmental parameters of food availability, water availability, temperature, oxygen level, and carbon dioxide level. " +
                "The user can adjust these parameters at the start of the simulation to within 10% of their default value. " +
                "Every generation, there is a chance of rain or a unique environmental event to occur:\r\n" +
                "     A rainforest can undergo deforestation, reducing the food availability by 10% and the oxygen level by 5%.\r\n" +
                "     A tundra can undergo snowstorms, decreasing the temperature by 10℃ and decreasing water availability by 10%\r\n" +
                "     A greenhouse can have a caretaker come in, increasing water availability by 5% and removing any infected plants.\r\n" +
                "     A desert can have sandstorms, decreasing their food availability by 5% and decreasing the temperature by 5℃";
        }

        /// <summary>
        /// Displays information about the Virus unit in the textbox
        /// </summary>
        private void btnVirus_Click(object sender, EventArgs e)
        {
            // Enable and disable buttons to show what information is currently shown
            btnVirus.Enabled = false;
            previouslySelected.Enabled = true;
            previouslySelected = btnVirus;
            // Display information about Viruses
            txtInstructions.Text = "A virus can infect any other unit except for viruses. \r\n\r\n" +
                "Whenever a virus is in contact with a living unit, it infects it. If a virus is in contact with multiple living units, " +
                "it infects only the one closest to the top left corner of the environment " +
                "(prioritizing the one closest horizontally if there are two units tied in distance). \r\n\r\n" +
                "Once infected, a unit only has a certain number of generations, " +
                "determined by a cell’s infection resistance, to be cured before they die. " +
                "A unit has a chance to be cured of its virus every generation. \r\n\r\n" +
                "The probability of being cured comes from the following formula: P=R/M, where P is the probability, R is the unit’s infection resistance, and M is the maximum resistance of any living unit.";
        }

        /// <summary>
        /// Displays information about the Cell unit in the textbox
        /// </summary>
        private void btnCell_Click(object sender, EventArgs e)
        {
            // Enable and disable buttons to show what information is currently shown
            btnCell.Enabled = false;
            previouslySelected.Enabled = true;
            previouslySelected = btnCell;
            // Display information about Cells
            txtInstructions.Text = "A cell is the basic building block of life.\r\n\r\n" +
                "Cells can merge into colonies once 4 cells form a 2 by 2 square. " +
                "The top-left block becomes the location of the new colony, and all of the cells that built the colony are removed from the environment.\r\n\r\n" +
                "If a cell is successfully cured from a viral infection, its resistance increases by 0.5 to represent immunity.";
        }

        /// <summary>
        /// Displays information about the Colony unit in the textbox
        /// </summary>
        private void btnColony_Click(object sender, EventArgs e)
        {
            // Enable and disable buttons to show what information is currently shown
            btnColony.Enabled = false;
            previouslySelected.Enabled = true;
            previouslySelected = btnColony;
            // Display information about Colonies
            txtInstructions.Text = "Colonies merge into a multicellular organism once 4 colonies form a 2 by 2 square, with the top-left colony absorbing the others " +
                "(i.e. the top-left block is the location of the new multicellular organism). \r\n\r\n" +
                "They evolve into either a plant or animal depending on atmospheric composition. " +
                "The percentage of carbon dioxide in the atmosphere represents the probability of evolving into a plant. " +
                "The same appies with oxygen and animals.\r\n\r\n" +
                "If a colony does not have enough food to sustain itself, it splits up into 4 cells again.";
        }

        /// <summary>
        /// Displays information about the Animal unit in the textbox
        /// </summary>
        private void btnAnimal_Click(object sender, EventArgs e)
        {
            // Enable and disable buttons to show what information is currently shown
            btnAnimal.Enabled = false;
            previouslySelected.Enabled = true;
            previouslySelected = btnAnimal;
            // Display information about Animals
            txtInstructions.Text = "Animals can independently thermoregulate to reach their ideal temperature, consuming 2 food units and 1 water unit " +
                "to increase or decrease their ideal external temperature by 1℃ (per generation).\r\n\r\n" +
                "Animals can eat plants around them, thus killing the plant. " +
                "After consuming a plant, however, the animal must enter hibernation for 3 generations, " +
                "during which its food, water, gas, ideal temperature, decomposition value, and infection resistance values are halved. " +
                "However, if the plant consumed is toxic, the animal dies. " +
                "An animal only attempts to eat a plant if it is starving; that is, if the food available to it is not greater than the food required by at least 500%.";
        }

        /// <summary>
        /// Displays information about the Plant unit  in the textbox
        /// </summary>
        private void btnPlant_Click(object sender, EventArgs e)
        {
            // Enable and disable buttons to show what information is currently shown
            btnPlant.Enabled = false;
            previouslySelected.Enabled = true;
            previouslySelected = btnPlant;
            // Display information about Plants
            txtInstructions.Text = "Plants can photosynthesize, consuming a random amount of carbon dioxide between 1 to 4 " +
                "and an equal amount of water to return an equal amount of food to their environment every generation." +
                "When a new plant is formed, food availability increases by 3 units.\r\n\r\n" +
                "Every plant has a probability of being toxic to animals who eat them: P=(t/100) * (a/50), " +
                "where a is the plant’s age and t is a random integer between 1 and 100 inclusive (t remains constant for each plant).";
        }
    }
}
