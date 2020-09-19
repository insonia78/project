using System;
using System.IO;
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
    /*
     * The implementation of the logical side of the game board as a whole, holds a 2d array of Tile objects, and contains methods for manipulating 
     * the contents of these tiles (their characters, mostly) as well as various other required operations on the board's tiles to make the actions in the game possible 
     * (advancing turns, making the enemies act, calculating a player's move options, etc). 
     * Also holds other relavent game information such as the number of turns.
     */
    public partial class MainWindow
    {
        //instance variables
        private int numRows;
        private int numCols;
        private int numTurns;
        private int numHeroes;
        private int numEnemies;
        private Tile[,] boardspaces;
        
         
 
        //accessors and mutators
        public int numberRows
        {
            get
            {
                return numRows;
            }
            set { }
        }
        public int numberCols
        {
            get
            {
                return numCols;
            }
            set { }
        }
        public int heroNumber
        {
            get
            {
                return numHeroes;
            }
            set { }
        }
        public int enemyNumber
        {
            get
            {
                return numEnemies;
            }
            set { }
        }
        public int turnNumber
        {
            get
            {
                return numTurns;
            }
            set { }
        }

        //constructors
        /*
         * Constructor for a blank board, makes a default board of all empty spaces
         */
        public void setupBoard()
        {
            numRows = 15;
            numCols = 15;
            numTurns = 1;
            numEnemies = 0;
            numHeroes = 5;
            boardspaces = new Tile[numRows, numCols];
            cells = new Grid[numRows, numCols]; //a 2d array of references to the grid cells that make up the board tiles graphically
            HeroesCounter.Content = ("Heroes Remaining: " + numHeroes);
            for(int r = 0; r < numRows; r++)
            {
                for(int c = 0; c < numCols; c++)
                {
                    boardspaces[r, c] = new Tile(r,c);

                    Grid cell = new Grid(); //Make a new grid object to contain the tile/character objects/buttons, images
                    cells[r, c] = cell;

                    refreshBoardSpace(r, c); //Draws the space for the first time
                    Board.Children.Add(cell);
                }
            }
        }

        /*
         * Constructor for setting up a board defined in a text file using various characters in the text file to determine the terrain type of each tile.
         * The input is read character by character, so the file should not be broken up with spaces or with multiple lines.
         * 0 = grass, 1 = mountain, 2 = water, 3 = swamp, other = defaults to grass. In the code, these are returned as their ascii code numbers, and have to be tested accordingly.
         * If the text file is not found, makes a blank, default board instead.
         * 
         * String mapfile = the name of the text file to read input from (Example: "testmap.txt")
         */
        public void setupBoard(String mapfile)
        {
            numRows = 15;
            numCols = 15;
            numTurns = 1;
            numEnemies = 0;
            numHeroes = 5;
            boardspaces = new Tile[numRows, numCols];
            HeroesCounter.Content = ("Heroes Remaining: " + numHeroes);
            cells = new Grid[numRows, numCols]; //a 2d array of references to the grid cells that make up the board tiles graphically

            if(!File.Exists(mapfile))
            {
                setupBoard();//make a blank board instead
            }
            else
            {
                using (StreamReader sr = File.OpenText(mapfile))
                {
                    int input;
                    for (int r = 0; r < numRows; r++)
                    {
                        for (int c = 0; c < numCols; c++)
                        {
                            input = sr.Read(); //read the next character in the txt file
                            switch (input)
                            {
                                case 48: //ascii code number for 0, grass (The StreamReader is reading them in as their ascii values)
                                    boardspaces[r, c] = new Tile(r,c,0);
                                    break;
                                case 49: //ascii code number for 1, mountain
                                    boardspaces[r, c] = new Tile(r,c,1);
                                    break;
                                case 50: //ascii code number for 2, water
                                    boardspaces[r, c] = new Tile(r,c,2);
                                    break;
                                case 51: //ascii code number for 3, swamp
                                    boardspaces[r, c] = new Tile(r,c,3);
                                    break;
                                default: //if no input or invalid input found in the file, make a blank grass space instead
                                    boardspaces[r, c] = new Tile(r,c);
                                    break;
                            }

                            Grid cell = new Grid(); //Make a new grid object to contain the tile/character objects/buttons, images
                            cells[r, c] = cell;

                            refreshBoardSpace(r, c); //Draws the space for the first time
                            Board.Children.Add(cell);
                        }
                    }
                }
            }
        }

        /*
         * Moves/copies a character from an old position to a specified new one if the position is within the 2d array's bounds and the new space contains no characters.
         * "Clears" the old tile of the character by setting it to null afterwards.
         * 
         * int oldRow = the row the character is currently in.
         * int oldCol = the column the character is currently in.
         * int newRow = the new row of the desired position to move the character to.
         * int newCol = the new column of the desired position to move the character to.
         */
        public void moveCharacter(int oldRow, int oldCol, int newRow, int newCol)
        {
            if (newRow >= 0 && newRow < numRows && newCol >= 0 && newCol < numCols && boardspaces[newRow, newCol].tileCharacter == null && boardspaces[newRow, newCol].isUnpassable == false)
            {
                boardspaces[newRow, newCol].tileCharacter = boardspaces[oldRow, oldCol].tileCharacter;
                //Update the character's row/column information
                boardspaces[newRow, newCol].tileCharacter.Row = newRow;
                boardspaces[newRow, newCol].tileCharacter.Col = newCol;
                boardspaces[oldRow, oldCol].tileCharacter = null;
                //redraw the two spaces (otherwise the character won't be visible in the new space, and the image will remain in the old space).
                refreshBoardSpace(oldRow, oldCol);
                refreshBoardSpace(newRow, newCol);
            }
        }

        /*
         * Recursive algorithm. Takes the position and speed of a character, and checks all adjacent (horizontal / vertical, not diagonal) tiles to see
         * if they can be moved to. If more speed remains, checks those tiles to see what adjacent tiles to that tile can be moved to from there, until speed = 0.
         * Tile can only be moved to if it is within the 2d array's bounds, it isn't "solid/unpassable" terrain, and it contains no character.
         * If a tile can be moved to, the tile's isMoveOption is set to true for use when displaying/adding buttons on the map interface.
         * Allows for types of terrain that "slows down" a character (takes multiple "speed" to travel through).
         * 
         * int speed = the value of the character's speed.
         * int row  = the row the character is located in.
         * int col = the column the character is located in.
         */
        public void moveOptions(int speed, int row, int col)
        {
            boardspaces[row,col].isMoveOption = true; //base case
            if(speed > 0)
            {
                
               
                //up movement
                if (row - 1 >= 0 && boardspaces[row - 1, col].isUnpassable == false && boardspaces[row - 1, col].tileCharacter == null)
                {
                    moveOptions(speed - boardspaces[row - 1, col].requiredMoveSpeed, row - 1, col); //Subtract the required movement speed to move through of the next tile from the remaining speed points
                }
                //down movement
                if (row + 1 < numRows && boardspaces[row + 1, col].isUnpassable == false && boardspaces[row + 1, col].tileCharacter == null)
                {
                    moveOptions(speed - boardspaces[row + 1, col].requiredMoveSpeed, row + 1, col);
                }
                //left movement
                if (col - 1 >= 0 && boardspaces[row, col - 1].isUnpassable == false && boardspaces[row, col - 1].tileCharacter == null)
                {
                    moveOptions(speed - boardspaces[row, col - 1].requiredMoveSpeed, row, col - 1);
                }
                //right movement
                if (col + 1 < numCols && boardspaces[row, col + 1].isUnpassable == false && boardspaces[row, col + 1].tileCharacter == null)
                {
                    moveOptions(speed - boardspaces[row, col + 1].requiredMoveSpeed, row, col + 1);
                }
            }
        }

        /*
         * Loops through the 2d array of board spaces and sets every tile's isMoveOption to false. For use after determining and displaying all move options for a 
         * selected player, clearing all those options afterwards so the variables are ready to display the next player's options.
         */
        public void clearMoveOptions()
        {
            for(int r = 0; r < numRows; r++)
            {
                for(int c = 0; c < numCols; c++)
                {
                    if (boardspaces[r, c].isMoveOption)
                    {
                        boardspaces[r, c].isMoveOption = false;
                        boardspaces[r, c].Click -= new RoutedEventHandler(MoveOption_Click);
                        refreshBoardSpace(r, c);
                    }
                }
            }
        }

        /*
         * After the user performs all moves/actions, calls the enemyTurn() method, which handles enemy movement/actions/calls to AI, and
         * resets certain attributes for players/enemies that are only for that specific turn (hasMoved, for example), and decreases the amount of turns any effects on them will last.
         * Also increments the turn counter.
         */
        public void nextTurn()
        {
            enemyTurn();
            for (int r = 0; r < numRows; r++)
            {
                for (int c = 0; c < numCols; c++)
                {
                    if (boardspaces[r, c].containsCharacter() == true)
                    {
                        boardspaces[r, c].tileCharacter.decrementEffectDurations();
                        boardspaces[r, c].tileCharacter.isActive = true;
                        refreshBoardSpace(r,c);
                    }
                }
            }

            numTurns++;
            TurnCounter.Content = ("Turn " + turnNumber);
        }

        /*
         * Called on by nextTurn(), loops through the 2d board array, finds every remaining enemy, sets hasMoved = true for that enemy (so that if they move down and/or
         * to the right, the for loops won't encounter those enemies again and move them again) and then calls the enemyMoveAI method for that enemy to determine 
         * where to move them.
         */
        public void enemyTurn()
        {
            for(int r = 0; r < numRows; r++)
            {
                for(int c = 0; c < numCols; c++)
                {
                    if (boardspaces[r, c].containsCharacter() == true && boardspaces[r, c].tileCharacter.GetType().IsSubclassOf(typeof(GameBoard.Enemy)) && boardspaces[r, c].tileCharacter.hasMoved == false)
                    {
                        boardspaces[r, c].tileCharacter.hasMoved = true;
                        enemyMoveAI(r, c);
                        //For some reason, enemeies are all moving in the same direction (or at least when close to each other)
                        //may be because the random number generator is being called too quickly back to back?
                    }
                }
            }
        }

        /*
         * Temporary, really sucky enemy movement AI and calls the moveCharacter method to move the enemy once a random direction (vertical, horizontal, or diagonal)
         * has been generated.
         * 
         * int row = the row that the enemy to be moved is currently in
         * int col = the column that the enemy to be moved is currently in
         */
        public void enemyMoveAI(int row, int col)
        {
            Random rng = new Random();
            int deltaRow = 1 - rng.Next(0, 3); //Can generate 0, 1, or 2. If 0 generated, 1 - 0 = 1, move down 1. If 1, 1 - 1 = 0, no vertical change. If 2, 1 - 2 = -1, move up 1.
            int deltaCol = 1 - rng.Next(0, 3); //Similar to the deltaRow rng usage, but controls horizontal movement. If deltaRow & deltaCol both != 0, diagonal movement.
            moveCharacter(row, col, row + deltaRow, col + deltaCol); 
        }

        /*
         * Loops through the 2d array of board spaces and counts the number of enemy objects (or subclasses of enemy) for use in displaying as well as confirming a win condition
         */
        public void countEnemies()
        {
            numEnemies = 0;
            for (int r = 0; r < numRows; r++)
            {
                for (int c = 0; c < numCols; c++)
                {
                    if (boardspaces[r, c].containsCharacter() == true && (boardspaces[r, c].tileCharacter.GetType() == typeof(GameBoard.Enemy) || boardspaces[r, c].tileCharacter.GetType().IsSubclassOf(typeof(GameBoard.Enemy))))
                    {
                        numEnemies++;
                    }
                }
            }
        }

        /*
         * Loops through the 2d array of board spaces and checks if all player objects (or subclass objects of player) have isActive = false, in order to see if 
         * every player character has taken their turn and the turn can automatically end.
         * 
         * returns false if any players are active, true if they all have.
         */
        public bool checkAllPlayersInactive()
        {
            for (int r = 0; r < numRows; r++)
            {
                for (int c = 0; c < numCols; c++)
                {
                    if (boardspaces[r, c].containsCharacter() == true && (boardspaces[r, c].tileCharacter.GetType() == typeof(GameBoard.Hero) || boardspaces[r, c].tileCharacter.GetType().IsSubclassOf(typeof(GameBoard.Hero))) && boardspaces[r, c].tileCharacter.isActive == true)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}
