package wednesday.jdbc_oop;

import java.sql.SQLException;
import java.util.List;

public class UserDAO extends AbstractDAO implements UserDAOI {
	
	@Override
	public List<User> getAllUsers() {
		return null;
	}

	@Override
	public User getUserById(int id) {
		User user = null;
		connect();
		try {
			stmt = conn.prepareStatement(SQL.GET_USERS_BY_ID.getQuery());
			stmt.setInt(1, 1);
			rs = stmt.executeQuery();
			if (rs.next()) {
				user = new User();
				user.setUserId(rs.getInt(1));
				user.setName(rs.getString(2));
				user.setEmail(rs.getString(3));
				user.setPassword(rs.getString(4));
			}
		} catch (SQLException e) {
			System.out.println(e.getMessage());
		}
		dispose();
		return user;
	}

}
