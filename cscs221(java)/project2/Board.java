
/**
 * Write a description of class Board here.
 *
 * @author (your name)
 * @version (a version number or a date)
 */
import java.util.*;
import java.io.*;

   public class Board{
        private LifeCell[][] board;    // Board of life cells.
        private LifeCell[][] board2;   // Second board 
        private int boardHeight, boardWidth;




    // Constructor for objects of class Board
        public Board(int width, int height){
       // creates a board with lifecell objects
       boardHeight = height;
       boardWidth = width;
       board = new LifeCell[width][height];
       board2 = new LifeCell[width][height];
       for(int i = 0; i < board.length; i++){
		   for(int j = 0 ; j < board.length;j++){

          board[i][j] = new LifeCell(board,i,j);
          board2[i][j] = new LifeCell(board,i,j);
          new LifeCell(board,i,j);
    	   }
	   }

 }



       public void createInitialBoard(Scanner infile) {
      // for each particular pair read in, ask life cell to toggle.

         while(infile.hasNext()== true){
          int x= infile.nextInt();
           int y = infile.nextInt();

            board[x][y].toggle();

		 }
		 infile.close();
    }


        public void updateBoard() {
            // first ask all life cells to count their living neighbors.
            // It should then ask all life cells to toggle
            // for the new generation.

                  for(int i = 0; i < 8 ; i++){
		             for(int j = 0 ; j < 8;j++){

				   int count = board[i][j].countNeighbors();

                    if ( count == 3 || count == 2 && board[i][j].isAlive() == true){
                         board2[i][j].toggle();
					 }
					 else if(count == 3 && board[i][j].isAlive() == false){
						     board2[i][j].toggle();
						 }
					 else if(count !=3 && board[i][j].isAlive() == false){
						        board2[i][j].isAlive();
							}
					 else if(count !=3 && board[i][j].isAlive() == true){
						     board2[i][j].isAlive();
						 }

					 }

				 }
				 // Setting board to false
				 for(int i = 0; i < 8 ; i++){
		             for(int j = 0 ; j < 8;j++){
						 board[i][j].getDead();
					 }
				 }



            }

       // tranfering and setting board from board2
	   public void copyBoard(){
		   for(int i = 0; i < 8 ; i++){
		   	   for(int j = 0 ; j < 8;j++){


                 if ( board2[i][j].isAlive() == true){
		                 board[i][j].toggle();
		   			}
		   		  else if( board2[i][j].isAlive() == false)
		   		  {
					  board[i][j].isAlive();
		           }
               }

			}
			 // Setting the elements of board2 to false  
			 for(int i = 0; i < 8 ; i++){
		   	   for(int j = 0 ; j < 8;j++){
				   board2[i][j].getDead();
			   }
		   }
		}

        public void printBoard (PrintWriter outfile) {

         //  prints the board with the appropriate characters +-|
         //  used to show the boundaries.  Where appropriate,
         //  Ask each cell to print itself.
               int col =0;
               int row = 0;
               boolean line = true;
               

          for(int i = 0;i < board.length + 1; i++){
                


			 while(line == true && i < 9){
				 for(row = 0; row < board2.length && line == true;){;
					outfile.println("");
					
					for (col = 0;col < board2.length;col++){
						 outfile.print("+");
						 
						 outfile.print(" - ");
						 
					 }
					 outfile.print("+");
					 
					 line = false;

				 }
			 }
                 outfile.println(" ");
                                   
                 

				 while(line == false && i < 8){
					 for (row = 0; row < board2.length && line == false;){
						 for(col = 0; col < board2.length; col++){
							 outfile.print("|");
							 

							 board[i][col].printcell(outfile);


						 }
						 outfile.print("|");
						 
						 line = true;

					 }
				 }
				 

			 }
			

		 }

}








