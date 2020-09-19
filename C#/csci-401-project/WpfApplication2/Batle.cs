using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApplication1
{
    public partial class Batle : Form
    {
        Board ar;
        Board br;
        
        public Batle(Board a, Board b)
        {
            InitializeComponent();
            ar = a;
            br = b;
            
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            pictureBox1.Image = ar.Image;
            pictureBox2.Image = br.Image;
            Enemy.Text = ar.Life.ToString();
            Hero.Text = br.Life.ToString();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        { 
        }

        private void Enemy_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Hero_TextChanged(object sender, EventArgs e)
        {

        }

     
    }
}
