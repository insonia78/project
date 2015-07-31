using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program9
{
    partial class program9_design
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
            this.label2 = new System.Windows.Forms.Label();
            this.first_number = new System.Windows.Forms.TextBox();
            this.second_number = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.total = new System.Windows.Forms.TextBox();
            this.add = new System.Windows.Forms.Button();
            this.multiply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(46, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Number";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label2.Location = new System.Drawing.Point(46, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Second Number";
            // 
            // first_number
            // 
            this.first_number.Location = new System.Drawing.Point(160, 41);
            this.first_number.Name = "first_number";
            this.first_number.Size = new System.Drawing.Size(100, 20);
            this.first_number.TabIndex = 2;
            this.first_number.TextChanged += new System.EventHandler(this.first_number_TextChanged);
            // 
            // second_number
            // 
            this.second_number.Location = new System.Drawing.Point(160, 72);
            this.second_number.Name = "second_number";
            this.second_number.Size = new System.Drawing.Size(100, 20);
            this.second_number.TabIndex = 3;
            this.second_number.TextChanged += new System.EventHandler(this.second_number_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Total";
            // 
            // total
            // 
            this.total.Location = new System.Drawing.Point(160, 100);
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.Size = new System.Drawing.Size(100, 20);
            this.total.TabIndex = 5;
            this.total.TabStop = false;
            this.total.TextChanged += new System.EventHandler(this.total_TextChanged);
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(52, 163);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(75, 23);
            this.add.TabIndex = 6;
            this.add.Text = "&ADD";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // multiply
            // 
            this.multiply.Location = new System.Drawing.Point(160, 163);
            this.multiply.Name = "multiply";
            this.multiply.Size = new System.Drawing.Size(75, 23);
            this.multiply.TabIndex = 7;
            this.multiply.Text = "&MULTIPLY";
            this.multiply.UseVisualStyleBackColor = true;
            this.multiply.Click += new System.EventHandler(this.multiply_Click);
            // 
            // program9_design
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.multiply);
            this.Controls.Add(this.add);
            this.Controls.Add(this.total);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.second_number);
            this.Controls.Add(this.first_number);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "program9_design";
            this.Text = "Program9";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox first_number;
        private System.Windows.Forms.TextBox second_number;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox total;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button multiply;
        private double number1,
                       number2;
                       
        public void add_Click(object sender,System.EventArgs e)
        {
            // trying to see if first_number is a number
            if (Double.TryParse(first_number.Text, out number1) == false)
            {
                MessageBox.Show("Enter a number");
            }
            else
            {
                number1 =Double.Parse(first_number.Text);
            }
            // trying to see f second_number is a number
            if (Double.TryParse(second_number.Text, out number2) == false)
            {
                MessageBox.Show("Enter a number");
            }
            else
            {
                number2 = Double.Parse(second_number.Text);
            }
            Class _class = new Class(number1,number2);

            total.Text =Convert.ToString(_class.getAddition());
       }
        public void multiply_Click(object sender, System.EventArgs e)
        {
            // trying to see if first_number is a number
            if (Double.TryParse(first_number.Text, out number1) == false)
            {
                MessageBox.Show("Enter a number");
            }
            else
            {
                number1 = Double.Parse(first_number.Text);
            }
            // trying to see f second_number is a number
            if (Double.TryParse(second_number.Text, out number2) == false)
            {
                MessageBox.Show("Enter a number");
            }
            else
            {
                number2 = Double.Parse(second_number.Text);
            }
            // creating the object 
            Class _class = new Class(number1, number2);

            total.Text = Convert.ToString(_class.getMoltiplication());
        }
    }

}

