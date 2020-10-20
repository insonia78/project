package exercise.jbcd.slide1602;

import java.util.List;

public interface UserDAOI {
	enum SQL {
		GET_ALL_USERS("SELECT * FROM users"),
		GET_USERS_BY_ID("SELECT * FROM users WHERE user_id = ?");
		
		private final String query;
		
		private SQL(String s) {
			this.query = s;
		}
		
		public String getQuery() {
			return query;
		}
	}
	
	/* Queries the database for all student information
	 * @return List containing all user information as User objects */
	List<User> getAllUsers();
	
	/* Queries the database for a specific user's information
	 * User id specifies the user 
	 * @param id refers to the user id being used 
	 * @return User object containing all information relating to the given id*/
	User getUserById(int id);
}
