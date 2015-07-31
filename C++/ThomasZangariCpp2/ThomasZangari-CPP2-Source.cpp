/* Program Cpp02
 @author Thomas Zangari
 @date 7/3/2014
 This program calculates the monthly amount of a loan, the amount payed back, and the total interest payed 
 */
#include<iostream>
#include <cmath>
#include <iomanip>
using namespace std;

int main()
{
	//variables
	const int YEAR = 12;
	double mInterRate,
		   rate,
		   loan,
		   formula;
	
	int numberOfPayments;
	int n =1;
	while(n<=5)
		cout<<n<<endl;
	n++;
	cout << "Thomas Zangari \n\n";
	//input from the user
	cout << "Enter the loan amount:\t";
	cin >> loan;
	cout << "Enter the annual interest rate:\t";
	cin >> mInterRate;
	cout << "Enter the number of payments:";
	cin >> numberOfPayments;
	
	//formulas
	rate = mInterRate/YEAR;
	formula = (rate/100 /(1-(pow((1 + rate/100),-numberOfPayments)))) * loan ;  
	cout << "\n";
	
	//output
	cout << "Thomas Zangari\n\n";
	cout << setprecision(2) << fixed << right;
	cout << "Loan Amount:" << setw(11) << "$" << setw(15) << loan << endl;
	cout << "Monthly Interest Rate:" << setw(16) << rate << "%" << endl;
	cout << "Number of Payments:" << setw(19) << numberOfPayments << endl;
	cout << "Monthly Payments:" << setw(6) << "$" << setw(15) << formula << endl;
	cout << "Amount Paid Back:" << setw(6) << "$" << setw(15) << (formula*numberOfPayments) << endl;
	cout << "Interest Paid:" << setw(9) << "$" << setw(15) << ((formula*numberOfPayments)-loan) << endl;
	
	return 0;

}

/*
  Thomas Zangari

Enter the loan amount:  10000.00
Enter the annual interest rate: 10.5
Enter the number of payments:48

Loan Amount:          $       10000.00
Monthly Interest Rate:            0.88%
Number of Payments:                 48
Monthly Payments:     $         256.03
Amount Paid Back:     $       12289.62
Interest Paid:        $        2289.62
Press any key to continue . . .
*/
