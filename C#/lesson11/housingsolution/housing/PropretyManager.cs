using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 
namespace HousingNamespace
{
    public abstract class PropretyManager

    {
        private string address;
        private int yearBuilt;

        public PropretyManager()
        {
           
        }
        public PropretyManager(string adrs,int yrBuilt)
        {
            address = adrs;
            yearBuilt = yrBuilt ;
        }
        public string Address
        {
            set
            {
                address = value;
            }
            get
            {
                return address;
            }
        }
        public int YearBuilt
        {
            set
            {
                yearBuilt = value;
            }
            get
            {
                return yearBuilt;
            }
        }
        public string Print()
        {
            string print = "";
            return print ="The address is: " + address +
                             "\nThe year is: " + yearBuilt;
        }
        public virtual int totalProjectedAmount()
        {
            int projectedAmount = 0;
            if(yearBuilt < 2000)
            {
               projectedAmount = 1000;
            }
            else
            {
                projectedAmount = 2000;
            }
            return projectedAmount ;
        }




    }
}
