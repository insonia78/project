package org.perscholas.securitydemo.security;

import java.util.Arrays;
import java.util.Collection;
import java.util.Date;
import java.util.List;
import java.util.stream.Collectors;

import org.perscholas.securitydemo.models.User;
import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.authority.SimpleGrantedAuthority;
import org.springframework.security.core.userdetails.UserDetails;



public class MyUserDetails implements UserDetails{

	/*
	 * Implementing methods from user details 
	 */
	private static final long serialVersionUID = 1L;


	private String uEmail;
	private String uPassword;
	private String uRole;
	private Boolean uEnabled;
	private List<GrantedAuthority> authorities;
	

	
	public MyUserDetails(User user) {
	this.uID = user.getuID();
	this.uName=user.getuName();
	this.uEmail=user.getuEmail();
	this.uPassword=user.getuPassword();
	this.uRole=user.getuRole();
	this.uEnabled=user.getuEnabled();
	this.authorities = Arrays.stream(user.getuRole().split(","))
				.map(SimpleGrantedAuthority::new)
				.collect(Collectors.toList());
	}



	@Override
	public Collection<? extends GrantedAuthority> getAuthorities() {
		
		System.out.println(authorities);
		return authorities;
	}



	@Override
	public String getPassword() {
		// TODO Auto-generated method stub
		return uPassword;
	}



	@Override
	public String getUsername() {
		// TODO Auto-generated method stub
		return uEmail;
	}



	@Override
	public boolean isAccountNonExpired() {
		// TODO Auto-generated method stub
		return true;
	}



	@Override
	public boolean isAccountNonLocked() {
		// TODO Auto-generated method stub
		return true;
	}



	@Override
	public boolean isCredentialsNonExpired() {
		// TODO Auto-generated method stub
		return true;
	}



	@Override
	public boolean isEnabled() {
		// TODO Auto-generated method stub
		return true;
	}

}