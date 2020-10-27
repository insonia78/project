package com.example.datingSite.configuration;

// import com.example.springsocial.security.*;
// import com.example.springsocial.security.oauth2.CustomOAuth2UserService;
// import com.example.springsocial.security.oauth2.HttpCookieOAuth2AuthorizationRequestRepository;
// import com.example.springsocial.security.oauth2.OAuth2AuthenticationFailureHandler;
// import com.example.springsocial.security.oauth2.OAuth2AuthenticationSuccessHandler;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.core.env.Environment;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.config.BeanIds;
import org.springframework.security.config.annotation.authentication.builders.AuthenticationManagerBuilder;
import org.springframework.security.config.annotation.method.configuration.EnableGlobalMethodSecurity;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.config.annotation.web.configuration.EnableWebSecurity;
import org.springframework.security.config.annotation.web.configuration.WebSecurityConfigurerAdapter;
import org.springframework.security.config.http.SessionCreationPolicy;
import org.springframework.security.config.oauth2.client.CommonOAuth2Provider;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.security.oauth2.client.registration.ClientRegistration;
import org.springframework.security.oauth2.client.web.AuthorizationRequestRepository;
import org.springframework.security.oauth2.client.web.HttpSessionOAuth2AuthorizationRequestRepository;
import org.springframework.security.oauth2.core.endpoint.OAuth2AuthorizationRequest;
import org.springframework.security.web.authentication.UsernamePasswordAuthenticationFilter;

// @Configuration
// public class SecurityConfig extends WebSecurityConfigurerAdapter {

//     @Override
//     protected void configure(HttpSecurity http) throws Exception {
//         http.authorizeRequests().anyRequest().authenticated().and().oauth2Login();
//     }

//     private static String CLIENT_PROPERTY_KEY = "spring.security.oauth2.client.registration.";

//     @Bean
//     public HttpSessionOAuth2AuthorizationRequestRepository cookieAuthorizationRequestRepository() {
//       return new HttpSessionOAuth2AuthorizationRequestRepository();
//   }
//   @Bean(BeanIds.AUTHENTICATION_MANAGER)
//     @Override
//     public AuthenticationManager authenticationManagerBean() throws Exception {
//         return super.authenticationManagerBean();
//     }
//   @Bean
//   public PasswordEncoder passwordEncoder() {
//       return new BCryptPasswordEncoder();
//   }  
 




// }