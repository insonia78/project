import java.io.*;
import java.util.*;
public class Program
{
        
        static Scanner infile ;
        static int runningTotal;
       public  static void main(String[] args)
       {
           
          ArrayList<Integer> size = new ArrayList<>();
    
          
          int i = 0;
         
     
       try
       {
            
          infile = new Scanner(new FileReader("number.txt"));
           while (infile.hasNext())
           {
               size.add(infile.nextInt());
               i++;   
               
               
           }
          int[] array = new int[size.size()];
          int[] arrayRightMost = new int[size.size()];
           
          int[] arrayMedium = new int[size.size()];
             
        i = 0;
      while(i < size.size())
      {      
           array[i] = size.get(i); 
           arrayRightMost[i] = size.get(i);
           arrayMedium[i] = size.get(i);
         i++;
       }
            
        
         System.out.print("\n");
         
         QuickSort(array,0,array.length - 1 );
         System.out.println("The number of comparisons for the left  L -> R  pivot  are "+ runningTotal);
         runningTotal = 0;
         QuickSort2(arrayRightMost,0,arrayRightMost.length - 1 );
         System.out.println("The number of comparisons for the left  R -> L  pivot  are "+ runningTotal);
         runningTotal = 0;
         QuickSort3(arrayMedium,0,arrayMedium.length - 1);
         System.out.println("The number of comparisons for the left  Medium  pivot  are "+ runningTotal);
                    
    }
    catch(Exception e)
    {
        
        System.out.println(e);
       // Console.WriteLine(e.StackTrace);
    }
           
       
}
    /**
     * starts the quicksort alghoritm 
     * @parm database
     * @param index
     * @return doQuickSort method
     */
    private static void QuickSort(int[] a, int l, int r) 
    {
 
		int pivot;
		if(r>l){
			add(r-l);
		pivot =Partition(a,l,r);
 
		QuickSort(a, l, pivot-1);
		QuickSort(a, pivot+1, r);
		}
	}
	private static void QuickSort2(int[] a, int l , int r)
	{
	    int pivot;
		if(r > l){
			add(r - l);
		pivot = Partition2(a,l,r);
 
		QuickSort2(a, l, pivot - 1);
		QuickSort2(a, pivot + 1, r);
		}
	    
	    
	}
	private static void QuickSort3(int[] a, int l , int r)
	{
	   
			
	    int pivot;
		if(r > l){
			add(r-l);
		pivot = partition3(a,l,r);
 
		QuickSort3(a, l, pivot - 1);
		QuickSort3(a, pivot + 1, r);
		}
		
		
	    
	    
	}
 
	private static void add(int i) {
		runningTotal+=i;
 
	}
 
	private static int Partition(int[] a, int l, int r) {
 
       
		int p=a[l];
		int k = l+1 ;
 
		for(int j = l+1 ; j<=r ; j++)
		{
			if(a[j] < p)
			{
				swap(a,k,j);
				k++;
			}
		}
		swap(a, l, k-1);
		return (k-1);
	}
	private static int Partition2(int[] a, int l, int r) 
	{
 
 
		swap(a,r,l);
 
		int p=a[l];
		int k =l+1;
 
		for(int j=l+1;j<=r;j++){
			if(a[j]<p)
			{
				swap(a,k,j);
				k++;
			}
		}
		swap(a, l, k-1);
		return (k-1);
	}
	
    private static int partition3(int[] a,int l,int r)
    {
       
        int pivot = median(a,l,r + 1);    
         swap(a,l,pivot);   
            
        int p=a[l];
		int k =l+1;
 
		for(int j=l+1;j <= r;j++){
			if(a[j]<p)
			{
			    
				swap(a,k,j);
				k++;
			}
			
		}
		swap(a, l, k-1);
		return (k - 1);
}
public static int median(int[] a, int l, int r)
{
            // Define the center of an array
            int middle = ((r - l) % 2 == 0) ? l + (r - l) / 2 - 1 : l + (r - l - 1) / 2;
            // Array of first, middle and last element
            int[] x = {a[l], a[middle], a[r - 1]};
            Arrays.sort(x);
            // Take index of the medianeÃ
            return a[l] == x[1] ? l : a[middle] == x[1] ? middle : r - 1;
 }
        
    /**
     * swaps the elements of the database
     * @param dataBase
     * @param a
     * @param b
     */
    
    private static void swap(int[] a, int l, int r)
    {
        int temp;
        temp = a[l];
        a[l] = a[r];
        a[r] = temp;
    }
    
}

