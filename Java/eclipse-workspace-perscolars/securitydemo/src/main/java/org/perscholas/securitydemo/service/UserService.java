package org.perscholas.securitydemo.service;

import java.util.List;


import org.perscholas.securitydemo.dao.IUserRepo;
import org.perscholas.securitydemo.models.User;
import org.perscholas.securitydemo.security.SecurityConfiguration;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;


@Service
public class UserService{

	@Autowired
	IUserRepo userRepo;
	
	
	public List<User> findAll() {

		return userRepo.findAll();
	}
	
	public User findById(Integer id) {

		return userRepo.findById(id).get();

	}
	public boolean existsById(Integer id) {

		return userRepo.existsById(id);
	}
	
	public void deleteById(Integer id) {

		if (existsById(id))
			userRepo.deleteById(id);

	}
	public void save(User user) {
		user.setuPassword(SecurityConfiguration.passwordEncoder().encode(user.getuPassword()));
		userRepo.save(user);
	

	}
	
}
