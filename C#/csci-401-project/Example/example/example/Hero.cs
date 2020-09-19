using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace ConsoleApplication1
{
    public class Hero : Board
    {
         private int life;
         private int state;
         private int job;
         private int arrow;
         private Image image;
        public Hero()
        {
            life = 10;
            state = 20;
            job = 20;
            arrow = 40;
            image = System.Drawing.Image.FromFile("Image\\hero.png");
        }
        
        public override int Life
        {
            get { return life; }
            set { life = value; }
        }
        public override int Arrow
        {
            get { return arrow; }
            set { arrow = value; }
        }
        public override int State
        {
            get { return state; }
            set { state = value; }
        }
        public override int Job
        {
            get { return job; }
            set { arrow = value; }
        }
        public override Image Image
        {
            get { return image; }
            set { image = value; }
        }
        
    }
}
