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
			stmt.setInt(1, id);
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

	@Override
	public User getUserByName(String name) {
		User user = null;
		connect();
		try {
			stmt = conn.prepareStatement(SQL.GET_USER_BY_NAME.getQuery());
			stmt.setString(1, name);
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

	@Override
	public Boolean validateUser(String email, String password) {
		String dbPassword = null;
		connect();
		try {
			stmt = conn.prepareStatement(SQL.VALIDATE_USER.getQuery());
			stmt.setString(1, email);
			rs = stmt.executeQuery();
			if (rs.next()) {
				dbPassword = rs.getString(1);
			}
		} catch (SQLException e) {
			System.out.println(e.getMessage());
		}
		dispose();
		if (password.equals(dbPassword)) {
			return true;
		}
		return false;
	}

	@Override
	public Boolean updateUser(User user) {
		int updateInt = 0;
		connect();
		try {
			stmt = conn.prepareStatement(SQL.UPDATE_USER.getQuery());
			stmt.setString(1, user.getName());
			stmt.setString(2, user.getEmail());
			stmt.setString(3, user.getPassword());
			stmt.setInt(4, user.getUserId());
			updateInt = stmt.executeUpdate();

			System.out.println(updateInt);
		} catch (SQLException e) {
			System.out.println(e.getMessage());
		}
		dispose();
		
		if (updateInt > 0) {
			return true;
		}
		
		return false;
	}
}