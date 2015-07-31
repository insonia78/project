namespace randomize_button
{
    partial class IndividualHeros
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
            this.AcceptIndividual = new System.Windows.Forms.Button();
            this.warriorHero = new System.Windows.Forms.Button();
            this.hunterHero = new System.Windows.Forms.Button();
            this.healerHero = new System.Windows.Forms.Button();
            this.mageHero = new System.Windows.Forms.Button();
            this.rogueHero = new System.Windows.Forms.Button();
            this.Hero_choices = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AcceptIndividual
            // 
            this.AcceptIndividual.Location = new System.Drawing.Point(620, 409);
            this.AcceptIndividual.Name = "AcceptIndividual";
            this.AcceptIndividual.Size = new System.Drawing.Size(129, 23);
            this.AcceptIndividual.TabIndex = 0;
            this.AcceptIndividual.Text = "Accept Changes";
            this.AcceptIndividual.UseVisualStyleBackColor = true;
            this.AcceptIndividual.Click += new System.EventHandler(this.button1_Click);
            // 
            // warriorHero
            // 
            this.warriorHero.Location = new System.Drawing.Point(170, 330);
            this.warriorHero.Name = "warriorHero";
            this.warriorHero.Size = new System.Drawing.Size(75, 23);
            this.warriorHero.TabIndex = 1;
            this.warriorHero.Text = "Warrior";
            this.warriorHero.UseVisualStyleBackColor = true;
            this.warriorHero.Click += new System.EventHandler(this.warriorHero_Click);
            // 
            // hunterHero
            // 
            this.hunterHero.Location = new System.Drawing.Point(275, 330);
            this.hunterHero.Name = "hunterHero";
            this.hunterHero.Size = new System.Drawing.Size(75, 23);
            this.hunterHero.TabIndex = 2;
            this.hunterHero.Text = "Hunter";
            this.hunterHero.UseVisualStyleBackColor = true;
            this.hunterHero.Click += new System.EventHandler(this.hunterHero_Click);
            // 
            // healerHero
            // 
            this.healerHero.Location = new System.Drawing.Point(384, 330);
            this.healerHero.Name = "healerHero";
            this.healerHero.Size = new System.Drawing.Size(75, 23);
            this.healerHero.TabIndex = 3;
            this.healerHero.Text = "Healer";
            this.healerHero.UseVisualStyleBackColor = true;
            // 
            // mageHero
            // 
            this.mageHero.Location = new System.Drawing.Point(485, 330);
            this.mageHero.Name = "mageHero";
            this.mageHero.Size = new System.Drawing.Size(75, 23);
            this.mageHero.TabIndex = 4;
            this.mageHero.Text = "Mage";
            this.mageHero.UseVisualStyleBackColor = true;
            // 
            // rogueHero
            // 
            this.rogueHero.Location = new System.Drawing.Point(594, 330);
            this.rogueHero.Name = "rogueHero";
            this.rogueHero.Size = new System.Drawing.Size(75, 23);
            this.rogueHero.TabIndex = 5;
            this.rogueHero.Text = "Rogue";
            this.rogueHero.UseVisualStyleBackColor = true;
            // 
            // Hero_choices
            // 
            this.Hero_choices.AutoSize = true;
            this.Hero_choices.BackColor = System.Drawing.Color.Aqua;
            this.Hero_choices.Location = new System.Drawing.Point(31, 335);
            this.Hero_choices.Name = "Hero_choices";
            this.Hero_choices.Size = new System.Drawing.Size(69, 13);
            this.Hero_choices.TabIndex = 6;
            this.Hero_choices.Text = "Hero Classes";
            // 
            // IndividualHeros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 462);
            this.Controls.Add(this.Hero_choices);
            this.Controls.Add(this.rogueHero);
            this.Controls.Add(this.mageHero);
            this.Controls.Add(this.healerHero);
            this.Controls.Add(this.hunterHero);
            this.Controls.Add(this.warriorHero);
            this.Controls.Add(this.AcceptIndividual);
            this.Name = "IndividualHeros";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Character Creation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AcceptIndividual;
        private System.Windows.Forms.Button warriorHero;
        private System.Windows.Forms.Button hunterHero;
        private System.Windows.Forms.Button healerHero;
        private System.Windows.Forms.Button mageHero;
        private System.Windows.Forms.Button rogueHero;
        private System.Windows.Forms.Label Hero_choices;
    }
}