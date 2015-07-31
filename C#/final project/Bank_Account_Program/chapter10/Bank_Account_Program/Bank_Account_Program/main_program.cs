/* program 10 
 * @author Thomas Zangari
 * this program acts like a small database it stores a account name ,is number nad the starting balance
 *  */ 




using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace WindowsFormsApplication1
{
    static class Program
    {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {      
               ArrayList name = new ArrayList();
               ArrayList account = new ArrayList();
               ArrayList balance = new ArrayList();
               ArrayList text = new ArrayList(); 
               
            
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Call to the bank account constructor
            BankAccountClass bankAccount = new BankAccountClass(name, account, balance,text);
            Application.Run(new Intro());
                        
        }
    }
}
