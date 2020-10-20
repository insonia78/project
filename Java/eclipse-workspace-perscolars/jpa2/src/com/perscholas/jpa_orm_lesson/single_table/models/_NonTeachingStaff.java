package com.perscholas.jpa_orm_lesson.single_table.models;

import javax.persistence.DiscriminatorValue;
import javax.persistence.Entity;

@Entity
@DiscriminatorValue(value = "NS")
public class _NonTeachingStaff extends _Staff {
	private String areaExpertise;

	public _NonTeachingStaff() {}
	
	public _NonTeachingStaff(int sid, String sname, String areaExperience) {
		super(sid, sname);
		this.areaExpertise = areaExperience;
	}
	
	public String getAreaExpertise() {
		return areaExpertise;
	}

	public void setAreaExpertise(String areaExpertise) {
		this.areaExpertise = areaExpertise;
	}
	
}
