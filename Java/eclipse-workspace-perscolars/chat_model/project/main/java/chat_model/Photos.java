package chat_model;

public class Photos {

	private int photos_id;
	private int user_id;
	private String photo_path;
	public Photos(User user) {
		this.user_id = user.getUser_id();
	}
	public int getPhotos_id() {
		return photos_id;
	}
	public void setPhotos_id(int photos_id) {
		this.photos_id = photos_id;
	}
	public int getUser_id() {
		return user_id;
	}
	public void setUser_id(int user_id) {
		this.user_id = user_id;
	}
	public String getPhoto_path() {
		return photo_path;
	}
	public void setPhoto_path(String photo_path) {
		this.photo_path = photo_path;
	}
	
}
