using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GameBoard
{
    class Hero : Character
    {

        public Hero()
        {
            row = 0;
            col = 0;
            characterPicture = new BitmapImage(new Uri("hero.png", UriKind.Relative));
        }

        public Hero(int r, int c, int charspeed)
        {
            row = r;
            col = c;
            hp = 10;
            moveSpeed = charspeed;
            characterPicture = new BitmapImage(new Uri("hero.png", UriKind.Relative));
        }
    }
}

