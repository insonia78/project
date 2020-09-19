
/**  BouncingBall.java
 * Extends SmartEllipse, adding the ability to "bounce." */

public class BouncingBall extends SmartEllipse implements Mover {
    private int _changeX, _changeY; // attributes
    private final int MOVE_LEN = 5;
    private javax.swing.JPanel _panel; // peer object (and container)
    private javax.swing.Timer _timer;

    public BouncingBall (java.awt.Color aColor, 
                                javax.swing.JPanel aPanel){
	super(aColor);                           //2a
	_changeX = MOVE_LEN;
	_changeY = MOVE_LEN;
	_panel = aPanel;
    }

    public void move() {
	int nextX = (int)this.getX() + _changeX;  // 2b
	int nextY = (int)this.getY() +  _changeY;
	if (nextX <= this.getMinBoundX()) {
	    _changeX *= -1;
	    nextX = this.getMinBoundX();
	}
	else if (nextX >= this.getMaxBoundX()) {
	    _changeX *= -1;
	    nextX = this.getMaxBoundX();
	}
	if (nextY <= this.getMinBoundY()) {
	    _changeY *= -1;
	    nextY  = this.getMinBoundY();
	}
	else if (nextY > this.getMaxBoundY()){
	    _changeY *= -1;
	    nextY = this.getMaxBoundY();
	}
	this.setLocation(nextX, nextY); //2c
    }
    public int getMinBoundX() {
	return (int) _panel.getX();   //2d
    }
    public int getMinBoundY() {
	return (int) _panel.getY();
    }
    public int getMaxBoundX() {
     	return (int) (_panel.getX() + _panel.getWidth()
		      - this.getWidth());
    }
    public int getMaxBoundY() {
	return (int) (_panel.getY() + _panel.getHeight()
		      - this.getHeight());
    }
}
