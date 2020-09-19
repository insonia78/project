using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community
{
    /**************************************************************************
     * Enemy is contrast to hero. when defeated by heros, the enemy character
     * will give experience points to the part of heros. the amount of 
     * experience points given to the party depend on the job role and level
     * of that enemy character.
     * ************************************************************************
     */
    class Enemy : Character
    {
        /**********************************************************************
         * TODO:
         * Create experience-for-kill system.
         * ********************************************************************
         */

        // fields
        private int baseExperienceAmount = 1;      // least experience given.
        private double experienceAmountMulti;       // increase amount depending on enemy type.
        private int currentExperienceAmount;        // amount of experience given for the kill.

        // Constructor.
        public Enemy()
        {
            Init();
        }

        public void Init()
        {
            experienceAmountMulti = 1.0;
            currentExperienceAmount = (int)(baseExperienceAmount * experienceAmountMulti);
        }

        /**********************************************************************
         * Get and sets for the variables.
         **********************************************************************
         */
        // get and set for the baseExperienceAmount variable.
        public int BaseExperienceAmount
        {
            get
            {
                return baseExperienceAmount;
            }
            set
            {
                baseExperienceAmount = value;
            }
        }

        // get and set for the experienceAmountMulti variable.
        public double ExperienceAmountMulti
        {
            get
            {
                return experienceAmountMulti;
            }
            set
            {
                experienceAmountMulti = value;
            }
        }

        // get and set for the currentExperienceAmount variable.
        public int CurrentExperienceAmount
        {
            get
            {
                return currentExperienceAmount;
            }
            set
            {
                currentExperienceAmount = value;
            }
        }

        /**********************************************************************
         * Other methods.
         * ********************************************************************
         */
        // Prints out the variables for testing purposes.
        public String ToString()
        {
            String text;

            text = (
                base.ToString() +
                "\nBase experience amount: " + baseExperienceAmount +
                "\nExperience Amount Multiplier: " + experienceAmountMulti +
                "\nCurrent Experience Amount: " + currentExperienceAmount + "\n");

            return text;
        }
    }
}