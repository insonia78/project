
/**
 * This class starts the game ofcourse and creates the heros.
 * then takes you to the worldmap
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class StartGame
{
    // instance variables - replace the example below with your own
    private String title;   // title of the game
    private String start; // displays the start prompt.
    private Dungeon level;

    /**
     * creates the title and displays it
     */
    public StartGame()
    {
        init();
    }
    
    public void init()
    {
        WarriorJob hero1 = new WarriorJob("Leonardo");
        HealerJob hero2 = new HealerJob("Michelangelo");
        ThiefJob hero3 = new ThiefJob("Raphael");
        ArcherJob hero4 = new ArcherJob("Donatello");
        
        level = new Dungeon(hero1, hero2, hero3, hero4);
    }
}
