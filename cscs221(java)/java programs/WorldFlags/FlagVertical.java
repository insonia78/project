
/**
 * Write a description of class Flag here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
import wheels.users.*;
import java.awt.Color;
public class FlagVertical
{
      private Rectangle _leftStripe;
      private Rectangle _midStripe;
      private Rectangle _rightStripe;
      
      public FlagVertical (Color leftColor, Color midColor, Color rightColor, int x, int y, int length){
          _leftStripe = new Rectangle();
          _midStripe = new Rectangle();
          _rightStripe= new Rectangle();
          this.setColor(leftColor, midColor, rightColor);
          this.setSize(length, (length*5)/6);
          this.setOutlineColor(Color.BLACK);
          this.setRotation();
          this.setLocation(x,y);
          
      }
      public void setColor(Color color1, Color color2, Color color3){
          _leftStripe.setColor(color1);
          _midStripe.setColor(color2);
          _rightStripe.setColor(color3);
      }
      public void setOutlineColor(Color someColor){
          _leftStripe.setFrameColor(someColor);
          _midStripe.setFrameColor(someColor);
          _rightStripe.setFrameColor(someColor);
      }
      public void setSize (int length, int height){
          _leftStripe.setSize(length/3, height);
          _midStripe.setSize(length/3, height);
          _rightStripe.setSize(length/3, height);
      }
      public void setLocation(int x, int y){
          _leftStripe.setLocation(x,y);
          _midStripe.setLocation( x  , y + _leftStripe.getWidth() );
          _rightStripe.setLocation(x, _midStripe.getYLocation()+ _midStripe.getWidth() );
       }
       public void setRotation(){
       _leftStripe.setRotation(90);
       _midStripe.setRotation(90);
       _rightStripe.setRotation(90);
       }
}
