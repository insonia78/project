/*program 6 1 
 * @author Thomas Zangari
 * this program asks the user to enter 5 scores and it computes the average and the letter grade.
 * The program uses a while loop for the  scores. It also uses while loop to check if the scores entered is correct 
 * */
  

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CalculateScoreWithLoop
{
    class CalculateScoreWithLoop
    {
        static void Main(string[] args)
        {
            int firstScore = 0,     // the five variables for the score
                secondScore = 0,
                thirdScore = 0,
                fourthScore = 0,
                fifthScore = 0;
           // variable for the intro
            Intro();
            /* Gets the scores and inside calls the GetAvergae method and the GetLetter grade 
             * */
            GetTheScore( firstScore,  secondScore,  thirdScore,  fourthScore,  fifthScore);
        
        
        }
        public static void Intro()
        {
            Console.WriteLine("Welcome to the Calculate Score With a Loop");
        }
        
        /* GetThesScore method that gets the 5 scores
         * @parm decision
         * @average
         * @verify
         * @letter
         *  */
        
                
        public static void GetTheScore( int firstScore,  int secondScore,  int thirdScore,  int fourthScore,  int fifthScore)
        {
            char decision ='Y';   // variable for the decision of the first loop 
            double average = 0;  //variable that holds the average
            bool verify = false; // this varible is uses in the if else statments 
            char letter ;        // this variable is for the letter grade

            while ((decision == 'Y') || (decision == 'y'))
            {   
                while(verify == false)
                {      
                    Console.Write("\nEnter your first grade:");
                    firstScore = Convert.ToInt32(Console.ReadLine());

                    if ((firstScore > 100) || (firstScore < 0))
                    {
                        MessageBox.Show("Your enterd a invalid Score","Message",MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    }
                    else
                    {
                       
                        verify = true;
                    }
                }
                verify = false;
                 
                while(verify == false)
                {
                    Console.Write("\nEnter your second grade:");
                    secondScore = Convert.ToInt32(Console.ReadLine());
                    
                    if ((secondScore > 100) || (secondScore < 0))
                    {
                        MessageBox.Show("Your enterd a invalid Score", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        verify = true;
                        
                     }
                }
                verify  = false;

                while (verify == false)
                {
                    Console.Write("\nEnter your third grade:");
                    thirdScore = Convert.ToInt32(Console.ReadLine());

                    if ((thirdScore > 100) || (thirdScore < 0))
                    {
                        MessageBox.Show("Your enterd a invalid Score", "Message", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
                    }
                    else
                    {
                        verify = true;
                    }
                }
                verify = false;

                while (verify == false)
                {

                    Console.Write("\nEnter your fourth grade:");
                    fourthScore = Convert.ToInt32(Console.ReadLine());

                    if ((fourthScore > 100) || (fourthScore < 0))
                    {
                        MessageBox.Show("Your enterd a invalid Score", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    }
                    else
                    {
                        verify = true;
                    }
                }
                verify = false;
                while (verify == false)
                {

                    Console.Write("\nEnter your fifth grade:");
                    fifthScore = Convert.ToInt32(Console.ReadLine());

                    if ((fifthScore > 100) || (fifthScore < 0))
                    {
                        MessageBox.Show("Your enterd a invalid Score", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        verify = true;
                    }
                }
                verify = false;
                
                //it prints the average and calls the GetAverage method that assigns it to the average variable
                Console.WriteLine("\nYour average is:"+ Convert.ToDouble(String.Format("{0:00}",average = GetAverage(firstScore,secondScore,thirdScore,fourthScore,fifthScore))));     
                //Prints the final grade in letter and it cals the GetLetter method and assignsit to the letter variable
                Console.WriteLine("\nYour final grade is:" + (letter = GetLetter(average)));
                //It askes if the user whants to enter more scores 
                Console.Write("\nDo you want to enter more scores?('Y' for yes or 'N' for no):"); 
                decision =Convert.ToChar(Console.ReadLine());
       
            }
        }
        /*GetAverage gets the average of the fivescores
         * @return  (firstScore + secondScore + thirdScore + fourthScore + fifthScore) / 5;
         * */
        static double GetAverage(int firstScore, int secondScore, int thirdScore, int fourthScore, int fifthScore)
        {
            return (firstScore + secondScore + thirdScore + fourthScore + fifthScore) / 5;
        }
        /* GetLetter method get the letter grade
         * @parm char lettergrade
         * @returns letterGrade
         * */
        static char GetLetter( double average)
        {
            char letterGrade ;

            if (average >= 90 && average <= 100)
            {
             letterGrade = 'A';
            }
            else if (average >= 80 && average <= 89)
           {
            letterGrade = 'B';
           }
           else if (average >= 70 && average <= 79)
          {
            letterGrade = 'C';
          }
          else if (average >= 60 && average <= 69)
          {
            letterGrade ='D';
          }
          else
          {
            letterGrade = 'F';
          }

        return letterGrade ;
      }

    }
}
