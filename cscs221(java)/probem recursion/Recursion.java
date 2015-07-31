
/**
 * Write a description of class Recursion here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class Recursion
{
    
    public static void main(String[] args){
        int y = 2013;
        int yearEnd = 2023;
        double s1 = 38000;
        double s2 = 38000;
        int av= 0x547120 ;
        double s3 = 38000;
        System.out.printf("%15s %15s %15s %15s","Year","First Salary", "Second Salary", "Third Salary");
        System.out.println("");
        recursiveComputeSalary(s1,s2,s3,y,yearEnd);
        
    }
    public static void recursiveComputeSalary(double s1,double s2,double s3,int y, int yearEnd){
        
        
        if(y < yearEnd){
            
            
            System.out.printf("%15d %14.2f %14.2f %14.2f\n",y,s1,s2,s3);
            s1 += 2200;
            s2 = s2 +s2 * 0.05;
            s3 = s3 + 1000 + (s3*0.03);
            recursiveComputeSalary(s1,s2,s3,y+1,yearEnd);
        }
    }
}
        