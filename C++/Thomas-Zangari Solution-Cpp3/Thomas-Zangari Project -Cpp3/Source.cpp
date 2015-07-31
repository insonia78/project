/* program Cpp03
   author: Thomas Zangari
   date: 7/4/2014
   The program ask the user to input a starting balance, the charges 
   of the month, the credits amount, and the credit limit. Then it computes the ending balance 
   the finance charged the over limit charge the montley total and the minimum due. It uses 
   a switch logic to compute the answers
*/
#include <iostream>
#include <cctype>
#include <iomanip>
#include <string>
using namespace std;

int main()
{
	/*
	//variables
    double creditOverLimitCharge = 25.00;   
	double creditIsLessOfStartingBalance = 0.015;
	int accountNumber;
	double balanceBeginingOfTheMonth;
	double balanceEndOfTheMonth = 0;
	double monthlyTotalCharge = 0;
	double totalItemCharged;
	double creditAmount = 0;
	double totalCreditsToTheAccount;
	double minimamDue = 0;

	char    creditType;
	  
	//input from the user 
	cout << "Thomas Zangari\n" << endl;
	cout << "Account Number:\t\t" ;
	cin >> accountNumber;
	cout << "Beginning balance:\t";
	cin >> balanceBeginingOfTheMonth;
	cout << "Charges:\t\t";
	cin >> totalItemCharged;
	cout << "Credits:\t\t";
	cin  >> totalCreditsToTheAccount; 
	cout << "Credit Limit:\t\t";
	cin >> creditType;


	//logic of the program 
	/* the switch logic computes the different credit limit and the relative credit 
	amount that are associated for each credit limit
	
	switch(creditType)
	{
  	       case 'd':
		   case 'D':
			       {
					   
					   creditAmount = 5000;
					   balanceEndOfTheMonth =  balanceBeginingOfTheMonth + (totalItemCharged  - totalCreditsToTheAccount); 

					   
					   
					   if(balanceBeginingOfTheMonth > totalCreditsToTheAccount)
					   {
						   creditIsLessOfStartingBalance *= balanceEndOfTheMonth;
						   
					   }
					   else
					   {
						   creditIsLessOfStartingBalance = 0.00;
					   }
					   if(balanceEndOfTheMonth > totalCreditsToTheAccount )
					   {
						   monthlyTotalCharge = balanceEndOfTheMonth + creditOverLimitCharge + creditIsLessOfStartingBalance;
					   }
					   else
					   {
					        monthlyTotalCharge = balanceEndOfTheMonth + creditIsLessOfStartingBalance  ;
							creditOverLimitCharge = 0.00;

					   }
					   minimamDue = (monthlyTotalCharge <=10) ? monthlyTotalCharge : (monthlyTotalCharge * 0.05); 
					   break;

			       }
		   case 'b':
		   case 'B':
				   {
					   creditAmount = 1000;
					   

					   balanceEndOfTheMonth =  balanceBeginingOfTheMonth + (totalItemCharged  - totalCreditsToTheAccount ); 

					   
					   if(balanceBeginingOfTheMonth > totalCreditsToTheAccount )
					   {
						   creditIsLessOfStartingBalance *= balanceEndOfTheMonth;
						   
					   }
					   else
					   {
						   totalCreditsToTheAccount += balanceEndOfTheMonth;
						   creditIsLessOfStartingBalance = 0.00;
					   }
					   if(balanceEndOfTheMonth > totalCreditsToTheAccount )
					   {
						   monthlyTotalCharge = balanceEndOfTheMonth + creditOverLimitCharge + creditIsLessOfStartingBalance;
					   }
					   else
					   {
					        monthlyTotalCharge = balanceEndOfTheMonth + creditIsLessOfStartingBalance  ;
							creditOverLimitCharge = 0.00;

					   }
					   
					   minimamDue = (monthlyTotalCharge <=10) ? monthlyTotalCharge : (monthlyTotalCharge * 0.05); 
					   break;


			       }
		   case 'C':
		   case 'c':
			       {
			           creditAmount = 2000;

					   balanceEndOfTheMonth =  balanceBeginingOfTheMonth + (totalItemCharged  - totalCreditsToTheAccount ); 

					   
					   if(balanceBeginingOfTheMonth > totalCreditsToTheAccount )
					   {
						    creditIsLessOfStartingBalance *= balanceEndOfTheMonth ;
						    
					   }
					   else
					   {
						   creditIsLessOfStartingBalance = 0.00;
					   }
					   if(balanceEndOfTheMonth > totalCreditsToTheAccount )
					   {
						   monthlyTotalCharge = balanceEndOfTheMonth + creditOverLimitCharge + creditIsLessOfStartingBalance;
						   
					   }
					   else
					   {
					        monthlyTotalCharge = balanceEndOfTheMonth + creditIsLessOfStartingBalance  ;
							creditOverLimitCharge = 0.00;
					   }
					   minimamDue = (monthlyTotalCharge <=10) ? monthlyTotalCharge : (monthlyTotalCharge * 0.05); 
					   break;

			       }

			       
		   case'a':
		   case'A':
			      {
					  creditAmount = 500;

					   balanceEndOfTheMonth =  balanceBeginingOfTheMonth + (totalItemCharged - totalCreditsToTheAccount  ); 

					   					   
					   if(totalCreditsToTheAccount < balanceBeginingOfTheMonth)
					   {
						   creditIsLessOfStartingBalance *= balanceEndOfTheMonth;
                           
					   }
					   else
					   {
						   creditIsLessOfStartingBalance = 0.00;
					   }
					   if(balanceEndOfTheMonth > totalCreditsToTheAccount )
					   {
						   monthlyTotalCharge = balanceEndOfTheMonth + creditOverLimitCharge + creditIsLessOfStartingBalance;
					   }
					   else
					   {
					       monthlyTotalCharge = balanceEndOfTheMonth + creditIsLessOfStartingBalance  ;
						   creditOverLimitCharge = 0.00;

					   }

					   minimamDue = (monthlyTotalCharge <=10) ? monthlyTotalCharge : (monthlyTotalCharge * 0.05); 
					   break;

			       }


	}
	


	//output
	
	cout << fixed << setprecision(2) ;
	cout << "\nAccount Number:\t\t" << accountNumber << endl ;
	cout << "Ending balance:" << setw(18) << balanceEndOfTheMonth << endl;
	cout << "Finance charge:" << setw(18) << right << creditIsLessOfStartingBalance << endl; 
	cout << "Credit Limit:" << setw(20) << creditAmount << endl ;
	cout << "Over limit charge:" << setw(15) << creditOverLimitCharge << endl;
	cout << "Monthly total:" << setw(19) << monthlyTotalCharge << endl;
	cout << "Minimum due:" << setw(21) << minimamDue << endl ;
    return 0;
	*/
    const int SIZE = 40;
    char number[SIZE];
	char split[SIZE];
	string value;
	int i = 0 ;
	int j = 0;
	cout << "Enter the number" << endl ;
	i = value.size();
	cin.getline(number,SIZE);
	while(number[i] != '\0')
	{
		i++;
	}
	if(i % 2 == 0)
	{
		while(number[j] != '\0')
		{
			if(j % 2 == 0)
			{
				split[j] = ' ';
			}
			else
			{
				split[j] = number[j];
			}
			j++;
		}
	}
	else
	{
		split[j] = number[j];
		 j++;
		while(number[j] != '\0')
		{
			if(j % 2 == 0)
			{
				split[j] = ' ';
			}
			else
			{
				split[j] = number[j];
			}
			j++;
		}

		
	}
	i = 0;
	while(split[i] != '\0')
	{
		cout << split[i];
		i++;
	}



		
	

	return 0;


}
/*********************************
Thomas Zangari

Account Number:         300
Beginning balance:      5000
Charges:                7500
Credits:                5500
Credit Limit:           d
1500070007025
Account Number:         300
Ending balance:           7000.00
Finance charge:              0.00
Credit Limit:             5500.00
Over limit charge:          25.00
Monthly total:            7025.00
Minimum due:               351.25
Press any key to continue . . .
*************************************************
Thomas Zangari

Account Number:         400
Beginning balance:      500
Charges:                350
Credits:                500
Credit Limit:           B

Account Number:         400
Ending balance:            350.00
Finance charge:              0.00
Credit Limit:             1000.00
Over limit charge:          25.00
Monthly total:             350.00
Minimum due:                17.50
Press any key to continue . . .
****************************************
Thomas Zangari

Account Number:         500
Beginning balance:      1500.00
Charges:                0.00
Credits:                1495.00
Credit Limit:           c

Account Number:         500
Ending balance:              5.00
Finance charge:              0.07
Credit Limit:             2000.00
Over limit charge:           0.00
Monthly total:               5.08
Minimum due:                 5.08
Press any key to continue . . .
***************************************
Thomas Zangari

Account Number:         600
Beginning balance:      1500
Charges:                0.00
Credits:                1480
Credit Limit:           C

Account Number:         600
Ending balance:             20.00
Finance charge:              0.30
Credit Limit:             2000.00
Over limit charge:           0.00
Monthly total:              20.30
Minimum due:                 1.02 Tz Their is a typo on the instructions 
Press any key to continue . . .
******************************************
Thomas Zangari

Account Number:         700
Beginning balance:      500
Charges:                500
Credits:                0
Credit Limit:           A

Account Number:         700
Ending balance:           1000.00
Finance charge:             15.00
Credit Limit:              500.00
Over limit charge:          25.00
Monthly total:            1040.00
Minimum due:                52.00
Press any key to continue . . .

****************************************/
