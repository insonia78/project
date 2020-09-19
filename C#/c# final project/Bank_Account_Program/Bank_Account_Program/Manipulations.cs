using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace WindowsFormsApplication1
{
    class Manipulations
    {
        static ArrayList name = new ArrayList();
        static ArrayList account = new ArrayList();
        static ArrayList balance = new ArrayList();
        static ArrayList text = new ArrayList();
        private string dummy = "";
        
        public Manipulations()
        {
        }
        public Manipulations(ArrayList names,ArrayList accounts,ArrayList balances,ArrayList texts)
        {
            name = names;
            account = accounts;
            balance = balances;
            text = texts; 

        }//end of method

        public bool ValidateIndex(ArrayList account)
        {
            bool decision = false;
            int i = 0;
            bool validate = false;

            while (decision == false)
            {

                if (account[i].ToString() == dummy)
                {
                    validate = true;
                    decision = true;
                }
                else
                {
                    i++;
                }
            }
            return validate;
        }// end of method

        public bool SearchAccountNumber(int actNumber, ArrayList account)
        {

            bool value = false;
            for (int i = 0; i < account.Count && value == false; i++)
            {
                if (actNumber.Equals(account[i]))
                {
                    value = true;
                }
            }
            return value;
        }// end of method

        public void setName(int i, string n,ArrayList name)
        {
             
            name.Insert(i, n);
        }//end of method

        public string getName(int i,ArrayList name)
        {
            return name[i].ToString();
        }//end of method

        public void setAccount(int i, int acc,ArrayList account)
        {
            
            account.Insert(i, acc);
        }// end of method

        public string getAccount(int i,ArrayList account)
        {
            return account[i].ToString();
        }//end of method

        public void setBalance(int i, decimal bal,ArrayList balance)
        {            
            balance.Insert(i, bal);
        }//end of method

        public void setRemoveBalance(int i, decimal bal, ArrayList balance)
        {
            balance.RemoveAt(i);
            balance.Insert(i, bal);
        }

        public string getBalance(int i,ArrayList balance)
        {
            return balance[i].ToString();
        }//end of method

        public void setText(int i, string output,ArrayList text)
        {
            text.RemoveAt(i);
            text.Insert(i, output);
        }//end of method

        public void setEmptyText(int i, string output, ArrayList text)
        {
            text.Insert(i, output);
        }

        public string getText(int i,ArrayList text)
        {
            return text[i].ToString();
        }//end of method

       

        public int getIndex(ArrayList account)
        {
            bool decision = false;
            int i = 0;

            while (decision == false)
            {
                if (account[i].ToString() == dummy)
                {
                    decision = true;
                }
                else
                {
                    i++;
                }
            }
            return i;
        }//end of method

        public int getIndexOf(int actNumber,ArrayList account)
        {
            return account.IndexOf(actNumber);
        }// end of method

       

    }//end of Class
}//end of namespace
