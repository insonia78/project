package com.perscholas.jpa_orm_lesson.models;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.PrimaryKeyJoinColumn;
import javax.persistence.Table;

@Entity
@Table(name = "non_teaching_staff")
@PrimaryKeyJoinColumn(referencedColumnName = "staff_id")
public class NonTeachingStaff extends Staff {
	@Column(name = "area_expertise")
	private String areaExpertise;

	public NonTeachingStaff() {}
	
	public NonTeachingStaff(int sid, String sname, String areaExperience) {
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
