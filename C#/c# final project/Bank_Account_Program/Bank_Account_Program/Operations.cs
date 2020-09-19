using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace WindowsFormsApplication1
{
    public partial class Operations : Form
    {
        //Variables

        private decimal withdraw, // hold the amount withdraw is always a positive value
                       deposit;  // it holds the  deposit it is always a positive value
                       
        private decimal balance;  // it holds the balance inputed from the user
                       
        private string accountName,  // it hold the account name
                        output = ""; // it hold the output that is displayed on the screen
       
        private int    index,         // it holds the index where the accountName, accountNumber and the balance is going to be places 
                       accountNumber; // it holds the accountNumber of the user all the program evolvs around the accountNumber

        private bool confirm ;        // is for clearing the withdraw and the deposit boxes  

           
        
        static ArrayList text = new ArrayList();   // it holds the transaction done in this case the output  
        static ArrayList name = new ArrayList();   // it holds the accountName
        static ArrayList account = new ArrayList(); // it holds the accoutNumber
        static ArrayList balanceValue = new ArrayList(); // it holds the balance 
        
        private Manipulations manipulation; // object for the manupulation of data



                
        
        
        public Operations(ArrayList txt,string actName,int actNumber, decimal b,ArrayList nm,ArrayList act,ArrayList bal)
        {
            InitializeComponent();
            
            
            
            text = txt;
            name = nm;
            account = act;
            balanceValue = bal;
            
            accountName = actName;
            accountNumber = actNumber;
            balance = b;

            txtAccountNameOperations.Text = actName;
            txtAccountNumberOperation.Text = actNumber.ToString();
            txtBalance.Text = b.ToString() ;
                       
        }
        
        
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtAccountNameOperations_TextChanged(object sender, EventArgs e)
        {
            manipulation = new Manipulations();
            richTextBoxText.Clear();
            
            if (manipulation.SearchAccountNumber(accountNumber, account) == true)
            {
                index = manipulation.getIndexOf(accountNumber, account);
                richTextBoxText.Text = manipulation.getText(index, text).ToString();
                output += manipulation.getText(index, text).ToString();
            }
            

        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
          
          if (txtDeposit.Text == "") { txtDeposit.Text = "0"; }
          if (txtWithdrawOperations.Text == "") { txtWithdrawOperations.Text = "0"; }
          bool confirm = GetValues();
          if (confirm == true)
          {
              DateTime date = DateTime.Now;
              balance += deposit - withdraw;

              txtBalance.Text = Convert.ToString(balance);
              output += date.ToLocalTime() + "\nwithdraw:" + withdraw + "\ndeposit:" + deposit + "\nNew Balance:" + (balance) + "\n\n";

              richTextBoxText.Text = output;

              txtDeposit.Text = "";
              txtWithdrawOperations.Text = "";
          }
                                   
        }

        private void txtWithdrawOperations_TextChanged(object sender, EventArgs e)
        {
            
                
        }

        private void richTextBoxText_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtDeposit_TextChanged(object sender, EventArgs e)
        {
                
                 
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            confirm = true;
            txtWithdrawOperations.Clear();
            txtDeposit.Clear();
            confirm = false;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            manipulation.setText(index, output, text);
            manipulation.setRemoveBalance(index, balance, balanceValue);
                   
            if (MessageBox.Show("Do you want to return to the prevous screan?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            
            {
                new Account_info(accountName,accountNumber,balance).Show();
                this.Hide();
            }
            else
            {
                if (MessageBox.Show("Do you want to exit from the program?","Message", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                   this.Close();
                }
                else
                {
                }
            
                
            }


        }//end method
        private bool GetValues()
        {
            bool confirm = true;
            if (Decimal.TryParse(txtWithdrawOperations.Text, out withdraw) == false)
            {
                txtWithdrawOperations.Clear();
                MessageBox.Show("Withdraw:\nYou entered an invalid value", "Withdraw");
                confirm = false;
            }
            else
            {
                withdraw = Convert.ToDecimal(txtWithdrawOperations.Text);
                if (withdraw < 0)
                {
                    MessageBox.Show("WithDraw:\nSorry no negative values", "WithDraw", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtWithdrawOperations.Clear();
                    withdraw = 0;
                    confirm = false;
                }
            }
            if (Decimal.TryParse(txtDeposit.Text, out deposit) == false)
            {
                txtDeposit.Clear();
                MessageBox.Show("Deposit:\nYou entered an invalid value", "Deposit");
                confirm = false;
            }
            else
            {
                deposit = Convert.ToDecimal(txtDeposit.Text);

                if (deposit < 0)
                {
                    MessageBox.Show("Deposit:\nSorry no negative values", "Deposit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDeposit.Clear();
                    deposit = 0;
                    confirm = false;
                }

            }
            return confirm;

        }
    }//end class
}//end namespace
