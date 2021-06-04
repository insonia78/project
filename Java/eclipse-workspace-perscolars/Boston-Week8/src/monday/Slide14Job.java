package monday;

public class Slide14Job {
	private boolean running = false;
	private final String filename;
	
	public Slide14Job (String filename) {
		this.filename = filename;
	}
	
	public boolean isRunning() {
		return running;
	}

	public String getFilename() {
		return filename;
	}

	public synchronized void start() {
		if (running) {
			throw new IllegalStateException();
		}
	}
}
