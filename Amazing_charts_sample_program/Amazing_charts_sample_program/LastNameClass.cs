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
    
    public class LastNameClass: Helper_Classes_namespace.DataBaseHelperClass
    {

        public LastNameClass() { } 
        public string LastName { get; set; }
        public List<Amazing_charts_sample_program_Patient_Format> getLastName(List<Amazing_charts_sample_program_Patient_Format> dataSet, Patient _patient)
        {
            string query = "SELECT * from credentials where last_name  like '" + _patient.LastName + "%'";            
            if (_patient.FirstName.Length > 0)
                query += " AND first_name like '" + _patient.FirstName + "%'";
            if (_patient.DateOfBirth.Length > 0)
                query += " AND date_of_birth like '" + _patient.DateOfBirth + "%'";            
            var response = this.PerformQuery(query);
            if (response.hasErrors == true) return dataSet;
            int index = 0;
            while (response.reader.Read())
            {
                Patient patient = new Patient();
                patient.FirstName = response.reader["first_name"].ToString();
                patient.LastName = response.reader["last_name"].ToString();
                patient.DateOfBirth = response.reader["date_of_birth"].ToString();
                patient.PhoneNumber = response.reader["phone"].ToString();
                string[] tempDate = Helper_Classes_namespace.HelperClass.getSystemDateTime().Date.ToString().Split(' ');
                patient.Age = Helper_Classes_namespace.HelperClass.getTotAge(patient.DateOfBirth, tempDate[0]);
                dataSet.Insert(index, patient);
                index++;
            }
            Helper_Classes_namespace.DataBaseHelperClass.ClosePerformQuery();
            return QuickSortNow(dataSet, 0, dataSet.Count - 1);
        }
        public static List<Amazing_charts_sample_program_Patient_Format> getLastName1(List<Amazing_charts_sample_program_Patient_Format> dataSet, Patient _patient)
        {
            string query = "SELECT * from credentials where last_name  like '" + _patient.LastName + "%'";
            if (_patient.FirstName.Length > 0)
                query += " AND first_name like '" + _patient.FirstName + "%'";
            if (_patient.DateOfBirth.Length > 0)
                query += " AND date_of_birth like '" + _patient.DateOfBirth + "%'";
            var response = new LastNameClass().PerformQuery(query);
            if (response.hasErrors == true) return dataSet;
            int index = 0;
            while (response.reader.Read())
            {
                Patient patient = new Patient();
                patient.FirstName = response.reader["first_name"].ToString();
                patient.LastName = response.reader["last_name"].ToString();
                patient.DateOfBirth = response.reader["date_of_birth"].ToString();
                patient.PhoneNumber = response.reader["phone"].ToString();
                string[] tempDate = Helper_Classes_namespace.HelperClass.getSystemDateTime().Date.ToString().Split(' ');
                patient.Age = Helper_Classes_namespace.HelperClass.getTotAge(patient.DateOfBirth, tempDate[0]);
                dataSet.Insert(index, patient);
                index++;
            }
            Helper_Classes_namespace.DataBaseHelperClass.ClosePerformQuery();
            return new LastNameClass().QuickSortNow(dataSet, 0, dataSet.Count - 1);
        }

        public bool testLastName(string lastName)
        {
            if (lastName == "")
            {
                Helper_Classes_namespace.ErrorMessages.setErrorMessage(" Last Name is empty ", false);                
                return false;
            }
            if (!Regex.Match(lastName, @"^[a-zA-Z'.]{1,40}$").Success)
            {
                Helper_Classes_namespace.ErrorMessages.setErrorMessage(" Invalid last name ", false);                
                return false;
            }
            return true;
        }
        public List<Amazing_charts_sample_program_Patient_Format> QuickSortNow(List<Amazing_charts_sample_program_Patient_Format> iInput, int start, int end)
        {
            if (start < end)
            {
                int pivot = Partition(iInput, start, end);
                QuickSortNow(iInput, start, pivot - 1);
                QuickSortNow(iInput, pivot + 1, end);
            }
            return iInput;
        }

        public int Partition(List<Amazing_charts_sample_program_Patient_Format> iInput, int start, int end)
        {
            string pivot = iInput[end].LastName;
            int pIndex = start;

            for (int i = start; i < end; i++)
            {
                if (iInput[i].LastName.CompareTo(pivot) < 0 || iInput[i].LastName.CompareTo(pivot) == 0)
                {
                    Patient temp = (Patient)iInput[i];
                    iInput[i] = iInput[pIndex];
                    iInput[pIndex] = temp;
                    pIndex++;
                }
            }

            Patient anotherTemp = (Patient)iInput[pIndex];
            iInput[pIndex] = iInput[end];
            iInput[end] = anotherTemp;
            return pIndex;
        }
    }
}

