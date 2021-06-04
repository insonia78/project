package org.perscholas.securitydemo.models;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;


@Entity
public class Course {
	@Id
	@GeneratedValue(strategy = GenerationType.AUTO)
	private Integer cID;
	private String cName;
	
	
	//default cons
	public Course() {}
	//cons without ID
	public Course(String cName, User user) {
		this.cName = cName;
		
	}
	
	//getters & setters
	public Integer getcID() {
		return cID;
	}
	public void setcID(Integer cID) {
		this.cID = cID;
	}
	public String getcName() {
		return cName;
	}
	public void setcName(String cName) {
		this.cName = cName;
	}




	
}
