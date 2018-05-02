using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helper_Classes_namespace;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace Amazing_charts_sample_program
{
    class PhoneClass: Helper_Classes_namespace.DataBaseHelperClass
    {
        public PhoneClass() { }
        public void getPhoneNumberData(string data)
        {
            this.PerformQuery("");
        }
        public string PhoneNumber { get; set; }
        public bool testPhoneFormat(string phone)
        {
            if (phone == "")
            {
                Helper_Classes_namespace.ErrorMessages.setErrorMessage("phone is empty", false);
                return false;
            }
            if (!Regex.Match(phone, @"^\d{3}-\d{3}-\d{4}$").Success)
            {
                Helper_Classes_namespace.ErrorMessages.setErrorMessage("xxx-xxx-xxxx phone number format is invalid!!!!!!! ", false);                
                return false;
            }
            return true;
        }
    }
}
