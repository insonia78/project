package com.perscholas.springboot_security_encrypt.controllers;

import java.util.Collection;

import javax.validation.Valid;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;

import com.perscholas.springboot_security_encrypt.models.User;
import com.perscholas.springboot_security_encrypt.services.UserService;

@Controller
public class HomeController {
	
	private UserService userService;
	
	@Autowired
	public HomeController(UserService userService) {
		this.userService = userService;
	}
	
	@RequestMapping("/")
	public String showHomePage(Model model) {
		// Get current user
		Object principal = SecurityContextHolder.getContext().getAuthentication().getPrincipal();
		
		// Print granted authorities for current user
		Collection<? extends GrantedAuthority> authorities = SecurityContextHolder.getContext().getAuthentication().getAuthorities();
		System.out.println(authorities);
		
		model.addAttribute("currentUser", ((UserDetails)principal).getUsername());
		return "HomePage";
	}
	
	@RequestMapping("/login")
	public String showLoginPage() {
		return "Login";
	}
	
	@RequestMapping("/register")
	public String showRegisterPage(Model model) {
		model.addAttribute("newUser", new User());
		return "register";
	}
	
	@PostMapping("/registerNewUser")
	public String registerNewUser(@Valid @ModelAttribute("newUser") User newUser, 
			BindingResult result) {
		System.out.println("Has Errors: " + result.hasErrors());
		if (result.hasErrors()) {
			return "register";
		}
		userService.save(newUser);
		return "redirect:/login";
	}
	
	@RequestMapping("/logout-success")
	public String showLogoutPage() {
		return "Logout";
	}
	
	@RequestMapping("/about")
	public String about() {
		return "about";
	}
	
	@RequestMapping("/admin")
	public String admin() {
		return "admin";
	}
	
	@RequestMapping("accessDenied")
	public String accessDenied() {
		return "access_denied";
	}
}