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
            this.cbGenNums = new System.Windows.Forms.ComboBox();
            this.btnLoadPrevGen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tmrGeneration
            // 
            this.tmrGeneration.Tick += new System.EventHandler(this.tmrGeneration_Tick);
            // 
            // lblGenNum
            // 
            this.lblGenNum.AutoSize = true;
            this.lblGenNum.Location = new System.Drawing.Point(22, 331);
            this.lblGenNum.Name = "lblGenNum";
            this.lblGenNum.Size = new System.Drawing.Size(70, 13);
            this.lblGenNum.TabIndex = 0;
            this.lblGenNum.Text = "GEN Number";
            // 
            // lblCurrScore
            // 
            this.lblCurrScore.AutoSize = true;
            this.lblCurrScore.Location = new System.Drawing.Point(22, 353);
            this.lblCurrScore.Name = "lblCurrScore";
            this.lblCurrScore.Size = new System.Drawing.Size(55, 13);
            this.lblCurrScore.TabIndex = 1;
            this.lblCurrScore.Text = "Curr score";
            // 
            // lblHighestConcurrentScore
            // 
            this.lblHighestConcurrentScore.AutoSize = true;
            this.lblHighestConcurrentScore.Location = new System.Drawing.Point(22, 379);
            this.lblHighestConcurrentScore.Name = "lblHighestConcurrentScore";
            this.lblHighestConcurrentScore.Size = new System.Drawing.Size(126, 13);
            this.lblHighestConcurrentScore.TabIndex = 2;
            this.lblHighestConcurrentScore.Text = "Highest concurrent score";
            // 
            // lblEnvParams
            // 
            this.lblEnvParams.AutoSize = true;
            this.lblEnvParams.Location = new System.Drawing.Point(28, 221);
            this.lblEnvParams.Name = "lblEnvParams";
            this.lblEnvParams.Size = new System.Drawing.Size(64, 13);
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
            this.lblTitle.Location = new System.Drawing.Point(15, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(310, 55);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Game of Life";
            // 
            // lblEnvironmentType
            // 
            this.lblEnvironmentType.AutoSize = true;
            this.lblEnvironmentType.Location = new System.Drawing.Point(28, 173);
            this.lblEnvironmentType.Name = "lblEnvironmentType";
            this.lblEnvironmentType.Size = new System.Drawing.Size(96, 13);
            this.lblEnvironmentType.TabIndex = 5;
            this.lblEnvironmentType.Text = "Environment Type ";
            // 
            // lblCurrentEvent
            // 
            this.lblCurrentEvent.AutoSize = true;
            this.lblCurrentEvent.Location = new System.Drawing.Point(28, 198);
            this.lblCurrentEvent.Name = "lblCurrentEvent";
            this.lblCurrentEvent.Size = new System.Drawing.Size(72, 13);
            this.lblCurrentEvent.TabIndex = 6;
            this.lblCurrentEvent.Text = "Current Event";
            // 
            // lblErase
            // 
            this.lblErase.AutoSize = true;
            this.lblErase.Location = new System.Drawing.Point(12, 428);
            this.lblErase.Name = "lblErase";
            this.lblErase.Size = new System.Drawing.Size(58, 13);
            this.lblErase.TabIndex = 7;
            this.lblErase.Text = "Erase Tool";
            // 
            // lblCellTool
            // 
            this.lblCellTool.AutoSize = true;
            this.lblCellTool.Location = new System.Drawing.Point(146, 428);
            this.lblCellTool.Name = "lblCellTool";
            this.lblCellTool.Size = new System.Drawing.Size(24, 13);
            this.lblCellTool.TabIndex = 8;
            this.lblCellTool.Text = "Cell";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(202, 428);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Colony";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 428);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Virus";
            // 
            // lblAnimalTool
            // 
            this.lblAnimalTool.AutoSize = true;
            this.lblAnimalTool.Location = new System.Drawing.Point(264, 428);
            this.lblAnimalTool.Name = "lblAnimalTool";
            this.lblAnimalTool.Size = new System.Drawing.Size(38, 13);
            this.lblAnimalTool.TabIndex = 11;
            this.lblAnimalTool.Text = "Animal";
            // 
            // lblPlantTool
            // 
            this.lblPlantTool.AutoSize = true;
            this.lblPlantTool.Location = new System.Drawing.Point(321, 428);
            this.lblPlantTool.Name = "lblPlantTool";
            this.lblPlantTool.Size = new System.Drawing.Size(31, 13);
            this.lblPlantTool.TabIndex = 12;
            this.lblPlantTool.Text = "Plant";
            // 
            // btnStart
            // 
            this.btnStart.AutoEllipsis = true;
            this.btnStart.Location = new System.Drawing.Point(211, 93);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(151, 50);
            this.btnStart.TabIndex = 13;
            this.btnStart.Text = "Start Sim!";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(73, 132);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 26);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save State";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbGenNums
            // 
            this.cbGenNums.FormattingEnabled = true;
            this.cbGenNums.Items.AddRange(new object[] {
            "0",
            "0",
            "0",
            "0",
            "0"});
            this.cbGenNums.Location = new System.Drawing.Point(11, 91);
            this.cbGenNums.MaxDropDownItems = 5;
            this.cbGenNums.Name = "cbGenNums";
            this.cbGenNums.Size = new System.Drawing.Size(56, 21);
            this.cbGenNums.TabIndex = 15;
            // 
            // btnLoadPrevGen
            // 
            this.btnLoadPrevGen.Location = new System.Drawing.Point(73, 91);
            this.btnLoadPrevGen.Name = "btnLoadPrevGen";
            this.btnLoadPrevGen.Size = new System.Drawing.Size(106, 35);
            this.btnLoadPrevGen.TabIndex = 16;
            this.btnLoadPrevGen.Text = "Load Previous Generation";
            this.btnLoadPrevGen.UseVisualStyleBackColor = true;
            this.btnLoadPrevGen.Click += new System.EventHandler(this.btnLoadPrevGen_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 508);
            this.Controls.Add(this.btnLoadPrevGen);
            this.Controls.Add(this.cbGenNums);
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
        private System.Windows.Forms.ComboBox cbGenNums;
        private System.Windows.Forms.Button btnLoadPrevGen;
    }
}

