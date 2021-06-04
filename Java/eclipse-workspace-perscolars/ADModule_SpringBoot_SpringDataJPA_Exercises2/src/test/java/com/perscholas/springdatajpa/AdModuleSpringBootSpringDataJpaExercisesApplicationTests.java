package com.perscholas.springdatajpa;

import static org.assertj.core.api.Assertions.assertThat;

import java.util.List;

import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

import com.perscholas.springdatajpa.controller.HomeController;
import com.perscholas.springdatajpa.models.Employee;
import com.perscholas.springdatajpa.repository.EmployeeRepository;

@SpringBootTest
class AdModuleSpringBootSpringDataJpaExercisesApplicationTests {

	@Autowired
	private EmployeeRepository empRepository;
	@Autowired
	private HomeController homeController;
	
	@Test
	void contextLoads() {
		assertThat(homeController).isNotNull();
	}
	
	@Test
	public void testFindByAddressZipcode() {
		List<Employee> actual = empRepository.findByAddressZipcode("75201");
		assertThat(actual.size()).isEqualTo(2);
		assertThat(actual.get(0).getFirstName()).isEqualTo("John");
		assertThat(actual.get(0).getId()).isEqualTo(1);
		assertThat(actual.get(1).getId()).isEqualTo(2);
	}
	
	@Test
	public void testFindByNameAndAddressZipcode() {
		List<Employee> actual = empRepository.findByFirstNameAndAddressZipcode(
				"John", "75000");
		assertThat(actual.get(0).getLastName()).isEqualTo("Smith");
	}
	
	@Test
	public void testFindByFirstName() {
		Employee actual = empRepository.findByFirstName("Jane");
		assertThat(actual.getAddress().getStreetAddress()).isEqualTo(
				"123 First St.");
	}
	
	@Test
	public void testFindByFirstNameEndsWith() {
		List<Employee> actual = empRepository.findByFirstNameEndsWith("ff");
		assertThat(actual.get(0).getFirstName()).isEqualTo("Jeff");
	}
	
//	@Test
//	public void testFindByLastName() {
//		Employee actual = empRepository.findByLastName("Smith");
//		assertThat(actual.getDepartmentName()).isEqualTo("Account Management");
//	}
	
	@Test
	public void testFindByLastnameOrFirstname() {
		List<Employee> actual = empRepository.findByLastnameOrFirstname("Jane", "Doe");
		assertThat(actual.size()).isEqualTo(3);
	}
	
}
