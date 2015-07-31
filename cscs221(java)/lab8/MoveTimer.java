
/**
 *: MoveTimer.java
 * A timer that controls the motion of  
 * some Mover object.
 * illustrates the event-handler recipe.
  */
public class MoveTimer extends javax.swing.Timer {
    Mover _mover;

    public MoveTimer (int anInterval, Mover aMover) {
	super(anInterval, null);
	_mover = aMover;
MoveListener myMoveListener = new MoveListener();
	this.addActionListener(myMoveListener);
	
    }
    private class MoveListener implements java.awt.event.ActionListener {
	public void actionPerformed (java.awt.event.ActionEvent e) {
	    _mover.move();
	}
    }
}

