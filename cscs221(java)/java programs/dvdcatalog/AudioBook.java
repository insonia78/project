
/**
 * Write a description of class AudioBook here.
 * 
 * @author (Thomas Zangari) 
 * @version (11/27/2013)
 */
public class AudioBook extends Item
{
   private String author;
   private String reader;
   
   public AudioBook(String s, int playingTime, String who, String who2){
       super(s, playingTime);
       this.author = who;
       this.reader = who2;
    }
    public void print(){
        super.print();
        System.out.println("Author: " + author);
        System.out.println("Reader: " + reader);
        System.out.println();
    }
}
