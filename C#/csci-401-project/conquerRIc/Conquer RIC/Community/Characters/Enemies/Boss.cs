using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community
{
    class Boss : Enemy
    {
        public Boss(String nam, bool sex)
        {
            Init(nam, sex);
        }

        // Second constructor.
        public Boss(int r, int c, int charSpeed)
        {
            //Init();
            Row = r;
            Col = c;
            CurrentSpeed = charSpeed;
        }

        private void Init(String n, bool s)
        {
            Name = n;
            Male = s;
            JobRole = "Boss";
            /******************************************************************
             * stat progression unique to this job role.
             * ****************************************************************
             */
            HealthMulti = 3.00;
            EnergyMulti = 3.00;
            AttackMulti = 2.00;
            DefenseMulti = 3.00;
            SpeedMulti = 2;
            AttackRangeMulti = 1.00;
            SpecialAttackMulti = 3.00;
            SpecialDefenseMulti = 3.00;

            ExperienceAmountMulti = 100.00;

            /******************************************************************
             * stats initialized after multipliers applied.
             * ****************************************************************
             */
            MaxHealth = (int)(BaseHealth + (BaseHealth * 
                (HealthMulti * CurrentLevel)));
            CurrentHealth = MaxHealth;

            MaxEnergy = (int)(BaseEnergy + (BaseEnergy * 
                (EnergyMulti * CurrentLevel)));
            CurrentEnergy = MaxEnergy;

            MaxAttack = (int)(BaseAttack + (BaseAttack * 
                (AttackMulti * CurrentLevel)));
            CurrentAttack = MaxAttack;

            MaxDefense = (int)(BaseDefense + (BaseDefense * 
                (DefenseMulti * CurrentLevel)));
            CurrentDefense = MaxDefense;

            MaxSpeed = (int)(BaseSpeed + (BaseSpeed * 
                (SpeedMulti * CurrentLevel)));
            CurrentSpeed = MaxSpeed;

            MaxAttackRange = (int)(BaseAttackRange + (BaseAttackRange * 
                (AttackRangeMulti * CurrentLevel)));
            CurrentAttackRange = MaxAttackRange;

            MaxSpecialAttack = (int)(BaseSpecialAttack + (BaseSpecialAttack * 
                (SpecialAttackMulti * CurrentLevel)));
            CurrentSpecialAttack = MaxSpecialAttack;

            MaxSpecialDefense = (int)(BaseSpecialDefense + (BaseSpecialDefense * 
                (SpecialDefenseMulti * CurrentLevel)));
            CurrentSpecialDefense = MaxSpecialDefense;
        }
    }
}