
/**
 * This will create the game board and show that you can place subclasses of another class onto
 * the spaces on the board and still be able to use their methods.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class Dungeon
{
    // instance variables - replace the example below with your own
    Board map;

    /**
     * Constructor for objects of class Dungeon
     */
    public Dungeon(Character first, Character second, Character third, Character fourth)
    {
        init(first, second, third, fourth);
        battleTest();
    }
    
    public void init(Character hOne, Character hTwo, Character hThree, Character hFour)
    {
        // initialise instance variables
        map = new Board(20, 20);

        WarriorJob orc = new WarriorJob();
        HealerJob pixie = new HealerJob();
        ArcherJob troll = new ArcherJob();
        ArcherJob troll2 = new ArcherJob();

        // place enemies
        map.getLayout()[19][0].placeCharacter(orc);
        map.getLayout()[18][1].placeCharacter(troll);
        map.getLayout()[19][2].placeCharacter(pixie);
        map.getLayout()[18][3].placeCharacter(troll2);

        // place heros
        map.getLayout()[1][0].placeCharacter(hOne);
        map.getLayout()[0][1].placeCharacter(hTwo);
        map.getLayout()[1][2].placeCharacter(hThree);
        map.getLayout()[0][3].placeCharacter(hFour);

        // test to show there are characters on these spots.
        System.out.println(map.getLayout()[18][1].toString()); // troll here
        System.out.println(map.getLayout()[10][10].toString()); // empty space
        System.out.println(map.getLayout()[1][2].toString()); // thief here
        System.out.println(map.getLayout()[5][5].toString()); // empty space
    }

    public void battleTest()
    {
        // test the battle between two characters.
        // pixie hits the thief in this example. 
        // variables are made for an easier to read S.O.P.
        // 95 - 25 means the troll will hit the thief for 70 damage.
        Character aggressor = map.getLayout()[18][1].getPerson(); 
        Character defender = map.getLayout()[1][2].getPerson();
        int damage = aggressor.getAttack() - defender.getDefense();

        // health of the thief has been decreased and current hp has been updated.
        defender.decreaseHealth(damage);

        // Message to test the math between the two subclasses.
        System.out.println( aggressor.getName() + " hits " + defender.getName() + " for an amount of " +
            damage + " damage! " + defender.getName() + " now has " + defender.getHealth() + " health.\n" );

        // Thief's updated status.
        System.out.println(defender.toString());
    }
}
