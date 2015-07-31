
import java.util.Scanner;

/**
 * This class manages an array of numbers
 * with some extra methods that can total the numbers
 * and compute an "alternating sum."
 * @author <thomas Zangari>, modified from CS201 code
 * @version October 23, 2013
 */

public class SmartArray {
    private int[] _numList;

    public SmartArray(int n) {
        _numList = new int[n];// initialize the _numList as an array of size n
         for(int i = 0; i < _numList.length; i++){
            _numList[i]= 0;  // write a loop to put 0's in all the cells
        }
    }

    public void addValue(int value, int location){
        _numList[location] = value;// add a value at location n in _numList
    }

    public int getLength() {
       return _numList.length; // return the length of the array
        // temporary -- so code will compile
    }

    public int sum(){ // a model for the alternating sum
        int result = 0;
        for (int i = 0; i < _numList.length; i++) {
            result = result + _numList[i];
        }
        return result;
    }

    public int alternatingSum(){
        int sum = 0;
        for (int i = 0; i < _numList.length; i++){
            if ( i % 2 == 0){
                sum += _numList[i];
            }
            else{
                sum -= _numList[i];
            }

        }     // if the elements are 1, 2, 3, 4
        return sum; // return the value 1-2+3-4
         // temporary -- so code will compile
    }

    public void display(){
        for (int i = 0; i < _numList.length; i++) {
            System.out.print(_numList[i] + " ");
        }
        System.out.println();
    }
    public int linearSearch(int toFind){
		boolean found = false;
		int result=-1;
		for(int i = 0; !found && i< _numList.length;i++){
			if(_numList[i] == toFind){
				found = true;
				result=i;
			}
		}
			return result;
	}
	public char getUserChoice(){
		Scanner kbd = new Scanner(System.in);


	    String answer = kbd.nextLine();
		char answer1 = answer.charAt(0);
		return answer1;

    }
    public int getMaxValue(){

    int max = _numList[0] ;
     for (int i = 1; i < _numList.length;i++){
		 if (_numList[i] > max)
		 {
			 max = _numList[i];
		 }
	 }
	 return max;
 }
 public int getMinValue(){
	 int min = _numList[0] ;
     for (int i = 1; i < _numList.length;i++){
	 	 if (_numList[i] < min)
	 	 {
	 		 min = _numList[i];
	 	 }
	 }
	 return min;
 }

}

