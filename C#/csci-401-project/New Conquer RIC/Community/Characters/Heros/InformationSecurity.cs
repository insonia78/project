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
    public class InformationSecurity : Hero
    {
        public InformationSecurity(String nam, bool sex)
        {
            Init(nam, sex);
        }

        // Second constructor.
        public InformationSecurity(int r, int c) : base(r, c)
        {
            Init(null, true);
            Row = r;
            Col = c;
        }

        private void Init(String n, bool s)
        {
            Name = n;
            Male = s;
            JobRole = "Information Security";

            // Picture will be generated depending on the sex.
            if(Male)
            {
                PortraitFile = "MaleInformationSecurity.png";
                PictureFile = "Heroes/Information_Security_MALE.png";
                //CharacterPicture = " "; 
            }
            else
            {
                PortraitFile = "FemaleInformationSecurity.png";
                PictureFile = "Heroes/Information_Security_FEMALE.png";
                //CharacterPicture = " "; 
            }
            CharacterPicture = new BitmapImage(new Uri(PictureFile, UriKind.Relative));
            CharacterPortrait = new BitmapImage(new Uri(PortraitFile, UriKind.Relative));

            statEffects = new List<Effect>();

            /******************************************************************
             * stat progression unique to this job role.
             * ****************************************************************
             */
            HealthMulti = 2.00;
            EnergyMulti = 1.50;
            AttackMulti = 2.25;
            DefenseMulti = 1.75;
            SpeedMulti = 1.75;
            AgilityMulti = 3;
            AttackRangeMulti = 1.00;
            SpecialAttackMulti = 2.00;
            SpecialDefenseMulti = 1.50;

            /******************************************************************
             * stats initialized after multipliers applied.
             * ****************************************************************
             */
            InstantiateLevel(1);
        }
        public override int[,] Ability2(int[,] boardspaces)
        {
            this.selectedAttackPower = 0.8;
            this.isSelectedAttackTypeSpecial = true;

            //up
            if (row - 1 >= 0 && boardspaces[row - 1, col] == 0)
            {
                boardspaces[row - 1, col] = 1;
            }
            //down
            if (row + 1 < boardspaces.GetLength(0) && boardspaces[row + 1, col] == 0)
            {
                boardspaces[row + 1, col] = 1;
            }
            //left
            if (col - 1 >= 0 && boardspaces[row, col - 1] == 0)
            {
                boardspaces[row, col - 1] = 1;
            }
            //right
            if (col + 1 < boardspaces.GetLength(1) && boardspaces[row, col + 1] == 0)
            {
                boardspaces[row, col + 1] = 1;
            }
            return boardspaces;
        }

        public override int[,] Ability3(int[,] boardspaces)
        {
            this.selectedAttackPower = 1.2;
            this.isSelectedAttackTypeSpecial = true;

            //up
            if (row - 1 >= 0 && boardspaces[row - 1, col] == 0)
            {
                boardspaces[row - 1, col] = 1;
            }
            if (row - 2 >= 0 && boardspaces[row - 2, col] == 0)
            {
                boardspaces[row - 2, col] = 1;
            }
            if (row - 3 >= 0 && boardspaces[row - 3, col] == 0)
            {
                boardspaces[row - 3, col] = 1;
            }
            //down
            if (row + 1 < boardspaces.GetLength(0) && boardspaces[row + 1, col] == 0)
            {
                boardspaces[row + 1, col] = 2;
            }
            if (row + 2 < boardspaces.GetLength(0) && boardspaces[row + 2, col] == 0)
            {
                boardspaces[row + 2, col] = 2;
            }
            if (row + 3 < boardspaces.GetLength(0) && boardspaces[row + 3, col] == 0)
            {
                boardspaces[row + 3, col] = 2;
            }
            //left
            if (col - 1 >= 0 && boardspaces[row, col - 1] == 0)
            {
                boardspaces[row, col - 1] = 3;
            }
            if (col - 2 >= 0 && boardspaces[row, col - 2] == 0)
            {
                boardspaces[row, col - 2] = 3;
            }
            if (col - 3 >= 0 && boardspaces[row, col - 3] == 0)
            {
                boardspaces[row, col - 3] = 3;
            }
            //right
            if (col + 1 < boardspaces.GetLength(1) && boardspaces[row, col + 1] == 0)
            {
                boardspaces[row, col + 1] = 4;
            }
            if (col + 2 < boardspaces.GetLength(1) && boardspaces[row, col + 2] == 0)
            {
                boardspaces[row, col + 2] = 4;
            }
            if (col + 3 < boardspaces.GetLength(1) && boardspaces[row, col + 3] == 0)
            {
                boardspaces[row, col + 3] = 4;
            }
            return boardspaces;
        }
    }
}