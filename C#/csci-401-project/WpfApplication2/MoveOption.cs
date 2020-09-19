using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using ConsoleApplication1;
namespace WpfApplication2
{
    public partial class MainWindow 
    {               
         bool go = false;
         bool go1 = false;
         int c, r;


        // Color structures. One is a variable used for temporary storage. The other 
        // is a constant used for comparisons.
         public void moveOption(int i, int j)
         {


             try
             {
                 c = j;
                 r = i;
                 // Color structures. One is a variable used for temporary storage. The other 
                 // is a constant used for comparisons.
                 c -= 2;
                 // high 
                 while (go == false)
                 {
                     if (c == j) 
                     {
                     }
                     else if (table[r, c] == 0  && c != (j + 2) &&  c != (j-2))
                     {
                         play[r, c].BackColor = ControlPaint.Light(play[i, j].BackColor);
                     }
                     else if ( c == (j+2))
                     {      
                         if(table[r,c-1] == 0)
                         {
                             play[r, c].BackColor = ControlPaint.Light(play[i, j].BackColor);
                              go = true;
                              go1 = true;
                         }
                         else
                         {
                              go = true;
                             go1 = true;
                         }
                     }
                     else if (c == (j - 2))
                     {
                         if (table[r, c + 1] == 0)
                         {
                             play[r, c].BackColor = ControlPaint.Light(play[i, j].BackColor);

                         }
                         else
                         {
                         }

                     }
                     c++;
                 }

                 go = false;
                 c = j;
                 c -= 1;
                 r += 1;

                 while (go1 == true)
                 {

                     if (table[r, c] == 0 && c != j+1 && c !=j-1)
                     {
                         
                         
                             play[r, c].BackColor = ControlPaint.Light(play[i, j].BackColor);
                                              
                     }
                     if(c == j+1)
                     {
                         if(table[r-1,c] != 0 && table[r,c-1] != 0)
                         {
                             go1 = false;
                             
                         }
                         else
                         {
                             play[r, c].BackColor = ControlPaint.Light(play[i, j].BackColor);
                             go1 = false;
                         }
                     }
                     if (c == j - 1)
                     {
                         if (table[r-1, c] != 0 && table[r,c+1] != 0)
                         {
                         }
                         else
                         {
                             play[r, c].BackColor = ControlPaint.Light(play[i, j].BackColor);
                         }

                     }

                     c++;
                 }
                 go1 = true;
                 c = j;
                 r += 1;
                 if (table[r, c] == 0 && table[r-1,c] == 0)
                 {
                     play[r, c].BackColor = ControlPaint.Light(play[i, j].BackColor);
                 }
                 //low 
                 r = i;
                 c = j;
                 c -= 1;
                 r -= 1;

                 while (go1 == true)
                 {
                     if (table[r, c] == 0 && c != j + 1 && c != j - 1)
                     {


                         play[r, c].BackColor = ControlPaint.Light(play[i, j].BackColor);

                     }
                     if (c == j + 1)
                     {
                         if (table[r + 1, c] != 0 && table[r, c - 1] != 0)
                         {
                             go1 = false;

                         }
                         else
                         {
                             play[r, c].BackColor = ControlPaint.Light(play[i, j].BackColor);
                             go1 = false;
                         }
                     }
                     if (c == j - 1)
                     {
                         if (table[r + 1, c] != 0 && table[r, c + 1] != 0)
                         {
                         }
                         else
                         {
                             play[r, c].BackColor = ControlPaint.Light(play[i, j].BackColor);
                         }

                     }

                     c++;
                 }
                 go1 = true;
                 c = j;
                 r -= 1;
                 if (table[r, c] == 0 && table[r+1,c] == 0)
                 {
                     play[r, c].BackColor = ControlPaint.Light(play[i, j].BackColor);
                 }
 
             }
             catch (NullReferenceException e)
             {
             }
             catch (IndexOutOfRangeException e)
             {

             }
            
         }
                    
    }
}
