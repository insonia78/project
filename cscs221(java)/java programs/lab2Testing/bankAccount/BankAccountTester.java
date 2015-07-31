
/**
 * This class is designed to test the BankAccount class
 * 
 * @author Thomas Zangari
 * @version 09/18/2013
 */
import java.util.Scanner;
public class BankAccountTester
{
    // instance variables - replace the example below with your own
    private Scanner _kbd;

    /**
     * Constructor for objects of class BAckAccountTester
     */
    public BankAccountTester()
    {
        // initialise instance variables
        _kbd = new Scanner(System.in);
        this.start();
    }
    public void start(){
        this.testAccount();
        this.testAccount();
        this.testAccount();
       
    }
    public void testAccount(){
        double accountAmount;
        double amount;
        double deposit;
        
        System.out.print("What is your initial account: ");
        accountAmount = _kbd.nextDouble();_kbd.nextLine();
        BankAccount balance= new BankAccount(accountAmount);
        System.out.println("Account Balance: " + balance.getBalance());
        System.out.print("Amount to withdraw: ");
        amount = _kbd.nextDouble();
        balance.withdraw(amount);
        System.out.printf("Account balance: %.2f", balance.getBalance());
        System.out.println();
        System.out.print("Amount to deposit: ");
        deposit = _kbd.nextDouble();
        balance.deposit(deposit);
        System.out.printf("Account balance: %.2f", balance.getBalance());
        System.out.println();
        System.out.println();

    }
}
        