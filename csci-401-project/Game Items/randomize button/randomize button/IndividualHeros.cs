using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace randomize_button
{
    public partial class IndividualHeros : Form
    {
        int[] heroType = new int[5];
        
        bool[] gender = new bool[5];
        
        String[] hero_name = new String[5];
        String[] hero_type = new String[5];
        string name, name2;
        string herotype;
        bool h1WasClicked, h2WasClicked, h3WasClicked, h4WasClicked, h5WasClicked;

        MainWindow mw = new MainWindow();




        public IndividualHeros()
        {
           
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            h1WasClicked = false;
            this.Hide();
        }

        /// <this is supposed to determine which picture from the first form was clicked.
        /// <depending on which one was clicked, it is supposed to assign a value to hero type
        ///< its not working properly. maybe i'm not sending the value properly.
        private void hunterHero_Click(object sender, EventArgs e)
        {
           
            h1WasClicked = mw.hero1WasClicked;
            h2WasClicked = mw.hero1WasClicked;
            h3WasClicked = mw.hero1WasClicked;
            h4WasClicked = mw.hero1WasClicked;
            h5WasClicked = mw.hero1WasClicked;
            if (h1WasClicked == true)
            {
                herotype = "Hunter";
                hero_type[1] = herotype;
                MessageBox.Show("this is hero class in index" + " " + hero_type[1].ToString());
            }
            else
            {
                MessageBox.Show("Something isn't working");
            }
            
        }

        private void warriorHero_Click(object sender, EventArgs e)
        {
            h1WasClicked = mw.hero1WasClicked;
            h2WasClicked = mw.hero1WasClicked;
            h3WasClicked = mw.hero1WasClicked;
            h4WasClicked = mw.hero1WasClicked;
            h5WasClicked = mw.hero1WasClicked;
            if (h1WasClicked == true)
            {
                herotype = "Hunter";
                hero_type[1] = herotype;
                MessageBox.Show("this is hero class in index" + " " + hero_type[1].ToString());
            }
            else
            {
                MessageBox.Show("Something isn't working");
            }
        }
    }
}
