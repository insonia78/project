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
using System.Reflection;

namespace GameBoard
{
    public partial class MainWindow
    {
        private const int numberOfColumns = 3;
        private const int numberOfFrames = 7;
        private const int frameWidth = 20;
        private const int frameHeight = 20;
        public static readonly TimeSpan TimePerFrame = TimeSpan.FromSeconds(0.1);
        private int currentFrame = 0;
        private ImageSource spritesheet;
        private ImageBrush animation;
        private TranslateTransform SpriteSheetOffset;
        private Rectangle animationSpace;
        private Grid animationContainer;

        private void clearAttackOptions()
        {
            for(int r = 0; r < numRows; r++)
            {
                for(int c = 0; c < numCols; c++)
                {
                    if(boardspaces[r,c].attackOption != 0)
                    {
                        boardspaces[r,c].attackOption = 0;
                        typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(boardspaces[r, c], new object[] { false });
                        boardspaces[r, c].Click -= new RoutedEventHandler(AttackOption_Click);
                        boardspaces[r, c].MouseEnter -= new MouseEventHandler(AttackOption_MouseEnter);
                        boardspaces[r, c].MouseLeave -= new MouseEventHandler(AttackOption_MouseLeave);
                        refreshBoardSpace(r, c);
                    }
                }
            }
        }

        /*
         * Display buttons for the different Attacks a Hero can do.
         */
        private void Attack_Click(object sender, RoutedEventArgs e)
        {
            Test_Attack.IsEnabled = true;
        }

        /*
         * When a Hero is selected that can attack and the attack button is clicked, run the method(s) involved in displaying who they can attack, displaying different abilities, and then
         * executing that ability, and if an attack and an enemy is selected, set that the hero has attacked and moved to true (hero can't move after attacking), disable buttons for those
         * and the defend button (can't defend after attacking).
         */
        private void AttackOption_Click(object sender, RoutedEventArgs e)
        {
            int attackArea = -1;

            try
            {
                attackArea = (sender as Tile).attackOption;
            }
            catch
            {

            }

            //Make sure the selected hero hasn't already attacked this turn (mostly not necessary, but for safety against glitches?)
            if (!boardspaces[selectedHeroRow, selectedHeroCol].tileCharacter.hasAttacked)
            {
                //Apply damage to enemy/enemies in the area selected based on attacker's and victim's stats.
                for(int r = 0; r < numRows; r++)
                {
                    for(int c = 0; c < numCols; c++)
                    {
                        if(attackArea == boardspaces[r, c].attackOption)
                        {
                            int heroAttackStat = boardspaces[selectedHeroRow, selectedHeroCol].tileCharacter.attack;
                            int heroSpAttackStat = boardspaces[selectedHeroRow, selectedHeroCol].tileCharacter.specialAttack;
                            double attackPower = boardspaces[selectedHeroRow, selectedHeroCol].tileCharacter.selectedAttackPower;
                            if (boardspaces[r, c].containsCharacter() && boardspaces[r, c].tileCharacter.GetType().IsSubclassOf(typeof(GameBoard.Enemy)))
                            {
                                timer.Interval = TimeSpan.FromSeconds(0.2);
                                timer.Tick += onUpdate;
                                timer.Start();
                                damageAnimation(boardspaces[r, c].tileCharacter);

                                //Started writing something to display the amount of damage after the explosion animation, doesn't work the way I want yet.

                                //int oldHealth = boardspaces[r, c].tileCharacter.hp;
                                //boardspaces[r,c].tileCharacter.damage(heroAttackStat, heroSpAttackStat, attackPower);
                                //int newHealth = boardspaces[r, c].tileCharacter.hp;
                                //TextBox damageValue = new TextBox();
                                //damageValue.Text = Convert.ToString(newHealth - oldHealth);
                                //boardspaces[r, c].tileCharacter.Content = damageValue;

                            }
                        }
                    }
                }
            }

            clearAttackOptions();
            Attack.IsEnabled = false;
            Move.IsEnabled = false; //Hero can't move after attacking.
            boardspaces[selectedHeroRow, selectedHeroCol].tileCharacter.hasAttacked = true;
            boardspaces[selectedHeroRow, selectedHeroCol].tileCharacter.hasMoved = true;
            if(!boardspaces[selectedHeroRow, selectedHeroCol].tileCharacter.isActive) //Check if hero has moved, used an item, and attacked, if so, the hero's turn is over, is inactive
            {
                refreshBoardSpace(selectedHeroRow, selectedHeroCol); //refresh the character so it appears faded.
                Defend.IsEnabled = false;
                End_Turn.IsEnabled = false;
                //If inactive, the item button is already disabled, and the move and attack were previously disabled in this method when the attack was successful.
            }
            if (checkAllPlayersInactive())
            {
                nextTurn();
            }
        }

        public void Attack1_Click(object sender, RoutedEventArgs e)
        {
            boardspaces = boardspaces[selectedHeroRow, selectedHeroCol].tileCharacter.Attack1(boardspaces, numRows, numCols); //Determines the different spaces the character can attack

            for (int r = 0; r < numRows; r++)
            {
                for (int c = 0; c < numCols; c++)
                {
                    if (boardspaces[r, c].attackOption != 0) //display buttons fof the different spaces the user can attack
                    {
                        boardspaces[r, c].Click -= new RoutedEventHandler(Tile_Click); //Remove the Tile_Click event handler from the tile button
                        boardspaces[r, c].Click += new RoutedEventHandler(AttackOption_Click); //Add a AttackOption_Click event handler to the tile button
                        boardspaces[r, c].MouseEnter += new MouseEventHandler(AttackOption_MouseEnter);
                        boardspaces[r, c].MouseLeave += new MouseEventHandler(AttackOption_MouseLeave);
                        //Make a colored border around attackOption spaces to signify which ones they are to the user.
                        boardspaces[r, c].BorderBrush = attackOption;
                        boardspaces[r, c].BorderThickness = new Thickness(1);

                    }
                }
            }
        }

        public void AttackOption_MouseEnter(object sender, MouseEventArgs e)
        {
            int attackArea = -1;

            try
            {
                attackArea = (sender as Tile).attackOption;
            }
            catch
            {

            }

            for (int r = 0; r < numRows; r++)
            {
                for (int c = 0; c < numCols; c++)
                {
                    if (attackArea == boardspaces[r, c].attackOption)
                    {
                        typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(boardspaces[r,c], new object[] { true });
                    }
                }
            }
        }

        public void AttackOption_MouseLeave(object sender, MouseEventArgs e)
        {
            int attackArea = -1;

            try
            {
                attackArea = (sender as Tile).attackOption;
            }
            catch
            {

            }

            for (int r = 0; r < numRows; r++)
            {
                for (int c = 0; c < numCols; c++)
                {
                    if (attackArea == boardspaces[r, c].attackOption)
                    {
                        typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(boardspaces[r, c], new object[] { false });
                    }
                }
            }
        }

        private void damageAnimation(Button space)
        {
            animationContainer = new Grid();

            animationSpace = new Rectangle();
            animationContainer.Height = 40;
            animationContainer.Width = 60;

            animation = new ImageBrush();
            spritesheet = new BitmapImage(new Uri("test_explosion_spritesheet.png", UriKind.Relative));
            animation.ImageSource = spritesheet;

            //Is supposed to start in the left/top and cycle through frames, doesn't work yet, so I set it to just be on the biggest explosion frame.
            //animation.AlignmentX = AlignmentX.Left;
            //animation.AlignmentY = AlignmentY.Top;
            animation.AlignmentX = AlignmentX.Center;
            animation.AlignmentY = AlignmentY.Bottom;
            animation.Stretch = Stretch.None;
            SpriteSheetOffset = new TranslateTransform(0, 0);
            animation.Transform = SpriteSheetOffset;

            animationSpace.Fill = animation;
            animationContainer.Children.Add(animationSpace);
            animationContainer.Height = 20;
            animationContainer.Width = 20;
            space.Content = animationContainer;
        }

        private void onUpdate(object sender, object e)
        {
            if (currentFrame < 6)
            {
                //currentFrame = (currentFrame + 1 + numberOfFrames) % numberOfFrames;
                var column = currentFrame % numberOfColumns;
                var row = currentFrame / numberOfColumns;

                SpriteSheetOffset.X = -column * frameWidth;
                SpriteSheetOffset.Y = -row * frameHeight;

                //animationSpace.Fill = animation;
                //animationContainer.Children.Clear();
                //animationContainer.Children.Add(animationSpace);
                //animationContainer.Height = 20;
                //animationContainer.Width = 20;
                //space.Content = animationContainer;

                currentFrame++;
            }
            else
            {
                currentFrame = 0;
                timer.Stop();
                timer.Tick -= onUpdate;
            }
        }



    }
}
