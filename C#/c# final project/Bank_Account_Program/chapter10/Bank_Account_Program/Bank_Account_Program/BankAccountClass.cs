/*@Author Thomas Zangari
 * this program construct the arrays 
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections; 
using System.Windows.Forms;
 
namespace WindowsFormsApplication1
{
    
    public class BankAccountClass
    {
        //variables
         private string accountName,
                         dummy ="";
         private int accountNumber;
         private static int n = 1;
         private double balanceValue;
         
         //Creating objects
         private Account_info accountInfo;
         private Manipulations manipulation;
         
         // The arrays    
         private ArrayList name = new ArrayList(n);
         private ArrayList account = new ArrayList(n);
         private ArrayList balance  = new ArrayList(n);
         private ArrayList text = new ArrayList(n);

         public BankAccountClass()
         {
             
             
         }
         public BankAccountClass(string acntName, int acntNumber, double bal)
         {
             accountName = acntName;
             accountNumber = acntNumber;
             balanceValue = bal;
         }
         public BankAccountClass(ArrayList num, ArrayList acc, ArrayList bal,ArrayList txt)
         {
             this.name = num;
             this.account = acc;
             this.balance = bal;
             this.text = txt;
             for (int i = 0; i < n; i++)
             {
                 name.Insert(i, dummy);
                 account.Insert(i, dummy);
                 balance.Insert(i, dummy);
                 text.Insert(i, dummy);
             }
             //creating the constructors to link the arrays
             accountInfo = new Account_info(name, account, balance, text);
             manipulation = new Manipulations(name, account, balance, text); 
             
         }
         public string AccountName
         {
             get
             {
                 return accountName;
             }
             set
             {
                 accountName = value;
             }
         }
         public int AccountNumber
         {
             get
             {
                 return accountNumber;
             }
             set
             {
                 accountNumber = value;
             }
         }
         public double BalanceValue
         {
             get
             {
                 return balanceValue;
             }
             set
             {
                 balanceValue = value;
             }
         }
        
        
         

  
    }// end of Class
                 

}//end of namespace


                 






 
   

