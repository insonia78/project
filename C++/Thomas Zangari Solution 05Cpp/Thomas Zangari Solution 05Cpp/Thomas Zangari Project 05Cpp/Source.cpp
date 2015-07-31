//
#include <iostream>
#include <fstream>
#include <string>
#include <iomanip>
using namespace std;


char ValidateTypeOfPatient();
//void ValidateNumberOfDaysInHopsital(int &);

int main()
{
    ofstream outputFile;	
	static string file;
	       
	int days_spent_in_the_Hospital,
		            patient_number;
	double dailyRate,
	       hospital_Medication_charges,
           hospital_services;
	
	cout << "Thomas Zangari" << endl;
	 
	cout << "\nOutput file enter:\t";
	cin >> file;
	outputFile.open(file.c_str());
	
		if(outputFile.fail())
		{
			cout << "\nCould not open output file: "+file+"\nProgramming aborting"<< endl;

		}
		else
		{
			cout << "Patient Number:";
			cin >> patient_number;
			while(patient_number != -1)
		    {
			  if( ValidateTypeOfPatient() == 'I')
			  {
				//  ValidateNumberOfDaysInHopsital(days_spent_in_the_Hospital);


			}// end of while

		}// end of if else
			return 0;


}
char ValidateTypeOfPatient();
{
    char type_of_patient;
	bool validation = false;

	
	  cout <<"Enter I (in-patient) or O (out-patient):";
	  cin >> type_of_patient;
	do
	{
	
	   if(toupper(type_of_patient) != 'I' || toupper(type_of_patient) != 'O')
	   {
		   cout << "Please enter I or O:\t";
		   cin >> type_of_patient;
	   }
	   else
	   {
		   validation = true;
	   }

	   

	}while (validation == false);
	
	return type_of_patient;
	

}// end of method
