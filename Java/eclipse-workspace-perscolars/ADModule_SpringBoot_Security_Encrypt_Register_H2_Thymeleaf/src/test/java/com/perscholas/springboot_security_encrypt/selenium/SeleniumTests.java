package com.perscholas.springboot_security_encrypt.selenium;

import static org.junit.jupiter.api.Assertions.assertEquals;

import org.junit.jupiter.api.Test;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

@SpringBootTest
class SeleniumTests {
	
	@Autowired
	private WebDriver driver;
	
	@Test
	void testLoginPage() {
		// Opens the login page for this web application
		driver.get("http://localhost:8080/");
		assertEquals("Login Page", driver.getTitle());
	}
	
	@Test
	void testLoginInput() {
		driver.get("http://localhost:8080/");
		// Locate username field by CSS selector and input "Joan"
		WebElement usernameField = driver.findElement(By.name("username"));
		usernameField.sendKeys("Joan");
		// Locate password field by CSS selector and input "joan1234"
		WebElement passwordField = driver.findElement(By.name("password"));
		passwordField.sendKeys("joan1234");
		// Click the submit button
		driver.findElement(By.cssSelector("body > form > div:nth-child(3) > input[type=submit]")).click();
		
		// Welcome page should be displayed - test welcome message
		WebElement welcomeMessage = driver.findElement(By.cssSelector("body > h2"));
		assertEquals(welcomeMessage.getText(), "Welcome Joan");
		
		/* Thread sleep is optional and is to allow visual inspection of final 
		 * state of browser. */
		try {
			Thread.sleep(3000);
		} catch (InterruptedException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
}