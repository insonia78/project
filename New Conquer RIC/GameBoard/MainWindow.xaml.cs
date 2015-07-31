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
using Community;

namespace GameBoard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Mostly deals with the visual/interface side of the game board.
    /// </summary>
    public partial class MainWindow : Page
    {
        private Grid[,] cells; //2D array of containers to add to the Board uniformGrid to hold the tiles
        SolidColorBrush moveOption = new SolidColorBrush(Colors.Red); 
        SolidColorBrush attackOption = new SolidColorBrush(Colors.Red);
       
        //The input heroes:
        private Hero hero1;
        private Hero hero2;
        private Hero hero3;
        private Hero hero4;
        private Hero hero5;

        //stores a reference to the location of a Character when it's selected (need the characters's location even when clicking on buttons for different spaces).
        private int selectedCharacterRow;
        private int selectedCharacterCol;

        //For the animated movement
        private bool ok = true;
        private int moveToRow;
        private int moveToCol;
        private int indexOfCol;
        private int indexOfRow;
        private int dummyRow;
        private int dummyCol;
        private int index = 0;
        public int countEnemiesForloop = 0;
        private int moveRow = 0, moveCol = 0;
        DispatcherTimer Enemytimer = new DispatcherTimer();
        DispatcherTimer EnemyAttachtimer = new DispatcherTimer();
        DispatcherTimer timer = new DispatcherTimer();
        ArrayList rowPlot = new ArrayList();
        ArrayList colPlot = new ArrayList();

        //For tutorial
        private string test;
        private bool isTutorial;
        public bool tutorialWasClicked; 
        public bool tutIntroductionExitClicked;
        public bool highlightedFirstClick;
        public bool tutFirstMoveExitClicked;
        public bool hero1move1;
        public bool waitIsClicked;
        public bool TutFirstMoveWaitTextExitIsClicked;
        public bool hero1move2;
        public bool nonHeroTurn;

        // control frame
        Window main;
        MediaElement music;

        /*
         * Initializes the GUI components, creates the cells 2d array, and sets up the board/tiles/characters, etc.
         */
        public MainWindow()
        {
            
            InitializeComponent();
            setupBoard("testmap.txt");
            selectedCharacterRow = 0;
            selectedCharacterCol = 0;

            //For attack animation
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += onUpdate;
            dispatcherTimer.Interval = TimePerFrame;

            //For testing purposes, characters added in this way. When the game is at the point where the hero data is taken from the world map, or
            //is global to the whole program, and setUpBoard() can read positions to add the characters, then they will be added in setUpBoard() rather than here.
            boardspaces[5, 3].tileCharacter = new SoftwareEngineer(5,3);
            refreshBoardSpace(5, 3);
            boardspaces[1, 2].tileCharacter = new SystemsAnalyst(1,2);
            refreshBoardSpace(1, 2);
            boardspaces[2, 2].tileCharacter = new NetworkArchitect(2, 2);
            refreshBoardSpace(2, 2);
            boardspaces[5, 5].tileCharacter = new CampusPolice(5, 5);
            refreshBoardSpace(5, 5);
            boardspaces[6, 5].tileCharacter = new CampusPolice(6, 5);
            refreshBoardSpace(6, 5);
            boardspaces[5, 1].tileCharacter = new CampusPolice(5, 1);
            refreshBoardSpace(5, 1);
            boardspaces[11, 9].tileCharacter = new CampusPolice(11,9);
            refreshBoardSpace(11, 9);
            boardspaces[13, 8].tileCharacter = new FoodServer(13,8);
            refreshBoardSpace(13, 8);
            boardspaces[14, 3].tileCharacter = new Gardener(14,3);
            refreshBoardSpace(14, 3);
        }

        public MainWindow(String levelFile, Hero[] heroes, Window frame, MediaElement bgm)
        {
            main = frame;
            music = bgm;

            InitializeComponent();

            hero1 = heroes[0];
            hero2 = heroes[1];
            hero3 = heroes[2];
            hero4 = heroes[3];
            hero5 = heroes[4];

            setupBoard(levelFile);
            selectedCharacterRow = 0;
            selectedCharacterCol = 0;

            //For attack animation
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += onUpdate;
            dispatcherTimer.Interval = TimePerFrame;
        }

        private void TitleBarTip_MouseDown(object sender, MouseButtonEventArgs e)
        {
            main.DragMove();
        }

        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            main.DragMove();
        }

        private void TitleBarButt_MouseDown(object sender, MouseButtonEventArgs e)
        {
            main.DragMove();
        }

        private void LeftTitleBarPatch_MouseDown(object sender, MouseButtonEventArgs e)
        {
            main.DragMove();
        }

        private void RightTitleBarPatch_MouseDown(object sender, MouseButtonEventArgs e)
        {
            main.DragMove();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            main.WindowState = WindowState.Minimized;
        }

        private void XButton_Click(object sender, RoutedEventArgs e)
        {
            EnterLeaveGame();
        }

        private void EnterLeaveGame()
        {
            BlackOut.Visibility = Visibility.Visible;
            LeaveGameGrid.Visibility = Visibility.Visible;
            music.Volume = 0.2;
        }

        private void LeaveGameOkButton_Click(object sender, RoutedEventArgs e)
        {
            // shuts down the instance of the wpf application.
            Application.Current.Shutdown();
        }

        private void LeaveGameCancelButton_Click(object sender, RoutedEventArgs e)
        {
            music.Volume = 0.5;
            LeaveGameGrid.Visibility = Visibility.Hidden;
            BlackOut.Visibility = Visibility.Hidden;
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
            boardspaces[r, c].Click -= new RoutedEventHandler(MoveOption_Click);
            boardspaces[r, c].Click -= new RoutedEventHandler(AttackOption_Click);
            //boardspaces[r, c].Click += new RoutedEventHandler(Tile_Click); //Add the Tile_Click event to the cell's button in case it isn't already on (will sometimes disappear otherwise).

            backgroundImage = new ImageBrush(boardspaces[r, c].terrainImage.terrainImage);
            backgroundImage.Stretch = Stretch.Fill;
            boardspaces[r, c].Background = backgroundImage; //Set the background of the tile button to the terrain image.
            boardspaces[r, c].BorderThickness = new Thickness(0); //Remove the tile button's border
            cells[r,c].Children.Add(boardspaces[r, c]); //Add the tile button to the Grid cell
            
            if (boardspaces[r, c].containsCharacter() == true) //For both heroes and enemies.
            {
                ImageBrush characterbrush = new ImageBrush(boardspaces[r, c].tileCharacter.CharacterPicture);
                characterbrush.Stretch = Stretch.Fill;
                boardspaces[r,c].tileCharacter.Background = characterbrush; //Character's image added onto character button in the same way the tile's image was
                boardspaces[r, c].tileCharacter.BorderThickness = new Thickness(0); //Remove the character button's border

                if (boardspaces[r, c].tileCharacter.GetType().IsSubclassOf(typeof(Community.Hero)))
                {
                    //boardspaces[r, c].tileCharacter.Click += new RoutedEventHandler(Character_Click); //Add Hero_Click event handler to the character button
                    if (!boardspaces[r, c].tileCharacter.isActive)
                    {
                        boardspaces[r, c].tileCharacter.Opacity = 0.5; //Reduce the opacity of the character button if the character is inactive to make the character look faded.
                    }
                    else
                    {
                        boardspaces[r, c].tileCharacter.Opacity = 1; //If the method comes across a hero whose opacity was lowered previously but is once again active, raise it back to 1
                    }
                }
                //else
                //{
                    //boardspaces[r, c].tileCharacter.Click += new RoutedEventHandler(Character_Click); //Add Enemy_Click event handler to the character button (character but not a hero = enemy)
                //}
                cells[r, c].Children.Add(boardspaces[r, c].tileCharacter); //Add the character button to the cell (covers the tile button)
            }
        }

        private void displayTileInfo(int row, int col)
        {
            Tile_Info_Image.Source = boardspaces[row, col].terrainImage.terrainImage; //Set the image in the tile/stat info pane to the image of the tile.
            testlabel.Content = "No character";
            if (boardspaces[row, col].containsCharacter() == true)
            {
                Character_Info_Image.Source = boardspaces[row, col].tileCharacter.CharacterPicture;
                if (boardspaces[row, col].tileCharacter.GetType().IsSubclassOf(typeof(Community.Enemy)))
                {
                    testlabel.Content = "Enemy!";
                }
                else if (boardspaces[row, col].tileCharacter.GetType().IsSubclassOf(typeof(Community.Hero)))
                {
                    testlabel.Content = "Hero";
                }

                if (boardspaces[row, col].tileCharacter.MaxHealth / 2 > boardspaces[row, col].tileCharacter.CurrentHealth)
                {
                    HealthBar.Foreground = moveOption; //Yellow
                }
                else if (boardspaces[row, col].tileCharacter.MaxHealth / 4 > boardspaces[row, col].tileCharacter.CurrentHealth)
                {
                    HealthBar.Foreground = attackOption; //Red
                }
                else
                {
                    HealthBar.Foreground = new SolidColorBrush(Colors.Green);
                }

                HealthBar.Visibility = Visibility.Visible;
                HealthBar.Maximum = boardspaces[row, col].tileCharacter.MaxHealth;
                HealthBar.Minimum = 0;
                HealthBar.Value = boardspaces[row, col].tileCharacter.CurrentHealth;
                //Health_Label.Content = boardspaces[row, col].tileCharacter.CurrentHealth;
                Defense_Label.Content = boardspaces[row, col].tileCharacter.CurrentDefense;
                SpDefense_Label.Content = boardspaces[row, col].tileCharacter.CurrentSpecialDefense;
            }
            else
            {
                HealthBar.Visibility = Visibility.Hidden;
                Character_Info_Image.Source = null;
            }
        }


        private void Board_Loaded(object sender, RoutedEventArgs e)
        {
           // music.Source = new Uri("../../LevelOneBgm.wav", UriKind.Relative);
          //  music.Play();
        }

        /*
         * When the user clicks on a character, bring up their info, interface to select their action/movement if they're a hero
         * 
         * Also checks if hero is active, has already moved, etc, to only enable the appropriate buttons.
         */
        private void Character_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Character Click");
            clearMoveOptions(); //If not done here, you can click on one hero to bring up their options, then click on another, the highlighted tiles for the first will remain, and you can move the second.
            clearAttackOptions();
            try
            {
                //Get the row and column of the Character button that was clicked (Row and Col are accessors in Character).
                selectedCharacterRow = (sender as Character).Row;
                selectedCharacterCol = (sender as Character).Col;
            }
            catch
            {

            }
            displayTileInfo(selectedCharacterRow, selectedCharacterCol);

            updateAvailableOptionButtons();
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
            if (!boardspaces[selectedCharacterRow, selectedCharacterCol].tileCharacter.hasMoved)
            {
                int type = 0;


                String display = "";
                int i = 0;

                boardspaces[selectedCharacterRow, selectedCharacterCol].tileCharacter.hasMoved = true;

                timer.Interval = TimeSpan.FromSeconds(0.2);

                //Disables the mouse from clicking on anything so the user can't click something else mid animation (bad things would happen)
                this.IsHitTestVisible = false;
                //Changes the cursor to a loading/waiting cursor for the duration of the animation to help let the user know they can't use the mouse
                Mouse.OverrideCursor = Cursors.Wait;

                dummyRow = selectedCharacterRow;
                dummyCol = selectedCharacterCol;


                PlotRoot(0);

                timer.Tick += timer_Tick;
                timer.Start();


                //Disable the move button.
                Move.IsEnabled = false;
            }
        }




        void timer_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("hello");
            if (dummyCol == moveToCol && dummyRow == moveToRow)
            {
                timer.Stop();
                timer.Tick -= timer_Tick;
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
            selectedCharacterRow = moveRow;
            selectedCharacterCol = moveCol;

            clearMoveOptions();
            rowPlot.Clear();
            colPlot.Clear();
            index = 0;
            

            //Reenables the mouse once the animation is done and the user can't screw things up.
            this.IsHitTestVisible = true;
            //Sets the cursor back to the normal one.
            Mouse.OverrideCursor = null;

            if (tutFirstMoveExitClicked)
            {
                hero1MoveCheck();
                End_Turn.IsEnabled = true;
                clearMoveOptions();

                for (int r = 0; r < numRows; r++)
                {
                    for (int c = 0; c < numCols; c++)
                    {
                        boardspaces[r, c].BorderThickness = new Thickness(0);
                    }
                }
            }
        }

        /*
         * If the move button was clicked, find the move options, then show them on the board/give those spaces moveoption_click event handlers.
         */
        private void Move_Click(object sender, RoutedEventArgs e)
        {
            clearAttackOptions();
            moveOptions(boardspaces[selectedCharacterRow, selectedCharacterCol].tileCharacter.CurrentSpeed, selectedCharacterRow, selectedCharacterCol);
            for (int r = 0; r < numRows; r++)
            {
                for (int c = 0; c < numCols; c++)
                {
                    if (boardspaces[r, c].isMoveOption) //display buttons for the user to click to chose where to move the selected player.
                    {
                       
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
         * For when the defend button is clicked what a hero is selected. 
         * 
         * Choosing defend adds an Effect object to the hero's list of stat effects that boosts their defense (positive percentage/double)
         * and lasts for one turn. Then, it ends the hero's turn (last action they can potentially do), fades the hero, and disables their 
         * buttons. Ends the player turn if all heros are done.
         */
        private void Defend_Click(object sender, RoutedEventArgs e)
        {
            //NEEDS TO BE ADDED: Add Effect to character stateffect list that boosts defense stat for 1 turn.
            boardspaces[selectedCharacterRow, selectedCharacterCol].tileCharacter.isActive = false;

            //End the turn for the selected hero using the wait button's event handler (does the same thing)
            End_Turn_Click(null, null);
        }

        /*
         * For when the use item button is clicked for a selected hero. 
         * 
         * Can be used once per hero per turn. Displays a list of usable items from the player's inventory, and applys the effect
         * of the selected item to the current hero (If one is selected, if not, list disappears and the button is still available). 
         * If an item was successfully used, disables the button, sets that the hero has used an item this turn, and checks if the character is 
         * still active after using this item. If not, fades the hero, disables buttons for any otherwise remaining options. Checks if all heroes
         * are inactive, if so, goes to next turn.
         */
        private void Use_Item_Click(object sender, RoutedEventArgs e)
        {
            //NEEDS TO BE ADDED: Show list of usable items

            //NEEDS TO BE ADDED: if item is selected and used, do the following:
            //Use_Item.IsEnabled = false;
            boardspaces[selectedCharacterRow, selectedCharacterCol].tileCharacter.hasUsedItem = true;
            if (!boardspaces[selectedCharacterRow, selectedCharacterCol].tileCharacter.isActive)
            {
                refreshBoardSpace(selectedCharacterRow, selectedCharacterCol);
                updateAvailableOptionButtons();
            }
            if (checkAllPlayersInactive())
            {
                disableAllOptionButtons();
                nextTurn();
            }
        }

        /*
         * When the wait button is clicked for the selected hero. 
         * 
         * Ends their turn by disabling all buttons for any actions, and setting the hero to inactive.
         * Refreshs the hero so they appear faded, and then checks if all heroes are now inactive. If so, starts the next turn.
         */
        private void End_Turn_Click(object sender, RoutedEventArgs e)
        {
            waitIsClicked = true;
            if (tutorialWasClicked == true && TutFirstMoveWaitTextExitIsClicked == false)
            {
                boardspaces[selectedCharacterRow, selectedCharacterCol].tileCharacter.isActive = false;
                refreshBoardSpace(selectedCharacterRow, selectedCharacterCol);
                disableAllOptionButtons();
                //if (checkAllPlayersInactive())
               //{
               //     nextTurn();
               // }
               this.inbetweenStep();
            }
            else if(tutorialWasClicked == true && TutFirstMoveWaitTextExitIsClicked == true && nonHeroTurn == false)
            {
                boardspaces[selectedCharacterRow, selectedCharacterCol].tileCharacter.isActive = false;
                refreshBoardSpace(selectedCharacterRow, selectedCharacterCol);
                disableAllOptionButtons();
                //if (checkAllPlayersInactive())
                //{
                //  nextTurn();
                //}
                this.inbetweenStep();
            }
            else if (tutorialWasClicked == true && TutFirstMoveWaitTextExitIsClicked == true && nonHeroTurn == true)
            {
                boardspaces[selectedCharacterRow, selectedCharacterCol].tileCharacter.isActive = false;
                refreshBoardSpace(selectedCharacterRow, selectedCharacterCol);
                disableAllOptionButtons();
            }
            else
            {
                boardspaces[selectedCharacterRow, selectedCharacterCol].tileCharacter.isActive = false;
                refreshBoardSpace(selectedCharacterRow, selectedCharacterCol);
                disableAllOptionButtons();
                if (checkAllPlayersInactive())
                {
                    nextTurn();
                }
            }
        }

        /*
         * Immediately ends the player's turn for all heros.
         */
        private void End_Heroes_Turn_Click(object sender, RoutedEventArgs e)
        {
            disableAllOptionButtons();
            End_Heroes_Turn.IsEnabled = false;
            ok = true;
            countEnemies();
            countEnemiesForloop = numEnemies;
            disableAllOptionButtons();
            End_Heroes_Turn.IsEnabled = false;
            timer.Interval = TimeSpan.FromSeconds(3);
            EnemyAttachtimer.Interval = TimeSpan.FromSeconds(5);
          
            if (tutFirstMoveExitClicked == true && TutFirstMoveWaitTextExitIsClicked == true)
            {
                disableAllOptionButtons();
                End_Heroes_Turn.IsEnabled = false;
 
                //nextTurn() resets the inactive, hasMoved, etc properties for each hero, so it doesn't need to be done here.
               // nextTurn();
                this.tutorialEnemyMoveOne();
                End_Heroes_Turn.IsEnabled = true;
                progressMap();
                localizeHero();
                disableAllOptionButtons();
                End_Heroes_Turn.IsEnabled = false;
                Enemytimer.Tick += Etimer_Tick;
                Enemytimer.Start();


                //nextTurn() resets the inactive, hasMoved, etc properties for each hero, so it doesn't need to be done here.
                //nextTurn();

                End_Heroes_Turn.IsEnabled = true;
                
            }
            else
            {
                progressMap();
                localizeHero();
                disableAllOptionButtons();
                End_Heroes_Turn.IsEnabled = false;
                Enemytimer.Tick += Etimer_Tick;
                Enemytimer.Start();


                //nextTurn() resets the inactive, hasMoved, etc properties for each hero, so it doesn't need to be done here.
                //nextTurn();

                End_Heroes_Turn.IsEnabled = true;
            }
        }
        public void Etimer_Tick(object sender, EventArgs e)
        {


            Enemytimer.Stop();
            Enemytimer.Tick -= Etimer_Tick;
            targetAndMoveToHero();

            EnemyAttach();
            
                //MessageBox.Show("false");
            if (test == "true")
            {
            }
            else
            {
                if (ok == true)
                {

                    enemyMove();
                    EnemyMoveOption();
                    boardspaces[selectedCharacterRow, selectedCharacterCol].tileCharacter.hasMoved = false;
                }
                EnemyAttach();
            }
            
         
            
                
            

            // enemyMoveAI();
            //nextTurn() resets the inactive, hasMoved, etc properties for each hero, so it doesn't need to be done here.



            countEnemiesForloop--;


        }
       

        public void TutorialLevel_Click(object sender, RoutedEventArgs e)
        {
            tutorialWasClicked = true;
            TutFirstMove.IsEnabled = false;
            TutIntroduction.IsEnabled = false;
            //pop up dialog box introducing people to the tutorial level
            TutIntroduction.Visibility = System.Windows.Visibility.Visible;
            TutorialIntroductionExit.Visibility = System.Windows.Visibility.Visible;
        }



        //exits the tutorial text.
        //calls the next step in the tutorial
        public void TutorialIntroductionExit_Click(object sender, RoutedEventArgs e)
        {
            tutIntroductionExitClicked = true;
            TutIntroduction.Visibility = System.Windows.Visibility.Hidden;
            TutorialIntroductionExit.Visibility = System.Windows.Visibility.Hidden;
            this.intermStep();
        }

        //talks about clicking on a character to get it to move.
        public void intermStep()
        {
            TutFirstMove0Text.IsEnabled = false;
            TutFirstMove0Text.Visibility = System.Windows.Visibility.Visible;
            TutFirstMove0TextExit.Visibility = System.Windows.Visibility.Visible;
            TutFirstMove0Text.Text = "For the tutorial, we clicked on the character you needed to move. When you play the levels, you will click on the one you want to move or interact with";           
        }

        //exits TutFirstMove0Text text
        //calls the first step in the tutorial
        private void TutFirstMove0TextExit_Click(object sender, RoutedEventArgs e)
        {
            TutFirstMove0Text.Visibility = System.Windows.Visibility.Hidden;
            TutFirstMove0TextExit.Visibility = System.Windows.Visibility.Hidden;
            //highlight the spot the character is on
            this.tutorialFirstStep();
        }

        //explains what happens when a character is clicked on and the move button is clicked
        public void tutorialFirstStep()
        {
            End_Turn.IsEnabled = false;
            Move.IsEnabled = false;
            Attack.IsEnabled = false;
            Defend.IsEnabled = false;
            //Use_Item.IsEnabled = false;
            
            if (tutIntroductionExitClicked == true)
            {              
                TutFirstMoveExit.Visibility = System.Windows.Visibility.Visible;
                TutFirstMove.Visibility = System.Windows.Visibility.Visible;
                
                TutFirstMove.Text = "Now that we've clicked on the highlighted tile, see how there are squares that light up? those squares indicate where the character can go." +
                "for our purposes, I want you to move to the square thats highlighted pink. " +
                "We clicked the move button for you. When you play in the game you will have to click the move button then move to the desired square.";              
            }       
        }

        //exits the TutFirstMove text.
        //calls the second step in the tutorial.
        private void TutFirstMoveExit_Click(object sender, RoutedEventArgs e)
        {
            tutFirstMoveExitClicked = true;
            TutFirstMove.Visibility = System.Windows.Visibility.Hidden;
            TutFirstMoveExit.Visibility = System.Windows.Visibility.Hidden;
            this.tutorialFirstStepTwo();
        }

        //
        //
        public void tutorialFirstStepTwo()
        {
            if (tutFirstMoveExitClicked == true && TutFirstMoveWaitTextExitIsClicked == false)
            {
                this.Character_Click(boardspaces[2, 2].tileCharacter, null);

                //makes the character move to a specific square.
                //checks that its that square.
                //if not, it reminds them to move the character so they can try again.

                Move_Click(boardspaces[2, 2].tileCharacter, null);
                for (int r = 0; r < numRows; r++)
                {
                    for (int c = 0; c < numCols; c++)
                    {
                        boardspaces[r, c].Click -= new RoutedEventHandler(Tile_Click);
                        if(boardspaces[r,c].containsCharacter())
                        {
                            boardspaces[r, c].tileCharacter.Click -= new RoutedEventHandler(Character_Click);
                        }
                        if (boardspaces[r, c].isMoveOption && (r != 5 || c != 1))
                        {
                            boardspaces[r, c].isMoveOption = false;
                            boardspaces[r, c].Click -= new RoutedEventHandler(MoveOption_Click);
                        }
                        hero1move1 = true;                       
                    }
                }
                Move.IsEnabled = false;
                End_Turn.IsEnabled = false;
                Attack.IsEnabled = false;
                Defend.IsEnabled = false;
                //Use_Item.IsEnabled = false;
                //[y,x]
                boardspaces[5, 1].BorderBrush = new SolidColorBrush(Colors.DeepPink);
                boardspaces[5, 1].BorderThickness = new Thickness(2);
              
               
            }
            else if  (tutFirstMoveExitClicked == true && TutFirstMoveWaitTextExitIsClicked == true) 
            {
                this.Character_Click(boardspaces[1, 3].tileCharacter, null);


                Move_Click(boardspaces[1, 3].tileCharacter, null);
                for (int r = 0; r < numRows; r++)
                {
                    for (int c = 0; c < numCols; c++)
                    {
                        if (boardspaces[r, c].isMoveOption && (r != 3 || c != 1))
                        {
                            boardspaces[r, c].isMoveOption = false;
                            boardspaces[r, c].Click -= new RoutedEventHandler(MoveOption_Click);
                        }
                        hero1move2 = true;
                    }
                }
                Move.IsEnabled = false;
                End_Turn.IsEnabled = false;
                Attack.IsEnabled = false;
                Defend.IsEnabled = false;
                //Use_Item.IsEnabled = false;

                boardspaces[3, 1].BorderBrush = new SolidColorBrush(Colors.DeepPink);
                boardspaces[3, 1].BorderThickness = new Thickness(2);
              
            }
        }

        //ends all the hero's turns.
         public void inbetweenStepTwo() {
        if(TutFirstMoveWaitTextExitIsClicked == true)
                {
                End_Heroes_Turn_Click(null, null);             
                }  
         }


        //sees if the hero has moved to the specified place.
        //it doesnt work yet. this stuff pops up before the hero moves...
        public void hero1MoveCheck()
        {
            if (boardspaces[5, 1].containsCharacter() == true && hero1move1 == true && nonHeroTurn == false)
            {
                TutFirstMoveWaitText.Visibility = System.Windows.Visibility.Visible;
               
                TutFirstMoveWaitText.IsEnabled = false;
                TutFirstMoveWaitText.Text = "Now that the character has moved to its new location, we need to end the character's turn. to do this, press the Wait Button.";
            }
            else if (boardspaces[3, 1].containsCharacter() == true && hero1move2 == true && nonHeroTurn == false)
            {
                TutFirstMoveWaitText.Visibility = System.Windows.Visibility.Visible;
                
                TutFirstMoveWaitText.IsEnabled = false;
                TutFirstMoveWaitText.Text = "Now that the character has moved to its new location, we need to end the character's turn. to do this, press the Wait Button.";
            }
            this.makeHeroWait();
        }


        //makes the hero wait at the spot they are at in the tutorial level
        public void makeHeroWait()
        {
            if (hero1move1 == true)
            {
                End_Turn.IsEnabled = true;
                Attack.IsEnabled = false;
                Defend.IsEnabled = false;
                //Use_Item.IsEnabled = false;

                for (int r = 0; r < numRows; r++)
                {
                    for (int c = 0; c < numCols; c++)
                    {
                        refreshBoardSpace(r, c);
                    }
                }
                
            }
            else if (hero1move2 == true)
            {
                End_Turn.IsEnabled = true;
                Attack.IsEnabled = false;
                Defend.IsEnabled = false;
                //Use_Item.IsEnabled = false;

                for (int r = 0; r < numRows; r++)
                {
                    for (int c = 0; c < numCols; c++)
                    {
                        refreshBoardSpace(r, c);
                    }
                }
            } else {
                End_Turn.IsEnabled = false;
                Attack.IsEnabled = false;
                Defend.IsEnabled = false;
                //Use_Item.IsEnabled = false;
            }
 
        }

        public void inbetweenStep()
        {

                TutFirstMoveWaitTextExit.Visibility = System.Windows.Visibility.Visible;
        }

        //
        //
        private void TutFirstMoveWaitTextExit_Click(object sender, RoutedEventArgs e)
        {
            if (tutorialWasClicked == true && TutFirstMoveWaitTextExitIsClicked == false)
            {
                TutFirstMoveWaitTextExitIsClicked = true;
                TutFirstMoveWaitText.Visibility = System.Windows.Visibility.Hidden;
                TutFirstMoveWaitTextExit.Visibility = System.Windows.Visibility.Hidden;
                this.intermStep();
            }
            else if (tutorialWasClicked == true && TutFirstMoveWaitTextExitIsClicked == true)
            {
                TutFirstMoveWaitText.Visibility = System.Windows.Visibility.Hidden;
                TutFirstMoveWaitTextExit.Visibility = System.Windows.Visibility.Hidden;
                this.inbetweenStepTwo();
               
            }
            
        }       
        
        //forces the enemy to move a certain way for turn 1.
        public async Task tutorialEnemyMoveOne()
        {
            nonHeroTurn = true;
            for (int i = 0; i < 6; i++)
            {
                if (i == 0)
                {
                    forceMoveCharacter(13, 4, 13, 7);
                    await Task.Delay(1000);
                }
                
                 else if (i == 1)
                {
                    forceMoveCharacter(11, 4, 11, 6);
                    await Task.Delay(1000);
                }
                 else if (i == 2)
                {
                    forceMoveCharacter(12, 9, 11, 9);
                    await Task.Delay(1000);
                }
                else if (i == 3)
                {
                    forceMoveCharacter(13, 12, 13, 13);
                    await Task.Delay(1000);
                }
                else if (i == 4)
                {
                    forceMoveCharacter(10, 11, 8, 11);
                    await Task.Delay(1000);
                }
                else if (i == 5)
                {
               //here is where we need to increment the turn.
                    //there also has to be a way to gray out the characters before here



                    numTurns++;
                    TurnCounter.Content = ("Turn " + turnNumber);

                    //Make sure there's no leftover move/attack events on the board (caused bugs occassionally without this).
                    clearMoveOptions();
                    clearAttackOptions();
                   this.tutorialSecondStep();
                }

            }    
        }


        public void tutorialSecondStep()
        {
            //ungray the characters and make them mobile again
            End_Turn.IsEnabled = false;
            Move.IsEnabled = false;
            Attack.IsEnabled = false;
            Defend.IsEnabled = false;
            //Use_Item.IsEnabled = false;

            if(turnNumber == 2)
            {
                TutSecondMove.Visibility = System.Windows.Visibility.Visible;
                TutSecondMove.IsEnabled = false;
                TutSecondMove.Text = "This step will show you what happens when a character needs to defend themselves from a stronger enemy. " +
                    "For this situation, we are showing what will happen if your character can't move to get away. " +
                    "Attacking the enemy would result in your character's death, so that isn't a viable option either. " +
                    "The solution to this is the defend button. " +
                    "The defend button will raise the selected hero's defense for one turn.";
            }
        }

        //forces the enemy to move a certain way for turn 2.
        //will be fixed once the turn counter issue is resolved.
        public void tutorialEnemyMoveTwo()
        {
            //for (int i = 0; i < 6; i++)
            //{
            //    if (i == 0)
             //   {
             //       forceMoveCharacter(13, 7, null, null);
             //   }
            
               // else if (i == 1)
               // {
               //     forceMoveCharacter(11, 6, null, null);
               // }
               // else if (i == 2)
               // {
               //     forceMoveCharacter(11, 9, null, null);
               // }
              //  else if (i == 3)
              //  {
              //      forceMoveCharacter(13, 13, null, null);
               // }
               // else if (i == 4)
              //  {
               //     forceMoveCharacter(8, 11, null, null);
               // }
               // else if (i == 5)
               // {
              //  }
           // }
        }

        /*
         * For when the player clicks on any board spaces, brings up info about the tile, and its picture, and displays it on the side (stats location).
         * If there is a character on the tile, display extra appropriate info for the character (current health, etc).
         */
        private void Tile_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Tile click");
            disableAllOptionButtons();
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

        private void updateAvailableOptionButtons()
        {
            if (boardspaces[selectedCharacterRow, selectedCharacterCol].tileCharacter.GetType().IsSubclassOf(typeof(Community.Hero)))
            {
                if (boardspaces[selectedCharacterRow, selectedCharacterCol].tileCharacter.isActive)
                {
                    End_Turn.IsEnabled = true;
                    Defend.IsEnabled = true;
                    if (boardspaces[selectedCharacterRow, selectedCharacterCol].tileCharacter.hasUsedItem == false)
                    {
                        //Use_Item.IsEnabled = true;
                    }
                    else
                    {
                        //Use_Item.IsEnabled = false; //Must do this because otherwise, if you clicked a character that could use an item (activates the item button) and then click one that can't, the item button stays active
                    }
                    if (boardspaces[selectedCharacterRow, selectedCharacterCol].tileCharacter.hasAttacked == false)
                    {
                        Attack.IsEnabled = true;
                        if (boardspaces[selectedCharacterRow, selectedCharacterCol].tileCharacter.hasMoved == false) //Check inside checking if already attacked because character can't move if already attacked.
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
                        Ability1.IsEnabled = false;
                        Ability2.IsEnabled = false;
                        Ability3.IsEnabled = false;
                        Ability4.IsEnabled = false;
                    }
                }
                else
                {
                    //Must disable all buttons if inactive because otherwise if you clicked a character that's active and then clicked one that's inactive, the buttons might stay enabled.
                    disableAllOptionButtons();
                }
            }
            else
            {
                //Must disable all buttons if inactive because otherwise if you clicked a character that's active and then clicked one that's inactive, the buttons might stay enabled.
                disableAllOptionButtons();
            }
        }

        private void disableAllOptionButtons()
        {
            Move.IsEnabled = false;
            Attack.IsEnabled = false;
            Ability1.IsEnabled = false;
            Ability2.IsEnabled = false;
            Ability3.IsEnabled = false;
            Ability4.IsEnabled = false;
            Defend.IsEnabled = false;
            //Use_Item.IsEnabled = false;
            End_Turn.IsEnabled = false;
        }

        private void Map_Maker_Click(object sender, RoutedEventArgs e)
        {
            mapBuilder map_maker = new mapBuilder();
            map_maker.Show();
        }

        private void ReturnToWorldMap_Click(object sender, RoutedEventArgs e)
        {
            for (int r = 0; r < numRows; r++)
            {
                for (int c = 0; c < numCols; c++)
                {
                    if (boardspaces[r, c].containsCharacter() == true)
                    {
                        boardspaces[r, c].tileCharacter.decrementEffectDurations();
                        boardspaces[r, c].tileCharacter.isActive = true;
                        boardspaces[r, c].tileCharacter.Opacity = 1;
                    }
                }
            }
            for (int r = 0; r < numRows; r++)
            {
                for (int c = 0; c < numCols; c++)
                {
                    if(boardspaces[r,c].containsCharacter())
                        boardspaces[r, c].tileCharacter.Click -= new RoutedEventHandler(Character_Click);
                    Board.Children.Remove(cells[r, c]);
                }
            }

            cells[hero1.Row, hero1.Col].Children.Clear();
            cells[hero2.Row, hero2.Col].Children.Clear();
            cells[hero3.Row, hero3.Col].Children.Clear();
            cells[hero4.Row, hero4.Col].Children.Clear();
            cells[hero5.Row, hero5.Col].Children.Clear();

            this.NavigationService.GoBack();
        }

        private void hideOptions()
        {
            for (int r = 0; r < numRows; r++)
            {
                for (int c = 0; c < numCols; c++)
                {
                    boardspaces[r, c].BorderThickness = new Thickness(0);
                }
            }
        }
    }
}