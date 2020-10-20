package org.perscolars.junitbacics;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

public class JUnitBasicsApplication {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		EntityManagerFactory factory  = Persistence.createEntityManagerFactory("JUnitBacics");
		EntityManager manager = factory.createEntityManager();
		manager.getTransaction().begin();	
				
	}

}
