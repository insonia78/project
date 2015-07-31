/*Program 8
 * @author : Thomas Zangari
 * this program creates a table  of random numbers, stores it in a double array and then it squares it.
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




    public class Program8b
    {
        int[,] array = new int[10,2];       // double array
        Random numbers = new Random();     
        String print = "";                  // holding the print variable that is going to be used for the messageBox.show method 
        
        /*
         * constructor
         * */
        public Program8b()
        {
            PrintBoard();
            MessageBox.Show(print,"OutPut");
        }
        /*This method creates the table and generates the numbers 
         * */
        public void PrintBoard()
        {
              int col =0;       // holds the colon variables 
              int row = 0,
                  row3 = 0;
              bool line = true;

          for(int i = 0;i < array.GetLength(0) + 1; i++)
          {
              if (i == 0)
              {
                   print += "            X    X^2";
              }


			 while(line == true && i < 11)
             {
				 for(row = 0; row < array.GetLength(0) + 1  && line == true;row++)
                 {
                     print += "\n";
                     print += "row";
					for (col = 0;col < array.GetLength(1);col++)
                    {
                        
                        
                            print += " + ";
                            print += " - ";
						 
					 } // end of for
					 print +="+";
					 line = false;
                     

				 }//end of out for
			 } // end of while
                 print += "\n";
				 while(line == false && i < 10)
                 {
					 
                     while ( row3 < array.GetLength(0) && line == false)
                     {
                         print += (row3 +1)+"      ";
						 for( col = 0; col < array.GetLength(1); col++)
                         {
                             if (row3 == 9)
                             {
                                 print += "| ";
                             }
                             else
                             {
                                 print += " | ";
                             }


                             
                             if (col == 1)
                             {
                                  
                                 
                                 array[row3, col] =(int)Math.Pow(array[row3, (col - 1)],2);
                                 print += array[row3, col];

                             }// end of if
                             else
                             {
                                 array[row3, col] = numbers.Next(100);
                                 print += array[row3, col];

                             }



						 }// end of for
						 print +=("|");
						 line = true;
                         row3++;

					 }// end of out while
				 }//end of while
          }// end of first for
        }// end of method
        
        

   }
 namespace Program8
 {
     class Program8
     {

        public static void Main()
        {
           Program8b program =  new Program8b();
        }
    }
}

