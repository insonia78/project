/*program 05cpp
 Thomas Zangari
 The program reads sales data from a file,calculates the amount to pay with the rispective percentage
 and writes the resoult to a file
 */

#include <iostream>
#include <fstream>
#include <string>
#include <iomanip>
using namespace std;

//Function prototype
char validateContinueReadAnotherFile();
void readFile();
double searchTopSales(double sales_array[],int index);
void writeOnFile(double sales_array[],int index ,double average,double topSalesValue,bool noDataProcessed,string nameFileWrite);
double getBonus_es(double sales_array[],double topSalesValue, double average, int i); 
bool  scanForInvalidData(double sales_array[],string fileName);
string enterTheFileNameWereToWrite();

int main()
{
	char to_continue_reading_file; // variable that holds the answer if the user whants to read another file
	
	do
	{
		// call to the read file
		readFile();

		cout << "\nDo you want to process another file" << endl ;
		// getting and validating the user entry
		to_continue_reading_file = validateContinueReadAnotherFile();

	}while(to_continue_reading_file == 'Y' || to_continue_reading_file == 'y');


	return 0;

}
// Function that reads and stores the value of the file in a array
void readFile()
{

	const int SIZE = 10; // holds the size of the array
	
	ifstream inputFile;   // read stream 
	
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
		// getting user response
		confirm_reading_file = validateContinueReadAnotherFile();

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
	
	// getting the files name where to write on
	fileNameWrite = enterTheFileNameWereToWrite();
	//cheking if sales are < 0
	processInvalidData = scanForInvalidData( sales_array,fileNameRead);

	//reading the files data
	while( inputFile >> sales && index <= SIZE)
	{


		if(sales < 0 && index < SIZE)// if the sales is < 0 
		{
			if(processInvalidData == true) // if the user wants to calculate the bad data 
			{
				sales_array[index] = sales;
				
				totalSales += sales ; // adding the sales to totalSales

			}
			else // if the user does not whant to add the bad data
			{
				sales_array[index] = -1;  // storing -1 as a flag
			}


		}
		else if( sales >= 0 && index < SIZE) // if the data is in the righ segment 
		{
			sales_array[index] = sales;
			totalSales += sales ;

		}

		index++;
		// if the data was proccesed 
		noDataProcessedOnFile = false;
	}// end while
	if(index > SIZE) // if the index > the array Size 
	{
		cout << "You exited the capicity of the Array" << endl;
		cout << "Only the first 10 data will be processed" << endl;
		// bringing the index back to the array range
		index = index - 1;
	}
	if(noDataProcessedOnFile == true) // if no data was processed
	{

		cout << "The file has no Data!" << endl;
		//writing on the file 
		writeOnFile(sales_array,index,averageSales,topsalesvalue,noDataProcessedOnFile,fileNameWrite);
		cout << "Do you want to process another file" << endl ;
		// getting the answer from the user 
		confirm_reading_file = validateContinueReadAnotherFile();
		if(confirm_reading_file == 'Y' || confirm_reading_file == 'y') 
		{
			readFile();
		}
		else //if answer is no 
		{
			exit(0);
		}

	}
	else //if data was processed 
	{
		//calculating the average
		averageSales = totalSales / index ; 
		// calculating the average
		topsalesvalue = searchTopSales(sales_array,index); 
		//calling the write on file
		writeOnFile(sales_array,index,averageSales,topsalesvalue,noDataProcessedOnFile,fileNameWrite);
	}

}
//Gets the file name where to righ returns the filename 
string enterTheFileNameWereToWrite()
{
	string fileName ;
	cout << "\nOutput file enter: ";
	cin >> fileName;
	return fileName;
}
//Searches the highest sale/s and returns it
double searchTopSales(double sales_array[],int index)
{
	double topSales = 0; // the top sale
	double temp = sales_array[0]; // temporary variable that stores one of the arrays values

	// searching the top value
	for(int i = 1; i < index;i++)
	{

		if( temp < sales_array[i])
		{

			temp = sales_array[i];

		}


	}//end of for
	topSales = temp; 
	return topSales;
}
// Writes on the file
void writeOnFile(double sales_array[], int index,double average,double topSalesValue,bool noDataProcessedOnFile,string fileNameWrite)
{

	ofstream outputFile; // stream for write

	double percentage = 0 ;  // holds the percentage that is going to be applied 
	double total_payout = 0; // total pay out for the single sales
	double global_payout = 0; // global pay out of all the sales 

	outputFile.open(fileNameWrite.c_str()); // opening the stream
	
	if(noDataProcessedOnFile == true)// if no data  was processed
	{
		outputFile << "Thomas Zangari\n\n";
		outputFile << "No sales Entered" ;
	}
	else// if the data was prossed  
	{
		if(outputFile.fail()) // if the file cant be read
		{
			cout << "\nCould not open output file: "+ fileNameWrite + "\nProgramming aborting" << endl;

		}
		else // if data has to be prossed 
		{
			outputFile << "Thomas Zangari\n\n" ;
			// stepping trew the array
			for (int i = 0 ; i < index; i++)
			{
				if(sales_array[i]  > 10000)
				{
					percentage = 0.06;
					total_payout = (sales_array[i] * percentage) + getBonus_es(sales_array,topSalesValue, average,i) ;


				}
				else if(sales_array[i]  <= 10000 && sales_array[i] > 5000)
				{
					percentage = 0.0525;
					total_payout = (sales_array[i] * percentage) + getBonus_es(sales_array,topSalesValue, average,i) ;

				}
				else if(sales_array[i]  <= 5000 && sales_array[i] > 1000)
				{
					percentage = 0.045;
					total_payout = (sales_array[i] * percentage) + getBonus_es(sales_array,topSalesValue, average,i) ;

				}
				else if( sales_array[i] <= 1000 && sales_array[i] >= 0)
				{
					percentage = 0.03;
					total_payout = (sales_array[i] * percentage) + getBonus_es(sales_array,topSalesValue, average,i) ;
				}
				else
				{
					percentage = 0 ;
					total_payout = 0 ;
				}
				// if they are wrong data that dont have to be processed
				if(sales_array[i] == -1)
				{
					outputFile << fixed << setprecision(2);
					outputFile << "Sales rep:" << (i + 1) << endl ; 
					outputFile << "INVALID DATA!\n\n" << endl;

				}
				else // writing the good data to be processed
				{

					outputFile << fixed << setprecision(2);
					outputFile << "Sales rep:" << (i + 1) << endl ; 
					outputFile << "Gross sales:" << setw(20) << sales_array[i] << endl;
					outputFile << "Commision rate (%):" << setw(13) << percentage * 100 << endl;
					outputFile << "Pay:" <<	setw(28) << total_payout << ("\n\n") << endl;
					// summing the global total
					global_payout += total_payout;
				}


			}// end of for

			// summury of operations
			outputFile << " --------------------------- " << endl;
			outputFile << "Average Sales:" << setw(19) << average << endl;
			outputFile << "Total payed:" << setw(21) << global_payout << endl;
			cout << "\nThe data has been writen in the file" << endl;
			// closing the file
			outputFile.close();

		}//end of if else
	}// end if else



}
//getting the bonuse to be add to the amount payed out returns the sum of the bonuses
double getBonus_es(double sales_array[],double topSalesValue, double average,int i)
{
	double sum_of_bonuses = 0; // holding the bonunes amount
	// if the amount  is > average 
	if(sales_array[i] > average)
	{
		sum_of_bonuses += 50;
	}
	// if the amount == to the top value
	if(sales_array[i] == topSalesValue )
	{
		sum_of_bonuses += 75 ;
	}

	return sum_of_bonuses;
}
// validate the user input for yes or no returns the answer
char validateContinueReadAnotherFile()
{
	char answer; //variable that holds the users anser 
	bool validation = false; //validation of the do while loop


	cout << "Enter Y (or y) or N (or n):   ";
	cin >> answer;

	do
	{

		//cheking fo the user answer
		if(answer=='Y' || answer == 'y' || answer == 'N' || answer == 'n')
		{
			validation = true;

		}
		else
		{ 
			cout << "Please enter Y or y or N or n:\t\t\t   ";
			cin >> answer;


		}



	}while (validation == false);

	return answer;


}// end of method
// Scannes for data that is < 0 return the bool of continuing reading data  
bool scanForInvalidData(double sales_array[],string fileName)
{
	double sales = 0; // variable for the sales 
	// opening the read stream
	ifstream inputFile; 
	inputFile.open(fileName.c_str());
	
	int index = 1 ; // variable that holds the positio of the sales in the file
	
	bool invalidData = false,     // holds if invalid data is true or false
		 continue_reading_data = false;  // if the wrong datamust be read or not 
	char continue_process;              // holds the users input 

	while(inputFile >> sales) // reading the data
	{

		if(sales < 0) // if sales are below )
		{
			
			cout << "\nWARNING!"<<endl;
			cout << "You have invalid data " << sales << " in position:" << index <<  endl;


			invalidData = true;
		}
		index++;
	}

	if(invalidData == true) // if the their is invalid data
	{
		
		cout << "\nDo you still want to process with the wrong data?" << endl ;
		cout << "(If Yes! the wrong data will be processed togheter with the good data)" << endl; 
		
		continue_process =validateContinueReadAnotherFile();
		
		if(continue_process == 'N' || continue_process == 'n') // if user does not want to process the bad file
		{
			cout << "\nDo you want to read again the file? "<< endl;
			cout << "(If No! the data will be processed with out the wrong data)" << endl;
			continue_process = validateContinueReadAnotherFile();

			if(continue_process == 'Y' || continue_process == 'y') // if user want to read another file
			{
				readFile();
			}

		}
		else // if the user want the bad data to be processed 
		{
			continue_reading_data = true;

		}//end if else
	}// end if
	return continue_reading_data;
}