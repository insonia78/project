//program written by Thomas Zangari java class COMI1510 summer 2013 AJ3.

import java.util.Scanner; // scanner method for input/output
import java.util.Random; // random method for generating the random number for the program
/**
  This program is a random number generated game. The computer generates a random number
  in a range of 1 throw 100, the user has 7 chances to guess the number and then asks if
  the user want's to play again.Ones the user choose no the program finishes.
  The program is developed in a do-while with a nested for-loop that iterates 7 time
  structured with  if, else-if statements.It holds an extra if else statement in the do
  while loop to recuperate the last iteration result.
  */
public class AssignmentN3
{
	public static void main(String[] args)
	{
		/**
		  Constant values of the program
	    */

		final int MAX_INTERETION = 7;      // constant value for the number of iteration of the for loop
		final  int OVER_RANDOM_VALUE = 100; // constant value for the user choice over the range of 100
        final  int UNDER_RANDOM_VALUE = 1;  // constant value for the user choice under the range of 1

        /**
         variables of the program
        */

	    int random1;  // variable that olds the random computer generated number
	    int userNumber; // variable that holds the user number choice
	    int number;     // variable that holds the number of iteration of the for loop
	    String answer;  // variable that holds the user answer if he wants to continue the game
        char answer1;   // the character of the answer variable
        boolean error;
        error = false;
        /**
          the do-while loop of the program holding the extra if-else statement, the
          scanner object ,the random object and the selection
          of the user if he wants to continue to play
        */

        System.out.println("Thomas Zangari\n"); // My name

        do
	    {

			System.out.println("\nNEW GAME\n\n");

            Scanner keyboard = new Scanner(System.in); // scanner object for inputoutput

    	    Random randomNumbers = new Random();

		    random1 = randomNumbers.nextInt(100)+1; // random selection in the range of
		                                            // 1 through 100

	        System.out.print("Your guess(1-100): "); // user number input
		    userNumber = keyboard.nextInt();

            /**
              for loop with if else-if statements for evaluating the user choice number,
              and to ask the user to re-enter a number
            */

		    for (number=1;number < MAX_INTERETION ;number++)
	        {
				if (random1 == userNumber)  // when the user choice number matches the
				                            // random number displaying the random number
				                            // and the number of integration that it took
				{
					System.out.print("\nCorrect!! The magic number is: "+ random1 + "\nYou got it in "+ number + " guesses\n");
					number +=MAX_INTERETION + 1; //  operation statement to get out the for loop
				}

				else if ( userNumber > OVER_RANDOM_VALUE) //when the user choice over
				                                           //exceed the computer random number

				{
						System.out.print("\nInvalid guess. Guess again (1-100): ");
		                userNumber = keyboard.nextInt();   //user re-enters the number
			    }
			    else if ( userNumber < UNDER_RANDOM_VALUE) // when the user choice under
			                                               // execeed the computer random number
    			{
						System.out.print("\nInvalid guess. Guess again (1-100): ");
		                userNumber = keyboard.nextInt();// user re-enters the number
			    }
				else if (random1 > userNumber) // random number over exceed the user choice
				{
				    	System.out.println("To LOW\n");
				        System.out.print("Your guess(1-100): ");
				    	userNumber = keyboard.nextInt(); // user re-enters the number
			    }
				else      // default the user choice over exceed the random number
				{
						System.out.println("To HIGH\n");
						System.out.print("Your guess(1-100): ");
						userNumber = keyboard.nextInt();
		        }

			}
			/**
			  if statement for evaluating the last iteration of the for-loop
			*/

			if ( number == MAX_INTERETION)
	    	    if (random1 == userNumber) // if user choice equals the random number
	    	                               // displaying the random number and the number
	    	                               // of iteration that it took
	    	    {
		    		System.out.print("\nCORRECT!! The magic number is: "+ random1 + "\nYou got it in "+ number + " guesses\n");
		    	}
	    		else // if user choice does not equals the number
	    	    {
	    		 	System.out.print("\nSORRY!! The magic number is: " + random1+ "\n\n");
			    }

			 System.out.print("\nAnother Game (Y/N)");
		     answer = keyboard.nextLine();
		     answer = keyboard.nextLine();
		     answer1 = answer.charAt(0);




		}while (answer1 == 'Y' || answer1 == 'y' );// do while loop asking if the user
		                                           // wants to replay the game
	}

}

/**
Thomas Zangari


NEW GAME


Your guess(1-100): 50
To HIGH

Your guess(1-100): 25
To HIGH

Your guess(1-100): 15
To LOW

Your guess(1-100): 20
To LOW

Your guess(1-100): 23

Correct!! The magic number is : 23
You got it in 5 guesses

Another Game (Y/N) y

NEW GAME


Your guess(1-100): 100
To HIGH

Your guess(1-100): 20
To HIGH

Your guess(1-100): 101

Invalid guess. Guess again (1-100): 101

Invalid guess. Guess again (1-100): -1

Invalid guess. Guess again (1-100): 20
To HIGH

Your guess(1-100): 20

SORRY!! The magic number is: 3


Another Game (Y/N) n

*/



