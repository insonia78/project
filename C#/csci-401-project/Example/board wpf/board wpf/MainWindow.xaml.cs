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
using ConsoleApplication1;
namespace WpfApplication1
{

    public partial class DataGridDetailsSample : Window
    {
        public DataGridDetailsSample()
        {
            InitializeComponent();
            List<Board> users = new List<Board>();
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    users.Add(new Enemy());
                }

                
            }
            dgUsers.ItemsSource = users;
        }

        
    }
}


