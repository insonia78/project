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
    public partial class GAME : Form
    {
        private int count = 0;
        private int target = 0;
        
        public GAME()
        {
            InitializeComponent();
            Random r = new Random();
            target = r.Next(1,100);
            
             
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPress_Click(object sender, EventArgs e)
        {
                 
           int number2;
           count++;
           if (Int32.TryParse(getNumber.Text, out number2) == false)
           {
               MessageBox.Show("You enterd and invalid value");
               getNumber.Clear();
           }
           else
           {
               
               number2 =Int32.Parse(getNumber.Text);
               if (number2 > 100 || number2 < 0)
               {
                   MessageBox.Show("you have enterd a invalid range");
                   getNumber.Clear();
                   
               }
               else
               {
                    
                    if (number2 > target)
                   {
                       this.toLow.BackColor = System.Drawing.Color.Black; 
                       this.toHigh.BackColor = System.Drawing.Color.Red;
                       getNumber.Clear();
                   }
                    else if (number2 < target)
                   {
                       this.toHigh.BackColor = System.Drawing.Color.Black;
                       this.toLow.BackColor = System.Drawing.Color.Blue;
                       getNumber.Clear();
                   }
                   else
                   {
                       
                       MessageBox.Show("ConGratulations\nThe number is "+ number2 +
                                        "\nyou found it in "+count+ " times");
                   }

               }

           }

        }

        private void toHigh_TextChanged(object sender, EventArgs e)
        {

        }

        private void toLow_TextChanged(object sender, EventArgs e)
        {

        }// end of method 

        
    }
}
