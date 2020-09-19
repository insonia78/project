
/**
 * Write a description of class Snowman here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
import wheels.users.*;
import java.awt.Color;

public class Snowman
{
    
    private Ellipse _head, _body, _leftEye, _rightEye;

    private int _x, _y;
   
    public Snowman(int x, int y){
        _body = new Ellipse();
        _head = new Ellipse();
        _leftEye = new Ellipse();
        _rightEye = new Ellipse();
        _x = x;
        _y = y;
        
        this.setColor(Color.WHITE, Color.GRAY);
        this.setSize();
        this.setLocation(x,y);
        this.setOutline(java.awt.Color.black,2);
    }
    public void setColor (Color snowColor, Color eyeColor){
        _body.setColor(snowColor);
        _head.setColor(snowColor);
        _rightEye.setColor(eyeColor);
        _leftEye.setColor(eyeColor);
    }
    public void setSize(){
        _body.setSize(100,100);
        _head.setSize(80,80);
        _leftEye.setSize(15,15);
        _rightEye.setSize(15,15);
    }
    public void setOutline(java.awt.Color color, int thickness){
        _body.setFrameColor(color);
        _body.setFrameThickness(thickness);
        _head.setFrameColor(color);
        _head.setFrameThickness(thickness);
    }
    public int getX(){
        return _x;
    }
    public int getY(){
        return _y;
    }
    public void setLocation(int x, int y){
        _x = x ;
        _y = y;
        _body.setLocation(_x, _y + 60);
        _head.setLocation(_x + 10, _y);
        _leftEye.setLocation(_x + 25, _y + 25);
        _rightEye.setLocation(_x + 65, _y + 25);
    }
}