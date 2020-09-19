
/**
 * Write a description of class SnowPeople here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
import wheels.users.*;
public class  SnowPicture extends Frame{
    
    // instance variables - replace the example below with your own
    private Snowman _snowman;
    private Snowman _snowman2;
    private Hat _hat;
    private Hat _hat2;
    private Ellipse _sun;
    private ConversationBubble _bubble;
    private ConversationBubble _bubble2;
    
    public SnowPicture() {
         _snowman = new Snowman(10,240);
         _snowman2 = new Snowman( 200, 240);
         _hat = new Hat(_snowman);
         _hat2 = new Hat (_snowman2);
         
         _sun = new Ellipse(java.awt.Color.yellow);
         _sun.setLocation(300,40);
         _sun.setSize(60,60);
         
         _bubble = new ConversationBubble("Happy snow day!",ConversationBubble.TAIL_DIR_LEFT);
         _bubble2 = new ConversationBubble("Look! there is the sunshine!",ConversationBubble.TAIL_DIR_LEFT);
         _bubble.setLocation(110,110);
         _bubble2.setLocation(300,110);
        }
        public static void main(String[] args){
            SnowPicture picture = new SnowPicture();
        }
    }
   