using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ConsoleApplication1
{
    public class Enemy : Board
    {
       private int life;
       private int state;
       private int job;
       private int arrow;
       private Image image;
       private int row;
       private int col;
        public Enemy()
        {
            life = 10;
            state = 20;
            job = 20;
            arrow = 40;
            image = System.Drawing.Image.FromFile("Image\\enemy.jpg");
        }
        public Enemy(int i, int j)
        {
            row = 1;
            col = 1;

            life = 10;
            state = 20;
            job = 20;
            arrow = 40;
            image = System.Drawing.Image.FromFile("Image\\enemy.jpg");

        }
        public override int Row
        {
            get { return row; }
            set{row = value;}
        }
        public override int Col
        {
            get { return col; }
            set { col = value; }
        }
        public override int Life
        {
            get { return life; }
            set { life = value; }
        }
        public override int Arrow
        {
            get { return arrow;}
            set { arrow = value;}
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
