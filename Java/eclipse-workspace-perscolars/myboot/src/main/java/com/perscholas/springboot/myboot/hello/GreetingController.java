package com.perscholas.springboot.myboot.hello;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class GreetingController {

	@GetMapping("/greeting")
	public String greeting() {
		return "Hello from my first Spring Boot application!";
	}
}