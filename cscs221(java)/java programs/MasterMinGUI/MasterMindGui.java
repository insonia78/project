import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.awt.geom.*;
import java.util.*;



/**
   MasterMind game the program is set up  to work with only one color at a time.
   It is developed in one class.
   the program is evilly documented

   Name Thomas Zangari
   data 04/25/2014

*/

public class MasterMindGui extends JFrame
{
   // Pannel components

   private JPanel board;              // board panel to hold the board of the game
   private JPanel  text;              // text panel to hold the text part of the game
   private JPanel radioButtonPanel;   // holds the radio button

   // Radiobuttons
   private JRadioButton  red;         // radio button for the color red
	private JRadioButton  blue;       //radio button for the color blue
	private JRadioButton  cyan;       // radio button for the color cyan
	private JRadioButton  pink ;      // radio button for the color pink
	private JRadioButton  green;      // radio button for the color green
    private JRadioButton  yellow;     // radio button fot the color yellow
	//Button Group
	private ButtonGroup   bg;
    // Button
   private JButton button;
   private JButton reset ;
   private JButton exit;
   //Text area
   private JTextArea answer;
   //Array for the board
   private Play[][] board2;                          // array that holds the board of the game
   private int[] userSelectionColor = new int[4];    // array that holds the userselection for the game
   private int[] compSelectionColor = new int[4];    // array that holds the computer selection
   //random generator for computer selection
    private Random randomColorGenerator = new Random();
    private int countB = 0;   //count of black pin
    private int countW= 0;    // count of white pin
    private boolean decisionW = false; // boolean value for the white pin
    private boolean decisionB = true;  //boolean value for the black pin
    private int count = 0;             // count for the number of interaction that the game suppose to do (no more than 12)
    private boolean computerSelectionTimes = true;  // computer selection method to make performe once
   //Integers for the array
    private int row = 0;
    private int col = 0;
    // count mouse listener
    private int countMouseListener = 0;
    private boolean rowResetBoolean = false;
    private boolean wrong = false;
    private boolean ok = false;
    private boolean check = false;
    private boolean resetcol = false;
    private boolean found = false;
    private boolean game = true;

    // string that contains the computer selection
    private String show = "";
    private String computerReply ="";
    //welcome text
    private String welcome="";




   /**
      Constructor
   */
    public MasterMindGui()
      {
         // Display a title.
         setTitle("MASTER MIND");


         // Specify an action for the close button.
         setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

         // Create a BorderLayout manager.
            setLayout(new BorderLayout());
          JPanel panel = new JPanel();

          radioButtonPanel();   //method that holds the radiobuttons
          board();              // method that holds the board
          cascadeText();        // method that holds the textarea
          welcomeText();        // text that is displayed in the begining of the program
          colorsFromComputer();
          displayComputerSelection();

         // Add the components to the content pane.
         panel.add(radioButtonPanel,BorderLayout.WEST);
         panel.add(board,BorderLayout.CENTER);
        panel.add(text,BorderLayout.EAST);
         add(panel);
         addMouseListener(new MyMouseListener());
         addMouseMotionListener(new MyMouseMotionListener());
         pack();
         setVisible(true);
   }
   /**
    *  radiobutton method for color selection
    */
   public void radioButtonPanel()
   {
	       radioButtonPanel = new JPanel();
	        radioButtonPanel.setPreferredSize(new Dimension(100,510));
	   		radioButtonPanel.setLayout(new GridLayout(6,1));

	   		 // Creating the Radio buttons
	   		red = new JRadioButton("Red",true);
	   		blue = new JRadioButton("Blue");
	   		cyan = new JRadioButton("Cyan");
	   		pink = new JRadioButton("Pink");
	   		green = new JRadioButton("Green");
	   		yellow = new JRadioButton("Yellow");



	   		bg = new ButtonGroup();

	   		bg.add(red);
	   		bg.add(blue);
	   		bg.add(cyan);
	   		bg.add(pink);
	   		bg.add(green);
	   	    bg.add(yellow);

	   	    radioButtonPanel.setBorder(BorderFactory.createTitledBorder("Colors"));

	   	    radioButtonPanel.add(red);
	   		radioButtonPanel.add(blue);
	   		radioButtonPanel.add(cyan);
	   		radioButtonPanel.add(pink);
	   		radioButtonPanel.add(green);
	        radioButtonPanel.add(yellow);

   }
   /**
    * board method that holds the board of the game and has an array of object to paint the board
    */
   public void board()
   {
       board = new JPanel();
	   int row,col;

	   board2 = new Play[4][12];

	   board.setPreferredSize(new Dimension (210, 600));
	   board.setBackground(Color.BLACK);
	   board.setLayout(null);
	   for(row = 0;row < 4; ++row)
	   {
		  for (col = 0;col < 12; ++col)
		  {
			board2[row][col] = new Play();

			board2[row][col].setBounds( (50 * row) + 6, (50  * col) + 5, 43, 43);
			board.add(board2[row][col]);
			board2[row][col].setBackground(Color.WHITE);


		 }

      }

   }
   /**
    * method that holds the text and the buttons of the program
    */
   public void cascadeText()
   {
	   text = new JPanel();
	   text.setPreferredSize(new Dimension(270,550));
	   text.setLayout(new FlowLayout());
	   answer = new JTextArea();
	   answer.setPreferredSize(new Dimension(270,500));
	   answer.setEditable(false);
	   button = new JButton("Play!");
	   reset = new JButton("Reset!");
	   exit = new JButton("Exit!");
	   text.add(answer);
       text.add(button);
       text.add(reset);
       text.add(exit);

       button.addActionListener(new ButtonListener());
       reset.addActionListener(new ResetListener());
       exit.addActionListener(new  ExitListener());
   }
   /**

     setting the userSelectionColor array to 0
    */
    public void zeroArray(){
		for(int i = 0; i < userSelectionColor.length;i++)
		{
			userSelectionColor[i] = 0;
		}
	}
	/**
	 * welcome method with the starting information of the game
	 */
	public void welcomeText()
	{
	  welcome =" Welcome to the MasterMind game \n This game does not have double colors so you\n have to select just one color \n"+
	             "To start choose one color from the color panel \n and click the mouse\n it automaticaly \n place the color in the "+
	              " rectangle.\n Have fun!";
	    answer.setText(welcome);
	}
	public void resetTheRow()
	    {
			boolean value = true;
			col--;
			for(int rowreset = 0; rowreset < compSelectionColor.length; rowreset++){

			board2[rowreset][col].setBackground(Color.WHITE);

			   }

			   rowResetBoolean = true;
			   if(count == -1)
			   {
			     count = 0;
			   }
			   else
			   {
			     count--;
			   }
			   row = 0;
			   wrong = false;

    	      zeroArray();// setting the arrray of the user to zero;


	}
	 public void colorsFromComputer(){
	         computerSelectionTimes = false;
		        for(int i = 0; i < compSelectionColor.length; i++){
		            compSelectionColor[i] = randomColorGenerator.nextInt(6)+1; //Starting selection from 1 to 6

		           }
		         int value =compSelectionColor[0]; // holding the value to compare
		         /* for loop to compare if their are any doubles or triples and changing
		          the value to a non value present in the computerSelection array*/
		         for(int j = 1 ; j < compSelectionColor.length; j++){
		              if(j == 1){
		   		       while(compSelectionColor[0] == compSelectionColor[j]){
		   			   compSelectionColor[j] = randomColorGenerator.nextInt(6)+1;		   ;
		   			  }
		   			 }
		       	    if( j == 2){
		   			     while(compSelectionColor[0] == compSelectionColor[j]||compSelectionColor[1] == compSelectionColor[j]){
		       	           compSelectionColor[j] = randomColorGenerator.nextInt(6)+1;
		       	          }

		   			}
		   		 if(j == 3){
		   		    while(compSelectionColor[0] == compSelectionColor[j] ||compSelectionColor[1] == compSelectionColor[j] ||compSelectionColor[2] == compSelectionColor[j]){
		   		          compSelectionColor[j] = randomColorGenerator.nextInt(6)+1;

		   		   }

		   	     }
		     }



    }//end of ComputerColorSelection
    public void displayComputerSelection(){
            show="";
	        for(int i = 0; i < compSelectionColor.length; i++){
	            if(compSelectionColor[i] == 1){
	                show +="1=red      ";
	            }
	            if(compSelectionColor[i] == 2){
	                show+="2=blue      ";
	            }
	            if(compSelectionColor[i] == 3){
	                show+="3=cyan      ";
	            }
	            if(compSelectionColor[i] == 4){
	                show+="4=pink      ";
	            }
	            if(compSelectionColor[i] == 5){
	                show+="5=green      ";
	            }
	            if(compSelectionColor[i] == 6){
	                show+="6=yellow      ";
	            }

	         }
	         System.out.println("the colors are"+ show);






    }// end of computer display selection



   private class MyMouseListener implements MouseListener
   {
	     public void mousePressed(MouseEvent event){}

    	    public void mouseReleased(MouseEvent event) {}
	   	    public void mouseClicked(MouseEvent event)
	   	    {
                if(game == true){
				    if(wrong = true && countMouseListener > 3){


						resetTheRow();
						countMouseListener = 0;

                   }
					else{
				       if(countMouseListener < 4){
						   	if(red.isSelected()){
									userSelectionColor[row] = 1;
									board2[row][col].setBackground(Color.RED);
									row++;
								}
								if(blue.isSelected()){
									userSelectionColor[row] = 2;
									board2[row][col].setBackground(Color.BLUE);
									row++;
								}
								if(cyan.isSelected()){
									userSelectionColor[row] = 3;
									board2[row][col].setBackground(Color.CYAN);
									row++;
								}
								if(pink.isSelected()){
									userSelectionColor[row] = 4;
									board2[row][col].setBackground(Color.PINK);
									row++;
								}
								if(green.isSelected()){
									userSelectionColor[row] = 5;
									board2[row][col].setBackground(Color.GREEN);
									row++;
								}
								if(yellow.isSelected()){
									userSelectionColor[row] = 6;
									board2[row][col].setBackground(Color.YELLOW);
									row++;
								}
								if(row > 3){
									row =0;
								    col++;
								    answer.setText("press Play");
							  }


						 }

						 countMouseListener++;
					 }
				}



		 	}
	   		public void mouseEntered(MouseEvent event) {}
	   	    public void mouseExited(MouseEvent event ) {}
   }

   private class MyMouseMotionListener implements MouseMotionListener
   {
	   public void mouseDragged(MouseEvent e){}
	   public void mouseMoved(MouseEvent e){}
   }



   /**
     Button Listener for the action of the game
     */
   private class ButtonListener implements ActionListener
   {

	   public void actionPerformed(ActionEvent e)
	   {
          
          boolean gamecount = false;

            check = checkForMultyColors();
		   if(check == true){

		   colorCompare();
		   displaySelection();
	       

	   }

	       else{
			   answer.setText("sorry no Multycolors aloud\n try again");
               resetTheRow();
               



		   }
		   displayComputerSelection();
		   if(countB == 4){
               displayComputerSelection();
			   found = true;
               JOptionPane.showMessageDialog(null,"Congratulation you have win  \n"+show);
               game = false;
		   }
		   else if(count > 10 && found == false){
		       displayComputerSelection();
			   JOptionPane.showMessageDialog(null,"try again  \n"+show);
               game = false;
		  }
		    zeroArray(); // userarray to zero;
		    count++;
		    System.out.println(count);
		    countMouseListener = 0;
	   }



    public boolean checkForMultyColors()
    {
		 countW = 0;
		boolean decision = false;
		int y = 0;

		for(int j = 0; j < compSelectionColor.length; j++){
			           int search = userSelectionColor[j];

			      // if statment if the two selection are equal and increases the countB the black pin
			        while(y <4){

			           if(userSelectionColor[j] == userSelectionColor[y] ){
                              
			                  countW++;
			             }
			              y++;
			            }
			            y = 0;

					 }
			             if(countW > 4){
							 decision = false;
						 }
						 else{
							 decision = true;
						 }
                     wrong = true;
					 return decision;

				 }

    /**
      This Method compares the computer selection and the user selection and increses the countW and countB values
      */



    public void colorCompare(){
	         countW = 0;     //setting the countW to zero;
	         countB = 0;

	         boolean found = false;     // is the value that you are searching is found
	         int doubles = 0;           // count that holds double values from the user
	         int search ;               // value that holds the search of the userselection with in the computerselection array
	         int y = 0;                 // value for the increasing value of the while loop and the userselection in the while loop

	     // first for loop
	        for(int j = 0; j < compSelectionColor.length; j++){
	           search = userSelectionColor[j];

	      // if statment if the two selection are equal and increases the countB the black pin
	           if(compSelectionColor[j] == userSelectionColor[j]){
	             countB++;

	           }
	          else{// going in the white pin selsection it uses a for loop to compare all the values of the array
	              for(int i = 0; i < compSelectionColor.length; i++){

	               if(compSelectionColor[i] == search ){
	                     decisionW = true;

	                  }
	                }
	            }
	            if(decisionW == true){
				  countW++;
			     decisionW = false;

	             }

		 }


    }//end of ColorCompare
    //displays the count of white and black pins
    public void displaySelection(){
	        if(countB <=3){
	            computerReply +="You have " + countB +" in the right place\n";
	        }
	        if(countW <= 4 && countW !=0){
	            computerReply+="You have " + countW + " Right colors\n";
	        }
	        answer.setText(computerReply);

    }//end of displaySelection
    public void displayComputerSelection(){
            show="";
	        for(int i = 0; i < compSelectionColor.length; i++){
	            if(compSelectionColor[i] == 1){
	                show +="1=red      ";
	            }
	            if(compSelectionColor[i] == 2){
	                show+="2=blue      ";
	            }
	            if(compSelectionColor[i] == 3){
	                show+="3=cyan      ";
	            }
	            if(compSelectionColor[i] == 4){
	                show+="4=pink      ";
	            }
	            if(compSelectionColor[i] == 5){
	                show+="5=green      ";
	            }
	            if(compSelectionColor[i] == 6){
	                show+="6=yellow      ";
	            }

	         }
	         System.out.println("the colors are"+ show);






    }
    /**
      Resetting the userArray to zero
      */
    public void zeroArray(){
		for(int i = 0; i < userSelectionColor.length;i++)
		{
			userSelectionColor[i] = 0;
		}
   }
}
/**
  Reset Listener to reset the board
  */

   private class ResetListener implements ActionListener
   {

   	   public void actionPerformed(ActionEvent e)
	   {
	       new MasterMindGui();



       }
    }
     private class ExitListener implements ActionListener
   {

   	   public void actionPerformed(ActionEvent e)
	   {
	       System.exit(0);



       }
    }


   public static void main(String[] args)
   	{
   		MasterMindGui gui = new MasterMindGui();

   	}

}