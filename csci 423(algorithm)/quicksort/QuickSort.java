
import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;

public class QuickSort {

    static int count = 0;
    static int array[];

    public static void main(String[] args) {
        readFile();
        System.out.println("Reading Input File....");
        count = 0;
        readFile();
        System.out.println("Sorting Using quicksort()");
        quicksort(0, array.length);
        System.out.println("Number of Comparisions In Terms of L & R");
        System.out.println("" + count);
        System.out.println("Reading Input File....");
        count = 0;
        readFile();
        System.out.println("Sorting Using quicksort2()");
        quicksort2(0, (array.length));
        System.out.println("Number of Comparisions In Terms of L & R");
        System.out.println("" + count);
        System.out.println("Reading Input File....");
        count = 0;
        readFile();
        System.out.println("Sorting Using quicksort3()");
        quicksort3(0, array.length);
        System.out.println("Number of Comparisions In Terms of L & R");
        System.out.println("" + count);
    }

    public static void readFile() {
        ArrayList<Integer> list = new ArrayList<Integer>();
        try (BufferedReader br = new BufferedReader(new FileReader("numbers.txt"))) {
            String sCurrentLine;
            while ((sCurrentLine = br.readLine()) != null) {
                list.add(Integer.parseInt(sCurrentLine));
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
        array = new int[list.size()];
        for (int i = 0; i < list.size(); i++) {
            array[i] = list.get(i);
        }
    }

    public static int quicksort(int l, int r) {
        int pivot = array[l];
        int k = l + 1;
        for (int j = l + 1; j < r; j++) {
            if (array[j] < pivot) {
                int temp = array[k];
                array[k] = array[j];
                array[j] = temp;
                k = k + 1;

            }
            count = count + 1;
        }
        int temp = array[l];
        array[l] = array[k - 1];
        array[k - 1] = temp;
        if (l < k - 1) {
            quicksort(l, k - 1);
        }
        if (k < r) {
            quicksort(k, r);
        }
        return k - 1;
    }

    public static int quicksort2(int l, int r) {
        int pivot = array[r - 1];
        int tempPivot = array[l];
        array[l] = array[r - 1];
        array[r - 1] = tempPivot;
        int k = l + 1;
        for (int j = l + 1; j < r; j++) {
            if (array[j] < pivot) {
                int temp = array[k];
                array[k] = array[j];
                array[j] = temp;
                k = k + 1;
            }
            count = count + 1;
        }
        int temp = array[l];
        array[l] = array[k - 1];
        array[k - 1] = temp;
        if (l < k - 1) {
            quicksort2(l, k - 1);
        }
        if (k < r) {
            quicksort2(k, r);
        }
        return k - 1;
		
    }

    public static int quicksort3(int l, int r) {
        int pivot = array[(l + r) / 2];
        int k = l + 1;
        int tempPivot = array[l];
        array[l] = array[(l + r) / 2];
        array[(l + r) / 2] = tempPivot;
        for (int j = l + 1; j < r; j++) {
            if (array[j] < pivot) {
                int temp = array[k];
                array[k] = array[j];
                array[j] = temp;
                k = k + 1;
            }
            count = count + 1;
        }
        int temp = array[l];
        array[l] = array[k - 1];
        array[k - 1] = temp;
        if (l < k - 1) {
            quicksort3(l, k - 1);
        }
        if (k < r) {
            quicksort3(k, r);
        }
        return k - 1;
    }
}
