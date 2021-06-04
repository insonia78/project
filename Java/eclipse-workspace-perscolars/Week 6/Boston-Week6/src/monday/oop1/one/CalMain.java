package monday.oop1.one;

public class CalMain {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		
		Calculator cal = new Calculator();
		Multiplier mul = new Multiplier();
		
		System.out.println("Calculator Object");
		cal.add(5, 7);
		cal.substract(10, 4);
		
		System.out.println("Multiply Object");
		mul.add(5,7);
		mul.substract(10, 4);
		mul.multiply(5, 5);
		mul.divide(10, 2);
		
		
		
		Calculator cal2 = new Multiplier();
		cal2.add(5,7);
		cal2.substract(10, 4);
		
		System.out.println("NewMultiplier Object");
		NewMultiplier newmul = new NewMultiplier();
		
		newmul.add(20, 30);
	}

}
