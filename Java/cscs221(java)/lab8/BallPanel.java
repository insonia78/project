
/**
 * BallPanel.java
 * Contains a bouncing ball.
 */
public class BallPanel extends javax.swing.JPanel 
       implements Mover {
    private final int INIT_X = 75; // attributes
    private final int INIT_Y = 75;
    private final int DIAMETER = 60;
    private final int INTERVAL = 100;
    private BouncingBall _ball; // components
    private MoveTimer _timer;

    public BallPanel () {
	super();
	_ball = new BouncingBall (java.awt.Color.red, this);  
	_timer = new MoveTimer(INTERVAL, this);
	this.setBackground(java.awt.Color.white);
	_ball.setLocation(INIT_X, INIT_Y);
	_ball.setSize(DIAMETER, DIAMETER);
	_timer.start();
    }
    public void move() {
	_ball.move();
	this.repaint();
    }

    public BouncingBall getBall() {
	return _ball;
    }
     
    public void paintComponent(java.awt.Graphics aBrush) {
	super.paintComponent(aBrush);
	java.awt.Graphics2D betterBrush = 
	    (java.awt.Graphics2D) aBrush;
	_ball.fill(betterBrush);
    }
}

