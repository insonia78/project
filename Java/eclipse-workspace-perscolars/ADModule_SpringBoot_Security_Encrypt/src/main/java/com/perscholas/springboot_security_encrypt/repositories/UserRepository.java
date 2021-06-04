package com.perscholas.springboot_security_encrypt.repositories;

import org.springframework.data.jpa.repository.JpaRepository;

import com.perscholas.springboot_security_encrypt.models.User;

public interface UserRepository extends JpaRepository<User, Integer> {
	User findByUsername(String username);
}
