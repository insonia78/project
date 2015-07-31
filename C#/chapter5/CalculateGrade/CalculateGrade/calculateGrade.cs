/*Program n 5 
 * @author thomas zangari
 * Thid program asked for input 5 grades and it returns the five grades with the average of it and the letter grade
 * the program is constructed with a class
 * */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateGrade
{
    class CalcuateGrade
    {
        static void Main(string[] args)
        {
            int firstGrade = 0,  // first grade
                secondGrade = 0 ,// second grade
                thirdGrade = 0 , // third grade
                fourthGrade = 0 , // fourth grade
                fithGrade = 0 ;  // fith grade
            
            Intro(); // calling the intro method
            // instatiating a object
            Calculate grades = new Calculate( firstGrade, secondGrade, thirdGrade, fourthGrade, fithGrade);
            // input the grades
            grades.setGrade();
            //out put with a ToString
            Console.WriteLine(grades);
            Console.ReadLine();
        }
        public static void Intro()
        {
            Console.WriteLine("Welcome to calculate your grade");
        }
    }
}
