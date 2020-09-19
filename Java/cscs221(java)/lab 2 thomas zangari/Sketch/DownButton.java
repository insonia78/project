
import wheels.users.*;

public class DownButton extends DrawButton {
   public DownButton (int x, int y, Cursor cursor) {
      super(x, y, cursor);
   }
   
   public java.awt.Point computeNextPoint(java.awt.Point lastPoint) {
      return new java.awt.Point(lastPoint.x, lastPoint.y+5);
   }
}
