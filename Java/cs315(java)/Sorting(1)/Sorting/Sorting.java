import java.util.*;
/**
 * This class contains methods that sort an array of objects using various
 * algorithms.
 *
 * @author Lewis and Chase
 * @version 3.1
 */
public class Sorting
{	/**
	 * Swaps to elements in an array. Used by various sorting algorithms.
	 *
	 * @param data the array in which the elements are swapped
	 * @param index1 the index of the first element to be swapped
	 * @param index2 the index of the second element to be swapped
	 */
	private static <T extends Comparable<? super T>> void swap(T[] data,
			int index1, int index2)
	{
		T temp = data[index1];
		data[index1] = data[index2];
		data[index2] = temp;
	}

/*** Sorts the specified array of objects using the quick sort algorithm.
	  * @param data the array to be sorted
	 */
	//public static <T extends Comparable<? super T>> T[] quickSort(T[] data)
	//{
	//	quickSort(data, 0, data.length - 1);
//	}

	/**
	 * Recursively sorts a range of objects in the specified array using the
	 * quick sort algorithm. The parameters min and max represent the range of
	 * values on which the sort is performed.
	 *
	 * @param data the array to be sorted
	 * @param min the minimum index in the range to be sorted
	 * @param max the maximum index in the range to be sorted
	 */
	public static <T extends Comparable<? super T>> T[] quickSort(T[] data,
			int min, int max)
	{
		if (min < max)
		{
			// create partitions
			int indexofpartition = partition(data, min, max);

			// sort the left partition (lower values)
			quickSort(data, min, indexofpartition - 1);

			// sort the right partition (higher values)
			quickSort(data, indexofpartition + 1, max);
		}
		return data;
	}

	/**
	 * Used by the quick sort algorithm to find the partition.
	 *
	 * @param data the array to be sorted
	 * @param min the minimum index in the range to be sorted
	 * @param max the maximum index in the range to be sorted
	 */
	private static <T extends Comparable<? super T>> int partition(
			T[] data, int min, int max)
	{
		T partitionelement;
		int left, right;
		int middle = (min + max) / 2;

		// use the middle data value as the partition element
		partitionelement = data[middle];
		// move it out of the way for now
		swap(data, middle, min);

		left = min;
		right = max;

		while (left < right)
		{
		    
	// search for an element that is > the partition element
	   while (left < right && data[left].compareTo(partitionelement) <= 0)
	   {    
			  left++;
	   }

	// search for an element that is < the partition element
			while (data[right].compareTo(partitionelement) > 0)
				right--;

	// swap the elements
			if (left < right)
				swap(data, left, right);
		}

		// move the partition element into place
		swap(data, min, right);

		return right;
	}
	 public static <T extends Comparable<? super T>> T[] mergeSort (T[] data, int min, int max)
   {
      T[] temp;
      int index1, left, right;

      /** return on list of length one */
      if (min==max)
        return data;

      /** find the length and the midpoint of the list */
      int size = max - min + 1;
      int pivot = (min + max) / 2;
      temp = (T[])(new Comparable[size]);

      mergeSort(data, min, pivot); // sort left half of list
      mergeSort(data, pivot + 1, max); // sort right half of list

      /** copy sorted data into workspace */
      for (index1 = 0; index1 < size; index1++)
         temp[index1] = data[min + index1];

      /** merge the two sorted lists */
      left = 0;
      right = pivot - min + 1;
      for (index1 = 0; index1 < size; index1++)
      {
         if (right <= max - min)
            if (left <= pivot - min)
               if (temp[left].compareTo(temp[right]) > 0)
                  data[index1 + min] = temp[right++];

               else
                  data[index1 + min] = temp[left++];
            else
               data[index1 + min] = temp[right++];
         else
            data[index1 + min] = temp[left++];
      }
      return data;
   }

   public static <T extends Comparable<? super T>> T[] PbubbleSort(T[] theArray, int n) {
// ---------------------------------------------------
// Sorts the items in an array into ascending order.
// Precondition: theArray is an array of n items.
// Postcondition: theArray is sorted into ascending
// order.  From Prichard&Carrano
// ---------------------------------------------------
  boolean sorted = false;  // false when swaps occur

  for (int pass = 1; (pass < n) && !sorted; ++pass) {
    // Invariant: theArray[n+1-pass..n-1] is sorted
    //            and > theArray[0..n-pass]
    sorted = true;  // assume sorted
    for (int index = 0; index < n-pass; ++index) {
      // Invariant: theArray[0..index-1] <= theArray[index]
      int nextIndex = index + 1;
      if (theArray[index].compareTo(theArray[nextIndex]) > 0) {
        // exchange items
        T temp = theArray[index];
        theArray[index] = theArray[nextIndex];
        theArray[nextIndex] = temp;
        sorted = false;  // signal exchange
      }  // end if
    }  // end for

    // Assertion: theArray[0..n-pass-1] < theArray[n-pass]
  }  // end for
  return theArray;
}  // end bubbleSort

  public static <T extends Comparable<? super T>> T[] PinsertionSort(T[] theArray, int n) {
// ---------------------------------------------------
// Sorts the items in an array into ascending order.
// Precondition: theArray is an array of n items.
// Postcondition: theArray is sorted into ascending
// order. FROM PRITCHARD & CARRANO
// ---------------------------------------------------
  // unsorted = first index of the unsorted region,
  // loc = index of insertion in the sorted region,
  // nextItem = next item in the unsorted region

  // initially, sorted region is theArray[0],
  //          unsorted region is theArray[1..n-1];
  // in general, sorted region is theArray[0..unsorted-1],
  //          unsorted region is theArray[unsorted..n-1]

  for (int unsorted = 1; unsorted < n; ++unsorted) {
    // Invariant: theArray[0..unsorted-1] is sorted

    // find the right position (loc) in
    // theArray[0..unsorted] for theArray[unsorted],
    // which is the first item in the unsorted
    // region; shift, if necessary, to make room
    T nextItem = theArray[unsorted];
    int loc = unsorted;

    while ((loc > 0) &&
           (theArray[loc-1].compareTo(nextItem) > 0)) {
      // shift theArray[loc-1] to the right
      theArray[loc] = theArray[loc-1];
      loc--;
    }  // end while
    // Assertion: theArray[loc] is where nextItem belongs
    // insert nextItem into sorted region
    theArray[loc] = nextItem;
  }  // end for
  return theArray;
}  // end insertionSort






   public static <T extends Comparable<? super T>> T[] selectionSort (T[] data)
   {
      int min;
      T temp;

      for (int index = 0; index < data.length-1; index++)
      {
         min = index;
         for (int scan = index+1; scan < data.length; scan++)
            if (data[scan].compareTo(data[min])<0)
               min = scan;

         /** Swap the values */
         temp = data[min];
         data[min] = data[index];
         data[index] = temp;
      }
      return data;
   }

}

