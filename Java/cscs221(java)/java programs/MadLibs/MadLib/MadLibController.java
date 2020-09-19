
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
      _veiw3.setIntro();
      
      userChoice =_veiw3.getUserChoice();

      while(userChoice == 'Y' || userChoice == 'y'){

       _veiw3.setInput();
       _veiw3.printStory();
       System.out.println();
       System.out.println();
       userChoice =_veiw3.getUserChoice();
       System.out.println();
       System.out.println();
  }
}

 
  public static void main(String[] args){
    	MadLibController begin = new MadLibController();
    	begin.start();
  }
}

