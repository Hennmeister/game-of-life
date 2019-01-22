namespace GameOfLife
{
    partial class InstructionsForm
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
            this.txtInstructions = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnGeneral = new System.Windows.Forms.Button();
            this.btnVirus = new System.Windows.Forms.Button();
            this.btnCell = new System.Windows.Forms.Button();
            this.btnColony = new System.Windows.Forms.Button();
            this.btnAnimal = new System.Windows.Forms.Button();
            this.btnPlant = new System.Windows.Forms.Button();
            this.btnEnvironment = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtInstructions
            // 
            this.txtInstructions.Location = new System.Drawing.Point(49, 140);
            this.txtInstructions.Margin = new System.Windows.Forms.Padding(1);
            this.txtInstructions.Multiline = true;
            this.txtInstructions.Name = "txtInstructions";
            this.txtInstructions.ReadOnly = true;
            this.txtInstructions.Size = new System.Drawing.Size(605, 233);
            this.txtInstructions.TabIndex = 0;
            this.txtInstructions.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(11, 19);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(281, 55);
            this.lblTitle.TabIndex = 20;
            this.lblTitle.Text = "Instructions";
            // 
            // btnGeneral
            // 
            this.btnGeneral.Location = new System.Drawing.Point(21, 77);
            this.btnGeneral.Name = "btnGeneral";
            this.btnGeneral.Size = new System.Drawing.Size(91, 44);
            this.btnGeneral.TabIndex = 21;
            this.btnGeneral.Text = "General Rules";
            this.btnGeneral.UseVisualStyleBackColor = true;
            this.btnGeneral.Click += new System.EventHandler(this.btnGeneral_Click);
            // 
            // btnVirus
            // 
            this.btnVirus.Location = new System.Drawing.Point(213, 77);
            this.btnVirus.Name = "btnVirus";
            this.btnVirus.Size = new System.Drawing.Size(91, 44);
            this.btnVirus.TabIndex = 22;
            this.btnVirus.Text = "Viruses";
            this.btnVirus.UseVisualStyleBackColor = true;
            this.btnVirus.Click += new System.EventHandler(this.btnVirus_Click);
            // 
            // btnCell
            // 
            this.btnCell.Location = new System.Drawing.Point(310, 77);
            this.btnCell.Name = "btnCell";
            this.btnCell.Size = new System.Drawing.Size(91, 44);
            this.btnCell.TabIndex = 23;
            this.btnCell.Text = "Cell";
            this.btnCell.UseVisualStyleBackColor = true;
            this.btnCell.Click += new System.EventHandler(this.btnCell_Click);
            // 
            // btnColony
            // 
            this.btnColony.Location = new System.Drawing.Point(407, 77);
            this.btnColony.Name = "btnColony";
            this.btnColony.Size = new System.Drawing.Size(91, 44);
            this.btnColony.TabIndex = 24;
            this.btnColony.Text = "Colony";
            this.btnColony.UseVisualStyleBackColor = true;
            this.btnColony.Click += new System.EventHandler(this.btnColony_Click);
            // 
            // btnAnimal
            // 
            this.btnAnimal.Location = new System.Drawing.Point(504, 77);
            this.btnAnimal.Name = "btnAnimal";
            this.btnAnimal.Size = new System.Drawing.Size(91, 44);
            this.btnAnimal.TabIndex = 25;
            this.btnAnimal.Text = "Animal";
            this.btnAnimal.UseVisualStyleBackColor = true;
            this.btnAnimal.Click += new System.EventHandler(this.btnAnimal_Click);
            // 
            // btnPlant
            // 
            this.btnPlant.Location = new System.Drawing.Point(601, 77);
            this.btnPlant.Name = "btnPlant";
            this.btnPlant.Size = new System.Drawing.Size(91, 44);
            this.btnPlant.TabIndex = 26;
            this.btnPlant.Text = "Plant";
            this.btnPlant.UseVisualStyleBackColor = true;
            this.btnPlant.Click += new System.EventHandler(this.btnPlant_Click);
            // 
            // btnEnvironment
            // 
            this.btnEnvironment.Location = new System.Drawing.Point(118, 77);
            this.btnEnvironment.Name = "btnEnvironment";
            this.btnEnvironment.Size = new System.Drawing.Size(91, 44);
            this.btnEnvironment.TabIndex = 27;
            this.btnEnvironment.Text = "Environments";
            this.btnEnvironment.UseVisualStyleBackColor = true;
            this.btnEnvironment.Click += new System.EventHandler(this.btnEnvironment_Click);
            // 
            // InstructionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 402);
            this.Controls.Add(this.btnEnvironment);
            this.Controls.Add(this.btnPlant);
            this.Controls.Add(this.btnAnimal);
            this.Controls.Add(this.btnColony);
            this.Controls.Add(this.btnCell);
            this.Controls.Add(this.btnVirus);
            this.Controls.Add(this.btnGeneral);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtInstructions);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "InstructionsForm";
            this.Text = "InstructionsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInstructions;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnGeneral;
        private System.Windows.Forms.Button btnVirus;
        private System.Windows.Forms.Button btnCell;
        private System.Windows.Forms.Button btnColony;
        private System.Windows.Forms.Button btnAnimal;
        private System.Windows.Forms.Button btnPlant;
        private System.Windows.Forms.Button btnEnvironment;
    }
}