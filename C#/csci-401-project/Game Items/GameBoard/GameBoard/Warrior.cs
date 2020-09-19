using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBoard
{
    class Warrior : Hero
    {
        public Warrior(int r, int c, int charSpeed)
        {
            row = r;
            col = c;
            hp = 10;
            moveSpeed = charSpeed;
        }
    }
}