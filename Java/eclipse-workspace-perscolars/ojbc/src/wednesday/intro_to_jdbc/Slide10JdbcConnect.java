package wednesday.intro_to_jdbc;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.sql.Statement;

public class Slide10JdbcConnect {
	public static void main(String[] args) throws SQLException {
		Connection conn = null;
		Statement stmt = null;
		try {
			conn = DriverManager.getConnection("jdbc:mariadb://localhost:3306/"
					+ "test?user=root&password=test");
			System.out.println("Connection made!!!");
			String create = "Create table user(user_id int AUTO_INCREMENT,"
					+ "Name varchar(45),"
					+ "email varchar(45),"
					+ "password varchar(45),"
					+ "PRIMARY KEY(user_id));";
			String sql = "INSERT INTO user (name, email, password) values ('John', 'john@doe.com', 'john1234');";
			stmt = conn.createStatement();
			//stmt.executeQuery(create);
			stmt.executeQuery(sql);
		} catch (SQLException e) {
			System.out.println(e.getMessage());
		}
		finally
		{
			if (!stmt.equals(null)) {
				stmt.close();
			}
			if (!conn.equals(null)) {
				conn.close();
			}
		}
	}
}