
/**
 * ColorButton.java
 * Controls the color of some Colorable object.
 * Illustrates the event-handler recipe.
 */
public class ColorButton extends javax.swing.JRadioButton {
    private java.awt.Color _color; // attribute
    private Colorable _colorable; // peer object

    public ColorButton (java.awt.Color aColor,
			Colorable aColorable, 
			javax.swing.ButtonGroup aGroup,
			boolean isSelected) {
	super("", isSelected);
	_color = aColor;
	_colorable = aColorable;
	this.setBackground(aColor); // make button display its color
	this.setText(this.getColorName(_color));
	this.addActionListener(new ColorListener());
	aGroup.add(this);
    }

    private class ColorListener implements java.awt.event.ActionListener {
	public void actionPerformed (java.awt.event.ActionEvent e) {
        _colorable.setColor(_color);
	}
    }

    public String getColorName (java.awt.Color aColor) {
	if (aColor == java.awt.Color.black) return "black";
	else if (aColor == java.awt.Color.blue) return "blue";
	else if (aColor == java.awt.Color.darkGray) return "dark gray";
	else if (aColor == java.awt.Color.gray) return "gray";
	else if (aColor == java.awt.Color.green) return "green";
	else if (aColor == java.awt.Color.lightGray) return "light gray";
	else if (aColor == java.awt.Color.magenta) return "magenta";
	else if (aColor == java.awt.Color.orange) return "orange";
        else if (aColor == java.awt.Color.pink) return "pink";
	else if (aColor == java.awt.Color.red) return "red";
	else if (aColor == java.awt.Color.white) return "white";
	else if (aColor == java.awt.Color.yellow) return "yellow";
	else {
	      return "random";
	   }// not one of the built-in colors
	    
    }
}
