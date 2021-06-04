package thursday;

import java.lang.Thread.State;

public class IntroThreads {

	public static void main(String[] args) {
			
		long id = Thread.currentThread().getId();
		String name = Thread.currentThread().getName();
		int priority = Thread.currentThread().getPriority();
		State state = Thread.currentThread().getState();
		String threadGroupName = Thread.currentThread().getThreadGroup().getName();
		System.out.printf("\n ID= %-5d\n Name= %-5s\n Priority= %-5d\n State= %-5s\n Thread Group Name= %-5s",id,name,priority,state,threadGroupName );
	}

}
