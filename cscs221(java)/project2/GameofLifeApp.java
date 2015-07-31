
/**
 * Write a description of class GamwofLife here.
 *
 * @author (Thomas Zangari)
 * @version ( date 3/18/2014)
 */
    import java.io.*;
    import java.util.*;
    import java.util.Scanner;

    public class GameofLifeApp {
          private Board currentBoard;
          private int num_generations;
          private Scanner infile;
          private PrintWriter outfile;
          private int x;
          private int y;



  public GameofLifeApp(){

            try {
                // Open the input/output streams.
              infile= new Scanner(new FileReader("INPUT.TXT"));
              outfile = new PrintWriter(new FileWriter("OUTPUT.TXT"));

	          }
              catch (IOException exc) {
                // Exit if a stream cannot be opened.
                System.out.println(exc);
                System.exit(1);
            }



          this.readInputData();
          this.playgame();
}

public void readInputData(){
// read the data from the text and store in the appropriate places




    while ( infile.hasNext()){

      x = infile.nextInt();
      y = infile.nextInt();
     num_generations = infile.nextInt();
     currentBoard = new Board(x,y);

     break;



      }
    currentBoard.createInitialBoard(infile);

}

    public void playgame() {
    for (int i = 1; i< num_generations; i++){
   // For each generation,
   // ask all life cells to count their living neighbors
   // then ask all life cells to update their states
   // for the new generation.
   // print the new board

         outfile.println("           Generation =" + i);
          
         currentBoard.printBoard(outfile);
         currentBoard.updateBoard();
         currentBoard.copyBoard();


}


  outfile.close();

}

       public static void main(String[] args)  {
               new GameofLifeApp();
       }
}

