package wednesday.intro_to_jdbc;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

import wednesday.jdbc_oop.User;

public class Slide12PreparedStatement {
	public static void main(String[] args) throws SQLException {
		// Declare Connection, PreparedStatement and ResultSet objects
		Connection conn = null;
		PreparedStatement stmt = null;
		ResultSet rs = null;
		List<User> allUsers = null;
		User user = null;
		
		try {
			// Get the database connection
			conn = DriverManager.getConnection("jdbc:mariadb://localhost:3307/"
					+ "jdbctest?user=root&password=root");
			System.out.println("Connection made!!!");
			
			// Set the SQL query string
			String sql = "SELECT * FROM users2";
			/* Pass the query string to the prepareStatement method of the Connection object and 
			 * assign the result to the PreparedStatement object. */
			stmt = conn.prepareStatement(sql);
			
			// Set the query parameters (?) - (first position (?), value)
//			stmt.setInt(1, 1);
//			stmt.setString(2, "john@doe.com");
			
			// Run the query and assign the result to the ResultSet object
			rs = stmt.executeQuery();
			
			// Iterate through the ResultSet object as long as there is a next row of data to be read
			allUsers = new ArrayList<>();
			while (rs.next()) {
//				System.out.println("ID: " + rs.getInt(1));
//				System.out.println("Name: " + rs.getString(2));
//				System.out.println("Email: " + rs.getString(3));
//				System.out.println("Password: " + rs.getString(4));
				user = new User();
				user.setUserId(rs.getInt("user_id"));
//				String s = rs.getString("user_id");
//				System.out.println(s);
				user.setName(rs.getString("name"));
				user.setEmail(rs.getString(3));
				user.setPassword(rs.getString(4));
				allUsers.add(user);
			}
		} catch (SQLException e) {
			System.out.println(e.getMessage());
		}
		finally
		{
			if (!rs.equals(null)) {
				rs.close();
			}
			if (!stmt.equals(null)) {
				stmt.close();
			}
			if (!conn.equals(null)) {
				conn.close();
			}
		}
		
		
		for (User u : allUsers) {
			System.out.println(u.toString());
		}
	}
}