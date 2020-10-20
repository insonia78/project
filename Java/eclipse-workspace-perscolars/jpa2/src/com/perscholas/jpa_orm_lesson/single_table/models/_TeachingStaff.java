package com.perscholas.jpa_orm_lesson.single_table.models;

import javax.persistence.DiscriminatorValue;
import javax.persistence.Entity;

@Entity
@DiscriminatorValue(value = "TS")
public class _TeachingStaff extends _Staff {
	private String qualification;
	private String subjectExpertise;
	
	public _TeachingStaff() {}
	
	public _TeachingStaff(int sid, String sname, String qualification, String subjectExpertise) {
		super(sid, sname);
		this.qualification = qualification;
		this.subjectExpertise = subjectExpertise;
	}
	
	public String getQualification() {
		return qualification;
	}
	public void setQualification(String qualification) {
		this.qualification = qualification;
	}
	public String getSubjectExpertise() {
		return subjectExpertise;
	}
	public void setSubjectExpertise(String subjectExpertise) {
		this.subjectExpertise = subjectExpertise;
	}
	
	
}
