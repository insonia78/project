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
namespace ConsoleApplication1
{
    public class Hero : Board
    {
         private int life;
         private int state;
         private int job;
         private int arrow;
         private System.Drawing.Image image;
         private ImageSource image1;
         private int play;
         public Hero()
         {
             image = System.Drawing.Image.FromFile("Image\\hero.png");
         }
        public Hero(int type)
        {
            switch (type)
            {
                case 3: 

                          image = System.Drawing.Image.FromFile("Image\\hero.png"); 
                         life = 5;
                         
                         life = 10;
                         state = 20;
                         job = 20;
                         arrow = 40;  
                    break;
                case 4:  image = System.Drawing.Image.FromFile("Image\\hero4.png"); 
                         life = 5;
                         state = 23;
                         job = 15;
                         arrow = 35;
                         break;
                case 5:
                         image = System.Drawing.Image.FromFile("Image\\terrein.jpg");
                         break;
                default: break; 
            }

        }
        
        public override  int Life
        {
            get { return life; }
            set { life = value; }
        }
        public override int Arrow
        {
            get { return arrow; }
            set { arrow = value; }
        }
        public override int State
        {
            get { return state; }
            set { state = value; }
        }
        public  override int Job
        {
            get { return job; }
            set { arrow = value; }
        }
        public override System.Drawing.Image Image
        {
            get { return image; }
            set { image = value; }
        }
        public ImageSource Image1
        {
            get{return image1;}
            set{image1= value;}
        }
        public override int play2
        {
            get
            {
                return play;
            }
            set
            {
               play = value;
            }
        }
        
    }
}
