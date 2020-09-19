using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Community
{
    public class Boss : Enemy
    {
        public Boss(String nam, bool sex)
        {
            Init(nam, sex);
        }

        // Second constructor.
        public Boss(int r, int c) : base(r, c)
        {
            Init("Ravenscroft", true);
            Row = r;
            Col = c;
        }

        private void Init(String n, bool s)
        {
            Name = n;
            Male = s;
            JobRole = "Boss";

            pictureFile = ".../.../Pictures/Enemies/Ravenscroft.png";
            characterPicture = new BitmapImage(new Uri(pictureFile, UriKind.Relative));

            /******************************************************************
             * stat progression unique to this job role.
             * ****************************************************************
             */
            HealthMulti = 3.00;
            EnergyMulti = 3.00;
            AttackMulti = 2.00;
            DefenseMulti = 3.00;
            SpeedMulti = 1.25;
            AgilityMulti = 2;
            AttackRangeMulti = 1.00;
            SpecialAttackMulti = 3.00;
            SpecialDefenseMulti = 3.00;

            ExperienceAmountMulti = 100.00;

            /******************************************************************
             * stats initialized after multipliers applied.
             * ****************************************************************
             */
            InstantiateLevel(1);
        }

        public override int[,] Ability2(int[,] boardspaces)
        {
            this.selectedAttackPower = 0.8;
            this.isSelectedAttackTypeSpecial = false;

            int i = 2;
            //up
            if (row - 1 >= 0 && boardspaces[row - 1, col] == 0)
            {
                boardspaces[row - 1, col] = 1;
                if (row - 2 >= 0 && boardspaces[row - 2, col] == 0)
                {
                    boardspaces[row - 2, col] = 1;
                    while (row - i >= 0 && boardspaces[row - i, col] == 0)
                    {
                        boardspaces[row - i, col] = 1;
                        i++;
                    }
                    i = 2;
                    if (col - 1 >= 0 && boardspaces[row - 2, col - 1] == 0)
                    {
                        boardspaces[row - 2, col - 1] = 1;
                        while (row - i >= 0 && boardspaces[row - i, col - 1] == 0)
                        {
                            boardspaces[row - i, col - 1] = 1;
                            i++;
                        }
                        i = 2;
                    }
                    if (col + 1 >= 0 && boardspaces[row - 2, col + 1] == 0)
                    {
                        boardspaces[row - 2, col + 1] = 1;
                        while (row - i >= 0 && boardspaces[row - i, col + 1] == 0)
                        {
                            boardspaces[row - i, col + 1] = 1;
                            i++;
                        }
                        i = 2;
                    }
                }
            }
            //down
            if (row + 1 < boardspaces.GetLength(0) && boardspaces[row + 1, col] == 0)
            {
                boardspaces[row + 1, col] = 2;
                if (row + 2 < boardspaces.GetLength(0) && boardspaces[row + 2, col] == 0)
                {
                    boardspaces[row + 2, col] = 2;
                    while (row + i < boardspaces.GetLength(0) && boardspaces[row + i, col] == 0)
                    {
                        boardspaces[row + i, col] = 2;
                        i++;
                    }
                    i = 2;
                    if (col - 1 >= 0 && boardspaces[row + 2, col - 1] == 0)
                    {
                        boardspaces[row + 2, col - 1] = 2;
                        while (row + i < boardspaces.GetLength(0) && boardspaces[row + i, col - 1] == 0)
                        {
                            boardspaces[row + i, col - 1] = 2;
                            i++;
                        }
                        i = 2;
                    }
                    if (col + 1 < boardspaces.GetLength(1) && boardspaces[row + 2, col + 1] == 0)
                    {
                        boardspaces[row + 2, col + 1] = 2;
                        while (row + i < boardspaces.GetLength(0) && boardspaces[row + i, col + 1] == 0)
                        {
                            boardspaces[row + i, col + 1] = 2;
                            i++;
                        }
                        i = 2;
                    }
                }
            }
            //left
            if (col - 1 >= 0 && boardspaces[row, col - 1] == 0)
            {
                boardspaces[row, col - 1] = 3;
                if (col - 2 >= 0 && boardspaces[row, col - 2] == 0)
                {
                    boardspaces[row, col - 2] = 3;
                    while (col - i >= 0 && boardspaces[row, col - i] == 0)
                    {
                        boardspaces[row, col - i] = 3;
                        i++;
                    }
                    i = 2;
                    if (row - 1 >= 0 && boardspaces[row - 1, col - 2] == 0)
                    {
                        boardspaces[row - 1, col - 2] = 3;
                        while (col - i >= 0 && boardspaces[row - 1, col - i] == 0)
                        {
                            boardspaces[row - 1, col - i] = 3;
                            i++;
                        }
                        i = 2;
                    }
                    if (row + 1 < boardspaces.GetLength(1) && boardspaces[row + 1, col - 2] == 0)
                    {
                        boardspaces[row + 1, col - 2] = 3;
                        while (col - i >= 0 && boardspaces[row + 1, col - i] == 0)
                        {
                            boardspaces[row + 1, col - i] = 3;
                            i++;
                        }
                        i = 2;
                    }
                }
            }
            //right
            if (col + 1 < boardspaces.GetLength(1) && boardspaces[row, col + 1] == 0)
            {
                boardspaces[row, col + 1] = 4;
                if (col + 2 < boardspaces.GetLength(1) && boardspaces[row, col + 2] == 0)
                {
                    boardspaces[row, col + 2] = 4;
                    while (col + i < boardspaces.GetLength(1) && boardspaces[row, col + i] == 0)
                    {
                        boardspaces[row, col + i] = 4;
                        i++;
                    }
                    if (row - 1 >= 0 && boardspaces[row - 1, col + 2] == 0)
                    {
                        boardspaces[row - 1, col + 2] = 4;
                        while (col + i < boardspaces.GetLength(1) && boardspaces[row - 1, col + i] == 0)
                        {
                            boardspaces[row - 1, col + i] = 4;
                            i++;
                        }
                    }
                    if (row + 1 < boardspaces.GetLength(0) && boardspaces[row + 1, col + 2] == 0)
                    {
                        boardspaces[row + 1, col + 2] = 4;
                        while (col + i < boardspaces.GetLength(1) && boardspaces[row + 1, col + i] == 0)
                        {
                            boardspaces[row + 1, col + i] = 4;
                            i++;
                        }
                    }
                }
            }
            return boardspaces;
        }
        public override int[,] Ability3(int[,] boardspaces)
        {
            this.selectedAttackPower = 1.2;
            this.isSelectedAttackTypeSpecial = false;

            //up
            if (row - 1 >= 0)
            {
                boardspaces[row - 1, col] = 1;
            }
            if (row - 2 >= 0)
            {
                boardspaces[row - 2, col] = 1;
            }
            if (row - 3 >= 0)
            {
                boardspaces[row - 3, col] = 1;
            }
            //down
            if (row + 1 < boardspaces.GetLength(0))
            {
                boardspaces[row + 1, col] = 2;
            }
            if (row + 2 < boardspaces.GetLength(0))
            {
                boardspaces[row + 2, col] = 2;
            }
            if (row + 3 < boardspaces.GetLength(0))
            {
                boardspaces[row + 3, col] = 2;
            }
            //left
            if (col - 1 >= 0)
            {
                boardspaces[row, col - 1] = 3;
            }
            if (col - 2 >= 0)
            {
                boardspaces[row, col - 2] = 3;
            }
            if (col - 3 >= 0)
            {
                boardspaces[row, col - 3] = 3;
            }
            //right
            if (col + 1 < boardspaces.GetLength(1))
            {
                boardspaces[row, col + 1] = 4;
            }
            if (col + 2 < boardspaces.GetLength(1))
            {
                boardspaces[row, col + 2] = 4;
            }
            if (col + 3 < boardspaces.GetLength(1))
            {
                boardspaces[row, col + 3] = 4;
            }
            return boardspaces;
        }
    }
}