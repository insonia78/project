#include <iostream.h>
#include <conio.h>
#include <stdlib.h>

//median of 3 quick sort.

void exchange(int list[], int p, int q)
{
	int temp = list[p];
	list[p] = list[q];
	list[q] = temp;
}

int partition(int list[], int p, int r)
{
	int x = list[r];
	int i = p-1;
	for(int j=p; j<r; j++)
	{
		if(list[j] <= x)
		{
			i++;
			exchange(list, i, j);
		}
	}
	exchange(list, i+1, r);
	return i+1;
}

int median_of_3(int list[], int p, int r)
{
	int median = (p + r) / 2;

	if(list[p] > list[r])
		exchange(list, p, r);
	if(list[p] > list[median])
		exchange(list, p, median);
	if(list[r] > list[median])
		exchange(list, r, median);

	return list[r];
}

void quicksort(int list[], int p, int r)
{
	if(p < r)
	{
		median_of_3(list, p, r);

		int q = partition(list, p, r);
		quicksort(list, p, q-1);
		quicksort(list, q+1, r);
	}
}

void main()
{
	clrscr();

	int list[] = {9, 5, 20, 3, 40, 50, 25};

	quicksort(list, 0, 6);

	cout<<"\nThe sorted array is:\n";
	for(int i=0; i< 7; i++)
		cout<<list[i]<<endl;

	getch();
}