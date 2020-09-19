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
using Community;
using GameBoard;

namespace World_Map
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Page
    {
        //Variables to determine whether a level is locked or unlocked
        //New game will only have the cafeteria and library unlocked
        private bool cafeteriaUnlocked = true;
        private bool libraryUnlocked = true;
        private bool murrayUnlocked = false;
        private bool craigLeeUnlocked = false;
        private bool clarkUnlocked = false;
        private bool gaigeUnlocked = false;

        Window main;    // reference titleScreen components.
        MediaElement music; // to be passed to the world map.

        //Testing an array of heroes before it officially gets passed from either the character creation or board game.
        Hero [] chosenHeroes = new Hero[5];
        Hero[] setOfHeroes = new Hero[5];

        public MainWindow()
        {
            InitializeComponent();
            //Sets the level/campus building's hoverOver status
            buildingSetUp();
            //Apply all five buttons to the MouseLeave event handler
            //When a the mouse leaves one of the five character buttons the button should be set to hidden
            btnCharacter1.MouseLeave += character_MouseLeave;
            btnCharacter2.MouseLeave += character_MouseLeave;
            btnCharacter3.MouseLeave += character_MouseLeave;
            btnCharacter4.MouseLeave += character_MouseLeave;
            btnCharacter5.MouseLeave += character_MouseLeave;
            
            //Fill in array of heroes with testers
            SoftwareEngineer Cedric = new SoftwareEngineer("Cedric", true);
            NetworkArchitect Malane = new NetworkArchitect("Malane", true);
            InformationSecurity Tom = new InformationSecurity("Tom", true);
            SystemsAnalyst Tyler = new SystemsAnalyst("Tyler", true);
            SupportEngineer Sandy = new SupportEngineer("Sandy", false);
            chosenHeroes[0] = Malane;
            chosenHeroes[1] = Cedric;
            chosenHeroes[2] = Tom;
            chosenHeroes[3] = Tyler;
            chosenHeroes[4] = Sandy;
            
        }
        //Mock Constructor that takes array of characters

        public MainWindow(Hero[] h)
        {
            InitializeComponent();
            //Sets the level/campus building's hoverOver statusmain = title;
            buildingSetUp();
            //Apply all five buttons to the MouseLeave event handler
            //When a the mouse leaves one of the five character buttons the button should be set to hidden
            btnCharacter1.MouseLeave += character_MouseLeave;
            btnCharacter2.MouseLeave += character_MouseLeave;
            btnCharacter3.MouseLeave += character_MouseLeave;
            btnCharacter4.MouseLeave += character_MouseLeave;
            btnCharacter5.MouseLeave += character_MouseLeave;
            //Gives setOfHeroes array with passed array of Characters 
            int i;
            for (i = 0; i < h.Length; i++)
            {
                setOfHeroes[i] = h[i];
            }
            character1image.Source = setOfHeroes[0].CharacterPicture;
            character2image.Source = setOfHeroes[1].CharacterPicture;
            character3image.Source = setOfHeroes[2].CharacterPicture;
            character4image.Source = setOfHeroes[3].CharacterPicture;
            character5image.Source = setOfHeroes[4].CharacterPicture;

            PortraitImage1.Source = setOfHeroes[0].CharacterPortrait;
            PortraitImage2.Source = setOfHeroes[1].CharacterPortrait;
            PortraitImage3.Source = setOfHeroes[2].CharacterPortrait;
            PortraitImage4.Source = setOfHeroes[3].CharacterPortrait;
            PortraitImage5.Source = setOfHeroes[4].CharacterPortrait;

            //test.Source = chosenHeroes[0].CharacterPicture;
            //testIMAGE.Source = chosenHeroes[1].CharacterPicture;
        }

    /***************************************************CHARACTERS***************************************************************/
        //Mouse enters button 1/Character 1
        //Status from previous run cleared
        //Status of character becomes visible
        private void btnCharacter1_MouseEnter(object sender, MouseEventArgs e)
        {

            lstCharacterStats.Items.Clear();
            lstCharacterStats.Visibility = System.Windows.Visibility.Visible;
            lstCharacterStats.Items.Add(setOfHeroes[0].ToStringScreen());//(setOfHeroes[0].ToStringScreen());
           //    imageTEST.Source = setOfHeroes[0].CharacterPicture;//new BitmapImage(new Uri(@"/Pictures/FemaleInformationSecurity.png", UriKind.Relative));
           // imageTEST.Source = setOfHeroes[0].CharacterPortrait;

            portrait1.Source = setOfHeroes[0].CharacterPortrait;


            portrait1.Visibility = System.Windows.Visibility.Visible;
            portraitoutter1.Visibility = System.Windows.Visibility.Visible;
        }
        
        //Mouse enters button 2/Character 2
        //Status from previous run cleared
        //Status of character becomes visible
        private void btnCharacter2_MouseEnter_1(object sender, MouseEventArgs e)
        {
            lstCharacterstats2.Items.Clear();
            lstCharacterstats2.Visibility = System.Windows.Visibility.Visible;
            lstCharacterstats2.Items.Add(setOfHeroes[1].ToStringScreen());
            PortraitImage2.Source = setOfHeroes[1].CharacterPortrait;

            portraitoutter2.Visibility = System.Windows.Visibility.Visible;


            PortraitImage2.Visibility = System.Windows.Visibility.Visible;

        }

        //Mouse enters button 3/Character 3
        //Status from previous run cleared
        //Status of character becomes visible
        private void btnCharacter3_MouseEnter(object sender, MouseEventArgs e)
        {
            lstCharacterstats3.Items.Clear();
            lstCharacterstats3.Visibility = System.Windows.Visibility.Visible;
            lstCharacterstats3.Items.Add(setOfHeroes[2].ToStringScreen());
            PortraitImage3.Source = setOfHeroes[2].CharacterPortrait;

            portraitoutter3.Visibility = System.Windows.Visibility.Visible;


            PortraitImage3.Visibility = System.Windows.Visibility.Visible;
        }

        //Mouse enters button 4/Character 4
        //Status from previous run cleared
        //Status of character becomes visible
        private void btnCharacter4_MouseEnter(object sender, MouseEventArgs e)
        {
            lstCharacterstats4.Items.Clear();
            lstCharacterstats4.Visibility = System.Windows.Visibility.Visible;
            lstCharacterstats4.Items.Add(setOfHeroes[3].ToStringScreen());
            PortraitImage4.Source = setOfHeroes[3].CharacterPortrait;
            portraitoutter4.Visibility = System.Windows.Visibility.Visible;


            PortraitImage4.Visibility = System.Windows.Visibility.Visible;
        }
        //Mouse enters button 5/Character 5
        //Status from previous run cleared
        //Status of character becomes visible
        private void btnCharacter5_MouseEnter(object sender, MouseEventArgs e)
        {
            lstCharacterStats5.Items.Clear();
            lstCharacterStats5.Visibility = System.Windows.Visibility.Visible;
            lstCharacterStats5.Items.Add(setOfHeroes[4].ToStringScreen());
            PortraitImage5.Source = setOfHeroes[4].CharacterPortrait;

            portraitoutter5.Visibility = System.Windows.Visibility.Visible;


            PortraitImage5.Visibility = System.Windows.Visibility.Visible;
        }

        //When mouse leaves the Character button(s) set's the Character(s) status visibility to hidden
        private void character_MouseLeave(object sender, MouseEventArgs e)
        {

            lstCharacterStats.Visibility = System.Windows.Visibility.Hidden;
            lstCharacterstats2.Visibility = System.Windows.Visibility.Hidden;
            lstCharacterstats3.Visibility = System.Windows.Visibility.Hidden;
            lstCharacterstats4.Visibility = System.Windows.Visibility.Hidden;
            lstCharacterStats5.Visibility = System.Windows.Visibility.Hidden;

            portraitoutter1.Visibility = System.Windows.Visibility.Hidden;
            portraitoutter2.Visibility = System.Windows.Visibility.Hidden;
            portraitoutter3.Visibility = System.Windows.Visibility.Hidden;
            portraitoutter4.Visibility = System.Windows.Visibility.Hidden;
            portraitoutter5.Visibility = System.Windows.Visibility.Hidden;

            portrait1.Visibility = System.Windows.Visibility.Hidden;
            PortraitImage2.Visibility = System.Windows.Visibility.Hidden;
            PortraitImage3.Visibility = System.Windows.Visibility.Hidden;
            PortraitImage4.Visibility = System.Windows.Visibility.Hidden;
            PortraitImage5.Visibility = System.Windows.Visibility.Hidden;

        }

      
       /***************************************************CHARACTERS***************************************************************/




        /****************************************************BUILDING***************************************************************/
        //Initialize building and option buttons with 0 opacity -- Making them transparant
        //Enables mouse enter and mouse leave to be activated for buildings/level and option button
        private void buildingSetUp()
        {

            //Building 1 - Cafeteria -- Tutorial Lvl
            btnCafeteria.Opacity = 0;
            btnCafeteria.MouseEnter += control_MouseEnter;
            btnCafeteria.MouseLeave += control_MouseLeave;

            //Building 2 - Library
            btnLibrary.Opacity = 0;
            btnLibrary.MouseEnter += control_MouseEnter;
            btnLibrary.MouseLeave += control_MouseLeave;

            //Building 3 - Murray Center
            btnMurray.Opacity = 0;
            btnMurray.MouseEnter += control_MouseEnter;
            btnMurray.MouseLeave += control_MouseLeave;

            //Building 4 - Craig Lee
            btnCraigLee.Opacity = 0;
            btnCraigLee.MouseEnter += control_MouseEnter;
            btnCraigLee.MouseLeave += control_MouseLeave;

            //Building 5 - Clark
            btnClark.Opacity = 0;
            btnClark.MouseEnter += control_MouseEnter;
            btnClark.MouseLeave += control_MouseLeave;

            //Building 6 - Gaige
            btnGaige.Opacity = 0;
            btnGaige.MouseEnter += control_MouseEnter;
            btnGaige.MouseLeave += control_MouseLeave;

            //Button for options
            btnOption.Opacity = 0;
            btnOption.MouseEnter += control_MouseEnter;
            btnOption.MouseLeave += control_MouseLeave;
        }

        //Increase opacity of building and option button to .40 when hovered over
       private void control_MouseEnter(object sender, MouseEventArgs e)
        {
            var btn = (Button)sender;
            btn.Opacity = .40;

        }
       //Decreate opacity of building and option button to 0 when mouse leaves
        //Calls reset function
       private void control_MouseLeave(object sender, MouseEventArgs e)
       {
           var btn = (Button)sender;
           btn.Opacity = .0;
           reset();

       }

       //Resets the labels over each building to show level number
       private void reset()
       {
           btnMurray.FontSize = 60;
           btnCraigLee.FontSize = 60;
           btnClark.FontSize = 60;
           btnCafeteria.Content = "TUTORIAL";
           btnLibrary.Content = "LVL 1";
           btnMurray.Content = "LVL 2";
           btnCraigLee.Content = "LVL 3";
           btnClark.Content = "LVL 4";
           btnGaige.Content = "LVL 5";
       }


        //Displays a lvl status message by updating the labels over the cafeteria button -- States if they are locked or unlocked
       private void btnCafeteria_Click(object sender, RoutedEventArgs e)
       {
           if (cafeteriaUnlocked == true)
           {
               btnCafeteria.Content = "BEGIN";
           }
           else
           {
               btnCafeteria.Content = "LOCKED";
           }
       }

       //Displays a lvl status message by updating the labels over the library button-- States if they are locked or unlocked
       private void btnLibrary_Click(object sender, RoutedEventArgs e)
       {
           if (libraryUnlocked == true)
           {
               btnLibrary.Content = "BEGIN";
           }
           else
           {
               btnLibrary.Content = "LOCKED";
           }

       }

       //Displays a lvl status message by updating the labels over the Murray button -- States if they are locked or unlocked
       private void btnMurray_Click(object sender, RoutedEventArgs e)
       {
           if (murrayUnlocked == true)
           {
               btnMurray.Content = "BEGIN";
           }
           else
           {
               //Readjusted size
               btnMurray.FontSize = 35;
               btnMurray.Content = "LOCKED";
           }
       }

       //Displays a lvl status message by updating the labels over the Craiglee buttons -- States if they are locked or unlocked
       private void btnCraigLee_Click(object sender, RoutedEventArgs e)
       {
           if (craigLeeUnlocked == true)
           {
               btnCraigLee.Content = "BEGIN";
           }
           else
           {
               //Readjusted size
               btnCraigLee.FontSize = 40;
               btnCraigLee.Content = "LOCKED";
           }
       }
       //Displays a lvl status message by updating the labels over the Clark button -- States if they are locked or unlocked
       private void btnClark_Click(object sender, RoutedEventArgs e)
       {
           if (clarkUnlocked == true)
           {
               btnClark.Content = "BEGIN";
           }
           else
           {
               btnClark.FontSize = 45;
               btnClark.Content = "LOCKED";
           }
       }
       //Displays a lvl status message by updating the labels over the gaige button -- States if they are locked or unlocked
       private void btnGaige_Click(object sender, RoutedEventArgs e)
       {
           if (gaigeUnlocked == true)
           {
               btnGaige.Content = "BEGIN";
           }
           else
           {
               btnGaige.Content = "LOCKED";
           }
       }

       /****************************************************BUILDING***************************************************************/


       /********************************************FORMAT CUSTOM WINDOW***********************************************************/

        //Changing the title bar to custom
       private void TitleBarTip_MouseDown(object sender, MouseButtonEventArgs e)
       {
           //this.DragMove();
       }

       private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
       {
           //this.DragMove();
       }

       private void TitleBarButt_MouseDown(object sender, MouseButtonEventArgs e)
       {
           //this.DragMove();
       }

       //Customized minimize button - Designed in blend using a rectangle component
       private void MinimizeButton_Click_1(object sender, RoutedEventArgs e)
       {
           //WindowState = WindowState.Minimized;
       }

        //Customized close button - Designed in blend using a rectangle component
       private void XButton_Click(object sender, RoutedEventArgs e)
       {
           Application.Current.Shutdown();
       }

       private void btnLibrary_MouseDoubleClick(object sender, MouseButtonEventArgs e)
       {
           GameBoard.MainWindow library =
               new GameBoard.MainWindow("testmap.txt", setOfHeroes);

           this.NavigationService.Navigate(library);
       }
       /********************************************FORMAT CUSTOM WINDOW***********************************************************/
    }
}
