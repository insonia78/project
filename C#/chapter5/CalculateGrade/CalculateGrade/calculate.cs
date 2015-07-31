/*
 * class method
 * */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Calculate
{
   // fields
   private int firstGrade,
               secondGrade,
               thirdGrade,
               fourthGrade,
               fifthGrade;
   /*constructor*/
    public Calculate( int a, int b, int c, int d, int e)
    {
        firstGrade =a;
        secondGrade = b;
        thirdGrade = c;
        fourthGrade = d;
        fifthGrade = e;
    }
    /* Setting the grades
     * */
    public void setGrade()
    {
        Console.Write("Enter your first grade:");
        firstGrade = Convert.ToInt32(Console.ReadLine());

        Console.Write("\nEnter your second grade:");
        secondGrade = Convert.ToInt32(Console.ReadLine());

        Console.Write("\nEnter your third grade:");
        thirdGrade = Convert.ToInt32(Console.ReadLine());

        Console.Write("\nEnter your fourth grade:");
        fourthGrade = Convert.ToInt32(Console.ReadLine());

        Console.Write("\nEnter your fifth grade:");
        fifthGrade = Convert.ToInt32(Console.ReadLine());
 
    }
    /* creating the average */
    public double getAverage()
    {
        double average =Convert.ToDouble(String.Format("{0:00}", (firstGrade + secondGrade + thirdGrade + fourthGrade + fifthGrade) / 5));

        return average;
    }
    /* getting the average*/     
    public char getLetterGrade()
    {
        char letterGrade ;
        if (getAverage() >= 90 && getAverage() <= 100)
        {
            letterGrade = 'A';
        }
        else if (getAverage() >= 80 && getAverage() <= 89)
        {
            letterGrade = 'B';
        }
        else if (getAverage() >= 70 && getAverage() <= 79)
        {
            letterGrade = 'C';
        }
        else if (getAverage() >= 60 && getAverage() <= 69)
        {
            letterGrade ='D';
        }
        else
        {
            letterGrade = 'F';
        }

        return letterGrade ;
    }
    /*To string method */
    public override string ToString ()
    {
        string print = ("\nYour grades are:" + firstGrade +
                        "\nSecond grade:" + secondGrade +
                        "\nThird grade:" + thirdGrade +
                        "\nFourth grade:" + fourthGrade +
                        "\nFith Grade:" + fifthGrade +
                        "\nAverage:" + getAverage() +
                        "\nYour final grade is:" + getLetterGrade());
        return print;
    }


}
