package wednesday.jdbc_oop;

import java.util.List;

public interface UserDAOI {
	
	enum SQL {
		GET_ALL_USERS("SELECT * FROM users2"),
		GET_USERS_BY_ID("SELECT * FROM users2 WHERE user_id = ?"),
		GET_USER_BY_NAME("SELECT * FROM users2 WHERE name = ?"),
		VALIDATE_USER("SELECT password FROM users2 where email = ?"),
		UPDATE_USER("update users2 set name = ?, email = ?, password = ? where user_id = ?");
		
		private final String query;
		
		private SQL(String s) {
			this.query = s;
		}
		
		public String getQuery() {
			return query;
		}
	}
	
	/* Queries the database for all user information
	 * @return List containing all user information as User objects */
	List<User> getAllUsers();
	
	/* Queries the database for a specific user's information
	 * User id specifies the user 
	 * @param id refers to the user id being used 
	 * @return User object containing all information relating to the given id*/
	User getUserById(int id);
	
	User getUserByName(String name);
	Boolean validateUser(String email, String password);
	Boolean updateUser(User user);
}
