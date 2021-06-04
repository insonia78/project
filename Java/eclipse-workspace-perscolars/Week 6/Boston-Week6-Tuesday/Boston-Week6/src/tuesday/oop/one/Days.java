package tuesday.oop.one;


public enum Days {
	MONDAY(0),TUESDAY(1),WEDNESDAY(2),THURSDAY(3),FRIDAY(4),SATURDAY(5),SUNDAY(6);
	
	private final int day;
	
	Days(int i) { // enum constructor
		this.day = i;
	}
	
	public int getDay() {
		return this.day;
	}


public static void getDay(Days day) {
	System.out.println("\nThe day is "+ day);
}
	
}

		
		
		