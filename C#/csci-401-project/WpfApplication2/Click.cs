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
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Drawing;
using ConsoleApplication1;
using Accessibility;
namespace WpfApplication2
{
    public partial class MainWindow
    {
        Hero hero = new Hero();
        
        private void Tyle_Click(object sender, EventArgs e)
        {
            
           
            upDateTable();
            try
            {
                i = (sender as Tyle).Row;
                j = (sender as Tyle).Col;
                
                
            }
            catch (NullReferenceException ex)
            {


            }
          
            if (validate == true && 0 != table[i,j] )
            {
                moveOption(i, j);
                Click = true;
                z = i;
                y = j;
                validate = false;
                menu.IsEnabled = true;
                //menu.IsFocused = true;
                menu.Background = new SolidColorBrush(Colors.Red);
               // Image.Source = new BitmapImage(new Uri("hero.jpg"));
                 
            }
            else
            {

                if (validateMove(i,j,z,y) == false)
                {
                    
                    ResetBackColor();

                }
                else
                {
                    
                    if (table[i, j] != 0 && table[z, y] == 1)
                    {
                        switch (table[i, j])
                        {
                            case 2: new Batle(play2[i, j], play2[z, y]).Show(); break;
                            case 3: new Batle(play2[i, j], play2[z, y]).Show(); break;
                        }
                    }
                    if (table[i, j] != 0 && table[z, y] == 2 || table[z, y] == 4)
                    {
                        switch (table[i, j])
                        {
                            case 1: new Batle(play2[i, j], play2[z, y]).Show(); break;
                            case 3: new Batle(play2[i, j], play2[z, y]).Show(); break;
                        }
                    }
                    if (table[i, j] != 0 && table[z, y] == 3)
                    {
                        switch (table[i, j])
                        {
                            case 2: new Batle(play2[i, j], play2[z, y]).Show(); break;
                            case 1: new Batle(play2[i, j], play2[z, y]).Show(); break;
                        }
                    }
                    play[i, j].BackgroundImage = play[z, y].BackgroundImage;
                    table[i, j] = table[z, y];
                    table[z, y] = 0;
                    play2[i, j] = play2[z, y];
                    play[z, y].BackgroundImage = null;

 
                    ResetBackColor();
                    upDateTable();
 
                    menu.IsEnabled = false;
                    menu.Background = new SolidColorBrush(Colors.Blue);

                }
                validate = true;
            }
        }
            public void ResetBackColor()
            {
                for(i = 0; i < 12 ;i++)
                {   
                    for(j=0;j < 12 ;j++)
                    {
                        
                            play[i, j].Click -= Tyle_Click;
                            play[i, j].BackColor = System.Drawing.Color.Green;
                            play[i, j].Click += Tyle_Click;
                    }
                }

            }
            public void upDateTable()
            {
                for (i = 0; i < 12; i++)
                {
                    for (j = 0; j < 12; j++)
                    {

                        
                                           }
                }
            }
            public bool validateMove(int i,int j, int z, int y)
            {
                bool validate = true;
                
                

                if (table[i, j] == table[z, y])
                {
                   
                    validate = false;
                }
                else if (i == z && j >= (y - 2) && j <= (y + 2))
                {
                    
                    
                    
                    if (table[i, j] == 0 && j != (y + 2) && j != (y - 2))
                    {
                     
                    }
                    else if (j == (y + 2))
                    {
                        if (table[i, j - 1] == 0)
                        {
                            
                        }
                        else
                        {
                            validate = false;
                        }
                    }
                    else if (j == (y - 2))
                    {
                        if (table[i, j + 1] == 0)
                        {
                            

                        }
                        else
                        {
                            validate = false;
                        }

                    }
                  
                                        
                }
                else if (i == (z + 1) &&(j >= (y - 1)) && (j <= (y + 1)))
                {
                    if (table[i, j] == 0 && j != y + 1 && j != y - 1)
                    {                        

                    }
                    if (j == y + 1)
                    {
                        if (table[i - 1, j] != 0 && table[i, j - 1] != 0)
                        {
                            validate = false;

                        }
                        else
                        {
                           
                        }
                    }
                    if (j == y - 1)
                    {
                        if (table[i - 1, j] != 0 && table[i, j + 1] != 0)
                        {
                            validate = false;
                        }
                        else
                        {
                            
                        }

                    }

                }
                else if (i == (z - 1) && j >= (y - 1) && j <= (y + 1))
                {
                    if (table[i, j] == 0 && j != y + 1 && j != y - 1)
                    {
                    }
                    if (j == y + 1)
                    {
                        if (table[i + 1, j] != 0 && table[i, j - 1] != 0)
                        {
                            validate = false;

                        }
                        else
                        {
                            
                        }
                    }
                    if (j == i - 1)
                    {
                        if (table[i + 1, y] != 0 && table[i, y + 1] != 0)
                        {
                            validate = false;
                        }
                        else
                        {
                            
                        }

                    }

                }
                else  if ((i == (z + 2)) && (j == y))
                {
                    if (table[i, j] == 0 && table[i - 1, j] == 0)
                    {

                    }
                    else
                    {
                        validate = false;
                    }

                }
                else if ((i == (z - 2)) && (j == y))
                {
                    if (table[i, j] == 0 && table[i + 1, j] == 0)
                    {

                    }
                    else
                    {
                        validate = false;
                    }

                }
                else
                {
                    validate = false;
                }
                return validate;
            }

        }
    }

