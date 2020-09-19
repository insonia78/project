
/**
 * Write a description of class MadlibController here.
 * This class holds the main class for executing the program.
 * 
 * @author (Thomas Zangari) 
 * @version (10/15/2013)
 */
public class MadLibController{

     private MadLibView _veiw3;
     private char userChoice;

  public MadLibController(){


    _veiw3 = new MadLibView();
  }


  public void start(){
      System.out.println("Have you ever played MadLibs?\n"+
                         "This is a game where you are asked to enter various words by category:\n"+
                         "a noun, a verb, a verb in the past tense, a color, etc.\n"+
                         "Then the words are plugged into a pre-existing story, and you get to read the final story with the new words filled in\n"+
                         "– and hopefully laugh at the funny results.");
      System.out.println();
      userChoice =_veiw3.getUserChoice();

      while(userChoice == 'Y' || userChoice == 'y'){

       _veiw3.setInput();
       printStory();
       System.out.println();
       System.out.println();
       userChoice =_veiw3.getUserChoice();
       System.out.println();
       System.out.println();
  }
}

  public void printStory(){
	   _veiw3.setOutput();
   }



  public static void main(String[] args){
    	MadLibController begin = new MadLibController();
    	begin.start();
  }
}

