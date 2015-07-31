// This program was written by Thomas Zangari Comi 1510 summer 2013  JA4
import java.text.DecimalFormat;
import java.util.Scanner;
import java.io.*;

/**
This program analyze the profit of a Stockfile contaning numbers of stocks,price per stock buyed,
buy commission percent, price for selling the stock, and commission percent for selling the stock.
It displays: the profit if the fealds are valid , the fields that are not valid,and if the file
contains data.The program is developed with two methods: checkValidity that test if the fields are valid,
and  profit for calculating the profit of the shares nested in a while loop.
*/

public class AssignmentN4
{
	public static void main(String[] args) throws IOException
	{
		String filename;            // contaning the filename.
        double numberOfShare;       // contaning the number of shares.
        double purcPricexShare  ;   // contaning the price purces per share.
        double purcComPerc  ;       // contaning the purces commission percent.
        double salesPricexShare  ;  // contaning the sale price per share.
        double salesComPerc  ;      // contaning sales commission percent.
        double profit   ;             // contaning the profit.
        int count = 0 ;               // count for the while loop
        boolean checkValidity = true  ;      // contaning the boolean value for checkValidity.
        double sum  = 0;              // contaning the sum value of the toatl profit
        double average = 0 ;          // average value of the sum.

        // format for the resoult
		DecimalFormat formatter =new DecimalFormat("#,##0.00");

		Scanner keyboard = new Scanner (System.in);

        System.out.print("Thomas Zangari\n\n");
		System.out.print("Enter the filename: ");
	    // inputing the filename
	    filename = keyboard.nextLine();
		File file = new File(filename);

        Scanner inputFile = new Scanner(file);


        /**
         while loop with nested checkValidity, and the profit method. This loop aquaries
         the values of the file and then it valuets in the method giving the relsoults.
         */
	    while (inputFile.hasNext())
		{

			numberOfShare = inputFile.nextDouble(); // aquaring the number of shares from the file
			purcPricexShare = inputFile.nextDouble(); // acquaring the price per share from the file
			purcComPerc = inputFile.nextDouble();     // acquaring purces commission price from the file
			salesPricexShare = inputFile.nextDouble();// aquaring the sales per share from the file
			salesComPerc = inputFile.nextDouble();    // aquaring the sales commission percent from the file.


            // function for acquaring the boolean checkValidity value.
            checkValidity = checkValidity(purcPricexShare,purcComPerc,salesComPerc,salesPricexShare,numberOfShare);
             // function for aquaring the double value from the profit method
		    profit = profit(numberOfShare,purcPricexShare,purcComPerc,salesPricexShare,salesComPerc);



            // If statment that displays the single profit of the single fields from the file if the boolean
            // checkValidity is true
			if (checkValidity == true)

			{

				count++;
				System.out.print("\nValid Transaction " + count  + " profit: $" +formatter.format (profit) + "\n\n");
                sum += profit;

            }

		}
		// closing the file.
		inputFile.close();
		// calculating the average of the total profit
		average = sum / count;

        // If statment for the total profit and the average of the total profit with count.
		if (count > 0  )
		{
			  System.out.println("\nThe total profit is: $" + formatter.format(sum));
			  System.out.println("The average profit is: $" + formatter.format(average));

		}
		// else statment if there is no transactions to process
	    else
		{
			 System.out.println("\nNo transaction processed");

		}
        System.exit(0);


    }



       /**
        checkValidity method for testing if the fields are invalid and returns a true false value
        @param purPricexShare  Price per Share to be tested.
        @parm purComPerc       Purces Commission Percentege to be tested.
        @parm salesComPerc     Sales Commission percent to be tested.
        @parm salesPricexShare Sales price per share to be tested.
        @parm numberOfShare    Number of Shares to be tested.
        @return checkValidity  returns True or False.
        */
       public static boolean checkValidity(double purcPricexShare,double purcComPerc,double salesComPerc,
                                            double salesPricexShare,double numberOfShare)
        {
			DecimalFormat formatter = new DecimalFormat("#,##0.00");

			final double SALES_PRICE_XSHARE_CEILING = 0.0;//   sales price per share ceiling value.
			final double PURC_PRICE_XSHARE = 0.0;          //   purces price per share ceiling value.
			final double PURC_COM_PERC = 0.20;             //   purces commission percent ceiling value.
			final double SALES_COM_PERC = 0.20;            //   sales commission percent ceiling value.
			final double NUMBER_OF_SHARE = 0.0;            //   number of shares that are not valid.

            boolean checkValidity = true      ;             //   the returning value of the method

            if  (purcPricexShare < PURC_PRICE_XSHARE )
			{
				if (salesPricexShare < SALES_PRICE_XSHARE_CEILING  )
			    {
			     System.out.println (" Purchase price invalid: $" + formatter.format(purcPricexShare) +"\n");
			     System.out.println(" Sales price invalid: $"+ salesPricexShare + "\n");
                  checkValidity = false;
			    }
			    else
			    {
					System.out.println (" Purchase price invalid: $" + formatter.format(purcPricexShare) +"\n");
                    checkValidity = false;
				}

			}
		    if (salesPricexShare < SALES_PRICE_XSHARE_CEILING )
			{
				System.out.println(" Sales price invalid: $"+formatter.format(salesPricexShare) + "\n");
                checkValidity = false;
            }
		    if (purcComPerc > PURC_COM_PERC || purcComPerc < 0)
		    {
			   if (salesComPerc > SALES_COM_PERC || salesComPerc < 0)
				 {
				    System.out.println("Purchase commission percent invalid:" +formatter.format (purcComPerc)+"\n");
			        System.out.println("Sale commission percent invalid:" + formatter.format(salesComPerc)+"\n");
                    checkValidity = false;
			     }
			     else
			     {
					 System.out.println("Purchase commission percent invalid:" + formatter.format(purcComPerc)+"\n");
                     checkValidity = false;
				 }
		    }
		    if  (salesComPerc > SALES_COM_PERC|| salesComPerc < 0)
			{
				System.out.println("Sale commission percent invalid:" + formatter.format(salesComPerc)+"\n");
                checkValidity = false;
			}
		    if  (numberOfShare == NUMBER_OF_SHARE)
			{
				System.out.println("Number of shares invalid :" +formatter.format(numberOfShare) + "\n");
                  checkValidity = false;
			}
		    return  checkValidity;
		}
        /**
         the method profit calulates the purchaseComAmount , salesComAmount,and the profit and returns the profit.
         @parm numberOfShare number of shares.
         @parm purcPricexShare purces price per share.
         @parm purComPerc purce commission percentege.
         @parm salesPricexShare sales price per share.
         @parm salesComPerc sales commission percent.
         @parm purchaseComAmount purchase  commission amount.
         @parm salseComAmount sales commission amount.
         @return the profit.
         */

        public static double profit(double numberOfShare,double purcPricexShare,double purcComPerc,
                                    double salesPricexShare,double salesComPerc)
        {
		  double purchaseComAmount; // contaning the value of the formula (numberOfShare*purcPricexShare*purcComPerc).
		  double salesComAmount;    // contaning the value of the formula(numberOfShare*salesPricexShare*salesComPerc).
          double profit;

	      purchaseComAmount = numberOfShare*purcPricexShare*purcComPerc;

		  salesComAmount = numberOfShare*salesPricexShare*salesComPerc;

		  profit = (numberOfShare * salesPricexShare- salesComAmount)-
					 (numberOfShare*purcPricexShare + purchaseComAmount);

		  return profit;
		}

}
/**
Thomas Zangari

Enter the filename: StockData.txt

Valid Transaction 1 profit: $226.31

 Purchase price invalid: $-15.75


Valid Transaction 2 profit: $336.22


Valid Transaction 3 profit: $-144.75


Valid Transaction 4 profit: $-1,333.86

Purchase commission percent invalid:1.02

Sale commission percent invalid:1.02


Valid Transaction 5 profit: $1,227.89

Number of shares invalid :0.00


The total profit is: $311.80
The average profit is: $62.36
Press any key to continue . . .

---------------------------------------

Thomas Zangari

Enter the filename: emptyData.txt

No transaction processed
Press any key to continue . . .
*/
