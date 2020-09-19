
/**
 * Write a description of class NewItem here.
 * 
 * @author (Thomas Zangari) 
 * @version (11/27/2013)
 */
public class BoardGame extends Item{
    private String typeOfGame;
    
    public BoardGame(String what,String time,String game){
    super(what,time);
    this.typeOfGame = game;
    
    }
    public void print(){
    super.print();
    System.out.println("Type of game: " + typeOfGame);
    System.out.println();
    }
}
    