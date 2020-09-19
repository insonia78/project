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
    public partial class MainWindow
    {

        
        int index1, index2; 
        Tile swamp1, swamp2;
      
        Brush colorTemp;
        Brush imageTemp;

        private void Move_Click(object sender, RoutedEventArgs e)
        {
          index1 = Board.Children.IndexOf(terrain[firstRow,firstCol]);
          index2 = Board.Children.IndexOf(terrain[secondRow,secondCol]);
                   
                
            

            Board.Children.Remove(terrain[secondRow, secondCol]);
            Board.Children.Remove(terrain[firstRow, firstCol]);
            terrain[secondRow, secondCol].Click -= moveCharacter;
            terrain[firstRow, firstCol].Click -= moveCharacter;
            swamp2 = terrain[secondRow, secondCol];
            swamp1 = terrain[firstRow, firstCol];
            colorTemp = terrain[secondRow, secondCol].Background;
            imageTemp = terrain[firstRow, firstCol].Background;
            

            terrain[firstRow, firstCol] = swamp2;
            terrain[firstRow, firstCol].Row = firstRow;
            terrain[firstRow, firstCol].Col = firstCol;
            terrain[firstRow, firstCol].Background = colorTemp;
            terrain[firstRow, firstCol].Click += moveCharacter;
            Board.Children.Insert(index1,terrain[firstRow, firstCol]);

            terrain[secondRow, secondCol] = swamp1;
            terrain[secondRow, secondCol].Row = secondRow;
            terrain[secondRow, secondCol].Col = secondCol;
            terrain[secondRow, secondCol].Background = imageTemp;
            terrain[secondRow, secondCol].Click += moveCharacter;
            Board.Children.Insert(index2, terrain[secondRow, secondCol]);
            Move.IsEnabled = false;


        }
               
    }
}


