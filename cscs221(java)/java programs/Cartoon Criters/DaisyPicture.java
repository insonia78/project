
/**
 * Write a description of class SnowPeople here.
 * 
 * @author (thomas zangari) 
 * @version (11/19/2013)
 */
import wheels.users.*;
public class  DaisyPicture extends Frame{
    
    // instance variables - replace the example below with your own
    private Rectangle _stem;
    private Daisy _daisy1,_daisy2,_daisy3;
    
    private Ellipse _sun;
    private ConversationBubble _bubble1;
    private ConversationBubble _bubble2;
    private ConversationBubble _bubble3;
    public DaisyPicture() {
         _daisy1 = new Daisy(70,240);
         _daisy2 = new Daisy( 285, 240);
         _daisy3 = new Daisy (500,240);
                  
         _sun = new Ellipse(java.awt.Color.yellow);
         _sun.setLocation(300,40);
         _sun.setSize(60,60);
         
         _bubble1 = new ConversationBubble("What a beautiful day!",ConversationBubble.TAIL_DIR_LEFT);
         _bubble2 = new ConversationBubble("Look! there is the sunshine!",ConversationBubble.TAIL_DIR_LEFT);
         _bubble3 = new ConversationBubble("And is nice and warm!",ConversationBubble.TAIL_DIR_LEFT);
         _bubble1.setLocation(70,110);
         _bubble2.setLocation(300,110);
         _bubble3.setLocation(500,110);
        }
        public static void main(String[] args){
            DaisyPicture picture = new DaisyPicture();
        }
    }
   