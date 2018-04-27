using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helper_Classes_namespace;
using System.Data.SqlClient;
namespace Amazing_charts_sample_program
{
    
    class LastNameClass: Helper_Classes_namespace.DataBaseHelperClass
    {

        public LastNameClass() { }
        public SqlCommand getLastName(String lastname)
        {
            
            return this.PerformQuery("");
        }
    }
}
