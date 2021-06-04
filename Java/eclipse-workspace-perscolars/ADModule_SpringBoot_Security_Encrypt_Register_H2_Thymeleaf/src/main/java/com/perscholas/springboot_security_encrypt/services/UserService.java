package com.perscholas.springboot_security_encrypt.services;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Service;

import com.perscholas.springboot_security_encrypt.models.User;
import com.perscholas.springboot_security_encrypt.repositories.UserRepository;

@Service
public class UserService {
	
	private UserRepository userRepository;
	private PasswordEncoder pswdEncoder;
	
	@Autowired
	public UserService(UserRepository userRepository, PasswordEncoder pswdEncoder) {
		this.userRepository = userRepository;
		this.pswdEncoder = pswdEncoder;
	}
	
	public User save(User user) {
		user.setPassword(pswdEncoder.encode(user.getPassword()));
		return userRepository.save(user);
	}
	
	public User findById(Integer id) {
		return userRepository.findById(id).get();
	}
	public User findByUsername(String username) {
		return userRepository.findByUsername(username);
	}
}