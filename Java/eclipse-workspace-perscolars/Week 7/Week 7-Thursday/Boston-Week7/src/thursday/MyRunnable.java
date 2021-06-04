package thursday;

public class MyRunnable implements Runnable{

	public static void main(String[] args) throws InterruptedException {
		Thread myThread = new Thread(new MyRunnable(), "myRunnable");
		myThread.start();
		
	}
	
	public void run() {
		System.out.println("Executing thread "+ Thread.currentThread().getName());
	}

}
