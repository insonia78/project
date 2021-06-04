package monday.oop1.two;

public class CheckingAccount extends BankAccount{
				
		//Fields
		private double myInterest;
		
		//Default Constructor

		public CheckingAccount() {
		}
		
		//Constructor
		public CheckingAccount(double interest) {
			this.myInterest=interest;
		}
		
		boolean withdraw(double amount) {
			
			if(amount>0) {
			double newBalance = super.getBalance()-amount;
			super.setBalance(newBalance);
			return true;
			
			}
			else {
				System.out.println("Amount must be positive!");
				return false;
			}
			
			
		}
		
		//Getters & Setters
		public double getMyInterest() {
			return myInterest;
		}
		public void setMyInterest(double myInterest) {
			this.myInterest = myInterest;
		}
		
}
