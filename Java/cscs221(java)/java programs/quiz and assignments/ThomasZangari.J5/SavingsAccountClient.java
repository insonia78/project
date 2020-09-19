// Thomas Zangari

import java.io.*;
import java.util.Scanner;
import java.text.DecimalFormat;

public class SavingsAccountClient
{
	public static void main(String args[]) throws IOException
	{
		// Use these declarations
		double interestRate;      	// Annual interest rate
		double balance;				// Balance in the account
		double interestEarned;    	// Interest earned
		double amount;            	// Amount of a deposit or withdrawal
		double totalUpdates=0;		// Total amount deposited and withdrawn


         DecimalFormat formatter = new DecimalFormat("$,##0.00");
		// Display your name
		System.out.println("Thomas Zangari");

		// Welcome message
		System.out.println("\nWelcome to the Fleesum Bank"
			+ "\nThis is the monthly interest calculator");

		// Create a Scanner object for keyboard input.
		Scanner keyboard = new Scanner(System.in);

		// Get the annual interest rate.
		System.out.print("\nEnter the savings account's " +
			"annual interest rate: ");
		interestRate = keyboard.nextDouble();

		// Get the starting balance.
		System.out.print("\nEnter the starting balance: ");
		balance = keyboard.nextDouble();


		// FILL IN HERE ACCORDING TO DIRECTIONS

		// instantiate of the savings acount object
		SavingsAccount savingsAccountClient = new SavingsAccount(interestRate,balance);


        System.out.println("\nStarting Values:");

		//displayng the toString method
		System.out.println(savingsAccountClient.toString());

        //opening the Updates.txt
		File file = new File("Updates.txt");

		Scanner inputFile = new Scanner(file);
        //checking for the file exists
        if (!file.exists())
		{
			System.exit(0);
		}
		// loop for getting the data from the file,summing the balance with the amount
		// and summing the amount with the totalUpdates variable.
		while (inputFile.hasNext())
		{
		    amount = inputFile.nextDouble();
            //
		    savingsAccountClient.update(amount);

            System.out.println("\nAmount:" + formatter.format(amount));

            System.out.print("New Balance:"+ formatter.format(balance+ amount)+"\n");

            balance = balance + amount;

            totalUpdates = totalUpdates + amount;
	    }
	    // closing the file
	    inputFile.close();

	    // updating the balance withthe interest.
	    savingsAccountClient.addInterest();

	    System.out.println("\nFinal values:");
        // calculating the interest value
	    interestEarned =(((interestRate)/ 12)*balance);
        // displayng the final balance and annual interest rate.
	    System.out.println(savingsAccountClient.toString());



		// Display the total updates, interest earned, and the balance.
		System.out.println("\nTotal Updates: " + formatter.format(totalUpdates));
		System.out.println("Interest earned: " + formatter.format(interestEarned));
		System.out.println("Ending balance: " + formatter.format(balance + interestEarned));
	}
}

