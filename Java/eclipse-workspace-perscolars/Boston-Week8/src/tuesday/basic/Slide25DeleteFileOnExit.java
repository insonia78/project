package tuesday.basic;

import java.io.File;
import java.io.IOException;

public class Slide25DeleteFileOnExit {
	public static void main(String[] args) {
		File temp;
		try
		{
			temp = File.createTempFile("myTempFile", ".txt");
			System.out.println("Temp file created :" + temp.getAbsolutePath());
			
			// temp.delete(); // For deleting immediately
			
			temp.deleteOnExit(); // Delete on runtime exit
			
			System.out.println("Temp file exists: " + temp.exists());
		}
		catch (IOException e)
		{
			e.printStackTrace();
		}
	}
}
