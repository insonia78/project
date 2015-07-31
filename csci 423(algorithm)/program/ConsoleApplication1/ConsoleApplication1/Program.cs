using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gcd
{
    public class Gcd
    {
        public Gcd(long n)
        {
            int Maxcnt = 0,
            Maxgcd = 0,
            MaxZ = 0,
            grcd = 0,
            Maxj = 0;
            int i = 0,y = 0;
            int remaindor = 0;
            int numerator = 0;
            int denominator = 0;



            for (int z = 2; z <= n; z++)
            {

                //numerator2 = z;
                for (int j = z + 1; j <= n; j++)
                {
                    denominator = j;
                    numerator = z;
                    i = 0;
                    while (denominator != 0)
                    {
                        // int division = numerator / denominator;   
                        remaindor = numerator % denominator;
                        numerator = denominator;
                        denominator = remaindor;
                        i++;
                    }
                    //denominator = j; ..............

                    grcd = numerator;
                    if (i > Maxcnt)
                    {
                        Maxcnt = i;
                        Maxgcd = grcd;
                        MaxZ = z;
                        Maxj = j;
                    }

                }
            }
        
            Console.WriteLine("For N ={0}\n The GCD of {1} and {2}= {3} and it took {4} divisions",n, MaxZ,Maxj,Maxgcd,Maxcnt);

            
        }
        static void Main(string[] args)
        {

            new Gcd(10);
            new Gcd(20);
            new Gcd(50);
            new Gcd(100);
            new Gcd(1000);
            new Gcd(1000000);
            
            Console.Read();
        }
    }
}
