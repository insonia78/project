package monday;

public class Slide16ThreadLocal implements Runnable {
	public static final ThreadLocal<Integer> localInt = new ThreadLocal<Integer>();
	private final Integer val;
	
	public Slide16ThreadLocal(Integer val) {
		this.val = val;
	}
	
	public void run() {
		/* ThreadLocal set() method is called on localInt instance thereby setting the value to 
		 * this.val. This value will not be accessible by any other threads other than the current 
		 * thread. */
		localInt.set(this.val);
		Integer i = localInt.get();
		System.out.println(Thread.currentThread().getName() + ": " + i);
		/* The remove method will clean up the ThreadLocal instance's value which can prevent 
		 * memory leak issues. */
		localInt.remove();
	}
	
	public static void main(String[] args) {
		Thread[] threads = new Thread[5];
		for (int i = 0; i < 5; i++) {
			// variable "i" is passed to Slide16LocalTest constructor
			threads[i] = new Thread(new Slide16ThreadLocal(i), "thread-" + i);
			threads[i].start();
		}
	}
}
