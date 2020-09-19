using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBoard
{
    public partial class Tile
    {
        public void enemyTurn()
        {
            for (int r = 0; r < numRows; r++)
            {
                for (int c = 0; c < numCols; c++)
                {
                    if (this.containsCharacter() == true && this.tileCharacter.GetType() == typeof(GameBoard.Enemy) && this.tileCharacter.hasMoved == false)
                    {
                        this.tileCharacter.hasMoved = true;
                        enemyMoveAI(r, c);
                    }
                }
            }
            for (int r = 0; r < numRows; r++)
            {
                for (int c = 0; c < numCols; c++)
                {
                    if (this.containsCharacter() == true && this.tileCharacter.GetType() == typeof(GameBoard.Enemy))
                    {
                        this.tileCharacter.hasMoved = false;
                    }
                }
            }
        }
        public void enemyMoveAI(int row, int col)
        {
            Random rng = new Random();
            int deltaRow = 1 - rng.Next(0, 3);
            int deltaCol = 1 - rng.Next(0, 3);
           // moveCharacter(row, col, row + deltaRow, col + deltaCol);
            //teleportation occurs in the enemyTurn() method if it moves to a spot the method hasnt looped to yet
            //could create an array, store enemies in that array in the loops, then move each
        }
    }
}
