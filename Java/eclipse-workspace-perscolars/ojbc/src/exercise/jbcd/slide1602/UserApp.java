package exercise.jbcd.slide1602;

public class UserApp {

	public static void main(String[] args) {
		
		UserDAO udao = new UserDAO();
		User uById = udao.getUserById(1);
		System.out.println(uById.toString());
	}

}
