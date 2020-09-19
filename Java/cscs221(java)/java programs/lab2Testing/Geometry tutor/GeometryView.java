
/**
 * cs201: lab 3  Geometry Tutor: thomas Zangari.
 * This is the GeometryView class. Its job is to handle all communication with
 * the user. It gives the user a menu of options.
 * It also communicates with the GeometryMaster.
 * @author (Thomas Zangari) 
 * @version (10/02/2013)
 */
import java.util.*;

public class GeometryView
{
   private GeometryMaster master;
   private int userChoice;
    /**
     * Constructor for objects of class GeometryView
     */
    public GeometryView()
    {
        // initialise instance variables
        master = new GeometryMaster();
        userChoice= -1;
    }

    public void start()
    {
      System.out.println("1 Calculate the area of a circle.");
      System.out.println("2 Calculate the area of a rectangle.");
      System.out.println("3 Calculate the area of a triangle.");
      System.out.println("4 Quit.");
      System.out.print("Enter your choice (1-4): ");
      userChoice = this.getUserInput();
      if (userChoice == 1){
          System.out.println("What is the radius of the circle?");
          int radius = this.getUserInput();
          double area = master.computeCircleArea(radius);
          System.out.print(master.getName() + "says the area of the circle is " + area);
        }else if (userChoice == 2) {
            System.out.println("You asked for the area of a rectangle.");
            System.out.print("What is the lenght of the rectangle?: ");
            int lenght=this.getUserInput();
            System.out.print("What is the width of the rectangle?: ");
            int width = this.getUserInput();
            double area = master.computeRectangleArea(lenght,width);
            System.out.print(master.getName() + "says the area of the rectanlge is " + area);
        }else if (userChoice == 3){
            System.out.println("You asked for the area of a triangle.");
            System.out.print("What is the base of the triangle?: ");
            int base=this.getUserInput();
            System.out.print("What is the height of the triangle?: ");
            int height = this.getUserInput();
            double area = master.computeTriangleArea(base,height);
            System.out.print(master.getName() + "says the area of the triangle is " + area);
        }else if(userChoice == 4){
            System.out.println("Goodbye. Thanks for playing!");
        }else{
            System.out.println("Invalid input. Try again.");
        }
        System.out.println();
        System.out.println();
    }

        public int getUserInput(){
               Scanner kbd = new Scanner(System.in);
               return kbd.nextInt();
    }
}
            
            
    

