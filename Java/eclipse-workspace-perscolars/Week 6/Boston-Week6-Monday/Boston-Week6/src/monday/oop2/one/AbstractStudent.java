package monday.oop2.one;

public abstract class AbstractStudent {
		
	
	protected String firstName;
	protected String lastName;
	protected double gpa;
	
	public void setFirstName(String name) {
		this.firstName = name;
	}
	public void setLastName(String name) {
		this.lastName = name;
	}
	
	public void setGPA (double grade) {
		this.gpa = grade;
	}
	
	abstract void getInfo();
	abstract String[] getName();
}
