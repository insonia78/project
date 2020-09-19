
/**
 * Write a description of class Java2DPicture here.
 * 
 * @author (thomas zangari) 
 * @version (a version number or a date)
 */
import java.awt.*;
import java.awt.geom.*;
import javax.swing.*;


public class Java2DPicture extends JPanel
{
        private Rectangle2D sky, grass,house,window,door,rightPanel,leftPanel;
        private Line2D horizon;
        private Ellipse2D sun;
        private Path2D road,roof;
        private JFrame frame;
        private Color brown;
        private Font italic;
        
        public Java2DPicture(){
            frame = new JFrame("Thomas Zangari Picture");
            frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
            frame.setContentPane(this);
            this.init();
            frame.pack();
            frame.setVisible(true);
        }
        public void init(){
            this.setPreferredSize(new Dimension(300,300));
            sky = new Rectangle2D.Float(0,0,300,200);
            grass = new Rectangle2D.Float(0,200,300,100);
            horizon = new Line2D.Float(0,200,300,200);
            sun = new Ellipse2D.Float(210,50, 40, 40);
            house = new Rectangle2D.Float(10,130,100,80);
            brown = new Color(128, 64, 0);
            window = new Rectangle2D.Float(30,135,20,25);
            door = new Rectangle2D.Float(70,169,25,40);
            rightPanel = new Rectangle2D.Float(40,135,1,25);
            leftPanel = new Rectangle2D.Float(30,147,20,1);
            italic = new Font("Serif", Font.BOLD+Font.ITALIC, 20);
            
            road = new Path2D.Float();
            road.moveTo(150, 200);
            
            road.lineTo(80, 300);
            road.lineTo(250,300);
            road.closePath();
            
            roof = new Path2D.Float();
            roof.moveTo(60,80);
            roof.lineTo(2,130);
            roof.lineTo(120,130);
            roof.closePath();
            
        }
        public void paintComponent(Graphics g){
            Graphics2D gr = (Graphics2D) g;
            
            super.paintComponent(g);
            gr.setPaint(Color.BLUE);
            gr.fill(sky);
            gr.setPaint(Color.GREEN);
            gr.fill(grass);
            gr.setPaint(Color.YELLOW);
            gr.fill(sun);
            gr.setPaint(brown);
            gr.fill(house);
            gr.setPaint(Color.RED);
            gr.fill(road);
            gr.setPaint(Color.YELLOW);
            gr.fill(roof);
            gr.setPaint(Color.WHITE);
            gr.fill(window);
            gr.setPaint(Color.BLACK);
            gr.fill(door);
            gr.setPaint(Color.BLACK);
            gr.fill(rightPanel);
            gr.setPaint(Color.BLACK);
            gr.fill(leftPanel);
            gr.setPaint(Color.BLACK);
            gr.setFont(italic);
            gr.drawString("Thomas", 220, 280);
        }
        public static void main(String[] args){new Java2DPicture();}
    }

    