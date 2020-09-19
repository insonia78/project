
/**
 * Write a description of class FlagPicture here.
 * 
 * @author (Thomas Zangari) 
 * @version (11/6/2013)
 */
import java.awt.Color;
import wheels.users.*;
public class FlagPicture extends Frame{

    private Flag _frenchFlag,
            _ivoryCoastFlag,
            _chadFlag,
            _bigFrenchFlag,
            _italianFlag;
            FlagVertical _frenchFlagVertical,
            _ivoryCoastFlagVertical,
            _chadFlagVertical,
            _bigFrenchFlagVertical,
            _italianFlagVertical,
            _netherlandsFlag;
            
   public FlagPicture(){
       _frenchFlag = new Flag(Color.BLUE, Color.WHITE, Color.RED, 10, 10,60);
       _ivoryCoastFlag =
       new Flag(new Color(255,200, 0),Color.WHITE, Color.GREEN, 10,180, 80);
       _chadFlag = new Flag(Color.BLUE, Color.YELLOW, Color.RED, 10, 90, 100);
       _bigFrenchFlag = new Flag (Color.BLUE, Color.WHITE, Color.RED ,10, 270,120);
       _italianFlag = new Flag (Color.GREEN,Color.WHITE,Color.RED, 10, 400,80); 
       
       _frenchFlagVertical = new FlagVertical(Color.BLUE, Color.WHITE, Color.RED, 200, 10,60);
       _ivoryCoastFlagVertical =
       new FlagVertical(new Color(255,200, 0),Color.WHITE, Color.GREEN, 200,180, 80);
       _chadFlagVertical = new FlagVertical(Color.BLUE, Color.YELLOW, Color.RED, 200, 90, 80);
       _bigFrenchFlagVertical = new FlagVertical (Color.BLUE, Color.WHITE, Color.RED ,200, 270,80);
       _italianFlagVertical = new FlagVertical (Color.GREEN,Color.WHITE,Color.RED, 200, 400,80);
       _netherlandsFlag = new FlagVertical(Color.RED,Color.WHITE,Color.BLUE,400,90,120);
    }
    
    public static void main(String[] args) {
       FlagPicture picture = new FlagPicture();
    }
}
