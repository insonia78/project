package exercise.jbcd.slide1602;

import java.io.File;
import java.io.IOException;
import java.io.InputStream;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.util.Properties;

public class DatabaseConnection {

		public Connection getConnection() throws ClassNotFoundException,
		IOException, SQLException {
		File f = new File("src/properties/db.properties");
		
		
		final Properties prop = new Properties();
		final InputStream inputStream = ClassLoader.class
				.getResourceAsStream(
						"/properties/db.properties.txt");
	    
		prop.load(inputStream);
		System.out.println(prop.getProperty("driver"));
		Class.forName(prop.getProperty("driver"));
		
		final Connection connection = DriverManager.getConnection(prop.getProperty("url"), 
				prop.getProperty("user"), prop.getProperty("password"));
		
		 return connection;
		
		}
	
	
}