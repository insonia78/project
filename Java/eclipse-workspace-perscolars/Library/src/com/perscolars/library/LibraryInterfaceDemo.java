package com.perscolars.library;

public class LibraryInterfaceDemo {

	public static void main(String[] args) {
		
		// TODO Auto-generated method stub
		KidUsers k = new KidUsers();
		k.setAge(10);
		k.setBookType("Kids");
		KidUsers ki = new KidUsers();
		ki.setAge(18);
		ki.setBookType("Fiction");
		AdultUsers ad = new AdultUsers();
		ad.setAge(5);
		ad.setBookType("Kids");
		AdultUsers a = new AdultUsers();
		a.setAge(23);
		a.setBookType("Fiction");

	}

}
