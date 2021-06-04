package org.perscholas.securitydemo.controller;

import java.util.List;
import java.util.Optional;

import javax.validation.Valid;

import org.perscholas.securitydemo.models.Course;
import org.perscholas.securitydemo.models.User;
import org.perscholas.securitydemo.service.CourseService;
import org.perscholas.securitydemo.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;





@Controller
public class UserCon {

	@Autowired
	UserService userService;
	@Autowired
	CourseService courseService;

	@RequestMapping("/")
	public String listUsers(Model modelUser) {
		String encoded = new BCryptPasswordEncoder().encode("admin");
System.out.println(encoded);
		// list of users available
		List<User> listUser = userService.findAll();
		
		modelUser.addAttribute("listUser", listUser);
		// list of course available
		List<Course> listCourse = courseService.findAll();
		modelUser.addAttribute("listCourse", listCourse);
		
		
		return "/index";
	}
	// for the custom login page container
		@GetMapping("/login")
		public String showLogin() {
			
			
			return "login";
		}
		@GetMapping("/home")
		public String showHome() {
			
			return "home";
		}
		@GetMapping("/accessdenied")
		public String accessdenied() {
			
			return "accessdenied";
		}
		@GetMapping("/newuser")
		public String adduser(Model modelUsers) {
			// object of Users
			User newUser = new User();
			
			
			// container for new user
			modelUsers.addAttribute("newUser", newUser);
			
			return "newuser";
		}
		
		@PostMapping("saveuser")
		public String saveUser(@Valid @ModelAttribute("newUser") User newUser, BindingResult bind) {
		//newUser.toString();
		
				userService.save(newUser);
			
			return "redirect:/";
		}

		
		
}
