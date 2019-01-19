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
        protected Rectangle[,] grid;
        protected Rectangle[] toolbar = new Rectangle[TOOLBAR_SIZE];
        protected Color[] toolbarColors;
        protected Rectangle imageDragBox;

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
                toolbar[i] = new Rectangle(CELL_SIZE * 8 * i, ClientSize.Height - CELL_SIZE*8, CELL_SIZE * 8, CELL_SIZE * 8);
                toolbarColors = new Color[] { Color.White, Virus.baselineColor, Cell.baselineColor, Colony.baselineColor, Animal.baselineColor, Plant.baselineColor };
            }
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
                    grid[j, k] = new Rectangle(((ClientSize.Width/2) - CELL_SIZE * 12) + CELL_SIZE * j, CELL_SIZE*k, CELL_SIZE, CELL_SIZE);
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
            if (toolbarSelection != Enums.UnitType.None)
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
            if (toolbarSelection != Enums.UnitType.None)
            {
                //MAY NEED TO FIX LOCATION ACCURACY =
                imageDragBox.Location = new Point(e.Location.X - CELL_SIZE / 4, e.Location.Y - CELL_SIZE / 4);
            }
        }

        protected virtual void GameForm_MouseDown(object sender, MouseEventArgs e)
        {
            for (int j = 0; j < grid.GetLength(GridHelper.ROW); j++)
            {
                for (int k = 0; k < grid.GetLength(GridHelper.COLUMN); k++)
                {
                    if(grid[j, k].Contains(e.Location))
                    {
                        manager.CreateUnit(j, k, toolbarSelection);
                        return;
                    }
                }
            }

            for (int i = 0; i < TOOLBAR_SIZE; i++)
            {
                if (toolbar[i].Contains(e.Location))
                {
                    toolbarSelection = (Enums.UnitType)i;
                    imageDragBox.Location = e.Location;
                    Cursor.Hide();
                    return;
                }
            }
            toolbarSelection = Enums.UnitType.None;
            Cursor.Show();
        }
    }
}
