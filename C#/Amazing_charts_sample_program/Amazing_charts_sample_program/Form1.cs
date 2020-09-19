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
        
        private FirstNameClass _firstNameClass = new FirstNameClass();
        private LastNameClass _lastNameClass = new LastNameClass();
        private DateOfBirth _dateOfBirth = new DateOfBirth();
        private PhoneClass _phone = new PhoneClass();
        private DataTable table;
        private List<Amazing_charts_sample_program_Patient_Format> dataSet;
        private bool selectedFromDatgaSet = true;
        public amazing_charts_sample_application()
        {
            InitializeComponent();
            dataSetView.CellClick += DataGridView1_CellContentClick_3;
            first_name_txt.MouseDoubleClick += new MouseEventHandler(mouseDBL_Click);
            last_name_txt.MouseDoubleClick += new MouseEventHandler(mouseDBL_Click);
            date_of_birth_txt.MouseDoubleClick += new MouseEventHandler(mouseDBL_Click);
            phone_txt_box.MouseDoubleClick += new MouseEventHandler(mouseDBL_Click);
            selectAllFromDataSet();
            setFocusOnTextBox();
        }
        private void setFocusOnTextBox()
        {            
            first_name_txt.GotFocus += OnFocus;
            last_name_txt.GotFocus += OnFocus;
            date_of_birth_txt.GotFocus += OnFocus;
            phone_txt_box.GotFocus += OnFocus;
        }
        private void removeFocusOnTextBox()
        {
            first_name_txt.GotFocus -= OnFocus;
            last_name_txt.GotFocus -= OnFocus;
            date_of_birth_txt.GotFocus -= OnFocus;
            phone_txt_box.GotFocus -= OnFocus;
        }
        private void OnFocus(object sender, EventArgs e)
        {
            selectedFromDatgaSet = false;
            dataSetView.CellClick += DataGridView1_CellContentClick_3;           
            
        }
        private void mouseDBL_Click(object sender, MouseEventArgs e)
        {            
            ClearTextBox();
            selectAllFromDataSet();
        }

        private void ClearTextBox()
        {
            age_txt_box.Text = "";
            first_name_txt.Text = "";
            last_name_txt.Text = "";
            date_of_birth_txt.Text= "";
            phone_txt_box.Text = "";

        }
        private Patient getTextBoxData(Patient p)
        {
            p.FirstName = first_name_txt.Text;
            p.LastName = last_name_txt.Text;
            p.DateOfBirth = date_of_birth_txt.Text;
            p.PhoneNumber = phone_txt_box.Text;
            return p;
        }
        private void first_name_txt_TextChanged(object sender, EventArgs e)
        {           
            if (first_name_txt.Text == "") return;            
            if (!Regex.Match(first_name_txt.Text, @"^[a-zA-Z'.]{1,40}$").Success)
            {
                MessageBox.Show("Invalid first name");
                return ;
            }
            
            if (!selectedFromDatgaSet)
            {                
                dataSet = _firstNameClass.getFirstName(new List<Amazing_charts_sample_program_Patient_Format>(), getTextBoxData(new Patient()));
                if (dataSet.Count == 0 && Helper_Classes_namespace.ErrorMessages.getErrorMessage().CompareTo("") != 0)
                {
                    MessageBox.Show(Helper_Classes_namespace.ErrorMessages.getErrorMessage());
                    return;
                }
                createDataSet(dataSet);
            }
        }
        private void createDataSet(List<Amazing_charts_sample_program_Patient_Format> data)
        {
            
            dataSetView.DataSource = "";
            table = new DataTable();
            table.Columns.Add("Index", typeof(int));
            table.Columns.Add("First Name", typeof(string));
            table.Columns.Add("Last Name", typeof(string));
            table.Columns.Add("Date of Birth", typeof(string));
            table.Columns.Add("Phone", typeof(string));
                        
            for (int i = 0; i < dataSet.Count;i++)
            {
                if(dataSet[i].GetType() == typeof(Patient))
                   table.Rows.Add(i, dataSet[i].FirstName, dataSet[i].LastName, dataSet[i].DateOfBirth, dataSet[i].PhoneNumber).CancelEdit();
            }
            
            dataSetView.DataSource = table;
        }
        private void last_name_txt_TextChanged(object sender, EventArgs e)
        {
            
            if (last_name_txt.Text == "")return ;
            
            if (!Regex.Match(last_name_txt.Text, @"^[a-zA-Z'.]{1,40}$").Success)
            {
                MessageBox.Show(" Invalid last name ");
                return ;
            }
            
            if (!selectedFromDatgaSet)
            {
                dataSet = _lastNameClass.getLastName(new List<Amazing_charts_sample_program_Patient_Format>(), getTextBoxData(new Patient()));
                if (dataSet.Count == 0 && Helper_Classes_namespace.ErrorMessages.getErrorMessage().CompareTo("") != 0)
                {
                    MessageBox.Show(Helper_Classes_namespace.ErrorMessages.getErrorMessage());
                    return;
                }                
                createDataSet(dataSet);
            }
        }
        private void getIndex(object sender, EventArgs e)
        {
            
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
                return;
            }
            if (!_dateOfBirth.testDate(date_of_birth_txt.Text))
            {
                MessageBox.Show(Helper_Classes_namespace.ErrorMessages.getErrorMessage());
                return;
            }

            if (!selectedFromDatgaSet)
            {
                dataSet = _dateOfBirth.getDateOfBirth(new List<Amazing_charts_sample_program_Patient_Format>(), getTextBoxData(new Patient()));
                if(dataSet.Count == 0)
                {
                    MessageBox.Show(Helper_Classes_namespace.ErrorMessages.getErrorMessage());
                    return;
                }
                createDataSet(dataSet);
            }
            age_txt_box.Text = _dateOfBirth.getAgeByBirthDate(date_of_birth_txt.Text);

        }

        private void phone_txt_box_TextChanged(object sender, EventArgs e)
        {
            
            if (phone_txt_box.Text == "")
            {                
                return ;
            }
            if (!Regex.Match(phone_txt_box.Text, @"^\d{3}-\d{3}-\d{4}$").Success)return;

            if (!_phone.testPhoneFormat(phone_txt_box.Text))
            {
                MessageBox.Show(Helper_Classes_namespace.ErrorMessages.getErrorMessage());
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
        private void selectAllFromDataSet()
        {
            string query = "SELECT * from credentials";
            var response = Helper_Classes_namespace.DataBaseHelperClass.GlobalPerformQuery(query);
            if (!(response.hasErrors))
            {
                SqlDataReader reader = response.command.ExecuteReader();
                dataSet = new List<Amazing_charts_sample_program_Patient_Format>();
                int index = 0;
                while (reader.Read())
                {
                    Patient patient = new Patient();
                    patient.FirstName  = reader["first_name"].ToString();
                    patient.LastName = reader["last_name"].ToString();
                    patient.DateOfBirth = reader["date_of_birth"].ToString();
                    patient.PhoneNumber = reader["phone"].ToString();
                    string[] tempDate = Helper_Classes_namespace.HelperClass.getSystemDateTime().Date.ToString().Split(' ');
                    patient.Age = Helper_Classes_namespace.HelperClass.getTotAge(patient.DateOfBirth, tempDate[0]);
                    dataSet.Insert(index, patient);
                    index++;

                }
                Helper_Classes_namespace.DataBaseHelperClass.ClosePerformQuery();
                dataSet =  _lastNameClass.QuickSortNow(dataSet, 0, dataSet.Count - 1);
                createDataSet(dataSet);
            }
            else
            {               
                    MessageBox.Show(Helper_Classes_namespace.ErrorMessages.getErrorMessage());
                    return;                
            }
        }
        private void save_Click(object sender, EventArgs e)
        {
            if (!_firstNameClass.testFirstName(first_name_txt.Text))
            {
                MessageBox.Show(Helper_Classes_namespace.ErrorMessages.getErrorMessage());
                return;
            }
            if (!_lastNameClass.testLastName(last_name_txt.Text))
            {
                MessageBox.Show(Helper_Classes_namespace.ErrorMessages.getErrorMessage());
                return;
            }

            if (!_dateOfBirth.testDate(date_of_birth_txt.Text))
            {
                MessageBox.Show(Helper_Classes_namespace.ErrorMessages.getErrorMessage());
                return;
            }

            if (!_phone.testPhoneFormat(phone_txt_box.Text))
            {
                MessageBox.Show(Helper_Classes_namespace.ErrorMessages.getErrorMessage());
                return;
            }

            string query = "SELECT * from credentials where first_name = '" + first_name_txt.Text
                            + "' AND last_name = '" + last_name_txt.Text
                            + "' AND date_of_birth = '" + date_of_birth_txt.Text +"'";
            
            
            string logEvent ="";

            var response = Helper_Classes_namespace.DataBaseHelperClass.GlobalPerformQuery(query);
            if (response.hasErrors)
            {
                MessageBox.Show(Helper_Classes_namespace.ErrorMessages.getErrorMessage());
                Helper_Classes_namespace.DataBaseHelperClass.ClosePerformQuery();
                return;
            }
            SqlDataReader reader = response.command.ExecuteReader();
            if (reader.HasRows)
            {
                query = "UPDATE credentials set first_name = '" + first_name_txt.Text
                            + "' ,last_name = '" + last_name_txt.Text
                            + "' ,date_of_birth = '" + date_of_birth_txt.Text
                            + "' ,phone = '" + phone_txt_box.Text
                            + "' where first_name = '" + first_name_txt.Text
                            + "' AND last_name = '" + last_name_txt.Text
                            + "' AND date_of_birth = '" + date_of_birth_txt.Text + "'";
                logEvent = "UPDATED \n" + first_name_txt.Text
                            + "\n" + last_name_txt.Text
                            + "\n" + date_of_birth_txt.Text.ToString()
                            + "\n" + phone_txt_box.Text;
            }
            else
            {
                query = "INSERT INTO credentials(first_name,last_name,date_of_birth,phone) VALUES('" + first_name_txt.Text + "','" + last_name_txt.Text + "','" + date_of_birth_txt.Text + "','" + phone_txt_box.Text + "')";
                logEvent = "INSERTED \n" + first_name_txt.Text
                            + "\n" + last_name_txt.Text
                            + "\n" + date_of_birth_txt.Text.ToString()
                            + "\n" + phone_txt_box.Text;
            }
            eventLogDisplay.AppendText("\n<---------------------->\n");
            eventLogDisplay.AppendText(logEvent);
            Helper_Classes_namespace.PerformWriteToFileAction.writeToLogFile(logEvent.Replace('\n', ' ') + " " +Helper_Classes_namespace.HelperClass.getSystemDateTime().ToLocalTime().ToString());
            Helper_Classes_namespace.DataBaseHelperClass.ClosePerformQuery();
            if (Helper_Classes_namespace.DataBaseHelperClass.GlobalPerformQuery(query) == null)
            {
                MessageBox.Show(Helper_Classes_namespace.ErrorMessages.getErrorMessage());
                Helper_Classes_namespace.DataBaseHelperClass.ClosePerformQuery();
                return;
            }            
            Helper_Classes_namespace.DataBaseHelperClass.ClosePerformQuery();
            MessageBox.Show(" Field Inserted !!!!!!! ");
            dataSetView.DataSource = "";
            table = new DataTable();
            table.Columns.Add("Index", typeof(int));
            table.Columns.Add("First Name", typeof(string));
            table.Columns.Add("Last Name", typeof(string));
            table.Columns.Add("Date of Birth", typeof(string));
            table.Columns.Add("Phone", typeof(string));
            table.Rows.Add(0, first_name_txt.Text, last_name_txt.Text, date_of_birth_txt.Text, phone_txt_box.Text).CancelEdit();
            dataSetView.DataSource = table;
           

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void DataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void DataGridView1_CellContentClick_3(object sender, DataGridViewCellEventArgs e)
        {
            setFocusOnTextBox();
            if (dataSet.Count <= e.RowIndex)
                return;
            ClearTextBox();
            dataSetView.CellClick -= DataGridView1_CellContentClick_3;
            selectedFromDatgaSet = true;
            
            try
            {
                eventLogDisplay.Select(eventLogDisplay.Text.Length, 0);
                first_name_txt.Text = dataSet[e.RowIndex].FirstName;
                last_name_txt.Text = dataSet[e.RowIndex].LastName;
                date_of_birth_txt.Text = dataSet[e.RowIndex].DateOfBirth;
                phone_txt_box.Text = dataSet[e.RowIndex].PhoneNumber;
                age_txt_box.Text = dataSet[e.RowIndex].Age;
                dataSetView.DataSource = "";
                table = new DataTable();
                table.Columns.Add("Index", typeof(int));
                table.Columns.Add("First Name", typeof(string));
                table.Columns.Add("Last Name", typeof(string));
                table.Columns.Add("Date of Birth", typeof(string));
                table.Columns.Add("Phone", typeof(string));
                table.Rows.Add(0, dataSet[e.RowIndex].FirstName, dataSet[e.RowIndex].LastName, dataSet[e.RowIndex].DateOfBirth, dataSet[e.RowIndex].PhoneNumber).CancelEdit();
                dataSetView.DataSource = table;
            }
            catch (IndexOutOfRangeException mes)
            {

            }
        }

        private void eventLog1_EntryWritten(object sender, System.Diagnostics.EntryWrittenEventArgs e)
        {

        }

        private void create_file_Click(object sender, EventArgs e)
        {
            if (!_firstNameClass.testFirstName(first_name_txt.Text))
            {
                MessageBox.Show(Helper_Classes_namespace.ErrorMessages.getErrorMessage());
                return;
            }
            if (!_lastNameClass.testLastName(last_name_txt.Text))
            {
                MessageBox.Show(Helper_Classes_namespace.ErrorMessages.getErrorMessage());
                return;
            }

            if (!_dateOfBirth.testDate(date_of_birth_txt.Text))
            {
                MessageBox.Show(Helper_Classes_namespace.ErrorMessages.getErrorMessage());
                return;
            }

            if (!_phone.testPhoneFormat(phone_txt_box.Text))
            {
                MessageBox.Show(Helper_Classes_namespace.ErrorMessages.getErrorMessage());
                return;
            }
            string query = "SELECT * from credentials where first_name = '" + first_name_txt.Text
                            + "' AND last_name = '" + last_name_txt.Text
                            + "' AND date_of_birth = '" + date_of_birth_txt.Text + "'";
            try
            {
                var response = Helper_Classes_namespace.DataBaseHelperClass.GlobalPerformQuery(query);
                if (response.hasErrors)
                {
                    MessageBox.Show(Helper_Classes_namespace.ErrorMessages.getErrorMessage());
                    Helper_Classes_namespace.DataBaseHelperClass.ClosePerformQuery();
                    return;
                }
                SqlDataReader reader = response.command.ExecuteReader();

                if (!reader.HasRows)
                {
                    MessageBox.Show(" Patient is not Saved!!!!!!");
                    Helper_Classes_namespace.DataBaseHelperClass.ClosePerformQuery();
                    return;
                }
                Helper_Classes_namespace.DataBaseHelperClass.ClosePerformQuery();
            }catch(System.Exception em)
            {
                Helper_Classes_namespace.ErrorMessages.setErrorMessage(em.ToString(), true);
                return;
            }

            string fileName = @"../../../" + first_name_txt.Text + "_" + last_name_txt.Text + "_" + date_of_birth_txt.Text.Replace('/', '-') + "_" + Helper_Classes_namespace.HelperClass.getSystemDateTime().ToLocalTime().ToString().Replace('/', '-').Replace(' ', '_').Replace(':', '-') + ".txt";
            string contactInformation = "First Name : " + first_name_txt.Text + "\r\n"
                                        + "Last Name : " + last_name_txt.Text + "\r\n"
                                        + "Date Of Birth : " + date_of_birth_txt.Text + "\r\n"
                                        + "Phone :" + phone_txt_box.Text;
            string logEvent = " >> created file " + first_name_txt.Text + "_" + last_name_txt.Text + "_" + date_of_birth_txt.Text.Replace('/', '-') + ".txt on " + Helper_Classes_namespace.HelperClass.getSystemDateTime().ToLocalTime();
            eventLogDisplay.AppendText("\n<---------------------->\n");
            eventLogDisplay.AppendText(logEvent);
            Helper_Classes_namespace.PerformWriteToFileAction.writeToLogFile(logEvent);
            Helper_Classes_namespace.PerformWriteToFileAction.createPatientFile(fileName, contactInformation);
            MessageBox.Show(" File Created ");
        }
    }
}
