

import java.io.IOException;
import java.nio.file.DirectoryNotEmptyException;
import java.nio.file.Path;
import java.nio.file.Paths;

public class S18CheckingFileAccessibility {

	public static void main(String[] args) throws DirectoryNotEmptyException, IOException{
		
			Path filePath = Paths.get("resources/checking.txt");
			filePath.toFile().delete();
			System.out.println("File or directory is deleted");
	}

}
