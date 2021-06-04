package com.perscholas.springdatajpa.repository;

import java.util.List;
import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import com.perscholas.springdatajpa.models.Employee;

@Repository
public interface EmployeeRepository extends JpaRepository<Employee, Long> {
	List<Employee> findAll();
	Optional<Employee> findById(Long id);
	List<Employee> findByFirstNameAndLastName(String firstName, String lastName);
	List<Employee> findByDepartmentNameAndAgeLessThanOrderByDateOfJoiningDesc(
			String departmentName, int maxAge);
	
	List<Employee> findByAddressZipcode(String zipcode);
	List<Employee> findByFirstNameAndAddressZipcode(String firstName, String zipcode);
	
	@Query("select e from Employee e where e.firstName = ?1")
	Employee findByFirstName(String firstName);
	
	@Query("select e from Employee e where e.firstName like %?1")
	List<Employee> findByFirstNameEndsWith(String subString);
	
	@Query(value = "SELECT * FROM employees WHERE lastname = ?1", nativeQuery = true)
	Employee findByLastName(String lastName);
	
	@Query("select e from Employee e where e.firstName = :firstName or e.lastName = :lastName")
	List<Employee> findByLastnameOrFirstname(@Param("firstName") String firstName, @Param("lastName") String lastName);

}