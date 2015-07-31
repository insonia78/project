
/**
 * Write a description of class Database here.
 * 
 * @author (Thomas Zangari) 
 * @version (11/27/2013)
 */
import java.util.*;

public class Database
{
    private Item[] list;
    private int DB_SIZE = 6;
    
    
    public Database(){
        this.list = new Item[DB_SIZE];
        this.list[0] = new AudioBook("Master and Commander", 1008,
                                      "Patrick O'Brien", "Simon Vance");
        this.list[1] = new DVD("Citizen Kane", 119,"Orson Welles");
        this.list[2] = new DVD("The Godfather",172,"Francis Ford Coppola");
        this.list[3] = new AudioBook("Ender's Game",682,"Orson Scott Card",
                                     "Stefan Rudnicki, Harlan Ellison");
        this.list[4] = new BoardGame("Chess","As need it ","Board Game");
        this.list[5] = new BoardGame("Chechers","As need it","Board Game");
    }
    public void start(){
        for (int i = 0; i< DB_SIZE;i++){
             this.list[i].print();
             
        }
    }
    public int getUserInput(){
        Scanner kbd = new Scanner(System.in);
        return kbd.nextInt();
    }
    public static void main(String[] args){
        Database db = new Database();
        db.start();
    }
}