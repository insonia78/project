// Program:  Reverse.cpp
// Uses pointers to manipulate a 1-D array
#include <iostream>
#include <cstdlib>
#include <iomanip>

using namespace std;

// Function prototypes
void printArray(int* dinamicArray,int arraySize);
void fillArray(int* dinamicArray, int arraySize);
void reverse(int *dinamicArray,int arraySize);

int main()
{
	int arraySize;			// size of the dynamically allocated array

	int *dinamicArray;// declare as needed for a dynamically allocated array of ints named data

	// Code to seed random number generator. Leave it commented out and you will get the same array
	// each time you run. Good idea when writing and debugging the code. If you want to see the effect
	// of seeding the random number generator, uncomment this line. When running to copy and submit 
	// output, make sure this line is commented out.
	//srand( time( 0 ) );

	// edit to display your own name
	cout << "Thomas Zangari" << endl << endl;

	// prompt user for the array size
	cout << "Array size: ";
	cin >> arraySize;

	// add code to validate array size, so it is greater than one
	while(arraySize <=1)
	{
		cout << "Array size must be more then 1:";
		cin >> arraySize;
	}


	// add code to dynamically allocate the array. Don't forget to release the memory
	// before the program ends.
	dinamicArray = new int[arraySize];
	if  (dinamicArray == NULL)
	{
		cout << "getting out of memory" <<endl;
		exit(1);
	}

	// call function to fill the array
	fillArray(dinamicArray,arraySize);

	// call function to print the array
	cout << "\nOriginal array:\n\n";
	printArray(dinamicArray,arraySize);

	// call function to reverse the array
	reverse(dinamicArray,arraySize);

	// call function to print the array
	cout << "\nReversed array:\n\n";
	printArray(dinamicArray,arraySize);
	cout << endl;
	delete [] dinamicArray;
	dinamicArray = 0 ;

	return 0;
}

// Function to fill the array with random numbers in the range 1-100 (inclusive).
// This function must use POINTER NOTATION (no subscripting) to work with the array.
// Reminder: neither of these notations is acceptable here: x[n] or *(x + n)
void fillArray(int *dinamicArray, int arraySize)
{
	for(int i = 0; i < arraySize; i++)
	{
		*dinamicArray = 1+ rand() %100;
		dinamicArray++;

	}
	// Complete this function
}

// Function to print the array, 5 values per line and right-aligned.
// This function must use POINTER NOTATION (no subscripting) to work with the array.
// Reminder: neither of these notations is acceptable here: x[n] or *(x + n)
void printArray(int *dinamicArray,int arraySize)
{
	// Complete this function
	for(int i = 0; i < arraySize; i++)
	{
		cout << setw(5) << *dinamicArray << setw(8) ;
		if((i+1) % 5 == 0){cout <<"\n";}
		*dinamicArray++;
	}
}

// Function to reverse the array. DO NOT DECLARE ANOTHER ARRAY. Reverse the array "in place"
// by exchanging the first and last element, then the second and next-to-last element, etc.
// This function must use POINTER NOTATION (no subscripting) to work with the array.
// Reminder: neither of these notations is acceptable here: x[n] or *(x + n)
void reverse(int *dinamicArray,int arraySize)
{
	// Complete this function
	int firstValue = 0 ;
	int secondValue = 0;
	int *reverseArray = dinamicArray;
	
	
	for(int i = 0; i < arraySize; i++)
	{
		dinamicArray++;
	   
	}
	cout<< endl;
	for(int i = 0; i < arraySize; i++)
	{
		dinamicArray--;
		firstValue = *dinamicArray;
		secondValue = *reverseArray;
		if(reverseArray < dinamicArray)
		{
		   *reverseArray = firstValue;
	       *dinamicArray = secondValue;
		}
			
		reverseArray++;
	}
	
	cout << endl;
	if(reverseArray == NULL)
	{
		cout << "out of memory" << endl;
		exit(1);
	}
	
	cout << endl;
}
/***********************************************
Thomas Zangari

Array size: -1
Array size must be more then 1:0
Array size must be more then 1:1
Array size must be more then 1:23

Thomas Zangari

Original array:

   42   68   35    1   70
   25   79   59   63   65
    6   46   82   28   62
   92   96   43   28   37
   92    5    3



Reversed array:

    3    5   92   37   28
   43   96   92   62   28
   82   46    6   65   63
   59   79   25   70    1
   35   68   42
Press any key to continue . . .
*/

