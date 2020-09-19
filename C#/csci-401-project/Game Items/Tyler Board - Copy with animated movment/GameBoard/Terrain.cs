using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GameBoard
{
    public class Terrain
    {
        private ImageSource tileImage;
        
        //accessors/mutators

        public ImageSource terrainImage
        {
            get
            {
                return tileImage;
            }
            set { }
        }
        public Terrain()
        {

        }

        /*
         * Possibly temporary/test constructor for making a terrain object with a designated image depending on the number input from a file.
         */
        public Terrain(int tileType):this()
        {
            switch (tileType)
            {
                case 0: //for grass
                    tileImage = new BitmapImage(new Uri("grass.png", UriKind.Relative));
                    break;
                case 1: //for mountain
                    tileImage = new BitmapImage(new Uri("mountain.png", UriKind.Relative));
                    break;
                case 2: //for water
                    tileImage = new BitmapImage(new Uri("water.png", UriKind.Relative));
                    break;
                case 3: //for swamp
                    tileImage = new BitmapImage(new Uri("swamp.png", UriKind.Relative));
                    break;
                default:
                    tileImage = new BitmapImage(new Uri("grass.png", UriKind.Relative));
                    break;
            }
        }
    }
}
