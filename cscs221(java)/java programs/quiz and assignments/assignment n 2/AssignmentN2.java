
// Program written by Thomas Zangari summer 2013 java 1510 AJ2

import java.util.Scanner;
import java.text.DecimalFormat;
/**
 This program calculates the cost of shiping a package with Fed Ex. At the user is asked to enter and then displays the package weight,
 a area-code for where the package should be shipt ,a service code for the type of shiping,if there is hazard products with
 relative percentig increase and then dysplays the cost .The decision structure is based on a nested if-else if statments,
 uses a input output console,and a decimal format for formmating the resoult.
 The formula for calulating the cost is (packageWeight*areaCode+specialService)*hazardCode+(packageWeight*areaCode+specialService).
 */

public class AssignmentN2
{
	public static void main(String[] args)
	{
		/**
		 Constant values for the area-codes need to calculate the price of shipping per pound.
		 */

		final double AREA_A = 0.60;     //constant value that calculates the user choose for area-code A or a.
		final double AREA_B = 1.00;     //constant value that calculates the user choose for area-code B or b.
		final double AREA_C = 1.25;     //constant value that calculates the user choose for area-code C or c.
		final double AREA_D = 1.40;     //constant value that calculates the user choose for area-code D or d.

		/**
		Constant values for calculating the service-code for the type of shipping.
		*/


		final String SPECIALSERVICE_1 = "No charge"; //constant value for service-code 1.
		final int SPECIALSERVICE_2= 10;              //constant value for service-code 2.
		final int SPECIALSERVICE_3= 25;               //constant value for service-code 3.

        /**
         Constant values for calculating the hazard-code.
         */

		final String HAZARDCODE_1 = "No charge"; //constant value for hazard-code 1.
		final double HAZARDCODE_2 = 0.10;        //constant value for hazard-code 2.
		final double HAZARDCODE_3 = 0.25;        //constant value for hazard-code 3.

        /**
        variables of the program.
        */

        String zone;
        char zone1;                        // variables for inputing the area code.
        double packageWeight;              // variable for inputing the package weight.
        int specialService ,hazardCode;    // variables for inputing

        /**
         Decimal format and scanner keyboard objects.
         */

        DecimalFormat formatter = new DecimalFormat("#,##0.00");
        Scanner keyboard = new Scanner (System.in);

        /**
          The input output of the program
        */

        System.out.println("Thomas Zangari\n\n\n");

		System.out.print("Package weight:");       // input/output for the package weight.
		packageWeight = keyboard.nextDouble();

		System.out.print("Zone (A-D) or (a-d):"); // input/output for the area code.
		zone = keyboard.nextLine();

        zone = keyboard.nextLine();    //
        zone1 = zone.charAt(0);        // changing the input of the area-code in a char variable.

		System.out.print("Special Service (1-3):" ); // input/output for the special service.
		specialService = keyboard.nextInt();

		System.out.print("Hazardous Shipment Code (1-3):");// input/output for hazardous shipment
        hazardCode = keyboard.nextInt();

        /** the nested if-else if decision structure for area code A || a.
        */

        if (zone1 == 'A'|| zone1 == 'a')
        {
			if (specialService == 1) // if statment for special-code 1 with hazard code 1,2,3 and defoult.
               if (hazardCode == 1)
               {
                  System.out.println("------------------------------------------------------------");
                  System.out.println("Special Service:"+SPECIALSERVICE_1 +"\nHazardous Shipment Code:" + HAZARDCODE_1+
				                       "\nShiping Cost:$"+formatter.format (packageWeight * AREA_A)+"\n");
			   }
			   else if (hazardCode == 2)
			   {
				  System.out.println("------------------------------------------------------------");
				  System.out.println("Special Service:"+SPECIALSERVICE_1);
				  System.out.println("Shipping Cost:$" + formatter.format(packageWeight * AREA_A * HAZARDCODE_2)+"\n");
			   }
			   else if(hazardCode == 3)
               {
				   System.out.println("------------------------------------------------------------");
				   System.out.println("Special Service:"+SPECIALSERVICE_1);
				   System.out.println("Shipping Cost:$" + formatter.format((packageWeight * AREA_A) * HAZARDCODE_3 +
				                      +(packageWeight * AREA_A))+"\n");
		       }
		       else
		       {
				   System.out.println("--------------------------------------------");
				   System.out.println("Zone (A-D) or (a-d):" +zone1);
				   System.out.println("Special Service (1-3):" + specialService );
				   System.out.println ("Hazardous Shipment Code (1-3): invalid entry:"+hazardCode+"\n");

		       }
            else if (specialService == 2)// if statment for special-code 2 with hazard code 1,2,3 and defoult.
               if (hazardCode == 1)
               {
            	   System.out.println("------------------------------------------------------------");
            	   System.out.println("Hazardous Shipment Code: " + HAZARDCODE_1 + "\nShiping Cost:$"
            	                       + formatter.format(packageWeight * AREA_A + SPECIALSERVICE_2)+"\n");
		       }
			   else if (hazardCode == 2)
			   {
				   System.out.println("------------------------------------------------------------");
				   System.out.println("Shipping Cost:$" + formatter.format((packageWeight * AREA_A + SPECIALSERVICE_2) * HAZARDCODE_2 +
				                      +(packageWeight * AREA_A + SPECIALSERVICE_2))+"\n");
			   }
			   else if (hazardCode ==3)
			   {
				   System.out.println("------------------------------------------------------------");
				   System.out.println("Shipping Cost:$" + formatter.format((packageWeight * AREA_A + SPECIALSERVICE_2) * HAZARDCODE_3 +
				                      +(packageWeight * AREA_A + SPECIALSERVICE_2))+"\n");
			   }
			   else
			   {
				   System.out.println("--------------------------------------------");
				   System.out.println("Zone (A-D) or (a-d):" + zone1);
				   System.out.println("Special Service (1-3):" + specialService);
				   System.out.println ("Hazardous Shipment Code (1-3): invalid entry:"+hazardCode+"\n");

			   }



           else if (specialService == 3) // nested if/else if statment for special-code 3 with hazard code 1,2,3 and defoult.
		        if (hazardCode == 1)
		        {
				   System.out.println("------------------------------------------------------------");
				   System.out.println("Hazardous Shipment Code:" + HAZARDCODE_1 + "\nShiping Cost:$" +
				                       formatter.format(packageWeight * AREA_A + SPECIALSERVICE_3)+"\n");
			    }
			    else if (hazardCode == 2)
			    {
			       System.out.println("------------------------------------------------------------");
			       System.out.println("Shipping Cost:$" + formatter.format((packageWeight * AREA_A + SPECIALSERVICE_3) * HAZARDCODE_2 +
			                          +(packageWeight * AREA_A + SPECIALSERVICE_3))+"\n");
			    }
			    else if (hazardCode ==3)
			    {
				   System.out.println("------------------------------------------------------------");
				   System.out.println("Shipping Cost:$" + formatter.format((packageWeight * AREA_A + SPECIALSERVICE_3) * HAZARDCODE_3 +
				                      +(packageWeight * AREA_A + SPECIALSERVICE_3))+"\n");
			    }
			    else
		        {
				   System.out.println("--------------------------------------------");
				   System.out.println("Zone (A-D) or (a-d):" + zone1);
				   System.out.println("Special Service (1-3):" + specialService );
				   System.out.println ("Hazardous Shipment Code (1-3): invalid entry:"+hazardCode+"\n");

		        }

            else  // defoult setting for area code A || a.

                if (hazardCode > 3)
                {
				   System.out.println("--------------------------------------------");
                   System.out.println("Zone (A-D) or (a-d):" + zone1);
                   System.out.println("Special Service (1-3): invalid entry:"+specialService);
                   System.out.println("Hazardous Shipment Code (1-3): invalid entry:"+hazardCode+"\n");

			    }
                else
                {
				   System.out.println("--------------------------------------------");
                   System.out.println("Zone (A-D) or (a-d):" + zone);
                   System.out.println("Special Service (1-3): invalid entry:"+specialService);
                   System.out.println ("Hazardous Shipment Code (1-3):"+ hazardCode +"\n");

			    }
	    }
	    /** the nested if-else if decision structure for area code B || b.
        */

	   else if (zone1 == 'B'|| zone1 == 'b')
        {
			if (specialService == 1)  // if statment for special-code 1 with hazard code 1,2,3 and defoult.
               if (hazardCode == 1)
               {
				   System.out.println("------------------------------------------------------------");
				   System.out.println("Special Service:"+SPECIALSERVICE_1+"\nHazardous Shipment Code:" +HAZARDCODE_1+
				                       "\nShiping Cost:$"+ formatter.format(packageWeight * AREA_B)+"\n");
			   }
			   else if (hazardCode == 2)
			   {
				   System.out.println("------------------------------------------------------------");
				   System.out.println("Special Service:"+SPECIALSERVICE_1);
				   System.out.println("Shipping Cost:$" + formatter.format((packageWeight * AREA_B) * HAZARDCODE_2 +
				                      +(packageWeight * AREA_B))+"\n");
			   }
			   else if(hazardCode == 3)
               {
				   System.out.println("------------------------------------------------------------");
				   System.out.println("Special Service:"+SPECIALSERVICE_1);
				   System.out.println("Shipping Cost:$" + formatter.format((packageWeight * AREA_B) * HAZARDCODE_3 +
				                      +(packageWeight * AREA_B))+"\n");
		       }
		       else
		       {
				   System.out.println("--------------------------------------------");
				   System.out.println("Zone (A-D) or (a-d):" + zone1);
				   System.out.println("Special Service (1-3):" + specialService );
				   System.out.println ("Hazardous Shipment Code (1-3): invalid entry:"+hazardCode+"\n");

		       }
            else if (specialService == 2)// if statment for special-code 2 with hazard code 1,2,3 and defoult.
               if (hazardCode == 1)
               {
            	   System.out.println("------------------------------------------------------------");
            	   System.out.println("Hazardous Shipment Code: "+HAZARDCODE_1+"\nShiping Cost:$"
            	                      + formatter.format(packageWeight * AREA_B + SPECIALSERVICE_2)+"\n");
		       }
			   else if (hazardCode == 2)
			   {
				   System.out.println("------------------------------------------------------------");
				   System.out.println("Shipping Cost:$" + formatter.format((packageWeight * AREA_B + SPECIALSERVICE_2) * HAZARDCODE_2 +
				                      +(packageWeight * AREA_B + SPECIALSERVICE_2))+"\n");
			   }
			   else if (hazardCode ==3)
			   {
				   System.out.println("------------------------------------------------------------");
				   System.out.println("Shipping Cost:$" + formatter.format((packageWeight * AREA_B + SPECIALSERVICE_2) * HAZARDCODE_3 +
				                      +(packageWeight * AREA_B + SPECIALSERVICE_2))+"\n");
			   }
			   else
			   {
				   System.out.println("--------------------------------------------");
				   System.out.println("Zone (A-D) or (a-d):" + zone1);
				   System.out.println("Special Service (1-3):" + specialService );
				   System.out.println ("Hazardous Shipment Code (1-3): invalid entry:"+hazardCode+"\n");

			   }



           else if (specialService == 3)// if statment for special-code 2 with hazard code 1,2,3 and defoult.
		        if (hazardCode == 1)
		        {
				   System.out.println("------------------------------------------------------------");
				   System.out.println("Hazardous Shipment Code:" + HAZARDCODE_1 + "\nShiping Cost:$"
			                           + formatter.format(packageWeight * AREA_B + SPECIALSERVICE_3)+"\n");
			    }
			    else if (hazardCode == 2)
			    {
			       System.out.println("------------------------------------------------------------");
			       System.out.println("Shipping Cost:$" + formatter.format((packageWeight * AREA_B + SPECIALSERVICE_3) * HAZARDCODE_2 +
			                          +(packageWeight * AREA_B + SPECIALSERVICE_3))+"\n");
			    }
			 else if (hazardCode ==3)
			    {
				   System.out.println("------------------------------------------------------------");
				   System.out.println("Shipping Cost:$" + formatter.format((packageWeight *AREA_B + SPECIALSERVICE_3) * HAZARDCODE_3 +
				                      +(packageWeight * AREA_B + SPECIALSERVICE_3))+"\n");
			    }
			 else
		        {
				  System.out.println("--------------------------------------------");
				  System.out.println("Zone (A-D) or (a-d):" + zone1);
				  System.out.println("Special Service (1-3):" + specialService );
				  System.out.println ("Hazardous Shipment Code (1-3): invalid entry:"+hazardCode+"\n");

		        }

          else       // defoult setting for area code B || b.

             if (hazardCode > 3)
                {
				  System.out.println("--------------------------------------------");
                  System.out.println("Zone (A-D) or (a-d):" + zone1);
                  System.out.println("Special Service (1-3): invalid entry:"+ specialService);
                  System.out.println("Hazardous Shipment Code (1-3): invalid entry:"+hazardCode+"\n");

			    }
             else
                {
				   System.out.println("--------------------------------------------");
                   System.out.println("Zone (A-D) or (a-d):" + zone1);
                   System.out.println("Special Service (1-3): invalid entry:"+specialService);
                   System.out.println ("Hazardous Shipment Code (1-3):"+ hazardCode+"\n");

			    }
	    }

	        /**
	           the nested if-else if decision structure for area code C || c.
            */

	 else if (zone1 == 'C'|| zone1 == 'c')
        {
			if (specialService == 1)     // if statment for special-code 1 with hazard code 1,2,3 and defoult.
               if (hazardCode == 1)
               {
				  System.out.println("------------------------------------------------------------");
				  System.out.println("Special Service:"+SPECIALSERVICE_1+"\nHazardous Shipment Code:"+HAZARDCODE_1+
				                     "\nShiping Cost:$"+ formatter.format(packageWeight * AREA_C)+"\n");
			   }
			   else if (hazardCode == 2)
			   {
				  System.out.println("------------------------------------------------------------");
				  System.out.println("Special Service:"+SPECIALSERVICE_1);
				  System.out.println("Shipping Cost:$" + formatter.format((packageWeight * AREA_C) * HAZARDCODE_2 +
				                     +(packageWeight * AREA_C))+"\n");
			   }
			   else if(hazardCode == 3)
               {
				  System.out.println("------------------------------------------------------------");
				  System.out.println("Special Service:"+SPECIALSERVICE_1);
				  System.out.println("Shipping Cost:$" + formatter.format((packageWeight * AREA_C) * HAZARDCODE_3 +
				                     +(packageWeight * AREA_C))+"\n");
		       }
		       else
		       {
				   System.out.println("--------------------------------------------");
				   System.out.println("Zone (A-D) or (a-d):" + zone1);
				   System.out.println("Special Service (1-3):" + specialService );
				   System.out.println ("Hazardous Shipment Code (1-3): invalid entry:"+hazardCode+"\n");

		       }
            else if (specialService == 2) // if statment for special-code 2 with hazard code 1,2,3 and defoult.
               if (hazardCode == 1)
               {
            	  System.out.println("------------------------------------------------------------");
            	  System.out.println("Hazardous Shipment Code: " + HAZARDCODE_1 + "\nShiping Cost:$" +
			                          formatter.format(packageWeight * AREA_C + SPECIALSERVICE_2)+"\n");
		       }
			   else if (hazardCode == 2)
			   {
				  System.out.println("Shipping Cost:$" + formatter.format((packageWeight * AREA_C + SPECIALSERVICE_2) *HAZARDCODE_2 +
				                     +(packageWeight * AREA_C + SPECIALSERVICE_2))+"\n");
			   }
			   else if (hazardCode ==3)
			   {
				  System.out.println("------------------------------------------------------------");
				  System.out.println("Shipping Cost:$" + formatter.format((packageWeight * AREA_C + SPECIALSERVICE_2) * HAZARDCODE_3 +
				                     +(packageWeight * AREA_C + SPECIALSERVICE_2))+"\n");
			   }
			   else
			   {
				   System.out.println("--------------------------------------------");
				   System.out.println("Zone (A-D) or (a-d):" + zone1);
				   System.out.println("Special Service (1-3):" + specialService );
				   System.out.println ("Hazardous Shipment Code (1-3): invalid entry:"+hazardCode+"\n");

			   }



         else if (specialService == 3) // if statment for special-code 3 with hazard code 1,2,3 and defoult.
		     if (hazardCode == 1)
		     {
				System.out.println("------------------------------------------------------------");
				System.out.println("Hazardous Shipment Code:" + HAZARDCODE_1 + "\nShiping Cost:$" +
			                        formatter.format(packageWeight * AREA_C + SPECIALSERVICE_3)+"\n");
			 }
			 else if (hazardCode == 2)
			 {
			    System.out.println("------------------------------------------------------------");
			    System.out.println("Shipping Cost:$" + formatter.format((packageWeight * AREA_C + SPECIALSERVICE_3) * HAZARDCODE_2 +
			                       +(packageWeight * AREA_C + SPECIALSERVICE_3))+"\n");
			 }
			 else if (hazardCode ==3)
			 {
				System.out.println("------------------------------------------------------------");
				System.out.println("Shipping Cost:$" + formatter.format((packageWeight * AREA_C + SPECIALSERVICE_3) * HAZARDCODE_3 +
				                   +(packageWeight * AREA_C + SPECIALSERVICE_3))+"\n");
			 }
			 else
		     {
				  System.out.println("--------------------------------------------");
				  System.out.println("Zone (A-D) or (a-d):" + zone1);
				  System.out.println("Special Service (1-3):" + specialService );
				  System.out.println ("Hazardous Shipment Code (1-3): invalid entry:"+hazardCode+"\n");

		     }

        else       // defoult setting for area code C || c.

            if (hazardCode > 3)
            {
			 System.out.println("--------------------------------------------");
             System.out.println("Zone (A-D) or (a-d):" + zone1);
             System.out.println("Special Service (1-3): invalid entry:"+specialService);
             System.out.println("Hazardous Shipment Code (1-3): invalid entry:"+hazardCode+"\n");

			}
            else
            {
				System.out.println("--------------------------------------------");
                System.out.println("Zone (A-D) or (a-d):" + zone1);
                System.out.println("Special Service (1-3): invalid entry:"+specialService);
                System.out.println ("Hazardous Shipment Code (1-3):"+ hazardCode+"\n");
                ;
			}
	    }

	    /**
	        the nested if-else if decision structure for area code C || c.
         */
	 else if (zone1 == 'D'|| zone1 == 'd')
        {
			if (specialService == 1)      // if statment for special-code 1 with hazard code 1,2,3 and defoult.
               if (hazardCode == 1)
               {
				  System.out.println("------------------------------------------------------------");
				  System.out.println("Special Service:"+SPECIALSERVICE_1+"\nHazardous Shipment Code:"+HAZARDCODE_1+
				                       "\nShiping Cost:$"+ formatter.format(packageWeight * AREA_D)+"\n");
			   }
			   else if (hazardCode == 2)
			   {
				  System.out.println("------------------------------------------------------------");
				  System.out.println("Special Service:"+SPECIALSERVICE_1);
				  System.out.println("Shipping Cost:$" + formatter.format((packageWeight * AREA_D) * HAZARDCODE_2 +
				                     +(packageWeight * AREA_D))+"\n");
			   }
			   else if(hazardCode == 3)
               {
				  System.out.println("------------------------------------------------------------");
				  System.out.println("Special Service:"+SPECIALSERVICE_1);
				  System.out.println("Shipping Cost:$" + formatter.format((packageWeight * AREA_D)* HAZARDCODE_3 +
				                      +(packageWeight * AREA_D))+"\n");
		       }
		       else
		       {
				   System.out.println("--------------------------------------------");
				   System.out.println("Zone (A-D) or (a-d):" + zone1);
				   System.out.println ("Hazardous Shipment Code (1-3): invalid entry:"+ hazardCode );
                   System.out.println("Special Service (1-3):" + specialService+"\n");
		       }
            else if (specialService == 2)  // if statment for special-code 2 with hazard code 1,2,3 and defoult.
               if (hazardCode == 1)
               {
            	  System.out.println("------------------------------------------------------------");
            	  System.out.println("Hazardous Shipment Code: "+HAZARDCODE_1+"\nShiping Cost:$" +
			                          formatter.format(packageWeight * AREA_D + SPECIALSERVICE_2)+"\n");
		       }
			   else if (hazardCode == 2)
			   {
				  System.out.println("------------------------------------------------------------");
				  System.out.println("Shipping Cost:$" + formatter.format((packageWeight * AREA_D + SPECIALSERVICE_2) * HAZARDCODE_2 +
				                     +(packageWeight * AREA_D + SPECIALSERVICE_2))+"\n");
			   }
			   else if (hazardCode ==3)
			   {
				  System.out.println("------------------------------------------------------------");
				  System.out.println("Shipping Cost:$" + formatter.format((packageWeight * AREA_D + SPECIALSERVICE_2) *HAZARDCODE_3 +
				                      +(packageWeight * AREA_D + SPECIALSERVICE_2))+"\n");
			   }
			   else
			   {
				   System.out.println("--------------------------------------------");
				   System.out.println("Zone (A-D) or (a-d):" + zone1);
				   System.out.println ("Hazardous Shipment Code (1-3): invalid entry:"+hazardCode);
                   System.out.println("Special Service (1-3):" + specialService + "\n"  );
			   }



           else if (specialService == 3)// if statment for special-code 3 with hazard code 1,2,3 and defoult.
		       if (hazardCode == 1)
		       {
				 System.out.println("--------------------------------------------");
				 System.out.println("Hazardous Shipment Code:"+HAZARDCODE_1+"\nShiping Cost:$" +
			                          formatter.format(packageWeight * AREA_D + SPECIALSERVICE_3)+"\n");
			   }
			   else if (hazardCode == 2)
			   {
			      System.out.println("--------------------------------------------");
			      System.out.println("Shipping Cost:$" + formatter.format((packageWeight * AREA_D + SPECIALSERVICE_3) * HAZARDCODE_2+
			                         +(packageWeight * AREA_D + SPECIALSERVICE_3))+"\n");
			   }
			   else if (hazardCode ==3)
			   {
				  System.out.println("--------------------------------------------");
				  System.out.println("Shipping Cost:$" + formatter.format((packageWeight * AREA_D + SPECIALSERVICE_3)* HAZARDCODE_3+
				                     +(packageWeight * AREA_D + SPECIALSERVICE_3))+"\n");
			   }
			   else
		       {
				  System.out.println("--------------------------------------------");
				  System.out.println("Zone (A-D) or (a-d):" + zone1);
				  System.out.println ("Hazardous Shipment Code (1-3): invalid entry:"+hazardCode);
				  System.out.println("Special Service (1-3):" + specialService+"\n" );
		       }

            else    // defoult setting for area code C || c.

               if (hazardCode > 3)
               {
				  System.out.println("--------------------------------------------");
                  System.out.println("Zone (A-D) or (a-d):" + zone1);
                  System.out.println("Hazardous Shipment Code (1-3): invalid entry"+hazardCode);
                  System.out.println("Special Service (1-3): invalid entry:"+specialService+"\n");
			   }
               else
               {
				  System.out.println("--------------------------------------------");
                  System.out.println("Zone (A-D) or (a-d):" + zone1);
                  System.out.println("Special Service (1-3): invalid entry:"+specialService);
                  System.out.println ("Hazardous Shipment Code (1-3):"+ hazardCode+"\n");

			   }
	    }
	    /**
	      defoult setting of the if/elseif structure with the values over the range of the input for having a shiping cost.
	    */

	    else
        {
               if (hazardCode > 3 && specialService > 3)
               {
				  System.out.println("--------------------------------------------");
			      System.out.println("Zone (A-D) or (a-d): invalid entry:"+zone1);
			      System.out.println("Special Service (1-3): invalid entry:"+specialService);
			      System.out.println("Hazardous Shipment Code (1-3): invalid entry:"+hazardCode+"\n");


               }
               else if (specialService > 3)
               {
				  System.out.println("--------------------------------------------");
			      System.out.println("Zone (A-D) or (a-d): invalid entry:"+zone1);
			      System.out.println("Special Service (1-3): invalid entry:"+specialService);
			      System.out.println ("Hazardous Shipment Code (1-3):"+ hazardCode+ "\n");


		       }
		       else if (hazardCode > 3)
		       {
				  System.out.println("--------------------------------------------");
				  System.out.println("Zone (A-D) or (a-d): invalid entry:"+zone1);
				  System.out.println("Special Service (1-3):"+ specialService);
				  System.out.println ("Hazardous Shipment Code (1-3):invalid entry:"+hazardCode+"\n");


			   }
               else
               {
				  System.out.println("--------------------------------------------");
			      System.out.println("Zone (A-D) or (a-d): invalid entry:"+zone1);
			      System.out.println("Special Service (1-3):" + specialService );
			      System.out.println ("Hazardous Shipment Code (1-3):"+ hazardCode+"\n");


			   }
		}
	}
}







 


















