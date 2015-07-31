using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    partial class GAME
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
            this.label1 = new System.Windows.Forms.Label();
            this.getNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toHigh = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.toLow = new System.Windows.Forms.TextBox();
            this.btnPress = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter the number here";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // getNumber
            // 
            this.getNumber.Location = new System.Drawing.Point(129, 21);
            this.getNumber.Name = "getNumber";
            this.getNumber.Size = new System.Drawing.Size(41, 20);
            this.getNumber.TabIndex = 1;
            this.getNumber.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "To high";
            // 
            // toHigh
            // 
            this.toHigh.BackColor = System.Drawing.SystemColors.ControlText;
            this.toHigh.Location = new System.Drawing.Point(129, 60);
            this.toHigh.Name = "toHigh";
            this.toHigh.ReadOnly = true;
            this.toHigh.Size = new System.Drawing.Size(21, 20);
            this.toHigh.TabIndex = 3;
            this.toHigh.TextChanged += new System.EventHandler(this.toHigh_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "To low";
            // 
            // toLow
            // 
            this.toLow.BackColor = System.Drawing.SystemColors.ControlText;
            this.toLow.Location = new System.Drawing.Point(129, 101);
            this.toLow.Name = "toLow";
            this.toLow.ReadOnly = true;
            this.toLow.Size = new System.Drawing.Size(21, 20);
            this.toLow.TabIndex = 5;
            this.toLow.TextChanged += new System.EventHandler(this.toLow_TextChanged);
            // 
            // btnPress
            // 
            this.btnPress.Location = new System.Drawing.Point(36, 155);
            this.btnPress.Name = "btnPress";
            this.btnPress.Size = new System.Drawing.Size(75, 23);
            this.btnPress.TabIndex = 6;
            this.btnPress.Text = "&PLAY";
            this.btnPress.UseVisualStyleBackColor = true;
            this.btnPress.Click += new System.EventHandler(this.btnPress_Click);
            // 
            // GAME
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnPress);
            this.Controls.Add(this.toLow);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.toHigh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.getNumber);
            this.Controls.Add(this.label1);
            this.Name = "GAME";
            this.Text = "GAME";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox getNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox toHigh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox toLow;
        private System.Windows.Forms.Button btnPress;
                    
    }
}

