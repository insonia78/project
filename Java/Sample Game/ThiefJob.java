
/**
 * Thief initial stats.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class ThiefJob extends Character
{
    // instance variables - replace the example below with your own

    /**
     * Constructor for objects of class Thief
     */
    public ThiefJob()
    {
        super("Goblin", 300, 25, 80, 0, 15, 1);
    }

    public ThiefJob(String newName)
    {
        // initialise instance variables
        super(newName, 300, 25, 80, 0, 15, 1);
    }
    
    public String toString()
    {
        String stats = "Character's stats\n\n" + 
            "Name:\t" + super.getName() + "\n" +
            "Job Role:\t" + "Thief" + "\n" +
            "Maximum Health:\t" + super.getMaxHealth() + "\n" +
            "Current Health:\t" + super.getHealth() + "\n" +
            "Defense:\t" + super.getDefense() + "\n" +
            "Attack:\t" + super.getAttack() + "\n" +
            "Movement Radius:\t" + super.getMovementRadius() + "\n" +
            "Attack Radius:\t" + super.getAttackRadius() + "\n";

        return stats;
    }
}
