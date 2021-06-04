package tuesday.basic;

import java.io.File;

public class Slide21ListOfFileNames {
	public static void main(String[] args) {
		File file = new File("/Users/Charlie/Documents");
		String[] fileList = file.list();
		for (String name: fileList) {
			System.out.println(name);
		}
	}
}
