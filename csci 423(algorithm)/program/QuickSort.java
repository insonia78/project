//Malane Thou
//Analysis of Algorithms
//Program #3

import java.io.File;
import java.io.FileNotFoundException;
import java.util.Arrays;
import java.util.Scanner;


public class QuickSort
{
	static int cnt[]=new int[4],ver=0;
	public static void main(String args[]) throws FileNotFoundException // If file was not found
	{
		
		//Scan in the text file with 10000 #s
		Scanner input = new Scanner(new File("QuickSort.txt"));
		int[] inputArray = new int[10000];
		int n=0;
		for(int i= 0; input.hasNextInt();i++)
		{
			inputArray[i] = input.nextInt();
			n++;
		}
		
		//print array before sorted
		//System.out.println("Before sorting QS1: " + Arrays.toString(array));
		//Sort array with leftmost element
		ver=1;
		cnt[ver]=0;
		quicksort(inputArray, 0, inputArray.length - 1); 
		//Prints sorted array
		//System.out.println("After sorting Using QS1: " + Arrays.toString(array));
		
		//Prints comparisions #
		System.out.println("Total Comparisons Q1: " + cnt[ver]);
		System.out.println();
		
		
		//Rereadin txt file to load array again
		input =new Scanner(new File("QuickSort.txt"));
		n=0;
		for(int i=0;input.hasNextInt();i++)
		{
			inputArray[i]=input.nextInt();
			n++;
		}
		
		//Print unsorted array
		//System.out.println("Before sorting QS2: " + Arrays.toString(array));

		//Sort Array using rightmost element
		ver=2;
		cnt[ver]=0;
		quicksort(inputArray, 0, inputArray.length - 1); 
		
		//Print sorted array
		//System.out.println("After sorting Using QS2: " + Arrays.toString(array));
		
		//Prints comparisions #
		System.out.println("Total Comparisons Q2: " + cnt[ver]); 
		System.out.println();
		
		input = new Scanner(new File("QuickSort.txt"));
		n=0;
		for(int i=0;input.hasNextInt();i++)
		{
			inputArray[i]=input.nextInt();
			n++;
		}
		
		//Prints unsorted array
		//System.out.println("Before sorting QS3: " + Arrays.toString(array));
		//Sorts using median
		ver=3;
		cnt[ver]=0;
		quicksort(inputArray, 0, inputArray.length - 1); 
		
		//Print sorted array
		//System.out.println("After sorting Using QS3: " + Arrays.toString(array));
		
		//Prints comparisions #
		System.out.println("Total Comparisons Q3: " + cnt[ver]);
	}


	public static void quicksort(int[] array, int startIdx, int endIdx) 
	{
		int idx = partition(array, startIdx, endIdx);

		// Recursively call quicksort with left part of the partitioned array
		if (startIdx < idx - 1) {
			quicksort(array, startIdx, idx - 1);
		}
		// Recursively call quick sort with right part of the partitioned array
		if (endIdx > idx) 
		{
			quicksort(array, idx, endIdx);
		}
	}
	
	/**
	 * Divides array from pivot, left side contains elements less than
	 * Pivot while right side contains elements greater than pivot.
	 *
	 */
	public static int partition(int[] array, int left, int right) {
		int pivot =0,tmp;
		if(ver==1)
		{
			pivot = array[left]; // taking first element as pivot	
		}
		else if(ver==2)
		{
			pivot = array[right]; // taking first element as pivot
			tmp = array[left];
			array[left] = array[right];
			array[right] = tmp;
		}
		else if(ver==3)
		{
			pivot = array[(left+right)/2]; // taking first element as pivot	
			tmp = array[left];
			array[left] = array[right];
			array[right] = tmp;
		}
		while (left <= right)
		{
			//searching number which is greater than pivot, bottom up
			while (array[left] < pivot) 
			{
				cnt[ver]++;
				left++;
			}
			//searching number which is less than pivot, top down
			while (array[right] > pivot) 
			{
				cnt[ver]++;
				right--;
			}

			// swap the values
			if (left <= right) 
			{
				//cnt[ver]++;
				tmp = array[left];
				array[left] = array[right];
				array[right] = tmp;

				//increment left index and decrement right index
				left++;
				right--;
			}
		}
		return left;
	}
}