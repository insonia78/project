
// ***********************SmartArrayTester*************
import java.util.Scanner;

/**
 * This class is designed to test the SmartArray methods,
 * especially the alternating sum.
 * @author <your name>, modified from CS201 code
 * @version October 23, 2013
 */

public class SmartArrayTester {
    private static final int LIST_SIZE = 15;
    private SmartArray _list;

    public SmartArrayTester() {
        _list = new SmartArray(LIST_SIZE);
    }
    public void start(){
        _list.display();
        this.getUserValues();
        _list.display();
        int result = _list.alternatingSum();
        System.out.println("The alternating sum is: " + result);
        this.getLinearSearch();
    }
    public void getUserValues(){
        int input;
        Scanner kbd = new Scanner(System.in);
        for (int i = 0; i < _list.getLength(); i++){
            System.out.println("Enter a number: ");
            input = kbd.nextInt();
            _list.addValue(input, i);
        }
	}
     public void getLinearSearch(){

		 int value;
		 int returnValue = 0;
		 String answer;
		 char answer1;
		 Scanner kbd = new Scanner(System.in);
		 System.out.print("do you want to search for a value?(Press y for yes or n for no): ");
		 answer1 = _list.getUserChoice();

		   while (answer1 == 'Y' || answer1 == 'y'){
			 System.out.print("What value do you want to search?: ");
			 value = kbd.nextInt();
			 returnValue = _list.linearSearch(value);

		     if (returnValue != -1){
			     System.out.println("the value is found and is located at position number " +returnValue+ " of the array.");
		     }
		     else {

		         System.out.print("the value was not found");
		         System.out.println();
		     }
		     System.out.println();
		     System.out.print("do you want to search for another value?(Press y for yes or n for no): ");
		     answer1 = _list.getUserChoice();
		 }
		 System.out.println();
		 System.out.print("Do you want to know the MAX value of the array?(Press y for yes or n for no): ");
		 answer1=_list.getUserChoice();
		 int max = _list.getMaxValue();
		 if(answer1 == 'Y' || answer1 == 'y'){
		   System.out.print("the max value is: " + max);
	      }
	     System.out.println();
	     System.out.println();
	     System.out.print("Do you want to know the MINIMUM value of the array?(Press y for yes or n for no): ");
		 answer1=_list.getUserChoice();
		 int min = _list.getMinValue();
		 if(answer1 == 'Y' || answer1 == 'y'){
		    System.out.print("the minimum value is: " + min);
	      }
	      System.out.println();




	 }





    public static void main(String[] args){
        SmartArrayTester test = new SmartArrayTester();
        test.start();
     }

}
// ************************end of Lab 4 code ******************
