
/**
 * Write a description of class Hat here.
 * 
 * @author (Thomas Zangari) 
 * @version (11/13/2013)
 */
import wheels.users.*;
import java.awt.Color;
public class Hat
{
    // instance variables - replace the example below with your own
    private Rectangle _hatBrim;
    private Rectangle _hatUpper;
    
    public Hat(Snowman mySnowman) {
        _hatBrim = new Rectangle();
        _hatUpper = new Rectangle();
        
        this.setColor(Color.BLACK);
        this.setSize(60,60);
        this.setLocation(mySnowman.getX() + 10, mySnowman.getY() - 60);
    }
    public void setColor(Color c){
        _hatBrim.setColor(c);
        _hatUpper.setColor(c);
    }
    public void setSize(int w,int h){
        _hatUpper.setSize(w, h);
        _hatBrim.setSize((w*4)/3,h/3);
    }
    public void setLocation(int x, int y){
         _hatBrim.setLocation(x, y + 50);
         _hatUpper.setLocation(x + 10, y);
    }
}
