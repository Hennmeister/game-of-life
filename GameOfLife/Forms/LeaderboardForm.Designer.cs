namespace GameOfLife
{
    partial class LeaderboardForm
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
            this.lblScore1 = new System.Windows.Forms.Label();
            this.lblScore2 = new System.Windows.Forms.Label();
            this.lblScore3 = new System.Windows.Forms.Label();
            this.lblScore4 = new System.Windows.Forms.Label();
            this.lblScore5 = new System.Windows.Forms.Label();
            this.lblPromptLoadScore = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblScore1
            // 
            this.lblScore1.AutoSize = true;
            this.lblScore1.Location = new System.Drawing.Point(276, 65);
            this.lblScore1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblScore1.Name = "lblScore1";
            this.lblScore1.Size = new System.Drawing.Size(35, 13);
            this.lblScore1.TabIndex = 0;
            this.lblScore1.Text = "label1";
            // 
            // lblScore2
            // 
            this.lblScore2.AutoSize = true;
            this.lblScore2.Location = new System.Drawing.Point(276, 107);
            this.lblScore2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblScore2.Name = "lblScore2";
            this.lblScore2.Size = new System.Drawing.Size(35, 13);
            this.lblScore2.TabIndex = 1;
            this.lblScore2.Text = "label1";
            // 
            // lblScore3
            // 
            this.lblScore3.AutoSize = true;
            this.lblScore3.Location = new System.Drawing.Point(276, 148);
            this.lblScore3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblScore3.Name = "lblScore3";
            this.lblScore3.Size = new System.Drawing.Size(35, 13);
            this.lblScore3.TabIndex = 2;
            this.lblScore3.Text = "label1";
            // 
            // lblScore4
            // 
            this.lblScore4.AutoSize = true;
            this.lblScore4.Location = new System.Drawing.Point(276, 185);
            this.lblScore4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblScore4.Name = "lblScore4";
            this.lblScore4.Size = new System.Drawing.Size(35, 13);
            this.lblScore4.TabIndex = 3;
            this.lblScore4.Text = "label1";
            // 
            // lblScore5
            // 
            this.lblScore5.AutoSize = true;
            this.lblScore5.Location = new System.Drawing.Point(276, 223);
            this.lblScore5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblScore5.Name = "lblScore5";
            this.lblScore5.Size = new System.Drawing.Size(35, 13);
            this.lblScore5.TabIndex = 4;
            this.lblScore5.Text = "label1";
            // 
            // lblPromptLoadScore
            // 
            this.lblPromptLoadScore.AutoSize = true;
            this.lblPromptLoadScore.Location = new System.Drawing.Point(186, 42);
            this.lblPromptLoadScore.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblPromptLoadScore.Name = "lblPromptLoadScore";
            this.lblPromptLoadScore.Size = new System.Drawing.Size(247, 13);
            this.lblPromptLoadScore.TabIndex = 5;
            this.lblPromptLoadScore.Text = "Double click any label to load the associated state.";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(460, 374);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(110, 41);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit to Main Menu";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // LeaderboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 427);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblPromptLoadScore);
            this.Controls.Add(this.lblScore5);
            this.Controls.Add(this.lblScore4);
            this.Controls.Add(this.lblScore3);
            this.Controls.Add(this.lblScore2);
            this.Controls.Add(this.lblScore1);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "LeaderboardForm";
            this.Text = "LeaderboardForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblScore1;
        private System.Windows.Forms.Label lblScore2;
        private System.Windows.Forms.Label lblScore3;
        private System.Windows.Forms.Label lblScore4;
        private System.Windows.Forms.Label lblScore5;
        private System.Windows.Forms.Label lblPromptLoadScore;
        private System.Windows.Forms.Button btnExit;
    }
}