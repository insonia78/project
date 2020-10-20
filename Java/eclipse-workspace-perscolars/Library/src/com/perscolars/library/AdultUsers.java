package com.perscolars.library;

public class AdultUsers implements LibraryUser{
	
	int age = 0;
	String bookType ="";
	public AdultUsers() {}
	
	public void registerAccount() 
	{
		if(age > 12)
		{
           System.out.println("You have successfully registered under a Adult Account"); 
		}
         if(age < 12)
         {
			System.out.println("Sorry,Age must be greater than 12 to refister as a adult");
         }
	
    }
	public void requestBook() 
	{
		if(bookType.equals("Fiction"))
		   System.out.println("Book Issued successfully, please return the book within 19days");
		else
			System.out.println("Oops, you are allowed to take only kids books");
	}
	public void setAge(int age)
	{
		this.age = age;
	}
	public void setBookType(String bookType)
	{
		this.bookType = bookType;
	}
}