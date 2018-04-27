using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Helper_Classes_namespace;
namespace Amazing_charts_sample_program
{
    public partial class amazing_charts_sample_application : Form
    {
        FirstNameClass _firstNameClass = new FirstNameClass();
        LastNameClass _lastNameClass = new LastNameClass();
        DateOfBirth _dateOfBirth = new DateOfBirth();
        public amazing_charts_sample_application()
        {
            InitializeComponent();
        }

        private void first_name_txt_TextChanged(object sender, EventArgs e)
        {
            
            

        }

        private void last_name_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void date_of_birth_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void phone_txt_box_TextChanged(object sender, EventArgs e)
        {

        }

        private void age_txt_box_TextChanged(object sender, EventArgs e)
        {

        }

        private void table_name_box_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void save_Click(object sender, EventArgs e)
        {
            string errorMessage = "";
            bool testSuccess = false;
            if (first_name_txt.Text == "")
            {
                errorMessage += "First Name is empty\n";
                testSuccess = true;
            }
            if (last_name_txt.Text == "")
            {
                errorMessage += "Last Name is empty\n";
                testSuccess = true;
            }
            if (date_of_birth_txt.Text == "")
            {
                errorMessage += "Date of birth is empty\n";
                testSuccess = true;
            }
            if (phone_txt_box.Text == "")
            {
                errorMessage += "phone is empty\n";
                testSuccess = true;
            }
            if (testSuccess)
            {
                MessageBox.Show(errorMessage);
                return;
            }
            if (!Regex.Match(first_name_txt.Text, @"^[a-zA-Z'.]{1,40}$").Success)
            {
                MessageBox.Show("Invalid first name");
                return;
            }
            if (!Regex.Match(last_name_txt.Text, @"^[a-zA-Z'.]{1,40}$").Success)
            {
                MessageBox.Show("Invalid last name");
                return;
            }
            if (!Regex.Match(date_of_birth_txt.Text, @"\d{2}/\d{2}/\d{4}").Success)
            {
                MessageBox.Show("xx/xx/xxxx Invalid birth format ");
                return;
            }
            DateTime UTCNow = DateTime.UtcNow;
            string year = UTCNow.Year.ToString();
            string month = UTCNow.Month.ToString();
            string day = UTCNow.Day.ToString();
            string systemFormat = month + "/" + day + "/" + year;


            int compareOrdinal = String.Compare(date_of_birth_txt.Text, systemFormat, StringComparison.Ordinal);

            if (compareOrdinal > 0)
            {
                MessageBox.Show( " date not valid ");
                return;
            }
            string[] words = date_of_birth_txt.Text.Split('/');
            int userYear = Int32.Parse(words[words.Length - 1]);
            int userMonth = Int32.Parse(words[words.Length - 3]);
            int userDay = Int32.Parse(words[words.Length - 2]);
            int age = Int32.Parse(year) - userYear;
            int currentTotaldays = Helper_Classes_namespace.HelperClass.getDaysUptoMonth(Int32.Parse(month));
            int userTotalDay = Helper_Classes_namespace.HelperClass.getDaysUptoMonth(userMonth);
            int differnce_of_day = ((currentTotaldays - userTotalDay) > 0 ? (currentTotaldays - userTotalDay) : 0);
            int remaning_days = differnce_of_day % 7;
            int weeks = differnce_of_day / 7;
            int totalDays = ((userDay - UTCNow.Day) > 0 ? (userDay - UTCNow.Day) : ((userDay - UTCNow.Day) * -1)) + remaning_days;
            age_txt_box.Text = age.ToString() + " yers " + weeks + " weeks " + totalDays + " days";
            if (!Regex.Match(phone_txt_box.Text, @"^\d{3}-\d{3}-\d{4}$").Success)
            {
                MessageBox.Show("xxx-xxx-xxxx phone number format is invalid!!!!!!! ");
                return;
            }
            
            string query = "SELECT * from credentials where first_name = '" + first_name_txt.Text
                            + "' AND last_name = '" + last_name_txt.Text
                            + "' AND date_of_birth = '" + date_of_birth_txt.Text +"'";
            
            SqlDataReader reader = Helper_Classes_namespace.DataBaseHelperClass.GlobalPerformQuery(query).ExecuteReader();
            if (reader.HasRows)
            {
                MessageBox.Show(" Update !!!!!!! ");
                query = "UPDATE credentials set first_name = '" + first_name_txt.Text
                            + "' ,last_name = '" + last_name_txt.Text
                            + "' ,date_of_birth = '" + date_of_birth_txt.Text
                            + "' ,phone = '" + phone_txt_box.Text
                            + "' where first_name = '" + first_name_txt.Text
                            + "' AND last_name = '" + last_name_txt.Text
                            + "' AND date_of_birth = '" + date_of_birth_txt.Text + "'";
            }
            else
            {
                //query = "INSERT INTO credentials(first_name,last_name,date_of_birth,phone) VALUES(" + first_name_txt.Text + "," + last_name_txt.Text + "," + date_of_birth_txt.Text + "," + phone_txt_box.Text + ")";
                query = "INSERT INTO credentials(first_name,last_name,date_of_birth,phone) VALUES('a','a','a','a')";


            }
            Helper_Classes_namespace.DataBaseHelperClass.ClosePerformQuery();
            Helper_Classes_namespace.DataBaseHelperClass.GlobalPerformQuery(query);
            Helper_Classes_namespace.DataBaseHelperClass.ClosePerformQuery();
            MessageBox.Show(" Field Inserted !!!!!!! ");

        }
    }
}
