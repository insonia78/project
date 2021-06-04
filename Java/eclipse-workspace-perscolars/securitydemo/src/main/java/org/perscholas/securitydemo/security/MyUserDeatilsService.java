package org.perscholas.securitydemo.security;

import java.util.Optional;

import org.perscholas.securitydemo.dao.IUserRepo;
import org.perscholas.securitydemo.models.User;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.stereotype.Service;


@Service
public class MyUserDeatilsService implements UserDetailsService {

	// created a query to find user by email
	@Autowired
	IUserRepo userRepo;

	@Override
	public UserDetails loadUserByUsername(String email) throws UsernameNotFoundException {
		// find if user exist
		Optional<User> user = userRepo.findByuEmail(email);
		// throw an error if not
		user.orElseThrow(() -> new UsernameNotFoundException("Not Found: " + email));
		// get me the user
		
		return user.map(MyUserDetails::new).get();
	}

}
