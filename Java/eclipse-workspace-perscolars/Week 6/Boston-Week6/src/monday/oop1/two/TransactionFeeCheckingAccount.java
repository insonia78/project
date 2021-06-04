package monday.oop1.two;

public class TransactionFeeCheckingAccount extends CheckingAccount {

	private static final double FEE = 2.00;

	public void chargeFee(CheckingAccount x, boolean i) {
		if (i) {
			x.withdraw(FEE);
		}
	}
}
