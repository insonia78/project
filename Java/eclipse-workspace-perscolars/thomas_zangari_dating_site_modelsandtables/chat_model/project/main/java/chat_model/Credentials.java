package chat_model;


public class Credentials {
 
	private int credentials_id;
	private int user_id;
	private String password;
	
	public Credentials(User user){
		this.user_id = user.getUser_id();		
	}
	public int getCredentials_id() {
		return credentials_id;
	}
	public void setCredentials_id(int credentials_id) {
		this.credentials_id = credentials_id;
	}
	public int getUser_id() {
		return user_id;
	}
	public void setUser_id(int user_id) {
		this.user_id = user_id;
	}
	public String getPassword() {
		return password;
	}
	public void setPassword(String password) {
		this.password = password;
	}
}
