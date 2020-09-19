using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GameBoard
{
    class Enemy_Warrior : Enemy
    {
        public Enemy_Warrior (int r, int c, int charSpeed)
        {
            row = r;
            col = c;
            hp = 1;
            moveSpeed = charSpeed;
            characterPicture = new BitmapImage(new Uri("Campus Police.png", UriKind.Relative));
        }
    }
}
