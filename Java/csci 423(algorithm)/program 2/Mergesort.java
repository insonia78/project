
import java.io.*;
import java.util.*;
public class Mergesort {
   static  long[] numbers;
   static  long[] array; 
   static  long[] helper;
   
   static  int number;
   static  long inversions = 0;
   static  long brutforceinversion = 0;
   static  long i = 0;
   public static void main(String[] args)
   {
       ArrayList<Integer> arraylist = new ArrayList<>();
       Scanner infile;
       Random ran ;
       
       int i = 0;
       int size  = 10;
       
      while(size <= 100)
      {
          array = new long[size];
         while( i < size)
         {
             ran = new Random();
            array[i] = ran.nextInt(1000) + 1;
            i++;
           
         }
         i = 0;
         System.out.println("the unsorted array is of size:"+ size); 
         print(array);
         
        
         for(int z = 0; z <= (array.length - 2); z++)
         {
           for(int j  = z + 1; j <= (array.length -1); j++)
           {
               if(array[z] > array[j])
               {
                  brutforceinversion++;
               }
                  
          }              
       }
       System.out.println("the sorted array "); 
         sort(array);
         print(array);
         size *= 10;
        System.out.println("the number of inversions are:"+inversions);
        System.out.println("the brut force inversion count:"+ brutforceinversion) ;
        array = null;
      }
       
      
       i = 0;
       size = 0;
       inversions = 0;
       brutforceinversion = 0;
       try
       {
          infile  = new Scanner (new FileReader("numbers.txt")); 
         
         while(infile.hasNext())
         {
            arraylist.add(infile.nextInt());
            i++;
            size++;
         }
     
      array = new long[size];
      i = 0;
      while(i < size)
      {
               
        array[i] =  arraylist.get(i);
        i++;
      }
      
       for(int z = 0; z <= (array.length - 2); z++)
       {
           for(int j  = z + 1; j <= (array.length -1); j++)
           {
               if(array[z] > array[j])
               {
                  brutforceinversion++;
               }
                  
          }
              
       }
       sort(array);
       }
       catch(Exception e) 
       {
              System.out.println(e.getMessage());
       }  
        System.out.println("the number of inversions are:"+inversions);
        System.out.println("the brut force inversion count:"+ brutforceinversion) ;      
    }

  public static void sort(long[] values) {
    numbers = values;
    number = values.length;
    helper = new long[number];
    inversions += mergesort(0, number - 1);
  }

  public static long  mergesort(int low, int high) {
    // check if low is smaller then high, if not then the array is sorted
     long inversion = 0; 
    if (low < high) {
      // Get the index of the element which is in the middle
      int middle = low + (high - low) / 2;
      // Sort the left side of the array
    inversion =  mergesort(low, middle);
      // Sort the right side of the array
    inversion +=  mergesort(middle + 1, high);
      // Combine them both
    inversion +=  merge(low, middle, high);
    }
    return inversion ;
  }

  public static long merge(int low, int middle, int high) {
  
    int inversion = 0;
   
    // Copy both parts into the helper array
    for (int i = low; i <= high; i++) 
    {
        
      helper[i] = numbers[i];
     
    }
    
    int i = low;
    int j = middle + 1;
    int k = low;
    // Copy the smallest values from either the left or the right side back
    //  to the original array
    while (i <= middle  && j <= high) {
     
       
       
      if (helper[i] <= helper[j]) {
       
        numbers[k] = helper[i];
        i++;
      } else {
       
        numbers[k] = helper[j];
        j++;
        inversion = inversion + ((middle+1) - i);
      }
      k++;
    }
    
    // Copy the rest of the left side of the array into the target array
    while (i <= middle) {
       
      numbers[k] = helper[i];
      k++;
      i++;
    }
  return inversion;
  }
  public static void print(long[] array)
  {
      for(int i = 0; i < array.length; i++)
      {
          System.out.print(array[i]+" ");
          if( (i+1) % 10 == 0)
          {
            System.out.print("\n");  
            }
        }
    }
} 

