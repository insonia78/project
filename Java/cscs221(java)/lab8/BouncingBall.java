
 // BouncingBall.java
 // A SmartEllipse that can change color or speed on command.
public class BouncingBall extends SmartEllipse 
   implements Mover, Accelerator, Colorable {
    private int _changeX, _changeY; // attributes
    private javax.swing.JPanel _panel; // peer object (and container)

    public BouncingBall (java.awt.Color aColor, 
                         javax.swing.JPanel aPanel){
	super(aColor);
	_changeX = 0;
	_changeY = 0;
	_panel = aPanel;
    }
    public void move() {
	int nextX = (int)this.getX() + _changeX;
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
	this.setLocation(nextX, nextY);
    }
    public int getMinBoundX() {
	return (int) _panel.getX();
    }
    public int getMinBoundY() {
	return (int) _panel.getY();
    }
    public int getMaxBoundX() {
    return (int) (_panel.getX() + _panel.getWidth()  - this.getWidth());
    }
    public int getMaxBoundY() {
	return (int) (_panel.getY() + _panel.getHeight() - this.getHeight());
    }
    public void setSpeed (int aSpeed) {
	_changeX = aSpeed;
	_changeY = aSpeed;
    }
        public void setColor (java.awt.Color aColor) {
	this.setFillColor(aColor);
	this.setBorderColor(aColor);
    }
}
