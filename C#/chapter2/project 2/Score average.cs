/* program 2 writen by thomas zangari summer 2014 c# 162
 * The program computes 5 scores and displays the scores and its average.
 * The average is formated so they are not digits on the right side of the decimal point
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreAverage
{
    class ScoreAverage
    {
        static void Main(string[] args)
        {
            const int NUMBER_0F_EXAMS = 5; // total of exams             
            //scores of the exams
            double firstScore = 85, 
                   secondScore = 87,
                   thirdScore = 76,
                   fourthScore = 80,
                   fifthScore = 90;
            // typing the scores
            Console.WriteLine("first Score:"+firstScore + "\nSecond Score:" + secondScore + "\nThird Score:" + thirdScore + "\nFourth Score:" + fourthScore + "\nFifth Score:" + fifthScore+"\n");
            // variable that holds the scores 
            double average = (firstScore + secondScore + thirdScore + fourthScore + fifthScore) / NUMBER_0F_EXAMS;
            //average score formated 
            Console.WriteLine("The average is {0:####} ",average);
            
            Console.Read(); 
   
        }
    }
}
