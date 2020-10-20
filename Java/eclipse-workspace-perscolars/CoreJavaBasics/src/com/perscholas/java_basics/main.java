/**
 * 
 */
package com.perscholas.java_basics;

/**
 * @author tomsa
 *
 */
public class main {

	/**
	 * @param args
	 * @param SumToIntegers 
	 */
	public static void main(String[] args) {
		// TODO Auto-generated method stub
          SumToIntegers(3,4);
          SumToDouble((double)3,(double)4);
          SumToIntegerDouble((int)3,(double)4);
          DivideTwoIntegers(5,6);
          CastingAInteger(5,6);
          NameAConstant(4);
          atACafe();
          
	}

	
	private static void atACafe() {
		// TODO Auto-generated method stub
		System.out.println("atACafe");
		double coffee = 1,
		       cappuccino = 1,
		       espresso = 1;
		double subtotal,
		       totalSale;
		
		subtotal =  coffee * 3;
		subtotal += cappuccino * 4;
		subtotal += espresso * 2;
		final double SALES_TAX = 0.2;
		totalSale = subtotal * SALES_TAX;
		System.out.format("%.2f", totalSale);
	}


	private static void NameAConstant(final int a) {
		System.out.println("NameAConstant");		
		// TODO Auto-generated method stub
		System.out.println(a + 5);
	}

	private static void CastingAInteger(int i, int j) {
		// TODO Auto-generated method stub
		System.out.println("CastingAInteger");
		int x = i, y = j ;
		double q = y/x;
		System.out.println(q);
		q = (double)y/x; 
		System.out.println(q);
		
	}

	private static void DivideTwoIntegers(int i, int j) {
		System.out.println("DivideTwoIntegers");
		// TODO Auto-generated method stub
		double divideResult = j/i;
		System.out.println(divideResult);
		divideResult = i/j;
		System.out.println(divideResult);
		
	}

	private static void SumToIntegerDouble(int i, double d) {
		System.out.println("SumToIntegerDouble");
		// TODO Auto-generated method stub
		double sum = i + d;
		System.out.println(sum);
		
	}

	private static void SumToDouble(double d, double e) {
		System.out.println("SumToDouble");
		// TODO Auto-generated method stub
		double sum = d + e;
		System.out.println(sum);
	}

	private static void SumToIntegers(int i, int j) {
		System.out.println("SumToIntegers");
		// TODO Auto-generated method stub
		int sum = i + j;
		System.out.println(sum);
	}
    
}
