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
    public class DateOfBirth : Helper_Classes_namespace.DataBaseHelperClass
    {
        private string year;
        private string month;
        private string day;
        
        public DateOfBirth(){ }
        public string Date_Of_Birth { get; set; }
        public string getSystemDateTime()
        {           
            year = Helper_Classes_namespace.HelperClass.getSystemDateTime().Year.ToString();
            month = Helper_Classes_namespace.HelperClass.getSystemDateTime().Month.ToString();
            day = Helper_Classes_namespace.HelperClass.getSystemDateTime().Day.ToString();
            return "0"+ month + "/" + day + "/" + year;
        }
        public List<Amazing_charts_sample_program_Patient_Format> getDateOfBirth(List<Amazing_charts_sample_program_Patient_Format> dataSet, Patient _patient)
        {
            string query = "SELECT * from credentials where date_of_birth like '" + _patient.DateOfBirth + "%'";
            if (_patient.FirstName.Length > 0)
                query += " AND first_name like '" + _patient.FirstName + "%'";
            if (_patient.LastName.Length > 0)
                query += " AND date_of_birth like '" + _patient.LastName + "%'";
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
            return dataSet;

        }
        public static List<Amazing_charts_sample_program_Patient_Format> getDateOfBirth1(List<Amazing_charts_sample_program_Patient_Format> dataSet, Patient _patient)
        {
            string query = "SELECT * from credentials where date_of_birth like '" + _patient.DateOfBirth + "%'";
            if (_patient.FirstName.Length > 0)
                query += " AND first_name like '" + _patient.FirstName + "%'";
            if (_patient.LastName.Length > 0)
                query += " AND date_of_birth like '" + _patient.LastName + "%'";
            var response = new DateOfBirth().PerformQuery(query);
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
            return dataSet;

        }

        public String getAgeByBirthDate(String date)
        {
            /*
            string systemFormat = getSystemDateTime();
            string[] words = date.Split('/');
            int userYear = Int32.Parse(words[words.Length - 1]);
            int userMonth = Int32.Parse(words[words.Length - 3]);
            int userDay = Int32.Parse(words[words.Length - 2]);
            int age = Int32.Parse(year) - userYear ;
            int currentTotaldays = Helper_Classes_namespace.HelperClass.getDaysUptoMonth(Int32.Parse(month));
            int userTotalDay = Helper_Classes_namespace.HelperClass.getDaysUptoMonth(userMonth);
            int differnce_of_day = ((currentTotaldays - userTotalDay) > 0 ? (currentTotaldays - userTotalDay) : ((currentTotaldays - userTotalDay) * -1));
            int remaning_days = differnce_of_day % 7;
            int weeks = differnce_of_day / 7;
            int totalDays = ((userDay - Int32.Parse(day)) > 0 ? (userDay - Int32.Parse(day)) : ((userDay - Int32.Parse(day)) * -1)) + remaning_days;
            weeks += (totalDays / 7);
            totalDays = totalDays % 7;
            */
            

            return Helper_Classes_namespace.HelperClass.getTotAge(date, getSystemDateTime());            
        }
        public bool testDate(string date)
        {
            if (date == "")
            {
                Helper_Classes_namespace.ErrorMessages.setErrorMessage("Date of birth is empty",false);
                return false;
            }
            if (!Regex.Match(date, @"\d{2}/\d{2}/\d{4}").Success)
            {                
                Helper_Classes_namespace.ErrorMessages.setErrorMessage("mm/dd/yyyy Invalid birth format ", false);
                return false;
            }            
            try
            {
                DateTime dt = DateTime.Parse(date);
            }
            catch
            {
               
                Helper_Classes_namespace.ErrorMessages.setErrorMessage(" Invalid birth format range ", false);
                return false;
            }
            if (!Helper_Classes_namespace.HelperClass.CompareDate(date))
            {
                Helper_Classes_namespace.ErrorMessages.setErrorMessage(" Invalid birth range date is over current date", false);
                return false;
            }
            return true;
        }

    }
}
