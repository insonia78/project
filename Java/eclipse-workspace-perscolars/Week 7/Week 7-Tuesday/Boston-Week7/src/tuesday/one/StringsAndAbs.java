package tuesday.one;

import java.util.StringJoiner;

public class StringsAndAbs {
	@FunctionalInterface
	interface Square {
		//abstract method
		int calculate(int x);
		//default method
		default void show() {
			System.out.println("Default Method Executed");
		}
		
	}

	public static void main(String[] args) {

		// Slide 5
		StringBuffer str = new StringBuffer("Per Scholas");
		int len = str.length();
		int capt = str.capacity();
		System.out.println("Length = " + len);
		System.out.println("Capacity = " + capt);

		str.append(" Platform");
		System.out.println(str);
		str.append(1);
		System.out.println(str);
		str.insert(4, "for ");
		System.out.println(str);
		str.insert(0, 5);
		System.out.println(str);
		str.insert(3, true);
		System.out.println(str);
		char geek_arr[] = { 'b', 'y' };
		str.insert(2, geek_arr);
		System.out.println(str);
		System.out.println("**********");

		// Slide 7

		StringJoiner joinNames = new StringJoiner(",", "[", "]");
		// Adding values to StringJoiner
		joinNames.add("Rahul");
		joinNames.add("Raju");

		// Creating StringJoiner with :(colon) delimiter

		StringJoiner joinNames2 = new StringJoiner(":", "[", "]");
		// adding values to StringJoiner

		joinNames2.add("Peter");
		joinNames2.add("Raheem");

		// Merging two StringJoiner
		StringJoiner merge = joinNames.merge(joinNames2);
		System.out.println(merge);

		// Slide 10
		int a = 5;
		// lambda expression to define the calculate method
		Square s = (int x) -> x * x;
		// parameter passed and return type must be
		// same as defined in the prototype
		int ans = s.calculate(a);
		System.out.println(ans);
		s.show();
		System.out.println("**********");
		
		//Slide 15
		
		InterfaceGeneric<Integer> nums = new InterfaceGeneric<Integer>() {
		@Override
		public Integer compare(Integer o1,Integer o2) {
			if(o1>o2) {
				return o1;
			}else {
				return o2;
			}
		}
		};
			
		int max = nums.compare(13, 9);
		System.out.println(max);
		System.out.println("**********");

	}//main

}// class
