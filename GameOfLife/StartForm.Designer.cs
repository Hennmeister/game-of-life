namespace GameOfLife
{
    partial class StartForm
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
            this.sldFoodAvailability = new System.Windows.Forms.TrackBar();
            this.btnStartRealistic = new System.Windows.Forms.Button();
            this.btnSaveUsername = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.sldWaterAvailability = new System.Windows.Forms.TrackBar();
            this.sldTemperature = new System.Windows.Forms.TrackBar();
            this.sldOxygenLevel = new System.Windows.Forms.TrackBar();
            this.sldCarbonDioxideLevel = new System.Windows.Forms.TrackBar();
            this.btnSetEnvParameters = new System.Windows.Forms.Button();
            this.cbEnvironmentSelection = new System.Windows.Forms.ComboBox();
            this.lblPromptEnvSelection = new System.Windows.Forms.Label();
            this.lblPromptUsername = new System.Windows.Forms.Label();
            this.lblPromptEnvParameters = new System.Windows.Forms.Label();
            this.btnSelectEnvironment = new System.Windows.Forms.Button();
            this.btnStartFree = new System.Windows.Forms.Button();
            this.btnDisplayInstructions = new System.Windows.Forms.Button();
            this.lblPromptExample = new System.Windows.Forms.Label();
            this.cbExamples = new System.Windows.Forms.ComboBox();
            this.btnLoadExample = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sldFoodAvailability)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sldWaterAvailability)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sldTemperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sldOxygenLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sldCarbonDioxideLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // sldFoodAvailability
            // 
            this.sldFoodAvailability.Location = new System.Drawing.Point(641, 120);
            this.sldFoodAvailability.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sldFoodAvailability.Name = "sldFoodAvailability";
            this.sldFoodAvailability.Size = new System.Drawing.Size(129, 56);
            this.sldFoodAvailability.TabIndex = 0;
            this.sldFoodAvailability.Scroll += new System.EventHandler(this.sldFoodAvailability_Scroll);
            this.sldFoodAvailability.CursorChanged += new System.EventHandler(this.sldFoodAvailability_CursorChanged);
            // 
            // btnStartRealistic
            // 
            this.btnStartRealistic.Location = new System.Drawing.Point(60, 120);
            this.btnStartRealistic.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnStartRealistic.Name = "btnStartRealistic";
            this.btnStartRealistic.Size = new System.Drawing.Size(137, 59);
            this.btnStartRealistic.TabIndex = 1;
            this.btnStartRealistic.Text = "Start Realistic Mode";
            this.btnStartRealistic.UseVisualStyleBackColor = true;
            this.btnStartRealistic.Click += new System.EventHandler(this.btnStartRealistic_Click);
            // 
            // btnSaveUsername
            // 
            this.btnSaveUsername.Location = new System.Drawing.Point(380, 170);
            this.btnSaveUsername.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSaveUsername.Name = "btnSaveUsername";
            this.btnSaveUsername.Size = new System.Drawing.Size(104, 39);
            this.btnSaveUsername.TabIndex = 2;
            this.btnSaveUsername.Text = "Save Username";
            this.btnSaveUsername.UseVisualStyleBackColor = true;
            this.btnSaveUsername.Click += new System.EventHandler(this.btnSaveUsername_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(380, 120);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(106, 22);
            this.txtUsername.TabIndex = 3;
            // 
            // sldWaterAvailability
            // 
            this.sldWaterAvailability.Location = new System.Drawing.Point(641, 170);
            this.sldWaterAvailability.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sldWaterAvailability.Name = "sldWaterAvailability";
            this.sldWaterAvailability.Size = new System.Drawing.Size(129, 56);
            this.sldWaterAvailability.TabIndex = 4;
            // 
            // sldTemperature
            // 
            this.sldTemperature.Location = new System.Drawing.Point(641, 225);
            this.sldTemperature.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sldTemperature.Name = "sldTemperature";
            this.sldTemperature.Size = new System.Drawing.Size(129, 56);
            this.sldTemperature.TabIndex = 5;
            // 
            // sldOxygenLevel
            // 
            this.sldOxygenLevel.Location = new System.Drawing.Point(641, 275);
            this.sldOxygenLevel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sldOxygenLevel.Name = "sldOxygenLevel";
            this.sldOxygenLevel.Size = new System.Drawing.Size(129, 56);
            this.sldOxygenLevel.TabIndex = 6;
            // 
            // sldCarbonDioxideLevel
            // 
            this.sldCarbonDioxideLevel.Location = new System.Drawing.Point(641, 337);
            this.sldCarbonDioxideLevel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sldCarbonDioxideLevel.Name = "sldCarbonDioxideLevel";
            this.sldCarbonDioxideLevel.Size = new System.Drawing.Size(129, 56);
            this.sldCarbonDioxideLevel.TabIndex = 7;
            // 
            // btnSetEnvParameters
            // 
            this.btnSetEnvParameters.Location = new System.Drawing.Point(641, 394);
            this.btnSetEnvParameters.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSetEnvParameters.Name = "btnSetEnvParameters";
            this.btnSetEnvParameters.Size = new System.Drawing.Size(122, 54);
            this.btnSetEnvParameters.TabIndex = 8;
            this.btnSetEnvParameters.Text = "Set Parameters";
            this.btnSetEnvParameters.UseVisualStyleBackColor = true;
            this.btnSetEnvParameters.Click += new System.EventHandler(this.btnSetEnvParameters_Click);
            // 
            // cbEnvironmentSelection
            // 
            this.cbEnvironmentSelection.FormattingEnabled = true;
            this.cbEnvironmentSelection.Location = new System.Drawing.Point(384, 275);
            this.cbEnvironmentSelection.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbEnvironmentSelection.Name = "cbEnvironmentSelection";
            this.cbEnvironmentSelection.Size = new System.Drawing.Size(62, 24);
            this.cbEnvironmentSelection.TabIndex = 9;
            // 
            // lblPromptEnvSelection
            // 
            this.lblPromptEnvSelection.AutoSize = true;
            this.lblPromptEnvSelection.Location = new System.Drawing.Point(236, 277);
            this.lblPromptEnvSelection.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPromptEnvSelection.Name = "lblPromptEnvSelection";
            this.lblPromptEnvSelection.Size = new System.Drawing.Size(138, 17);
            this.lblPromptEnvSelection.TabIndex = 10;
            this.lblPromptEnvSelection.Text = "Select Environment: ";
            // 
            // lblPromptUsername
            // 
            this.lblPromptUsername.AutoSize = true;
            this.lblPromptUsername.Location = new System.Drawing.Point(377, 62);
            this.lblPromptUsername.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPromptUsername.Name = "lblPromptUsername";
            this.lblPromptUsername.Size = new System.Drawing.Size(111, 17);
            this.lblPromptUsername.TabIndex = 11;
            this.lblPromptUsername.Text = "Enter Username";
            // 
            // lblPromptEnvParameters
            // 
            this.lblPromptEnvParameters.AutoSize = true;
            this.lblPromptEnvParameters.Location = new System.Drawing.Point(627, 71);
            this.lblPromptEnvParameters.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPromptEnvParameters.Name = "lblPromptEnvParameters";
            this.lblPromptEnvParameters.Size = new System.Drawing.Size(222, 17);
            this.lblPromptEnvParameters.TabIndex = 12;
            this.lblPromptEnvParameters.Text = "Select Environmental Parameters:";
            // 
            // btnSelectEnvironment
            // 
            this.btnSelectEnvironment.Location = new System.Drawing.Point(384, 321);
            this.btnSelectEnvironment.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSelectEnvironment.Name = "btnSelectEnvironment";
            this.btnSelectEnvironment.Size = new System.Drawing.Size(106, 39);
            this.btnSelectEnvironment.TabIndex = 13;
            this.btnSelectEnvironment.Text = "Select Environment";
            this.btnSelectEnvironment.UseVisualStyleBackColor = true;
            this.btnSelectEnvironment.Click += new System.EventHandler(this.btnSelectEnvironment_Click);
            // 
            // btnStartFree
            // 
            this.btnStartFree.Location = new System.Drawing.Point(60, 225);
            this.btnStartFree.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnStartFree.Name = "btnStartFree";
            this.btnStartFree.Size = new System.Drawing.Size(137, 59);
            this.btnStartFree.TabIndex = 14;
            this.btnStartFree.Text = "Start Free Mode";
            this.btnStartFree.UseVisualStyleBackColor = true;
            this.btnStartFree.Click += new System.EventHandler(this.btnStartFree_Click);
            // 
            // btnDisplayInstructions
            // 
            this.btnDisplayInstructions.Location = new System.Drawing.Point(248, 167);
            this.btnDisplayInstructions.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDisplayInstructions.Name = "btnDisplayInstructions";
            this.btnDisplayInstructions.Size = new System.Drawing.Size(105, 53);
            this.btnDisplayInstructions.TabIndex = 15;
            this.btnDisplayInstructions.Text = "Show Instructions";
            this.btnDisplayInstructions.UseVisualStyleBackColor = true;
            // 
            // lblPromptExample
            // 
            this.lblPromptExample.AutoSize = true;
            this.lblPromptExample.Location = new System.Drawing.Point(236, 394);
            this.lblPromptExample.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPromptExample.Name = "lblPromptExample";
            this.lblPromptExample.Size = new System.Drawing.Size(101, 17);
            this.lblPromptExample.TabIndex = 16;
            this.lblPromptExample.Text = "Load Example:";
            // 
            // cbExamples
            // 
            this.cbExamples.FormattingEnabled = true;
            this.cbExamples.Items.AddRange(new object[] {
            "Example 1",
            "Example 2",
            "Example 3"});
            this.cbExamples.Location = new System.Drawing.Point(384, 394);
            this.cbExamples.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbExamples.Name = "cbExamples";
            this.cbExamples.Size = new System.Drawing.Size(62, 24);
            this.cbExamples.TabIndex = 17;
            // 
            // btnLoadExample
            // 
            this.btnLoadExample.Location = new System.Drawing.Point(384, 437);
            this.btnLoadExample.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLoadExample.Name = "btnLoadExample";
            this.btnLoadExample.Size = new System.Drawing.Size(106, 39);
            this.btnLoadExample.TabIndex = 18;
            this.btnLoadExample.Text = "Load Example";
            this.btnLoadExample.UseVisualStyleBackColor = true;
            this.btnLoadExample.Click += new System.EventHandler(this.btnLoadExample_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 507);
            this.Controls.Add(this.btnLoadExample);
            this.Controls.Add(this.cbExamples);
            this.Controls.Add(this.lblPromptExample);
            this.Controls.Add(this.btnDisplayInstructions);
            this.Controls.Add(this.btnStartFree);
            this.Controls.Add(this.btnSelectEnvironment);
            this.Controls.Add(this.lblPromptEnvParameters);
            this.Controls.Add(this.lblPromptUsername);
            this.Controls.Add(this.lblPromptEnvSelection);
            this.Controls.Add(this.cbEnvironmentSelection);
            this.Controls.Add(this.btnSetEnvParameters);
            this.Controls.Add(this.sldCarbonDioxideLevel);
            this.Controls.Add(this.sldOxygenLevel);
            this.Controls.Add(this.sldTemperature);
            this.Controls.Add(this.sldWaterAvailability);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.btnSaveUsername);
            this.Controls.Add(this.btnStartRealistic);
            this.Controls.Add(this.sldFoodAvailability);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "StartForm";
            this.Text = "StartForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StartForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.sldFoodAvailability)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sldWaterAvailability)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sldTemperature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sldOxygenLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sldCarbonDioxideLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TrackBar sldFoodAvailability;
        private System.Windows.Forms.Button btnStartRealistic;
        private System.Windows.Forms.Button btnSaveUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TrackBar sldWaterAvailability;
        private System.Windows.Forms.TrackBar sldTemperature;
        private System.Windows.Forms.TrackBar sldOxygenLevel;
        private System.Windows.Forms.TrackBar sldCarbonDioxideLevel;
        private System.Windows.Forms.Button btnSetEnvParameters;
        private System.Windows.Forms.ComboBox cbEnvironmentSelection;
        private System.Windows.Forms.Label lblPromptEnvSelection;
        private System.Windows.Forms.Label lblPromptUsername;
        private System.Windows.Forms.Label lblPromptEnvParameters;
        private System.Windows.Forms.Button btnSelectEnvironment;
        private System.Windows.Forms.Button btnStartFree;
        private System.Windows.Forms.Button btnDisplayInstructions;
        private System.Windows.Forms.Label lblPromptExample;
        private System.Windows.Forms.ComboBox cbExamples;
        private System.Windows.Forms.Button btnLoadExample;
    }
}