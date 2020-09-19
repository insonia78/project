import java.text.DecimalFormat;
/**
Savings account class with the getInterestRate,addInterest,getBalance,
update,toString methods.
*/
public class SavingsAccount
{
	DecimalFormat formatter = new DecimalFormat("$,##0.00");

	private double annualInterestRate ;
	private double balance ;

    public SavingsAccount()
	{
		annualInterestRate = 0.005;
		balance = 0.00;
	}
    public SavingsAccount( double annRate,double bal)
    {
		annualInterestRate = annRate;
		balance = bal;

	    // if statment testing for invalid entry balance from the client
		if (balance < 0)
		{
			balance = 0.00;    // default value for the balance
			System.out.println("WARNING: Starting balance must not be negative;"
								+ " \nsetting it to" +formatter.format(balance));
		}
		// if statment testing for invalid entry annual interest from the client.
		if (annualInterestRate < 0)
		{
			annualInterestRate = 0.005; // default value for the annual interst rate.
			System.out.println("WARNING: Interest rate must not be negative;"
							   + "setting it to:" + (annualInterestRate*100)+"%");
		}

	}
	/**
	The getInterestRate methods gets the annual iterest rate from the SavingsAccountClient class
	in the main method.
	@return The value in the annualInterestRate field.
	 */
	public double getInterestRate()
	{
		return annualInterestRate;
	}
	/**
	The getBalance gets the balance from the from the SavingsAccountClient class in the main method.
	*/
	public double getBalance()
	{
		return balance;
	}
	/**
	The update method test if the  balance is inferior to zero
	@param bal The parameter that test the if statment.
	*/
	public void update( double bal)
	{
		// if statment that test if the balance is inferior to zero.
		balance += bal;
		if (balance < 0)
		{
			System.out.println("\nWARNING:ACCOUNT OVERDRAWN"+formatter.format(balance));
		}

    }
    /**
	The addInterest method adds the interest to the balance if the balance is major than zero.
	*/
	public void addInterest()
	{
		Double monthlyIntRate = (annualInterestRate)/ 12;// monthley interest rate
		Double monthlyInt = 0.0;                         // monthley interest in dollars

		// If it is major than zero it calculates the monthley interest and it adds it to balance
		if (balance > 0)
		{
			monthlyInt = balance * monthlyIntRate;
		    balance += monthlyInt;
		}
	}
	/**
	The toString method returns the values of the inizial and the final balance and
	annual interest
	@return The inizial and final values of the balance and the annual interest rate.
	*/
	public String toString()
	{
	  DecimalFormat formatter = new DecimalFormat(",##0.00");

	  return "Balance =$" +formatter.format(balance) + "\n" + "Interest amount = "
	         +formatter.format(annualInterestRate*100) + "%";
	}


}