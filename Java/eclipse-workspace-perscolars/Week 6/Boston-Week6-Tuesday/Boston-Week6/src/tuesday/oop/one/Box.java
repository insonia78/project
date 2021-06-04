package tuesday.oop.one;

import java.util.ArrayList;
import java.util.List;

public class Box <T>{

	
		
		List<T> values;
		
		public Box() {
			values = new ArrayList<T>();
		}
		
		public void add(T value) {
			values.add(value);
		
		}
		public List<T> get(){
			return values;
		}
}
