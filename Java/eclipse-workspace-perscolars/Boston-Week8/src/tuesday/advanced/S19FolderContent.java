package tuesday.advanced;

import java.io.BufferedReader;
import java.io.File;
import java.io.IOException;
import java.io.InputStreamReader;

public class S19FolderContent {
// hint for dir path : /Users/Habboubi/eclipse-workspace/Boston-Week8/src/tuesday/
	// hint for dir name : advanced
	public static void main(String[] args) throws IOException {

		BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
		System.out.println("Enter Dir Path");
		String dirpath = br.readLine();
		System.out.println("Enter the dir name");
		String dname = br.readLine();
		File f = new File(dirpath, dname);
		if (f.exists()) {
			String arr[] = f.list();
			int n = arr.length;

			for (int i = 0; i < n; i++) {
				System.out.println(arr[i]);
				File f1 = new File(arr[i]);
				if (f1.isFile()) {
					System.out.println(" :is a file");
				}
			}
			System.out.println("No. of enteris in this directory " + n);
		} else {
			System.out.println("Directory not found");
		}

	}

}
