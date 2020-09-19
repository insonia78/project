/**
 * Performs the quick sort alghoritem 
 */


public class quickSort
{
    /**
     * Empty Constructor
     */
    public quickSort()
    {
	}
	/**
	 * starts the quicksort alghoritm 
	 * @parm database
	 * @param index
	 * @return doQuickSort method
	 */
    public  Employee[] quickSort(Employee[] dataBase,int index)
	{
		   return doQuickSort(dataBase,0,index);
	}
	/**
	 * It sorts the two halfs of the array 
	 * @param dataBase
	 * @param start
	 * @param end
	 * @return dataBase
	 * 
	 */
	private Employee[] doQuickSort(Employee[] dataBase,int start, int end)
	{
		int pivotPoint;
		if(start < end)
		{
			pivotPoint = partition(dataBase, start,end);

			doQuickSort(dataBase,start,pivotPoint -1);
			doQuickSort(dataBase,pivotPoint +1, end);
		}
		return dataBase;
	}
	/**
	 * it partition the two halfs of the array
	 * and uses the swamo method to swap the elements 
	 * @param dataBase
	 * @param start
	 * @param end
	 * @return endOflist
	 */
	private int partition(Employee[] dataBase,int start,int end)
	{
		String pivotValue;
		int endOfLeftList;
		int mid;
		mid = (start+ end)/2;
		swap(dataBase,start,mid);

		pivotValue = dataBase[start].getName();
		endOfLeftList = start;

		for(int scan = start +1; scan <= end && dataBase[scan] != null; scan++)
		{
			if(dataBase[scan].getName().compareTo(pivotValue)<0)
			{
				endOfLeftList++;
				swap(dataBase, endOfLeftList, scan);
			}
		}
		swap(dataBase,start,endOfLeftList);
		return endOfLeftList;
	}
	/**
	 * swaps the elements of the database
	 * @param dataBase
	 * @param a
	 * @param b
	 */
	private void swap(Employee[] dataBase, int a, int b)
	{
		Employee temp;
		temp = dataBase[a];
		dataBase[a] = dataBase[b];
		dataBase[b] = temp;
	}
}