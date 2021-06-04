package org.perscholas.securitydemo;

import org.springframework.boot.context.properties.ConfigurationProperties;




@ConfigurationProperties(prefix = "defaultvalues")
public class ConfigProperties {
    
    private String hostName;
    private int port;
    private String from;
    
    
	public String getHostName() {
		return hostName;
	}
	public void setHostName(String hostName) {
		this.hostName = hostName;
	}
	public int getPort() {
		return port;
	}
	public void setPort(int port) {
		this.port = port;
	}
	public String getFrom() {
		return from;
	}
	public void setFrom(String from) {
		this.from = from;
	}
 
    // standard getters and setters
}