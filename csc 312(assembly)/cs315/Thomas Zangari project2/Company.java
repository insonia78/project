

import java.io.*;
import java.util.*;
import java.text.*;



/**
 * The Company class contains the array where the Employees are holds. It performs all the tasks that are asks int the
   Data Base class.Like add,find, find Weekly salary
 *
 * @author (Thomas Zangari)
 * @version (a version number or a date)
 */

public class Company
{
    private static final int MAX_SIZE = 7; // size of the array
    private static Employee[] dataBase = new Employee[MAX_SIZE]; //static database
    private String name =""; //holds the name of the Employee
    private String id ="";        // holds the id of the Employee
    private double salary = 0;         //holds the salary of the employee
    private String overtime = "null" ; //if overtime is present

    private double hoursWorked = 0; // hours worked only for the hourly employee
    private static int index = -1; //keeps the count of the index used in the array
    private quickSort quicksort = new quickSort(); // calls the quicksort algorithm.
    /**
      Empty constructior
    */

    public Company()
    {
    }
    /**
      constructor for creating a Salary Worker object and inserting it in the array
       @param name the name of the employee
       @param id the id of the employee
       @param salarythe salary of the employee
    */
    public Company(String name,String id,double salary)
    {
          index++;
          dataBase[index] = new SalariedWorker(name,id,salary);
    }
    /**
      constructor for creating a Hourly Worker object and inseting it in the array
      @param name the name of the employee
      @param id the id of the employee
      @param salary the salary of the employee
      @param overtime it has the boolean true or false
      @param hoursWorked if hours worked are present
    */
    public Company(String name,String id,double salary,String overtime,double hoursWorked)
    {
         index++;
         dataBase[index] = new HourlyWorker(name,id,salary,overtime,hoursWorked);
    }
    /**
          constructor for creating a Hourly Worker object and inseting it in the array
	      with no hours worked
	      @param name the name of the employee
	      @param id the id of the employee
	      @param salary the salary of the employee
	      @param overtime it has the boolean true or false

    */
    public Company(String name,String id, double salary,String overtime)
    {
		index++;
		dataBase[index] = new HourlyWorker(name,id,salary,overtime);
	}
	/**
	   it checks if the array need to call the expandCapacity method
	*/
    public void CheckForRoomInArray()
    {
		if(dataBase[dataBase.length - 1] != null)
		{
			dataBase = expandCapacity( dataBase, MAX_SIZE);
		}
	}

    /**
       It accepts an employee id and finds the employees index if present.
       \n-It uses binary search
       @param name_or_id is the employee Name
       @return foundIndex the employee index if present, or -1 otherwise
     */
    public int FindEmployee(String name_or_id)
    {

		boolean found = false;// if the employee was found it changes in true
		int foundIndex = -1;   // if the employee index was found or else it keeps the -1

		doquickSort();        // it calls the quicksort to sort the array in order to use binary search
		int first = 0;
		int last = index;
		int middle = (index / 2);


		while(found == false && first <= last)
		{
			middle= (first + last)/2;

		    if((dataBase[middle].getName().equals(name_or_id))  || (dataBase[middle].getId().equals(name_or_id)) )
		    {

		         foundIndex = middle;
		         found = true;
			 }
			 else if((dataBase[middle].getName().compareTo(name_or_id) > 0) || (dataBase[middle].getId().compareTo(name_or_id) > 0))
			 {

                	 last = middle - 1;

		     }
		     else if((dataBase[middle].getName().compareTo(name_or_id) < 0) || (dataBase[middle].getId().compareTo(name_or_id) < 0))
			 {
				    first = middle + 1;

			 }


		}

		return foundIndex;
	}
	/**
	 * It finds the employee by is index
	 * @param i is the index
	 */
	public void FindByPosition(int i)
	{
	    
	    if(i > index || i < 0)
	    {
            System.out.println("Position out of the lenght of the array") ; 	        
	    }
	    else
	    {
	      System.out.println(dataBase[i].toString());   
	     }
	    
	}
	public void Find(String name)
	{
	   int j = FindEmployee(name);
	   if(j == -1)
	   {
	       System.out.println("Employee not found");
	   }
	   else
	   {
	       System.out.println("The Employee is present at position " + (j+1));
	   }
	       
	    
	}
	/**
	   Add an employee to the array.And tells how many employees are in the array
	   \n-It calles the FindEmployee method to check if the employee is already present
	   @param employee it accepts an employee object
	*/
	public void Add(Employee employee)
	{

   		int j = 0; // holds the index of the employee if present, other -1
        String message ="" ;

		j = FindEmployee(employee.getName());


		if(j == -1)
		{
			dataBase[++index] = employee;
			System.out.println( "employee added at position " + (index+1) );
		}
		else
		{
			System.out.println("The employee is already present  at position" + (j+1));

		}
		System.out.println("They are " + (index+1) +" employees in the array");



	}
    /**
		   Removes an employee from the array.And it tell howmany employees are remaning
		   -It calles the FindEmployee method to check if the employee is present
		   @param name_or_id it accepts a name
	*/
	public void Remove(String name_or_id)
	{
		int j = 0;
		String message = "" ;
		j = FindEmployee(name_or_id);
         
		if(j > -1)
		{

		   dataBase[j] = null;
		   for(int i = j; i < index ; i++)
		   {
			   dataBase[i] = dataBase[i+1];


		   }
           System.out.println("The Employee was removed at position "+(j+1));
           --index;
           System.out.println("They are "+(index +1)+" Employees int the array");
	   }
	   else
	   {
		   System.out.println("Employee was not found");
	   }
	}
	/**
	    it calls the quicksort method from the quicksort class
	*/
	public void doquickSort()
	{

		dataBase = quicksort.quickSort(dataBase,index);
	}
	/**
	    It expands the capacity of the array by double the size of the original size
	    @param myArray the array
	    @param capacity the initial capacity of the array
	    @return the array expanded
	 */
	public Employee[] expandCapacity( Employee[] myArray, int capacity) {

	            capacity *= 2;

	        Employee[] newArray = new Employee[capacity]; // a) create a new array with an updated capacity

	        for (int i = 0; i < myArray.length; i++) {
	            newArray[i] = myArray[i];   // b) copy the contents of the  original into the new array
	        } // end for

	        myArray = newArray;  //c)  change the reference to the original Array

           return myArray;

	 }
     /**
       The method finds the weekly salary of the employee.
       It uses the FindEmployee method to find the Employee
       @param name_or_id the name of the Employee
       @return salary
      */
     public String FindWeeklysalary(String name_or_id)
     {
		 String salary = "";
         DecimalFormat formatter = new DecimalFormat("$###.##");
		 Scanner kbd = new Scanner(System.in);
		 int i = FindEmployee(name_or_id);//finds the index of the employee

		 if(i != -1)
		 {
			 if(dataBase[i].getOvertime() == "true")
			 {

				 char answer1 = 'Y';
				 if(dataBase[i].getHoursWorked() > 0)//if hours worked are already present in the array
				 {
					 System.out.println("-----------------------------------------------------------");
					 System.out.println("there are hours present in the dataBase!");
					 System.out.println("the present weekly salary is based on "+dataBase[i].getHoursWorked()+ " hours.\n And the current weekly salary is $" + formatter.format((dataBase[i].getSalary() * dataBase[i].getHoursWorked())));
                     System.out.println("----------------------------------------------------------------");
                     System.out.println("Do you want to find a different weekly salary?Y for yes or N for n");
                     String answer = kbd.next();
                     answer1 = answer.charAt(0);


				 }
				 if(Character.toUpperCase(answer1) == 'Y')
				 {
				   System.out.println("Please enter the number of hours");
				   double hours = kbd.nextDouble();
				   salary = FindWeeklysalary(formatter,name_or_id,hours,i);
			     }
			     else
			     {
				 }
			 }
			 else if(dataBase[i].getOvertime() == "false")
			 {

				 char answer1 = 'Y';
				 if(dataBase[i].getHoursWorked() > 0)
				 {
					 System.out.println("--------------------------------------------------------------");
					 System.out.println("there are hours present in the dataBase!");
					 System.out.println("the present weekly salary is based on "+dataBase[i].getHoursWorked()+ "hours.\nAnd the current weekly salary is " + formatter.format((dataBase[i].getSalary() * dataBase[i].getHoursWorked())));
                     System.out.println("--------------------------------------------------------------");
                     System.out.println("Do you want to find a different weekly salary?Y for yes or N for n");
					 String answer = kbd.next();
					 answer1 = answer.charAt(0);


				 }
				 if(Character.toUpperCase(answer1) == 'Y')
				 {
				   System.out.println("Please enter the number of hours");
                   double hours = kbd.nextDouble();
				   salary = FindWeeklysalary(formatter,name_or_id,hours,i);
				 }
				 else
				 {
				 }
			 }
			 else
			 {
			   salary = "the weekly salary is:$"+formatter.format((dataBase[i].getSalary()/52));
		     }
		 }
		 else
		 {
			 salary = "The Employee "+name_or_id+" does not exist";
		 }
		 return salary;
	 }
	 /**
	    It is an extention of the previus method it calculates the amount of hours too
	    @param formatter uses DecimalFormat class
	    @param name_or_id name of the employee
	    @param hours the number of hours to enter
	    @param i the index of the where the employee is located
	    @return salary
	  */
	 public String FindWeeklysalary(DecimalFormat formatter,String name_or_id,double hours,int i)
	 {
                 String salary = ""; 
				 if(dataBase[i].getOvertime().equals("true"))
				 {
	 			   salary = "the weekly salary is:$ "+formatter.format((dataBase[i].getSalary() * hours));
			     }
			     else
			     {
					 if(hours > 40)
					 {
						 salary = "Sorry no overtime allowed. The salary is calculated by 40 hours:$ " + formatter.format((dataBase[i].getSalary()* 40));
					 }
					 else
					 {
						 salary = "The weekly salary is:$ "+formatter.format((dataBase[i].getSalary() * hours));
					 }
				 }
           return salary;  
	 }
    /**
     It prints the content of the array
     */
	public void print()
	{

		int i = 0;
		System.out.println("name\t\t\tId\tSalary\tovertime hours    weeklySalary \n");
		while(i <= index)
		{
			System.out.println(this.dataBase[i].toString());
            i++;
		}

	}




}
