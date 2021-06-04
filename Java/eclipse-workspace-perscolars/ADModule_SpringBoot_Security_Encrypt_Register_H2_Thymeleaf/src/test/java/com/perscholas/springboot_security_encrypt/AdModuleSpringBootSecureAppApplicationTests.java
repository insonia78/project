package com.perscholas.springboot_security_encrypt;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertNotNull;

import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.security.crypto.password.PasswordEncoder;

import com.perscholas.springboot_security_encrypt.controllers.HomeController;
import com.perscholas.springboot_security_encrypt.models.User;
import com.perscholas.springboot_security_encrypt.services.UserService;

@SpringBootTest
class AdModuleSpringBootSecureAppApplicationTests {

	HomeController homeController;
	UserService userService;
	PasswordEncoder pswdEncoder;
	
	@Autowired
	public AdModuleSpringBootSecureAppApplicationTests(
			HomeController homeController, UserService userService,
			PasswordEncoder pswdEncoder) {
		this.homeController = homeController;
		this.userService = userService;
		this.pswdEncoder = pswdEncoder;
	}
	
	@Test
	void contextLoads() {
		assertNotNull(homeController);
	}
	
	@Test
	void testFindUserById() {
		User user = userService.findById(1);
		assertEquals("John", user.getUsername());
		assertEquals("ROLE_USER", user.getUserRole());
	}
}
