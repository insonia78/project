using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helper_Classes_namespace;
using System.Data.SqlClient;
namespace Amazing_charts_sample_program
{
    class DateOfBirth : Helper_Classes_namespace.DataBaseHelperClass
    {
        public DateOfBirth() { }
        public SqlCommand getDateOfBirth(String date)
        {
            return this.PerformQuery("");
        }
        public String getAgeByBirthDate(String date)
        {
            return "";
        }
    }
}
