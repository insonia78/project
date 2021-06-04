package monday;

public class ThreadLocalExample {
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
	public static void main(String[] args) throws InterruptedException {
		
		  MyRunnableLocal sharedRunnableInstance = new MyRunnableLocal();

	        Thread thread1 = new Thread(sharedRunnableInstance);
	        Thread thread2 = new Thread(sharedRunnableInstance);

	        thread1.start();
	        thread2.start();

	        thread1.join(); //wait for thread 1 to terminate
	        thread2.join(); //wait for thread 2 to terminate

	}

}


	

