
import wheels.users.*;

public class UpButton extends DrawButton {
   public UpButton (int x, int y, Cursor cursor) {
             super(x, y, cursor);
   }
   
   public java.awt.Point computeNextPoint(java.awt.Point lastPoint) {
      return new java.awt.Point(lastPoint.x, lastPoint.y-5);
   }
}

