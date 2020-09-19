﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Community
{
    public class CampusPolice : Enemy
    {
        public CampusPolice()
        {
            Init();
        }

        // Second constructor.
        public CampusPolice(int r, int c) : base(r, c)
        {
            Init();
            Row = r;
            Col = c;
        }

        private void Init()
        {
            /******************************************************************
             * stat progression unique to this job role.
             * ****************************************************************
             */
            JobRole = "Campus Police";

            pictureFile = ".../.../Pictures/Enemies/Campus_Police.png";
            characterPicture = new BitmapImage(new Uri(pictureFile, UriKind.Relative));

            statEffects = new List<Effect>();

            HealthMulti = 3.00;
            EnergyMulti = 1.50;
            AttackMulti = 2.00;
            DefenseMulti = 3.00;
            SpeedMulti = 1;
            AgilityMulti = 1;
            AttackRangeMulti = 1.00;
            SpecialAttackMulti = 2.00;
            SpecialDefenseMulti = 2.00;

            ExperienceAmountMulti = 25.00;
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

            //up
            if (row - 1 >= 0 && boardspaces[row - 1, col] == 0)
            {
                boardspaces[row - 1, col] = 1;
                if (row - 2 >= 0 && boardspaces[row - 2, col] == 0)
                {
                    boardspaces[row - 2, col] = 1;
                    if (col - 1 >= 0 && boardspaces[row - 2, col - 1] == 0)
                        boardspaces[row - 2, col - 1] = 1;
                    if (col + 1 >= 0 && boardspaces[row - 2, col + 1] == 0)
                        boardspaces[row - 2, col + 1] = 1;
                }
            }
            //down
            if (row + 1 < boardspaces.GetLength(0) && boardspaces[row + 1, col] == 0)
            {
                boardspaces[row + 1, col] = 2;
                if (row + 2 < boardspaces.GetLength(0) && boardspaces[row + 2, col] == 0)
                {
                    boardspaces[row + 2, col] = 2;
                    if (col - 1 >= 0 && boardspaces[row + 2, col - 1] == 0)
                        boardspaces[row + 2, col - 1] = 2;
                    if (col + 1 < boardspaces.GetLength(1) && boardspaces[row + 2, col + 1] == 0)
                        boardspaces[row + 2, col + 1] = 2;
                }
            }
            //left
            if (col - 1 >= 0 && boardspaces[row, col - 1] == 0)
            {
                boardspaces[row, col - 1] = 3;
                if (col - 2 >= 0 && boardspaces[row, col - 2] == 0)
                {
                    boardspaces[row, col - 2] = 3;
                    if (row - 1 >= 0 && boardspaces[row - 1, col - 2] == 0)
                        boardspaces[row - 1, col - 2] = 3;
                    if (row + 1 < boardspaces.GetLength(1) && boardspaces[row + 1, col - 2] == 0)
                        boardspaces[row + 1, col - 2] = 3;
                }
            }
            //right
            if (col + 1 < boardspaces.GetLength(1) && boardspaces[row, col + 1] == 0)
            {
                boardspaces[row, col + 1] = 4;
                if (col + 2 < boardspaces.GetLength(1) && boardspaces[row, col + 2] == 0)
                {
                    boardspaces[row, col + 2] = 4;
                    if (row - 1 >= 0 && boardspaces[row - 1, col + 2] == 0)
                        boardspaces[row - 1, col + 2] = 4;
                    if (row + 1 < boardspaces.GetLength(0) && boardspaces[row + 1, col + 2] == 0)
                        boardspaces[row + 1, col + 2] = 4;
                }
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
                boardspaces[row, col + 3] = 3;
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