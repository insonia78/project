
import wheels.users.*;

public class Cursor {
   private java.awt.Point _location;
   
   public Cursor () {
      _location = new java.awt.Point(350, 250);
   }
   
   public void setLocation(java.awt.Point point) {
      _location = point;
   }
   
   public java.awt.Point getLocation() {
      return _location;

         }
}
