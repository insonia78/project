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
using World_Map;

namespace CharacterCreation
{
    /// <summary>
    /// Interaction logic for CharacterCreationPage.xaml
    /// </summary>
    public partial class CharacterCreationPage : Page
    {
        // fields
        Window main;    // reference titleScreen components.
        MediaElement music; // to be passed to the world map.


        int[] heroType = new int[5];
        String[] name_female = new String[20] { "Sally", "Sammy", "Erica", "Amanda", "Caitlyn", "Sandy", 
                                                "Ashley", "Serena", "Catherine", "Gabby", "Angie", "Lori", 
                                                "Anna", "Stephanie", "Rachel", "Monica", "Nina", "Rose", 
                                                "Emily", "LaraCroft" };
        bool[] gender = new bool[5];
        String[] name_male = new String[20] { "Evan", "Christian", "Joseph", "Bob", "Dylan", "Aaron", "Bill", 
                                              "Chandler", "Joey", "Mark", "Tyler", "Malane", "Thomas", "Cedric", 
                                              "William", "Devin", "Randy", "Travis", "Leon", "MasterChief" };
        String[] hero_name = new String[5];
        String[] job_type = new String[5];

        Hero[] heroes;

        string name, name2;

        public bool hero1WasClicked = false;
        public bool hero2WasClicked = false;
        public bool hero3WasClicked = false;
        public bool hero4WasClicked = false;
        public bool hero5WasClicked = false;

        public CharacterCreationPage(Window title, MediaElement bgM)
        {
            main = title;
            music = bgM;
            InitializeComponent();
        }

        //allows the array to be accessed in individual heros class
        public String[] jobTypeArray
        {
            get
            {
                return job_type;
            }
            set
            {
                job_type = value;
            }
        }

        //allows the array to be accessed in individual heros class
        public String[] heroNameArray
        {
            get
            {
                return hero_name;
            }
            set
            {
                hero_name = value;
            }
        }

        //allows the array to be accessed in individual heros class
        public bool[] heroGenderArray
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
            }
        }

        private void EnterLeaveGame()
        {
            BlackOut.Visibility = Visibility.Visible;
            LeaveGameGrid.Visibility = Visibility.Visible;
            //bgm.Volume = 0.2;
        }

        private void CustomAppear()
        {
            BlackOut.Visibility = Visibility.Visible;
            CustomizeWindowGrid.Visibility = Visibility.Visible;
        }

        /// <the Boolean Gender() creates a random number generator that determines if the  heros are male or female. it puts them into the array
        public void Gender()
        {
            Random random = new Random();
            int num;    // represents job role
            int numba;  // represents gender

            for (int i = 0; i < 5; i++)
            {
                num = random.Next(0, 5);
                heroType[i] = num;

                numba = random.Next(1, 3);

                if (numba == 1)
                {
                    gender[i] = true;
                    ///<here is where I am having issues with the picture. I tried to save it to resources like a few pages suggested.
                    ///it saved it to a new folder, not the resources section I need and i cant get it to go to the right resources.
                    ///<Hero1.Background = Properties.Resources.deadladybug2.jpg;
                }
                else
                {
                    gender[i] = false;
                }
            }
        }

        //sets the hero classes for the randomize button
        public void Herocharacter()
            /*
             * 1 of 5 different assortments of heroes.
             */
        {
            Random random = new Random();

            int num;    // roles of heroes.
            int nums;   // combination choice.

            int i = 0;
            num = random.Next(0, 5);
            heroType[i] = num; // not sure where this is going.

            nums = random.Next(0, 5);

            if (nums == 0)
            {
                job_type[i] = "Software Engineer";
                job_type[i + 1] = "Support Engineer";
                job_type[i + 2] = "Systems Analyst";
                job_type[i + 3] = "Network Architect";
                job_type[i + 4] = "Information Security";
            }
            else if (nums == 1)
            {
                job_type[i] = "Information Security";
                job_type[i + 1] = "Software Engineer";
                job_type[i + 2] = "Support Engineer";
                job_type[i + 3] = "Systems Analyst";
                job_type[i + 4] = "Network Architect";
            }
            else if (nums == 2)
            {
                job_type[i] = "Network Architect";
                job_type[i + 1] = "Information Security";
                job_type[i + 2] = "Software Engineer";
                job_type[i + 3] = "Support Engineer";
                job_type[i + 4] = "Systems Analyst";
            }
            else if (nums == 3)
            {
                job_type[i] = "Systems Analyst";
                job_type[i + 1] = "Network Architect";
                job_type[i + 2] = "Information Security";
                job_type[i + 3] = "Software Engineer";
                job_type[i + 4] = "Support Engineer";
            }
            else
            {
                job_type[i] = "Support Engineer";
                job_type[i + 1] = "Systems Analyst";
                job_type[i + 2] = "Network Architect";
                job_type[i + 3] = "Information Security";
                job_type[i + 4] = "Software Engineer";
            }
        }

        //this sets the names for the randomization button
        //it sends the names into a common array so they can be accessed for the heros.
        //false are females.
        //<true are males.
        public void HeroNames()
        {
            Random random = new Random();

            int numnum;


            for (int i = 0; i < 5; i++)
            {

                heroType[i] = i;
                numnum = random.Next(0, 20);

                if (i == 0)
                {
                    if (gender[i] == true)
                    {
                        name = name_male[numnum];
                        hero_name[i] = name;
                    }
                    else
                    {
                        name = name_female[numnum];
                        hero_name[i] = name;
                    }
                }
                else if (i == 1)
                {
                    if (gender[i] == true)
                    {
                        name2 = name_male[numnum];

                        while (name2 == hero_name[0])
                        {
                            numnum = random.Next(0, 20);
                            name2 = name_male[numnum];
                            name = name2;
                            hero_name[i] = name;
                        }

                        hero_name[i] = name2;
                    }
                    else
                    {
                        name2 = name_female[numnum];

                        while (name2 == hero_name[0])
                        {
                            numnum = random.Next(0, 20);
                            name2 = name_female[numnum];
                            name = name2;
                            hero_name[i] = name;
                        }

                        hero_name[i] = name2;
                    }
                }
                else if (i == 2)
                {
                    if (gender[i] == true)
                    {
                        name2 = name_male[numnum];

                        while (name2 == hero_name[0] || name2 == hero_name[1])
                        {
                            numnum = random.Next(0, 20);
                            name2 = name_male[numnum];
                            name = name2;
                            hero_name[i] = name;
                        }

                        hero_name[i] = name2;
                    }
                    else
                    {
                        name2 = name_female[numnum];
                        while (name2 == hero_name[0] || name2 == hero_name[1])
                        {
                            numnum = random.Next(0, 20);
                            name2 = name_female[numnum];
                            name = name2;
                            hero_name[i] = name;
                        }

                        hero_name[i] = name2;
                    }
                }
                else if (i == 3)
                {
                    if (gender[i] == true)
                    {
                        name2 = name_male[numnum];

                        while (name2 == hero_name[0] || name2 == hero_name[1] || name2 == hero_name[2])
                        {
                            numnum = random.Next(0, 20);
                            name2 = name_male[numnum];
                            name = name2;
                            hero_name[i] = name;
                        } 
                        hero_name[i] = name2;
                    }
                    else
                    {
                        name2 = name_female[numnum];
                        while (name2 == hero_name[0] || name2 == hero_name[1] || name2 == hero_name[2])
                        {
                            numnum = random.Next(0, 20);
                            name2 = name_female[numnum];
                            name = name2;
                            hero_name[i] = name;
                        }
                        hero_name[i] = name2;
                    }
                }
                else
                {
                    if (gender[i] == true)
                    {
                        name2 = name_male[numnum];

                        while (name2 == hero_name[0] || name2 == hero_name[1] || name2 == hero_name[2] || name2 == hero_name[3])
                        {
                            numnum = random.Next(0, 20);
                            name2 = name_male[numnum];
                            name = name2;
                            hero_name[i] = name;
                        }
                        hero_name[i] = name2;
                    }
                    else
                    {
                        name2 = name_female[numnum];
                        while (name2 == hero_name[0] || name2 == hero_name[1] || name2 == hero_name[2] || name2 == hero_name[3])
                        {
                            numnum = random.Next(0, 20);
                            name2 = name_female[numnum];
                            name = name2;
                            hero_name[i] = name;
                        }
                        hero_name[i] = name2;
                    }
                }
            }
        }

        public void placeCharacter()
        {
            heroes = new Hero[5];
            for (int i = 0; i < 5; i++)
            {
                switch (job_type[i])
                {
                    case "Software Engineer":
                        {
                            heroes[i] = new SoftwareEngineer(hero_name[i], gender[i]);
                            break;
                        }
                    case "Support Engineer":
                        {
                            heroes[i] = new SupportEngineer(hero_name[i], gender[i]);
                            break;
                        }
                    case "Systems Analyst":
                        {
                            heroes[i] = new SystemsAnalyst(hero_name[i], gender[i]);
                            break;
                        }
                    case "Network Architect":
                        {
                            heroes[i] = new NetworkArchitect(hero_name[i], gender[i]);
                            break;
                        }
                    case "Information Security":
                        {
                            heroes[i] = new InformationSecurity(hero_name[i], gender[i]);
                            break;
                        }

                    default:
                        {
                            break;
                        }
                }
            }
            heroOneSlot.Source = heroes[0].CharacterPortrait;
            heroTwoSlot.Source = heroes[1].CharacterPortrait;
            heroThreeSlot.Source = heroes[2].CharacterPortrait;
            heroFourSlot.Source = heroes[3].CharacterPortrait;
            heroFiveSlot.Source = heroes[4].CharacterPortrait;

            nameLabelOne.Content = heroes[0].Name;
            nameLabelTwo.Content = heroes[1].Name;
            nameLabelThree.Content = heroes[2].Name;
            nameLabelFour.Content = heroes[3].Name;
            nameLabelFive.Content = heroes[4].Name;

            genderLabelOne.Content = heroes[0].Male;
            genderLabelTwo.Content = heroes[1].Male;
            genderLabelThree.Content = heroes[2].Male;
            genderLabelFour.Content = heroes[3].Male;
            genderLabelFive.Content = heroes[4].Male;

            jobLabelOne.Content = heroes[0].JobRole;
            jobLabelTwo.Content = heroes[1].JobRole;
            jobLabelThree.Content = heroes[2].JobRole;
            jobLabelFour.Content = heroes[3].JobRole;
            jobLabelFive.Content = heroes[4].JobRole;
        }

        ///<this is the start of the randomize button. when you click it, it will call the gender one.
        /// once it calls the gender it will call the hero one. 
        /// after it calls the hero one, it calls the name.
        private void RandomButton_Click(object sender, RoutedEventArgs e)
        {
            ///<does this before it does everything else.this.Gender();
            Gender();
            HeroNames();
            Herocharacter();
            placeCharacter();
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

        private void LeaveGameOkButton_Click(object sender, RoutedEventArgs e)
        {
            // shuts down the instance of the wpf application.
            Application.Current.Shutdown();
        }

        private void LeaveGameCancelButton_Click(object sender, RoutedEventArgs e)
        {
            //bgm.Volume = 0.5;
            LeaveGameGrid.Visibility = Visibility.Hidden;
            BlackOut.Visibility = Visibility.Hidden;
        }

        private void HeroOneHighlight_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroOneHighlight.Opacity = .15;
        }

        private void HeroOneHighlight_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroOneHighlight.Opacity = 1;
        }

        private void HeroOneAura_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroOneHighlight.Opacity = .15;
        }

        private void HeroOneAura_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroOneHighlight.Opacity = 1;
        }

        private void HeroOneFrame_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroOneHighlight.Opacity = .15;
        }

        private void HeroOneFrame_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroOneHighlight.Opacity = 1;
        }

        private void heroOneSlot_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroOneHighlight.Opacity = .15;
        }

        private void heroOneSlot_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroOneHighlight.Opacity = 1;
        }

        private void HeroTwoAura_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroTwoHighlight.Opacity = .15;
        }

        private void HeroTwoAura_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroTwoHighlight.Opacity = 1;
        }

        private void HeroTwoFrame_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroTwoHighlight.Opacity = .15;
        }

        private void HeroTwoFrame_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroTwoHighlight.Opacity = 1;
        }

        private void heroTwoSlot_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroTwoHighlight.Opacity = .15;
        }

        private void heroTwoSlot_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroTwoHighlight.Opacity = 1;
        }

        private void HeroThreeHighlight_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroThreeHighlight.Opacity = .15;
        }

        private void HeroThreeHighlight_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroThreeHighlight.Opacity = 1;
        }

        private void HeroThreeAura_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroThreeHighlight.Opacity = .15;
        }

        private void HeroThreeAura_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroThreeHighlight.Opacity = 1;
        }

        private void HeroThreeFrame_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroThreeHighlight.Opacity = .15;
        }

        private void HeroThreeFrame_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroThreeHighlight.Opacity = 1;
        }

        private void heroThreeSlot_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroThreeHighlight.Opacity = .15;
        }

        private void heroThreeSlot_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroThreeHighlight.Opacity = 1;
        }

        private void HeroFourHighlight_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroFourHighlight.Opacity = .15;
        }

        private void HeroFourHighlight_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroFourHighlight.Opacity = 1;
        }

        private void HeroFourAura_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroFourHighlight.Opacity = .15;
        }

        private void HeroFourAura_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroFourHighlight.Opacity = 1;
        }

        private void HeroFourFrame_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroFourHighlight.Opacity = .15;
        }

        private void HeroFourFrame_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroFourHighlight.Opacity = 1;
        }

        private void heroFourSlot_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroFourHighlight.Opacity = .15;
        }

        private void heroFourSlot_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroFourHighlight.Opacity = 1;
        }

        private void HeroFiveHighlight_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroFiveHighlight.Opacity = .15;
        }

        private void HeroFiveHighlight_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroFiveHighlight.Opacity = 1;
        }

        private void HeroFiveAura_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroFiveHighlight.Opacity = .15;
        }

        private void HeroFiveAura_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroFiveHighlight.Opacity = 1;
        }

        private void HeroFiveFrame_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroFiveHighlight.Opacity = .15;
        }

        private void HeroFiveFrame_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroFiveHighlight.Opacity = 1;
        }

        private void heroFiveSlot_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroFiveHighlight.Opacity = .15;
        }

        private void heroFiveSlot_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroFiveHighlight.Opacity = 1;
        }

        private void HeroTwoHighlight_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroTwoHighlight.Opacity = .15;
        }

        private void HeroTwoHighlight_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroTwoHighlight.Opacity = 1;
        }

        private void SoftwareEngineerButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CustomizeXButton_Click(object sender, RoutedEventArgs e)
        {
            CustomizeWindowGrid.Visibility = Visibility.Hidden;
            BlackOut.Visibility = Visibility.Hidden;
        }

        private void HeroOneFrame_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void HeroOneAura_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void HeroOneHighlight_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void HeroTwoHighlight_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void HeroTwoAura_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void HeroTwoFrame_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void HeroThreeHighlight_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void HeroThreeAura_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void HeroThreeFrame_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void HeroFourHighlight_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void HeroFourAura_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void HeroFourFrame_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void HeroFiveHighlight_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void HeroFiveAura_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void HeroFiveFrame_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void jobLabelOne_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void genderLabelOne_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void nameLabelOne_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void nameLabelTwo_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void genderLabelTwo_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void jobLabelTwo_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void nameLabelThree_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void genderLabelThree_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void jobLabelThree_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void nameLabelFour_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void genderLabelFour_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void jobLabelFour_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void nameLabelFive_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void genderLabelFive_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void jobLabelFive_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void nameLabelOne_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroOneHighlight.Opacity = .15;
        }

        private void nameLabelOne_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroOneHighlight.Opacity = 1;
        }

        private void genderLabelOne_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroOneHighlight.Opacity = .15;
        }

        private void genderLabelOne_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroOneHighlight.Opacity = 1;

        }

        private void jobLabelOne_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroOneHighlight.Opacity = .15;

        }

        private void jobLabelOne_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroOneHighlight.Opacity = 1;

        }

        private void nameLabelTwo_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroTwoHighlight.Opacity = .15;

        }

        private void nameLabelTwo_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroTwoHighlight.Opacity = 1;

        }

        private void genderLabelTwo_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroTwoHighlight.Opacity = .15;

        }

        private void genderLabelTwo_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroTwoHighlight.Opacity = 1;

        }

        private void jobLabelTwo_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroTwoHighlight.Opacity = .15;

        }

        private void jobLabelTwo_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroTwoHighlight.Opacity = 1;

        }

        private void nameLabelThree_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroThreeHighlight.Opacity = .15;

        }

        private void nameLabelThree_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroThreeHighlight.Opacity = 1;

        }

        private void genderLabelThree_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroThreeHighlight.Opacity = .15;

        }

        private void genderLabelThree_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroThreeHighlight.Opacity = 1;

        }

        private void jobLabelThree_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroThreeHighlight.Opacity = .15;

        }

        private void jobLabelThree_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroThreeHighlight.Opacity = 1;

        }

        private void nameLabelFour_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroFourHighlight.Opacity = .15;

        }

        private void nameLabelFour_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroFourHighlight.Opacity = 1;

        }

        private void genderLabelFour_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroFourHighlight.Opacity = .15;

        }

        private void genderLabelFour_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroFourHighlight.Opacity = 1;

        }

        private void jobLabelFour_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroFourHighlight.Opacity = .15;

        }

        private void jobLabelFour_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroFourHighlight.Opacity = 1;

        }

        private void nameLabelFive_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroFiveHighlight.Opacity = .15;

        }

        private void nameLabelFive_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroFiveHighlight.Opacity = 1;

        }

        private void genderLabelFive_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroFiveHighlight.Opacity = .15;

        }

        private void genderLabelFive_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroFiveHighlight.Opacity = 1;

        }

        private void jobLabelFive_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroFiveHighlight.Opacity = .15;

        }

        private void jobLabelFive_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroFiveHighlight.Opacity = 1;

        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            World_Map.MainWindow map =
                new World_Map.MainWindow(heroes);

            this.NavigationService.Navigate(map);
        }
    }
}
