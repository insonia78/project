import java.util.Arrays;

public class main {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		int[] numList= {1,8,4,6,10,27,11};
		int sum = 0;
		for(int i = 0 ;i < numList.length;i++)
		{
			sum += numList[i];
		}
        System.out.println(sum/numList.length);
	
	int currentIndexOfC = 0 ;
	int[] listA = {5,10,15,20,25,30,35};
	System.out.println("Binary Search:");
	System.out.println(binarySearch(listA, 30));
	int[] listB = {4,5,1,10,22,20,30};
	int[] listC = new int[listA.length];
	
	for(int i = 0 ; i < listA.length; i++)
	{
		for(int  y = 0 ; y < listB.length;y++)
		{
			
     		if(listA[i] == listB[y])
     		{
     			listC[currentIndexOfC] = listA[i];
     			currentIndexOfC +=1;
     		}
		}
			
	}
	System.out.println(Arrays.toString(listC));
	
	
	}
    public static int binarySearch(int[] values, int searchValue)
    {
    	int i0 = 0,i1 = values.length-1;
    	while(i0 < i1) {
    		int iMid = (i0+i1)/2,v = values[iMid];
    		if(v == searchValue) return iMid;
    		if(v > searchValue) i1 = iMid - 1;else i0 = iMid +1;
    	}
    	
    	return ~i0;
    }
}
