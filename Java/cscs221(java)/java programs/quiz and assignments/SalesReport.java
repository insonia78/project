import java.util.Scanner;
import java.io.*;
import java.text.DecimalFormat;
import javax.swing.JOptionPane;

public class SalesReport
{
	public static void main(String[] args) throws IOException
	{
       final int NUM_DAYS = 30;
       String filename;
       double totalSales;
       double averageSales;
       filename = getFileName();

       totalSales = getTotalSales(filename);
       averageSales = totalSales / NUM_DAYS;
       displayResoult(totalSales, averageSales);

       System.exit(0);


    }
    public static String getFileName()
    {
		String file;
		file = JOptionPane.showInputDialog("Enter the name of the file\n contaning 30 days of sales amount");

	    return file;
	}
	public static double getTotalSales(String filename)throws IOException
	{
		double total = 0.0;
		double sales;
		File file = new File(filename);
		Scanner inputFile = new Scanner (file);
		while (inputFile.HasNext())
		{
			sales = inputFile.nextDouble();
			total+= sales;
		}
	    inputFile.close();
	    return total;
     }
     public static void displayResults(double total, double avg)
     {
			DecimalFormat dollar = new DecimalFormat("#,###,00");
			JOptionPane.showMessageDialog(null, " the total sales for the periodis $" + dollar.format(total)+
			                                    "\nThe average daily salses where $" + dollar.format(avg));
	 }


}