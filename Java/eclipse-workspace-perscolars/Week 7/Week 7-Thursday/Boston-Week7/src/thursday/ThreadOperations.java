package thursday;

public class ThreadOperations extends Thread{
	
	@Override
	public void run() {
		System.out.println("Before Sleep");
		try {
			Thread.sleep(Long.MAX_VALUE);
			
		}catch(InterruptedException e) {
			System.out.println("Thread Interrupted");
		}
		System.out.println("After Sleep");
	}


	public static void main(String[] args) throws InterruptedException {
		/*
		The main thread is created automatically when our program is started.
		To control it we must obtain a reference to it. This can be done by
		calling the method currentThread( ) which is present in Thread class.
		*/
			Thread testThread = new Thread(new ThreadOperations() ,"testThread");
			testThread.start();
	
			testThread.interrupt();
			//System.out.println("testThread is Running");
			//testThread.join();
			//System.out.println("testThread has Finished.");
			
			
	}
	

}
