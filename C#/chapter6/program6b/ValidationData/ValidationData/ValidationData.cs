/*program 6/2 
 * @author Thomas Zangari
 * This program validates a number 
 *  */ 




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValidationData
{
    class ValidationData
    {
        /*Main method 
         * @parm char  decision
         * @parm bool count 
         * */
        static void Main(string[] args)
        {
            char decision = 'Y'; //variable for the decision of the while loop
            bool count = true ; // variable that hold the if statment int the Intro()
            
            ValidateData( decision = Intro(ref decision,ref count ),ref count);
        }
        /*This method hold the intro of the program and if the user want to participate to the program
         *@return decision 
         */ 
        public static char Intro(ref char decision,ref bool count)
        {
            if (count == true)
            {
                Console.WriteLine("Welcome to Validation Data program\nChoose a number from 10 to 50");
                count = false;
            }
            Console.Write("\nDo you want to start(press Y for yes or N for no:)");
            decision = Convert.ToChar(Console.ReadLine());
            return decision;

        }
        /*This method makes al the decision of the program
         * @param double data holds the users input
         * */
        public static void ValidateData(char decision,ref bool count)
        {
            double data = 0.0;
            while ((decision == 'Y') || (decision == 'y'))
            {
                Console.Write("\nEnter the number:");
                data = Convert.ToInt32(Console.ReadLine());

                if ((data < 10) || (data > 50))
                {
                    MessageBox.Show("Invalid range\n you entered:" + data, "message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(data + " Its with in the wright range", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                Intro(ref decision,ref count);
            }

            

            
        }


    }
}
