package tuesday.advanced;

public class S26PersonChaining {

	private String name;
	private int age;
	
	public S26PersonChaining setName(String name) {
		this.name=name;
		return this;
	}
	public S26PersonChaining setAge(int age) {
		this.age=age;
		return this;
	}
	
	public void introduce() {
		System.out.println("Hello, my name is "+ name + " and I am "+age+" years old.");
	}
	
	public static void main(String[] args) {
		S26PersonChaining person = new S26PersonChaining();
		person.setName("Peter")
		.setAge(21)
		.introduce();
	}
	
	

}
