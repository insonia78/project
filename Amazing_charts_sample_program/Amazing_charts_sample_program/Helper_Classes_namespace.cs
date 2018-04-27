using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;




namespace Helper_Classes_namespace
{
    
    public abstract class  DataBaseHelperClass
    {          
        public SqlCommand PerformQuery(string query)
        {
            SqlCommand command = new SqlCommand(query, SqlConnectionClass.getConn());
            SqlConnectionClass.getConn().Open();
            
            return command;
        }
        public static void SettingDbConnection(String connectionString)
        {
            SqlConnectionClass.setConn(connectionString);

        }
        public static SqlCommand GlobalPerformQuery(string query)
        {
            SqlCommand command = new SqlCommand(query, SqlConnectionClass.getConn());
            SqlConnectionClass.getConn().Open();
            return command;
        }
        public static void ClosePerformQuery()
        {            
            SqlConnectionClass.getConn().Close();            
        }
        private static  class SqlConnectionClass
        {

            static SqlConnection con = new SqlConnection();
            public static void setConn(String connectionString) {  con.ConnectionString = connectionString; }
            public static SqlConnection getConn() { return con; }            
        }
    }
    public static class PerformWriteToFileAction 
    {
        static System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Public\TestFolder\WriteLines2.txt", true);
        public static int createPatientFile(String filename,String data)
        {
            System.IO.File.WriteAllText(@filename, data);
            return 1;
        }

        public static int writeToLogFile(String data)
        {
            file.WriteLine(data);
            return 1;
        }
    }
    public static class HelperClass
    {
        static DateTime UTCNow = DateTime.UtcNow;
        private static int getDaysInaMonth(int month)
        {      
          return DateTime.DaysInMonth(UTCNow.Year, month);
        }
        public static int getDaysUptoMonth(int month)
        {
            int totalDays = 0;
            for(int i = 1; i <= month;i++)
            {
                totalDays += getDaysInaMonth(i);
            }
            return totalDays;
        }
    }
}

