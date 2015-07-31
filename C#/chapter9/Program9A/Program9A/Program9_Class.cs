/* program class 
 * This program adds and multyplies two numbers 
 * */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    public class Class
    {
        //variables 
       private double number1,
                     number2;
              

    
        public Class( double n1, double n2)
        {
           number1 = n1;
            number2 = n2;
        
        }
       public double getAddition()
       {
          return number1 + number2;
       }
       public double getMoltiplication()
       {
          return number1 * number2; 
        } 
}
