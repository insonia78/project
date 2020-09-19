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
    public class SystemsAnalyst : Hero
    {
        public SystemsAnalyst(String nam, bool sex)
        {
            Init(nam, sex);
        }

        // Second constructor.
        public SystemsAnalyst(int r, int c) : base(r, c)
        {
            Init(null, true);
            Row = r;
            Col = c;
        }

        private void Init(String n, bool s)
        {
            Name = n;
            Male = s;
            JobRole = "Systems Analyst";

            // Picture will be generated depending on the sex.
            if(Male)
            {
                PortraitFile = "MaleSystemsAnalyst.png";
                PictureFile = "Heroes/System_Analyst_MALE.png";
                //CharacterPicture = " "; 
            }
            else
            {
                PortraitFile = "FemaleSystemsAnalyst.png";
                PictureFile = "Heroes/System_Analyst_FEMALE.png";
                //CharacterPicture = " "; 
            }
            CharacterPicture = new BitmapImage(new Uri(PictureFile, UriKind.Relative));
            CharacterPortrait = new BitmapImage(new Uri(PortraitFile, UriKind.Relative));

            statEffects = new List<Effect>();

            /******************************************************************
             * stat progression unique to this job role.
             * ****************************************************************
             */
            HealthMulti = 1.75;
            EnergyMulti = 3.00;
            AttackMulti = 1.25;
            DefenseMulti = 1.25;
            SpeedMulti = 1.25;
            AgilityMulti = 2;
            AttackRangeMulti = 2.00;
            SpecialAttackMulti = 3.00;
            SpecialDefenseMulti = 2.00;

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
            //up left
            if (row - 1 >= 0 && col - 1 >=0 && boardspaces[row - 1, col - 1] == 0)
            {
                boardspaces[row - 1, col - 1] = 1;
            }
            //up right
            if (row - 1 >= 0 && col +1 <boardspaces.GetLength(1) && boardspaces[row - 1, col + 1] == 0)
            {
                boardspaces[row - 1, col + 1] = 1;
            }
            //down
            if (row + 1 < boardspaces.GetLength(0) && boardspaces[row + 1, col] == 0)
            {
                boardspaces[row + 1, col] = 1;
            }
            //down left
            if (row + 1 < boardspaces.GetLength(0) && col - 1 >= 0 && boardspaces[row + 1, col - 1] == 0)
            {
                boardspaces[row + 1, col - 1] = 1;
            }
            //down right
            if (row + 1 < boardspaces.GetLength(0) && col + 1 < boardspaces.GetLength(1) && boardspaces[row + 1, col + 1] == 0)
            {
                boardspaces[row + 1, col + 1] = 1;
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
            this.selectedAttackPower = 0.5;
            this.isSelectedAttackTypeSpecial = true;

            //up
            if (row - 3 >= 0 && boardspaces[row - 3, col] == 0)
            {
                boardspaces[row - 3, col] = 1;
                //up
                if (row - 4 >= 0 && boardspaces[row - 4, col] == 0)
                {
                    boardspaces[row - 4, col] = 1;
                }
                //down
                if (boardspaces[row - 2, col] == 0)
                {
                    boardspaces[row - 2, col] = 1;
                }
                //left
                if (col - 1 >= 0 && boardspaces[row - 3, col - 1] == 0)
                {
                    boardspaces[row - 3, col - 1] = 1;
                }
                //right
                if (col + 1 < boardspaces.GetLength(1) && boardspaces[row - 3, col + 1] == 0)
                {
                    boardspaces[row - 3, col + 1] = 1;
                }
            }
            //down
            if (row + 3 < boardspaces.GetLength(0) && boardspaces[row + 3, col] == 0)
            {
                boardspaces[row + 3, col] = 2;
                //up
                if (row + 4 < boardspaces.GetLength(0) && boardspaces[row + 4, col] == 0)
                {
                    boardspaces[row + 4, col] = 2;
                }
                //down
                if (boardspaces[row + 2, col] == 0)
                {
                    boardspaces[row + 2, col] = 2;
                }
                //left
                if (col - 1 >= 0 && boardspaces[row + 3, col - 1] == 0)
                {
                    boardspaces[row + 3, col - 1] = 2;
                }
                //right
                if (col + 1 < boardspaces.GetLength(1) && boardspaces[row + 3, col + 1] == 0)
                {
                    boardspaces[row + 3, col + 1] = 2;
                }
            }
            //left
            if (col - 3 >= 0 && boardspaces[row, col - 3] == 0)
            {
                boardspaces[row, col - 3] = 3;
                //up
                if (row - 1 >= 0 && boardspaces[row - 1, col - 3] == 0)
                {
                    boardspaces[row - 1, col - 3] = 3;
                }
                //down
                if (row + 1 < boardspaces.GetLength(0) && boardspaces[row + 1, col - 3] == 0)
                {
                    boardspaces[row + 1, col - 3] = 3;
                }
                //left
                if (col - 4 >= 0 && boardspaces[row, col - 4] == 0)
                {
                    boardspaces[row, col - 4] = 3;
                }
                //right
                if (boardspaces[row, col - 2] == 0)
                {
                    boardspaces[row, col - 2] = 3;
                }
            }
            //right
            if (col + 3 < boardspaces.GetLength(1) && boardspaces[row, col + 3] == 0)
            {
                boardspaces[row, col + 3] = 4;
                //up
                if (row - 1 >= 0 && boardspaces[row - 1, col + 3] == 0)
                {
                    boardspaces[row - 1, col + 3] = 4;
                }
                //down
                if (row + 1 < boardspaces.GetLength(0) && boardspaces[row + 1, col + 3] == 0)
                {
                    boardspaces[row + 1, col + 3] = 4;
                }
                //left
                if (col + 4 < boardspaces.GetLength(1) && boardspaces[row, col + 4] == 0)
                {
                    boardspaces[row, col + 4] = 4;
                }
                //right
                if (boardspaces[row, col + 2] == 0)
                {
                    boardspaces[row, col + 2] = 4;
                }
            }

            return boardspaces;
        }
    }
}