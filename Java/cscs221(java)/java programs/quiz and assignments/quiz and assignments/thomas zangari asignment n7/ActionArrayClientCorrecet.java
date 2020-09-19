//Thomas Zangari assignemntJ7 COMI 1510 Summer  2013.

/* KJ
Thomas you got this to work well! Good for you. There are some issues with it where it
could be improved. Please see my comments about those places. Overall a nice job.
*/

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.util.Random;
import java.text.DecimalFormat;

// KJ this should be a Javadoc comment
/*
    The ActionArrayClient class creates a GUI application that creates a array of random numbers,
    and it displays the content in a JOptionPaneMessage.Calculates :  average,  minimum, maximum value,
    and it display's it in a JTextField. Sorts the array from Max to Min, and displays
    the content in a JOptionPane.The decision process is developed in several method.The
    panel hold 6 JRadioButtons a JButton that has the actionLisener and a JTextField.
 */

// KJ this is not a client class in the same sense as we have used it this semester.
// It should be named more appropriately.
public class ActionArrayClientCorrecet extends JFrame

{
	private JPanel infoPanel;   //Information on what to do panel.
	private JPanel arrayPanel;  //Holds the JRadioButtons panel.
	private JPanel buttonPanel; // Holds the JButton panel.
	private JPanel textPanel;   // Holds the JTextField panel.


	private final int WINDOW_WIDTH = 340;   // the width of the window.
	private final int WINDOW_HEIGHT = 230;  // the height of the window.

    // for the buttonPanel
	private JButton processAction;          // to calculates the varius JRadioButtons.

	//for the JTextFieldPanel
	private JTextField arrayAnswer;;        // Display's the average, the Min, and the Max value.

	private JLabel info;                    // for the information panel.

    //for the RadioPanel
	private JRadioButton newArray;          //To select a new array.
	private JRadioButton  sortArray;        // To sort the array.
	private JRadioButton showArrayMax;      // To calculate the max value.
	private JRadioButton displayArray;      // To display's the array
	private JRadioButton showArrayAverage;  // To calculate the average
	private JRadioButton showArrayMin;      // To calculate the min value

	private ButtonGroup bg;                 // Radio button group.

	private int[] array;                    // The declaring the array

	// KJ these last 3 are not necessary as fields. They should be declared locally, inside
	// the methods that need them. You should be using the array's length property inside
	// your methods rather than this variable.
	private int arrayLength;            // The array lenght variable.

    private String show = "";               // String that holds the array content for Displaying with JOoptionPane.
	private String show1 = "";
	/**
	Constructor
	*/
	public  ActionArrayClient()
	{
        // Title of the window
		setTitle("Thomas Zangari");

        // Seting the size of the window
        setSize(WINDOW_WIDTH, WINDOW_HEIGHT);

        // Closing the window when
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

		//Setting the Layout manager to Flow
		setLayout(new FlowLayout(FlowLayout.CENTER));

        //Setting the Layout manager to Border
		setLayout(new BorderLayout());

        // Creating 2 panels.
	    JPanel panel1 = new JPanel();
        JPanel panel2 = new JPanel();

        //Creating the customPanels
	    buildInfoPanel();
		buildArrayPanel();
		buildButtonPanel();
		buildTextPanel();
        //Adding the panels
		panel1.add(infoPanel);
		panel1.add(arrayPanel);
		panel1.add(buttonPanel);
		panel2.add(textPanel);

		//setting the panels in the regions
		add(panel1,BorderLayout.CENTER);
		add(panel2, BorderLayout.SOUTH);

        // displays the windows
		setVisible(true);
	}
	/**
	 The buildInfoPanel method builds the info panel
	 */
	private void buildInfoPanel()
    {
		//Panel for the infoPanel
		infoPanel = new JPanel();

        // creating a Jlabel
		info = new JLabel("Choose an Action");

        // Adding the Jlabel to the infoPanel
		infoPanel.add(info);



	}
    /**
    The buildButtonGroup method builds the button panel
    */

	private void buildButtonPanel()
	{
		//Panel for the buttonPanel.
		buttonPanel = new JPanel();

        //Creating a JButton.
        processAction = new JButton("PROCESS ACTION");
        //ActionListener
        processAction.addActionListener (new RadioButtonListener());

        //Adding the processAction to the buttonPanel
        buttonPanel.add(processAction);

	}
    /**
     The buildArrayPanel method build the JRadioButtons
    */
	private void buildArrayPanel()
	{
		//Panel for the arrayPanel
        arrayPanel = new JPanel();
        //setting the LayoutManager to gridLayout
		arrayPanel.setLayout(new GridLayout(3,2));

        // Creating the Radio buttons
    	newArray = new JRadioButton("New Array", true);
		sortArray = new JRadioButton("Sort Array",false);
		displayArray = new JRadioButton("Display Array",false);
		showArrayMax = new JRadioButton("Show Array Max",false);
		showArrayAverage = new JRadioButton("Show Array Average",false);
		showArrayMin = new JRadioButton("Show Array Min",false);


        //Grouping the radio buttons.
		bg = new ButtonGroup();
		bg.add(newArray);
		bg.add(sortArray);
		bg.add(showArrayMax);
		bg.add(displayArray);
		bg.add(showArrayAverage);
		bg.add(showArrayMin);

        //Adding the radio buttons to the panel
		arrayPanel.add(newArray);
		arrayPanel.add(displayArray);
		arrayPanel.add(sortArray);
		arrayPanel.add(showArrayAverage);
		arrayPanel.add(showArrayMax);
		arrayPanel.add(showArrayMin);
	}
	/**
     the buildTextPanel method builds the JTextPanel
     */
	private void buildTextPanel()
    {
	   //panel for the TextPanel
	   textPanel = new JPanel();
	   //creating a JTextField
	   arrayAnswer = new JTextField(29);
	   //adding the arrayAnswer to the textPanel
	   textPanel.add(arrayAnswer);


	}
    /**
	      Private inner class that handles the event when
	      the user clicks the Process button.
   */
   // KJ the Process button is NOT a Radio Button, so this is not named appropriately.
    private class RadioButtonListener implements ActionListener
    {
		public void actionPerformed(ActionEvent e)
		{

			// KJ you should only be calling the method that corresponds to the
			// selected radio button. It's a waste of time to call methods not
			// being used.
			// KJ in Java the method names should begin with a lowercase letter.
			// KJ this should be an if/else if series. Only one radio button at a time
			// is selected.
            //Call for having a new array.
            NewArrayMethod();
            //Call for sorting the array.
            NewSortArrayMethod();
            //Call for having the max value
		    NewShowArrayMaxMethod();
            //Call for having the min value
			NewShowArrayMinMethod();
            // Call for having the average
			NewShowArrayAverageMethod();
            // Call for displaying
			NewDisplayArrayMethod();


		}
		/**
		The NewArrayMethod creates a new array
		*/
		private void  NewArrayMethod()
	    {

			String inputString; // to hold the JOptionPane input

            // if newArray JRadioButton is Selected.
			if(newArray.isSelected())
			{
				inputString = JOptionPane.showInputDialog("What size do you whant the Array?");
			 	arrayLength  = Integer.parseInt(inputString);
                // if statment for invalid entry or process the new array
			    if ( arrayLength <= 1)
			    {
					// KJ This is not a helpful message. It should say something like
					// "Invalid length"
					 JOptionPane.showMessageDialog(null,"No futher process");
			 	}
			 	else // create a new array
			    {
					arrayAnswer.setText("NEW ARRAY:SIZE " + arrayLength);
					int random1;
					array = new int[arrayLength];

					for (int i = 0; i < arrayLength; i++)
					{
						// KJ it is not appropriate to declare this here. It should be
						// either declared as a field or within the method here, but
						// certainly not in a loop.
						Random randomNumbers = new Random();

						random1 = randomNumbers.nextInt(100)+1;

						array[i] =  random1;

					}


				}

			}


	    }
	    /**
	      NewSortArrayMethod method sorts the array from Min to Max.
	     */
		private void NewSortArrayMethod()
	    {    // if sortArray RadioJButton is selcted
		     if(sortArray.isSelected())
		     {
				 if (array == null)
				 {
					// KJ This is not a helpful message. It should say something like
					// "No array has been created"
				    JOptionPane.showMessageDialog(null,"No Futher Processing");
				 }
                 else // sort the array
                 {
					 boolean swap;
					 int temp = 0 ;

					 do
					 {
						 swap = false;
						 for(int i = 0; i < (arrayLength - 1) ;i++)
						 {
								if (array[i] > array[i+1])
								{
									temp = array[i];
								    array[i] = array[i+1];
								    array[i+1] = temp;
								    swap = true;


								}
						 }

		             }while(swap);


					 arrayAnswer.setText("ARRAY IS SORTED");
			     }

		     }
	   }
	   /**
	   The NewShowArrayMaxMethod method finds the and displays the max value
	   */
	   private void NewShowArrayMaxMethod()
	   {
           //if showArray JRadioButton is Selected
		   if(showArrayMax.isSelected())
		   {
			   if(array == null)
			   {
					// KJ This is not a helpful message. It should say something like
					// "No array has been created"
			   		JOptionPane.showMessageDialog(null,"No Futher Processing");
		       }
               else // find the array max value
               {
				   int max = array[0];
				   for(int i = 1; i < arrayLength;i++)
				   {
				    	if (array[i] > max)
				   		    max = array[i];
	            	}
				   arrayAnswer.setText("ARRAY:MAX " + max  );
		       }


		   }
	   }
	   /**
	     The NewShowArrayMinMethod method finds the min value and it displays it
	   */
	   private void NewShowArrayMinMethod()
	   {  //if showArrayMin JRadioButton is selected
		  if(showArrayMin.isSelected())
		  {
			  if(array == null)
			  {
					// KJ This is not a helpful message. It should say something like
					// "No array has been created"
				  JOptionPane.showMessageDialog(null,"No Futher Processing");
		      }
		      else // find the min value
		      {
				  int min = array[0];
				  for(int i = 1; i < arrayLength;i++)
				  {
				   	if (array[i] < min)
				  	min = array[i];
				  }

				  arrayAnswer.setText("ARRAY:MIN " + min );
			  }


		  }
	  }
	  /**
	  The NewShowAverageMethod method finds the average and it displays it
	  */
	  private void NewShowArrayAverageMethod()
	  {
		 DecimalFormat formatter = new DecimalFormat(",##0.0");
        //if the showArrayAverage JRadioButton is selected
		if(showArrayAverage.isSelected())
        {
			if(array == null)
			{
					// KJ This is not a helpful message. It should say something like
					// "No array has been created"
		   		JOptionPane.showMessageDialog(null,"No Futher Processing");
		    }
		    else // find the average.
            {
				double total = 0;
				for ( int i = 0; i < arrayLength;i++)
					// KJ indent inside loop
				total += array[i];
		        double average = total/arrayLength;

		        arrayAnswer.setText("AVERAGE ARRAY: " +formatter.format(average) );
	        }
		}
	 }
	 /**
	   The NewDisplayArrayMethod method displays the new array and the sorted array
	   */
	 private void NewDisplayArrayMethod()
	 {
		if(displayArray.isSelected())
		{
			if (array == null)
			{
					// KJ This is not a helpful message. It should say something like
					// "No array has been created"
				JOptionPane.showMessageDialog(null,"No Futher Processing");
		    }
            else // display the new array or the sorted array
            {

				for (int i = 0; i < arrayLength;i++)
				 {
                     show += array[i] + "   ";
                     if((i + 1) % 10 == 0)
                     	// KJ indent inside if
                     show +="\n";

				 }
                 arrayAnswer.setText("ARRAY DISPLAYED"  );
                 JOptionPane.showMessageDialog(null,"The Array Contains \n"+ show + " ");

                 // KJ this is not a blank string. A blank/empty string is "".
		         show = " ";// setting show variable back to blank

		    }

        }
    }
 }
 /**
 The main method executes the program
 */
 public static void main(String[] args)
 {
 	   ActionArrayClient myArray = new ActionArrayClient();
 }

}


















