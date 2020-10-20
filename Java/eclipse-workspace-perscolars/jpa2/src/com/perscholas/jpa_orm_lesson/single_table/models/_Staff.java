package com.perscholas.jpa_orm_lesson.single_table.models;

import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Inheritance;
import javax.persistence.InheritanceType;
import javax.persistence.Table;

@Entity
@Table
@Inheritance(strategy = InheritanceType.SINGLE_TABLE)
public abstract class _Staff {
	@Id
	protected Integer sid;
	protected String sname;
	
	public _Staff() {}
	
	public _Staff(int sid, String sname) {
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
