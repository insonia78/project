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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

      
        
         const int boardRow = 15;
         const int boardCol = 15;
        Tile[,] terrain = new Tile[boardRow, boardCol];
        Grid[,] cell = new Grid[boardRow, boardCol];
        SolidColorBrush grass = new SolidColorBrush(Colors.Green);
        SolidColorBrush mountain = new SolidColorBrush(Colors.Gray);
        SolidColorBrush water = new SolidColorBrush(Colors.Blue);
        SolidColorBrush swamp = new SolidColorBrush(Colors.Brown);
        SolidColorBrush black = new SolidColorBrush(Colors.Black);
        SolidColorBrush red = new SolidColorBrush(Colors.Red);
        SolidColorBrush moveOption = new SolidColorBrush(Colors.Yellow);

        int[,] table = 
             {
           {00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00,0,0,0},
           {00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00,0,0,0},
           {00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00,0,0,0},
           {00, 00, 00, 00, 00, 02, 02, 00, 00, 00, 03, 00,0,0,0},
           {00, 00, 00, 04, 00, 02, 02, 00, 00, 00, 00, 00,0,0,0},
           {00, 00, 00, 00, 05, 00, 00, 00, 00, 03, 00, 00,0,0,0},
           {00, 00, 04, 00, 00, 00, 00, 00, 03, 00, 00, 00,0,0,0},
           {00, 00, 00, 04, 00, 00, 01, 00, 00, 00, 00, 00,0,0,0},
           {00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00,0,0,0},
           {00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00,0,0,0},
           {00, 00, 00, 00, 0, 00, 00, 00, 00, 00, 00, 00,0,0,0},
           {00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00,0,0,0},
           {00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00,0,0,0},
           {00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00,0,0,0},
           {00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00,0,0,0},
       };
             
        /*
         * Initializes the GUI components, creates the cells 2d array, and renders the board/board spaces/characters, etc. for the first time.
         */
        public MainWindow()
        {
            
           
            InitializeComponent();
           
            setUpBoard();
            
        }
       

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Board_Loaded(object sender, RoutedEventArgs e)
        {


        }

        private void status_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        
        
        /*
         * After any changes to the stat of the board/the contained tiles & characters, or information on the display needs to be updated, this method is called.
         * Clears the UnifRomGrid that displays the board, and then remakes it, placing any characters & buttons as it goes along.
         */
        

        //Events of test moving buttons being clicked - does not move enemies, doesn't count as a turn, to move the player without changing the board for ease of testing
        //Will be removed later.
      /*  private void UpButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedPlayerRow > 0 && board.boardSpace(selectedPlayerRow - 1, selectedPlayerCol).containsCharacter() == false)
            {
                board.moveCharacter(selectedPlayerRow, selectedPlayerCol, selectedPlayerRow - 1, selectedPlayerCol);
                selectedPlayerRow--;
                render();
            }
        }
        private void RightButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedPlayerCol < 19 && board.boardSpace(selectedPlayerRow, selectedPlayerCol + 1).containsCharacter() == false)
            {
                board.moveCharacter(selectedPlayerRow, selectedPlayerCol, selectedPlayerRow, selectedPlayerCol + 1);
                selectedPlayerCol++;
                render();
            }
        }
        private void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedPlayerCol > 0 && board.boardSpace(selectedPlayerRow, selectedPlayerCol - 1).containsCharacter() == false)            
            {
                board.moveCharacter(selectedPlayerRow, selectedPlayerCol, selectedPlayerRow, selectedPlayerCol - 1);
                selectedPlayerCol--;
                render();
            }
        }
        private void DownButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedPlayerRow < 19 && board.boardSpace(selectedPlayerRow + 1, selectedPlayerCol).containsCharacter() == false)
            {
                board.moveCharacter(selectedPlayerRow, selectedPlayerCol, selectedPlayerRow + 1, selectedPlayerCol);
                selectedPlayerRow++;
                render();
            }
        }
        //end of test buttons to be removed.
        */
        /*
         * When the user clicks on a player character, bring up the interface to select their action/movement
         */
       /*
        private void Player_Click(object sender, RoutedEventArgs e)
        {
            board.clearMoveOptions(); //set all move options that were previously left as true to false before calculating the current ones.

            //loop through the grid cells/tiles to see which one the user's mouse was over when a player button was clicked - locates which player was selected
            for (int r = 0; r < board.numberRows; r++)
            {
                for (int c = 0; c < board.numberCols; c++)
                {
                    if (cells[r, c].IsMouseOver)
                    {
                        selectedPlayerRow = r;
                        selectedPlayerCol = c;
                    }
                }
            }
            if (!board.boardSpace(selectedPlayerRow, selectedPlayerCol).tileCharacter.hasMoved) //check to make sure the player hasn't already been moved, if not, bring up move options
            {
                board.moveOptions(board.boardSpace(selectedPlayerRow, selectedPlayerCol).tileCharacter.speed, selectedPlayerRow, selectedPlayerCol);
            }
            render(); 
        }
        */
        /*
         * When a user clicks on one of the buttons to move to a tile, move the player character there, advance the turn if all players have been moved.
         */
        /*
        private void MoveOption_Click(object sender, RoutedEventArgs e)
        {
            int newRow = selectedPlayerRow;
            int newCol = selectedPlayerCol;
            //loop through the grid cells/tiles to see which one the user's mouse was over when a move button was clicked - locates which space was selected
            for (int r = 0; r < board.numberRows; r++)
            {
                for (int c = 0; c < board.numberCols; c++)
                {
                    if(cells[r, c].IsMouseOver)
                    {
                        newRow = r;
                        newCol = c;
                    }
                }
            }
            board.moveCharacter(selectedPlayerRow, selectedPlayerCol, newRow, newCol);
            board.boardSpace(newRow, newCol).tileCharacter.hasMoved = true;
            if (board.checkAllPlayersMoved())
            {
                board.nextTurn();
            }
            selectedPlayerRow = newRow;
            selectedPlayerCol = newCol;
            board.clearMoveOptions();
            render();
            */
        }
    }
