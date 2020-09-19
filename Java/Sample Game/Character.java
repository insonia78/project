
/**
 * This class holds basic status information for characters.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class Character
{
    // instance variables
    private String name;
    private int maxHealth;
    private int health;
    private int defense;
    private int attack;
    private int magicAttack;
    private int movementRadius;
    private int attackRadius;

    /**
     * Constructor for Hero characters.
     */
    public Character(String newName, int maxHP, int def, int atk, int mATK, int movRad, int atkRad)
    {
        init(newName, maxHP, def, atk, mATK, movRad, atkRad);
    }
    
    public void init(String nName, int mHP, int de, int at, int mat, int mRad, int aRad)
    {
        // initialise instance variables
        name = nName;
        maxHealth = mHP;
        health = maxHealth;
        defense = de;
        attack = at;
        magicAttack = mat;
        movementRadius = mRad;
        attackRadius = aRad;
    }
    
    public String getName()
    {
        return name;
    }
    
    public int getMaxHealth()
    {
        return maxHealth;
    }
    
    public int getHealth()
    {
        return health;
    }
    
    public void decreaseHealth(int dam)
    {
        health = (health - dam);
    }
    
    public int getDefense()
    {
        return defense;
    }
    
    public int getAttack()
    {
        return attack;
    }
    
    public int getMagicAttack()
    {
        return magicAttack;
    }
    
    public int getMovementRadius()
    {
        return movementRadius;
    }
    
    public int getAttackRadius()
    {
        return attackRadius;
    }
    
    public String toString()
    {
        String stats = "Character's stats\n\n" + 
            "Name:\t" + name + "\n" +
            "Maximum Health:\t" + maxHealth + "\n" +
            "Current Health:\t" + health + "\n" +
            "Defense:\t" + defense + "\n" +
            "Attack:\t" + attack + "\n" +
            "Magic Attack:\t" + magicAttack + "\n" +
            "Movement Radius:\t" + movementRadius + "\n" +
            "Attack Radius:\t" + attackRadius + "\n";

        return stats;
    }
}
