
/**
 * Write a description of class Tile here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class Tile
{
    // instance variables - replace the example below with your own
    Character person;
    
    /**
     * Constructor for objects of class Tile
     */
    public Tile()
    {
        init();
    }

    public void init()
    {
        // initialise instance variables
        person = null;
    }
    
    public void placeCharacter(Character pers)
    {
        person = pers;
    }
    
    public Character getPerson()
    {
        return person;
    }
    
    public String toString()
    {
        if(person == null)
        {
            return "There is no one occupying this spot.\n";
        }
        else
        {
            return person.toString();
        }
    }
}
