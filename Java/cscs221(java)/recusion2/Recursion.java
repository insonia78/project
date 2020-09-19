
/**
 * Write a description of class Recursion here.
 *
 * @author (your name)
 * @version (a version number or a date)
 */
public class Recursion
{
   

    public Recursion(){


       sub(3582);
    }
    public void sub(int n){
       System.out.println((n%10));

        if((n /10)!= 0 ){
            sub(n/10);
        }
        System.out.println(n%10);
    }
    public static void main(String[] args){
        new Recursion();
    }

}
