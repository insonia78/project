package monday.oop1.two;

public class BankMain {

	public static void main(String[] args) {
		// TODO Auto-generated method stub

		CheckingAccount someone = new CheckingAccount(3.5);
		
		System.out.println("Current Balance "+someone.getBalance());
		System.out.println("Interest: "+someone.getMyInterest());
		
		
		someone.setBalance(500.20);
		someone.setMyInterest(2.1);
		
		
		System.out.println("Current Balance "+someone.getBalance());
		System.out.println("Interest: "+someone.getMyInterest());
		
		boolean i = someone.withdraw(50);
		
		System.out.println("Current Balance "+someone.getBalance());
		
		TransactionFeeCheckingAccount fee = new TransactionFeeCheckingAccount();
		fee.chargeFee(someone, i);
		System.out.println("Current Balance after fee"+someone.getBalance());


	
		
	}

}
