// File: Array1.java
// WHAT IS THE OUTPUT OF THIS PROGRAM?

public class Array1
{
    public static void main( String args[] )
    {
        int a[] = { 1, 2, 3, 4, 5 };
        int b[] = { 6, 7, 8, 9, 10 };

        output( a, b[3] );
        change( a, b[3] );
        output( a, b[3] );
    }

    public static void change( int values[], int num )
    {
        values[2] = 10;
        values[4] = 20;
        num = -1;
        output( values, num );
    }

    public static void output( int array[], int val )
    {
        for ( int i = 0; i < array.length; i++ )
            System.out.println( array[i] );

        System.out.println( val );
        System.out.println();
    }
}

