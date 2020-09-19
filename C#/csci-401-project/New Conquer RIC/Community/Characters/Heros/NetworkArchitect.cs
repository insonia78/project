using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Collections;

namespace Community
{
    public class NetworkArchitect : Hero
    {
        public NetworkArchitect(String nam, bool sex)
        {
            Init(nam, sex);
        }

        // Second constructor.
        public NetworkArchitect(int r, int c) : base(r, c)
        {
            Init(null, true);
            Row = r;
            Col = c;
        }

        private void Init(String n, bool s)
        {
            Name = n;
            Male = s;
            JobRole = "Network Architect";

            // Picture will be generated depending on the sex.
            if(Male)
            {
                PortraitFile = "MaleNetworkArchitect.png";
                PictureFile = "Heroes/Network_Architecture_MALE.png";
            }
            else
            {
                PortraitFile = "FemaleNetworkArchitect.png";
                PictureFile = "Heroes/Network_Architecture_FEMALE.png";
            }
            CharacterPicture = new BitmapImage(new Uri(PictureFile, UriKind.Relative));
            CharacterPortrait = new BitmapImage(new Uri(PortraitFile, UriKind.Relative));

            statEffects = new List<Effect>();

            /******************************************************************
             * stat progression unique to this job role.
             * ****************************************************************
             */
            HealthMulti = 1.75;
            EnergyMulti = 1.50;
            AttackMulti = 3.00;
            DefenseMulti = 2;
            SpeedMulti = 1.25;
            AgilityMulti = 3;
            AttackRangeMulti = 3.00;
            SpecialAttackMulti = 2.00;
            SpecialDefenseMulti = 1.50;

            /******************************************************************
             * stats initialized after multipliers applied.
             * ****************************************************************
             */
            InstantiateLevel(1);
        }

        public override int[,] Ability1(int[,] boardspaces)
        {
            this.selectedAttackPower = 1;
            this.isSelectedAttackTypeSpecial = false;

            //up
            if (row - 4 >= 0 && boardspaces[row - 4, col] == 0)
            {
                boardspaces[row - 4, col] = 1;
            }
            //down
            if (row + 4 < boardspaces.GetLength(0) && boardspaces[row + 4, col] == 0)
            {
                boardspaces[row + 4, col] = 2;
            }
            //left
            if (col - 4 >= 0 && boardspaces[row, col - 4] == 0)
            {
                boardspaces[row, col - 4] = 3;
            }
            //right
            if (col + 4 < boardspaces.GetLength(1) && boardspaces[row, col + 4] == 0)
            {
                boardspaces[row, col + 4] = 4;
            }
            return boardspaces;
        }

        public override int[,] Ability2(int[,] boardspaces)
        {
            this.selectedAttackPower = 0.2;
            this.isSelectedAttackTypeSpecial = false;

            int i = 1;
            //up
            while(row - i >= 0 && boardspaces[row - i, col] == 0)
            {
                boardspaces[row - i, col] = 1;
                i++;
            }
            i = 1;
            //down
            while (row + i < boardspaces.GetLength(0) && boardspaces[row + i, col] == 0)
            {
                boardspaces[row + i, col] = 2;
                i++;
            }
            i = 1;
            //left
            while (col - i >= 0 && boardspaces[row, col - i] == 0)
            {
                boardspaces[row, col - i] = 3;
                i++;
            }
            i = 1;
            //right
            while (col + i < boardspaces.GetLength(1) && boardspaces[row, col + i] == 0)
            {
                boardspaces[row, col + i] = 4;
                i++;
            }
            return boardspaces;
        }

        public override int[,] Ability3(int[,] boardspaces)
        {
            this.selectedAttackPower = 1;
            this.isSelectedAttackTypeSpecial = true;

            //makes a circle that can go throught walls, radius 3
            //up three spaces, and the two up corners
            if(row - 3 >= 0 && boardspaces[row - 3, col] == 0)
            {
                boardspaces[row - 3, col] = 1;
            }
            if (row - 3 >= 0 && col - 1 >= 0 && boardspaces[row - 3, col - 1] == 0)
            {
                boardspaces[row - 3, col- 1] = 1;
            }
            if (row - 3 >= 0 && col + 1 < boardspaces.GetLength(1) && boardspaces[row - 3, col + 1] == 0)
            {
                boardspaces[row - 3, col + 1] = 1;
            }
            if (row - 2 >= 0 && col - 2 >= 0 && boardspaces[row - 2, col - 2] == 0)
            {
                boardspaces[row - 2, col - 2] = 1;
            }
            if (row - 2 >= 0 && col + 2 < boardspaces.GetLength(1) && boardspaces[row - 2, col + 2] == 0)
            {
                boardspaces[row - 2, col + 2] = 1;
            }
            //down three and the two down corners
            if(row + 3 < boardspaces.GetLength(0) && boardspaces[row + 3, col] == 0)
            {
                boardspaces[row + 3, col] = 1;
            }
            if (row + 3 < boardspaces.GetLength(0) && col - 1 >= 0 && boardspaces[row + 3, col - 1] == 0)
            {
                boardspaces[row + 3, col - 1] = 1;
            }
            if (row + 3 < boardspaces.GetLength(0) && col + 1 < boardspaces.GetLength(1) && boardspaces[row + 3, col + 1] == 0)
            {
                boardspaces[row + 3, col + 1] = 1;
            }
            if (row + 2 < boardspaces.GetLength(0) && col - 2 >= 0 && boardspaces[row + 2, col - 2] == 0)
            {
                boardspaces[row + 2, col - 2] = 1;
            }
            if (row + 2 < boardspaces.GetLength(0) && col + 2 < boardspaces.GetLength(1) && boardspaces[row + 2, col + 2] == 0)
            {
                boardspaces[row + 2, col + 2] = 1;
            }

            //left 3
            if (col - 3 >= 0 && boardspaces[row, col - 3] == 0)
            {
                boardspaces[row, col - 3] = 1;
            }
            if (col - 3 >= 0 && row - 1 >= 0 && boardspaces[row - 1, col - 3] == 0)
            {
                boardspaces[row - 1, col - 3] = 1;
            }
            if (col - 3 >= 0 && row + 1 < boardspaces.GetLength(0) && boardspaces[row + 1, col - 3] == 0)
            {
                boardspaces[row + 1, col - 3] = 1;
            }

            //right 3
            if (col + 3 < boardspaces.GetLength(1) && boardspaces[row, col + 3] == 0)
            {
                boardspaces[row, col + 3] = 1;
            }
            if (col + 3 < boardspaces.GetLength(1) && row - 1 >= 0 && boardspaces[row - 1, col + 3] == 0)
            {
                boardspaces[row - 1, col + 3] = 1;
            }
            if (col + 3 < boardspaces.GetLength(1) && row + 1 < boardspaces.GetLength(0) && boardspaces[row + 1, col + 3] == 0)
            {
                boardspaces[row + 1, col + 3] = 1;
            }
            return boardspaces;
        }
    }
}