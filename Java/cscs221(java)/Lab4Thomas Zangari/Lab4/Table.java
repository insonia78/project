//***********************************************************
//                         Table.java                             //***********************************************************
 //      Written by Edward McDowell for Computer Science 201.      
//             modified by N. Sarawagi and A Moskol     
//***********************************************************
     //  This program reads a table of integers having rowN rows and  
     //  colN columns into a two-dimensional array. It displays the    
     //  table on the screen with row and column sums.
//***********************************************************

import java.util.*;
import java.io.*;

     public class Table 
     {         
        private int[ ][ ] table; // declare table as a 2D Array
        private final int rowN;  // number of rows 
        private final int colN;  // number of columns


        public Table(int rows, int columns)
        {
            rowN = rows;
            colN = columns;
            // Create the array
            table = new int[rowN][colN];
        }       
public int [ ] rowSums ()
{
     int [ ] rowsum = new int[rowN];
   // Compute the row sums.
    for (int row = 0; row < rowN; ++row){
    // for each row: initialize the rowsum = 0;
        rowsum[row] = 0;
        //For each row: Go through each column and accumulate the sum 
        for (int col = 0; col < colN; ++col){
            rowsum[row] = rowsum[row]+table[row][col];
               rowsum[row] += table[row][col]; 
        }
    }
    return rowsum;
}

public int [ ] colSums ()
{
    int [ ] colsum = new int[colN];
   // Compute the column sums.
    for (int col = 0; col < colN; ++col) {
    // for each col: initialize the colsum = 0;
        colsum[col] = 0;
    //For each clmn: Go through each row and accumulate the sum
        for (int row = 0; row < rowN; ++row){
            colsum[col] = colsum[col]+table[row][col];
               // OR  colsum[col] += table[row][col];
        }
    }
    return colsum;
}
public int [] [] get2DimArrayFromTable()
{
return table;
}




public void ReadTablefromFile(String fileName) throws IOException {
            Scanner infile;
            int row;
            int col;
            infile = new Scanner(new FileReader(fileName));
                       
            // Read the table one row at a time..
             for (row = 0; row < rowN; ++row)
                 for (col = 0; col < colN; ++col)
                     table[row][col] = infile.nextInt();
             infile.close();
        }       
         
public void printTableSumstoFile (String fileName) throws IOException{
          PrintWriter  outfile;
          int [ ] rowsum = rowSums();
          outfile = new PrintWriter(new FileWriter(fileName));
          outfile.println( );
         for (int row = 0; row < rowN; ++row) {
            for (int col = 0; col < colN; ++col) {
             outfile.printf ("%4d", table[row][col]);
		} 
        outfile. printf("%8d%n", rowsum[row]);
        } 
        int [ ] colsum = colSums();
          outfile.printf("%n");
        for (int col = 0; col < colN; ++col){
        	outfile.printf ("%4d", colsum[col]);
	} 
        outfile.printf ("%n");
        outfile.close();
}
public static Table addTables (Table atable1, Table atable2){
int [] [] a1, a2;
// set a1 to be the 2Dim array of atable1
a1 = atable1.get2DimArrayFromTable();  
// set a2 to be the 2Dim array of atable2
a2 = atable2.get2DimArrayFromTable();
// declare and create a new  Table  object named tableSum – pass appropriate parameters to the constructor of Table using length of a1
Table tableSum = new Table(a1.length,a1.length - 1); 
//declare a variable aSum, and set it to be 2DimArray in tableSum
int[] [] aSum = tableSum.get2DimArrayFromTable();
// add each element of a1 to a2 and store in aSum (nested for loops)
for(int row = 0;row < a1.length; row++){
        
    for(int col =0;col < a1.length - 1;col++){
        aSum[row][col] = a1[row][col]+ a2[row][col];
        
    }
}


return tableSum;
        
    
    
//return tableSum
}


}
