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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblEnvironmentType = new System.Windows.Forms.Label();
            this.lblCurrentEvent = new System.Windows.Forms.Label();
            this.lblErase = new System.Windows.Forms.Label();
            this.lblCellTool = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAnimalTool = new System.Windows.Forms.Label();
            this.lblPlantTool = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tmrGeneration
            // 
            this.tmrGeneration.Tick += new System.EventHandler(this.tmrGeneration_Tick);
            // 
            // lblGenNum
            // 
            this.lblGenNum.AutoSize = true;
            this.lblGenNum.Location = new System.Drawing.Point(29, 407);
            this.lblGenNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGenNum.Name = "lblGenNum";
            this.lblGenNum.Size = new System.Drawing.Size(92, 17);
            this.lblGenNum.TabIndex = 0;
            this.lblGenNum.Text = "GEN Number";
            // 
            // lblCurrScore
            // 
            this.lblCurrScore.AutoSize = true;
            this.lblCurrScore.Location = new System.Drawing.Point(29, 434);
            this.lblCurrScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrScore.Name = "lblCurrScore";
            this.lblCurrScore.Size = new System.Drawing.Size(74, 17);
            this.lblCurrScore.TabIndex = 1;
            this.lblCurrScore.Text = "Curr score";
            // 
            // lblHighestConcurrentScore
            // 
            this.lblHighestConcurrentScore.AutoSize = true;
            this.lblHighestConcurrentScore.Location = new System.Drawing.Point(29, 466);
            this.lblHighestConcurrentScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHighestConcurrentScore.Name = "lblHighestConcurrentScore";
            this.lblHighestConcurrentScore.Size = new System.Drawing.Size(167, 17);
            this.lblHighestConcurrentScore.TabIndex = 2;
            this.lblHighestConcurrentScore.Text = "Highest concurrent score";
            // 
            // lblEnvParams
            // 
            this.lblEnvParams.AutoSize = true;
            this.lblEnvParams.Location = new System.Drawing.Point(37, 251);
            this.lblEnvParams.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEnvParams.Name = "lblEnvParams";
            this.lblEnvParams.Size = new System.Drawing.Size(84, 17);
            this.lblEnvParams.TabIndex = 3;
            this.lblEnvParams.Text = "Env Params";
            // 
            // tmrRefresh
            // 
            this.tmrRefresh.Enabled = true;
            this.tmrRefresh.Interval = 25;
            this.tmrRefresh.Tick += new System.EventHandler(this.tmrRefresh_Tick);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(20, 25);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(383, 69);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Game of Life";
            // 
            // lblEnvironmentType
            // 
            this.lblEnvironmentType.AutoSize = true;
            this.lblEnvironmentType.Location = new System.Drawing.Point(37, 213);
            this.lblEnvironmentType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEnvironmentType.Name = "lblEnvironmentType";
            this.lblEnvironmentType.Size = new System.Drawing.Size(127, 17);
            this.lblEnvironmentType.TabIndex = 5;
            this.lblEnvironmentType.Text = "Environment Type ";
            // 
            // lblCurrentEvent
            // 
            this.lblCurrentEvent.AutoSize = true;
            this.lblCurrentEvent.Location = new System.Drawing.Point(264, 213);
            this.lblCurrentEvent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrentEvent.Name = "lblCurrentEvent";
            this.lblCurrentEvent.Size = new System.Drawing.Size(95, 17);
            this.lblCurrentEvent.TabIndex = 6;
            this.lblCurrentEvent.Text = "Current Event";
            // 
            // lblErase
            // 
            this.lblErase.AutoSize = true;
            this.lblErase.Location = new System.Drawing.Point(16, 527);
            this.lblErase.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblErase.Name = "lblErase";
            this.lblErase.Size = new System.Drawing.Size(77, 17);
            this.lblErase.TabIndex = 7;
            this.lblErase.Text = "Erase Tool";
            // 
            // lblCellTool
            // 
            this.lblCellTool.AutoSize = true;
            this.lblCellTool.Location = new System.Drawing.Point(195, 527);
            this.lblCellTool.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCellTool.Name = "lblCellTool";
            this.lblCellTool.Size = new System.Drawing.Size(31, 17);
            this.lblCellTool.TabIndex = 8;
            this.lblCellTool.Text = "Cell";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(269, 527);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Colony";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 527);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Virus";
            // 
            // lblAnimalTool
            // 
            this.lblAnimalTool.AutoSize = true;
            this.lblAnimalTool.Location = new System.Drawing.Point(352, 527);
            this.lblAnimalTool.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAnimalTool.Name = "lblAnimalTool";
            this.lblAnimalTool.Size = new System.Drawing.Size(50, 17);
            this.lblAnimalTool.TabIndex = 11;
            this.lblAnimalTool.Text = "Animal";
            // 
            // lblPlantTool
            // 
            this.lblPlantTool.AutoSize = true;
            this.lblPlantTool.Location = new System.Drawing.Point(428, 527);
            this.lblPlantTool.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPlantTool.Name = "lblPlantTool";
            this.lblPlantTool.Size = new System.Drawing.Size(40, 17);
            this.lblPlantTool.TabIndex = 12;
            this.lblPlantTool.Text = "Plant";
            // 
            // btnStart
            // 
            this.btnStart.AutoEllipsis = true;
            this.btnStart.Location = new System.Drawing.Point(99, 112);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(243, 39);
            this.btnStart.TabIndex = 13;
            this.btnStart.Text = "Start Sim!";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(272, 265);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 38);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(272, 309);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 38);
            this.btnLoad.TabIndex = 15;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 625);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblPlantTool);
            this.Controls.Add(this.lblAnimalTool);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCellTool);
            this.Controls.Add(this.lblErase);
            this.Controls.Add(this.lblCurrentEvent);
            this.Controls.Add(this.lblEnvironmentType);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblEnvParams);
            this.Controls.Add(this.lblHighestConcurrentScore);
            this.Controls.Add(this.lblCurrScore);
            this.Controls.Add(this.lblGenNum);
            this.DoubleBuffered = true;
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
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblEnvironmentType;
        private System.Windows.Forms.Label lblCurrentEvent;
        private System.Windows.Forms.Label lblErase;
        private System.Windows.Forms.Label lblCellTool;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAnimalTool;
        private System.Windows.Forms.Label lblPlantTool;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
    }
}

