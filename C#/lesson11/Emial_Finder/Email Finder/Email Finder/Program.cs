using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Time
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader inFile;
            StreamWriter outFile;
            DateTime date = DateTime.Now;
            string inValue;
            bool validation = true;
            string email;
            char decision = 'y';

            while (Char.ToLower(decision) == 'y')
            {

                Console.WriteLine("Enter the email:");
                email = Console.ReadLine();
                if (File.Exists(@"C:\Users\thomas\Desktop\email\email.txt") == true)
                {

                    try
                    {

                        inFile = new StreamReader(@"C:\Users\thomas\Desktop\email\email.txt");

                        while ((inValue = inFile.ReadLine()) != null)
                        {

                            if (inValue == email)
                            {
                                Console.WriteLine("sorry the email exist ");
                                Console.WriteLine(inValue);
                                if ((inValue = inFile.ReadLine()) != null)
                                {
                                    Console.WriteLine(inValue);
                                }
                                validation = false;
                                break;
                            }


                        }
                        inFile.Close();

                    }
                    catch (System.IO.IOException e)
                    {
                        Console.WriteLine(e.Message);
                    }

                }
                else
                {
                    Console.WriteLine("The File does not exist");
                }
                try
                {


                    if (validation == true)
                    {

                        outFile = new StreamWriter(@"C:\Users\thomas\Desktop\email\email.txt", true);
                        outFile.WriteLine(email);
                        outFile.WriteLine(date.ToLongDateString());
                        outFile.Close();
                        Console.WriteLine("The email was added");
                    }
                }
                catch (System.IO.IOException e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Enter another Email?");
                decision = Convert.ToChar(Console.ReadLine());
            }// end of while
            Console.Read();
        }
    }
}
