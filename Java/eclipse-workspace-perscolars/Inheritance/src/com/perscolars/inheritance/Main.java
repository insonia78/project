package com.perscolars.inheritance;

public class Main {

	public static void main(String[] args) {
		// TODO Auto-generated method stub

	}

}
abstract class Employee{
	protected long employeeId = 0;
	protected String employeeName = "";
	protected String employeeAddress ="";
	protected long employeePhone =0;
	protected double basicSalary = 0;
	protected double specialAllowance = 250.80;
	protected double Hra = 1000.50;
			
	public Employee()
	{
		
	}
	public Employee(long id, String name, String address,
			long phone)
	{
		this.employeeId = id;
		this.employeeName = name;
		this.employeeAddress = address;
		this.employeePhone = phone;
	}
	protected  void calculateSalary()
	{
		double salary =	this.basicSalary + (basicSalary * this.specialAllowance/100)
				+(this.basicSalary * this.Hra/100);
	}
	
}
class Manager extends Employee{
	public Manager(long id, String name, String address,
			long phone)
	{
		super(id,name,address,phone);
	}
	
	
}
