package wednesday.jdbc_oop;

//import java.util.Scanner;

public class UserApp {

	public static void main(String[] args) {
		UserDAO udao = new UserDAO();
//		User uById = udao.getUserByName("John");
//		System.out.println(uById.toString());
		
		User user = new User();
		user.setUserId(1);
		user.setName("Bob");
		user.setEmail("bob@email.com");
		user.setPassword("bob1234");
		udao.updateUser(user);
		
//		Scanner s = new Scanner(System.in);
//		System.out.println("Please enter your email: ");
//		String email = s.nextLine();
//		System.out.println("Please enter your password: ");
//		String password = s.nextLine();
//		Boolean validated = udao.validateUser(email, password);
//		if (validated) {
//			System.out.println("You are logged in!");
//		} else {
//			System.out.println("Login failed.");
//		}
//		s.close();
	}
}
