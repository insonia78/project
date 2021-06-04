package monday;

public class Slide15Job {
	private final String filename;
	
	private Slide15Job (String filename) {
		this.filename = filename;
	}

	public static Slide15Job createAndStart(String filename) {
		Slide15Job job = new Slide15Job(filename);
		job.start();
		return job;
	}
	
	public String getFilename() {
		return filename;
	}

	public synchronized void start() {
		System.out.println("Start method.");
	}
	
	public static void main(String[] args) {
		Slide15Job obj = Slide15Job.createAndStart("newFilename");
		System.out.println(obj.getFilename());
	}
}
