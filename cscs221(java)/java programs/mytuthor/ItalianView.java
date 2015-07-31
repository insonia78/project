
/**
 * cs201: lab 3  Geometry Tutor: thomas Zangari.
 * This is the GeometryView class. Its job is to handle all communication with
 * the user. It gives the user a menu of options.
 * It also communicates with the GeometryMaster.
 * @author (Thomas Zangari) 
 * @version (10/02/2013)
 */
import java.util.*;

public class ItalianView
{
   private ItalianMaster master;
   private int userChoice;
   private String answer;
   private char userAnswer;
    /**
     * Constructor for objects of class GeometryView
     */
    public ItalianView()
    {
        // initialise instance variables
        master = new ItalianMaster();
        userChoice= -1;
        answer = "";
    }

    public void start()
    {
      System.out.println("Whit this program you are going to lear some basic Italian phrases.");
      System.out.println("press 1 to learn how to say 'Good Morning'.");
      System.out.println("press 2 to learn how to say 'Good Night'.");
      System.out.println("press 3 to learn how to say 'Hello how are you doing?'");
      System.out.print("Do you want to learn?(press 'y' to start or 'n' to quit):");
      userAnswer = this.getUserInput();
      while(userAnswer == 'Y' || userAnswer == 'y'){
      System.out.print("Enter your choice (1-3): ");
      userChoice = this.getUserChoice();  
      if (userChoice == 1){
          System.out.println("You have chosen how to say 'Good Morning'");
          answer = master.computerGoodMorning();
          System.out.println("The answer is:" + answer);
        }else if (userChoice == 2) {
            System.out.println("You have chosen how to say 'Good Night'");
            answer=master.computerGoodNight();
            System.out.println("The answer is:"+answer);
           
        }else if (userChoice == 3){
            System.out.println("You have chosen how to say 'Hello! how are you doing?'");
            answer = master.computerHelloHaYDoing() ;
            System.out.println("The answer is:"+answer);
        }else{
            System.out.println("Invalid input. Try again.");
        }
        System.out.println();
        System.out.print("Do you want to learn more?(press 'y' to start or 'n' to quit):");
        userAnswer = this.getUserInput();
       
    }
    System.out.println("Goodbye. Thanks for playing!");
}

        public char getUserInput(){
               String userChoice;
               char userChoice1;
               
               Scanner kbd = new Scanner(System.in);
               userChoice = kbd.nextLine();
               return userChoice1 = userChoice.charAt(0);
           
    }
    public int getUserChoice(){
               Scanner kbd = new Scanner(System.in);
               return kbd.nextInt();
   }
}
            
            
    

