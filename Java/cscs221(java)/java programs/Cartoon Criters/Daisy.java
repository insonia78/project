
/**
 * Write a description of class Dayse here.
 * 
 * @author (thomas zangari) 
 * @version (11/19/2013)
 */
import wheels.users.*;
import java.awt.Color;

public class Daisy
{
    // instance variables - replace the example below with your own
    private Rectangle _stem;
    private Ellipse _petal1,_petal2,_petal3,_petal4,_petal5,_petal6;
    private Ellipse _center;

    private int _x, _y;
    /**
     * Constructor for objects of class Dayse
     */
    public Daisy(int x, int y){
        _petal1 = new Ellipse();
        _petal2 = new Ellipse();
        _petal3 = new Ellipse();
        _petal4 = new Ellipse();
        _petal5 = new Ellipse();
        _petal6 = new Ellipse();
        _center = new Ellipse();
        _stem = new Rectangle();
        _x = x;
        _y = y;

        this.setColor(Color.WHITE);
        this.setSize();
        this.setLocation(x,y);
        this.setOutline(java.awt.Color.black,2);
        // initialise instance variables
    }

    public void setColor ( Color petalColor){
        _petal1.setColor(petalColor);
        _petal2.setColor(petalColor);
        _petal3.setColor(petalColor);
        _petal4.setColor(petalColor);
        _petal5.setColor(petalColor);
        _petal6.setColor(petalColor);
        _center.setColor(java.awt.Color.YELLOW);
        _stem.setColor(java.awt.Color.GREEN);
    }

    public void setSize(){
        _petal1.setSize(40,40);
        _petal2.setSize(40,40);
        _petal3.setSize(40,40);
        _petal4.setSize(40,40);
        _petal5.setSize(40,40);
        _petal6.setSize(40,40);
        _center.setSize(40,40);
        _stem.setSize(10,100);
    }

    public void setOutline(java.awt.Color color,int thickness){
        _petal1.setFrameColor(color);
        _petal1.setFrameThickness(thickness);
        _petal2.setFrameColor(color);
        _petal2.setFrameThickness(thickness);
        _petal3.setFrameColor(color);
        _petal3.setFrameThickness(thickness);
        _petal4.setFrameColor(color);
        _petal4.setFrameThickness(thickness);
        _petal5.setFrameColor(color);
        _petal5.setFrameThickness(thickness);
        _petal6.setFrameColor(color);
        _petal6.setFrameThickness(thickness);
        _center.setFrameThickness(thickness);
    }

    public int getX(){
        return _x;
    }

    public int getY(){
        return _y;
    }

    public void setLocation(int x,int y){
        _x = x;
        _y = y;
        _petal1.setLocation(_x-10,_y-30);
        _petal2.setLocation(_x+20,_y-30);
        _petal3.setLocation(_x+30,_y);
        _petal4.setLocation(_x-30,_y);
        _petal5.setLocation(_x+26,_y+25);
        _petal6.setLocation(_x-16,_y+29);
        _stem.setLocation(_x+15,_y+40);
        _center.setLocation(x,y);
    }
}

    
    