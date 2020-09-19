
/**
 *  Class Circle models a circle located at point(_centerX,_centerY)with radius _radius."
 * 
 * @author Thomas Zangari 
 * @version 09/11/2013
 */

    // instance variables - replace the example below with your own
    

    /**
     * Constructor for objects of class Circle
     */
    public class Circle          
    {
        // initialise instance variables
        private int _centerX, _centerY;
        private double _radius;
        private double Pi=Math.PI; 
        
        public Circle(int x, int y, double r){
              
            _centerX =x;
            _centerY = y;
            _radius = r;
        }
        public double computerArea(){
            return  Pi*_radius*_radius;
        }
        public double computerCircumference(){
            return 2*Pi*_radius;
        }
        public void displayCircleStats(){
            System.out.println("radius: " + _radius);
            System.out.println("Area: " + this.computerArea());
            System.out.println("Circumference: " + this.computerCircumference());
            System.out.println("Center Value of X = " + _centerX +" Center value of Y = " + _centerY);
        }
    }

    