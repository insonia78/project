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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Mostly deals with the visual/interface side of the game board.
    /// </summary>
    public partial class MainWindow : Window
    {
        private Grid[,] cells; //2D array of containers to add to the Board uniformGrid to hold the tiles
        SolidColorBrush moveOption = new SolidColorBrush(Colors.Yellow);
        SolidColorBrush attackOption = new SolidColorBrush(Colors.Red);

        //stores a reference to the location of a Hero when it's selected (need the hero's location even when clicking on buttons for different spaces).
        private int selectedHeroRow;
        private int selectedHeroCol;

        //For the animated movement
        private int moveToRow;
        private int moveToCol;
        private int indexOfCol;
        private int indexOfRow;
        private int dummyRow;
        private int dummyCol;
        private int index = 0;
        private int moveRow = 0, moveCol = 0;
        private object[,] position = new object[15, 15];
        DispatcherTimer timer = new DispatcherTimer();
        ArrayList rowPlot = new ArrayList();
        ArrayList colPlot = new ArrayList();

        /*
         * Initializes the GUI components, creates the cells 2d array, and sets up the board/tiles/characters, etc.
         */
        public MainWindow()
        {
            InitializeComponent();
            setupBoard("testmap.txt");
            selectedHeroRow = 0;
            selectedHeroCol = 0;

            //For testing purposes, characters added in this way. When the game is at the point where the hero data is taken from the world map, or
            //is global to the whole program, and setUpBoard() can read positions to add the characters, then they will be added in setUpBoard() rather than here.
            boardspaces[4, 1].tileCharacter = new Warrior(4,1,4);
            refreshBoardSpace(4, 1);
            boardspaces[1, 2].tileCharacter = new Mage(1,2,3);
            refreshBoardSpace(1, 2);
            boardspaces[5, 5].tileCharacter = new Enemy_Warrior(5, 5, 2);
            refreshBoardSpace(5, 5);
            boardspaces[11, 9].tileCharacter = new Enemy_Warrior(11,9,2);
            refreshBoardSpace(11, 9);
            boardspaces[13, 8].tileCharacter = new Enemy_Healer(13,8,3);
            refreshBoardSpace(13, 8);
            boardspaces[14, 3].tileCharacter = new Enemy_Hunter(14,3,1);
            refreshBoardSpace(14, 3);
        }

        /*
         * Clears, then re-adds the elements to be displayed on the specified space based on the tile's data. Used to remove elements that were added to the space that can't be
         * removed directly, restoring the tile to the state it's supposed to be in.
         * 
         * int r, c = the row, column of the space to refresh.
         */
        private void refreshBoardSpace(int r, int c)
        {
            cells[r, c].Children.Clear(); //Clear everything that's in the cell, now an empty Grid object
            ImageBrush backgroundImage;

            boardspaces[r, c].Click -= new RoutedEventHandler(Character_Click); //Remove the Hero_Click event from the cell in case there is one (from moving characters off a space). Otherwise, sometimes it remains and do bad stuff.
            boardspaces[r, c].Click += new RoutedEventHandler(Tile_Click); //Add the Tile_Click event to the cell's button in case it isn't already on (will sometimes disappear otherwise).

            backgroundImage = new ImageBrush(boardspaces[r, c].terrainImage.terrainImage);
            boardspaces[r, c].Background = backgroundImage; //Set the background of the tile button to the terrain image.
            boardspaces[r, c].BorderThickness = new Thickness(0); //Remove the tile button's border
            cells[r,c].Children.Add(boardspaces[r, c]); //Add the tile button to the Grid cell
            
            if (boardspaces[r, c].containsCharacter() == true) //For both heroes and enemies.
            {
                ImageBrush characterbrush = new ImageBrush(boardspaces[r, c].tileCharacter.characterImage);
                boardspaces[r,c].tileCharacter.Background = characterbrush; //Character's image added onto character button in the same way the tile's image was
                boardspaces[r, c].tileCharacter.BorderThickness = new Thickness(0); //Remove the character button's border

                if (boardspaces[r, c].tileCharacter.GetType().IsSubclassOf(typeof(GameBoard.Hero)))
                {
                    boardspaces[r, c].tileCharacter.Click += new RoutedEventHandler(Character_Click); //Add Hero_Click event handler to the character button
                    if (!boardspaces[r, c].tileCharacter.isActive)
                    {
                        boardspaces[r, c].tileCharacter.Opacity = 0.5; //Reduce the opacity of the character button if the character is inactive to make the character look faded.
                    }
                    else
                    {
                        boardspaces[r, c].tileCharacter.Opacity = 1; //If the method comes across a hero whose opacity was lowered previously but is once again active, raise it back to 1
                    }
                }
                else
                {
                    boardspaces[r, c].tileCharacter.Click += new RoutedEventHandler(Character_Click); //Add Enemy_Click event handler to the character button (character but not a hero = enemy)
                }
                cells[r, c].Children.Add(boardspaces[r, c].tileCharacter); //Add the character button to the cell (covers the tile button)
            }
        }

        private void displayTileInfo(int row, int col)
        {
            Tile_Info_Image.Source = boardspaces[row, col].terrainImage.terrainImage; //Set the image in the tile/stat info pane to the image of the tile.
            testlabel.Content = "No character";
            if (boardspaces[row, col].containsCharacter() == true)
            {
                Character_Info_Image.Source = boardspaces[row, col].tileCharacter.characterImage;
                if (boardspaces[row, col].tileCharacter.GetType().IsSubclassOf(typeof(GameBoard.Enemy)))
                {
                    testlabel.Content = "Enemy!";
                }
                else if (boardspaces[row, col].tileCharacter.GetType().IsSubclassOf(typeof(GameBoard.Hero)))
                {
                    testlabel.Content = "Hero";
                }
                Health_Label.Content = boardspaces[row, col].tileCharacter.hp;
                Defense_Label.Content = boardspaces[row, col].tileCharacter.defense;
                SpDefense_Label.Content = boardspaces[row, col].tileCharacter.specialDefense;
            }
            else
                Character_Info_Image.Source = null;
        }


        private void Board_Loaded(object sender, RoutedEventArgs e)
        {


        }

        /*
         * When the user clicks on a character, bring up their info, interface to select their action/movement if they're a hero
         * 
         * Also checks if hero is active, has already moved, etc, to only enable the appropriate buttons.
         */
        private void Character_Click(object sender, RoutedEventArgs e)
        {
            clearMoveOptions(); //If not done here, you can click on one hero to bring up their options, then click on another, the highlighted tiles for the first will remain, and you can move the second.
            try
            {
                //Get the row and column of the Character button that was clicked (Row and Col are accessors in Character).
                selectedHeroRow = (sender as Character).Row;
                selectedHeroCol = (sender as Character).Col;
            }
            catch
            {

            }
            displayTileInfo(selectedHeroRow, selectedHeroCol);

            if (boardspaces[selectedHeroRow, selectedHeroCol].tileCharacter.GetType().IsSubclassOf(typeof(GameBoard.Hero)))
            {
                if (boardspaces[selectedHeroRow, selectedHeroCol].tileCharacter.isActive)
                {
                    End_Turn.IsEnabled = true;
                    Defend.IsEnabled = true;
                    if (boardspaces[selectedHeroRow, selectedHeroCol].tileCharacter.hasUsedItem == false)
                    {
                        Use_Item.IsEnabled = true;
                    }
                    else
                    {
                        Use_Item.IsEnabled = false; //Must do this because otherwise, if you clicked a character that could use an item (activates the item button) and then click one that can't, the item button stays active
                    }
                    if (boardspaces[selectedHeroRow, selectedHeroCol].tileCharacter.hasAttacked == false)
                    {
                        Attack.IsEnabled = true;
                        if (boardspaces[selectedHeroRow, selectedHeroCol].tileCharacter.hasMoved == false) //Check inside checking if already attacked because character can't move if already attacked.
                        {
                            Move.IsEnabled = true;
                        }
                        else
                        {
                            Move.IsEnabled = false; //Must do this because otherwise, if you clicked a character that could move (activates the move button) and then click one that can't, the move button stays active
                        }
                    }
                    else
                    {
                        Defend.IsEnabled = false; //Can't defend after attacking
                        Attack.IsEnabled = false; //Must do this because otherwise, if you clicked a character that could attack (activates the attack button) and then click one that can't, the attack button stays active
                    }
                }
                else
                {
                    //Must disable all buttons if inactive because otherwise if you clicked a character that's active and then clicked one that's inactive, the buttons might stay enabled.
                    Move.IsEnabled = false;
                    Attack.IsEnabled = false;
                    Defend.IsEnabled = false;
                    Use_Item.IsEnabled = false;
                    End_Turn.IsEnabled = false;
                }
            }
            else
            {
                //Must disable all buttons if inactive because otherwise if you clicked a character that's active and then clicked one that's inactive, the buttons might stay enabled.
                Move.IsEnabled = false;
                Attack.IsEnabled = false;
                Defend.IsEnabled = false;
                Use_Item.IsEnabled = false;
                End_Turn.IsEnabled = false;
            }
        }

        /*
         * When a user clicks on one of the buttons to move to a tile, move the player character there, advance the turn if all players have been moved.
         */
        private void MoveOption_Click(object sender, RoutedEventArgs e)
        {


            try
            {
                //Get the row and column of the tile button that was clicked (Row and Col are accessors in Tile).
                moveToRow = (sender as Tile).Row;
                moveToCol = (sender as Tile).Col;
            }
            catch
            {

            }




            //Make sure the selected hero hasn't already moved this turn (mostly not necessary, but for safety against glitches?)
            if (!boardspaces[selectedHeroRow, selectedHeroCol].tileCharacter.hasMoved)
            {
                int type = 0;


                String display = "";
                int i = 0;
                boardspaces[selectedHeroRow, selectedHeroCol].tileCharacter.hasMoved = true;


                timer.Interval = TimeSpan.FromSeconds(0.2);

                dummyRow = selectedHeroRow;
                dummyCol = selectedHeroCol;
                moveRow = moveToRow;
                if (selectedHeroRow == moveToRow)
                {
                    if (selectedHeroCol < moveToCol)
                    {
                        type = 0;
                        PlotRoot(type);

                        timer.Tick += timer0_Tick;
                        timer.Start();

                    }
                    if (selectedHeroCol > moveToCol)
                    {
                        type = 1;
                        PlotRoot(type);
                        timer.Tick += timer1_Tick;
                        timer.Start();

                    }

                }
                else if (selectedHeroCol == moveToCol)
                {
                    if (selectedHeroRow < moveToRow)
                    {
                        type = 2;
                        PlotRoot(type);
                        timer.Tick += timer2_Tick;
                        timer.Start();

                    }
                    if (selectedHeroRow > moveToRow)
                    {
                        type = 3;
                        PlotRoot(type);
                        timer.Tick += timer3_Tick;
                        timer.Start();

                    }

                }
                else if (selectedHeroCol < moveToCol && selectedHeroRow < moveToRow)
                {
                    type = 4;
                    PlotRoot(type);
                    timer.Tick += timer4_Tick;
                    timer.Start();

                }
                else if (selectedHeroCol < moveToCol && selectedHeroRow > moveToRow)
                {
                    type = 5;
                    PlotRoot(type);
                    timer.Tick += timer5_Tick;
                    timer.Start();


                }
                else if (selectedHeroCol > moveToCol && selectedHeroRow > moveToRow)
                {
                    type = 6;
                    PlotRoot(type);
                    timer.Tick += timer6_Tick;
                    timer.Start();


                }
                else if (selectedHeroCol > moveToCol && selectedHeroRow < moveToRow)
                {
                    type = 7;
                    PlotRoot(type);
                    timer.Tick += timer7_Tick;
                    timer.Start();

                }

            }

            //Disable the move button.
            Move.IsEnabled = false;

        }
        void timer0_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("hello");
            if (dummyCol == moveToCol)
            {
                timer.Stop();
                timer.Tick -= timer0_Tick;
                Clear();
            }
            else
            {
                moveRow = (int)rowPlot[index];
                moveCol = (int)colPlot[index];
                moveCharacter(dummyRow, dummyCol, moveRow, moveCol);
                dummyCol = moveCol;
                dummyRow = moveRow;
                index++;
            }

        }
        void timer1_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("hello");
            if (dummyCol == moveToCol)
            {
                timer.Stop();
                timer.Tick -= timer1_Tick;
                Clear();
            }
            else
            {
                moveRow = (int)rowPlot[index];
                moveCol = (int)colPlot[index];
                moveCharacter(dummyRow, dummyCol, moveRow, moveCol);
                dummyCol = moveCol;
                dummyRow = moveRow;
                index++;
            }

        }
        void timer2_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("hello");
            if (dummyRow == moveToRow)
            {
                timer.Stop();
                timer.Tick -= timer2_Tick;
                Clear();
            }
            else
            {
                moveRow = (int)rowPlot[index];
                moveCol = (int)colPlot[index];
                moveCharacter(dummyRow, dummyCol, moveRow, moveCol);
                dummyCol = moveCol;
                dummyRow = moveRow;
                index++;
            }

        }
        void timer3_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("hello");
            if (dummyRow == moveToRow)
            {
                timer.Stop();
                timer.Tick -= timer3_Tick;
                Clear();
            }
            else
            {
                moveRow = (int)rowPlot[index];
                moveCol = (int)colPlot[index];
                moveCharacter(dummyRow, dummyCol, moveRow, moveCol);
                dummyCol = moveCol;
                dummyRow = moveRow;
                index++;
            }

        }
        void timer4_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("hello");
            if (dummyCol == moveToCol && dummyRow == moveToRow)
            {
                timer.Stop();
                timer.Tick -= timer4_Tick;
                Clear();
            }
            else
            {
                moveRow = (int)rowPlot[index];
                moveCol = (int)colPlot[index];
                moveCharacter(dummyRow, dummyCol, moveRow, moveCol);
                dummyCol = moveCol;
                dummyRow = moveRow;
                index++;
            }

        }
        void timer5_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("hello");
            if (dummyCol == moveToCol && dummyRow == moveToRow)
            {
                timer.Stop();
                timer.Tick -= timer5_Tick;
                Clear();
            }
            else
            {
                moveRow = (int)rowPlot[index];
                moveCol = (int)colPlot[index];
                moveCharacter(dummyRow, dummyCol, moveRow, moveCol);
                dummyCol = moveCol;
                dummyRow = moveRow;
                index++;
            }

        }
        void timer6_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("hello");
            if (dummyCol == moveToCol && dummyRow == moveToRow)
            {
                timer.Stop();
                timer.Tick -= timer6_Tick;
                Clear();
            }
            else
            {
                moveRow = (int)rowPlot[index];
                moveCol = (int)colPlot[index];
                moveCharacter(dummyRow, dummyCol, moveRow, moveCol);
                dummyCol = moveCol;
                dummyRow = moveRow;
                index++;
            }

        }
        void timer7_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("hello");
            if (dummyCol == moveToCol && dummyRow == moveToRow)
            {
                timer.Stop();
                timer.Tick -= timer7_Tick;
                Clear();
            }
            else
            {
                moveRow = (int)rowPlot[index];
                moveCol = (int)colPlot[index];
                moveCharacter(dummyRow, dummyCol, moveRow, moveCol);
                dummyCol = moveCol;
                dummyRow = moveRow;
                index++;
            }

        }
        private void Clear()
        {
            selectedHeroRow = moveRow;
            selectedHeroCol = moveCol;

            clearMoveOptions();
            rowPlot.Clear();
            colPlot.Clear();
            index = 0;
            position = null;
            position = new object[15, 15];

        }

        /*
         * If the move button was clicked, find the move options, then show them on the board/give those spaces moveoption_click event handlers.
         */
        private void Move_Click(object sender, RoutedEventArgs e)
        {
            moveOptions(boardspaces[selectedHeroRow, selectedHeroCol].tileCharacter.speed, selectedHeroRow, selectedHeroCol);
            for (int r = 0; r < numRows; r++)
            {
                for (int c = 0; c < numCols; c++)
                {
                    if (boardspaces[r, c].isMoveOption) //display buttons for the user to click to chose where to move the selected player.
                    {
                        position[r, c] = boardspaces[r, c];
                        boardspaces[r, c].Click -= new RoutedEventHandler(Tile_Click); //Remove the Tile_Click event handler from the tile button
                        boardspaces[r, c].Click += new RoutedEventHandler(MoveOption_Click); //Add a MoveOption_Click event handler to the tile button
                        //Make a colored border around moveOption spaces to signify which ones they are to the user.
                        boardspaces[r, c].BorderBrush = moveOption;
                        boardspaces[r, c].BorderThickness = new Thickness(1);
                        
                    }
                }
            }
        }

        /*
         * For when the defend button is clicked what a hero is selected. Choosing defend adds an Effect object to the hero's list of stat effects that boosts their defense (positive percentage/double)
         * and lasts for one turn. Then, it ends the hero's turn (last action they can potentially do), fades the hero, and disables their action buttons. Ends the player turn if all heros are done.
         */
        private void Defend_Click(object sender, RoutedEventArgs e)
        {
            Defend.IsEnabled = false;
            //NEEDS TO BE ADDED: Add Effect to character stateffect list that boosts defense stat for 1 turn.
            boardspaces[selectedHeroRow, selectedHeroCol].tileCharacter.isActive = false;
            refreshBoardSpace(selectedHeroRow, selectedHeroCol);
            End_Turn.IsEnabled = false;
            Move.IsEnabled = false;
            Attack.IsEnabled = false;
            Use_Item.IsEnabled = false;
            if (checkAllPlayersInactive())
            {
                nextTurn();
            }
        }

        /*
         * For when the use item button is clicked for a selected hero. Can be used once per hero per turn. Displays a list of usable items from the player's inventory, and applys the effect
         * of the selected item to the current hero (If one is selected, if not, list disappears and the button is still available). 
         * If an item was successfully used, disables the button, sets that the hero has used an item this turn, and checks if the character is still active after using this item. If not,
         * fades the hero, disables buttons for any otherwise remaining options. Checks if all heroes are inactive, if so, goes to next turn.
         */
        private void Use_Item_Click(object sender, RoutedEventArgs e)
        {
            //NEEDS TO BE ADDED: Show list of usable items

            //NEEDS TO BE ADDED: if item is selected and used, do the following:
            Use_Item.IsEnabled = false;
            boardspaces[selectedHeroRow, selectedHeroCol].tileCharacter.hasUsedItem = true;
            if (!boardspaces[selectedHeroRow, selectedHeroCol].tileCharacter.isActive)
            {
                refreshBoardSpace(selectedHeroRow, selectedHeroCol);
                Defend.IsEnabled = false;
                End_Turn.IsEnabled = false;
                //If now inactive, the move and attack buttons are already disabled.
            }
            if (checkAllPlayersInactive())
            {
                nextTurn();
            }
        }

        /*
         * When the end turn button is clicked for the selected hero. Ends their turn by disabling all buttons for any actions, and setting the hero to inactive.
         * Refreshs the hero so they appear faded, and then checks if all heroes are now inactive. If so, starts the next turn.
         */
        private void End_Turn_Click(object sender, RoutedEventArgs e)
        {
            boardspaces[selectedHeroRow, selectedHeroCol].tileCharacter.isActive = false;
            refreshBoardSpace(selectedHeroRow, selectedHeroCol);
            End_Turn.IsEnabled = false;
            Move.IsEnabled = false;
            Attack.IsEnabled = false;
            Defend.IsEnabled = false;
            Use_Item.IsEnabled = false;
            if (checkAllPlayersInactive())
            {
                nextTurn();
            }
        }

        /*
         * Immediately ends the player's turn for all heros. nextTurn() resets the inactive, hasMoved, etc properties for each hero, so it doesn't need to be done here.
         */
        private void End_Heroes_Turn_Click(object sender, RoutedEventArgs e)
        {
            nextTurn();
        }

        /*
         * For when the player clicks on any board spaces, brings up info about the tile, and its picture, and displays it on the side (stats location).
         * If there is a character on the tile, display extra appropriate info for the character (current health, etc).
         */
        private void Tile_Click(object sender, RoutedEventArgs e)
        {
            Move.IsEnabled = false;
            Attack.IsEnabled = false;
            Defend.IsEnabled = false;
            Use_Item.IsEnabled = false;
            End_Turn.IsEnabled = false;
            clearMoveOptions();
            clearAttackOptions();

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

            displayTileInfo(row, col);
        }

        private void Map_Maker_Click(object sender, RoutedEventArgs e)
        {
            mapBuilder map_maker = new mapBuilder();
            map_maker.Show();
        }
    }
}