using System;

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
            this.picEvent = new System.Windows.Forms.PictureBox();
            this.txtSessionName = new System.Windows.Forms.TextBox();
            this.lblPromptSessionName = new System.Windows.Forms.Label();
            this.btnConfirmSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picEvent)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrGeneration
            // 
            this.tmrGeneration.Interval = 200;
            this.tmrGeneration.Tick += new System.EventHandler(this.tmrGeneration_Tick);
            // 
            // lblGenNum
            // 
            this.lblGenNum.AutoSize = true;
            this.lblGenNum.Location = new System.Drawing.Point(59, 789);
            this.lblGenNum.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblGenNum.Name = "lblGenNum";
            this.lblGenNum.Size = new System.Drawing.Size(183, 32);
            this.lblGenNum.TabIndex = 0;
            this.lblGenNum.Text = "GEN Number";
            // 
            // lblCurrScore
            // 
            this.lblCurrScore.AutoSize = true;
            this.lblCurrScore.Location = new System.Drawing.Point(59, 842);
            this.lblCurrScore.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblCurrScore.Name = "lblCurrScore";
            this.lblCurrScore.Size = new System.Drawing.Size(145, 32);
            this.lblCurrScore.TabIndex = 1;
            this.lblCurrScore.Text = "Curr score";
            // 
            // lblHighestConcurrentScore
            // 
            this.lblHighestConcurrentScore.AutoSize = true;
            this.lblHighestConcurrentScore.Location = new System.Drawing.Point(59, 904);
            this.lblHighestConcurrentScore.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblHighestConcurrentScore.Name = "lblHighestConcurrentScore";
            this.lblHighestConcurrentScore.Size = new System.Drawing.Size(329, 32);
            this.lblHighestConcurrentScore.TabIndex = 2;
            this.lblHighestConcurrentScore.Text = "Highest concurrent score";
            // 
            // lblEnvParams
            // 
            this.lblEnvParams.AutoSize = true;
            this.lblEnvParams.Location = new System.Drawing.Point(75, 486);
            this.lblEnvParams.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblEnvParams.Name = "lblEnvParams";
            this.lblEnvParams.Size = new System.Drawing.Size(168, 32);
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
            this.lblTitle.Location = new System.Drawing.Point(40, 48);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(754, 135);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Game of Life";
            // 
            // lblEnvironmentType
            // 
            this.lblEnvironmentType.AutoSize = true;
            this.lblEnvironmentType.Location = new System.Drawing.Point(75, 413);
            this.lblEnvironmentType.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblEnvironmentType.Name = "lblEnvironmentType";
            this.lblEnvironmentType.Size = new System.Drawing.Size(252, 32);
            this.lblEnvironmentType.TabIndex = 5;
            this.lblEnvironmentType.Text = "Environment Type ";
            // 
            // lblCurrentEvent
            // 
            this.lblCurrentEvent.AutoSize = true;
            this.lblCurrentEvent.Location = new System.Drawing.Point(880, 327);
            this.lblCurrentEvent.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblCurrentEvent.Name = "lblCurrentEvent";
            this.lblCurrentEvent.Size = new System.Drawing.Size(189, 32);
            this.lblCurrentEvent.TabIndex = 6;
            this.lblCurrentEvent.Text = "Current Event";
            // 
            // lblErase
            // 
            this.lblErase.AutoSize = true;
            this.lblErase.Location = new System.Drawing.Point(32, 1021);
            this.lblErase.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblErase.Name = "lblErase";
            this.lblErase.Size = new System.Drawing.Size(152, 32);
            this.lblErase.TabIndex = 7;
            this.lblErase.Text = "Erase Tool";
            // 
            // lblCellTool
            // 
            this.lblCellTool.AutoSize = true;
            this.lblCellTool.Location = new System.Drawing.Point(389, 1021);
            this.lblCellTool.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblCellTool.Name = "lblCellTool";
            this.lblCellTool.Size = new System.Drawing.Size(65, 32);
            this.lblCellTool.TabIndex = 8;
            this.lblCellTool.Text = "Cell";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(539, 1021);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 32);
            this.label1.TabIndex = 9;
            this.label1.Text = "Colony";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(229, 1021);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 32);
            this.label2.TabIndex = 10;
            this.label2.Text = "Virus";
            // 
            // lblAnimalTool
            // 
            this.lblAnimalTool.AutoSize = true;
            this.lblAnimalTool.Location = new System.Drawing.Point(704, 1021);
            this.lblAnimalTool.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblAnimalTool.Name = "lblAnimalTool";
            this.lblAnimalTool.Size = new System.Drawing.Size(103, 32);
            this.lblAnimalTool.TabIndex = 11;
            this.lblAnimalTool.Text = "Animal";
            // 
            // lblPlantTool
            // 
            this.lblPlantTool.AutoSize = true;
            this.lblPlantTool.Location = new System.Drawing.Point(856, 1021);
            this.lblPlantTool.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblPlantTool.Name = "lblPlantTool";
            this.lblPlantTool.Size = new System.Drawing.Size(81, 32);
            this.lblPlantTool.TabIndex = 12;
            this.lblPlantTool.Text = "Plant";
            // 
            // btnStart
            // 
            this.btnStart.AutoEllipsis = true;
            this.btnStart.Location = new System.Drawing.Point(373, 186);
            this.btnStart.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(400, 76);
            this.btnStart.TabIndex = 13;
            this.btnStart.Text = "Start Sim!";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.Location = new System.Drawing.Point(813, 682);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(149, 74);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
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
            this.cbGenNums.Location = new System.Drawing.Point(21, 203);
            this.cbGenNums.Margin = new System.Windows.Forms.Padding(5);
            this.cbGenNums.MaxDropDownItems = 5;
            this.cbGenNums.Name = "cbGenNums";
            this.cbGenNums.Size = new System.Drawing.Size(108, 39);
            this.cbGenNums.TabIndex = 15;
            // 
            // btnLoadPrevGen
            // 
            this.btnLoadPrevGen.Location = new System.Drawing.Point(147, 191);
            this.btnLoadPrevGen.Margin = new System.Windows.Forms.Padding(5);
            this.btnLoadPrevGen.Name = "btnLoadPrevGen";
            this.btnLoadPrevGen.Size = new System.Drawing.Size(213, 85);
            this.btnLoadPrevGen.TabIndex = 16;
            this.btnLoadPrevGen.Text = "Load Previous Generation";
            this.btnLoadPrevGen.UseVisualStyleBackColor = true;
            this.btnLoadPrevGen.Click += new System.EventHandler(this.btnLoadPrevGen_Click);
            // 
            // picEvent
            // 
            this.picEvent.Location = new System.Drawing.Point(813, 176);
            this.picEvent.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.picEvent.Name = "picEvent";
            this.picEvent.Size = new System.Drawing.Size(296, 143);
            this.picEvent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picEvent.TabIndex = 16;
            this.picEvent.TabStop = false;
            // 
            // txtSessionName
            // 
            this.txtSessionName.Location = new System.Drawing.Point(772, 789);
            this.txtSessionName.Name = "txtSessionName";
            this.txtSessionName.Size = new System.Drawing.Size(190, 38);
            this.txtSessionName.TabIndex = 17;
            // 
            // lblPromptSessionName
            // 
            this.lblPromptSessionName.AutoSize = true;
            this.lblPromptSessionName.Location = new System.Drawing.Point(539, 792);
            this.lblPromptSessionName.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblPromptSessionName.Name = "lblPromptSessionName";
            this.lblPromptSessionName.Size = new System.Drawing.Size(207, 32);
            this.lblPromptSessionName.TabIndex = 18;
            this.lblPromptSessionName.Text = "Session Name:";
            // 
            // btnConfirmSave
            // 
            this.btnConfirmSave.AutoSize = true;
            this.btnConfirmSave.Location = new System.Drawing.Point(813, 862);
            this.btnConfirmSave.Margin = new System.Windows.Forms.Padding(5);
            this.btnConfirmSave.Name = "btnConfirmSave";
            this.btnConfirmSave.Size = new System.Drawing.Size(149, 74);
            this.btnConfirmSave.TabIndex = 19;
            this.btnConfirmSave.Text = "OK";
            this.btnConfirmSave.UseVisualStyleBackColor = true;
            this.btnConfirmSave.Click += new System.EventHandler(this.btnConfirmSave_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2499, 1211);
            this.Controls.Add(this.btnConfirmSave);
            this.Controls.Add(this.lblPromptSessionName);
            this.Controls.Add(this.txtSessionName);
            this.Controls.Add(this.picEvent);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GameForm";
            this.Text = "Form1";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GameForm_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.picEvent)).EndInit();
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
        private System.Windows.Forms.PictureBox picEvent;
        private System.Windows.Forms.TextBox txtSessionName;
        private System.Windows.Forms.Label lblPromptSessionName;
        private System.Windows.Forms.Button btnConfirmSave;
    }
}

