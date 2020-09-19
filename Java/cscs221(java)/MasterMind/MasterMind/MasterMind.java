
/**
 * This is a Mastermind game made with numbers.The game askes you to guess 4 colors using numbers  randomly 
 * generated from the computer. Their are no doubles or triples numbers in the game 
 * and you have 12 guesses to accive the task.The game will give you cloues weater you have the color in the right place 
 * or if you have the right color with black pins for the right position and white for the right color
 *The program uses 2 arrays one for the computer selection the other for the user selection 
 * @author (Thomas zangari)
 * @version (MasterMind)
 */
import java.util.*;
public class MasterMind
{

    private final int  ARRAY_DIMENSION = 4;      //dimension of the array
    private int[] compSelectionColor = new int[ARRAY_DIMENSION]; //computer selection array
    private int[] userSelectionColor = new int[ARRAY_DIMENSION]; // user selection array
    private String[] convertToColors = new String[ARRAY_DIMENSION]; //array that hold the conversion from number to string;
    private Scanner kbd = new Scanner(System.in); //scanner kbd
    private Random randomColorGenerator = new Random(); // generate the random value for the computer
    private int countB = 0;   //count of black pin 
    private int countW= 0;    // count of white pin
    private int count = 0;    // count value of the construtor loop
    boolean decisionW = false; // boolean value for the white pin
    boolean decisionB = true;  //boolean value for the black pin

    
    //constructor holding the methods call and the 12 intereations for the game
      public MasterMind(){
         this.colorsFromComputer();   
         while(count < 12 && countB < 4){
          this.colorsFromUser();
          this.colorCompare();
          this.displaySelection();
          count++;
        }
        this.displayComputerSelection();


    }
    // Method for making the computer generate the color with random class
     public void colorsFromComputer(){

     for(int i = 0; i < compSelectionColor.length; i++){
         compSelectionColor[i] = randomColorGenerator.nextInt(6)+1; //Starting selection from 1 to 6

        }
      int value =compSelectionColor[0]; // holding the value to compare
      // for loop to compare if their are any doubles or triples and changing
      // the value to a non value present in the computerSelection array
      for(int j = 1 ; j < compSelectionColor.length; j++){
           if(j == 1){
		       if(compSelectionColor[0] == compSelectionColor[j]){
			   compSelectionColor[j] = randomColorGenerator.nextInt(6)+1;		   ;
			  } 
			 }
    	    if( j == 2){
			     if(compSelectionColor[0] == compSelectionColor[j]){
    	           compSelectionColor[j] = randomColorGenerator.nextInt(6)+1;
    	          }
    	          if(compSelectionColor[1] == compSelectionColor[j]){
    	              compSelectionColor[j] = randomColorGenerator.nextInt(6)+1;
    	           }
    	           
			}
		 if(j == 3){
		    while(compSelectionColor[0] == compSelectionColor[j] ||compSelectionColor[1] == compSelectionColor[j] ||compSelectionColor[2] == compSelectionColor[j]){
		          compSelectionColor[j] = randomColorGenerator.nextInt(6)+1;
		        
		   }

	   }
     }


    }
    // User selection to play the game
     public void colorsFromUser(){
         System.out.println("Select a color \n 1 for red, 2 for blue, 3 for yellow, 4 for orange, 5 for green and 6 for purple");
         for(int i = 0; i < userSelectionColor.length;i++){
             userSelectionColor[i] = kbd.nextInt();
            }
    }
    /**
     * method to make the comparison with the color you have chosen and the computer choice
     * 
     */
    public void colorCompare(){
         countW = 0;
         countB = 0;

     // first for loop
        for(int j = 0; j < compSelectionColor.length; j++){
           int search = userSelectionColor[j];

      // if statment if the two selection are equal and increases the countB the black pin    
           if(compSelectionColor[j] == userSelectionColor[j]){
             countB++;
           }
            else {// going in the white pin selsection it uses a for loop to compare all the values of the array
            for(int i = 0; i < compSelectionColor.length; i++){
               if(compSelectionColor[i] == search){
                      decisionW = true;
                  }
                }
            }
                if(decisionW == true ){
                    countW++;
                    decisionW = false;
            }

       }
    }
//displays the count of white and black pins 
    public int displaySelection(){
        if(countB <=3){
            System.out.println("You have " + countB +" in the right place");
        }
        if(countW <= 4){
            System.out.println("You have " + countW + " Right colors");
        }
        return countB;
    }
    // it displays the computer selection of the end of the game
    public void displayComputerSelection(){
       System.out.println("The computer selection");
        for(int i = 0; i < compSelectionColor.length; i++){
            if(compSelectionColor[i] == 1){
                System.out.print("1=red      ");
            }
            if(compSelectionColor[i] == 2){
                System.out.print("2=blue      ");
            }
            if(compSelectionColor[i] == 3){
                System.out.print("3=yellow      ");
            }
            if(compSelectionColor[i] == 4){
                System.out.print("4=orange      ");
            }
            if(compSelectionColor[i] == 5){
                System.out.print("5=green      ");
            }
            if(compSelectionColor[i] == 6){
                System.out.print("6=purple      ");
            }
            
         }
    }

 public static void main (String[] args) {
       MasterMind masterMind = new MasterMind();
    }
}


