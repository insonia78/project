package monday;

import java.util.Map;

public final class Slide13ImmutableMessage {
	private final String subject;
	private final String message;
	private final Map<String, String> header;
	
	public Slide13ImmutableMessage(Map<String, String> header, String subject, String message) {
		this.header = header;
		this.subject = subject;
		this.message = message;
	}

	public String getSubject() {
		return subject;
	}

	public String getMessage() {
		return message;
	}

	public Map<String, String> getHeader() {
		return header;
	}
	
}
