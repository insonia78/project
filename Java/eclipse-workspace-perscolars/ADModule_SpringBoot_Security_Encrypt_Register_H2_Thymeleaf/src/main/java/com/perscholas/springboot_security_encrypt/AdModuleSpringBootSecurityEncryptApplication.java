package com.perscholas.springboot_security_encrypt;

import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;

import com.perscholas.springboot_security_encrypt.models.User;
import com.perscholas.springboot_security_encrypt.services.UserService;

@SpringBootApplication
public class AdModuleSpringBootSecurityEncryptApplication {

	public static void main(String[] args) {
		SpringApplication.run(AdModuleSpringBootSecurityEncryptApplication.class, args);
	}

	@Bean
	public CommandLineRunner insertEmployeeRecords(UserService userService) {
		return args -> {
			// Save two standard users (ROLE_USER)
			userService.save(new User("John", "john1234"));
			userService.save(new User("Jane", "jane1234"));
			
			// Save two admin users (ROLE_ADMIN)
			User user = null;
			user = new User("Joan", "joan1234");
			user.setUserRole("ROLE_ADMIN");
			userService.save(user);
			user = new User("James", "james1234");
			user.setUserRole("ROLE_ADMIN");
			userService.save(user);		};
	}
}
