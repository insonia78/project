
/**
 * Write a description of class QuickSort here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class QuickSort
{
   
    public static void main(String[] args)
    {
        int[] array ={5,1,3,6,4,2};
        quickSort(array);
    
    }
    public static void quickSort(int[] array)
    {
        doQuickSort(array,0,array.length -1);
    }
    private static void doQuickSort(int[] array,int start,int end){
        int pivotPoint;
        printArray(array);
        System.out.println(start+"start- end"+ end);
        if(end-start>0){
           System.out.println("Inside the first if");
            pivotPoint = partition(array,start,end);
           doQuickSort(array,start,pivotPoint -1);
           doQuickSort(array,pivotPoint +1,end);
        }
    }
    private static int partition(int[] array,int start, int end){
        System.out.println("Inside the partition");
        int partition;
        int endOfLeftList;
        int mid,temp;
        mid =(start+end)/2;
        partition=array[mid];
        temp = array[start];
        array[start] = array[mid];
        array[mid] = temp;
        int left = start;
        int right = end;
        while(left < right){
            while(array[left]>partition && left<right){
                left++;
            }
            while(array[right]<partition){
                right--;
            }
            if(left<right){
                temp = array[left];
                array[left] = array[right];
                array[right] = temp;
            }
        }
        temp =array[start];
        array[start] = array[end];
        array[end] = temp;
        
        printArray(array);
        return right;
        
    }
     /*   for(int scan = start + 1; scan<=end;scan++){
            System.out.println("inside the for loop");
            printArray(array);
            System.out.print("index"+scan+" array[start]"+array[scan]);
            if(array[scan]<pivotValue){
               System.out.println("Inside the if statment");
                printArray(array);
                
                endOfLeftList++;
                System.out.print(" endOfLeftList"+ endOfLeftList+"scan"+scan);
                System.out.println("swap");
                swap(array,endOfLeftList,scan);
                printArray(array);
            }
        }
        swap(array,start,endOfLeftList);
        printArray(array);
        return endOfLeftList;
    }
    private static void swap(int[] array,int a, int b){
        System.out.println("Inside the first swap");
        int temp;
        temp = array[a];
        System.out.print("temp"+temp+" ");
        printArray(array);
        array[a]=array[b];
        System.out.print(" array[a]"+array[a]+" ");
        printArray(array);
        array[b]=temp;
        System.out.println(" array[b]"+array[b]+" ");
        printArray(array);
    }
    */
    public static void printArray(int[] array){
        for(int i = 0; i<array.length;i++){
            System.out.print(array[i]+" ");
        }
        System.out.println("");
    }
    
}
            

    

