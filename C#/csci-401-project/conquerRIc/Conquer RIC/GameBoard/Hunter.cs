﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBoard
{
    class Hunter : Hero
    {
        public Hunter(int r, int c, int charSpeed) : base(r, c, charSpeed)
        {
            row = r;
            col = c;
            hp = 10;
            moveSpeed = charSpeed;
        }
    }
}
