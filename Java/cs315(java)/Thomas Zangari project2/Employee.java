

/**
 * Write a description of class Employee here.
 *
 * @author (your name)
 * @version (a version number or a date)
 */
public abstract class Employee
{
    private String name ;
    private String id;
     private double salary;
     private String overtime;
     private double hoursWorked;
    private double weeklySalary;


    public Employee(String name, String id )
    {
        this.name = name;
        this.id = id;
        this.salary = 0;
        this.overtime = "null";
        this.hoursWorked = 0;
        this.weeklySalary = 0;
    }
    public String getName(){return name;}
    public void setName(String n){}
    public String getId()
    {
        return id;
    }
    public void setId(String id)
    {
        id = id;
    }
    public double getSalary()
	    {
	        return salary;
	    }
	    public void setSalary(double salary)
	    {
	        salary = salary;
	    }
	    public String getOvertime()
	    {
              return overtime;
	    }
	    public void setOvertime(String overtime)
	    {
	        this.overtime = overtime;
	    }
	    public double getHoursWorked()
	    {
	        return this.hoursWorked;
	    }
	    public void setHoursWorked(double hoursWorked)
	    {
	        this.hoursWorked = hoursWorked;
	    }
	    public double FindSalary()
	    {
	        this.weeklySalary = salary * hoursWorked;
	        return weeklySalary;
    }

    public String toString()
    {
		String fixedname = name;

		while(fixedname.length() < 19)
		{
		  fixedname +=".";
		}
        String print =  fixedname+"\t"+ id+"\t" ;
        return print;
    }
}
