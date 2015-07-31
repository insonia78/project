/*program Cpp04
  author:Thomas Zangari
  date: 7/15/2014
  calculates a class average, displays the valid and invalid scores count, and draws histograms showing the grade distribution
  */
#include <iostream>
#include <fstream>
#include <string>
#include <iomanip>
using namespace std;

int main()
{
	const string INVALID = "INVALID";	//constant that holds the Invalid input for the invalid scores
	ifstream inputFile;     // variable that holds the input stream for accesing the file  
	string fileName,        //variables that gets the file name from the user   
		   emptyvalue,      // variable that is used if the their is no data in the file 
	// histogram values for the grades        
		   histogram_A = "", 
		   histogram_B = "",
		   histogram_C = "",
	       histogram_D = "",
		   histogram_F = "";
	
	int countOfValidScores = 0,      // variables that holds the count of the valid scores that is going to be used for the average and is going displays it 
		countOfInvalidScores = 0,    // variables that holds the count of the invlid variables  
		sum = 0,                   // variable that holds the sum of all the valid scores
	    scores = 0;                // variables that olds the scores that are going to be display in the for loop
	    
	double average;               // holds the average 
	bool validateEmptyFile = true; // used to validate if the file has no data 

	cout << "Thomas Zangari \n"<<endl;
	cout << "Enter the file name:";
	// getting the file name from the user
	cin >> fileName;
	inputFile.open(fileName.c_str());
	
	
	   while(inputFile == false)
	   {
		   cout << "\nError opening file " + fileName << endl;
		   
		   cout << "\nReenter the file name:";
	       cin >> fileName;
		   inputFile.open(fileName.c_str());
	   }
	  
	   
		// for loop for calculating the histogram, the sum, and the invalid scores    
	   for(int positionIndex = 1 ;inputFile >> scores; positionIndex++ )
	   {
		     if(scores >=90 && scores <=100)
		     {			   
			   cout << positionIndex << ".\t" << scores << endl;
			   histogram_A +="*";
			   countOfValidScores++;
			   sum += scores;
		     }
		     else if(scores >=80 && scores <90)
		     {			    
			    cout << positionIndex << ".\t" << scores << endl;
			    histogram_B +="*";
			    countOfValidScores++;
			    sum += scores;
		     }
		     else if(scores >=70 && scores < 80)
		     {			    
			     cout << positionIndex << ".\t" << scores << endl;
			     histogram_C +="*";
			     countOfValidScores++;
			     sum += scores;
		      }
		      else if(scores >=60 && scores <70)
		      {			   
			       cout << positionIndex << ".\t" << scores << endl;
			       histogram_D +="*";
			       countOfValidScores++;
			       sum += scores;
		      }
		      else if(scores >= 0 && scores < 60)
		      {
			      cout << positionIndex << ".\t" << scores << endl;
			      histogram_F +="*";
				  countOfValidScores++;
			      sum += scores;
		      }
		      else
		      {			    
			        cout << positionIndex << ".\t" << scores << "\t" + INVALID << endl;
                    countOfInvalidScores++;
			  
		      }//end of if-else if
				
	  validateEmptyFile = false;
	  }//end of for loop

	   
	   if(validateEmptyFile == true) // if the file is empty
	   {
		   cout << "\nEmpty input file" << endl;
		   
	   }
	   else// if the file has data 
	   {
	       average =(double)sum/countOfValidScores;
	       cout << right;
	       cout << "\nNumber of VALID grades:" << setw(10) << countOfValidScores << endl;
	       cout << "Number of INVALID grades:" << setw(8) << countOfInvalidScores << endl;
	       cout << fixed << setprecision(1);
	       cout << "\nClass average is:" << setw(5) << average << endl;
	       
		   //displays the grade histogram 
		   cout << "\nGrade distribution:"<< endl;
		   cout << "A:\t" << histogram_A << endl; 
	       cout << "B:\t" << histogram_B << endl;
	       cout << "C:\t" << histogram_C << endl;
           cout << "D:\t" << histogram_D << endl;
	       cout << "F:\t" << histogram_F << endl;
	 
	  }// end of if else
       
	   // closing the file
	   inputFile.close();


	return 0;
}// end of main

/**************************
Thomas Zangari

Enter the file name:hello.txt

Error opening file hello.txt

Reenter the file name:
***************************
Thomas Zangari

Enter the file name:hello.txt

Error opening file hello.txt

Reenter the file name: empty.txt

Empty input file
Press any key to continue . . .
*********************************
Thomas Zangari

Enter the file name:GradeData.txt
1.      -1      INVALID
2.      95
3.      87
4.      75
5.      68
6.      56
7.      99
8.      78
9.      73
10.     84
11.     101     INVALID
12.     58
13.     100
14.     72
15.     88
16.     91
17.     65
18.     89
19.     90
20.     50
21.     -2      INVALID
22.     83
23.     75
24.     82
25.     74
26.     70
27.     76
28.     87
29.     120     INVALID

Number of VALID grades:        25
Number of INVALID grades:       4

Class average is: 78.6

Grade distribution:
A:      *****
B:      *******
C:      ********
D:      **
F:      ***
Press any key to continue . . .
*/
