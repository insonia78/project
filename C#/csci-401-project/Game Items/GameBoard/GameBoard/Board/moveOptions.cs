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
        int speed;
       
        public void moveOptions()
        {
            terrain[row, col].isMoveOption = true;
            if (speed > 0)
            {
                //up
                if (row - 1 >= 0 && terrain[row, col].tileTerrain != 1 && terrain[row, col].tileTerrain != 2 && terrain[row, col].tileCharacter == null)
                {
                    if (terrain[row, col].tileTerrain == 3)
                    {
                        terrain[row, col].Background = moveOption;
                        terrain[row, col].Opacity = 0.30; 
                        speed -= 2; row -= 1;
                        moveOptions();
                        
                    }
                    else
                    {
                        terrain[row, col].Background = moveOption;
                        terrain[row, col].Opacity = 0.30; 
                        speed -= 1; row -= 1; 
                        moveOptions();
                    }
                    terrain[row, col].isMoveOption = true;
                }
                //down
                if (row + 1 <= 19 && terrain[row, col].tileTerrain != 1 && terrain[row, col].tileTerrain != 2 && terrain[row, col].tileCharacter == null)
                {
                    if (terrain[row, col].tileTerrain == 3)
                    {
                        terrain[row, col].Background = moveOption;
                        terrain[row, col].Opacity = 0.30; 
                        speed -= 2; row -= 1;
                        moveOptions();
                    }
                    else
                    {
                        terrain[row, col].Background = moveOption;
                        terrain[row, col].Opacity = 0.30; 
                        speed -= 1; row += 1;
                        moveOptions();
                    }
                    terrain[row, col].isMoveOption = true;
                }
                //left
                if (col - 1 >= 0 && terrain[row, col].tileTerrain != 1 && terrain[row, col].tileTerrain != 2 && terrain[row, col].tileCharacter == null)
                {
                    if (terrain[row, col].tileTerrain == 3)
                    {
                        terrain[row, col].Background = moveOption;
                        terrain[row, col].Opacity = 0.30; 
                        speed -= 2; col -= 1;
                        moveOptions();
                    }
                    else
                    {
                        terrain[row, col].Background = moveOption;
                        terrain[row, col].Opacity = 0.30; 
                        speed -= 1; col -= 1;
                        moveOptions();
                    }
                    terrain[row, col].isMoveOption = true;
                }
                //right
                if (col + 1 <= 19 && terrain[row, col].tileTerrain != 1 && terrain[row, col].tileTerrain != 2 && terrain[row, col].tileCharacter == null)
                {
                    if (terrain[row, col].tileTerrain == 3)
                    {
                        terrain[row, col].Background = moveOption;
                        terrain[row, col].Opacity = 0.30; 
                        speed = -2; col += 1;
                        moveOptions();
                    }
                    else
                    {
                        terrain[row, col].Background = moveOption;
                        terrain[row, col].Opacity = 0.30; 
                        speed -= 1; col += 1;
                        moveOptions();
                    }
                    terrain[row, col].isMoveOption = true;
                }
            }
        }
    }
}
