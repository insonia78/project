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

namespace GameBoard
{
    class Mage : Enemy
    {
        ImageBrush image = new ImageBrush();
        private int numCols;
        private int numRows;
        private int attack;
        public Mage ()
        {
            
            image.ImageSource =
            new BitmapImage(new Uri("hero.png", UriKind.Relative));
            hp = 10;
            attack = 4;
          //  speed = movespeed;
        }
        public override int Col
        {
            get { return numCols; }
            set { numCols = value; }
        }
        public override int Row
        {
            get { return numRows; }
            set { numRows = value; }
        }
        public override ImageBrush Image
        {
            get { return image; }
            set { image = value;}
        }
        public override int Attack
        {
            get
            {
                return attack;
            }
            set
            {
                attack = value;
            }
        } 


    }
}
