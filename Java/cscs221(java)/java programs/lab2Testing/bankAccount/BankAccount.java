
/**
 * Write a description of class BankAccount here.
 * 
 * @author Thomas Zangari   
 * @version 09/18/2013
 */
public class BankAccount
{
    // instance variables - replace the example below with your own
    private double _balance;
    

    /**
     * Constructor for objects of class BankAccount
     */
    public BankAccount(double bal)
    {
        // initialise instance variables
        _balance = bal;
    }

   public void withdraw (double amount){
       _balance = _balance - amount;
    }
     public void deposit (double amount){
       _balance = _balance + amount;
    }
     public double getBalance(){
       return _balance;
    }
}
    
    
    