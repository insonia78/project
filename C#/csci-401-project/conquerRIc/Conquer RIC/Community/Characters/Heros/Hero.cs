using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community
{
    /**************************************************************************
     * The heros contrast the enemy classes. Heros will be able to gain
     * experience until they hit the max experience they can earn for their 
     * current level and then they will be able to level up. Resetting their
     * max requirement of expereince to level up. For each level increase, the
     * difference from the max experience and min experience will be greater than 
     * the previous level.
     * The hero character will also be able to wear equipment that affects 
     * their stats for the better or worse. They will be able to place these
     * equipments are parts of their bodies and can interchange these items
     * during the Player's time in the world map.
     * The base and max experience do not change, after leveling up 
     * they 
     * ************************************************************************
     */
    /**********************************************************************
     * TODO:
     * helmet
     * chest
     * legs
     * arms
     * experience gain system.
     * ********************************************************************
     */
    class Hero : Character
    {
        // fields
        
        private String characterProfilePicture;     // image of the hero for the UI.
        
        // base stats for experience.
        private int baseExperience = 0;             // experience earned.
        private int baseMaxExperience = 100;        // experience needed to earn a new level.
        private double baseExperienceRate = 10.0;   // rate at which the hero earns experience.

        // current stats.
        private int currentExperience;              // current amount of experience.

        // default constructor.
        public Hero()
        {
            Init();
        }

        // Second constructor.
        public Hero(int r, int c, int charSpeed)
        {
            Init();
            base.Row = r;
            base.Col = c;
            base.CurrentSpeed = charSpeed;
        }

        public void Init()
        {
            characterProfilePicture = "Missingno.png";
            currentExperience = baseExperience;
        }

        // get and set for the profileImage variable.
        public String CharacterProfilePicture
        {
            get
            {
                return characterProfilePicture;
            }
            set
            {
                characterProfilePicture = value;
            }
        }

        // get and set for the baseExperience variable.
        public int BaseExperience
        {
            get
            {
                return baseExperience;
            }
            set
            {
                baseExperience = value;
            }
        }

        // get and set for the baseMaxExperience variable.
        public int BaseMaxExperience
        {
            get
            {
                return baseMaxExperience;
            }
            set
            {
                baseMaxExperience = value;
            }
        }

        // get and set for the baseMaxExperienceRate variable.
        public double BaseExperienceRate
        {
            get
            {
                return baseExperienceRate;
            }
            set
            {
                baseExperienceRate = value;
            }
        }

        // get and set for the currentExperience variable.
        public int CurrentExperience
        {
            get
            {
                return currentExperience;
            }
            set
            {
                currentExperience = value;
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
                "\nProfile image: " + characterProfilePicture +
                "\n\nExperience Stats:\n\n" +
                "Experience at the beginning of this level: " + baseExperience + "\n" +
                "Experience needed to level: " + baseMaxExperience + "\n" +
                "Current Experience: " + currentExperience);

            return text;
        }
    }
}