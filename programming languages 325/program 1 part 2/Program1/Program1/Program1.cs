using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Program1
    {
        char[] chart;
        bool ok = false;
        public Program1()
        {
           String[] input = {
	"",
	" ",
	"   ",
	"a",
	"abc",
	" GFD ",
	"  !@#$ ",
	"_",
	"L",
	" 1 2 3 ",
	"0X",
	"0x",
	"ox",
	"0XL",
	"L2",
	"08",
	" 0xab L ",
	"0b",
	"0xag",
	"1LL",
	"0",
	"3",
	"4",
	"5",
	"8",
	"9",
	"0l",
	"  123  ",
	"1029384756",
	"1l",
	" 12",
	"23 ",
	" 345 ",
	"45L",
	" 56L",
	"67L ",
	" 89L ",
	"  00",
	"01",
	"    01234567 ",
	" 01l",
	" 017l",
	"0000",
	"0000L",
	"01276l",
	"0x0000",
	"0X0",
	"0x1234567890abcdefABCDEF",
	" 0XCaBeL ",
	"   0x0L   ",
	"0b0",
	"0B110",
	" 0B1l ",
	"0b11L",
	"0b01010110",
	"1_2",
	" 3__4__5",
	"0_0",
	"01_2_3__4_5_6_7L",
	"0x12_AB",
	"0XF__A__9l",
	" 0b0__1",
	"0B1_1_0_1L ",
	"_1",
	"2_",
	"3_L",
	"00_",
	"01_L",
	"0x_a",
	"0XF_",
	"0x23_f_L",
	"0b_1",
	"0B00_",
	"0b1__0_L",
	"_L"
};
         //  String[] input = { "67L " };
            int a = 'A';
            Console.WriteLine(a);
              foreach(String strings in input) 
           {                  
                        
               Console.WriteLine("The string {0} is {1} ",strings,CheckFor(strings).ToString());
                         
           }               
            Console.Read();
        }
        public bool CheckFor(String l)
        {
            bool test = true;
            bool valid = true;
            
            ok = checkForSpaces(l);
            
            
            if (ok == true)
            {

                for (int i = 0; i < chart.Length && test == true; i++)
                {
                    int v = chart[i];
                    if (Convert.ToInt32(chart[i]) == 48 && i == 0 && chart.Length > 1)
                    {
                        test = true;

                    }
                    else if (Convert.ToInt32(chart[i]) == 120 && i == 1 && chart.Length > 2)
                    {
                        test = true;
                    }
                    else if (v >= 48 && v <= 57 && i > 1)
                    {
                        test = true;
                    }
                    else if (v >= 65 && v <= 70 && i > 1)
                    {
                        test = true;
                    }
                    else if (v >= 97 && v <= 102 && i > 1)
                    {
                        test = true;
                    }
                    else
                    {
                        test = false;
                        break;
                    }
                    if (i == chart.Length - 1 && test != false)
                    {
                        test = true;
                    }


                }

                for (int i = 0; i < chart.Length && test == false; i++)
                {
                    if (chart[i] == '0')
                    {
                        
                    }
                    else if (chart[i] == '1')
                    {
                        
                    }
                    else
                    {
                        test = false;
                        break;
                    }
                    if (i == chart.Length -1 && test == false)
                    {
                        test = true;
                    }
                }
                for (int i = 0; i < chart.Length && test == false; i++)
                {
                    if (chart[i] == '0' && valid == true)
                    {
                        
                        continue;
                    }
                    else
                    {

                        if (chart[i] == '0')
                        {
                            valid = false;
                            test = false;
                            break;
                        }
                        else if (chart[i] == '1')
                        {
                            
                           
                        }
                        else if (chart[i] == '2')
                        {
                            
                            
                        }
                        else if (chart[i] == '3')
                        {
                            
                            
                        }
                        else if (chart[i] == '4')
                        {
                           
                            
                        }
                        else if (chart[i] == '5')
                        {
                            
                            
                        }
                        else if (chart[i] == '6')
                        {
                            
                        }
                        else if (chart[i] == '7')
                        {
                            
                            
                        }
                        else
                        {
                            test = false;
                            break;
                        }
                        if (i == chart.Length - 1 && test == false)
                        {
                            test = true;
                        }
                    }
                }
                for (int i = 0; i < chart.Length && test == false; i++)
                {
                    if (Convert.ToInt32(chart[i]) >= 48 && Convert.ToInt32(chart[i]) <= 57)
                    {
                        
                    }
                    else
                    {
                        test = false;
                        break;
                    }
                    if (i == chart.Length - 1 && test == false)
                    {
                        test = true;
                    }

                }

                for (int i = 0; i < chart.Length && test == false; i++)
                {
                    if (chart[chart.Length - 1] == 'L' || chart[chart.Length - 1] == 'l')
                    {
                        if (chart[i] == '0')
                        {

                        }
                        else if (chart[i] == '1')
                        {
                        }
                        else if (chart[i] == '2')
                        {
                        }
                        else if (chart[i] == '3')
                        {
                        }
                        else if (chart[i] == '4')
                        {
                        }
                        else if (chart[i] == '5')
                        {
                        }
                        else if (chart[i] == '6')
                        {
                        }
                        else if (chart[i] == '7')
                        {
                        }
                        else if (chart[i] == '8')
                        {

                        }
                        else if (chart[i] == '9')
                        {

                        }
                        else if (chart[chart.Length - 1] == 'l' || chart[chart.Length - 1] == 'L' && i > 1)
                        {

                        }
                        else
                        {
                            test = false;
                            break;
                        }
                    }
                    else
                    {
                        test = false;
                        break;
                    }
                    if (i == chart.Length - 1 && test == false)
                    {
                        test = true;
                    }


                }

                

            }
            else
            {
                test = false;
            }
            return test;
        }
        public bool checkForSpaces(String l)
        {

            bool ok = false;
            int spaces = 0,
                 leters = 0;
            try
            {
                char[] value = l.ToCharArray();

                int[] check = new int[value.Length];
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] == ' ')
                    {
                        check[i] = 0;
                        spaces++;
                    }
                    else
                    {
                        check[i] = 1;
                        leters++;
                    }
                }
                if (check[0] == 0 && (value.Length - 1) == leters)
                {
                    chart = new char[value.Length - 1];
                    for (int i = 1; i < value.Length; i++)
                    {
                        chart[i - 1] = value[i];
                    }

                    ok = true;
                }
                else if (check[value.Length - 1] == 0 && (value.Length - 1) == leters)
                {
                    chart = new char[value.Length - 1];
                    for (int i = value.Length-2; i >= 0; i--)
                    {
                        chart[i] = value[i];
                    }

                    ok = true;
                }
                else if (check[0] == 0 && check[value.Length - 1] == 0 && (value.Length - 2) == leters)
                {
                    chart = new char[value.Length - 2];
                    for (int i = 1; i < value.Length - 1; i++)
                    {
                        chart[i - 1] = value[i];
                    }

                    ok = true;
                }
                else if (value.Length == leters)
                {
                    chart = new char[value.Length];
                    for (int i = 0; i < value.Length; i++)
                    {
                        chart[i] = value[i];
                    }
                    ok = true;
                }
                else
                {
                    for (int i = 1; i < (value.Length - 1); i++)
                    {
                        if (check[i] == 0 && check[i - 1] == 1 && check[i + 1] == 1)
                        {
                            ok = false;
                            break;
                        }
                        else
                        {
                            ok = true;
                        }
                    }
                    if (ok == true)
                    {
                        chart = new char[leters];
                        int count = 0;
                        for (int i = 0; i < (value.Length); i++)
                        {
                            if (check[i] == 0)
                            {
                                count++;
                            }
                            else
                            {
                                chart[i - count] = value[i];
                            }
                        }

                    }                    
                }
                if (leters == 0)
                {
                    ok = false;
                }
            }
            catch (Exception e)
            {
                ok = false;
            }


            return ok;
        }// end method
        
    
     
        public static void Main(string[] args)
        {
            new Program1();
        }
     
    }
}
