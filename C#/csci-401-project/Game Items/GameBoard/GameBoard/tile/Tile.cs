using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
namespace GameBoard
{
    public partial class Tile : System.Windows.Controls.Button 
    {
        private int numRows;
        private int row;
        private int col;
        private int speed;
        private int numCols;
        private ImageBrush image;
        private Brush background;
        private Boolean canMoveTo;
        private readonly int terrainType;  //0 for field, 1 for mountain, 2 for water, ...

        public Tile()  //"blank" tile, default is grass, no character on it
        {
            canMoveTo = false;
            terrainType = 0;
            aCharacter = null;
        }

        public Tile(int movespeed,int r, int c)
        {
            speed = movespeed;
            numRows = r;
            numCols = c;
            row = r;
            col = c;
            canMoveTo = false;
           aCharacter = null;
        }
        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        
        public  virtual int Col
        {
            get { return numCols; }
            set { numCols = value; }
        }
        public virtual int Row
        {
            get { return numRows; }
            set { numRows = value; }
        }
        
        public int tileTerrain
        {
            get
            {
                return terrainType;
            }
            set { }
        }
        private Character aCharacter;
        public virtual Character tileCharacter
        {
            get
            {
                return aCharacter;
            }
            set
            {
                aCharacter = value;
            }
        }
        public Boolean isMoveOption
        {
            get
            {
                return canMoveTo;
            }
            set
            {
                canMoveTo = value;
            }
        }
        public  virtual ImageBrush Image
        {
              get{return null;}
              set { image = value;}
        }
        public virtual int Attack
        {
            get { return 0 ; }
            set { ; }
        }
        
        
       
        
        
        
        
        
    }
}
