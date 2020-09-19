import wheels.users.*;

public class RightDownCornerButton extends DrawButton {
   public RightDownCornerButton (int x, int y, Cursor cursor) {
      super(x, y, cursor);
   }
   
   public java.awt.Point computeNextPoint(java.awt.Point lastPoint) {
      return new java.awt.Point(lastPoint.x+5, lastPoint.y);
   }
}