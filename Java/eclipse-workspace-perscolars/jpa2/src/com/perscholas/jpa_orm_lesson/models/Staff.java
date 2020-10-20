package com.perscholas.jpa_orm_lesson.models;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Inheritance;
import javax.persistence.InheritanceType;
import javax.persistence.Table;

@Entity
@Table(name = "staff")
@Inheritance(strategy = InheritanceType.JOINED)
public abstract class Staff {
	@Id
	@Column(name = "staff_id")
	protected Integer sid;
	@Column(name = "sname")
	protected String sname;
	
	public Staff() {}
	
	public Staff(int sid, String sname) {
		this.sid = sid;
		this.sname = sname;
	}
	
	public Integer getSid() {
		return sid;
	}
	public void setSid(Integer sid) {
		this.sid = sid;
	}
	public String getSname() {
		return sname;
	}
	public void setSname(String sname) {
		this.sname = sname;
	}
	
}
