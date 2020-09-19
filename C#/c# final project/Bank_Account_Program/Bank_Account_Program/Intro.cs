using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Intro : Form
    {
        public Intro()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnEnterAccountInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The program acts like a small database\nIt stores accounts in a system of parallel arraylist\n"
                             +"Once you have saved the account you can recal it by entering the accountNumber","Message",MessageBoxButtons.OK,MessageBoxIcon.Information); 
            new Account_info().Show();
             
            this.Hide();
             
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
