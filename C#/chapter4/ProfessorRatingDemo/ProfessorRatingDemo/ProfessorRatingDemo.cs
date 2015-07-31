/*Program n 10 chapter 4 
 * author Thomas Zangari
 * This program requires you to enter the professor Id and the grades and it gives the average.
 * The program is constructer with a Main method and a class
 * */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessorRatingDemo
{
    class ProfessorRatingDemo
    {
        static void Main(string[] args)
        {                
            int id = 0,             //variable for prof id             
                easiness = 0,       // variable for data 
                helpfulness = 0,
                clarity = 0;
            // crating the object
            ProfessorRating rating = new ProfessorRating(ref id, ref easiness,ref helpfulness,ref clarity);
            //calling and displaying the intro for the program
            Console.WriteLine(rating.getIntro());
            // calling the setValues so the user can input the values
            rating.setValues();
            //Displaying the values plus the average with the toString method from the class Professor Rating 
            Console.WriteLine(rating);
            Console.Read();
            
        }
        
    }    
}
