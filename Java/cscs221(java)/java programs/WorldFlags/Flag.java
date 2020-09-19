
/**
 * Write a description of class Flag here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
import wheels.users.*;
import java.awt.Color;
public class Flag
{
      private Rectangle _leftStripe;
      private Rectangle _midStripe;
      private Rectangle _rightStripe;
      
      public Flag (Color leftColor, Color midColor, Color rightColor, int x, int y, int width){
          _leftStripe = new Rectangle();
          _midStripe = new Rectangle();
          _rightStripe= new Rectangle();
          this.setColor(leftColor, midColor, rightColor);
          this.setSize(width, (width*5)/6);
          this.setOutlineColor(Color.BLACK);
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
      public void setSize (int width, int height){
          _leftStripe.setSize(width/3, height);
          _midStripe.setSize(width/3, height);
          _rightStripe.setSize(width/3, height);
      }
      public void setLocation(int x, int y){
          _leftStripe.setLocation(x,y);
          _midStripe.setLocation(x + _leftStripe.getWidth(), y);
          _rightStripe.setLocation(_midStripe.getXLocation() + _midStripe.getWidth(), y);
       }
        
}
