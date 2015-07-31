import javax.swing.JOptionPane;
import java.util.Random;

// KJ this is the solution to problem 17 on page 294 of the Addis text.
// Your assignment is to insert good Java doc in front of the class and
// before each method.


/**
 this program is a rockPaperScissors. The game askes the user to input
 a String: Rock, Paper,or Scissors and then evaluates the user choice with
 the computer choice for a winner.
 */

public class RockPaperScissors
{
   public static void main(String[] args)
   {
		String computer;
		String user;

		// Get the computer's choice.
		computer = computerChoice();

		// Get the user's choice.
		user = userChoice();

		// Determine the winner.
		determineWinner(computer, user);

		// Exit the program.
		System.exit(0);
	}
	// KJ Javadoc should line up with the code for the method. Indent
   /**
   The computerChoice method returns the computer choice after generating a random
   number in the value of 1 to 3.
   @return  Returns Rock,Papper,or Scissors  choice of the computer
   */
	public static String computerChoice()
	{
		// Variable to hold the computer's choice.
		String choice;

      // Create a Random object.
      Random rand = new Random();

      // Generate a random number in the range of
		// 1 through 3.
      int num = rand.nextInt(3) + 1;

		// Determine the computer's choice where
		// 1=rock, 2=paper, and 3=scissors.
  		if (num == 1)
			choice = "rock";
		else if (num == 2)
			choice = "paper";
		else
			choice = "scissors";

		// Return the computer's choice.
		return choice;
	}
	// KJ The first sentence should describe the method itself, not focus on what
	// it returns. It should also name the method. Like this:
	// The userChoice method gets the user's choice and validates it.
   /**
    The userChoice method gets the user choice of Rock,Papper,Scissors
    @return It returns the user input
   */
	public static String userChoice()
	{
		// Variable to hold the user's input.
      String input;

		// Get the user's choice.
      input = JOptionPane.showInputDialog(
          "Enter your choice of rock, paper, or scissors.");

		// Validate the choice.
		while (!isValidChoice(input))
		{
			// Get the user's choice.
      	input = JOptionPane.showInputDialog(
         	 "Please enter rock, paper, or scissors.");
		}

		// Return the user's choice.
		return input;
	}
	// KJ Same here. Don't say what it returns in the first sentence. Say what it does. Name the method.
	// The @return tag should say when it returns true and when false.
	/**
	The isValidChoice method is a boolean method that validates the computer and the users choice.
	@param choice The choice of the user or the computer
	@return The boolean true when the choice is valid, false when the choice is not valid.
	*/
	public static boolean isValidChoice(String choice)
	{
		// Variable to hold the validation result.
		boolean valid;

		if (choice.equalsIgnoreCase("rock")  ||
		    choice.equalsIgnoreCase("paper") ||
			 choice.equalsIgnoreCase("scissors"))
		{
			valid = true;
		}
		else
		{
			valid = false;
		}

		// Return the validation result.
		return valid;
	}
	// KJ The description needs work. The  method's main purpose is not to display the
	// user and computer choice. It's to display the winner!
	// Name the method.
	/**
	The determineWinner method decides and displays who the winner is.
	@param computer The computer choice of the game
	@param user the user choice of the game
	*/
	public static void determineWinner(String computer, String user)
	{
		// String to hold the output.
		String output;

		// Start building the output string with the computer's
		// and the user's choices.
		output =  "Computer's choice: " + computer + "\n";
		output += "Your choice: " + user + "\n";

		// Determine the winner and continue building the
		// output string.
    	if (user.equalsIgnoreCase("rock"))
    	{
        if (computer.equalsIgnoreCase("scissors"))
            output += "YOU win! Rock smashes scissors.";
        else if (computer.equalsIgnoreCase("paper"))
            output += "Computer wins! Paper wraps rock.";
        else
            output += "Tie. No winner.";
    	}
    	else if (user.equalsIgnoreCase("paper"))
    	{
        	if (computer.equalsIgnoreCase("scissors"))
            output += "Computer wins! Scissors cut paper.";
        	else if (computer.equalsIgnoreCase("rock"))
            output += "YOU win! Paper wraps rock.";
        else
            output += "Tie. No winner.";
    	}
    	else if (user.equalsIgnoreCase("scissors"))
    	{
        	if (computer.equalsIgnoreCase("rock"))
            output += "Computer win! Rock smashes scissors.";
        else if (computer.equalsIgnoreCase("paper"))
            output += "YOU win! Scissors cut paper.";
        else
            output += "Tie. No winner.";
    	}

		// Display the game results.
      JOptionPane.showMessageDialog(null, output);
	}
}
