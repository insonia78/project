package tuesday.advanced;

public class S25Person {
		
		private String name;
		private int age;
		
		public void setName(String name) {
			this.name=name;
			
		}
		public void setAge(int age) {
			this.age=age;
			
		}
		
		public void introduce() {
			System.out.println("Hello, my name is "+ name + " and I am "+age+" years old.");
		}
		
		public static void main(String[] args) {
			S25Person person = new S25Person();
			person.setName("Peter");
			person.setAge(21);
			person.introduce();
		}
}
