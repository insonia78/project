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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms.Integration;
using System.Drawing;
using ConsoleApplication1;
namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class Hero1 : UserControl
    {
        Hero herosomething = new Hero();
        public Hero1()
        {
            InitializeComponent();
            PlaceHero();
        }
        public void PlaceHero()
        {
            System.Windows.Forms.Panel hero = new System.Windows.Forms.Panel();
            hero.BackgroundImage = herosomething.Image ;
            System.Windows.Forms.Button button = new System.Windows.Forms.Button();
            WindowsFormsHost host = new WindowsFormsHost();
            host.Child = hero ;


            PutImage.Children.Add(host);
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            
        }
    }
}
