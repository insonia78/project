package com.perscholas.jpa_orm_lesson.app;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

import com.perscholas.jpa_orm_lesson.models.NonTeachingStaff;
import com.perscholas.jpa_orm_lesson.models.TeachingStaff;

public class StaffApp {
	
	public static void main(String[] args) {
		EntityManagerFactory factory  = Persistence.createEntityManagerFactory("Inheritance Test");
		EntityManager manager = factory.createEntityManager();
		manager.getTransaction().begin();
		
		TeachingStaff ts = new TeachingStaff(1, "Mike", "Something", "Computer");
		NonTeachingStaff ns = new NonTeachingStaff(2, "Zamira", "Finding people jobs");
		
		manager.persist(ts);
		manager.persist(ns);
		
		manager.getTransaction().commit();
		manager.close();
		factory.close();
	}
}
