using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class RealisticModeGameForm : GameForm
    { 
        public RealisticModeGameForm(GameManager manager) : base(manager)
        {

        }
        
        private void DisableToolbar()
        {

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // RealisticModeGameForm
            // 
            this.ClientSize = new System.Drawing.Size(918, 416);
            this.Name = "RealisticModeGameForm";
            this.ResumeLayout(false);

        }
    }
}
