#include <iostream>
#include <fstream>
#include <string>
#include <iomanip>
#include <ctime>
#include <stdio.h>
#include <time.h>

using namespace std;
#define SIZE 26
int main()
{
	ifstream inputFile;
	ofstream outputFile;
	inputFile.open("Email_sent.txt");//read
	
	time_t now = time(0);
    
	string email;
	string value;
	bool validate = false;

	

	cout << "Enter the email adress" << endl;
	cin >> email;

	 while(inputFile >> value)
	 {
		 cout << value;
		 if(value == email)
		 {
			 string value2 ;
			 cout << "the email exist" << endl;
			 if(inputFile >> value2)
			 {
			  cout << "it was ritiing on " << value <<"" << value2 << endl;
			 }
			 validate = true;
			 break;
		 }
	 }
	 inputFile.close();

	 
	 if(validate == false)
	 {   outputFile.open("Email_sent.txt");//write
		 outputFile << email << " "  << now << endl;
         outputFile.close();

	 }
	 


}
