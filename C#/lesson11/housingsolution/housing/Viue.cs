using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiUnitNamespace;

namespace HousingProgram
{
    public partial class Viue : Form
    {
        MultiUnit multiUnit = new MultiUnit();
        public Viue()
        {
            InitializeComponent();
            richTextBox1.Text = multiUnit.Print();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
