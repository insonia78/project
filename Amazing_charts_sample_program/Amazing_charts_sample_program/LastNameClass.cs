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
    
    class LastNameClass: Helper_Classes_namespace.DataBaseHelperClass
    {

        public LastNameClass() { } 
        public string LastName { get; set; }
        public List<Amazing_charts_sample_program_Patient_Format> getLastName(List<Amazing_charts_sample_program_Patient_Format> dataSet, string lastName)
        {
            string query = "SELECT * from credentials where last_name  like '" + lastName + "%'";
            var response = this.PerformQuery(query);
            if (response == null) return null;
            SqlDataReader reader = response.ExecuteReader();
            int index = 0;
            while (reader.Read())
            {
                Patient patient = new Patient();
                patient.FirstName = reader["first_name"].ToString();
                patient.LastName = reader["last_name"].ToString();
                patient.DateOfBirth = reader["date_of_birth"].ToString();
                patient.PhoneNumber = reader["phone"].ToString();
                string[] tempDate = Helper_Classes_namespace.HelperClass.getSystemDateTime().Date.ToString().Split(' ');
                patient.Age = Helper_Classes_namespace.HelperClass.getTotAge(patient.DateOfBirth, tempDate[0]);
                dataSet.Insert(index, patient);
                index++;
            }
            Helper_Classes_namespace.DataBaseHelperClass.ClosePerformQuery();
            return dataSet;
        }
    
        public bool testLastName(string lastName)
        {
            if (lastName == "")
            {
                MessageBox.Show("Last Name is empty");
                return false;
            }
            if (!Regex.Match(lastName, @"^[a-zA-Z'.]{1,40}$").Success)
            {
                MessageBox.Show(" Invalid last name ");
                return false;
            }
            return true;
        }
    }
}
