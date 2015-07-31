#include <iostream>
#include <fstream>
#include <string>
#include <iomanip>

using namespace std;



void readFile(ifstream &inputFile);
char* shift( char String[], int &size);
bool checkString(char *newString);

int main()
{
	const int SIZE = 100;
	int size = 100;
	char to_continue_reading_file; // variable that holds the answer if the user whants to read another file
	ifstream inputFile;
	char String[SIZE];
	char *newString = String;
	bool validate = false;
	
	cout << "Do you want to read from  afile" << endl ;
	cin >> to_continue_reading_file;
	if(to_continue_reading_file == 'Y' || to_continue_reading_file == 'y')
	{
		// call to the read file
		readFile(inputFile);
		if((inputFile.getline(newString,size)) == NULL)
	    {
			newString = shift(newString,size);
			inputFile.getline(newString,size);
		}
		else
		{
			inputFile.getline(newString,size);
		}
		validate == true;
	}
	else
	{
		cout << "Enter the String" << endl;
		if((cin.getline(newString,size)) == NULL)
	    {
			newString = shift(newString,size);
			cin.getline(newString,size);
		}
		else
		{
			cin.getline(newString,size);
		}
		validate == true;
	}
	if(validate == true)
	{
		bool corect ;
		cout << "Is the String valid" << endl;
		corect = checkString(newString);
		if(corect == true)
		{
			cout << "true" ;
		}
		else
		{
			cout << "false";
		}
	}
	return 0;

}
bool checkString(char *newString)
{
	int i = 0;
	int spaces = 0;
	while(newString[i] != '\0')
	{
        if(newString[i] == ' ')
		{
			spaces++;
		}
		i++;
	}
	return true;
}
// Function that reads and stores the value of the file in a array
void readFile(ifstream &inputFile)
{

	const int SIZE = 10; // holds the size of the array
	
	 
	
	string fileNameRead,  // variables that holds the file to read 
		 fileNameWrite;   // variable that holds the variable to write
	
	double sales = 0,     // holds the data read from the file
		   totalSales = 0,     // holds the total of the sales
		   averageSales = 1,   // holds the average of the total sales calculated 
		   topsalesvalue = 0,  // holds the highest sales value 
		   sales_array[SIZE] = {0}; //initializing the the array to zero

	int index = 0;                 //holds the indexes of the data read
	
	char confirm_reading_file;     // holds if the user wants to read another file     
	
	bool processInvalidData = false, // if the user chooses to add the invalid data
		noDataProcessedOnFile = true; // if the their where no data in the file


	cout << "Thomas Zangari \n" << endl;
	cout << "Enter the file name to be read:";
	//getting the file name from the user
	cin >> fileNameRead;
	inputFile.open(fileNameRead.c_str());

	while(!inputFile)// if the stream was not opend to be read  
	{
		cout << "The file does not exist do you want to enter another file?\n";
		
		cin >> confirm_reading_file;
		// getting user response
		

		if(confirm_reading_file == 'N' || confirm_reading_file == 'n')
		{
			exit(0); // exeting the program
		}
		else // if the user wants to read another file
		{
			cout << "Enter the file name:";
			// getting the file name from the user
			cin >> fileNameRead;
			inputFile.open(fileNameRead.c_str());
		}

	}// end while
}	
char* shift( char values[], int &size)
{
	 size *=100;
	char* newArray = new char[size];
	
	
	if( size < 1)
	{
		cout << " sorry the array size must be more then 0" << endl;
		exit(0);
	}
	else
	{
		*newArray = 0;
		
		for(int i = 0; i < size; i++)
		{
			newArray++;
			*newArray = *values ;
			values++;
		 
		}
		for(int i = 0; i < size; i++)
		{
			
		   	newArray--;
		}
		  
	}
	return newArray;
}


