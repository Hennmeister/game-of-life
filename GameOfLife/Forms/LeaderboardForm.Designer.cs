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
            this.btnExit = new System.Windows.Forms.Button();
            this.lblLeaderboardTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblScore1
            // 
            this.lblScore1.AutoSize = true;
            this.lblScore1.Location = new System.Drawing.Point(274, 109);
            this.lblScore1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblScore1.Name = "lblScore1";
            this.lblScore1.Size = new System.Drawing.Size(0, 13);
            this.lblScore1.TabIndex = 0;
            // 
            // lblScore2
            // 
            this.lblScore2.AutoSize = true;
            this.lblScore2.Location = new System.Drawing.Point(274, 151);
            this.lblScore2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblScore2.Name = "lblScore2";
            this.lblScore2.Size = new System.Drawing.Size(0, 13);
            this.lblScore2.TabIndex = 1;
            // 
            // lblScore3
            // 
            this.lblScore3.AutoSize = true;
            this.lblScore3.Location = new System.Drawing.Point(274, 192);
            this.lblScore3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblScore3.Name = "lblScore3";
            this.lblScore3.Size = new System.Drawing.Size(0, 13);
            this.lblScore3.TabIndex = 2;
            // 
            // lblScore4
            // 
            this.lblScore4.AutoSize = true;
            this.lblScore4.Location = new System.Drawing.Point(274, 229);
            this.lblScore4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblScore4.Name = "lblScore4";
            this.lblScore4.Size = new System.Drawing.Size(0, 13);
            this.lblScore4.TabIndex = 3;
            // 
            // lblScore5
            // 
            this.lblScore5.AutoSize = true;
            this.lblScore5.Location = new System.Drawing.Point(274, 267);
            this.lblScore5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblScore5.Name = "lblScore5";
            this.lblScore5.Size = new System.Drawing.Size(0, 13);
            this.lblScore5.TabIndex = 4;
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
            // lblLeaderboardTitle
            // 
            this.lblLeaderboardTitle.AutoSize = true;
            this.lblLeaderboardTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeaderboardTitle.Location = new System.Drawing.Point(175, 9);
            this.lblLeaderboardTitle.Name = "lblLeaderboardTitle";
            this.lblLeaderboardTitle.Size = new System.Drawing.Size(242, 42);
            this.lblLeaderboardTitle.TabIndex = 7;
            this.lblLeaderboardTitle.Text = "Leaderboard";
            // 
            // LeaderboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 427);
            this.Controls.Add(this.lblLeaderboardTitle);
            this.Controls.Add(this.btnExit);
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
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblLeaderboardTitle;
    }
}