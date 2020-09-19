using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace ConsoleApplication1
{
    public partial  class Section 
    {
        private int life;
        private int state;
        private int job;
        private int arrow;
        private Image image;
        public int Life
        {
            get { return life; }
            set { life = value; }
        }
        public int Arrow
        {
            get { return arrow; }
            set { arrow = value; }
        }
        public int State
        {
            get { return state; }
            set { state = value; }
        }
        public int Job
        {
            get { return job; }
            set { arrow = value; }
        }
        public Image Image
        {
            get { return image; }
            set { image = value; }
        }
    }
}
