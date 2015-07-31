
/**
 * SpeedSlider.java
 * Controls the speed of some Accelerator object.
 * Illustrates the event-handler recipe.
 */
public class SpeedSlider extends javax.swing.JSlider {
    private Accelerator _accelerator; // peer object

    public SpeedSlider (int anOrientation, 
          Accelerator anAccelerator, 
			int aMinSpeed, int aMaxSpeed, 
               int aCurrentSpeed) {
	super(anOrientation, aMinSpeed, 
           aMaxSpeed, aCurrentSpeed);
	_accelerator = anAccelerator;
	this.setValue(0);
	this.setMinimum(0);
	this.setMaximum(aMaxSpeed);
	this.setMajorTickSpacing(5);
	this.setMinorTickSpacing(1);
	this.setPaintTicks(true);
	this.setPaintLabels(true);
	this.addChangeListener(new SpeedListener(this));
    }

    private class SpeedListener implements 
                      javax.swing.event.ChangeListener {
	private SpeedSlider _slider;

	public SpeedListener (SpeedSlider aSlider) {
	    _slider = aSlider;
	}

	public void stateChanged      
        (javax.swing.event.ChangeEvent e) {
	    _accelerator.setSpeed (_slider.getValue());
	}
    }
}
