namespace WindowsFormsApplication1
{
    partial class Operations
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
            this.txtAccountNameOperations = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAccountNumberOperation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtWithdrawOperations = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDeposit = new System.Windows.Forms.TextBox();
            this.richTextBoxText = new System.Windows.Forms.RichTextBox();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account Name";
            // 
            // txtAccountNameOperations
            // 
            this.txtAccountNameOperations.Location = new System.Drawing.Point(112, 25);
            this.txtAccountNameOperations.Name = "txtAccountNameOperations";
            this.txtAccountNameOperations.ReadOnly = true;
            this.txtAccountNameOperations.Size = new System.Drawing.Size(100, 20);
            this.txtAccountNameOperations.TabIndex = 1;
            this.txtAccountNameOperations.TextChanged += new System.EventHandler(this.txtAccountNameOperations_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Account Number";
            // 
            // txtAccountNumberOperation
            // 
            this.txtAccountNumberOperation.Location = new System.Drawing.Point(112, 59);
            this.txtAccountNumberOperation.Name = "txtAccountNumberOperation";
            this.txtAccountNumberOperation.ReadOnly = true;
            this.txtAccountNumberOperation.Size = new System.Drawing.Size(100, 20);
            this.txtAccountNumberOperation.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Balance";
            // 
            // txtBalance
            // 
            this.txtBalance.Location = new System.Drawing.Point(112, 96);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.ReadOnly = true;
            this.txtBalance.Size = new System.Drawing.Size(100, 20);
            this.txtBalance.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Withdraw";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtWithdrawOperations
            // 
            this.txtWithdrawOperations.Location = new System.Drawing.Point(112, 146);
            this.txtWithdrawOperations.Name = "txtWithdrawOperations";
            this.txtWithdrawOperations.Size = new System.Drawing.Size(100, 20);
            this.txtWithdrawOperations.TabIndex = 7;
            this.txtWithdrawOperations.TextChanged += new System.EventHandler(this.txtWithdrawOperations_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Deposit";
            // 
            // txtDeposit
            // 
            this.txtDeposit.Location = new System.Drawing.Point(112, 178);
            this.txtDeposit.Name = "txtDeposit";
            this.txtDeposit.Size = new System.Drawing.Size(100, 20);
            this.txtDeposit.TabIndex = 9;
            this.txtDeposit.TextChanged += new System.EventHandler(this.txtDeposit_TextChanged);
            // 
            // richTextBoxText
            // 
            this.richTextBoxText.Location = new System.Drawing.Point(274, 25);
            this.richTextBoxText.Name = "richTextBoxText";
            this.richTextBoxText.ReadOnly = false;
            this.richTextBoxText.Size = new System.Drawing.Size(345, 173);
            this.richTextBoxText.TabIndex = 10;
            this.richTextBoxText.Text = "";
            this.richTextBoxText.TextChanged += new System.EventHandler(this.richTextBoxText_TextChanged);
            // 
            // btnContinue
            // 
            this.btnContinue.Location = new System.Drawing.Point(274, 252);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(112, 23);
            this.btnContinue.TabIndex = 11;
            this.btnContinue.Text = "&Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(402, 252);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(102, 23);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(521, 251);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(98, 23);
            this.Exit.TabIndex = 13;
            this.Exit.Text = "&Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Operations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(642, 308);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.richTextBoxText);
            this.Controls.Add(this.txtDeposit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtWithdrawOperations);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBalance);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAccountNumberOperation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAccountNameOperations);
            this.Controls.Add(this.label1);
            this.Name = "Operations";
            this.Text = "Operations";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAccountNameOperations;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAccountNumberOperation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtWithdrawOperations;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDeposit;
        private System.Windows.Forms.RichTextBox richTextBoxText;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button Exit;
    }
}