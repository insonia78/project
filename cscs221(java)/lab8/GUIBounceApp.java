
/**
 * GUIBounceApp.java
 * Window that contains two panels, one that displays a bouncing ball
 * and one that holds control buttons.
 */
public class GUIBounceApp extends javax.swing.JFrame {
    public GUIBounceApp (String title) {
        super(title);
        this.setSize(600, 450);
        BallPanel ballPanel = new BallPanel();
        ControlPanel controlPanel = new 
                                 ControlPanel(ballPanel);
        this.add(ballPanel, 
                        java.awt.BorderLayout.CENTER);
        this.add(controlPanel, 
                        java.awt.BorderLayout.EAST);
        this.setDefaultCloseOperation(
             javax.swing.JFrame.EXIT_ON_CLOSE);
        this.setVisible(true);
    }
        public static void main (String [ ] args) {
        GUIBounceApp app = new GUIBounceApp(
                "Create your own customized bouncing ball!");
    }
}


