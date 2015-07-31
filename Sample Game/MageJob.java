
/**
 * Write a description of class Mage here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class MageJob extends Character
{
    // instance variables - replace the example below with your own

    /**
     * Constructor for objects of class Mage
     */
    public MageJob()
    {
        super("Wizard", 500, 20, 10, 120, 4, 8);
    }

    public MageJob(String newName)
    {
        // initialise instance variables
        super(newName, 500, 20, 10, 120, 4, 8);
    }

    public String toString()
    {
        String stats = "Character's stats\n\n" + 
            "Name:\t" + super.getName() + "\n" +
            "Job Role:\t" + "Mage" + "\n" +
            "Maximum Health:\t" + super.getMaxHealth() + "\n" +
            "Current Health:\t" + super.getHealth() + "\n" +
            "Defense:\t" + super.getDefense() + "\n" +
            "Attack:\t" + super.getAttack() + "\n" +
            "Magic Attack:\t" + super.getMagicAttack() + "\n" +
            "Movement Radius:\t" + super.getMovementRadius() + "\n" +
            "Attack Radius:\t" + super.getAttackRadius() + "\n";

        return stats;
    }
}
