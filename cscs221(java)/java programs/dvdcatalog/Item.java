
/**
 * Write a description of class Item here.
 * 
 * @author (Thomas Zangari) 
 * @version (11/27/2013)
 */
import java.util.*;

public class Item
{
    private String title;
    private String time;
    private int playingTime;
    private boolean gotIt;
    
    public Item(){
               
    }
    public Item(String s,int playingTime){
        this.title = s;
        this.playingTime = playingTime;
       
    }
    public Item(String s,String time){
        this.title = s;
        this.time = time;
    }
    public void setOwn(int answer){
     if(answer == 1){
         this.gotIt = true;
     }
     else{
         this.gotIt = false;
        }
    
    }
    public void print(){
          if(time == time){
           System.out.println("Title: " + title);
           System.out.println("If you own it press 1");
             int answer = this.getUserInput();
             this.setOwn(answer);
           System.out.println("Playing time: " + time);
           System.out.println("Owned by me: " + gotIt);
         }
         else if(playingTime == playingTime){
           
           System.out.println("Title: " + title);
           System.out.println("Playing time: " + playingTime);
           System.out.println("Owned by me: " + gotIt);
        }
    }
            
    
    public int getUserInput(){
               Scanner kbd = new Scanner(System.in);
               return kbd.nextInt();
    }
    
}
