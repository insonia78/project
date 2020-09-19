// thomas Zangari

import java.util.Scanner;
import java.text.*;

/**
 Class to demonstrate the Student class
*/
public class StudentClient
{
	/**
	main class
	*/
    public static void main( String[] args )
    {
        System.out.println( "Thomas Zangari" );

        Scanner kb = new Scanner( System.in );

        System.out.print( "How many students? " );
        int howMany = kb.nextInt();

        // Create the Student array; call it roster

         Student[] roster = new Student[howMany];

        // Leave these lines alone. Write methods below.
        // Call a method to fill the array of Students
        fillArray( roster );

        // Call a method to display the roster (name & grade)
        System.out.println("\nStudents:");
        display( roster );

        // Call a method to show the name(s) of the
        // Student(s) with the highest grade
        System.out.println("\nStudent(s) with highest grade");
        showMax( roster );

        // Call a method to find the average grade.
        showAvg( roster );

        // Call a method to determine and show the
        // letter grade for each student.
        System.out.println("Letters Grade:");
        showLetterGrade( roster );

        // Call a method to sort an array of Students
        // by name. Then redisplay it.
        System.out.println("\nAlphabetical listing:");
        sortName( roster );
        display( roster );

        // Call a method to sort an array of Students
        // by grade, high to low. Then redisplay it.
        System.out.println("\nStudents by grade, high to low");
        sortGrade( roster );
        display( roster );

    }

    /**
    The fillArray method fill's the array and validates the client input of the grade.
    @param Student[] std the array.
    */
    public static void fillArray( Student[] std )
    {
		Scanner kb = new Scanner( System.in );
		String name;
		int grade;

		for ( int i = 0;i < std.length ; i++)
		{
			System.out.print("\nName: ");
			name = kb.nextLine();


			System.out.print("Grade (0-100): ");
			grade = kb.nextInt();
            // loop for invalid input from the client.
			while ( grade <0 || grade >100)
			{
				if (grade < 0 || grade > 100)
				{
					System.out.print("Re-enter the grade: ");
					grade = kb.nextInt();

				}
			}

            std[i] = new Student(name,grade);
            name = kb.nextLine();

		}


    }
    /**
    The display method diplays the clients input from the array
    @param Student[] std Array of valius
    */
    public static void display( Student[] std )
    {

      for ( int i = 0;i < std.length ; i++)
      {

		  System.out.println(std[i].toString());
	  }

    }
    /**
    The showMax method displays the max grade of the array
    @param Student[] std array.
    */
    public static void showMax( Student[] std )
    {
		 Student highest = std[0];
		 //loop for finding the high value
		 for (int i = 1; i < std.length; i++)
		 {
			 if (std[i].getGrade() > highest.getGrade())
			 {
				 highest = std[i];

			 }
		 }
		 //loop checking if there is more than one max high grade.
		 for (int i = 0; i < std.length; i++)
		 {
			 if( std[i].getGrade()== highest.getGrade())
			 {
				System.out.println ( std[i].toString());
			 }
		 }



    }
    /**
    The showAvg method displays the average of all the grades
    @param Student[] std the array.
    */
    public static void showAvg( Student[] std )
    {
		int total = 0;
		int average;
		for (int i = 0; i < std.length; i++)
		{
            total =total+ std[i].getGrade();
		}
		average = total/std.length;
		System.out.println("\nClass average is:"+average+"\n");

    }
    /**
    The showLetterGrade displays the letter format of the grade.
    @param Student[] std the array.
    */
    public static void showLetterGrade( Student[] std )
    {
       char letterGrade;
       for (int i = 0; i < std.length; i++)
       {
		   if (std[i].getGrade() >= 90)
		   {
			   letterGrade = 'A';
			   System.out.println(std[i].getName()+":" + letterGrade);

		   }
		   else if(std[i].getGrade() >= 80)
		   {
			   letterGrade = 'B';
			   System.out.println(std[i].getName()+":" + letterGrade);

		   }
		   else if(std[i].getGrade() >= 70)
		   {
			   letterGrade = 'C';
			   System.out.println(std[i].getName()+":" + letterGrade);

		   }
		   else if(std[i].getGrade() >= 60)
		   {
			   letterGrade = 'D';
			   System.out.println(std[i].getName()+":" + letterGrade);

		   }
		   else
		   {
			   letterGrade = 'F';
			   System.out.println(std[i].getName()+":" + letterGrade);
		   }

	   }


    }
    /**
    The sortName method uses a bubble sort method to display the name in Alfabetical order.
    @param Student[] std the array
    */
    public static void sortName( Student[] std )
    {
		 boolean swap;
		 Student temp;
		 do
		 {
			 swap = false;
			 for (int i = 0; i < (std.length -1); i++)
			 {

				 if (std[i].getName().compareTo(std[i + 1].getName())>0)
				 {
					 temp =std[i];
					 std[i]=std[i +1];
					 std[i + 1] = temp;
					 swap = true;
				 }
			 }

		 }while(swap);



    }
    /**
    The sortGrade method uses a bubble sort method to display the grade form high to low
    @param Student[] std the array.
    */
    public static void sortGrade( Student[] std )
    {
		boolean swap;
		Student temp;
		int last = std.length - 1;
		do
		{
			swap = false;
			for (int i = 0; i<(std.length - 1); i++)
			{
				if (std[i].getGrade() < std[i+1].getGrade())
				{
					 temp =std[i];
					 std[i]=std[i +1];
					 std[i + 1] = temp;
					 swap = true;
				 }
			 }
		     last--;
		 }while(swap);

	}

}
/**
YOUR NAME
How many students? 5

Name: Hogg, Ima
Grade (0-100): 76

Name: Too, Yew R
Grade (0-100): 98

Name: Frisbee, Iona
Grade (0-100): 82

Name: Lynn, Amanda
Grade (0-100): -5
Re-enter the grade: 101
Re-enter the grade: 98

Name: Bird, Earl E
Grade (0-100): 87

Students:
Name : Hogg, Ima
Grade : 76
Name : Too, Yew R
Grade : 98
Name : Frisbee, Iona
Grade : 82
Name : Lynn, Amanda
Grade : 98
Name : Bird, Earl E
Grade : 87

Student(s) with highest grade
Name : Too, Yew R
Grade : 98
Name : Lynn, Amanda
Grade : 98

Class average is:88

Letters Grade:
Hogg, Ima:C
Too, Yew R:A
Frisbee, Iona:B
Lynn, Amanda:A
Bird, Earl E:B

Alphabetical listing:
Name : Bird, Earl E
Grade : 87
Name : Frisbee, Iona
Grade : 82
Name : Hogg, Ima
Grade : 76
Name : Lynn, Amanda
Grade : 98
Name : Too, Yew R
Grade : 98

Students by grade, high to low
Name : Lynn, Amanda
Grade : 98
Name : Too, Yew R
Grade : 98
Name : Bird, Earl E
Grade : 87
Name : Frisbee, Iona
Grade : 82
Name : Hogg, Ima
Grade : 76
Press any key to continue . . .
*/