package monday.oop2.one;

public class Student extends AbstractStudent implements StudentI{
			
	
			//from Abstraction 
	@Override
	void getInfo() {
		// TODO Auto-generated method stub
		System.out.println("Hi. My name is " + this.firstName + " " + this.lastName);
		System.out.println("I have a " + this.gpa + " GPA.");
	}

	@Override
	String[] getName() {
		// TODO Auto-generated method stub
		String[] name = {this.firstName,this.lastName};
		return name;
	}

	
		
	// from Implementation
	
	String nickName;
	@Override
	public void setNickName(String name) {
		// TODO Auto-generated method stub
		this.nickName=name;
	}

	@Override
	public void introduceSelf() {
		// TODO Auto-generated method stub
		System.out.println("Hi, I'm " + nickName);
		System.out.println("I'm attending "+ this.school);
	}

}
