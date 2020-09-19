
/**
 * Write a description of class Sorting here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
/**
 * This class contains methods that sort an array of objects using various
 * algorithms.
 * 
 * @author Lewis and Chase
 * @version 3.1
 */
public class Sorting
{	
	private static <T extends Comparable<? super T>> void swap(T[] data,
			int index1, int index2)
	{
		T temp = data[index1];
		data[index1] = data[index2];
		data[index2] = temp;
	}

	public static <T extends Comparable<? super T>> void quickSort(int[] data)
	{
		quickSort(data, 0, data.length - 1);
	}

	
	 
	public static <T extends Comparable<? super T>> void quickSort(T[] data,
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
	}

	
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


