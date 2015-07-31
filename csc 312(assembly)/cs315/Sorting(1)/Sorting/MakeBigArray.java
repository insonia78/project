import java.util.Random;


/**
 * Write a description of class Random here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */


    // instance variables - replace the example below with your ownimport java.util.Random;
public class MakeBigArray

{   static int TEST_ARRAY_SIZE = 100000; // Put in an appropriate integers
    private static int MIN_VALUE = 1;
    private  static int MAX_VALUE = 100000;
    private final static Random gen = new Random();
   
    
    public static void main (String[] args) {
        Integer[] data = new Integer[TEST_ARRAY_SIZE];
        Integer[] sortedArray = new Integer[TEST_ARRAY_SIZE];
        
        System.out.print("\nUnsorted list Size = " + TEST_ARRAY_SIZE);
        makeTestArray(sortedArray,sortedArray);
        data = initSorted(sortedArray);
        timing(data,data);
        
        System.exit(0);
        
        for(int i = 0; i < 3; i++)
        {
            TEST_ARRAY_SIZE *= 10;
            Integer[] data1 = new Integer[TEST_ARRAY_SIZE];
            Integer[] sortedArray1 = new Integer[TEST_ARRAY_SIZE];
            makeTestArray(data1,sortedArray1);
            System.out.print("\nUnsorted list Size = " + TEST_ARRAY_SIZE);
            timing(data1,sortedArray1);
            MIN_VALUE *= 10;
            MAX_VALUE = 9 + (MAX_VALUE *=10); 
            
            
        }
        System.exit(0);
        
        makeTestArray(data,sortedArray);
        
        print("\nUnsorted list size = "+TEST_ARRAY_SIZE,sortedArray);
        Sorting.quickSort(data,0,(data.length - 1));
        print("\n\nQuick Sort",data);
        
        print("\n\nUnsorted list",sortedArray);
        data = Sorting.PbubbleSort(sortedArray,sortedArray.length);
        print("\n\nBubble sort",data);
      
        // This code can be used to create an Array that has random integers.  
   //The size of the array and the minimum and maximum value of the random integers are defined by the constants.        
    }
        
        public static void makeTestArray(Integer[] data,Integer[] array)
        {
            
            int rangeMax = MAX_VALUE - MIN_VALUE + 1;
            
            for (int i = 0; i < array.length; i++)
            {
                array[i] = new Integer(gen.nextInt(rangeMax) + MIN_VALUE);
                data[i] = array[i];
            }  
           
            
        }
        public static void print(String title,Integer[] data)
       {
         System.out.println(title);
         for (int index = 0; index < data.length; index++)
        {
          System.out.printf("%5d",data[index]);
         
          if(index % 20 == 19)
          {
             System.out.println("\n");
          }
         }
       }
       public static void timing(Integer[] data1 ,Integer[] sortedArray1)
       {
          
           long startTime = System.nanoTime();    
           Sorting.quickSort(data1,0,(data1.length - 1));
           long estimatedTime = System.nanoTime() - startTime;
           System.out.print("\nThe quick sort time is " + estimatedTime);
           long startTime2 = System.nanoTime();    
           Sorting.PbubbleSort(sortedArray1,sortedArray1.length);
           long estimatedTime2 = System.nanoTime() - startTime;
           System.out.print("\nThe bubble sort time is " + estimatedTime2);
           System.out.println("\n");
        }
        public static Integer[] initSorted(Integer[] data)
        {
               Sorting.quickSort(data,0,(data.length - 1));
               return data;
        }
    }
