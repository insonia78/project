
/**
 * ControlPanel.java
 * Contain buttons that control the bouncing ball's color and speed.
 */

import java.awt.Color;

public class ControlPanel extends javax.swing.JPanel {
    private final int MAX_SPEED = 40; // attribute

    public ControlPanel (BallPanel aPanel) {
	super(new java.awt.GridLayout(0, 1));
	// create radio buttons
	javax.swing.ButtonGroup group = new 
	    javax.swing.ButtonGroup();  //2a
        Colorable colorable = aPanel.getBall(); 
        ColorButton redButton = new
	    ColorButton(java.awt.Color.red, colorable, 
			group, true); 
        ColorButton blueButton = new
	    ColorButton(java.awt.Color.blue, colorable, 
			group, false);
		ColorButton blackButton = new ColorButton(java.awt.Color.black, colorable, group, false);	
		ColorButton randomButton = new ColorButton(new Color(155,0,255), colorable, group, false);	
        javax.swing.JPanel radioRow = 
            new javax.swing.JPanel(); //2b
        radioRow.add(blueButton); //2c
        radioRow.add(redButton);
        radioRow.add(blackButton);
        radioRow.add(randomButton);
        

	// create slider
	Accelerator accelerator = aPanel.getBall();
	javax.swing.JPanel sliderRow = new 
	    javax.swing.JPanel();
        sliderRow.add(new 
		      SpeedSlider(javax.swing.JSlider.HORIZONTAL, 
				  accelerator, 0, MAX_SPEED, 0));

	// create quit button
	javax.swing.JPanel quitRow =
            new javax.swing.JPanel();
	quitRow.add(new QuitButton());
	// put it all together
	this.add(radioRow);
	this.add(sliderRow);
	this.add(quitRow);
    }
}
