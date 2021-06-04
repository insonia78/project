package com.perscholas.springdatajpa.repository;

import java.util.List;
import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.perscholas.springdatajpa.models.Employee;

@Repository
public interface EmployeeRepository extends JpaRepository<Employee, Integer> {
	List<Employee> findAll();
	Optional<Employee> findById(Long id);
	List<Employee> findByFirstNameAndLastName(String firstName, String lastName);
	List<Employee> findByDepartmentNameAndAgeLessThanOrderByDateOfJoiningDesc(
			String departmentName, int maxAge);
}