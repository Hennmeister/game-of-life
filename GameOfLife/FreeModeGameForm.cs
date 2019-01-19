using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class FreeModeGameForm : GameForm
    {
        public FreeModeGameForm(GameManager manager) : base(manager)
        {

        }

        private void SetFoodAvailability()
        {

        }

        private void SetWaterAvailability()
        {

        }
        
        private void SetTemperature()
        {

        }

        private void SetOxygenLevel()
        {

        }

        private void SetCarbonDioxideLevel()
        {

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FreeModeGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1077, 415);
            this.Name = "FreeModeGameForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
