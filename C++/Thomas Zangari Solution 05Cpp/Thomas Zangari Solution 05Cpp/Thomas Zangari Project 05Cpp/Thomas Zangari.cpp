/*program 05.cpp 
  thomas zangari
  this program computes and displayes the charges for a patient's hospital stay
  */
#include <iostream>
#include <fstream>
#include <string>
#include <iomanip>
using namespace std;

// function prototypes
char ValidateTypeOfPatient();
int ValidateNumberOfDaysInHopsital(int &);
void ValidateDailyRoomRate(double &);
void ValidateMedicalCharges(double &);
void ValidateHospitalServices(double &);
 // overloaded constructor 
double CalcCharges(int days_spent_in_the_Hospital,double dailyRate,double hospital_Medical_charges,double hospital_services);
double CalcCharges(double hospital_Medical_charges,double hospital_services);

string getAndPrintPatientNumber(int &);

int main()
{
	//variables
	
    ofstream outputFile;           // output stream	
	static string file,           // the name of the file 
		         print_patient_number; //string that holds the patient number
	char typeOfPatient = 'I' ;       // type of patient valid values I or O
	int days_spent_in_the_Hospital = 0,
		          patient_Id_number = 0,
		          number_of_patient = 0;
	
	double dailyRate = 0.0,                   // holds the daily rate 
	       hospital_Medical_charges = 0.0,
           hospital_services = 0.0,           // includes the labfees  
		   total_charges_for_sigle_patient = 0.0,
		   global_total = 0,                  // the total of the total charges for single patient variable
		   average_charges = 1;
	
	bool noPatientProcess = true;               // if no patient where processed 
	
	cout << "Thomas Zangari" << endl;
	 // openind the read file stream and initializing the file name
	cout << "\nOutput file enter: ";
	cin >> file;
	outputFile.open(file.c_str());
	
		if(outputFile.fail()) // if the file cant be read
		{
			cout << "\nCould not open output file: "+ file + "\nProgramming aborting"<< endl;

		}
		else // if the file was opend for read stream
		{
			print_patient_number = getAndPrintPatientNumber(patient_Id_number); //variable that holds the patient number
			

			while(patient_Id_number != -1) // if patient id number is not equal the flag 
		    {
		      
			  number_of_patient += 1; // counting the number of single patient processed
			  
			  typeOfPatient = ValidateTypeOfPatient(); // validating the type of patient Acepted value I or O
			  if( typeOfPatient == 'I' || typeOfPatient =='i')
			  {
				  if(ValidateNumberOfDaysInHopsital(days_spent_in_the_Hospital) == 0) // if the days spent are equal to zero 
				  {		 
					      cout << fixed << setprecision(2);
						  // getting and validating the variables
					      ValidateNumberOfDaysInHopsital(days_spent_in_the_Hospital);
				  		  ValidateMedicalCharges(hospital_Medical_charges);
				          ValidateHospitalServices(hospital_services);
						  
						  total_charges_for_sigle_patient = CalcCharges(hospital_Medical_charges,hospital_services);
						  // printing the Patient number and the total charges
						  cout << "\nPatient Number: " << patient_Id_number  << "\nThe total charges are: $ "<< total_charges_for_sigle_patient << endl; 
						  // adding the single total charges to the global charges  
						  global_total += total_charges_for_sigle_patient;
						  // writing to the file
						  outputFile << fixed << setprecision(2);
						  outputFile << "\nPatient Number:" << patient_Id_number  << "\nThe total charges are: $ "<< total_charges_for_sigle_patient << endl; 
				  }
				  else // if numbers are more then 0
				  {
					
                     cout << fixed << setprecision(2);
					 // getting and validating the variables
                     ValidateDailyRoomRate(dailyRate);
					 ValidateMedicalCharges(hospital_Medical_charges);
				     ValidateHospitalServices(hospital_services);
					 
					 total_charges_for_sigle_patient = CalcCharges(days_spent_in_the_Hospital,dailyRate,hospital_Medical_charges,hospital_services);
					 // printing the Patient number and the total charges
					 cout << "\nPatient Number: " << patient_Id_number  << "\nThe total charges are: $ "<< total_charges_for_sigle_patient << endl; 
                     // adding the single total charges to the global charges 
					 global_total += total_charges_for_sigle_patient;
					 // writing to the file
					 outputFile << fixed << setprecision(2);
					 outputFile << "\nPatient Number:" << patient_Id_number  << "\nThe total charges are: $ "<< total_charges_for_sigle_patient << endl; 
				  }

			  }
			  else
			  {
                    cout << fixed << setprecision(2);
					// getting and validating the variables 
                    ValidateMedicalCharges(hospital_Medical_charges);
				    ValidateHospitalServices(hospital_services);

			        total_charges_for_sigle_patient = CalcCharges(hospital_Medical_charges,hospital_services);
				     // printing the Patient number and the total charges
					cout << "\nPatient Number:" << patient_Id_number  << "\nThe total charges are: $ "<< total_charges_for_sigle_patient << endl;
					 // adding the single total charges to the global charges 
					global_total += total_charges_for_sigle_patient;
					// writing to file
				    outputFile << fixed << setprecision(2);
					outputFile << "\nPatient Number:" << patient_Id_number  << "\nThe total charges are: $ "<< total_charges_for_sigle_patient << endl;


			  }//end of if else
			  noPatientProcess = false; // if  patient where processed 
			  print_patient_number = getAndPrintPatientNumber(patient_Id_number);
			}// end of while
			
			if(noPatientProcess == false)
			{ 
              // writing to the file
			  outputFile << fixed << setprecision(2);
			  outputFile << "\nNumber of Patients:" << setw(14) << number_of_patient << endl;
			  outputFile << "Total charges:     $" << setw(13) << global_total << endl ;
			  average_charges = global_total/number_of_patient;
			  outputFile << "Average charges:   $" << setw(13) << average_charges << endl;
			  // printing the riepilog of the single patient processed 
			  cout << fixed << setprecision(2);
			  cout << "\nNumber of Patients:" << setw(14) << number_of_patient << endl;
			  cout << "Total charges:     $" << setw(13) << global_total << endl ;
			  average_charges = global_total/number_of_patient;
			  cout << "Average charges:   $" << setw(13) << average_charges << endl;
			  cout << "Charges were printed to " << file << endl;
			}
			else // if no patient where processed
			{
				cout << "No patient procesed." << endl ;
			    cout << "Charges were printed to " << file << "\n" << endl;
				outputFile << "No patient procesed." << endl ;
			}



		}// end of if else
			
		
		
		return 0;


}

// the function gets and prints the patient number
string getAndPrintPatientNumber(int &patient_number)
{    		
	cout << "\nPatient Number:  ";
    cin >> patient_number;
	return "Patient Number:"+ patient_number;
}//end of method

// the function validates the tipology of the patient 
char ValidateTypeOfPatient()
{
    char type_of_patient;
	bool validation = false;

	
	 cout << "Enter I (in-patient) or O (out-patient):   ";
     cin >> type_of_patient;
	  
	do
	{
		 
			
		if(type_of_patient =='I' || type_of_patient == 'i' || type_of_patient == 'O' || type_of_patient == 'o')
	   {
		   validation = true;
		  
	   }
	   else
	   { 
		   cout << "Please enter I or O:\t\t\t   ";
		   cin >> type_of_patient;
		   
		   
	   }

	   

	}while (validation == false);
	
	return type_of_patient;
	

}// end of method

// the function validates the number of days spent in the hospital reference variable
int ValidateNumberOfDaysInHopsital(int &days_spent_in_the_Hospital)
{
	bool validation = false;
	
	cout << "Number of days in the hospital:\t\t" ;
	cin >> days_spent_in_the_Hospital;
	
	do
	{
		if(days_spent_in_the_Hospital < 0) // if days are below zero
		{
			cout << "Days in the hospital must be zero or more\nPlease reenter:\t\t\t\t";
			cin >> days_spent_in_the_Hospital;
		}
		else
		{
			validation = true;
		}


	}while(validation == false);
	return days_spent_in_the_Hospital;


}// end of method

// the function validates the dailyRate reference variable
void ValidateDailyRoomRate(double &dailyRate)
{
	bool validation = false;
	
	cout << "Daily Room Rate:\t\t\t" ;
	cin >> dailyRate;
	
	do
	{
		if(dailyRate < 0.0)
		{
			cout << "Room rate must be zero or more\nPlease reenter:\t\t\t\t";
			cin >> dailyRate;
		}
		else
		{
			validation = true;
		}


	}while(validation == false);

}// end of method

// the function validates the hospital _Medical_charges reference variable
void ValidateMedicalCharges(double &hospital_Medical_charges)
{
	bool validation = false;
	
	cout << "Medical charges:\t\t\t" ;
	cin >> hospital_Medical_charges;
	
	do
	{
		if(hospital_Medical_charges < 0.0)
		{
			cout << "Medical Charges must be zero or more\nPlease reenter:\t\t\t\t";
			cin >> hospital_Medical_charges;
		}
		else
		{
			validation = true;
		}


	}while(validation == false);

}//end of method

// the function validates the hospital services  reference variable
void ValidateHospitalServices(double &hospital_services)
{
	bool validation = false;
	
	cout << "Lab fees and other services:\t\t" ;
	cin >> hospital_services;
	
	do
	{
		if(hospital_services < 0.0)
		{
			cout << "This charges must be zero or more\nPlease reenter:\t\t\t\t";
			cin >> hospital_services;
		}
		else
		{
			validation = true;
		}


	}while(validation == false);

}// end of method

//overloaded construtor for days > 0 and inpatient returns sum of it  
double CalcCharges(int days_spent_in_the_Hospital,double dailyRate,double hospital_Medical_charges,double hospital_services)
{
	
	return (days_spent_in_the_Hospital * dailyRate) + hospital_Medical_charges + hospital_services;

}
//overloaded constructor for for days == 0 or outpatients returns sum of it 
double CalcCharges(double hospital_Medical_charges,double hospital_services)
{
	return hospital_Medical_charges + hospital_services;

}//end of method


/**********************************
Thomas Zangari

Output file enter: HospitalReport1.txt

Patient Number:  1111
Enter I (in-patient) or O (out-patient):   I
Number of days in the hospital:         6
Daily Room Rate:                        257.75
Medical charges:                        123.45
Lab fees and other services:            89.90

Patient Number: 1111
The total charges are: $ 1759.85

Patient Number:  2222
Enter I (in-patient) or O (out-patient):   o
Medical charges:                        1000.00
Lab fees and other services:            895.50

Patient Number:2222
The total charges are: $ 1895.50

Patient Number:  -1

Number of Patients:             2
Total charges:     $      3655.35
Average charges:   $      1827.68
Charges were printed to HospitalReport1.txt
Press any key to continue . . .
******************************************
Thomas Zangari

Output file enter: HospitalReport2.txt

Patient Number:  3333
Enter I (in-patient) or O (out-patient):   x
Please enter I or O:                       i
Number of days in the hospital:         -9
Days in the hospital must be zero or more
Please reenter:                         9
Daily Room Rate:                        -9
Room rate must be zero or more
Please reenter:                         100.00
Medical charges:                        -9
Medical Charges must be zero or more
Please reenter:                         100.00
Lab fees and other services:            -9
This charges must be zero or more
Please reenter:                         -8
This charges must be zero or more
Please reenter:                         100.00

Patient Number: 3333
The total charges are: $ 1100.00

Patient Number:  -1

Number of Patients:             1
Total charges:     $      1100.00
Average charges:   $      1100.00
Charges were printed to HospitalReport2.txt
Press any key to continue . . .
************************************************
Thomas Zangari

Output file enter: HospitalReport1.txt

Could not open output file: HospitalReport1.txt
Programming aborting
Press any key to continue . . .
*********************************************
Thomas Zangari

Output file enter: HospitalReport3.txt

Patient Number:  -1
No patient procesed.
Charges were printed to HospitalReport3.txt

Press any key to continue . . .
*/
