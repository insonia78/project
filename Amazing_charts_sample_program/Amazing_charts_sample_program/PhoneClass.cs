using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helper_Classes_namespace;
using System.Data.SqlClient;
namespace Amazing_charts_sample_program
{
    class PhoneClass: Helper_Classes_namespace.DataBaseHelperClass
    {
        public PhoneClass() { }
        public SqlCommand getPhoneNumberData(String data)
        {
            return this.PerformQuery("");
        }
    }
}
