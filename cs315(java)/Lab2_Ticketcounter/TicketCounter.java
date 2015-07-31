/**
 * TicketCounter demonstrates the use of a queue for simulating a waiting line.
 *
 * @author Dr. Lewis
 * @author Dr. Chase
 * @version 1.0, 08/12/08
 */



public class TicketCounter    
{
   final static int MIN = 60;
   final static int MAX = 180;
   final static int MAX_CASHIERS = 10;
   final static int NUM_CUSTOMERS = 200;
   final static int ARRIVAL_TIME = 20;
   final static int PROCESS = (int)((MAX - MIN +1)*Math.random()+MIN);
   public static void main ( String[] args) 
   {
      Customer customer;
      LinkedQueue<Customer> customerQueue = new LinkedQueue<Customer>();
      int[] cashierTime = new int[MAX_CASHIERS];	
      int totalTime, averageTime, departs;
      
      
      System.out.println("Process time(in seconds):"+PROCESS+"\n");
      // printing the output
      System.out.printf("%20s %30s %n","Number of Cashiers","Average Time (in minutes)");       
      /** process the simulation for various number of cashiers */
      for (int cashiers=0; cashiers < MAX_CASHIERS; cashiers++)
      { 
         /** set each cashiers time to zero initially*/
          for (int count=0; count < cashiers; count++)
            cashierTime[count] = 0;

         /** load customer queue */
         for (int count=1; count <= NUM_CUSTOMERS; count++)
            customerQueue.enqueue(new Customer(count*ARRIVAL_TIME));

         totalTime = 0;

         /** process all customers in the queue */
         while (!(customerQueue.isEmpty())) 
         {
            for (int count=0; count <= cashiers; count++)
            {
               if (!(customerQueue.isEmpty()))
               {
                  customer = customerQueue.dequeue();
                  if (customer.getArrivalTime() > cashierTime[count])
                     departs = customer.getArrivalTime() + PROCESS;
                  else
                     departs = cashierTime[count] + PROCESS; 
                  customer.setDepartureTime (departs);
                  cashierTime[count] = departs;
                  totalTime += customer.totalTime();
               }
            }
         }

         /** output results for this simulation */
         averageTime = (totalTime / NUM_CUSTOMERS)/60;
         System.out.printf ("%10d %30d %n",(cashiers+1),averageTime);
        
      }
   }
}
