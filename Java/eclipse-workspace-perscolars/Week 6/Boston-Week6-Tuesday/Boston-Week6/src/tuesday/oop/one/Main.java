package tuesday.oop.one;

public class Main {

	public static void main(String[] args) {

		// Generic
		Box<Integer> intBox = new Box<Integer>();

		intBox.add(12);
		intBox.add(24);
		intBox.add(42);
		intBox.add(45);
		
		System.out.println(intBox.get());

		// Variable Arguments (method below)
		printLines(1, 3, 6, 8, 9, 7);

		// Enumerations
		Days.getDay(Days.MONDAY);
		Days day = Days.SATURDAY;
		System.out.println(day + " is day number " + day.getDay());

		// Nested Class (Static)
		Nested.InnerClass.hello();

		// Nested Class(Non-Static)
		Nested n = new Nested();
		Nested.InnerClass2 ni = n.new InnerClass2();
		ni.hello();

	} // main method ends

	public static void printLines(int... a) {
		for (int i : a)
			System.out.print(i + " ");
	}

} // class ends
