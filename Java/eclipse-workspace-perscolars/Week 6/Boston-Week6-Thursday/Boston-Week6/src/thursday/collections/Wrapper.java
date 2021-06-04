package thursday.collections;

public class Wrapper<T> {
	
		private T t;
		private int accessCount;
		public Wrapper(T t) {
			
			this.t = t;
		}
		
		public T getValue() {
			accessCount++;
			return t;
		}
	
			
}
