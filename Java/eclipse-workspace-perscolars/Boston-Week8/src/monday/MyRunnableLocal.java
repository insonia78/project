package monday;

public class MyRunnableLocal implements Runnable {
	//private ThreadLocal<Integer> threadLocal = new ThreadLocal<Integer>();
	private Integer threadLocal;
	/*
	 * http://tutorials.jenkov.com/java-concurrency/threadlocal.html
	 * This example creates a single MyRunnable instance which is passed to two
	 * different threads. Both threads execute the run() method, and thus sets
	 * different values on the ThreadLocal instance. If the access to the set() call
	 * had been synchronized, and it had not been a ThreadLocal object, the second
	 * thread would have overridden the value set by the first thread. However,
	 * since it is a ThreadLocal object then the two threads cannot see each other's
	 * values. Thus, they set and get different values.
	 */
	@Override
	public void run() {
		//threadLocal.set((int) (Math.random() * 100D));
		threadLocal =((int) (Math.random() * 100D));

		try {
			Thread.sleep(2000);
		} catch (InterruptedException e) {
		}

		//System.out.println(threadLocal.get());
		System.out.println(threadLocal);

	}

}