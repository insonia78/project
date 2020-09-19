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
            characterPicture = new BitmapImage(new Uri("hero.png", UriKind.Relative));
        }

        public Hero(int r, int c, int charspeed) : base(r ,c, charspeed)
        {
            characterPicture = new BitmapImage(new Uri("hero.png", UriKind.Relative));
        }
    }
}

