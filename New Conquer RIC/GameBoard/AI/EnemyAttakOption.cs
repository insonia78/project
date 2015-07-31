using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Collections;
/*
 * Enemy attack option enables the enemy to peform a attack
 * it chooces 4 ability and then  returns true or false if the attack was performed after the movement or before the movment 
 * */

namespace GameBoard
{
    public partial class MainWindow : Page
    {



        public void EnemyAttach()
        {
            int heroInAttackRangeCount = 0;
            int max_heroesInRange = 0;
            int bestAttack = 0;
            int bestAttackArea = 0;
            int r = selectedCharacterRow;
            int c = selectedCharacterCol;

            Ability1_Click(boardspaces[r, c], null);

            heroInAttackRangeCount = countHeroesInArea(area1);
            if (heroInAttackRangeCount > max_heroesInRange)
            {
                bestAttack = 1;
                bestAttackArea = 1;
                max_heroesInRange = heroInAttackRangeCount;
            }

            heroInAttackRangeCount = countHeroesInArea(area2);
            if (heroInAttackRangeCount > max_heroesInRange)
            {
                bestAttack = 1;
                bestAttackArea = 2;
                max_heroesInRange = heroInAttackRangeCount;
            }

            heroInAttackRangeCount = countHeroesInArea(area3);
            if (heroInAttackRangeCount > max_heroesInRange)
            {
                bestAttack = 1;
                bestAttackArea = 3;
                max_heroesInRange = heroInAttackRangeCount;
            }

            heroInAttackRangeCount = countHeroesInArea(area4);
            if (heroInAttackRangeCount > max_heroesInRange)
            {
                bestAttack = 1;
                bestAttackArea = 4;
                max_heroesInRange = heroInAttackRangeCount;
            }


            Ability2_Click(boardspaces[r, c], null);

            heroInAttackRangeCount = countHeroesInArea(area1);
            if (heroInAttackRangeCount > max_heroesInRange)
            {
                bestAttack = 2;
                bestAttackArea = 1;
                max_heroesInRange = heroInAttackRangeCount;
            }

            heroInAttackRangeCount = countHeroesInArea(area2);
            if (heroInAttackRangeCount > max_heroesInRange)
            {
                bestAttack = 2;
                bestAttackArea = 2;
                max_heroesInRange = heroInAttackRangeCount;
            }

            heroInAttackRangeCount = countHeroesInArea(area3);
            if (heroInAttackRangeCount > max_heroesInRange)
            {
                bestAttack = 2;
                bestAttackArea = 3;
                max_heroesInRange = heroInAttackRangeCount;
            }

            heroInAttackRangeCount = countHeroesInArea(area4);
            if (heroInAttackRangeCount > max_heroesInRange)
            {
                bestAttack = 2;
                bestAttackArea = 4;
                max_heroesInRange = heroInAttackRangeCount;
            }


            Ability3_Click(boardspaces[r, c], null);

            heroInAttackRangeCount = countHeroesInArea(area1);
            if (heroInAttackRangeCount > max_heroesInRange)
            {
                bestAttack = 3;
                bestAttackArea = 1;
                max_heroesInRange = heroInAttackRangeCount;
            }

            heroInAttackRangeCount = countHeroesInArea(area2);
            if (heroInAttackRangeCount > max_heroesInRange)
            {
                bestAttack = 3;
                bestAttackArea = 2;
                max_heroesInRange = heroInAttackRangeCount;
            }

            heroInAttackRangeCount = countHeroesInArea(area3);
            if (heroInAttackRangeCount > max_heroesInRange)
            {
                bestAttack = 3;
                bestAttackArea = 3;
                max_heroesInRange = heroInAttackRangeCount;
            }

            heroInAttackRangeCount = countHeroesInArea(area4);
            if (heroInAttackRangeCount > max_heroesInRange)
            {
                bestAttack = 3;
                bestAttackArea = 4;
                max_heroesInRange = heroInAttackRangeCount;
            }


            switch (bestAttack)
            {
                case 0:
                    clearAttackOptions();
                    test = "false";
                    break;
                case 1:
                    Ability1_Click(boardspaces[r, c], null);
                    switch (bestAttackArea)
                    {
                        case 0:
                            clearAttackOptions();
                            test = "false";
                            break;
                        case 1:
                            applyAbilityToArea(area1);
                            break;
                        case 2:
                            applyAbilityToArea(area2);
                            break;
                        case 3:
                            applyAbilityToArea(area3);
                            break;
                        case 4:
                            applyAbilityToArea(area4);
                            break;
                    }
                    break;
                case 2:
                    Ability2_Click(boardspaces[r, c], null);
                    switch (bestAttackArea)
                    {
                        case 0:
                            clearAttackOptions();
                            test = "false";
                            break;
                        case 1:
                            applyAbilityToArea(area1);
                            break;
                        case 2:
                            applyAbilityToArea(area2);
                            break;
                        case 3:
                            applyAbilityToArea(area3);
                            break;
                        case 4:
                            applyAbilityToArea(area4);
                            break;
                    }
                    break;
                case 3:
                    Ability3_Click(boardspaces[r, c], null);
                    switch (bestAttackArea)
                    {
                        case 0:
                            clearAttackOptions();
                            test = "false";
                            break;
                        case 1:
                            applyAbilityToArea(area1);
                            break;
                        case 2:
                            applyAbilityToArea(area2);
                            break;
                        case 3:
                            applyAbilityToArea(area3);
                            break;
                        case 4:
                            applyAbilityToArea(area4);
                            break;
                    }
                    break;
            }

           

            

            }


        }
    }


