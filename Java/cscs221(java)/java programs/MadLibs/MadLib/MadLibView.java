
/**
 * Write a description of class MAdLibView here.
 * 
 * @author (Thomas Zangari) 
 * @version (10/13/2013)
 */
import java.util.*;


public class MadLibView
{
    // instance variables - replace the example below with your own
    private MadLibGame  _game ;
    private String _story;

    public MadLibView() {
		_game = new MadLibGame();
	}

    public void setIntro(){
        
           String intro =("Have you ever played MadLibs?\n"+
                         "This is a game where you are asked to enter various words by category:\n"+
                         "a noun, a verb, a verb in the past tense, a color, etc.\n"+
                         "Then the words are plugged into a pre-existing story, and you get to read the final story with the new words filled in\n"+
                         "– and hopefully laugh at the funny results.");
          System.out.print(intro);
          System.out.println();
       }                     
    
	public char getUserChoice(){

    String userChoice;
    char userChoice1;
    System.out.print("Do you want to play?(press 'y' to start or 'n' to quit):");
    userChoice = this.getUserInput();

    return userChoice1 = userChoice.charAt(0);

    }

    public void setInput(){

        System.out.print("Enter a noun: ");
        String noun = this.getUserInput();
        System.out.print("Enter a noun: ");
        String noun2 = this.getUserInput();
        System.out.print("Enter a past tense verb: " );
        String verb =this.getUserInput();
        System.out.print("Enter His,Her,or Hern: ");
        String suffix = this.getUserInput();
        System.out.print("Enter a title: ");
        String title = this.getUserInput();
        System.out.println();
        System.out.println();
        _story = _game.getStory(noun,noun2,verb,suffix,title);
    }
     public void printStory(){
      System.out.print( _story);
    }
    public String getUserInput(){
        Scanner kbd = new Scanner(System.in);
        return kbd.nextLine();
    }
}
