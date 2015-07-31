using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using MultiUnitNamespace;

namespace HousingProgram
{
    public partial class HousingManager : Form
    {
        int number;
        string address;
        string typeOfHouse;
        int yearBuilt;
        
        public HousingManager()
        {
            InitializeComponent();
        }

        private void yearBuildt_Click(object sender, EventArgs e)
        {

        }

        private void rBSingleFamily_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            typeOfHouse = comboBox1.Text;
            address = txtAddress.Text;
            number = Convert.ToInt16(txtNumber.Text);
            yearBuilt = Convert.ToInt32(txtYearBuilt.Text); 
            if (rBMultyUnit.Checked == true)
            {
                MultiUnit a = new MultiUnit(number,typeOfHouse,address,yearBuilt);
                MessageBox.Show(a.Print()); 
            }
            new Viue().Show();
        }

        private void rBMultyUnit_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtYearBuilt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
