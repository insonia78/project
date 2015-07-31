
import wheels.users.*;

public class SketchApp extends Frame {
   private Cursor _cursor;
   private DrawButton _upButton, _downButton;
   private DrawButton _leftButton, _rightButton;
   private DrawButton _rightCornerButton, _leftCornerButton;
   private DrawButton _rightDownCornerButton, _leftDownCornerButton;
   
   public SketchApp() {
      _cursor = new Cursor();
      _upButton = new UpButton(350, 5, _cursor);
      _rightButton = new RightButton(670, 220, _cursor);
      _leftButton = new LeftButton(5, 220, _cursor);
      _downButton = new DownButton(350, 440, _cursor);
      _rightCornerButton = new RightCornerButton(670,5,_cursor);
      _leftCornerButton = new LeftCornerButton(5,5,_cursor);
      _rightDownCornerButton = new RightDownCornerButton(670, 440, _cursor);
      _leftDownCornerButton = new LeftDownCornerButton(5, 440, _cursor);;

      
   } 
   
   public static void main() {
      SketchApp myPad = new SketchApp();
   }
}
