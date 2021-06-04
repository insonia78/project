package monday;

import java.util.concurrent.locks.ReentrantLock;

class Slide06Runnable implements Runnable {
	private final ReentrantLock lock = new ReentrantLock();
	
	@Override
	public void run() {
		/* The lock() method of the RentrantLock object is called to prevent other threads from 
		 * running the code until the unlock() method is called. This is similar to using the 
		 * "synchronized" keyword, but with added capabilities. You can read more about this at
		 * https://docs.oracle.com/javase/8/docs/api/java/util/concurrent/locks/ReentrantLock.html*/
		lock.lock();
		try
		{
			for (int i = 1; i <= 5; i++) {
				System.out.println(Thread.currentThread().getName() + ": " + i);
			}
		}
		/* Try blocks without catch are allowed in Java. Any exceptions thrown will be handled 
		 * elsewhere (i.e., higher up the call stack). This assures that the finally block will run 
		 * even if an exception is thrown. */
		finally
		{
			/* If the lock() method is called and the unlock() method is not called afterwards then 
			 * deadlock results.
			 * If the unlock() method is called and the lock() method is not called prior then an 
			 * IllegalMonitorStateException is thrown. */
			lock.unlock();
		}

	}
	
}

public class Slide06ReentrantLock {
	
	public static void main(String[] args) {
		Runnable r = new Slide06Runnable();
		Thread[] threadArr = new Thread[5];
		for (int i = 0; i < threadArr.length; i++) {
			threadArr[i] = new Thread(r);
			threadArr[i].start();
		}
	}
}