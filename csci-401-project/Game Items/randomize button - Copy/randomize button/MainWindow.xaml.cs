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




namespace randomize_button
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[] heroType = new int[5];
        String[] name_female = new String[20] { "Sally", "Sammy", "Erica", "Amanda", "Caitlyn", "Sandy", "Ashley", "Serena", "Catherine", "Gabby", "Angie", "Lori", "Anna", "Stephanie", "Rachel", "Monica", "LaraCroft", "Rose", "Emily", "Nina" };
            bool[] gender = new bool[5];
            String[] name_male = new String[20] { "Evan", "Christian", "Joseph", "Bob", "Dylan", "Aaron", "Bill", "Chandler", "Joey", "Mark", "Tyler", "Malane", "Thomas", "Cedric", "William", "Devin", "Randy", "Travis", "Leon", "MasterChief" };
            String[] hero_name = new String[5];
            String[] hero_type = new String[5];
            string name, name2;
            public bool hero1WasClicked = false;
            public bool hero2WasClicked = false;
            public bool hero3WasClicked = false;
            public bool hero4WasClicked = false;
            public bool hero5WasClicked = false;
       
        //allows the array to be accessed in individual heros class
        public String[] heroTypeArray
        {
            get
            {
                return hero_type;
            }
            set
            {
                hero_type = value;
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



        public MainWindow()
        {
            InitializeComponent();

            
        }
        /// <the Boolean Gender() creates a random number generator that determines if the  heros are male or female. it puts them into the array
        public void Gender()
        {
            Random random = new Random();

            
           
            int num ;
            for (int i = 0; i < 5; i++)
            {
                num = random.Next(1, 6);
                heroType[i] = num;
               
                    
                    num = random.Next(1, 3);
                    if (num == 1)
                    {
                        
                        gender[i] = true;
                            name = name_male[i];
                        
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

      

        public void Herocharacter()
        {
            Random random = new Random();



            int num;
            int nums;
           
           int i = 0;
                num = random.Next(1, 6);
                heroType[i] = num;


                nums = random.Next(1, 6);
                
                if (nums == 1)
                {
                    hero_type[i] = "warrior";
                    hero_type[i + 1] = "healer";
                    hero_type[i + 2]="mage";
                    hero_type[i + 3]="hunter";
                    hero_type[i + 4] = "rogue";
                }
                else if (nums == 2)
                {
                    hero_type[i] = "rogue";
                    hero_type[i + 1] = "warrior";
                    hero_type[i + 2] = "healer";
                    hero_type[i + 3] = "mage";
                    hero_type[i + 4] = "hunter";


                }
                else if (nums == 3)
                {
                    hero_type[i] = "hunter";
                    hero_type[i + 1] = "rogue";
                    hero_type[i + 2] = "warrior";
                    hero_type[i + 3] = "healer";
                    hero_type[i + 4] = "mage";
                }
                else if (nums == 4)
                {
                    hero_type[i] = "mage";
                    hero_type[i + 1] =  "hunter";
                    hero_type[i + 2] = "rogue";
                    hero_type[i + 3] =  "warrior";
                    hero_type[i + 4] =  "healer";
                }
                else 
                {
                    hero_type[i] = "healer";
                    hero_type[i + 1] =  "mage";
                    hero_type[i + 2] = "hunter";
                    hero_type[i + 3] = "rogue";
                    hero_type[i + 4] =  "warrior";
                }
            }

        

        /// <this sets the names for the randomization button
        /// <it sends the names into a common array so they can be accessed for the heros.
        /// <false are girls.
        /// <true are guys.
        public void HeroNames()
        {
            Random random = new Random();


            
            int numnum;

            for (int i = 0; i < 5; i++)
            {
                
                heroType[i] = i;


                numnum = random.Next(0, 20);
                if (gender[i] == true)
                {
                  

            
            if (i == 0)
            {
                name = name_male[numnum];
                hero_name[i] = name;
            }
            else if (i == 1)
            {
                name2 = name_male[numnum];
                if (name2 == hero_name[0])
                {
                    numnum = random.Next(0, 20);
                    name2 = name_male[numnum];
                }
                else
                {
                    name = name2;
                    hero_name[1] = name;
                }
            }
            else if (i == 2)
            {
                name2 = name_male[numnum];
                if (name2 == hero_name[0] || name2 == hero_name[1])
                {
                    numnum = random.Next(0, 19);
                    name2 = name_male[numnum];
                }
                else
                {
                    name = name2;
                    hero_name[2] = name;
                }
            }
            else if (i == 3)
            {
                name2 = name_male[numnum];
                if (name2 == hero_name[0] || name2 == hero_name[1] || name2 == hero_name[2])
                {
                    numnum = random.Next(0, 19);
                    name2 = name_male[numnum];
                }
                else
                {
                    name = name2;
                    hero_name[3] = name;
                }
            }
            else if (i == 4)
            {
                name2 = name_male[numnum];
                if (name2 == hero_name[0] || name2 == hero_name[1] || name2 == hero_name[2] || name2 == hero_name[3])
                {
                    numnum = random.Next(0, 19);
                    name2 = name_male[numnum];
                }
            }
        
                }
                else if(gender[i] == false)
                {

                    if (i == 0)
                    {
                        name = name_female[numnum];
                        hero_name[0] = name;
                    }

                    else if (i == 1)
                    {
                        name2 = name_female[numnum];
                        if (name2 == hero_name[0])
                        {
                            numnum = random.Next(0, 19);
                            name2 = name_female[numnum];
                        }
                    
                        else
                        {
                            name = name2;
                            hero_name[1] = name;
                        }
                    }
                    else if (i == 2)
                    {
                        name2 = name_female[numnum];
                        if (name2 == hero_name[0] || name2 == hero_name[1])
                        {
                            numnum = random.Next(0, 19);
                            name2 = name_female[numnum];
                        }
                        else
                        {
                            name = name2;
                            hero_name[2] = name;
                        }
                    }
                    else if (i == 3)
                    {
                        name2 = name_female[numnum];
                        if (name2 == hero_name[0] || name2 == hero_name[1] || name2 == hero_name[2])
                        {
                            numnum = random.Next(0, 19);
                            name2 = name_female[numnum];
                        }
                        else
                        {
                            name = name2;
                            hero_name[3] = name;
                        }
                    }
                    else if (i == 4)
                    {
                        name2 = name_female[numnum];
                        if (name2 == hero_name[0] || name2 == hero_name[1] || name2 == hero_name[2] || name2 == hero_name[3])
                        {
                            numnum = random.Next(0, 19);
                            name2 = name_female[numnum];
                        }
                        else
                        {
                            name = name2;
                            hero_name[4] = name;
                        }
                    }
                }

                }
            }
        

            
        

        ///<this is the start of the randomize button. when you click it, it will call the gender one.
        /// once it calls the gender it will call the hero one. 
        /// after it calls the hero one, it calls the name.
        private void GenRan_Click(object sender, RoutedEventArgs e)
        {
            ///<does this before it does everything else.

            

            this.Gender();
            this.Herocharacter();
            this.HeroNames();
            placeCharacter();
        }
        public  void placeCharacter()
        {
            Character[] characters = new Character[5];
            for (int i = 0; i < 5; i++)
            {
                switch(heroType[i])
                {
                    case 0 :
                        {
                            characters[i] = new Character();
                            characters[i].Gender = gender[i];                         
                            characters[i].Herocharacter = hero_type[i];
                            characters[i].Name = hero_name[i];
                            Hero1class.Content = characters[i].Herocharacter;

                            Hero1name.Content = characters[i].Name;
                            
                           
                            break;
                        }
                    case 1 :
                        {
                            characters[i] = new Character();
                            characters[i].Gender = gender[i];
                            characters[i].Herocharacter = hero_type[i];
                            characters[i].Name = hero_name[i];

                            Hero2class.Content = characters[i].Herocharacter;
                            
                           
                            Hero2name.Content = characters[i].Name;
                            
                           
                            break;
                        }
                    case 2 :
                        {
                            characters[i] = new Character();
                            characters[i].Gender = gender[i];
                            characters[i].Herocharacter = hero_type[i];
                            characters[i].Name = hero_name[i];
                            Hero3class.Content = characters[i].Herocharacter;

                            Hero3name.Content = characters[i].Name;
                                                       
                            break;
                        }
                    case 3 :
                        {
                            characters[i] = new Character();
                            characters[i].Gender = gender[i];
                            characters[i].Herocharacter = hero_type[i];
                            characters[i].Name = hero_name[i];

                            Hero4class.Content = characters[i].Herocharacter;

                            Hero4name.Content = characters[i].Name;
                            
                           
                            break;
                        }
                    case 4 :
                        {
                            characters[i] = new Character();
                            characters[i].Gender = gender[i];
                            characters[i].Herocharacter = hero_type[i];
                            characters[i].Name = hero_name[i];
                            
                            Hero5class.Content = characters[i].Herocharacter;

                            Hero5name.Content = characters[i].Name;
                          
                            break;
                        }
                  
                    default:
                            {
                                /*
                                characters[i] = new Character();
                                characters[i] .Gender = gender[i];
                                characters[i].Herocharacter = hero_type[i];
                                characters[i].Name = hero_name[i];
                                Hero1class.Content = hero_type[0];
                                Hero2class.Content = hero_type[1];
                                Hero3class.Content = hero_type[2];
                                Hero4class.Content = hero_type[3];
                                Hero5class.Content = hero_type[4];
                                Hero1name.Content = hero_name[0];
                                Hero2name.Content = hero_name[1];
                                Hero3name.Content = hero_name[2];
                                Hero4name.Content = hero_name[3];
                                Hero5name.Content = hero_name[4];
                          */
                                break;
                            }
                       
                }
                /*
               MessageBox.Show("this is gender in index " + i +" "+ gender[i].ToString());
               MessageBox.Show("this is character in index " + i +" "+characters[i].Gender.ToString());

                //!!!!!!!!!! can't figure out where this null pointer exception is coming from. Help would be appreciated
               MessageBox.Show("this name is in index " + i + " " + characters[i].Name.ToString());
               MessageBox.Show("this is in index " + i + " " + characters[i].ToString());
               MessageBox.Show("this is hero class in index" + " " + characters[i].Herocharacter.ToString()); */
            }

        }

        /// <this is what will happen if you dont want to randomize the heros.
        /// it is supposed to make the buttons and text boxes below the hero visible.
        /// once they are visible i want to make them clickable.
        /// from there the person will be able to do their choices.
     

      




      

        private void getName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        // here are the five hero images and what happens when you click them
        private void Hero1_Click(object sender, RoutedEventArgs e)
        {

            hero1WasClicked = true;
            IndividualHeros ih = new IndividualHeros(this);
            ih.ShowDialog();

        }

        private void Hero2_Click_1(object sender, RoutedEventArgs e)       
            {

                hero2WasClicked = true;
                IndividualHeros ih = new IndividualHeros(this);
                ih.ShowDialog();
            }
        

        private void Hero3_Click_1(object sender, RoutedEventArgs e)
        {

            hero3WasClicked = true;
            IndividualHeros ih = new IndividualHeros(this);
            ih.ShowDialog();
            
        }

        private void Hero4_Click(object sender, RoutedEventArgs e)
        {

            hero4WasClicked = true;
            IndividualHeros ih = new IndividualHeros(this);
            ih.ShowDialog();
        }


        private void Hero5_Click(object sender, RoutedEventArgs e)
        {

            hero5WasClicked = true;
            IndividualHeros ih = new IndividualHeros(this);
            ih.ShowDialog();
           
        }


 

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            
        }

       

       
    }
}

