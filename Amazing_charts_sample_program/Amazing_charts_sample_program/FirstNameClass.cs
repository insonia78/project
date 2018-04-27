using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
// helper namespace
using Helper_Classes_namespace;
namespace Amazing_charts_sample_program
{
    class FirstNameClass : Helper_Classes_namespace.DataBaseHelperClass
    {
        public FirstNameClass() { }
        
        public SqlCommand getFirstName(String firstName)
        {
            return this.PerformQuery("");
            
        }

    }
}
