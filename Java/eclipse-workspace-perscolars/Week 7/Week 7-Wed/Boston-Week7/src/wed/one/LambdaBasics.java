package wed.one;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.stream.IntStream;
import java.util.stream.Stream;

public class LambdaBasics {

	@FunctionalInterface
	public interface MyFunctionalInterface{
		public String sayHello();
	}
	@FunctionalInterface
	public interface MyFunctionalInterface2{
		public int incrementByFive(int a);
	}
	
	
	public interface StringConcat{
		public String sconcat(String a, String b);
		}
	
	public interface ComparatorInterface{
		public String comparator(String str);
	}
	
	public static void main(String[] args) {
		
		//first func
		MyFunctionalInterface msg = () -> {
			return "Hello";
		};
		System.out.println(msg.sayHello());
		
		System.out.println("********");

		//second func
		MyFunctionalInterface2 f = (num) -> num+5;
		System.out.println(f.incrementByFive(22));
		System.out.println("********");

		//third func
		//lambda expression
		StringConcat s = (str1,str2) -> str1+str2;
		System.out.println("Result: "+ s.sconcat("Hello", "Boston Team"));
		System.out.println("********");

		//Generator
		
		ComparatorInterface reverser_space = (str)  ->{
			String sub_str = "";
			for(int i = str.length()-1;i >=0;i--) {
				sub_str +=str.charAt(i);
			}
			return sub_str;
			
		};
		
		ComparatorInterface normal_noSpace = (str) ->{
		String sub_str="";
		
		for(int i =0;i<str.length();i++) {
			String ss = Character.toString(str.charAt(i));
			if(!ss.equals(" ")) {
				sub_str +=ss;
			}
		}
		return sub_str;
		};
		System.out.println(reverser_space.comparator("Hello class of JD"));
		System.out.println(normal_noSpace.comparator("Hello class of JD"));

		System.out.println("********");

		// LambdaConsumer
		List<String> names = new ArrayList<String>();
		names.add("Larry");
		names.add("Steve");
		names.add("James");
		names.add("Conan");
		names.add("Ellen");


		names.forEach(name ->{
			System.out.println(name);
		});
		System.out.println("********");

		names.stream().forEach(name ->{
			System.out.println(name);
		});
		System.out.println("********");
		names.stream()
		.filter(sss->sss.startsWith("C")||sss.startsWith("S"))
		.map(String::toUpperCase)
		.sorted().forEach(sss->{
		System.out.println(sss);
		});
		System.out.println("********");
		//Stream.of
		
		Stream.of("a1","a2","a3")
		.findFirst()
		.ifPresent(x->System.out.println(x));
		
		System.out.println("********");
		//Slide 18
		
		Stream.of("d2","a2","b1","b3","c")
		.filter(b->{
			System.out.println("filter: "+b);
			return true;
		}).forEach(b->System.out.println("forEach: "+b));
		
		//Slide 22
		
		
	}//main
	//calculator
	public static Object CalExpression(String ex) {
		List<String> expression = Arrays.asList(ex.split(""));
		
		IntStream.range(0,expression.size()).forEach((s)->{
			System.out.println(s);
		});
		return null;
	}

}//class
