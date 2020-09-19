
import wheels.users.*;

public class DrawButton extends Ellipse {
    private Cursor _cursor;
   
   public DrawButton(int x, int y, Cursor cursor) {
      super(x, y);
      this.setSize(20, 20);
      _cursor = cursor; //store reference to peer cursor
   }
   
   public void mousePressed(java.awt.event.MouseEvent e) {
      this.setFillColor(java.awt.Color.BLUE);
   }
   
   public void mouseReleased(java.awt.event.MouseEvent e) {
      java.awt.Point lastPoint = _cursor.getLocation();
      java.awt.Point nextPoint = computeNextPoint(lastPoint);
      Line line = new Line(lastPoint, nextPoint);
      line.setColor(java.awt.Color.BLACK);
      line.setThickness(2);
      _cursor.setLocation(nextPoint);
      this.setFillColor(java.awt.Color.RED);
   }
   
   public java.awt.Point computeNextPoint(java.awt.Point lastPoint) {
      return new java.awt.Point(0, 0); // default: move cursor to (0,0)
   }
}

 
