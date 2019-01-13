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
        GameManager manager = new GameManager();

        public GameForm()
        {
            InitializeComponent();
        }

        private void Test_Click(object sender, EventArgs e)
        {
            //Delete
            manager.CreateUnit(0, 0, 0);
            Test.Text = manager.grid[0, 0].ToString();
        }


    }
}
