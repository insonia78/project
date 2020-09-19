
/**
 * Write a description of class Recursion here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class Recursion
{
    // instance variables - replace the example below with your own
    public static void main (String[] args){
        System.out.println(mystery(0));
    }
    public static int mystery(int n)
    {
        System.out.println("method call " +n);
        if (n > 6){
         System.out.println("return " + n);   
        return n -3;
        }else{
       //  System.out.print(3 * mystery(n-1));
       // System.out.println(":" + n +"factorial" +n+"-1");    
        return n+ mystery (n +1);
         
    }
    }
}
