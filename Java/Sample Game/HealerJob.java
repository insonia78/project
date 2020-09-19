
/**
 * healer initial stats.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class HealerJob extends Character
{
    // instance variables - replace the example below with your own

    /**
     * Constructor for objects of class Thief
     */
    public HealerJob()
    {
        super("Pixie",500, 20, 10, 120, 4, 1);
    }
    
    public HealerJob(String newName)
    {
        super(newName, 500, 20, 10, 120, 4, 1);
    }

    public String toString()
    {
        String stats = "Character's stats\n\n" + 
            "Name:\t" + super.getName() + "\n" +
            "Job Role:\t" + "Healer" + "\n" +
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
