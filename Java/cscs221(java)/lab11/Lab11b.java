

/**
 * This Class determinse if a phrase is a palindrome or not .
 *
 * @author (Thomas Zangari)
 * @version (a version number or a date)
 */
import java.util.*;
public class Lab11b
{
	/**
	  Main method that answers if the phrase is a palindrome or not
	  */

	public static void main(String[] args) {
	    char answer1 = 'y';

	   while(answer1 == 'y'){
	    Scanner kbd = new Scanner(System.in);
	    System.out.println("Enter the phrase that you want to test");
	    String string =kbd.nextLine() ;

	    // if recursive stament that computes the palindrome
	    if (isPalindrome(string)) {
	      System.out.println("It IS a palindrome!");
	    } else {
	      System.out.println("It is NOT a palindrome!");
	    }
	    System.out.println();
	    int count = wordCount(string); // variable that hols the return value of the wordCount method
	    avarageWordCount(string, count);
	    System.out.println("");
	    System.out.println("Do you want to continue (press y for yes or n for no)");
	    String answer = kbd.nextLine();
	    answer1 = answer.charAt(0);

	   }
  }
  /**
     This method test if the phrase is a palindrome or not
   */

   public static boolean isPalindrome(String stringToTest) {
    String workingCopy = removeJunk(stringToTest);
    String reversedCopy = reverse(workingCopy);

    return reversedCopy.equalsIgnoreCase(workingCopy);
  }
  /**
    This method creates a stringbuffer of the phrase
  */
  public static String removeJunk(String string) {
    int len = string.length();
    StringBuffer dest = new StringBuffer(len);
    char c;

    for (int i = (len - 1); i >= 0; i--) {
      c = string.charAt(i);
      if (Character.isLetterOrDigit(c)) {
        dest.append(c);
      }
    }

    return dest.toString();
  }
  /**
    Getting the reverse of the phrase
    */
  public static String reverse(String string) {
    StringBuffer sb = new StringBuffer(string);

     //Causes this character sequence to be replaced by the reverse of the sequence.
     return sb.reverse().toString();
  }
  /**
  this methid counts the words in each phrase
  */
  public static int wordCount(String string){

        int count = 0; // variable that holds the counting words from each space


        for(int i = 0 ; i < string.length(); i++)
        {
           if(string.charAt(i) == ' ')
           {
  			 count++;
  	      }

  	  }
  	  count++;//variable that counts the last space
  	    System.out.println("The lenght of the phrase is:" + count);
  	   return count;
  }
  /**
    this methos computes the avarage count of each phrase
    */
   public static void avarageWordCount(String string, int count){
	    int countW = 0; // variable that holds the counting characters

	    for(int i = 0 ; i < string.length(); i++){
	   if(string.charAt(i) == ' '){}
	    else{
			countW++;
		}
	}
        double average =(double)countW/count;
  	    System.out.printf("the average word count %.3f",average);
  	    System.out.println("");
   }

}
