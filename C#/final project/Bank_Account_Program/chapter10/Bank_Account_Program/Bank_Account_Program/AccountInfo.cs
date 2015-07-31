/* accountInfo class 
 * it stores and asks the info for the account
 * */



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
    public partial class Account_info : Form
    {
         // variables
         private string accountName;
         private int accountNumber,
                     accountNumber2,
                              index;
                          
         private decimal  balanceValue;
         private string dummy = "";
         private bool choose = true;
        
         static ArrayList name = new ArrayList();
         static ArrayList account = new ArrayList();
         static ArrayList balance = new ArrayList();
         static ArrayList text = new ArrayList();

         Manipulations manipulation = new Manipulations();             
        
        public Account_info()
        {
            InitializeComponent();
        }
        public Account_info(ArrayList nm, ArrayList act, ArrayList bal, ArrayList txt)
        {
            name = nm;
            account = act;
            balance = bal;
            text = txt;
                       
        }
        
        public Account_info(string acntName, int actNumber, decimal balance)
        {
            InitializeComponent();
            textAccountName.Text = acntName;
            txtAccountNumber.Text = Convert.ToString(actNumber);
            txtBegingBalance.Text = Convert.ToString(balance);

        }

        private void Acount_Info_Load(object sender, EventArgs e)
        {

        }

        public void btnContinue_Click(object sender, EventArgs e)
        {
            bool validate = false;
            string empty = "";
            validate = Validate();
            if (validate == true)
            {
                
                if (manipulation.SearchAccountNumber(accountNumber,account) == false && manipulation.ValidateIndex(account) == true)
                {
                   
                    manipulation.setName(index, accountName,name);
                    manipulation.setAccount(index, accountNumber,account);
                    manipulation.setBalance(index, balanceValue,balance);
                    manipulation.setEmptyText(index, empty, text);
                   
                    
                }
                           
               
               new Operations(text,accountName,accountNumber,balanceValue,name,account,balance).Show();
               this.Hide();
            }
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textAccountName_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void txtAccountNumber_TextChanged(object sender, EventArgs e)
        {
            if (choose == true)
            {

                if (Int32.TryParse(txtAccountNumber.Text, out accountNumber) == false)
                {
                    txtAccountNumber.Clear();
                    MessageBox.Show("Account Number:\nYou entered invalid values", "Account Number");
                }
                else
                {
                    int accountNumber2 = Int32.Parse(txtAccountNumber.Text);
                    if (accountNumber2.ToString().Length > 6)
                    {
                        MessageBox.Show("AccountNumber:\nThe Account supposed to be 6 digit long", "Account Number");
                        txtAccountNumber.Clear();
                        accountNumber2 = 0;
                    }
                    
                    if (manipulation.SearchAccountNumber(accountNumber2, account) == true)
                    {
                        int i = manipulation.getIndexOf(accountNumber2, account);
                        this.txtBegingBalance.ReadOnly = true;
                        txtBegingBalance.Text = manipulation.getBalance(i, balance);
                        textAccountName.Text = manipulation.getName(i, name); 
                    }

                }
            }

        }

        private void txtBegingBalance_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Clear?\nPress Yes to continue No to Exit from the program", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                choose = false;
                textAccountName.Text ="";
                txtAccountNumber.Text="";
                txtBegingBalance.Text="";
                this.txtBegingBalance.ReadOnly = false;
                choose = true;
            }
            else
            {
                if (MessageBox.Show("Do you want to Exit?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }
        private bool Validate()
        {
            bool validation = false;
            int validate = 0;
            
            if (textAccountName.Text == "" && choose == true)
            {
                textAccountName.Clear();
                MessageBox.Show("Account name:\nEnter an Account Name", "Account Name");
            }
            else
            {
                accountName = textAccountName.Text;
                validate++;
            }
            if (txtAccountNumber.Text.Length != 6)
            {
                txtAccountNumber.Clear();
                accountNumber = 0;
                MessageBox.Show("The account number supposed to be 6 digits");
            }
            else
            {
                    accountNumber = Int32.Parse(txtAccountNumber.Text);
                    validate++;
            }
            
            if (Decimal.TryParse(txtBegingBalance.Text, out balanceValue) == false)
            {
              
                txtBegingBalance.Clear();
                MessageBox.Show("Beginnig Balance:\nEnter a numeric Balance", "Starting Balance");
            }
            else if (txtBegingBalance.Text == "")
            {
                MessageBox.Show("Beginnig Balance:\nEnter a starting Balance", "Starting Balance");
            }
            else
            {
                balanceValue = Convert.ToDecimal(txtBegingBalance.Text);
                validate++;
            }
            if (validate == 3)
            {
                validation = true;
            }
            else
            {
                validation = false;
            }

            return validation;

        } //end of VAlidation method
            
        
    }// end of class

}// end of namespace
