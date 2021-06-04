package tuesday.advanced;

import java.io.File;

public class S16CheckFileExists {

	public static void main(String[] args) {
		// accept file name or directory name through command line args
		String fname = "sample3.txt";
		//pass the filename or directory name to file object
		File f = new File(fname);
		//apply file class methods on file object
		System.out.println("File name: "+f.getName());
		System.out.println("Path: "+f.getPath());
		System.out.println("Absolute path: "+f.getAbsolutePath());
		System.out.println("Parent: "+f.exists());
		if (f.exists()) {
			System.out.println("Is Writeable: "+f.canWrite());
			System.out.println("Is readable: "+f.canRead());
			System.out.println("Is a directory: "+f.isDirectory());
			System.out.println("File Size in bytes: "+ f.length());
		}
	}

}
