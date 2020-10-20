

package perscolars.java;
import java.util.Scanner;
import java.lang.Math;
public class main {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Scanner a  = new Scanner(System.in);
		
		System.out.println("Enter a value from 1 to 7 ");
		try
		{
			int value = a.nextInt();
			switch(value)
			{
			case 1:
			    System.out.println("Monday");
			     break;
			case 2:
			    System.out.println("Tuesday");
			     break;
			case 3:
			    System.out.println("Wednsday");
			     break;
			case 4:
			    System.out.println("Thursday");
			     break;
			case 5:
			    System.out.println("Friday");
			     break;
			case 6:
			    System.out.println("Saturday");
			     break;
			case 7:
			    System.out.println("Sunday");
			     break;
			default:
				System.out.println("Value not allowed");
			}
		}catch(Exception e)
		{
			System.out.println("invalid entry");
		}
	    try {
	    	System.out.println("Enter a value from 1 to 7");
	    	int value = a.nextInt();
	    	if(value >= 1 && value <= 7)
	    	{
	    		System.out.println("Your value is " + value);
	    	}
	    	
	    }catch(Exception e)
	    {
	    	System.out.println("value not allowed");
	    }
	    int max = 3; 
        int min = 0; 
        int range = max - min + 1;      
        int rand = (int)(Math.random() * range) + min;
        switch(rand)
        {
        case 0:
        	System.out.println("Hearts");
        	break;
        case 1:
        	System.out.println("Clubs");
        	break;
        case 2:
        	System.out.println("Spades");
        	break;
        case 3:
        	System.out.println("Diamonds");
        	break;
        }
        for(int i = 0 ; i < 100; i += 5)
		{
			System.out.println(i);
		}
        for(int i = 100; i > 1; i -= 10)
        {
        	System.out.println(i);
        }
       
	}
	
}
