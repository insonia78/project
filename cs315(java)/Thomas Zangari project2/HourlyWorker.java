
/**
 * The class for the HourlyWorker
 *
 * @author (Thomas Zangari)
 * @version (a version number or a date)
 */
import java.text.*;
public class HourlyWorker extends Employee
{

    private double salary;
    private String overtime;
    private double hoursWorked;
    private double weeklySalary;
    DecimalFormat formatter = new DecimalFormat("$###.##");
   /**
    * Constructor with hours worked
    * @param name is the name
    * @param salary is the salary
    * @parm overtime if overtime is present 
    * @parm hoursWorked how many hours where worked 
    * @super 
    */
    public HourlyWorker(String name,String  id,double salary,String overtime,double hoursWorked)
    {
        super(name,id);

        this.salary = salary;
        this.overtime = overtime;
        this.hoursWorked = hoursWorked;
    }
    /**
    * Constructor with out hours worked
    * @param name is the name
    * @param salary is the salary
    * @parm overtime if overtime is present 
    * 
    * @super 
    */
    
    public HourlyWorker(String name,String  id,double salary,String overtime)
	{
	        super(name,id);

	        this.salary = salary;
	        this.overtime = overtime;
    }
    /**
     * Gets the salary
     * @return salary
     */
    public double getSalary()
    {
        return salary;
    }
    /**
     * Sets the salary
     * @param salary
     */
    public void setSalary(double salary)
    {
        salary = salary;
    }
    /**
     * Gets the overtime
     * @returns overtime
     */
    public String getOvertime()
    {
        return overtime;
    }
    /**
     * Sets the overtime
     * @parm overtime
     */
    public void setOvertime(String overtime)
    {
        overtime = overtime;
    }
    /**
     * Gets the hours worked
     * @return hoursWorked
     */
    public double getHoursWorked()
    {
        return hoursWorked;
    }
    /**
     * Sets the hours worked
     * @param hoursWorked
     */
    public void setHoursWorked(double hoursWorked)
    {
        hoursWorked = hoursWorked;
    }
    /**
     * Finds the weekly salary.If the overtime is false no overtime else yes
     * @param salary
     * @param HoursWorked
     * @return weeklySalary
     */
    public double FindSalary(double salary,double hoursWorked)
    {

        if(this.overtime == "false")
        {
			if(hoursWorked > 40)
			{
				weeklySalary = salary * 40;
			}
			else
			{
				weeklySalary = salary * hoursWorked;
			}
		}

        return weeklySalary;
    }
    /**
     * ToString()
     * @return print
     */
    public String toString()
    {

         String print = super.toString()+
                        formatter.format(this.salary)+"\t"+
                        this.overtime+"\t"+
                        this.hoursWorked+"\t"+
                        formatter.format(FindSalary(salary,hoursWorked))+"\n--------------------------------" ;
           return print;

    }



}
