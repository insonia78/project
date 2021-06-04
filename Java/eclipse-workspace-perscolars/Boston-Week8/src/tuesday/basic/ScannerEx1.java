package tuesday.basic;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.util.Scanner;

public class ScannerEx1 {
	public static void main(String[] args) throws FileNotFoundException {
		Scanner s = null;
		File readIn = new File("Sample3.txt");
		BufferedReader bufferStream = null;
		FileReader inputStream = null;
		
		try
		{
			inputStream = new FileReader(readIn);
			bufferStream = new BufferedReader(inputStream);
			s = new Scanner(bufferStream);
			
			while (s.hasNext()) {
				System.out.println(s.next());
			}
		}
		finally
		{
			if (s != null) {
				s.close();
			}
		}
	}
}
