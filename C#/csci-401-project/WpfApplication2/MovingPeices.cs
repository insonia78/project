using System;
using System.Windows;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication2
{
    public partial class MainWindow
    {
        private static Timer aTimer;
        private int[] rows = new int[12];
        private int[] columns = new int[12];
      private static int x ,t;
        int ro, ca, m,l;
     //  
        public void Move()
        {
             x = z;t = y;
             m = z; l = y;
            PlotRoot();
            ro = z;
            ca = y;
            aTimer = new Timer(4);
            aTimer.Elapsed += timer_Tick;
            aTimer.Interval = 3;
            int AnimationStart = 6;
            int AnimationStop = -AnimationStart;
            int AnimationCounter = AnimationStop;

            aTimer.Start();
            



           
        }
           
        public void PlotRoot()
        {
            if (i >= z)
            {
                if (j >= y)
                {
                    for ( r = z; r <= i; r++)
                    {
                        for (c = y; c <= j; c++)
                        {
                            if (table[r, c] == 0)
                            {
                                rows[r] = r;
                                columns[c] = c;
                            }

                        }
                    }

                }
                else
                {

                }
            }
            else
            {
                if (y >= j)
                {
                }
                else
                {
                }
            }
            for (int r = z; r <= i; r++)
            {
                for (int c = y; c <= j; c++)
                {


                }
            }

        }
        private void timer_Tick(object sender, EventArgs e)
        {
            while (aTimer.Enabled == true)
            {
                if (x == i && t == j)
                {
                    
                    table[i, j] = table[z, y];
                    table[z, y] = 0;
                    play2[i, j] = play2[z, y];
                    play[z, y].BackgroundImage = null;
                    aTimer.Stop();
                }
                else
                {
                    if (ro < i)
                    {
                        x = rows[ro];
                    }
                    if (ca < j)
                    {
                        t = columns[ca];
                    }
                    play[x, t].BackgroundImage = play[m, l].BackgroundImage;
                    play[m, l].BackgroundImage = null;
                    m = x;
                    l = t;
                    ro++;
                    ca++;
                }

            }
        }
            
        }
    }


