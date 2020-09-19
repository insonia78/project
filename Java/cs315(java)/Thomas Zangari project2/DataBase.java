
/**
 * the program reads a file of Employees and then it interacks with the client to perform some tasks
 * like, adding,finding,removing an employee,and then printing the list.
 * The program uses inheritance and polymorphism to separet and store two different types of Employees in a array. A Salary worker
   and a Hourly worker.
   @author (thomas Zangari)
 * @version (10/21/2014)
 */
import java.io.*;
import java.util.*;

/**
  The class reades a file and then interacts with the client to perform some opeartion on it like Find,Add,Remove,Find a weekly salary, and print the list
*/
public class DataBase
{
	private Scanner infile ;    // Scaner object for reading file stream
	private String salaryEmployee ; // it holds the tag for the salary that is read from the file
	private char tag;              // it holds the character that is charAt from the string
	private String name ="";       // the name of the Employee
	private String id ="";         // it holds the id
	private double salary = 0;     // it holds the salary
	private String overtime =  "" ;   // if overtime is allowed in the hourly worker
	private double hoursWorked = 0;     //  it holds the hours worked from the hourly employee
	private Company company ;           //  Company class to save the data in the array


    /**
       Empty constructor
    */


    public DataBase()
    {
	}
	/**
	  It reads a file and call's the Company object to store the data in the array
	  @param is the name of the file to be read
	  @return void
	 */
	public void AddFile(String filename)
	{

	 try
		{

            // creating a scannre class to read the file
			infile = new Scanner(new FileReader(filename));
			// while file has a next value
			while(infile.hasNext())
			{

				salaryEmployee = infile.next();// reading the tag S
				tag = salaryEmployee.charAt(0); // getting the char value

				if( tag == 'S')//is a Salary worker
				{
					// reading the name of the salary employee from the file
					name = infile.next();
					// reading the id from the file
					id = infile.next();
					//reading the salary
					salary = infile.nextDouble();
					// creating a object for the salary worker to be stored in the array
					company = new Company(name,id,salary);
					// checking if the array needs to expanded
					company.CheckForRoomInArray();

				}
				else if(tag == 'H') // is a hourly worker
				{
					// reading the name of the hourly worker from the file
					name = infile.next();
					// reading the id from the file
					id = infile.next();
					// getting the hourly salary
					salary = infile.nextDouble();
					// if overtime is allowed
					overtime = infile.next();

					if(overtime == "false")// if overtime is not allowed
					{
						// creating a object for salary worker with no overtime allowed
						company = new Company(name,id,salary,overtime);
						// cheking if array needs expanded
						company.CheckForRoomInArray();
					}
					else
					{
						if(infile.hasNext("H") == true || infile.hasNext("S") == true)
						{
							hoursWorked = 0;

						}
						else
						{

							hoursWorked = Double.parseDouble(infile.next());

						}
                        // creating a object for a Hourly Worker with overtime allowed
						company = new Company(name,id,salary,overtime,hoursWorked);
						//checking if array needs expanded
						company.CheckForRoomInArray();
					}


				}
			}

			}
			catch(IOException e) // if some thing else is the problem
			{
				Scanner kbd = new Scanner(System.in);

				System.out.println("Cant read the file"+ e);
				System.out.print("Enter the filename:  ");
				filename = kbd.nextLine();
				AddFile(filename);

			}




    }
    /**
      Main method it reads the first file and holds the menu for the interaction with
      the client
     */

    public static void main(String[] args)
    {

       Scanner kbd = new Scanner(System.in);// scanner for reading imputs from the keyboard
       int input = 10; //holds the input of the user for selection of the menu
       DataBase dataBase = new DataBase(); // creates an object for reading the file
	   dataBase.AddFile("EmployeeData.txt"); //reading the initial file
       Company company = new Company();
       boolean invalid = false;


       while(input != 9)
       {

		   System.out.print("\n\n1) Add a salaried worker"+
		   	   			"\n2) Add an hourly worker who has no overtime allowed"+
		   	   			"\n3) Add an hourly worker who has overtime allowed."+
		   	   			"\n4) Print the sorted list."+
		   	   			"\n5) Remove a worker."+
		   	   			"\n6) Find a worker by name"+
		   	   			"\n7) Find a worker by position(position starts at 1)"+
		   	   			"\n8) Find the weekly salary"+
		   	   			"\n9) end the process: ");

		   		   try
		   		   {
					invalid = false;
		   		   // getting the users choice
		   		    input = kbd.nextInt();

		   		   }
		           catch(InputMismatchException e)
		   		   {
		                 System.out.println("Wrong key!");
		                 kbd.nextLine();
                         invalid = true;
		   		   }






		   if(input > 9 && invalid == false) //if their is a wrong key
		    {
				System.out.println("Wrong key");


			}
			else
			{
		           switch (input)
		           {
		                        case 1:
		                        {
									 AddSalaryWorker(company,kbd);
									 break;
								}
								case 2:
								{
								   // hourly worker with out overtime
								   AddHourlyWorkerWithOOT(company,kbd);
								   break;
								}
								case 3:
								{
								   //hourly wroker with overtime
								   AddHourlyWorkerWithOT(company,kbd);
								   break;
								}
								case 4:
								{
									//prints the list
								    Print(company);

									break;
								}
								case 5:
								{
									//removes a employee
									Remove(company,kbd);
									break;
								}
								case 6:
								{
									//finds an employee
									Find(company,kbd);
									break;
								}
								case 7:
								{
								    FindByPosition(company,kbd);
								    break;
								}
								case 8:
								{
									//finds the weekly salary
									FindWeeklySalary(company,kbd);
									break;
								}
								case 9:
		                        {
		                           System.exit(0);							
								}
							}
			}

	   }



    }
    /**
     * It calles the findByposition method in the company class
     * @param company the company object to add the employee
       @param kbd scanner for reading inputs from the keyboard
     */
    public static void FindByPosition(Company company, Scanner kbd)
    {
        int position;
        System.out.println("What is the position that you want to find? Positions start a 1");
        position = kbd.nextInt();
        company.FindByPosition(position);
        
    }
    /**
      It askes for the field to be compleated. It creates a salary worker object and uses the
      Add method from the company class to insert it in the array
      @param company the company object to add the employee
      @param kbd scanner for reading inputs from the keyboard
      @return void
    */
    public static void AddSalaryWorker(Company company,Scanner kbd)
   {
	   String answer;
	   char answer1 ;
	   String name;
	   String id;
	   double salary;
	   double hoursWorked ;

		   System.out.print("What is the name? ");
		   name = kbd.next();
		   System.out.print("What is the id? ");
		   id = kbd.next();
		   System.out.print("What is the Salary?" );
		   salary = kbd.nextDouble();
		   //checking if arry needs to be expanded
		   company.CheckForRoomInArray();
		   // creating a salary worker object to add to the array
		   SalariedWorker worker = new SalariedWorker(name,id,salary);
		   // using the Add method in the company class to add the worker in the array
		   company.Add(worker);
   }
   /**
         It askes for the field to be compleated. It creates a hourly worker object and uses the
         Add method from the company class to insert it in the array
         @param company the company object to add the employee
         @param kbd scanner for reading inputs from the keyboard
         @return void
    */
   public static void AddHourlyWorkerWithOT(Company company, Scanner kbd)
   {
	   System.out.print("What is the name? ");
	   String name = kbd.next();
	   System.out.print("What is the id? ");
	   String id = kbd.next();
	   System.out.print("What is the Salary?" );
	   double salary = kbd.nextDouble();
	   String overtime = "true";
	   //checking  if array needs to be expanded
	   company.CheckForRoomInArray();
	   //creating an hourly worker oject
	   HourlyWorker worker = new HourlyWorker(name,id,salary,overtime);
	   // adding the worker in the array
	   company.Add(worker);

   }
   /**
            It askes for the field to be compleated.Creates an hourly worker object and then uses the
            Add method from the company class to insert it in the array
            @param company the company object to add the employee
            @param kbd scanner for reading inputs from the keyboard
            @return void
    */
   public static void AddHourlyWorkerWithOOT(Company company, Scanner kbd)
      {
   	   System.out.print("What is the name? ");
   	   String name = kbd.next();
   	   System.out.print("What is the id? ");
   	   String id = kbd.next();
   	   System.out.print("What is the Salary?" );
   	   double salary = kbd.nextDouble();
   	   String overtime = "false";
   	   company.CheckForRoomInArray();
       HourlyWorker worker = new HourlyWorker(name,id,salary,overtime);
	   company.Add(worker);
   }
   /**
        It askes the name of the employee to be removed and then calls the company.Remove
        to remove the employee from the array
        @param company the company object to add the employee
	    @param kbd scanner for reading inputs from the keyboard
        @return void
    */
   public static void Remove(Company company,Scanner kbd)
   {
	   String name_or_id ;
	   System.out.print("What name do you want to remove? ");
	   name_or_id = kbd.next();
	   company.Remove(name_or_id);


   }
   /**
       It askes the name of the employee to be found and then calls the company.Find
       to find the employee from the array
       @param company the company object to add the employee
   	   @param kbd scanner for reading inputs from the keyboard
       @return void
    */
   public static void Find(Company company,Scanner kbd)
   {
	   String findName;
	   System.out.print("What name do you want to find? ");
       findName = kbd.next();
       company.Find(findName);
       
   }
   /**
       It askes the name of the employee for which you want to find the weekly salary and then calls the company.FindWeeklysalary
       to find the weekly
       @param company the company object to add the employee
   	   @param kbd scanner for reading inputs from the keyboard
       @return void
    */
   public static void FindWeeklySalary(Company company, Scanner kbd)
   {
       String salary="";
	   System.out.print("What is the name? ");
	   String name = kbd.next();
	   salary = company.FindWeeklysalary(name);
	   System.out.println(salary);
	   
   }
   /**
       It calles the company.quicksort and the company.print that prints the content of the array
       @param company the company object to add the employee
   	   @return void
    */
   public static void Print(Company company)
   {
	   company.doquickSort();
	   company.print();

   }
  
}


