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
using System.Collections;

namespace GameBoard
{
    public partial class MainWindow : Window
    {
        public void progressMap()
        {
            mapping = null;
            mapping = new int[numRows, numCols];
            for (int r = 0; r < numRows; r++)
            {
                for (int c = 0; c < numCols; c++)
                {
                    if (boardspaces[r, c].containsCharacter())
                    {
                        if (boardspaces[r, c].tileCharacter.GetType().IsSubclassOf(typeof(Community.Hero)))
                            mapping[r, c] = 1;
                        else //is an enemy
                            mapping[r, c] = 2;
                    }
                    else
                        mapping[r, c] = 0;
                }
            }
        }
    }
}
