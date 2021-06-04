package org.perscholas.securitydemo;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;
import org.thymeleaf.extras.springsecurity4.dialect.SpringSecurityDialect;
import org.thymeleaf.spring5.SpringTemplateEngine;
import org.thymeleaf.templateresolver.ITemplateResolver;

@SpringBootApplication
public class SecurityDemoApplication {

	public static void main(String[] args) {
		SpringApplication.run(SecurityDemoApplication.class, args);
	}
	
	// enabling thymeleaf sec for view controlling and session information
		@Bean
		public SpringTemplateEngine templateEngine(ITemplateResolver templateResolver, SpringSecurityDialect sec) {
			final SpringTemplateEngine templateEngine = new SpringTemplateEngine();
			templateEngine.setTemplateResolver(templateResolver);
			templateEngine.addDialect(sec); // Enable use of "sec"
			return templateEngine;
		}

		// enabling thymeleaf sec for view controlling and session information
		@Bean
		public SpringSecurityDialect securityDialect() {
			return new SpringSecurityDialect();
		}

}
