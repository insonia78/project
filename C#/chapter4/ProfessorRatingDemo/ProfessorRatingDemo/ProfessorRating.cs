
/*
 * professor rating class 
 * */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ProfessorRating
{
    private int id,         // variables for the program
                easiness,
                helpfulness,
                clarity;

    // constructor
    public  ProfessorRating(ref int a ,ref int b,ref  int c,ref int d)
    {
        id = a;
        easiness = b; 
        helpfulness = c;
        clarity = d;
    }
    
    public String getIntro()
    {
        String intro = "Welcome to the professor evaluation program\n";  
        return intro;
    }
    /*
     * setting the values method with user input
     * @parm id
     * @parm easiness
     * @parm helpfulness
     * @parm clarity
     * */
    public void setValues()
    {
        Console.Write("Enter your ID:");
        id = Convert.ToInt32(Console.ReadLine());

        Console.Write("\nEnter the easine:");
        easiness = Convert.ToInt32(Console.ReadLine());

        Console.Write("\nEnter the helpfulness:");
        helpfulness = Convert.ToInt32(Console.ReadLine());

        Console.Write("\nEnter your clarity:");
        clarity = Convert.ToInt32(Console.ReadLine());
     }
    /* 
     * getting the average from the variables
     * @return average 
     */

    public double getAverage()
    {
        double average = (easiness + helpfulness + clarity) / 3;
        return average;
    }
    /*
     * toString method
     * @return print it returns the output for the program
     * */
    public override string ToString()
    {
        string print ="easiness:" + easiness +
                       "\nhelpulness:" + helpfulness +
                       "\nclarity:" + clarity +
                       "\naverage:"+String.Format("{0:00}",getAverage());
        return print;
    }

}
