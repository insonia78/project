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

namespace GameBoard
{
    /// <summary>
    /// Interaction logic for mapBuilder.xaml
    /// </summary>
    public partial class mapBuilder : Window
    {
        private Grid[,] cells;
        private Tile[,] mapSpaces;
        private int numRows, numCols;
        private int tileType;

        public mapBuilder()
        {
            tileType = 2;
            numRows = 15;
            numCols = 15;
            cells = new Grid[numRows, numCols];
            mapSpaces = new Tile[numRows, numCols];
            InitializeComponent();
            for (int r = 0; r < numRows; r++)
            {
                for (int c = 0; c < numCols; c++)
                {
                    Grid cell = new Grid();
                    mapSpaces[r,c] = new Tile(r,c, 0);
                    mapSpaces[r,c].Click += new RoutedEventHandler(Space_Click);
                    ImageBrush backgroundImage;
                    backgroundImage = new ImageBrush(mapSpaces[r, c].terrainImage.terrainImage);
                    mapSpaces[r, c].Background = backgroundImage; //Set the background of the tile button to the terrain image.
                    mapSpaces[r,c].BorderThickness = new Thickness(0);
                    cells[r, c] = cell;
                    cell.Children.Add(mapSpaces[r,c]);
                    Map.Children.Add(cell);
                }
            }
        }

        private void Space_Click(object sender, RoutedEventArgs e)
        {
            int row = 0;
            int col = 0;

            try
            {
                //Get the row and column of the tile button that was clicked (Row and Col are accessors in Tile).
                row = (sender as Tile).Row;
                col = (sender as Tile).Col;
            }
            catch
            {

            }

            cells[row, col].Children.Clear();
            mapSpaces[row, col] = new Tile(row, col, tileType);
            mapSpaces[row, col].Click += new RoutedEventHandler(Space_Click);
            ImageBrush backgroundImage;
            backgroundImage = new ImageBrush(mapSpaces[row, col].terrainImage.terrainImage);
            mapSpaces[row, col].Background = backgroundImage; //Set the background of the tile button to the terrain image.
            mapSpaces[row, col].BorderThickness = new Thickness(0);
            cells[row, col].Children.Add(mapSpaces[row, col]);
        }
    }
}
