package lambaexamples;

import java.util.function.*;

public class main {

	public main() {
		function(3);
		predicate();
		unaryOperator();
		binaryOperator();
	}
	private void binaryOperator() {
		// TODO Auto-generated method stub
		BinaryOperator<Integer> a = (Integer b,Integer c) ->{ 
			return (b + c);};
		System.out.println(a.apply(5, 3));	
			
		
	}
	private void unaryOperator() {
		// TODO Auto-generated method stub
		UnaryOperator<String> a = (String p) ->{
			return p.toUpperCase();
			
		};
		System.out.println(a.apply("thomas"));
	}
	private void predicate() {
		// TODO Auto-generated method stub
		Predicate a = (b) -> b != null;
		System.out.println(a.test("Thomas"));
	}
	private void function(Integer b) {
		// TODO Auto-generated method stub
		Function<String,String> a =(n)-> n + n;
		System.out.println(a.apply("Thomas"));		 
	}
	
	public static void main(String[] args) {
		// TODO Auto-generated method stub
          new main();  
	}

}
