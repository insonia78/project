using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Community
{
    /**************************************************************************
     * This class is the skeleton of every hero and enemy.
     * each character has base stats that will be the same for all job classes.
     * Each stat has a multiplier. This multiplier will change the stats of each
     * job class. They are also their to decide how many points a character will
     * receive for each stat when they level up as it pertains to their job role.
     * ************************************************************************
     */
    /**************************************************************************
     * TODO:
     * build leveling system.
     * build battle system; 
     *      taking and receiving damage. death. status effects etc.
     * ************************************************************************
     */
    class Character
    {
        // fields
        private String name;

        // fields for the game board.
        private int row;
        private int col;
        private bool hasMovedOnTurn = false;
        private bool hasAttackedOnTurn = false;
        private bool hasUsedItemOnTurn = false;
        private bool isActiveOnTurn = true;
        private String characterPicture;

        // base stats.
        // all characters will have the same base stats.
        private int baseLevel = 1;                  // initial level.
        private int baseHealth = 100;               // initial health
        private int baseEnergy = 50;                // initial energy
        private int baseAttack = 5;                 // initial attack
        private int baseDefense = 5;                // initial defense
        private int baseSpeed = 5;                  // initial speed
        private int baseAttackRange = 1;            // initial attack range
        private int baseSpecialAttack = 10;         // initial special attack
        private int baseSpecialDefense = 10;        // initial special defense

        // stat multipliers , increases stats by a set amount for each level.
        // will differ depending on class setup. can be used injuction with effects.
        private double healthMulti;
        private double energyMulti;
        private double attackMulti;
        private double defenseMulti;
        private double speedMulti;
        private double attackRangeMulti;
        private double specialAttackMulti;
        private double specialDefenseMulti;

        // maximum values.
        private int maxLevel;
        private int maxHealth;
        private int maxEnergy;
        private int maxAttack;
        private int maxDefense;
        private int maxSpeed;
        private int maxAttackRange;
        private int maxSpecialAttack;
        private int maxSpecialDefense;

        // current state of stats. (affected by status changing properties.)
        private int currentLevel;
        private int currentHealth;
        private int currentEnergy;
        private int currentAttack;
        private int currentDefense;
        private int currentSpeed;
        private int currentAttackRange;
        private int currentSpecialAttack;
        private int currentSpecialDefense;

        // constructor
        public Character()
        {
            Init();
        }

        // initialize the fields.
        public void Init()
        {
        name = "MissingNo";
        characterPicture = "Missingno.png";

        // stat multipliers , increases stats by a set amount for each stat.
        healthMulti = 1.0;
        energyMulti = 1.0;
        attackMulti = 1.0;
        defenseMulti = 1.0;
        speedMulti = 1.0;
        attackRangeMulti = 1.0;
        specialAttackMulti = 1.0;
        specialDefenseMulti = 1.0;

        // maximum values.
        maxLevel = 99;
        maxHealth = (int)(baseHealth * healthMulti);
        maxEnergy = (int)(baseEnergy * energyMulti);
        maxAttack = (int)(baseAttack * attackMulti);
        maxDefense = (int)(baseDefense * defenseMulti);
        maxSpeed = (int)(baseSpeed * speedMulti);
        maxAttackRange = (int)(baseAttackRange * attackRangeMulti);
        maxSpecialAttack = (int)(baseSpecialAttack * specialAttackMulti);
        maxSpecialDefense = (int)(baseSpecialDefense * specialDefenseMulti);

        // current state of stats. (affected by status changing properties.)
        currentLevel = baseLevel;
        currentHealth = maxHealth;
        currentEnergy = maxEnergy;
        currentAttack = maxAttack;
        currentDefense = maxDefense;
        currentSpeed = maxSpeed;
        currentAttackRange = maxAttackRange;
        currentSpecialAttack = maxSpecialAttack;
        currentSpecialDefense = maxSpecialDefense;
        }

        /**********************************************************************
         * Get and Sets for the character name and the canMoveOnTurn variable.
         * ********************************************************************
         */
        // get and set for the name variable.
        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public virtual int Col
        {
            get { return col; }
            set { col = value; }
        }
        public virtual int Row
        {
            get { return row; }
            set { row = value; }
        }

        public String CharacterPicture
        {
            get
            {
                return characterPicture;
            }
            set { characterPicture = value; }
        }

        public bool HasMovedOnTurn
        {
            get
            {
                return hasMovedOnTurn;
            }
            set
            {
                hasMovedOnTurn = value;
            }
        }
        public bool HasAttackedOnTurn
        {
            get
            {
                return hasAttackedOnTurn;
            }
            set
            {
                hasAttackedOnTurn = value;
            }
        }
        public bool HasUsedItemOnTurn
        {
            get
            {
                return hasUsedItemOnTurn;
            }
            set
            {
                hasUsedItemOnTurn = value;
            }
        }

        public bool IsActiveOnTurn
        {
            get
            {
                return isActiveOnTurn;
            }

        }

        /**********************************************************************
         * Gets and sets for the Base Stats of the character.
         **********************************************************************
         */
        // get and set for the baseLevel variable.
        public int BaseLevel
        {
            get
            {
                return baseLevel;
            }
            set
            {
                baseLevel = value;
            }
        }

        // get and set for the baseHealth variable.
        public int BaseHealth
        {
            get
            {
                return baseHealth;
            }
            set
            {
                baseHealth = value;
            }
        }

        // get and set for the baseEnergy variable.
        public int BaseEnergy
        {
            get
            {
                return baseEnergy;
            }
            set
            {
                baseEnergy = value;
            }
        }

        // get and set for the baseAttack variable.
        public int BaseAttack
        {
            get
            {
                return baseAttack;
            }
            set
            {
                baseAttack = value;
            }
        }

        // get and set for the baseDefense variable.
        public int BaseDefense
        {
            get
            {
                return baseDefense;
            }
            set
            {
                baseDefense = value;
            }
        }

        // get and set for the baseSpeed variable.
        public int BaseSpeed
        {
            get
            {
                return baseSpeed;
            }
            set
            {
                baseSpeed = value;
            }
        }

        // get and set for the baseAttackRange variable.
        public int BaseAttackRange
        {
            get
            {
                return baseAttackRange;
            }
            set
            {
                baseAttackRange = value;
            }
        }

        // get and set for the baseSpecialAttack variable.
        public int BaseSpecialAttack
        {
            get
            {
                return baseSpecialAttack;
            }
            set
            {
                baseSpecialAttack = value;
            }
        }

        // get and set for the baseSpecialDefense variable.
        public int BaseSpecialDefense
        {
            get
            {
                return baseSpecialDefense;
            }
            set 
            {
                baseSpecialDefense = value;
            }
        }

        /**********************************************************************
         * Gets and Sets for the Multiplier Stats.
         * ********************************************************************
         */
        // get and set for the healthMulti variable.
        public double HealthMulti
        {
            get
            {
                return healthMulti;
            }
            set
            {
                healthMulti = value;
            }
        }

        // get and set for the energyMulti variable.
        public double EnergyMulti
        {
            get
            {
                return energyMulti;
            }
            set
            {
                energyMulti = value;
            }
        }

        // get and set for the attackMulti variable.
        public double AttackMulti
        {
            get
            {
                return attackMulti;
            }
            set
            {
                attackMulti = value;
            }
        }

        // get and set for the defenseMulti variable.
        public double DefenseMulti
        {
            get
            {
                return defenseMulti;
            }
            set
            {
                defenseMulti = value;
            }
        }

        // get and set for the speedMulti variable.
        public double SpeedMulti
        {
            get
            {
                return speedMulti;
            }
            set
            {
                speedMulti = value;
            }
        }

        // get and set for the attackRangeMulti variable.
        public double AttackRangeMulti
        {
            get
            {
                return attackRangeMulti;
            }
            set
            {
                attackRangeMulti = value;
            }
        }

        // get and set for the specialAttackMulti variable.
        public double SpecialAttackMulti
        {
            get
            {
                return specialAttackMulti;
            }
            set
            {
                specialAttackMulti = value;
            }
        }

        // get and set for the specialDefenseMulti variable.
        public double SpecialDefenseMulti
        {
            get
            {
                return specialDefenseMulti;
            }
            set
            {
                specialDefenseMulti = value;
            }
        }

        /**********************************************************************
         * Gets and sets for the Maximum Stats.
         * ********************************************************************
         */
        // get and set for the maxLevel variable.
        public int MaxLevel
        {
            get
            {
                return maxLevel;
            }
            set
            {
                maxLevel = value;
            }
        }

        // get and set for the maxHealth variable.
        public int MaxHealth
        {
            get
            {
                return maxHealth;
            }
            set
            {
                maxHealth = value;
            }
        }

        // get and set for the maxEnergy variable.
        public int MaxEnergy
        {
            get
            {
                return maxEnergy;
            }
            set
            {
                maxEnergy = value;
            }
        }

        // get and set for the maxAttack variable.
        public int MaxAttack
        {
            get
            {
                return maxAttack;
            }
            set
            {
                maxAttack = value;
            }
        }

        // get and set for the maxDefense variable.
        public int MaxDefense
        {
            get
            {
                return maxDefense;
            }
            set
            {
                maxDefense = value;
            }
        }

        // get and set for the maxSpeed variable.
        public int MaxSpeed
        {
            get
            {
                return maxSpeed;
            }
            set
            {
                maxSpeed = value;
            }
        }

        // get and set for the maxAttackRange variable.
        public int MaxAttackRange
        {
            get
            {
                return maxAttackRange;
            }
            set
            {
                maxAttackRange = value;
            }
        }

        // get and set for the maxSpecialAttack variable.
        public int MaxSpecialAttack
        {
            get
            {
                return maxSpecialAttack;
            }
            set
            {
                maxSpecialAttack = value;
            }
        }

        // get and set for the maxSpecialDefense variable.
        public int MaxSpecialDefense
        {
            get
            {
                return maxSpecialDefense;
            }
            set
            {
                maxSpecialDefense = value;
            }
        }

        /**********************************************************************
         * Get and sets for the Current Stats.
         * ********************************************************************
         */
        // get and set for the currentLevel variable.
        public int CurrentLevel
        {
            get
            {
                return currentLevel;
            }
            set
            {
                currentLevel = value;
            }
        }

        // get and set for the currentHealth variable.
        public int CurrentHealth
        {
            get
            {
                return currentHealth;
            }
            set
            {
                currentHealth = value;
            }
        }

        // get and set for the currentEnergy variable.
        public int CurrentEnergy
        {
            get
            {
                return currentEnergy;
            }
            set
            {
                currentEnergy = value;
            }
        }

        // get and set for the currentAttack variable.
        public int CurrentAttack
        {
            get
            {
                return currentAttack;
            }
            set
            {
                currentAttack = value;
            }
        }

        // get and set for the currentDefense variable.
        public int CurrentDefense
        {
            get
            {
                return currentDefense;
            }
            set
            {
                currentDefense = value;
            }
        }

        // get and set for the currentSpeed variable.
        public int CurrentSpeed
        {
            get
            {
                return currentSpeed;
            }
            set
            {
                currentSpeed = value;
            }
        }

        // get and set for the currentAttackRange variable.
        public int CurrentAttackRange
        {
            get
            {
                return currentAttackRange;
            }
            set
            {
                currentAttackRange = value;
            }
        }

        // get and set for the currentSpecialAttack variable.
        public int CurrentSpecialAttack
        {
            get
            {
                return currentSpecialAttack;
            }
            set
            {
                currentSpecialAttack = value;
            }
        }

        // get and set for the currentSpecialDefense variable.
        public int CurrentSpecialDefense
        {
            get
            {
                return currentSpecialDefense;
            }
            set
            {
                currentSpecialDefense = value;
            }
        }

        /**********************************************************************
         * Misc. Methods.
         * ********************************************************************
         */
        // returns the status of the turn for the character.
        public bool IsActive
        {
            get
            {//If these three are true, then the character is no longer active, 
             //change before returning the value.
                if (hasMovedOnTurn && hasAttackedOnTurn && hasUsedItemOnTurn) 
                    isActiveOnTurn = false;
                return isActiveOnTurn;
            }
            set
            {
                isActiveOnTurn = value;
                hasMovedOnTurn = !value;
                hasUsedItemOnTurn = !value;
                hasAttackedOnTurn = !value;
                //If isActiveOnTurn = true, hasMovedOnTurn, etc. = !true = false.
                //If we want to set isActive = true, then we're making the character completely 
                // available for a new turn, so the other variables need to be false
                //If we're setting isActive to false, we're ending their turn, so the other variables 
                // should be true for the purposes of the code, whether actually true or not.
            }
        }

        /**********************************************************************
         * For taking damage (when another character attacks you).
         * 
         * Calculates damage that should be applied to the character based on the 
         * opponent's attack and special attack stats, and the attack power of the attack they used
         * Character who's being attacked's defense is used "against" the opponent's attack, 
         * and their special defense is used against the opponent's special attack.
         * Checks if health is less than or equal to zero, so
         * ********************************************************************
         */
        public void ReceiveDamage(int opponentAttack, int opponentSpecialAttack, double attackPower)
        {
            //Damage calculating formula I made up off the top of my head. 
            //Almost definitely will need to be replaced/adjusted.
            int damage = (int)(((opponentAttack / currentDefense + 
                opponentSpecialAttack / currentSpecialDefense) * attackPower));

            currentHealth = currentHealth - damage;

            if (currentHealth <= 0)
            {
                //NEEDS TO BE DONE:
                //character dies *insert code here*
                //if hero, can't just set it to null, need it to be stored somewhere.
            }
        }

        // Prints out the variables for testing purposes.
        public String ToString()
        {
            String text;
            
            text = (
                "The Character " + name + "'s stats are the following:\n" +
                "\nCharacter is moveable: " + isActiveOnTurn +
                "\nCharacter moved this turn: " + hasMovedOnTurn +
                "\nCharacter attacked this turn: " + hasAttackedOnTurn +
                "\nCharacter used an item this turn: " + hasUsedItemOnTurn +
                "\nCharacter is active this turn: " + isActiveOnTurn +
                "\n8-bit picture: " + characterPicture + 

                "\n\n\nBase Stats:\n\n" +
                "Level: " + baseLevel + "\n" +
                "Health: " + baseHealth + "\n" +
                "Energy: " + baseEnergy + "\n" +
                "Attack: " + baseAttack + "\n" +
                "Defense: " + baseDefense + "\n" +
                "Speed: " + baseSpeed + "\n" +
                "Attack Range: " + baseAttackRange + "\n" +
                "Special Attack: " + baseSpecialAttack + "\n" +
                "Special Defense: " + baseSpecialDefense + "\n" +
                
                "\n\n\nMultiplier Stats:\n\n" +
                "Health: " + healthMulti + "\n" +
                "Energy: " + energyMulti + "\n" +
                "Attack: " + attackMulti + "\n" +
                "Defense: " + defenseMulti + "\n" +
                "Speed: " + speedMulti + "\n" +
                "Attack Range: " + attackRangeMulti + "\n" +
                "Special Attack: " + specialAttackMulti + "\n" +
                "Special Defense: " + specialDefenseMulti + 
                
                "\n\n\nMaximum Stats:\n\n" +
                "Health: " + maxHealth + "\n" +
                "Energy: " + maxEnergy + "\n" +
                "Attack: " + maxAttack + "\n" +
                "Defense: " + maxDefense + "\n" +
                "Speed: " + maxSpeed + "\n" +
                "Max Attack Range: " + maxAttackRange + "\n" +
                "Attack Range: " + maxAttackRange + "\n" +
                "Special Attack: " + maxSpecialAttack + "\n" +
                "Special Defense: " + maxSpecialDefense +
            
                "\n\n\nCurrent Stats:\n\n" +
                "Health: " + currentHealth + "\n" +
                "Energy: " + currentEnergy + "\n" +
                "Attack: " + currentAttack + "\n" +
                "Defense: " + currentDefense + "\n" +
                "Speed: " + currentSpeed + "\n" +
                "Attack Range: " + currentAttackRange + "\n" +
                "Special Attack: " + currentSpecialAttack + "\n" +
                "Special Defense: " + currentSpecialDefense);

            return text;
        }
    }
}