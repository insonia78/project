package com.perscholas.jpa_orm_lesson.models;

import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.NamedQuery;
import javax.persistence.Table;

@Entity
@Table(name = "departments")
@NamedQuery(query = "SELECT d FROM Department d WHERE d.did = :id", name = "Find Department By ID")
public class Department {
	@Id
	@Column(name = "did")
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	private int did;
	@Basic
	@Column(name = "dname")
	private String dname;
	@Basic
	@Column(name = "dstate")
	private String dstate;
	public int getDid() {
		return did;
	}

	public void setDid(int did) {
		this.did = did;
	}

	public String getDname() {
		return dname;
	}

	public void setDname(String dname) {
		this.dname = dname;
	}

	public String getDstate() {
		return dstate;
	}

	public void setDstate(String dstate) {
		this.dstate = dstate;
	}

	
	
   public Department() {}
	
	public Department(String dname, String dstate) {
		this.dname = dname;
		this.dstate = dstate;
		
	}
	public Department(int id,String dname, String dstate) {
		this.dname = dname;
		this.dstate = dstate;
		this.did = id;		
	}
	@Override
	public String toString() {
		return "ID: " + this.did + 
				"\nName: " + this.dname + 
				"\nState: " + this.dstate;				
	}
}
