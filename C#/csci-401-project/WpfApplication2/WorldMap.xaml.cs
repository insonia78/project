using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using ConsoleApplication1;
namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class WorldMap : Window
    {
        Window1 window = new Window1();
        Hero hero = new Hero();
        WindowsFormsHost host = new WindowsFormsHost();
        Hero2 hero1 = new Hero2();
        public WorldMap()
        {
            InitializeComponent();
          
           // Slot1.Source = hero.Image1;
           
            hero1.BackgroundImage = hero.Image; 
            hero1.MouseEnter += new EventHandler(Hero_Inn);
            hero1.MouseLeave += new EventHandler(Hero_Out);
            host.Child = hero1;
            Hero1.Children.Add(host);
           
        }
        private void Hero_Inn(object sender, EventArgs e)
        {
            window.Show();
        }
        private void Hero_Out(object sender, EventArgs e)
        {
            window.Hide();
        }

        private void Image_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            window.Show();

        }
        private void Image_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            window.Hide();

        }


       
    }
}
