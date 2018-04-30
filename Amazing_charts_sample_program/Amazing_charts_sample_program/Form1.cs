﻿using System;
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
        PhoneClass _phone = new PhoneClass();

        public amazing_charts_sample_application()
        {
            InitializeComponent();
        }

        private void first_name_txt_TextChanged(object sender, EventArgs e)
        {

            if (first_name_txt.Text == "") return;            
            if (!Regex.Match(first_name_txt.Text, @"^[a-zA-Z'.]{1,40}$").Success)
            {
                MessageBox.Show("Invalid first name");
                return ;
            }
            _firstNameClass.getFirstName(first_name_txt.Text);

        }

        private void last_name_txt_TextChanged(object sender, EventArgs e)
        {
            if (last_name_txt.Text == "")return ;
            
            if (!Regex.Match(last_name_txt.Text, @"^[a-zA-Z'.]{1,40}$").Success)
            {
                MessageBox.Show(" Invalid last name ");
                return ;
            }
            MessageBox.Show(_lastNameClass.getLastName(last_name_txt.Text));
        }

        private void date_of_birth_txt_TextChanged(object sender, EventArgs e)
        {
            age_txt_box.Text = "";
            if (date_of_birth_txt.Text == "")
            {                
                return ;
            }
            if (!Regex.Match(date_of_birth_txt.Text, @"\d{2}/\d{2}/\d{4}").Success)
            {
                if(date_of_birth_txt.Text.Length >= 10)
                    MessageBox.Show(" Invalid birth date mm/dd/yyyy ");
                return;
            }            
            if (!Helper_Classes_namespace.HelperClass.CompareDate(date_of_birth_txt.Text))
            {
                MessageBox.Show(" Invalid birth range date is over current date");
                return ;
            }
            try
            {
                DateTime dt = DateTime.Parse(date_of_birth_txt.Text);
            }
            catch
            {
                MessageBox.Show(" Invalid birth format range");
                return ;
            }
            if (!Regex.Match(date_of_birth_txt.Text, @"\d{2}/\d{2}/\d{4}").Success)
            {
                MessageBox.Show("mm/dd/yyyy Invalid birth format ");
                return ;
            }
            age_txt_box.Text = _dateOfBirth.getAgeByBirthDate(date_of_birth_txt.Text);
            _dateOfBirth.getDateOfBirth(date_of_birth_txt.Text);
        }

        private void phone_txt_box_TextChanged(object sender, EventArgs e)
        {
            if (phone_txt_box.Text == "")
            {                
                return ;
            }
            if (!Regex.Match(phone_txt_box.Text, @"^\d{3}-\d{3}-\d{4}$").Success)return;
            
            if (!Regex.Match(phone_txt_box.Text, @"^\d{3}-\d{3}-\d{4}$").Success)
            {
                MessageBox.Show("xxx-xxx-xxxx phone number format is invalid!!!!!!! ");
                return;
            }
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
            if(!_firstNameClass.testFirstName(first_name_txt.Text))return;
            if (!_lastNameClass.testLastName(last_name_txt.Text)) return;           
            if (!_dateOfBirth.testDate(date_of_birth_txt.Text))return;       
            age_txt_box.Text = _dateOfBirth.getAgeByBirthDate(date_of_birth_txt.Text);            
            if (!_phone.testPhoneFormat(phone_txt_box.Text))return;            
            string query = "SELECT * from credentials where first_name = '" + first_name_txt.Text
                            + "' AND last_name = '" + last_name_txt.Text
                            + "' AND date_of_birth = '" + date_of_birth_txt.Text +"'";
            
            SqlDataReader reader = Helper_Classes_namespace.DataBaseHelperClass.GlobalPerformQuery(query).ExecuteReader();
            if (reader == null)
                return;
            else if (reader.HasRows)
                query = "UPDATE credentials set first_name = '" + first_name_txt.Text
                            + "' ,last_name = '" + last_name_txt.Text
                            + "' ,date_of_birth = '" + date_of_birth_txt.Text
                            + "' ,phone = '" + phone_txt_box.Text
                            + "' where first_name = '" + first_name_txt.Text
                            + "' AND last_name = '" + last_name_txt.Text
                            + "' AND date_of_birth = '" + date_of_birth_txt.Text + "'";            
            else
               query = "INSERT INTO credentials(first_name,last_name,date_of_birth,phone) VALUES('" + first_name_txt.Text + "','" + last_name_txt.Text + "','" + date_of_birth_txt.Text + "','" + phone_txt_box.Text + "')";
            Helper_Classes_namespace.DataBaseHelperClass.ClosePerformQuery();
            Helper_Classes_namespace.DataBaseHelperClass.GlobalPerformQuery(query);
            Helper_Classes_namespace.DataBaseHelperClass.ClosePerformQuery();
            MessageBox.Show(" Field Inserted !!!!!!! ");

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
           // dataGridView1.
        }
    }
}
