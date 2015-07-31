using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Enemy : Board
    {
        int value;
        public Enemy()
        {
            value = 5 ;
        }
        public int getNumber()
        {
            return value;
        }
        public void setValue(int i)
        {
            this.value = i;
        }
    }
}
