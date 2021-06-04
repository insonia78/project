package org.perscholas.simplespringapp.controllers;

import javax.servlet.http.HttpSession;
import javax.validation.Valid;

import org.perscholas.simplespringapp.models.User;
import org.springframework.stereotype.Controller;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.WebDataBinder;
import org.springframework.web.bind.annotation.InitBinder;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.config.annotation.EnableWebMvc;

@Controller
@RequestMapping("/")
@EnableWebMvc
public class IndexController {
	
	@RequestMapping("/")
	public ModelAndView index() {
		ModelAndView mav = new ModelAndView("index");
		User newUser = new User();
		mav.addObject("newUser", newUser);
		return mav;
	}
	
	@RequestMapping(value="/userInfo", method=RequestMethod.POST)
	public ModelAndView userInfo(@Valid @ModelAttribute("newUser") User newUser,
			BindingResult result) {
		if (result.hasErrors()) {
			ModelAndView mavError = new ModelAndView("index");
			return mavError;
		}
		ModelAndView mav = new ModelAndView("user_page");
		mav.addObject("newUser", newUser);
		return mav;
	}
	
	@RequestMapping(value="/userInfoConfirm", method=RequestMethod.POST)
	public ModelAndView userInfoConfirm(@ModelAttribute("newUser") User newUser,
			BindingResult result) {
		ModelAndView mav = new ModelAndView("user_account_page");
		mav.addObject("newUser", newUser);
		return mav;
	}
	
	@RequestMapping("/loginForm")
	public ModelAndView loginForm() {
		ModelAndView mav = new ModelAndView("login_form");
		return mav;
	}
	
	@RequestMapping("/login")
	public String loginUser(@RequestParam("email") String email,
			@RequestParam("password") String password,
			HttpSession session) {
		if (password.equals("john1234")) {
			User currentUser = new User();
			currentUser.setUsername("John");
			currentUser.setEmail("john@doe.com");
			currentUser.setPassword("john1234");
			session.setAttribute("currentUser", currentUser);
			return "redirect:/welcome";
		}
		return "forward:/loginForm";
	}
	
	@RequestMapping("/welcome")
	public String welcomePage() {
		return "welcome";
	}
	
	@RequestMapping("/logout")
	public String logout(HttpSession session) {
		session.invalidate();
		return "forward:/loginForm";
	}
	
	@InitBinder
	public void initBinder(WebDataBinder binder) {
		binder.setDisallowedFields(new String[] {"password"});
	}
}