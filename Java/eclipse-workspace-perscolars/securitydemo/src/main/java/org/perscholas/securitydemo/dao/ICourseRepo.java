package org.perscholas.securitydemo.dao;

import org.perscholas.securitydemo.models.Course;
import org.springframework.data.jpa.repository.JpaRepository;

public interface ICourseRepo extends JpaRepository<Course, Integer> {

}
