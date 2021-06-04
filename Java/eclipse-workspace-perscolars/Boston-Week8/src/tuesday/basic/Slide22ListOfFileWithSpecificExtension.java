package tuesday.basic;

import java.io.File;

public class Slide22ListOfFileWithSpecificExtension {
	public static void main(String[] args) {
		File file = new File("/Users/Charlie/Documents");
		String[] fileList = file.list();
		for (String name: fileList) {
			if (name.toLowerCase().endsWith(".txt")) {
				System.out.println(name);
			}
		}
	}
}
