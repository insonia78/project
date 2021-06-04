package com.perscholas.springdatajpa;

import java.time.LocalDate;

import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;

import com.perscholas.springdatajpa.models.Address;
import com.perscholas.springdatajpa.models.Employee;
import com.perscholas.springdatajpa.repository.AddressRepository;
import com.perscholas.springdatajpa.repository.EmployeeRepository;

@SpringBootApplication
public class AdModuleSpringBootSpringDataJpaExercisesApplication {

	public static void main(String[] args) {
		SpringApplication.run(AdModuleSpringBootSpringDataJpaExercisesApplication.class, args);
	}

	@Bean
	public CommandLineRunner insertEmployeeRecords(EmployeeRepository empRepository, AddressRepository addRepository) {
		return args -> {
			Employee emp1 = new Employee("John", "Doe", 25, "Marketing", LocalDate.of(2015, 12, 15));
			Address add1 = new Address("123 Main St.", "Dallas", "TX", "75201");
			emp1.setAddress(add1);
			add1.setEmployee(emp1);
			empRepository.save(emp1);

			Employee emp2 = new Employee("Jane", "Doe", 25, "Quality Engineering", LocalDate.of(2012, 6, 5),
					new Address("123 First St.", "Dallas", "TX", "75201"));
			emp2.getAddress().setEmployee(emp2);
			empRepository.save(emp2);

			Employee emp3 = new Employee("Jeff", "Doe", 28, "User Experience", LocalDate.of(2014, 2, 20),
					new Address("321 Second Ave.", "Irving", "TX", "75000"));
			emp3.getAddress().setEmployee(emp3);
			empRepository.save(emp3);

			Employee emp4 = new Employee("John", "Smith", 25, "Account Management", LocalDate.of(2016, 3, 3),
					new Address("321 Second Ave.", "Irving", "TX", "75000"));
			emp4.getAddress().setEmployee(emp4);
			empRepository.save(emp4);
		};
	}

}
