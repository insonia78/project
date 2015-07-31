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
using Community;
/*
 * It has the game theory for the strategy and selects which Enemy attachs the Hero
 * 
 * */




namespace GameBoard
{
    public partial class MainWindow : Page
    {

        int aheroRow, aheroCol;
        int aindex = 0;
        int iterationNumber = 0;
         int i = 0;
        public void targetAndMoveToHero()
        {
            int row = 0;
            int col = 0;
            int done = 0;
            int index = 0;
            int targetEnemyCount = 0;
            int targetHeroCount = 0;
            iterationNumber = 0;
            double dummyTemp = 0;
            int dummyIndex = 0;
            
            ArrayList selectHeroHealt = new ArrayList();
            ArrayList selectEnemyAttack = new ArrayList();
            ArrayList selectEnemyHealt = new ArrayList();
            ArrayList selectHeroAttack = new ArrayList();
            ArrayList dummyTargetHeroAttack = new ArrayList();
            ArrayList dummyTargetHeroHealth = new ArrayList();
            ArrayList dummyTargetEnemyAttack = new ArrayList();
            ArrayList dummyTargetEnemyHealth = new ArrayList();
            ArrayList heroHealthEnemyAttachWeight = new ArrayList();
            ArrayList targetHeroRow1 = new ArrayList();
            ArrayList targetHeroCol1 = new ArrayList();
            ArrayList targetEnemyRow1 = new ArrayList();
            ArrayList targetEnemyCol1 = new ArrayList();
          if (targetEnemyRow.Count > 0 && countEnemiesForloop > 0)
          { 
            int tempEnemyAttack = (int)targetEnemyAttack[0];
            while (done < targetEnemyAttack.Count)
            {
                dummyTargetEnemyAttack.Add((int)targetEnemyAttack[done]);
                dummyTargetEnemyHealth.Add((int)targetEnemyHealth[done]);
                done++;
            }
            done = 0;
            while (done < targetHeroAttack.Count)
            {
                dummyTargetHeroAttack.Add((int)targetHeroAttack[done]);
                dummyTargetHeroHealth.Add((int)targetHeroHealth[done]);
                done++;
            }
            done = 0;
            int skip = -1;
            while (targetEnemyCount < targetEnemyAttack.Count)
            {
                while (done < dummyTargetEnemyAttack.Count)
                {
                    if (tempEnemyAttack == -1)
                    {
                        done++;
                        continue;
                        
                        
                    }
                    else
                    {
                        if (tempEnemyAttack < (int)dummyTargetEnemyAttack[done] && (int)dummyTargetEnemyAttack[done] != -1)
                        {
                            tempEnemyAttack = (int)dummyTargetEnemyAttack[done];
                                              
                            done = 0;
                        }
                        
                    }
                    done++;

                }

                targetEnemyCount++;
                if (tempEnemyAttack != -1)
                {
                    index = dummyTargetEnemyAttack.IndexOf(tempEnemyAttack);
                    selectEnemyAttack.Add(index);

                    dummyTargetEnemyAttack.RemoveAt(index);
                    dummyTargetEnemyAttack.Insert(index, skip);
                    tempEnemyAttack = (int)dummyTargetEnemyAttack[0];
                }
                int check = 0;
                if (tempEnemyAttack == -1)
                {
                    while (check < dummyTargetEnemyAttack.Count && tempEnemyAttack == -1)
                    {
                        tempEnemyAttack = (int)dummyTargetEnemyAttack[check];
                        check++;
                    }
                }
                else
                {
                    tempEnemyAttack = (int)dummyTargetEnemyAttack[check];
                }
                index = 0;
                done = 0;
            }
            targetEnemyCount = 0;
           int tempHeroHealth = (int)targetHeroHealth[0];
            done = 0;
            while (targetEnemyCount < targetHeroHealth.Count)
            {
                while (done < dummyTargetHeroHealth.Count)
                {
                    if ((int)dummyTargetHeroHealth[done] == -1)
                    {
                        done++;
                        continue;
                    }
                    else
                    {
                        if (tempHeroHealth > (int)dummyTargetHeroHealth[done] && (int)dummyTargetHeroHealth[done] != 1)
                        {
                            tempHeroHealth = (int)dummyTargetHeroHealth[done];
                            
                            done = 0;
                        }
                        
                    }
                    done++;
                    
                }
                targetEnemyCount++;
                if (tempHeroHealth != -1)
                {
                    index = dummyTargetHeroHealth.IndexOf(tempHeroHealth);
                    selectHeroHealt.Add(index);

                    dummyTargetHeroHealth.RemoveAt(index);
                    dummyTargetHeroHealth.Insert(index, skip);
                    tempHeroHealth = (int)dummyTargetHeroHealth[0];
                }
                int check = 0;
                if (tempHeroHealth == -1)
                {
                    while (check < dummyTargetHeroHealth.Count && tempHeroHealth == -1)
                    {
                        tempHeroHealth = (int)dummyTargetHeroHealth[check];
                        check++;
                    }

                }
                else
                {
                    tempHeroHealth = (int)dummyTargetHeroHealth[check];
                }
                index = 0;
                done = 0;
            }
            done = 0;
            targetEnemyCount = 0;
            int tempEnemyHealth = (int)targetEnemyHealth[0];
            while (targetEnemyCount < targetEnemyHealth.Count)
            {
                while (done < dummyTargetEnemyHealth.Count)
                {
                    if ((int)dummyTargetEnemyHealth[done] == -1)
                    {
                        done++;
                        continue;
                    }
                    else
                    {
                        if (tempEnemyHealth > (int)dummyTargetEnemyHealth[done])
                        {
                            tempEnemyHealth = (int)dummyTargetEnemyHealth[done];
                           
                            done = 0;
                        }
                        
                    }
                    done++;

                }
                targetEnemyCount++;
                if (tempEnemyHealth != 1)
                {
                    index = dummyTargetEnemyHealth.IndexOf(tempEnemyHealth);
                    selectEnemyHealt.Add(index);

                    dummyTargetEnemyHealth.RemoveAt(index);
                    dummyTargetEnemyHealth.Insert(index, skip);
                    tempEnemyHealth = (int)dummyTargetEnemyHealth[0];
                }
                int check = 0;
                if (tempHeroHealth == -1)
                {
                    while (check < dummyTargetEnemyHealth.Count && tempHeroHealth == -1)
                    {
                        tempEnemyHealth = (int)dummyTargetEnemyHealth[check];
                        check++;
                    }

                }
                else
                {
                    tempEnemyHealth = (int)dummyTargetEnemyHealth[check];
                }
                index = 0;
                done = 0;
            }
            targetEnemyCount = 0;
            int tempHeroAttack = (int)targetHeroAttack[0];
            done = 0;
            while (targetEnemyCount < dummyTargetHeroAttack.Count)
            {
                while (done < dummyTargetHeroAttack.Count)
                {
                    if ((int)dummyTargetHeroAttack[done] == -1)
                    {
                        done++;
                        continue;
                    }
                    else
                    {
                        if (tempHeroAttack < (int)dummyTargetHeroAttack[done])
                        {
                            tempHeroAttack = (int)dummyTargetHeroAttack[done];
                            done = 0;
                        }
                        
                    }
                      done++;

                }
                targetEnemyCount++;
                if (tempHeroAttack != -1)
                {
                    index = dummyTargetHeroAttack.IndexOf(tempHeroAttack);
                    selectHeroAttack.Add(index);

                    dummyTargetHeroAttack.RemoveAt(index);
                    dummyTargetHeroAttack.Insert(index, skip);
                    tempHeroAttack = (int)dummyTargetHeroAttack[0];
                }
                int check = 0;
                if (tempHeroAttack == -1)
                {
                    while (check < dummyTargetHeroAttack.Count && tempHeroAttack == -1)
                    {
                        tempHeroAttack = (int)dummyTargetHeroAttack[check];
                        check++;
                    }

                }
                else
                {
                    tempHeroAttack = (int)dummyTargetHeroAttack[check];
                }
                index = 0;
                done = 0;

            }
            done = 0;
            // to consider if enemy < hero or hero < enemy
            while (done < targetEnemyRow.Count)
            {
                double maxWeigth = 0;                
                int Erow = Math.Abs((int)targetEnemyRow[(int)selectEnemyAttack[done]] - (int)targetHeroRow[(int)selectHeroHealt[done]]);
                int Ecol = Math.Abs((int)targetEnemyCol[(int)selectEnemyAttack[done]] - (int)targetHeroCol[(int)selectHeroHealt[done]]);
                int Hrow = Math.Abs((int)targetEnemyRow[(int)selectEnemyHealt[done]] - (int)targetHeroRow[(int)selectHeroAttack[done]]);
                int Hcol = Math.Abs((int)targetEnemyCol[(int)selectEnemyHealt[done]] - (int)targetHeroCol[(int)selectHeroAttack[done]]);

                
                
             heroHealthEnemyAttachWeight.Add(((0.30)*((int)targetHeroHealth[(int)selectHeroHealt[done]]/(int)targetEnemyAttack[(int)selectEnemyAttack[done]])) +((0.10)*((int)targetEnemyHealth[(int)selectEnemyHealt[done]]/(int)targetHeroAttack[(int)selectHeroAttack[done]])) + (0.20 * (Hrow + Hcol) )+ (0.40 * (Erow + Ecol)));
                //heroHealthEnemyAttachWeight.Add(Erow + Ecol);
                
               targetEnemyRow1.Add((int)targetEnemyRow[(int)selectEnemyAttack[done]]);
               targetEnemyCol1.Add((int)targetEnemyCol[(int)selectEnemyAttack[done]]);
               targetHeroRow1.Add((int)targetHeroRow[(int)selectHeroHealt[done]]);
               targetHeroCol1.Add((int)targetHeroCol[(int)selectHeroHealt[done]]);
               /* 
               targetEnemyRow1.Add((int)targetEnemyRow[done]);
               targetEnemyCol1.Add((int)targetEnemyCol[done]);
               targetHeroCol1.Add((int)targetHeroCol[done]);
               targetHeroRow1.Add((int)targetHeroRow[done]);
                * */
               done++;
            }
            done = 0;
            try
            {
                dummyTemp = (double)heroHealthEnemyAttachWeight[0];
                dummyIndex = 0;
                while (done < heroHealthEnemyAttachWeight.Count)
                {
                    if (dummyTemp < (double)heroHealthEnemyAttachWeight[done])
                    {
                         
                        dummyTemp = (double)heroHealthEnemyAttachWeight[done];
                        dummyIndex = heroHealthEnemyAttachWeight.IndexOf(dummyTemp);
                        done = 0;
                    }
                    done++;


                }
            }
            catch
            {
                ok = false;
                Enemytimer.Stop();
                Enemytimer.Tick -= Etimer_Tick;
            }
                      

            
                try
                {
                    aheroRow = (int)targetHeroRow1[dummyIndex];
                    aheroCol = (int)targetHeroCol1[dummyIndex];

                }
                catch
                {
                }

                try
                {
                    
                    selectedCharacterRow = (int)targetEnemyRow1[dummyIndex];
                    selectedCharacterCol = (int)targetEnemyCol1[dummyIndex];
                }
                catch
                {
                }
                try
                {
                    targetEnemyRow.RemoveAt(targetEnemyRow.IndexOf(targetEnemyRow1[dummyIndex]));
                    targetEnemyCol.RemoveAt(targetEnemyCol.IndexOf(targetEnemyCol1[dummyIndex]));
                    targetEnemyAttack.RemoveAt((int)selectEnemyAttack[dummyIndex]);
                    targetEnemyHealth.RemoveAt((int)selectEnemyAttack[dummyIndex]);
                    
                    
                    selectHeroHealt.Clear();
                    selectEnemyAttack.Clear();
                    selectEnemyHealt.Clear();
                    selectHeroAttack.Clear();
                    dummyTargetHeroAttack.Clear();
                    dummyTargetHeroHealth.Clear();
                    dummyTargetEnemyAttack.Clear();
                    dummyTargetEnemyHealth.Clear();
                    heroHealthEnemyAttachWeight.Clear();
                    targetHeroRow1.Clear();
                    targetHeroCol1.Clear();
                    targetEnemyRow1.Clear();
                    targetEnemyCol1.Clear();
                    ok = true;
                }
                catch
                {
                    nextTurn();
                }
                // i++;

            }
            else
            {
                ok = false;
                Enemytimer.Stop();
                Enemytimer.Tick -= Etimer_Tick;
                

            }
                
                //EnemyAbility1();
                //displayEnemyAttackAreas();
            }
        
        
         
        }
    }

