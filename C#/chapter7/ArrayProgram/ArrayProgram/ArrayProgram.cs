/* program 7
 * @author Thomas Zangari
 * This program ask to entry value in to an array that the user decided the quanity.
 * Every iteration the user is asked if he wants to continue inputing. It displays  how many values were inputed and the quantity of each single input 
 * 
 */
 



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace ArrayProgram          
{
    class ArrayProgram
    {
        /* Main methos
         * @parm dimension askes the dimension of the array 
         * @parm size olds the value for the dimension and it is passed in the GetValue method
         * 
         */
        static void Main(string[] args)
        {
            int dimension = 0;           // the dimension of the array
            int size = Intro(dimension); // setting the size variable with the Intro method
            GetValues(size);             // gets the values from the user 
            Console.Read();
        }
        /* Intro method introduces the program and gets the dimension of the array
         * @returns the dimension
         * */
        public static int Intro(int dimension)
        {
            bool confirm = true;
            Console.WriteLine("Welcome to data entry. This program uses an array of integers");
            do
            {

                Console.Write("\nhow long is going to be the array?");
                if (Int32.TryParse(Console.ReadLine(), out dimension) == false)
                {
                    MessageBox.Show("Invalid Entry", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    confirm = true;
                }
                else
                {
                   
                    confirm = false;
                }
            } while (confirm == true);
            return dimension;
        }
        /*Iniziales the array to values of -1
         *@returns the array initizialed  
         */
        public static int[] Inizialized(int size, int[] array1)
        {
            for (int i = 0; i < array1.Length; i++)
            {
                array1[i] = -1;
            }
            return array1;
        }
        /*Gets the values to inser in the array and it copies to a second array so to be sorted 
         * @param array1
         * @param array2
         * @param value
         * @param confirm
         * @param count
         * @param decision
         * */
        public static void GetValues(int size)
        {
            int[] array1 = new int[size];                    // the first array that holds the users input
            int[] array2 = new int[array1.Length];           // the second that is sorted 
            int value ;                                      // holds the users input
            bool confirm = true;                             // used in the do while loop for the decision
            int count = 0;                                   // count how many entries were made 
            char decision = 'Y';                             // variable that holds the users input if he want to continue to insert elements in to the array
            bool decision2 = true;
            // calling the Inizialized menthod to inizialized all the elements to -1 
            array1 = Inizialized(size, array1);     

            //for loop for the entry of the users inputs  with decision if he wants to continue inputing 
            for (int i = 0; i < array1.Length; i++)
            {

                do
                {
                    Console.Write("\nEnter the values that you want to add in the array (Values suppose be in the range of 0 and 10):");
                    if ((Int32.TryParse(Console.ReadLine(), out value) == false))
                    {
                        MessageBox.Show("Invalid Entry", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        confirm = true;
                    }
                    else
                    {
                        if ((value < 0) || (value > 10))
                        {
                            MessageBox.Show("Invalid Entry", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            confirm = true;
                        }
                        else
                        {
                            array1[i] = value;
                            confirm = false;
                            count++;
                        }
                    }
                } while (confirm == true);
                
               
                

                do
                {
                    Console.Write("Do you want to enter another value?(Press Y for yes or N for no):");
                    if (char.TryParse(Console.ReadLine(), out decision))
                    {
                        if (decision == 'Y' || decision == 'y')
                        {
                            decision2 = false;
                        }
                        else if (decision == 'N' || decision == 'n')
                        {
                            decision2 = false;
                        }
                        else
                        {
                            MessageBox.Show("Enter a letter", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            decision2 = true;
                        }
                            
                    }
                    else
                    {
                        MessageBox.Show("Enter a letter", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        decision2 = true;
                    }
                } while (decision2 == true);
                 
                if ((decision == 'Y') || (decision == 'y'))
                {
                    continue;
                }
                else
                {
                    break;
                }



            }// end of for loop
            
            //copieng the values into the seond array 
            for (int i = 0; i < array1.Length; i++)
            {
                array2[i] = array1[i];
            }//end loop
            
            Array.Sort(array2);
            
            Console.WriteLine("You have entered:{0} elements", count);
            
            //calling the print method to print the values and the respective quantity of each value
            Print(array1, array2);


        }
        /* Prints the values of the array
         * @param count for the values of the array
         * @param count2 for the values of the array with values = -1
         * */
        public static void Print(int[] array1, int[] array2)
        {
            int count = 0;                // for the values of the array
            int count2 = 0;               //  for the values that are equal to -1


            
            for (int j = 0; j < array2.Length;)
            {
                for( int i = 0; i < array1.Length;i++)
                {
                    
                    if(array2[i] == -1)
                    {
                       
                         count2++;
                          
                    }
                    else if(array2[j] == array2[i])
                    {
                        
                        count++;
                    }
                } // end of the second loop

                if (array2[j] == -1) // if the values are = to -1 no display
                {
                    
                }
                else
                {
                    Console.Write("They are:" + count + " of value:" + array2[j] + "\n");
                }

                if (array2[j] == -1) // adding the values of the count to the j variable of the first for loop 
                {
                    j = j + count2;
                    continue;
                    
                }
                else if (j < array2.Length - 1)
                {
                    j = j + count;

                }
                else
                {
                    j = j + 1;
                }
                count = 0;
                count2 = 0;
                 
            } // end of the first loop
                      
        }

    }
}
