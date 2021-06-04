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
			conn = DriverManager.getConnection("jdbc:mariadb://localhost:3307/"
					+ "jdbctest?user=root&password=root");
			System.out.println("Connection made!!!");
			
			
			
			String sql = "INSERT INTO users2 (name, email, password) values ('Jane', 'jane@doe.com', 'jane1234')";
//			String sql = "create table users2 (user_id int auto_increment primary key, name varchar(50), email varchar(50), password varchar(50))";

			stmt = conn.createStatement();
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