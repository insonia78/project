/**
 * 
 */
package org.perscholas.firstpackage;

/**
 * @author tomsa
 *
 */
public class main {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		System.out.println("this is a test");
		main m = new main();
		m.getGrade(100);
		m.getGrade(-100);
		m.getGrade(64);
		m.getGrade(70);
		

	}
	public void getGrade(int grade)
	{
		if(grade >= 90 && grade <= 100)
			System.out.println("A");
		else if (grade >= 80 && grade <= 89)
			System.out.println("B");
		else if (grade >= 70 && grade <= 79)
			System.out.println("C");
		else if (grade >= 65 && grade <= 69)
			System.out.println("D");
		else if(grade >= 0 && grade <= 64)
			System.out.println("F");
		else
			System.out.println("Invalid Entry");
	}

}
