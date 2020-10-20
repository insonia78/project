package wednesday.intro_to_jdbc;

import java.sql.DriverManager;
import java.sql.SQLException;

public class Slide08JdbcConnect {
	public static void main(String[] args) throws SQLException {
		
		try {
			DriverManager.getConnection("jdbc:mariadb://localhost:3306/"
					+ "test?user=root&password=test");
			System.out.println("Connection made!!!");
		} catch (SQLException e) {
			System.out.println(e.getMessage());
		}
	}
}