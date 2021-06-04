package org.perscholas.securitydemo.dao;

import java.util.Optional;

import org.perscholas.securitydemo.models.User;
import org.springframework.data.jpa.repository.JpaRepository;



public interface IUserRepo extends JpaRepository<User, Integer> {
	Optional<User> findByuEmail(String userEmail);
}
