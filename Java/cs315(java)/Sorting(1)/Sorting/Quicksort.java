
/**
 * Write a description of class Quicksort here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class Quicksort
{
    private static <T extends Comparable<? super T>> void swap(T[] data,
			int index1, int index2)
	{
		T temp = data[index1];
		data[index1] = data[index2];
		data[index2] = temp;
	}
    
    
    
    // instance variables - replace the example below with your own
    
    
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
	

		// use the middle data value as the partition element
		partitionelement = data[min];
		// move it out of the way for now
		//swap(data, middle, min);

		left = min;
		right = max;

		while (left < right)
		{
	// search for an element that is > the partition element
	   while (left < right && data[left].compareTo(partitionelement) <= 0)
				left++;

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
     
}
