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
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Drawing;
using ConsoleApplication1;
using Accessibility;
namespace WpfApplication2
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        System.Windows.Forms.Tyle[,] play =  new System.Windows.Forms.Tyle[12,12];
        System.Windows.Forms.Integration.WindowsFormsHost[,] host = new System.Windows.Forms.Integration.WindowsFormsHost[12, 12];
        System.Windows.Controls.UserControl[,] terrain = new System.Windows.Controls.UserControl[12, 12];
        Board[,] play2 = new Board[12,12];
        PaintEventArgs g;
        bool Click = false;
        int i, j;
        bool validate = true;
        int z, y;
       
        int[,] table = new int[12, 12]
             {
           {00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00},
           {00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00},
           {00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00},
           {00, 00, 00, 00, 00, 02, 02, 00, 00, 00, 03, 00},
           {00, 00, 00, 04, 00, 02, 02, 00, 00, 00, 00, 00},
           {00, 00, 00, 00, 05, 00, 00, 00, 00, 03, 00, 00},
           {00, 00, 04, 00, 00, 00, 00, 00, 03, 00, 00, 00},
           {00, 00, 00, 04, 00, 00, 01, 00, 00, 00, 00, 00},
           {00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00},
           {00, 00, 00, 00, 00, 01, 00, 00, 00, 00, 00, 00},
           {00, 00, 00, 00, 1, 00, 00, 00, 00, 00, 00, 00},
           {00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00},
       };

        public MainWindow()
        {
             
           
            InitializeComponent();
            initializeBoard();
            placePeaces();
            //Move();
        }
        public void initializeBoard()
        {
            new WorldMap().Show();
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                   
                            host[i, j] = new System.Windows.Forms.Integration.WindowsFormsHost();

                            play[i, j] = new System.Windows.Forms.Tyle();
                            play[i, j].Size = new System.Drawing.Size(50, 50);
                            play[i, j].Row = i;
                            play[i, j].Col = j;
                            play[i, j].BorderStyle = BorderStyle.None;
                            play[i, j].Location = new System.Drawing.Point(j * 50 + 50, i * 50 + 50);
                            if (table[i, j] == 2)
                            {
                                play[i, j].BackColor = System.Drawing.Color.Blue;
                            }
                            else
                            {
                                play[i, j].BackColor = System.Drawing.Color.Green;
                            } 
                            
                            play[i, j].BackgroundImageLayout = ImageLayout.Center;

                            play[i, j].Click += new EventHandler(Tyle_Click);
                            play[i, j].Timer += new EventHandler(timer_Tick);

                            host[i, j].Child = play[i, j];
                   
                           
                            board.Children.Add(host[i, j]);
                             
                           
                  }
                }
            }
   

            
        
        private void Board_Loaded(object sender, RoutedEventArgs e)
        {

            
        }

        private void Capture_Table_TextInput(object sender, TextCompositionEventArgs e)
        {
            
        }

        private void Capture_Table_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
       
        

     }
  }

