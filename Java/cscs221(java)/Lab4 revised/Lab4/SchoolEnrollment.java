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
        catch (FileNotFoundException e) {
             System.err.println("FileNotFoundException: " + e.getMessage());
                       
        System.exit(1);
    }
    catch(IOException err){
        
        System.out.println("Cant write on files");
        err.printStackTrace();
        System.exit(1);
    }
    


  totalEnrolment = Table.addTables(table1,table2);
  try{
      totalEnrolment.printTableSumstoFile("Total.txt");
    }
    catch(IOException err){
        
        System.out.println("Cant open Total.txt");
        System.exit(1);
    }
  
  
  
 
            
}
}
   
   

    
