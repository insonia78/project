package tuesday.advanced;

import java.io.File;

public class S09FilesExamples1 {

	public static void main(String[] args) {
		File readin = new File("sample.txt");
		File writeTo = new File("sampleTo.txt");
		
		System.out.println(readin.getAbsoluteFile());
		System.out.println(writeTo.getAbsoluteFile());
		
		System.out.println(readin.getParentFile());
		System.out.println(readin.isFile());
		System.out.println(readin.exists());
		System.out.println(readin.canWrite());
		readin.getFreeSpace();
		
	}

}
