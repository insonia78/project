package org.perscholas.securitydemo.models;

import java.util.List;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToMany;
import javax.validation.constraints.NotNull;

import org.springframework.beans.factory.annotation.Value;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.annotation.PropertySource;
import org.springframework.context.annotation.PropertySources;
import org.springframework.stereotype.Component;





@PropertySources({
@PropertySource(value = "classpath:application.properties", ignoreResourceNotFound=true),
@PropertySource("classpath:application.properties")
        })

@Entity
public class User {

	@Id
	@GeneratedValue(strategy = GenerationType.AUTO)
	@NotNull(message = "Field is required!")
	
	private Integer uID;
	private String uName;
	@Column(unique=true) 
	private String uEmail;
	@Column(columnDefinition = "boolean default true")
	private Boolean uEnabled;
	@NotNull(message = "Field is required!")
	@Value("${role.admin:USER}")
	private String uRole;
	private String uPassword;
	@OneToMany(targetEntity = Course.class)
	private List<Course> course;
	
	//default cons
	public User() {}
	//cons without ID
	public User(String uName, String uEmail, Boolean uEnabled, @NotNull(message = "Field is required!") String uRole,
			String uPassword, List<Course> course) {
		this.uName = uName;
		this.uEmail = uEmail;
		this.uEnabled = uEnabled;
		this.uRole = uRole;
		this.uPassword = uPassword;
		this.course = course;
	}
	public User(String uName, String uEmail, Boolean uEnabled, @NotNull(message = "Field is required!") String uRole,
			String uPassword) {
		this.uName = uName;
		this.uEmail = uEmail;
		this.uEnabled = uEnabled;
		this.uRole = uRole;
		this.uPassword = uPassword;
		
	}



	
	

	
	//getters & setters
	public Integer getuID() {
		return uID;
	}
	public void setuID(Integer uID) {
		this.uID = uID;
	}
	public String getuName() {
		return uName;
	}
	public void setuName(String uName) {
		this.uName = uName;
	}
	public String getuEmail() {
		return uEmail;
	}
	public void setuEmail(String uEmail) {
		this.uEmail = uEmail;
	}
	public Boolean getuEnabled() {
		return uEnabled;
	}
	public void setuEnabled(Boolean uEnabled) {
		this.uEnabled = uEnabled;
	}
	public String getuRole() {
		return uRole;
	}
	public void setuRole(String uRole) {
		this.uRole = uRole;
	}
	public List<Course> getCourse() {
		return course;
	}
	public void setCourse(List<Course> course) {
		this.course = course;
	}






	public String getuPassword() {
		return uPassword;
	}






	public void setuPassword(String uPassword) {
		
		this.uPassword = uPassword;
	}
	@Override
	public String toString() {
		return "User [uID=" + uID + ", uName=" + uName + ", uEmail=" + uEmail + ", uEnabled=" + uEnabled + ", uRole="
				+ uRole + ", uPassword=" + uPassword + "]";
	}

	
	
}
