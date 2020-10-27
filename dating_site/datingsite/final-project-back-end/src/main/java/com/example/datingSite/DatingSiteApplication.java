package com.example.datingSite;



import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

import org.springframework.context.annotation.Bean;
import org.springframework.web.servlet.config.annotation.CorsRegistry;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurer;

@SpringBootApplication
//@Import({ CORSFilter.class, SpringWebSecurityConfiguration.class })
public class DatingSiteApplication {

	

	public static void main(String[] args) {
		SpringApplication.run(DatingSiteApplication.class, args);
	}
    // @Bean
	// public WebMvcConfigurer corsConfigurer() {
	// 	System.out.println("hello");
	// 	return new WebMvcConfigurer() {
	// 		@Override
	// 		public void addCorsMappings(CorsRegistry registry) {
	// 			registry.addMapping("/graphql").allowedOrigins("*");
	// 		}
	// 	};
	// }
	
}
