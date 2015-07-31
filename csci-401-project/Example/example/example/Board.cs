using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ConsoleApplication1
{
    public class Board 
    {
        //public Board(){}

        public virtual int Arrow { get; set; }
        public virtual int State { get; set; }
        public virtual int Job { get; set; }
        public virtual Image Image { get; set; }
        public virtual int Row { get; set; }
        public virtual int Col { get; set; }        
        public virtual int Life { get; set; }
        public virtual Image getImage(int a) { return null; }
        public virtual bool setTerrain(Board a, int b) { return false; }
        
         
    }
}
