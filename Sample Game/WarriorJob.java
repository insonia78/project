
/**
 * Warrior initial stats
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class WarriorJob extends Character
{
    // instance variables - replace the example below with your own

    /**
     * Constructor for objects of class Warrior
     */
    public WarriorJob()
    {
        super("Orc", 1000, 100, 75, 0, 4, 1);
    }

    public WarriorJob(String newName)
    {
        // initialise instance variables
        super(newName, 1000, 100, 75, 0, 4, 1);
    }

    public String toString()
    {
        String stats = "Character's stats\n\n" + 
            "Name:\t" + super.getName() + "\n" +
            "Job Role:\t" + "Warrior" + "\n" +
            "Maximum Health:\t" + super.getMaxHealth() + "\n" +
            "Current Health:\t" + super.getHealth() + "\n" +
            "Defense:\t" + super.getDefense() + "\n" +
            "Attack:\t" + super.getAttack() + "\n" +
            "Movement Radius:\t" + super.getMovementRadius() + "\n" +
            "Attack Radius:\t" + super.getAttackRadius() + "\n";

        return stats;
    }
}
