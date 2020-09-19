#include <iostream>
#include <string>
using namespace std;

int main()
{
	const int SIZE = 40 ;
	char number[SIZE] ;
	char split[SIZE];

    int i = 0, 
	    j = 0;

	cout << "ENTER THE NUMBER" << endl;
	cin.getline(number,SIZE);

	while(number[i] != '\0')
	{
		i++;
	}
	
	if(i % 2 == 0)
	{
		i = 0 ;
		while(number[i] != '\0')
		{
			if(i % 2 == 0 && i != 0 )
			{
				
				split[j] =' ';
				j++;
				
				split[j] = number[i];
				j++;
				
			}
			else
			{
		        split[j] = number[i];
				j++;
			}
			i++;
	
		}
		split[j] = '\0';
	}
	else
	{
        i = 0; 		
		split[j] = number[i];
		j++;
		i++;
		while(number[i] != '\0')
		{
			if(i % 2 == 0)
			{
				split[j] = number[i];
				j++; 
			}
			else
			{
				split[j] = ' ';
				j++;
				split[j] = number[i];
				j++;
			}
			i++;
		}
		split[j] = '\0';
	}
	
	j = 0;
	
	while(split[j] != '\0')
	{
		cout << split[j] ;
		j++;
	}

	
	return 0;
}