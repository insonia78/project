//@author Thomas Zangari Cpp1 
//This program calculates the surface area and volume of a clipped right circular cone 

#include <iostream>
#include <cmath>
#include <iomanip>
using namespace std;

int main()
{
	// decalring the variables 
	const double PI = 3.14159;
	double radius1 = 4,
		   radius2 = 5.75,
		   height = 3.91,
		   slant_height,
		   surface_area,
		   volume;

	 //Calculating the formulas
int number = 6;
int x = 0;
x = number--;
cout << x << endl;

	slant_height = sqrt(pow(height,2.0) + pow((radius1-radius2),2.0)); 
	surface_area = PI * (pow(radius1,2.0)+pow(radius2,2.0)+(radius1+radius2) * slant_height);
	volume = (PI * height/3) * (pow(radius1,2.0) + (radius1 * radius2 ) + pow(radius2,2.0));

	//dispalying the result
	cout<<"Thomas Zangari\n\n";
	cout<<"Radius 1:"<<setw(7)<<radius1<<endl;
	cout<<"Radius 2:"<<setw(10)<<radius2<<endl;
	cout<<"Height:"<<setw(12)<<height <<endl;
	cout<<setprecision(6);
	cout<<"Slant Heigth:"<<setw(9)<<slant_height<<endl;
	cout<<"Surface Area:"<<setw(9)<<surface_area <<endl;
	cout<<"Volume:"<<setw(15)<<volume<<endl;
	return 0;


}

/*
  Thomas Zangari

Radius 1:      4
Radius 2:      5.75
Height:        3.91
Slant Heigth:  4.28376
Surface Area:  285.348
Volume:        295.063
Press any key to continue . . .
*/