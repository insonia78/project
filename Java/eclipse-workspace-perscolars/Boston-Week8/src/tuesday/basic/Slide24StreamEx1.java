package tuesday.basic;

import java.io.FileInputStream;
import java.io.IOException;
import java.util.Scanner;

public class Slide24StreamEx1 {
	public static void main(String[] args) throws IOException {
		FileInputStream inputStream = null;
		Scanner sc = null;
		try
		{
			inputStream = new FileInputStream("sample3.txt");
			sc = new Scanner(inputStream, "UTF-8");
			while (sc.hasNextLine()) {
				String line = sc.nextLine();
				System.out.println(line);
			}
			if (sc.ioException() != null) {
				throw sc.ioException();
			}
		}
		finally
		{
			if (inputStream != null) {
				inputStream.close();
			}
			if (sc != null) {
				sc.close();
			}
		}
	}
}
