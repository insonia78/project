// This class declares a 4 by 3 table, and calls the appropriate
// method to fill and print it.
//
import java.io.*;
import java.util.*;

public class SchoolEnrollment
{
    public static void main(String[] args)throws IOException {
        
        Table table1,table2,totalEnrolment;
        
        
        table1 = new Table(6,5);
        table2 = new Table(6,5);
        
       try{
           table1.ReadTablefromFile("School1.txt");
           table2.ReadTablefromFile("School2.txt");
           
        }
        catch(IOException err){
            table1 = null ;
            table2 = null;
            if(table1 == null){
            System.out.println("Cannot open Schooll.txt");
        }
        if(table2 == null){
            System.out.println("Cannot open School2.txt " );
        }
        System.exit(1);
    }


  totalEnrolment = Table.addTables(table1,table2);
  try{
      totalEnrolment.printTableSumstoFile("Total.txt");
    }
    catch(IOException err){
        totalEnrolment = null;
        System.out.println("Cant open Total.txt");
        System.exit(1);
    }
  
  
  
 
            
}
}
   
   

    
