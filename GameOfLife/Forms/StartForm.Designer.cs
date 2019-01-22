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
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.sldWaterAvailability = new System.Windows.Forms.TrackBar();
            this.sldTemperature = new System.Windows.Forms.TrackBar();
            this.sldOxygenLevel = new System.Windows.Forms.TrackBar();
            this.sldCarbonDioxideLevel = new System.Windows.Forms.TrackBar();
            this.cbEnvironmentSelection = new System.Windows.Forms.ComboBox();
            this.lblPromptEnvSelection = new System.Windows.Forms.Label();
            this.lblPromptUsername = new System.Windows.Forms.Label();
            this.lblPromptEnvParameters = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnDisplayInstructions = new System.Windows.Forms.Button();
            this.lblPromptExample = new System.Windows.Forms.Label();
            this.cbExamples = new System.Windows.Forms.ComboBox();
            this.btnLoadExample = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblFoodSlider = new System.Windows.Forms.Label();
            this.lblTempSlider = new System.Windows.Forms.Label();
            this.lblOxygenSlider = new System.Windows.Forms.Label();
            this.lblCarbonDioxideSlider = new System.Windows.Forms.Label();
            this.lblMinFood = new System.Windows.Forms.Label();
            this.lblMaxFood = new System.Windows.Forms.Label();
            this.lblCurrFood = new System.Windows.Forms.Label();
            this.lblWaterSlider = new System.Windows.Forms.Label();
            this.lblCurrWater = new System.Windows.Forms.Label();
            this.lblCurrTemp = new System.Windows.Forms.Label();
            this.lblCurrOxygen = new System.Windows.Forms.Label();
            this.lblCurrCarbonDioxide = new System.Windows.Forms.Label();
            this.lblMinWater = new System.Windows.Forms.Label();
            this.lblMinTemp = new System.Windows.Forms.Label();
            this.lblMinOxygen = new System.Windows.Forms.Label();
            this.lblMinCarbonDioxide = new System.Windows.Forms.Label();
            this.lblMaxWater = new System.Windows.Forms.Label();
            this.lblMaxTemp = new System.Windows.Forms.Label();
            this.lblMaxOxygen = new System.Windows.Forms.Label();
            this.lblMaxCarbonDioxide = new System.Windows.Forms.Label();
            this.btnLoadState = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sldFoodAvailability)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sldWaterAvailability)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sldTemperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sldOxygenLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sldCarbonDioxideLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // sldFoodAvailability
            // 
            this.sldFoodAvailability.Location = new System.Drawing.Point(546, 158);
            this.sldFoodAvailability.Margin = new System.Windows.Forms.Padding(2);
            this.sldFoodAvailability.Name = "sldFoodAvailability";
            this.sldFoodAvailability.Size = new System.Drawing.Size(97, 45);
            this.sldFoodAvailability.TabIndex = 0;
            this.sldFoodAvailability.Scroll += new System.EventHandler(this.sldFoodAvailability_Scroll);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(177, 119);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(100, 20);
            this.txtUsername.TabIndex = 3;
            this.txtUsername.Text = "h";
            // 
            // sldWaterAvailability
            // 
            this.sldWaterAvailability.Location = new System.Drawing.Point(546, 227);
            this.sldWaterAvailability.Margin = new System.Windows.Forms.Padding(2);
            this.sldWaterAvailability.Name = "sldWaterAvailability";
            this.sldWaterAvailability.Size = new System.Drawing.Size(97, 45);
            this.sldWaterAvailability.TabIndex = 4;
            this.sldWaterAvailability.Scroll += new System.EventHandler(this.sldWaterAvailability_Scroll);
            // 
            // sldTemperature
            // 
            this.sldTemperature.Location = new System.Drawing.Point(546, 294);
            this.sldTemperature.Margin = new System.Windows.Forms.Padding(2);
            this.sldTemperature.Name = "sldTemperature";
            this.sldTemperature.Size = new System.Drawing.Size(97, 45);
            this.sldTemperature.TabIndex = 5;
            this.sldTemperature.Scroll += new System.EventHandler(this.sldTemperature_Scroll);
            // 
            // sldOxygenLevel
            // 
            this.sldOxygenLevel.Location = new System.Drawing.Point(546, 359);
            this.sldOxygenLevel.Margin = new System.Windows.Forms.Padding(2);
            this.sldOxygenLevel.Name = "sldOxygenLevel";
            this.sldOxygenLevel.Size = new System.Drawing.Size(97, 45);
            this.sldOxygenLevel.TabIndex = 6;
            this.sldOxygenLevel.Scroll += new System.EventHandler(this.sldOxygenLevel_Scroll);
            // 
            // sldCarbonDioxideLevel
            // 
            this.sldCarbonDioxideLevel.Location = new System.Drawing.Point(546, 430);
            this.sldCarbonDioxideLevel.Margin = new System.Windows.Forms.Padding(2);
            this.sldCarbonDioxideLevel.Name = "sldCarbonDioxideLevel";
            this.sldCarbonDioxideLevel.Size = new System.Drawing.Size(97, 45);
            this.sldCarbonDioxideLevel.TabIndex = 7;
            this.sldCarbonDioxideLevel.Scroll += new System.EventHandler(this.sldCarbonDioxideLevel_Scroll);
            // 
            // cbEnvironmentSelection
            // 
            this.cbEnvironmentSelection.FormattingEnabled = true;
            this.cbEnvironmentSelection.Location = new System.Drawing.Point(177, 176);
            this.cbEnvironmentSelection.Margin = new System.Windows.Forms.Padding(2);
            this.cbEnvironmentSelection.Name = "cbEnvironmentSelection";
            this.cbEnvironmentSelection.Size = new System.Drawing.Size(100, 21);
            this.cbEnvironmentSelection.TabIndex = 9;
            this.cbEnvironmentSelection.SelectedIndexChanged += new System.EventHandler(this.cbEnvironmentSelection_SelectedIndexChanged);
            // 
            // lblPromptEnvSelection
            // 
            this.lblPromptEnvSelection.AutoSize = true;
            this.lblPromptEnvSelection.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblPromptEnvSelection.Location = new System.Drawing.Point(174, 161);
            this.lblPromptEnvSelection.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPromptEnvSelection.Name = "lblPromptEnvSelection";
            this.lblPromptEnvSelection.Size = new System.Drawing.Size(66, 13);
            this.lblPromptEnvSelection.TabIndex = 10;
            this.lblPromptEnvSelection.Text = "Environment";
            // 
            // lblPromptUsername
            // 
            this.lblPromptUsername.AutoSize = true;
            this.lblPromptUsername.Location = new System.Drawing.Point(174, 104);
            this.lblPromptUsername.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPromptUsername.Name = "lblPromptUsername";
            this.lblPromptUsername.Size = new System.Drawing.Size(55, 13);
            this.lblPromptUsername.TabIndex = 11;
            this.lblPromptUsername.Text = "Username";
            // 
            // lblPromptEnvParameters
            // 
            this.lblPromptEnvParameters.AutoSize = true;
            this.lblPromptEnvParameters.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPromptEnvParameters.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblPromptEnvParameters.Location = new System.Drawing.Point(439, 109);
            this.lblPromptEnvParameters.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPromptEnvParameters.Name = "lblPromptEnvParameters";
            this.lblPromptEnvParameters.Size = new System.Drawing.Size(210, 20);
            this.lblPromptEnvParameters.TabIndex = 12;
            this.lblPromptEnvParameters.Text = "Enviromental Parameters";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(21, 374);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(110, 40);
            this.btnStart.TabIndex = 14;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnDisplayInstructions
            // 
            this.btnDisplayInstructions.Location = new System.Drawing.Point(21, 87);
            this.btnDisplayInstructions.Margin = new System.Windows.Forms.Padding(2);
            this.btnDisplayInstructions.Name = "btnDisplayInstructions";
            this.btnDisplayInstructions.Size = new System.Drawing.Size(110, 40);
            this.btnDisplayInstructions.TabIndex = 15;
            this.btnDisplayInstructions.Text = "Show Instructions";
            this.btnDisplayInstructions.UseVisualStyleBackColor = true;
            this.btnDisplayInstructions.Click += new System.EventHandler(this.btnDisplayInstructions_Click);
            // 
            // lblPromptExample
            // 
            this.lblPromptExample.AutoSize = true;
            this.lblPromptExample.Location = new System.Drawing.Point(143, 418);
            this.lblPromptExample.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPromptExample.Name = "lblPromptExample";
            this.lblPromptExample.Size = new System.Drawing.Size(77, 13);
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
            this.cbExamples.Location = new System.Drawing.Point(146, 433);
            this.cbExamples.Margin = new System.Windows.Forms.Padding(2);
            this.cbExamples.Name = "cbExamples";
            this.cbExamples.Size = new System.Drawing.Size(100, 21);
            this.cbExamples.TabIndex = 17;
            // 
            // btnLoadExample
            // 
            this.btnLoadExample.Location = new System.Drawing.Point(146, 374);
            this.btnLoadExample.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoadExample.Name = "btnLoadExample";
            this.btnLoadExample.Size = new System.Drawing.Size(110, 40);
            this.btnLoadExample.TabIndex = 18;
            this.btnLoadExample.Text = "Load Example";
            this.btnLoadExample.UseVisualStyleBackColor = true;
            this.btnLoadExample.Click += new System.EventHandler(this.btnLoadExample_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(11, 20);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(587, 55);
            this.lblTitle.TabIndex = 19;
            this.lblTitle.Text = "Welcome to Game of Life";
            // 
            // lblFoodSlider
            // 
            this.lblFoodSlider.AutoSize = true;
            this.lblFoodSlider.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFoodSlider.Location = new System.Drawing.Point(420, 161);
            this.lblFoodSlider.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFoodSlider.Name = "lblFoodSlider";
            this.lblFoodSlider.Size = new System.Drawing.Size(35, 13);
            this.lblFoodSlider.TabIndex = 21;
            this.lblFoodSlider.Text = "Food";
            // 
            // lblTempSlider
            // 
            this.lblTempSlider.AutoSize = true;
            this.lblTempSlider.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTempSlider.Location = new System.Drawing.Point(402, 294);
            this.lblTempSlider.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTempSlider.Name = "lblTempSlider";
            this.lblTempSlider.Size = new System.Drawing.Size(78, 13);
            this.lblTempSlider.TabIndex = 22;
            this.lblTempSlider.Text = "Temperature";
            // 
            // lblOxygenSlider
            // 
            this.lblOxygenSlider.AutoSize = true;
            this.lblOxygenSlider.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblOxygenSlider.Location = new System.Drawing.Point(402, 359);
            this.lblOxygenSlider.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOxygenSlider.Name = "lblOxygenSlider";
            this.lblOxygenSlider.Size = new System.Drawing.Size(87, 26);
            this.lblOxygenSlider.TabIndex = 23;
            this.lblOxygenSlider.Text = "% Oxygen\r\nin Atmosphere";
            // 
            // lblCarbonDioxideSlider
            // 
            this.lblCarbonDioxideSlider.AutoSize = true;
            this.lblCarbonDioxideSlider.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblCarbonDioxideSlider.Location = new System.Drawing.Point(402, 430);
            this.lblCarbonDioxideSlider.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCarbonDioxideSlider.Name = "lblCarbonDioxideSlider";
            this.lblCarbonDioxideSlider.Size = new System.Drawing.Size(106, 26);
            this.lblCarbonDioxideSlider.TabIndex = 24;
            this.lblCarbonDioxideSlider.Text = "% Carbon Dioxide\r\nin Atmosphere";
            // 
            // lblMinFood
            // 
            this.lblMinFood.AutoSize = true;
            this.lblMinFood.Location = new System.Drawing.Point(519, 161);
            this.lblMinFood.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMinFood.Name = "lblMinFood";
            this.lblMinFood.Size = new System.Drawing.Size(23, 13);
            this.lblMinFood.TabIndex = 25;
            this.lblMinFood.Text = "min";
            // 
            // lblMaxFood
            // 
            this.lblMaxFood.AutoSize = true;
            this.lblMaxFood.Location = new System.Drawing.Point(641, 161);
            this.lblMaxFood.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMaxFood.Name = "lblMaxFood";
            this.lblMaxFood.Size = new System.Drawing.Size(26, 13);
            this.lblMaxFood.TabIndex = 26;
            this.lblMaxFood.Text = "max";
            // 
            // lblCurrFood
            // 
            this.lblCurrFood.AutoSize = true;
            this.lblCurrFood.Location = new System.Drawing.Point(585, 143);
            this.lblCurrFood.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCurrFood.Name = "lblCurrFood";
            this.lblCurrFood.Size = new System.Drawing.Size(40, 13);
            this.lblCurrFood.TabIndex = 27;
            this.lblCurrFood.Text = "current";
            // 
            // lblWaterSlider
            // 
            this.lblWaterSlider.AutoSize = true;
            this.lblWaterSlider.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaterSlider.Location = new System.Drawing.Point(420, 227);
            this.lblWaterSlider.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWaterSlider.Name = "lblWaterSlider";
            this.lblWaterSlider.Size = new System.Drawing.Size(41, 13);
            this.lblWaterSlider.TabIndex = 28;
            this.lblWaterSlider.Text = "Water";
            // 
            // lblCurrWater
            // 
            this.lblCurrWater.AutoSize = true;
            this.lblCurrWater.Location = new System.Drawing.Point(582, 212);
            this.lblCurrWater.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCurrWater.Name = "lblCurrWater";
            this.lblCurrWater.Size = new System.Drawing.Size(40, 13);
            this.lblCurrWater.TabIndex = 29;
            this.lblCurrWater.Text = "current";
            // 
            // lblCurrTemp
            // 
            this.lblCurrTemp.AutoSize = true;
            this.lblCurrTemp.Location = new System.Drawing.Point(582, 274);
            this.lblCurrTemp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCurrTemp.Name = "lblCurrTemp";
            this.lblCurrTemp.Size = new System.Drawing.Size(40, 13);
            this.lblCurrTemp.TabIndex = 30;
            this.lblCurrTemp.Text = "current";
            // 
            // lblCurrOxygen
            // 
            this.lblCurrOxygen.AutoSize = true;
            this.lblCurrOxygen.Location = new System.Drawing.Point(582, 344);
            this.lblCurrOxygen.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCurrOxygen.Name = "lblCurrOxygen";
            this.lblCurrOxygen.Size = new System.Drawing.Size(40, 13);
            this.lblCurrOxygen.TabIndex = 31;
            this.lblCurrOxygen.Text = "current";
            // 
            // lblCurrCarbonDioxide
            // 
            this.lblCurrCarbonDioxide.AutoSize = true;
            this.lblCurrCarbonDioxide.Location = new System.Drawing.Point(582, 415);
            this.lblCurrCarbonDioxide.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCurrCarbonDioxide.Name = "lblCurrCarbonDioxide";
            this.lblCurrCarbonDioxide.Size = new System.Drawing.Size(40, 13);
            this.lblCurrCarbonDioxide.TabIndex = 32;
            this.lblCurrCarbonDioxide.Text = "current";
            // 
            // lblMinWater
            // 
            this.lblMinWater.AutoSize = true;
            this.lblMinWater.Location = new System.Drawing.Point(512, 227);
            this.lblMinWater.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMinWater.Name = "lblMinWater";
            this.lblMinWater.Size = new System.Drawing.Size(23, 13);
            this.lblMinWater.TabIndex = 33;
            this.lblMinWater.Text = "min";
            // 
            // lblMinTemp
            // 
            this.lblMinTemp.AutoSize = true;
            this.lblMinTemp.Location = new System.Drawing.Point(519, 294);
            this.lblMinTemp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMinTemp.Name = "lblMinTemp";
            this.lblMinTemp.Size = new System.Drawing.Size(23, 13);
            this.lblMinTemp.TabIndex = 34;
            this.lblMinTemp.Text = "min";
            // 
            // lblMinOxygen
            // 
            this.lblMinOxygen.AutoSize = true;
            this.lblMinOxygen.Location = new System.Drawing.Point(519, 359);
            this.lblMinOxygen.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMinOxygen.Name = "lblMinOxygen";
            this.lblMinOxygen.Size = new System.Drawing.Size(23, 13);
            this.lblMinOxygen.TabIndex = 35;
            this.lblMinOxygen.Text = "min";
            // 
            // lblMinCarbonDioxide
            // 
            this.lblMinCarbonDioxide.AutoSize = true;
            this.lblMinCarbonDioxide.Location = new System.Drawing.Point(521, 430);
            this.lblMinCarbonDioxide.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMinCarbonDioxide.Name = "lblMinCarbonDioxide";
            this.lblMinCarbonDioxide.Size = new System.Drawing.Size(23, 13);
            this.lblMinCarbonDioxide.TabIndex = 36;
            this.lblMinCarbonDioxide.Text = "min";
            // 
            // lblMaxWater
            // 
            this.lblMaxWater.AutoSize = true;
            this.lblMaxWater.Location = new System.Drawing.Point(641, 227);
            this.lblMaxWater.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMaxWater.Name = "lblMaxWater";
            this.lblMaxWater.Size = new System.Drawing.Size(26, 13);
            this.lblMaxWater.TabIndex = 37;
            this.lblMaxWater.Text = "max";
            // 
            // lblMaxTemp
            // 
            this.lblMaxTemp.AutoSize = true;
            this.lblMaxTemp.Location = new System.Drawing.Point(641, 294);
            this.lblMaxTemp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMaxTemp.Name = "lblMaxTemp";
            this.lblMaxTemp.Size = new System.Drawing.Size(26, 13);
            this.lblMaxTemp.TabIndex = 38;
            this.lblMaxTemp.Text = "max";
            // 
            // lblMaxOxygen
            // 
            this.lblMaxOxygen.AutoSize = true;
            this.lblMaxOxygen.Location = new System.Drawing.Point(641, 359);
            this.lblMaxOxygen.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMaxOxygen.Name = "lblMaxOxygen";
            this.lblMaxOxygen.Size = new System.Drawing.Size(26, 13);
            this.lblMaxOxygen.TabIndex = 39;
            this.lblMaxOxygen.Text = "max";
            // 
            // lblMaxCarbonDioxide
            // 
            this.lblMaxCarbonDioxide.AutoSize = true;
            this.lblMaxCarbonDioxide.Location = new System.Drawing.Point(641, 430);
            this.lblMaxCarbonDioxide.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMaxCarbonDioxide.Name = "lblMaxCarbonDioxide";
            this.lblMaxCarbonDioxide.Size = new System.Drawing.Size(26, 13);
            this.lblMaxCarbonDioxide.TabIndex = 40;
            this.lblMaxCarbonDioxide.Text = "max";
            // 
            // btnLoadState
            // 
            this.btnLoadState.Location = new System.Drawing.Point(260, 374);
            this.btnLoadState.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoadState.Name = "btnLoadState";
            this.btnLoadState.Size = new System.Drawing.Size(74, 40);
            this.btnLoadState.TabIndex = 41;
            this.btnLoadState.Text = "Load";
            this.btnLoadState.UseVisualStyleBackColor = true;
            this.btnLoadState.Click += new System.EventHandler(this.btnLoadState_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 486);
            this.Controls.Add(this.btnLoadState);
            this.Controls.Add(this.lblMaxCarbonDioxide);
            this.Controls.Add(this.lblMaxOxygen);
            this.Controls.Add(this.lblMaxTemp);
            this.Controls.Add(this.lblMaxWater);
            this.Controls.Add(this.lblMinCarbonDioxide);
            this.Controls.Add(this.lblMinOxygen);
            this.Controls.Add(this.lblMinTemp);
            this.Controls.Add(this.lblMinWater);
            this.Controls.Add(this.lblCurrCarbonDioxide);
            this.Controls.Add(this.lblCurrOxygen);
            this.Controls.Add(this.lblCurrTemp);
            this.Controls.Add(this.lblCurrWater);
            this.Controls.Add(this.lblWaterSlider);
            this.Controls.Add(this.lblCurrFood);
            this.Controls.Add(this.lblMaxFood);
            this.Controls.Add(this.lblMinFood);
            this.Controls.Add(this.lblCarbonDioxideSlider);
            this.Controls.Add(this.lblOxygenSlider);
            this.Controls.Add(this.lblTempSlider);
            this.Controls.Add(this.lblFoodSlider);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnLoadExample);
            this.Controls.Add(this.cbExamples);
            this.Controls.Add(this.lblPromptExample);
            this.Controls.Add(this.btnDisplayInstructions);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblPromptEnvParameters);
            this.Controls.Add(this.lblPromptUsername);
            this.Controls.Add(this.lblPromptEnvSelection);
            this.Controls.Add(this.cbEnvironmentSelection);
            this.Controls.Add(this.sldCarbonDioxideLevel);
            this.Controls.Add(this.sldOxygenLevel);
            this.Controls.Add(this.sldTemperature);
            this.Controls.Add(this.sldWaterAvailability);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.sldFoodAvailability);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(735, 525);
            this.MinimumSize = new System.Drawing.Size(735, 525);
            this.Name = "StartForm";
            this.Text = "StartForm";
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
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TrackBar sldWaterAvailability;
        private System.Windows.Forms.TrackBar sldTemperature;
        private System.Windows.Forms.TrackBar sldOxygenLevel;
        private System.Windows.Forms.TrackBar sldCarbonDioxideLevel;
        private System.Windows.Forms.ComboBox cbEnvironmentSelection;
        private System.Windows.Forms.Label lblPromptEnvSelection;
        private System.Windows.Forms.Label lblPromptUsername;
        private System.Windows.Forms.Label lblPromptEnvParameters;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnDisplayInstructions;
        private System.Windows.Forms.Label lblPromptExample;
        private System.Windows.Forms.ComboBox cbExamples;
        private System.Windows.Forms.Button btnLoadExample;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFoodSlider;
        private System.Windows.Forms.Label lblTempSlider;
        private System.Windows.Forms.Label lblOxygenSlider;
        private System.Windows.Forms.Label lblCarbonDioxideSlider;
        private System.Windows.Forms.Label lblMinFood;
        private System.Windows.Forms.Label lblMaxFood;
        private System.Windows.Forms.Label lblCurrFood;
        private System.Windows.Forms.Label lblWaterSlider;
        private System.Windows.Forms.Label lblCurrWater;
        private System.Windows.Forms.Label lblCurrTemp;
        private System.Windows.Forms.Label lblCurrOxygen;
        private System.Windows.Forms.Label lblCurrCarbonDioxide;
        private System.Windows.Forms.Label lblMinWater;
        private System.Windows.Forms.Label lblMinTemp;
        private System.Windows.Forms.Label lblMinOxygen;
        private System.Windows.Forms.Label lblMinCarbonDioxide;
        private System.Windows.Forms.Label lblMaxWater;
        private System.Windows.Forms.Label lblMaxTemp;
        private System.Windows.Forms.Label lblMaxOxygen;
        private System.Windows.Forms.Label lblMaxCarbonDioxide;
        private System.Windows.Forms.Button btnLoadState;
    }
}