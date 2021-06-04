package org.perscholas.simplespringapp.models;

import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;

import org.perscholas.simplespringapp.annotations.ValidDob;
import org.perscholas.simplespringapp.annotations.ValidEmail;

public class User {
	@NotNull
	@Size(min=5, max=14, message="Username must be between {2} and {1}")
	private String username;
	private String password;
	@ValidEmail
	private String email;
	private String dob;
	
	public String getUsername() {
		return username;
	}
	public void setUsername(String username) {
		this.username = username;
	}
	public String getPassword() {
		return password;
	}
	public void setPassword(String password) {
		this.password = password;
	}
	public String getEmail() {
		return email;
	}
	public void setEmail(String email) {
		this.email = email;
	}
	
	public String getDob() {
		return dob;
	}
	public void setDob(String dob) {
		this.dob = dob;
	}
}
