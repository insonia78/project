
/**
 * Write a description of class ComplesNumberApp here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
import java.text.DecimalFormat;
public class ComplexNumberApp
{
    DecimalFormat format = new DecimalFormat("0.000");
    public ComplexNumberApp()
    {
        // creating the object
        Complex ts1 = new Complex(3,2);
        Complex ts2 = new Complex (0,0);
        Complex ts3 = new Complex (1,1);
        Complex ts4 = new Complex(1,-1);
        Complex ts5 = new Complex(0,5);
        Complex ts6 = new Complex(5,0);
        Complex c1 = ts1;
        Complex c2 = ts2;
        Complex c3 = new Complex(2,1);
        Complex c4 = new Complex(0,1);
        Complex c5 = new Complex(1,1);
        Complex c6 = new Complex(-1,-1);
        Complex c7 = new Complex(0,-1);
        Complex c8 = new Complex(-1,0);
        Complex c9 = c1.add(c6);
        
        // printing the onbjects
        System.out.println(ts1.toString());
        System.out.println(ts2.toString());
        System.out.println(ts3.toString());
        System.out.println(ts4.toString());
        System.out.println(ts5.toString());
        System.out.println(ts6.toString());
        System.out.println("The magnitude of c1 = " + format.format(c1.findMagnitude()));
        System.out.println("c1 = "+c1.toString());
        System.out.println("c2 = "+c2.toString());
        System.out.println("c3 = "+c3.toString());
        System.out.println("c4 = "+c4.toString());
        System.out.println("c5 = "+c5.toString());
        System.out.println("c6 = "+c6.toString());
        System.out.println("c7 = "+c7.toString());
        System.out.println("c8 = "+c8.toString());
        System.out.println("c1 + c6 = c9 = " + c1.add(c6));
        System.out.println("c1 - c6 =" + c1.subtract(c6));
        System.out.println("c1 times c6 ="+ c1.multiply(c6));
        System.out.println("c1 and c2 are equal is " + c1.equals(c2));
        System.out.println("c3 and c9 are equal is " + c3.equals(c9));
    }
    public static void main(String[] args)
    {
        new ComplexNumberApp();
    }

    
}
