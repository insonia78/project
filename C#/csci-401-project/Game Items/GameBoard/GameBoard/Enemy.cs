using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBoard
{
    class Enemy : Character
    {
        private int health;

        public Enemy()
        {
            hp = 1;
        }

        public Enemy (int movespeed, int row, int col):base(movespeed,row,col)
        {
            hp = 1; 
            speed = movespeed;
        }
    }
}
