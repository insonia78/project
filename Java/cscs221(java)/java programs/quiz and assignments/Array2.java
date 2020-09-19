// File: Array2.java
import java.util.Scanner;

public class Array2
{
    public static void main( String args[] )
    {
        Scanner kb = new Scanner( System.in );
        // Declare and create 2 arrays of 5 ints each.
        // Call the arrays a and b.
        int a[] = new int[5];
        int b[] = new int[5];




        // Declare and create 2 arrays of 10 ints each.
        // Call the arrays c and d.
         int c[] = new int[10];
         int d[] =new int[10];




        // Call the fillArray method to fill array a with
        // values from the user
        System.out.println( "Enter values for first array" );
         fillArray(a);


        // Call the fillArray method to fill array c with
        // values from the user
        System.out.println( "\nEnter values for second array" );
         fillArray(c);


        // Call the copyArray method to copy array a to b
          copyArray(a,b);


        // Call the copyArray method to copy array c to d
         copyArray(c,d);


        // Call the printArray method to print array b
        System.out.println( "This is a copy of the first array" );
        printArray(b);


        // Call the printArray method to print array d
        System.out.println( "\nThis is a copy of the second array" );
        printArray( d );

        System.exit(0);


    }


    // Write method fillArray to read values for an array
    // of ints from the user, using the system console.
     public static void fillArray(int values[])
     {
		 Scanner kb = new Scanner( System.in );
		 for (int i = 0; i < values.length; i++)
		  {
			  System.out.println("Enter the values");
			  values[i] = kb.nextInt();
		  }
	 }
    // write method copyArray to copy values from one array
    // of ints to another. If they aren't the same length, display
    // an error message on the system console.
     public static void copyArray(int values[],int values2[])
     {
		 if (values.length == values2.length)
		 {
			 for(int i = 0;i < values.length;i++)
			 {
				 values2[i] = values[i];
			 }
		 }
		 else
		 {
			 System.out.println("error they are not the same lenght");
		 }
	 }


    // write method printArray to print an array of
    // ints on the system console, 3 numbers on a line

    public static void printArray(int values[])
    {
		for( int i = 0; i < values.length;i++)
         {
			 System.out.print( values[i] + " " );
		     if ( ( i + 1 ) % 3  == 0 )
                System.out.println();
	     }
			System.out.println();

	}
}













