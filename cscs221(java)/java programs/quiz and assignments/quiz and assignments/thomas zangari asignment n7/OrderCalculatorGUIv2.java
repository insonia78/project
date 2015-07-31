
import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.text.DecimalFormat;

/**
   The OrderCalculatorGUIv2 class creates the GUI for the
   Brandi's Bagel House application.
   This version uses one class to create the same interface
   as the book's version of OrderCalculatorGUI (which uses
   several classes).
*/

public class OrderCalculatorGUIv2 extends JFrame
{
   private JPanel bagelPanel;     		// Bagel panel
   private JPanel toppingPanel; 		// Topping panel
   private JPanel coffeePanel;    		// Coffee panel
   private JPanel greetingPanel;  		// To display a greeting
   private JPanel buttonPanel;    		// To hold the buttons

   // for the buttonPanel
   private JButton calcButton;    		// To calculate the cost
   private JButton exitButton;    		// To exit the application

   // for the greetingPanel
   private JLabel greeting;				// For the greetingPanel

   // for the bagelPanel
   private JRadioButton whiteBagel;  	// To select white
   private JRadioButton wheatBagel;  	// To select wheat
   private ButtonGroup bagelBg;      	// Radio button group

   // for the coffeePanel
   private JRadioButton noCoffee;      	// To select no coffee
   private JRadioButton regularCoffee; 	// To select regular coffee
   private JRadioButton decafCoffee;   	// To select decaf
   private JRadioButton cappuccino;    	// To select cappuccino
   private ButtonGroup coffeeBg;       	// Radio button group

	// for the toppingPanel
   private JCheckBox creamCheese;  		// To select cream cheese
   private JCheckBox butter;       		// To select butter
   private JCheckBox peachJelly;   		// To select peach jelly
   private JCheckBox blueberryJam; 		// To select blueberry jam

   private final double TAX_RATE = 0.06; // Sales tax rate

   /**
      Constructor
   */

   public OrderCalculatorGUIv2()
   {
      // Display a title.
      setTitle("Order Calculator");

      // Specify an action for the close button.
      setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

      // Create a BorderLayout manager.
      setLayout(new BorderLayout());

      // Create the custom panels.
      buildGreetingPanel();
      buildBagelPanel();
      buildToppingPanel();
      buildCoffeePanel();

      // Create the button panel.
      buildButtonPanel();

      // Add the components to the content pane.
      add(greetingPanel, BorderLayout.NORTH);
      add(bagelPanel, BorderLayout.WEST);
      add(toppingPanel, BorderLayout.CENTER);
      add(coffeePanel, BorderLayout.EAST);
      add(buttonPanel, BorderLayout.SOUTH);

      // Pack the contents of the window and display it.
      pack();
      setVisible(true);
   }

   /**
      The buildButtonPanel method builds the button panel.
   */

   private void buildButtonPanel()
   {
      // Create a panel for the buttons.
      buttonPanel = new JPanel();

      // Create the buttons.
      calcButton = new JButton("Calculate");
      exitButton = new JButton("Exit");

      // Register the action listeners.
      calcButton.addActionListener(new CalcButtonListener());
      exitButton.addActionListener(new ExitButtonListener());

      // Add the buttons to the button panel.
      buttonPanel.add(calcButton);
      buttonPanel.add(exitButton);
   }

   private void buildBagelPanel()
   {
		// Create a panel for bagels
		bagelPanel = new JPanel();

      // Create a GridLayout manager with
      // two rows and one column.
      bagelPanel.setLayout(new GridLayout(2, 1));

      // Create the radio buttons.
      whiteBagel = new JRadioButton("White", true);
      wheatBagel = new JRadioButton("Wheat");

      // Group the radio buttons.
      bagelBg = new ButtonGroup();
      bagelBg.add(whiteBagel);
      bagelBg.add(wheatBagel);

      // Add a border around the panel.
      bagelPanel.setBorder(
			BorderFactory.createTitledBorder("Bagel"));

      // Add the radio buttons to the panel.
      bagelPanel.add(whiteBagel);
      bagelPanel.add(wheatBagel);
	}

	private void buildGreetingPanel()
	{
		// Create a panel for greeting
		greetingPanel = new JPanel();

      // Create the label.
      greeting = new JLabel("Welcome to Brandi's Bagel House");

      // Add the label to this panel.
      greetingPanel.add(greeting);
	}

	private void buildCoffeePanel()
	{
		// Create a panel for coffees
		coffeePanel = new JPanel();

      // Create a GridLayout manager with
      // four rows and one column.
      coffeePanel.setLayout(new GridLayout(4, 1));

      // Create the radio buttons.
      noCoffee = new JRadioButton("None");
      regularCoffee =
      	new JRadioButton("Regular coffee", true);
      decafCoffee = new JRadioButton("Decaf coffee");
      cappuccino = new JRadioButton("Cappuccino");

      // Group the radio buttons.
      coffeeBg = new ButtonGroup();
      coffeeBg.add(noCoffee);
      coffeeBg.add(regularCoffee);
      coffeeBg.add(decafCoffee);
      coffeeBg.add(cappuccino);

      // Add a border around the panel.
      coffeePanel.setBorder(
			BorderFactory.createTitledBorder("Coffee"));

      // Add the radio buttons to the panel.
      coffeePanel.add(noCoffee);
      coffeePanel.add(regularCoffee);
      coffeePanel.add(decafCoffee);
      coffeePanel.add(cappuccino);
	}

	private void buildToppingPanel()
	{
		// Create a panel for toppings
		toppingPanel = new JPanel();

      // Create a GridLayout manager with
      // four rows and one column.
      toppingPanel.setLayout(new GridLayout(4, 1));

      // Create the check boxes.
      creamCheese = new JCheckBox("Cream cheese");
      butter = new JCheckBox("Butter");
      peachJelly = new JCheckBox("Peach jelly");
      blueberryJam = new JCheckBox("Blueberry jam");

      // Add a border around the panel.
      toppingPanel.setBorder(
			BorderFactory.createTitledBorder("Toppings"));

      // Add the check boxes to the panel.
      toppingPanel.add(creamCheese);
      toppingPanel.add(butter);
      toppingPanel.add(peachJelly);
      toppingPanel.add(blueberryJam);
	}

   /**
      Private inner class that handles the event when
      the user clicks the Calculate button.
   */
   private class CalcButtonListener implements ActionListener
   {
      public void actionPerformed(ActionEvent e)
      {
         // Variables to hold the subtotal, tax, and total
         double subtotal, tax, total;

         // Calculate the subtotal.
         subtotal = getBagelCost() +
                    getToppingCost() +
                    getCoffeeCost();

         // Calculate the sales tax.
         tax = subtotal * TAX_RATE;

         // Calculate the total.
         total = subtotal + tax;

         // Create a DecimalFormat object to format output.
         DecimalFormat dollar = new DecimalFormat("0.00");

         // Display the charges.
         JOptionPane.showMessageDialog(null, "Subtotal: $" +
                       dollar.format(subtotal) + "\n" +
                       "Tax: $" + dollar.format(tax) + "\n" +
                       "Total: $" + dollar.format(total));
      }
   }

   /**
      getBagelCost method
      @return The cost of the selected bagel.
   */

   private double getBagelCost()
   {
		// The following constants are used to indicate
		// the cost of each type of bagel.
		final double WHITE_BAGEL = 1.25;
		final double WHEAT_BAGEL = 1.50;

      double bagelCost = 0.0;

      if (whiteBagel.isSelected())
         bagelCost = WHITE_BAGEL;
      else
         bagelCost = WHEAT_BAGEL;

      return bagelCost;
   }

   /**
      getCoffeeCost method
      @return The cost of the selected coffee.
   */

   private double getCoffeeCost()
   {
		// The following constants are used to indicate
		// the cost of coffee.
		final double NO_COFFEE = 0.0;
		final double REGULAR_COFFEE = 1.25;
		final double DECAF_COFFEE = 1.25;
		final double CAPPUCCINO = 2.00;

      double coffeeCost = 0.0;

      if (noCoffee.isSelected())
         coffeeCost = NO_COFFEE;
      else if (regularCoffee.isSelected())
         coffeeCost = REGULAR_COFFEE;
      else if (decafCoffee.isSelected())
         coffeeCost = DECAF_COFFEE;
      else if (cappuccino.isSelected())
         coffeeCost = CAPPUCCINO;

      return coffeeCost;
   }

   /**
      getToppingCost method
      @return The cost of the selected toppings.
   */

   private double getToppingCost()
   {
		// The following constants are used to indicate
		// the cost of toppings.
		final double CREAM_CHEESE = 0.50;
		final double BUTTER = 0.25;
		final double PEACH_JELLY = 0.75;
		final double BLUEBERRY_JAM = 0.75;

      double toppingCost = 0.0;

      if (creamCheese.isSelected())
         toppingCost += CREAM_CHEESE;
      if (butter.isSelected())
         toppingCost += BUTTER;
      if (peachJelly.isSelected())
         toppingCost += PEACH_JELLY;
      if (blueberryJam.isSelected())
         toppingCost += BLUEBERRY_JAM;

      return toppingCost;
   }

   /**
      Private inner class that handles the event when
      the user clicks the Exit button.
   */
   private class ExitButtonListener implements ActionListener
   {
      public void actionPerformed(ActionEvent e)
      {
          System.exit(0);
      }
   }

   /**
	   This method creates an instance of the OrderCalculatorGUI class
	   which displays the GUI for the Brandi's Bagel House application.
	*/

	public static void main(String[] args)
	{
		OrderCalculatorGUIv2 gui = new OrderCalculatorGUIv2();
	}


}

