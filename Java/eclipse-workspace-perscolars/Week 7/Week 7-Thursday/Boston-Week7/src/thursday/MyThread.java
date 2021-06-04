package thursday;

public class MyThread extends Thread{

	public static void main(String[] args) throws InterruptedException {
		MyThread myThread = new MyThread("JDThread");
		myThread.start();
		

	}
	
	public MyThread(String name) {
		super(name);
	}
	
	@Override
	public void run() {
		System.out.println("Executing thread "+Thread.currentThread().getName());
	}

}
