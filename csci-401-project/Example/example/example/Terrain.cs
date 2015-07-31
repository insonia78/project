using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace ConsoleApplication1
{
    public class Terrain: Board
    {
        Image image;
        public Terrain()
        {                     
            
        }
        
        public override Image getImage(int type)
        {
            switch(type)
            {
                case 2:image = System.Drawing.Image.FromFile("Image\\terrein.jpg");break;
            }        
            return image;
            
        }
        public override bool setTerrain(Board hero, int table)
        {
            bool validate = false;
            switch (table)
            {

                case 1: new House().Show();
                         validate = true; break;
                case 2: new House().Show();
                         validate = true; break;
            }
            return validate;

        }
    }
}
