package com.perscholas.springdatajpa;

import static org.assertj.core.api.Assertions.assertThat;

import java.time.LocalDate;
import java.util.List;

import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

import com.perscholas.springdatajpa.controller.HomeController;
import com.perscholas.springdatajpa.models.Book;
import com.perscholas.springdatajpa.models.Employee;
import com.perscholas.springdatajpa.repository.BookRepository;
import com.perscholas.springdatajpa.repository.EmployeeRepository;

@SpringBootTest
class AdModuleSpringBootSpringDataJpaExercisesApplicationTests {

	@Autowired
	private BookRepository bookRepository;
	@Autowired
	private EmployeeRepository empRepository;
	@Autowired
	private HomeController homeController;
	
	@Test
	void contextLoads() {
		assertThat(homeController).isNotNull();
	}
	
	@Test
	public void testFindBookByTitle() {
		Book foundBook = bookRepository.findByTitle("A Christmas Carol");
		assertThat(foundBook.getAuthor()).isEqualTo("Charles Dickens");
	}
	
	@Test
	public void testFindBookById() {
		assertThat(bookRepository.findById(2L).getTitle()).isEqualTo(
				"The Legend of Sleepy Hallow");
	}
	
	@Test
	public void testFindAllEmployees() {
		Employee expected = new Employee("John", "Doe", 25, 
				"Marketing", LocalDate.of(2015, 12, 15));
		expected.setId(1L);
		
		List<Employee> empList = empRepository.findAll();
		assertThat(empList).contains(expected);
	}
	
	@Test
	public void testFindBookByFirstNameAndLastName() {
		List<Employee> empList = empRepository.findByFirstNameAndLastName("Jane", "Doe");
		assertThat(empList.get(0).getDepartmentName()).isEqualTo("Quality Engineering");
	}
	
	@Test
	public void testFindByDepartmentNameAndAgeLessThan() {
		List<Employee> empList = empRepository.findByDepartmentNameAndAgeLessThanOrderByDateOfJoiningDesc("Data Science", 29);
		assertThat(empList.size()).isEqualTo(3);
	}
	
}
