using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community
{
    class SystemsAnalyst : Hero
    {
        public SystemsAnalyst(String nam, bool sex)
        {
            Init(nam, sex);
        }

        // Second constructor.
        public SystemsAnalyst(int r, int c, int charSpeed)
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
            JobRole = "Systems Analyst";

            // Picture will be generated depending on the sex.
            if(Male)
            {
                CharacterProfilePicture = "MaleSystemsAnalyst.png";
                CharacterPicture = " "; 
            }
            else
            {
                CharacterProfilePicture = "FemaleSystemsAnalyst.png";
                CharacterPicture = " "; 
            }

            /******************************************************************
             * stat progression unique to this job role.
             * ****************************************************************
             */
            HealthMulti = 1.75;
            EnergyMulti = 3.00;
            AttackMulti = 1.25;
            DefenseMulti = 1.25;
            SpeedMulti = 2;
            AttackRangeMulti = 2.00;
            SpecialAttackMulti = 3.00;
            SpecialDefenseMulti = 2.00;

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