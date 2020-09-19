
/* Write a description of class Lab6 here.
 *
 * @author (Thomas Zangari)
 * @version (date 3/18/2014)
 */

import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

public class Lab6 extends JPanel implements ActionListener {

   private JFrame frame;
   private JLabel efficLbl,mileage1Lbl,mileage2Lbl,gallonsLbl;
   private JTextField efficBox,mileage1Box,mileage2Box,gallonsBox;
   private JButton go;

   public Lab6(){
       frame = new JFrame("Lab6");
       frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
       frame.setContentPane(this);
       this.init();
       frame.pack();
       frame.setVisible(true);
   }

    public void init(){
        this.setPreferredSize(new Dimension(270,185));
        this.setBackground(Color.BLUE);
        this.setLayout(null);

        mileage1Lbl = new JLabel("Mileage 1");
        mileage1Box = new JTextField();
        mileage1Lbl.setBounds(10,10,120,25);
        mileage1Box.setBounds(140,10,120,25);
        this.add(mileage1Lbl); this.add(mileage1Box);

        mileage2Lbl = new JLabel("Mileage 2");
        mileage2Box = new JTextField();
        mileage2Lbl.setBounds(10,45,120,25);
        mileage2Box.setBounds(140, 45, 120, 25);
        this.add(mileage2Lbl); this.add(mileage2Box);

        gallonsLbl = new JLabel("Gallons");
        gallonsBox = new JTextField();
        gallonsLbl.setBounds(10,80, 120, 25);
        gallonsBox.setBounds(140,80, 120,25);
        this.add(gallonsLbl); this.add(gallonsBox);

        efficLbl = new JLabel("Fuel Efficiency");
        efficBox = new JTextField();
        efficBox.setEditable(false);
        efficLbl.setBounds(10, 115, 120, 25);
        efficBox.setBounds(140, 115, 120, 25);
        this.add(efficLbl); this.add(efficBox);

        go = new JButton("Compute");
        go.addActionListener(this);
        go.setBounds(75, 150, 120, 25);
        this.add(go);
	}

	public void actionPerformed(ActionEvent e){
		double mileage1,mileage2,gallons,efficiency;
		String result;

		try {
			mileage1 = Double.parseDouble(mileage1Box.getText());
			mileage2 = Double.parseDouble(mileage2Box.getText());
			gallons = Double.parseDouble(gallonsBox.getText());
			efficiency = (mileage2 - mileage1)/gallons;
			result = String.format("%.1f", efficiency);
			efficBox.setText(result);
		}
		catch(NumberFormatException exc){
			efficBox.setText("Number error");
		}
		catch(ArithmeticException exc){
			efficBox.setText("Can't calculate by zero");
		}

}
  public static void main(String[] args){
	  new Lab6();
  }
}
