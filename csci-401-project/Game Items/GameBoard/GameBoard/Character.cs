using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBoard
{
    public  class Character : Tile
    {
        private int health;
        private int attack = 10;
        private int moveSpeed;
        private Boolean canMoveOnTurn = false;
        Character aCharacter;
        public Character(int movespeed,int row,int col):base(movespeed,row,col)
        {
            health = 10;
        }
        public override Character tileCharacter
        {
            get { return aCharacter;}
            set { aCharacter = value;}

         }
        public int hp
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
            }
        }

        public int speed
        {
            get
            {
                return moveSpeed;
            }
            set
            {
                moveSpeed = value;
            }
        }

        public Boolean hasMoved
        {
            get
            {
                return canMoveOnTurn;
            }
            set
            {
                canMoveOnTurn = value;
            }
        }

        public Character()
        {
            health = 10;
        }
        public virtual int Attack
        {
            get { return attack; }
            set { attack = value; }
        }

    }
}
