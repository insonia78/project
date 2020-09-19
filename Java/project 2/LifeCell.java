
/**
 * Write a description of class LifeCell here.
 *
 * @author (your name)
 * @version (a version number or a date)
 */
import java.util.*;
import java.io.*;

public class LifeCell {
        private LifeCell[][] board;          // A reference to the board array.

        private boolean alive ;              // Stores the state of the cell.
        private int row, col;              // Position of the cell on the board.
        private int count;                // Stores number of living neighbors.


        public LifeCell(LifeCell[][] b, int r, int c) {
            // Initialize the life cell as dead.  Store the reference
            // to the board array and the board position passed as
            // arguments.  Initialize the neighbor count to zero.


           row = r;
           col = c;
           count = 0;
           alive = false;


           board = new LifeCell[r+1][c+1];


           board = b;




                  if(board[r][c] != null){

                   board[r][c].isAlive();




			  }

      }
         public int countNeighbors() {
            // Set "count" to the number of living neighbors of this cell.

                  count = 0 ;
                  if(row > 0 && col > 0 && row < 7 && col < 7){

                     if(board[row-1][col-1].isAlive() == true){
                         count += 1;
                       }



                    if(board[row-1][col].isAlive() == true){
					 count +=1;
                	}

					if(board[row-1][col+1].isAlive() == true){
						count +=1;
				  }




				   if(board[row][col-1].isAlive() == true){
						count +=1;

			      }

                  if(board[row][col+1].isAlive() == true){
                        count +=1;
                 }
				 if(board[row+1][col-1].isAlive() == true){
						count +=1;
				 }
			     if(board[row+1][col].isAlive() == true){
						count +=1;
                 }
				 if(board[row+1][col+1].isAlive() == true){
						 count +=1;
				 }


	   }



                else if(row == 0 && col == 0 ){          //uperleft angle

                      if(board[row + 1][col].isAlive() == true){
                          count +=1;
                        }
                      if(board[row + 1][col + 1].isAlive() == true){
                          count +=1;
                        }
                      if(board[row][col + 1].isAlive() == true){
                          count +=1;
                        }
                    }
                  else if(row == 0 && col == 7){           // uperRight angle
                      if( board[row][col - 1].isAlive() == true){
                          count +=1;
                        }
                      if( board[row +1][col - 1].isAlive() == true){
                          count +=1;
                        }
                      if(board[row + 1] [col].isAlive() == true){
                          count +=1;
                        }
                    }
                    else if(row == 7 && col == 0){           //underLeft angle
                        if(board[row -1][col].isAlive() == true){
                            count +=1;
                        }
                        if(board[row-1][col+1].isAlive() == true){
                            count +=1;
                        }
                        if(board[row][col+1].isAlive() == true){
                            count +=1;
                        }
                    }
                    else if(row == 7 && col == 7){          //underRight angle
                        if(board[row][col-1].isAlive() == true){
                            count +=1;
                        }
                        if(board[row-1][col].isAlive() == true){
                            count +=1;
                        }
                        if(board[row-1][col-1].isAlive() == true){
                            count +=1;
                        }
                    }
                    else if(row == 0 && col > 0 && col < 7 ){    //upper middle side
                         if(board[row][col-1].isAlive() == true){
                          count +=1;
                        }

                        if(board[row][col+1].isAlive() == true){
                            count +=1;
                        }
                        if(board[row+1][col-1].isAlive() == true){
                            count +=1;
                        }
                        if(board[row + 1][col].isAlive() == true){
                            count +=1;
                        }
                        if(board[row+1][col+1].isAlive() == true){
                            count +=1;
                        }
                    }
                    else if(row == 7 && col > 0 && col < 7 ){    //lower middle side
                        if(board[row][col-1].isAlive() == true){
                            count +=1;
                        }
                        if(board[row][col+1].isAlive() == true){
                            count +=1;
                        }
                        if(board[row-1][col-1].isAlive() == true){
                            count +=1;
                        }
                        if(board[row-1][col].isAlive() == true){
                            count +=1;
                        }
                        if(board[row-1][col+1].isAlive() == true){
                            count +=1;
                        }
                    }
                    else if(row > 0 && row < 7 && col ==0 ){ //middle left side

                        if(board[row -1][col].isAlive() == true){
                            count +=1;
                        }
                        if(board[row-1][col+1].isAlive() == true){
                            count +=1;
                        }
                        if(board[row][col+1].isAlive() == true){
                            count +=1;
                        }
                        if(board[row+1][col+1].isAlive() == true){
                            count +=1;
                        }
                        if(board[row+1][col].isAlive() == true){
                            count +=1;
                        }

                    }
                   else if(row > 0 && row < 7 && col == 7){ //middle right side
                        if(board[row -1][col].isAlive() == true){
                            count +=1;
                        }
                        if(board[row-1][col-1].isAlive() == true){
                            count +=1;
                        }
                        if(board[row][col-1].isAlive() == true){
                            count +=1;
                        }
                        if(board[row+1][col-1].isAlive() == true){
                            count +=1;
                        }
                        if(board[row+1][col].isAlive() == true){
                            count +=1;
                        }
					}
     	           return count;

			}




        public void printcell (PrintWriter outfile) {
            // When alive, the cell is printed as a *; when dead a space
            String[][] stringBoard = new String[row+1][col+1];
                       if(board[row][col].isAlive() == true){
				    		stringBoard[row][col] = " * ";
				     	}
				    	else{
				    		stringBoard[row][col] = "   ";
				    	   }

			outfile.print(stringBoard[row][col]);


}



         public boolean isAlive() {
			return alive;
			}



        public void toggle() {// if cell is alive, toggle will make it dead
            alive = !alive;    // if cell is dead, toggle will make it alive
         }
         public boolean getDead(){
			 alive = false;
			 return alive;
		 }



}






