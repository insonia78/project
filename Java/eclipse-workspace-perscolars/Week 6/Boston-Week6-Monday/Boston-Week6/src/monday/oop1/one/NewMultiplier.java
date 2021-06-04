package monday.oop1.one;

public class NewMultiplier extends Multiplier{
	
		@Override
		public void display(int a, int b, String modifier, int result) {
			System.out.println(a+modifier+b+" yields "+result);
		}
}
