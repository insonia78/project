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
using System.Windows.Threading;


namespace GameBoard
{
    partial class MainWindow
    {
         bool validate = true;
         int row;
         int col;
         int secondRow,
             secondCol;
         int firstRow, firstCol;
         private void moveCharacter(object sender, RoutedEventArgs e)
         {
             try
             {
                 row = (sender as Tile).Row;
                 col = (sender as Tile).Col;
             }
             catch
             {

             }
             if (validate == true)
             {

                 
                 firstRow = row;
                 firstCol = col;
                 validate = false;

             }
             else
             {
                 secondRow = row;
                 secondCol = col;
                 validate = true;
                 Move.IsEnabled = true;
             }
         }
                   
                

        }
    }

