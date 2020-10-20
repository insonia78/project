import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.nio.file.StandardCopyOption;

public class S21FilesPlayGround {

	public static void main(String[] args) throws IOException {
		File newFile = null;
		File playGround = new File("resources");
		playGround.mkdir();
		System.out.println(playGround.isDirectory());
		new File(playGround.getAbsolutePath() +"/first").mkdir();
		newFile = new File(playGround.getAbsolutePath() + "/sample.txt");
		newFile.createNewFile();
		System.out.println(newFile.getName());
		Files.move(Paths.get(newFile.getPath()),
				Paths.get(playGround.getAbsolutePath() + "/first/" + (newFile.getName())),
				StandardCopyOption.REPLACE_EXISTING);

	}

}
