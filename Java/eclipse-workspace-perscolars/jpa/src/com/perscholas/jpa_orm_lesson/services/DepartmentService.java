package com.perscholas.jpa_orm_lesson.services;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

import com.perscholas.jpa_orm_lesson.models.Department;

public class DepartmentService {
	
	public Integer createDepartment(Department newDepartment) {
		EntityManagerFactory entityManagerFactory = Persistence.createEntityManagerFactory("JPA Test");
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		entityManager.persist(newDepartment);
		entityManager.getTransaction().commit();
		entityManager.close();
		entityManagerFactory.close();
		return newDepartment.getDid();
	}
	
	public Department findDepartment(int eid) {
		EntityManagerFactory entityManagerFactory = Persistence.createEntityManagerFactory("JPA Test");
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		Department foundDepartment = entityManager.find(Department.class, eid);
		return foundDepartment;
	}
	
	public void updateDepartmentName(int eid, String newDname) {
		EntityManagerFactory entityManagerFactory = Persistence.createEntityManagerFactory("JPA Test");
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		Department foundDepartment = entityManager.find(Department.class, eid);
		foundDepartment.setDname(newDname);		
		entityManager.getTransaction().commit();
	}
	public void updateDepartmentState(int eid, String newState) {
		EntityManagerFactory entityManagerFactory = Persistence.createEntityManagerFactory("JPA Test");
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		Department foundDepartment = entityManager.find(Department.class, eid);
		foundDepartment.setDstate(newState);		
		entityManager.getTransaction().commit();
	}
	
	public void removeDepartment(int eid) {
		EntityManagerFactory entityManagerFactory = Persistence.createEntityManagerFactory("JPA Test");
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		Department foundDepartment = entityManager.find(Department.class, eid);
		entityManager.remove(foundDepartment);
		entityManager.getTransaction().commit();
	}

	

}
