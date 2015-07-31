/*program3 exercise 10 
 * author: Thomas Zangari
 * The program asks to enter a student id and three of scores. It returns the average of the three scores
 * 
 * */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdandStudentScores
{
    class IdandStudentScores
    {
        static void Main(string[] args)
        {
            int studentId, // student id
                score1,    // first score
                score2,    // second score
                score3,    // third score
               average;    // gets the average
            
            Intro();
            average = GetStudentIdandScore(out studentId, out score1 , out score2, out score3);
          
            PrintOutTheScoresandAverage( average,  score1,  score2,  score3);
            Console.ReadKey();       
        }
        /*
         * Method for intro()
         * */
        public static void Intro()
        {
            Console.WriteLine("Welcome to score calculator\n");
        }
        /*Method that gets the student id and the three scores it and returns the average
         * */
        public static int GetStudentIdandScore(out int studentId, out int score1, out int score2, out int score3)
        {
            String studentIdString; // string that holds the student if for conversion
            
            Console.Write("Enter your student ID: ");
            
            studentIdString= Console.ReadLine();
            studentId = int.Parse(studentIdString);

            // geting the scores
            Console.Write("\nEnter your first score:");
            score1 = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("\nEnter your second score:");
            score2 = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("\nEnter your third score:");
            score3 = Convert.ToInt32(Console.ReadLine());

            return (score1 + score2 + score3)/3; //returning the average  
                     
        }
        /* Print outs the scores and the average
         * */
        public static void PrintOutTheScoresandAverage(int average, int score1, int score2,int score3)
        {
            Console.WriteLine("\nYour first score is:{0:00}\n",score1);
            Console.WriteLine("Your second score is:{0:00}\n",score2);
            Console.WriteLine("Your third score is:{0:00}\n",score3);
            Console.WriteLine("Your average is: {0:00}", average);  
        }

    }
}
