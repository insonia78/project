package org.perscholas.securitydemo.service;

import java.util.List;

import org.perscholas.securitydemo.dao.ICourseRepo;
import org.perscholas.securitydemo.models.Course;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class CourseService {

	@Autowired
	ICourseRepo courseRepo;
	
	public List<Course> findAll() {

		return courseRepo.findAll();
	}
	
	public Course findById(Integer id) {

		return courseRepo.findById(id).get();

	}
	public boolean existsById(Integer id) {

		return courseRepo.existsById(id);
	}
	
	public void deleteById(Integer id) {

		if (existsById(id))
			courseRepo.deleteById(id);

	}
	public void save(Course c) {
		
		courseRepo.save(c);
	

	}
}
