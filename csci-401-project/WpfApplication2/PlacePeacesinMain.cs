using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleApplication1;
namespace WpfApplication2
{
    public partial class MainWindow 
    {
        public void placePeaces()
        {
            for (i = 0; i < 12; i++)
                for (j = 0; j < 12; j++)
                {
                    switch (table[i, j])
                    {

                        case 1: play2[i, j] = new Enemy();
                            play[i, j].BackgroundImage = play2[i, j].Image;

                            break;



                        case 2: 
                                
                                break;
                   



                        case 3: play2[i, j] = new Hero(table[i, j]);
                                play[i, j].BackgroundImage = play2[i, j].Image;
                            break;
                        case 4: play2[i, j] = new Hero(table[i, j]);
                                play[i, j].BackgroundImage = play2[i, j].Image;
                            break;
                        case 5: play2[i,j] = new Hero(table[i,j]);
                            play[i, j].BackgroundImage = play2[i, j].Image;
                            break;
                        default: break;
                    }
                }
        }
    }
}
