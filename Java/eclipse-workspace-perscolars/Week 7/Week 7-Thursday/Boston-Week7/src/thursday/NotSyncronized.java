package thursday;

public class NotSyncronized extends Thread{
	
	private static int counter = 0;

	public static void main(String[] args) {
		Thread[] threads = new Thread[5];
		for(int i = 0; i<threads.length;i++) {
			threads[i] = new Thread(new NotSyncronized(), "thread-"+i);
			threads[i].start();
		}
	}
	@Override
	public void run() {
		while(counter <10) {
			System.out.println("["+Thread.currentThread().getName()+"] before: "+counter);
			counter++;
			System.out.println("["+Thread.currentThread().getName()+"] after: "+counter);

		}
	}

}
