using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBoard
{
    public partial class Tile
    {
        public void clearMoveOptions()
        {
            for (int r = 0; r < numRows; r++)
            {
                for (int c = 0; c < numCols; c++)
                {
                    this.isMoveOption = false;
                }
            }
        }
    }
}
