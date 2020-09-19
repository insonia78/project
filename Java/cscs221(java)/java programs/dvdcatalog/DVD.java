
/**
 * Write a description of class DVD here.
 * 
 * @author (Thomas Zangari) 
 * @version (a version number or a date)
 */
public class DVD extends Item
{
    private String director;
    
    public DVD(String what, int time, String who){
        super(what, time);
        this.director = who;
    }
    public void print(){
        super.print();
        System.out.println("Director: "  + director);
        System.out.println();
    }
}
