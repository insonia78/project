package com.perscholas.jpa_orm_lesson.app;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import javax.persistence.Query;

import com.perscholas.jpa_orm_lesson.models.Department;
import com.perscholas.jpa_orm_lesson.models.Employee;
import com.perscholas.jpa_orm_lesson.services.DepartmentService;
import com.perscholas.jpa_orm_lesson.services.EmployeeService;

//import com.perscholas.jpa_orm_lesson.models.Employee;
//import com.perscholas.jpa_orm_lesson.services.EmployeeService;

public class EmployeeJpaApp {

	public static void main(String[] args) {
//		EmployeeService es = new EmployeeService();
//		Employee e = new Employee("Joan", 95000.00, "JD");
//		Integer id = es.createEmployee(e);
//		System.out.println(id);
		DepartmentService es = new DepartmentService();
		Department d = new Department("Joan", "MA");
		Integer id = es.createDepartment(d);
		System.out.println(id);
		
		
		EntityManagerFactory entityManagerFactory = Persistence.createEntityManagerFactory("JPA Test");
		EntityManager entityManager = entityManagerFactory.createEntityManager();
//		
//		Query query = entityManager.createQuery("select e from Employee e");
//		List<?> employees = query.getResultList();
//		
//		for (Object obj : employees) {
//			System.out.println(obj.toString());
//		}
//		
// 		Query query = entityManager.createQuery("SELECT e FROM Employee e WHERE e.eid = :id");
//		query = entityManager.createNamedQuery("Find Employee By ID");
//		query.setParameter("id",1);
//		List<?> employees = query.getResultList();
//		
//		employees.stream().forEach(System.out::println);
		
		Query query = entityManager.createQuery("SELECT d FROM Department d WHERE d.did = :id");
		//query = entityManager.createNamedQuery("Find Department By ID");
		query.setParameter("id",1);
		List<?> department = query.getResultList();
		
		department.stream().forEach(System.out::println);
		
	}

}
