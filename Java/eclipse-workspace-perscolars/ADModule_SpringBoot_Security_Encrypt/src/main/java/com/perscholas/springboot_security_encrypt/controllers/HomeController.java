package com.perscholas.springboot_security_encrypt.controllers;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;

@Controller
public class HomeController {
	@RequestMapping("/")
	public String showHomePage() {
		return "HomePage";
	}
	
	@RequestMapping("/login")
	public String showLoginPage() {
		return "Login";
	}
	
	@RequestMapping("/logout-success")
	public String showLogoutPage() {
		return "Logout";
	}
}
