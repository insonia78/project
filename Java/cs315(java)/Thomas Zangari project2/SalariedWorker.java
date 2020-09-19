
/**
 * Sets, gets and toString() the Salary Worker parameters 
 *
 * @author (Thomas)
 * @version (a version number or a date)
 */
import java.text.*;
public class SalariedWorker extends Employee
{

    double salary;
    double weeklySalary;
    DecimalFormat formatter = new DecimalFormat("$###.##");

    /**
     * Constructor 
     * @param name
     * @param id
     * @param salary
     */
    public SalariedWorker(String name, String id,double salary)
    {
       super(name,id);
       this.salary = salary;

    }
    /**
     * gets the salary
     * @return salary
     */
    public double getSalary()
    {
        return this.salary;
    }
    /**
     * sets the salary
     * @param salary
     */
    public void setSalary(double salary)
    {
        this.salary = salary;
    }
    /**
     * Finds the weekly salary
     * @return weeklySalary
     */
    public double FindSalary()
    {
        this.weeklySalary = salary/52;

        return weeklySalary;
    }
    /**
     * ToString()
     * @return print
     */
    public String toString()
    {

        String print = super.toString()+
                       formatter.format(this.salary)+"\t\t\t"+
                       formatter.format(FindSalary())+"\n---------------------------------";
        return print;
    }
}
