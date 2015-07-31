//Thomas Zangari
/**
The public class Student with the setGrade,getGrade,getName,and toString methods.
*/
public class Student
{
    private String name;
    private int grade;
    /**
    Constructor accepts arguments for the objects field.
    @param newName Sets the variable with the argument
    */
    public Student( String newName )
    {
        name = newName ;
        grade = 0 ;// Sets name to newName, grade to 0.

    }
    /** overloaded Student class Constructor accepts arguments for the object fiels for validating grade
    @param newName Sets the variable name with the argument newName.
    @param newGrade Sets the variable grade with the argument newGrade.
    */

    public Student(String newName, int newGrade )
    {
        if (newGrade < 0 || newGrade > 100)                   // Validates newGrade: between 0 and 100
        {
			System.out.println("The grade is not valid");     // If newGrade isn't valid, error message and quit.
            System.exit(0);
        }
        else
        {
			 name = newName;                                  // Otherwise, sets name to newName, grade to newGrade.
			 grade = newGrade;
	    }
    }
    /**
    The setGrade method mutator accepts a argument for the object field and sets the argument for validation.
    @ param newGrade argument  for validating the grade
    */

    public void setGrade( int newGrade )
    {
     if (newGrade < 0 || newGrade > 100)     // Validates newGrade: between 0 and 100.
     {
		  System.out.println("The grade is not valid");// If newGrade isn't valid, error message and
     }                                                 // leave grade unchanged.

    }
    /**
    The getGrade method returns the grade of the student.
    @return the grade
    */

    public int getGrade()
    {
       return grade;

    }
    /**
    The getName method return the name of the student.
    @return the name of the student.
    */
    public String getName()
    {
       return name;
    }
    /**
    The toString method returns the grade and the name of the student.
    @return the name and the grade of the student.
    */
    public String toString()
    {
        return "Name : " + name + "\nGrade : " + grade;// Form should be:
        // Name: John Smith
        // Grade: 98

    }
}


