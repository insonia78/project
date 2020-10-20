package com.perscholas.jpa_orm_lesson.models;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.PrimaryKeyJoinColumn;
import javax.persistence.Table;

@Entity
@Table(name = "teaching_staff")
@PrimaryKeyJoinColumn(referencedColumnName = "staff_id")
public class TeachingStaff extends Staff {
	@Column(name="qualification")
	private String qualification;
	@Column(name = "subject_expertise")
	private String subjectExpertise;
	
	public TeachingStaff() {}
	
	public TeachingStaff(int sid, String sname, String qualification, String subjectExpertise) {
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
