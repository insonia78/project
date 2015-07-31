using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community
{
    class InformationSecurity : Hero
    {
        public InformationSecurity(String nam, bool sex)
        {
            Init(nam, sex);
        }

        // Second constructor.
        public InformationSecurity(int r, int c, int charSpeed)
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
            JobRole = "Information Security";

            // Picture will be generated depending on the sex.
            if(Male)
            {
                CharacterProfilePicture = "MaleInformationSecurity.png";
                CharacterPicture = " "; 
            }
            else
            {
                CharacterProfilePicture = "FemaleInformationSecurity.png";
                CharacterPicture = " "; 
            }

            /******************************************************************
             * stat progression unique to this job role.
             * ****************************************************************
             */
            HealthMulti = 2.00;
            EnergyMulti = 1.50;
            AttackMulti = 2.25;
            DefenseMulti = 1.75;
            SpeedMulti = 3;
            AttackRangeMulti = 1.00;
            SpecialAttackMulti = 2.00;
            SpecialDefenseMulti = 1.50;

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