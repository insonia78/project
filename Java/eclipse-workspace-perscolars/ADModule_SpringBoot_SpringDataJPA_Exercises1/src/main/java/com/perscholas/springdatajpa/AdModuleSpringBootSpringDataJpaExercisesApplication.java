package com.perscholas.springdatajpa;

import java.time.LocalDate;

import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;

import com.perscholas.springdatajpa.models.Book;
import com.perscholas.springdatajpa.models.Employee;
import com.perscholas.springdatajpa.repository.BookRepository;
import com.perscholas.springdatajpa.repository.EmployeeRepository;

@SpringBootApplication
public class AdModuleSpringBootSpringDataJpaExercisesApplication {

	public static void main(String[] args) {
		SpringApplication.run(AdModuleSpringBootSpringDataJpaExercisesApplication.class, args);
	}
	
	@Bean
	public CommandLineRunner insertBookRecords(BookRepository bookRepository) {
		return args -> {
			bookRepository.save(new Book("A Christmas Carol", "Charles Dickens"));
			bookRepository.save(new Book("The Legend of Sleepy Hallow", "Washington Irving"));
			bookRepository.save(new Book("Alice's Adventures in Wonderland", "Lewis Carroll"));
			bookRepository.save(new Book("The Great Gatsby", "F. Scott Fitzgerald"));
			bookRepository.save(new Book("Moby Dick", "Ernest Hemmingway"));
		};
	}
	
	@Bean
	public CommandLineRunner insertEmployeeRecords(EmployeeRepository empRepository) {
		return args -> {
			empRepository.save(new Employee("John", "Doe", 25, "Marketing", LocalDate.of(2015, 12, 15)));
			empRepository.save(new Employee("Jane", "Doe", 25, "Quality Engineering", LocalDate.of(2012, 6, 5)));
			empRepository.save(new Employee("Jeff", "Doe", 28, "User Experience", LocalDate.of(2014, 2, 20)));
			empRepository.save(new Employee("Jennifer", "Doe", 23, "Data Science", LocalDate.of(2017, 8, 23)));
			empRepository.save(new Employee("Joan", "Doe", 24, "Data Science", LocalDate.of(2017, 7, 18)));
			empRepository.save(new Employee("Jerry", "Doe", 28, "Data Science", LocalDate.of(2017, 4, 12)));
			empRepository.save(new Employee("Jesse", "Doe", 30, "Data Science", LocalDate.of(2017, 11, 30)));

		};
	}

}
