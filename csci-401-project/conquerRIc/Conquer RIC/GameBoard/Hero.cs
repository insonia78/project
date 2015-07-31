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

        public override Tile[,] Attack1(Tile[,] boardspaces, int numRows, int numCols)
        {
            //TEST ATTACK ONLY, will probably be removed later
            //up
            this.selectedAttackPower = 1.0;

            if(row - 1 >= 0 && !boardspaces[row -1, col].isUnpassable)
            {
                boardspaces[row - 1, col].attackOption = 1;
                if(row - 2 >= 0 && !boardspaces[row - 2, col].isUnpassable)
                {
                    boardspaces[row - 2, col].attackOption = 1;
                    if (col - 1 >= 0 && !boardspaces[row - 2, col - 1].isUnpassable)
                        boardspaces[row - 2, col - 1].attackOption = 1;
                    if (col + 1 >= 0 && !boardspaces[row - 2, col + 1].isUnpassable)
                        boardspaces[row - 2, col + 1].attackOption = 1;
                }
            }
            //down
            if (row + 1 < numRows && !boardspaces[row + 1, col].isUnpassable)
            {
                boardspaces[row + 1, col].attackOption = 4;
                if (row + 2 < numRows && !boardspaces[row + 2, col].isUnpassable)
                {
                    boardspaces[row + 2, col].attackOption = 4;
                    if (col - 1 >= 0 && !boardspaces[row + 2, col - 1].isUnpassable)
                        boardspaces[row + 2, col - 1].attackOption = 4;
                    if (col + 1 < numCols && !boardspaces[row + 2, col + 1].isUnpassable)
                        boardspaces[row + 2, col + 1].attackOption = 4;
                }
            }
            //left
            if (col - 1 >= 0 && !boardspaces[row, col - 1].isUnpassable)
            {
                boardspaces[row, col - 1].attackOption = 2;
                if (col - 2 >= 0 && !boardspaces[row, col - 2].isUnpassable)
                {
                    boardspaces[row, col - 2].attackOption = 2;
                    if (row - 1 >= 0 && !boardspaces[row -1, col - 2].isUnpassable)
                        boardspaces[row -1, col - 2].attackOption = 2;
                    if (row + 1 < numCols && !boardspaces[row + 1, col -2].isUnpassable)
                        boardspaces[row + 1, col -2].attackOption = 2;
                }
            }
            //right
            if (col + 1 >= 0 && !boardspaces[row, col + 1].isUnpassable)
            {
                boardspaces[row, col + 1].attackOption = 3;
                if (col + 2 >= 0 && !boardspaces[row, col + 2].isUnpassable)
                {
                    boardspaces[row, col + 2].attackOption = 3;
                    if (row - 1 >= 0 && !boardspaces[row - 1, col + 2].isUnpassable)
                        boardspaces[row - 1, col + 2].attackOption = 3;
                    if (row + 1 < numCols && !boardspaces[row - 1, col + 2].isUnpassable)
                        boardspaces[row + 1, col + 2].attackOption = 3;
                }
            }

            return boardspaces;
        }
    }
}

