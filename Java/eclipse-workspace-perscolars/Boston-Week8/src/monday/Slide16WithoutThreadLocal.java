package monday;

public class Slide16WithoutThreadLocal implements Runnable {
	private Integer val;

	public Slide16WithoutThreadLocal(Integer val) {
		this.val = val;
	}

	public void run() {
		System.out.println(Thread.currentThread().getName() + ": " + val);
	}

	public static void main(String[] args) throws InterruptedException {
		Thread[] threads = new Thread[20];
		for (int i = 0; i < threads.length; i++) {
			threads[i] = new Thread(new Slide16WithoutThreadLocal(i), "thread-" + i);
			threads[i].start();
		}
	}
}