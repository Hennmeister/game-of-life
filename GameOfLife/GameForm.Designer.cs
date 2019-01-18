namespace GameOfLife
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tmrGeneration = new System.Windows.Forms.Timer(this.components);
            this.lblGenNum = new System.Windows.Forms.Label();
            this.lblCurrScore = new System.Windows.Forms.Label();
            this.lblHighestConcurrentScore = new System.Windows.Forms.Label();
            this.lblEnvParams = new System.Windows.Forms.Label();
            this.tmrRefresh = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tmrGeneration
            // 
            this.tmrGeneration.Enabled = true;
            this.tmrGeneration.Interval = 1000;
            this.tmrGeneration.Tick += new System.EventHandler(this.tmrGeneration_Tick);
            // 
            // lblGenNum
            // 
            this.lblGenNum.AutoSize = true;
            this.lblGenNum.Location = new System.Drawing.Point(663, 457);
            this.lblGenNum.Name = "lblGenNum";
            this.lblGenNum.Size = new System.Drawing.Size(68, 13);
            this.lblGenNum.TabIndex = 0;
            this.lblGenNum.Text = "GEN number";
            // 
            // lblCurrScore
            // 
            this.lblCurrScore.AutoSize = true;
            this.lblCurrScore.Location = new System.Drawing.Point(663, 479);
            this.lblCurrScore.Name = "lblCurrScore";
            this.lblCurrScore.Size = new System.Drawing.Size(55, 13);
            this.lblCurrScore.TabIndex = 1;
            this.lblCurrScore.Text = "Curr score";
            // 
            // lblHighestConcurrentScore
            // 
            this.lblHighestConcurrentScore.AutoSize = true;
            this.lblHighestConcurrentScore.Location = new System.Drawing.Point(663, 505);
            this.lblHighestConcurrentScore.Name = "lblHighestConcurrentScore";
            this.lblHighestConcurrentScore.Size = new System.Drawing.Size(126, 13);
            this.lblHighestConcurrentScore.TabIndex = 2;
            this.lblHighestConcurrentScore.Text = "Highest concurrent score";
            // 
            // lblEnvParams
            // 
            this.lblEnvParams.AutoSize = true;
            this.lblEnvParams.Location = new System.Drawing.Point(663, 529);
            this.lblEnvParams.Name = "lblEnvParams";
            this.lblEnvParams.Size = new System.Drawing.Size(64, 13);
            this.lblEnvParams.TabIndex = 3;
            this.lblEnvParams.Text = "Env Params";
            // 
            // tmrRefresh
            // 
            this.tmrRefresh.Enabled = true;
            this.tmrRefresh.Interval = 50;
            this.tmrRefresh.Tick += new System.EventHandler(this.tmrRefresh_Tick);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 586);
            this.Controls.Add(this.lblEnvParams);
            this.Controls.Add(this.lblHighestConcurrentScore);
            this.Controls.Add(this.lblCurrScore);
            this.Controls.Add(this.lblGenNum);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "GameForm";
            this.Text = "Form1";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GameForm_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrGeneration;
        private System.Windows.Forms.Label lblGenNum;
        private System.Windows.Forms.Label lblCurrScore;
        private System.Windows.Forms.Label lblHighestConcurrentScore;
        private System.Windows.Forms.Label lblEnvParams;
        private System.Windows.Forms.Timer tmrRefresh;
    }
}

