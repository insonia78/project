
namespace WindowsFormsApplication1
{
    partial class Account_info
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
            this.textAccountName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAccountNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBegingBalance = new System.Windows.Forms.TextBox();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account Name";
            // 
            // textAccountName
            // 
            this.textAccountName.Location = new System.Drawing.Point(144, 22);
            this.textAccountName.Name = "textAccountName";
            this.textAccountName.Size = new System.Drawing.Size(100, 20);
            this.textAccountName.TabIndex = 1;
            this.textAccountName.TextChanged += new System.EventHandler(this.textAccountName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Account Number";
            // 
            // txtAccountNumber
            // 
            this.txtAccountNumber.Location = new System.Drawing.Point(144, 56);
            this.txtAccountNumber.Name = "txtAccountNumber";
            this.txtAccountNumber.Size = new System.Drawing.Size(100, 20);
            this.txtAccountNumber.TabIndex = 3;
            this.txtAccountNumber.TextChanged += new System.EventHandler(this.txtAccountNumber_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Beginig Balance";
            // 
            // txtBegingBalance
            // 
            this.txtBegingBalance.Location = new System.Drawing.Point(144, 89);
            this.txtBegingBalance.Name = "txtBegingBalance";
            this.txtBegingBalance.Size = new System.Drawing.Size(100, 20);
            this.txtBegingBalance.TabIndex = 5;
            this.txtBegingBalance.TextChanged += new System.EventHandler(this.txtBegingBalance_TextChanged);
            // 
            // btnContinue
            // 
            this.btnContinue.Location = new System.Drawing.Point(47, 128);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(75, 32);
            this.btnContinue.TabIndex = 6;
            this.btnContinue.Text = "&Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(144, 128);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 31);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Account_info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.txtBegingBalance);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAccountNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textAccountName);
            this.Controls.Add(this.label1);
            this.Name = "Account_info";
            this.Load += new System.EventHandler(this.Acount_Info_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textAccountName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAccountNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBegingBalance;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnClear;

        

       
    }
}