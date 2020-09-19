
/**
 * Write a description of class Archer here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class ArcherJob extends Character
{
    // instance variables - replace the example below with your own

    /**
     * Constructor for objects of class Archer
     */
    public ArcherJob()
    {
        // initialise instance variables
        super("Troll", 350, 25, 95, 0, 5, 12);
    }
    
    public ArcherJob(String newName)
    {
        // initialise instance variables
        super(newName, 350, 25, 95, 0, 5, 12);
    }
    
    public String toString()
    {
        String stats = "Character's stats\n\n" + 
            "Name:\t" + super.getName() + "\n" +
            "Job Role:\t" + "Archer" + "\n" +
            "Maximum Health:\t" + super.getMaxHealth() + "\n" +
            "Current Health:\t" + super.getHealth() + "\n" +
            "Defense:\t" + super.getDefense() + "\n" +
            "Attack:\t" + super.getAttack() + "\n" +
            "Movement Radius:\t" + super.getMovementRadius() + "\n" +
            "Attack Radius:\t" + super.getAttackRadius() + "\n";

        return stats;
    }
}
