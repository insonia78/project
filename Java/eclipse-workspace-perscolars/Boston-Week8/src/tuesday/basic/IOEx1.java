package tuesday.basic;

import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;

public class IOEx1 {

	public static void main(String[] args) throws IOException {
		FileReader inputStream = null;
		FileWriter outputStream = null;
		File readIn = new File("sample.txt");
		File writeTo = new File("sampleTo.txt");
		
		try
		{
			inputStream = new FileReader(readIn);
			outputStream = new FileWriter(writeTo);
			int c;
			while((c = inputStream.read()) != -1) {
				outputStream.write(c);
			}
		}
		finally
		{
			if (inputStream != null) {
				inputStream.close();
			}
			if (outputStream != null) {
				outputStream.close();
			}
			
		}
	}

}
