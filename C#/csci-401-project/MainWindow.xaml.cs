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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Board a = new Board();
        public MainWindow()  
       {
        List<List<Board>> lsts = new List<List<Board>>();

        for (int i = 0; i < 5; i++)
        {
            lsts.Add(new List<Board>());

            for (int j = 0; j < 5; j++)
            {
                lsts[i].Add(new Board());
            }
        }

        InitializeComponent();

        lst.ItemsSource = lsts;
    
        }
    }
}
