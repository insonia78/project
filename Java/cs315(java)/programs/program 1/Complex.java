
/**
 * Write a description of class Complex here.
 * 
 * @author (Thomas Zangari) 
 * @version (a version number or a date)
 */
public class Complex implements ComplexNumberADT
{
    private int real;
    private int imaginary;
    private String results;
    

    /**Default Constructor
     * 
     */
    public Complex()
    { 
        real = 0;
        imaginary = 0;

    }

    /**
     * Constructor 
     * @param r : the real number 
     * @param i : the imaginary number  
     */
    public Complex (int r, int i) {
        real = r;
        imaginary = i;
    }

    /** 
     * accessor for the real number
     */
    public int getReal(){
        return real;
    }

    /**
     * accessor for the imaginary number
     */  
    public int getImaginary(){
        return imaginary;
    }
  
    /**
     * mutator for the real number
     */
    public void setReal(int r){
        real = r;
    }
  
    /**
   * mutator for the imaginary number
   */
    public void setImaginary(int i){
        imaginary = i;
    }

    
    /** 
     * Adds a real and an imaginary number 
     * @param c: the imaginary number and the real number
     * @return the sum of the real and imaginary number
     */

    public Complex add (Complex c)
    { 
        Complex tempComp = new Complex();
        tempComp.real = this.real + c.real;
        tempComp.imaginary = this.imaginary + c.imaginary;
         
        return tempComp;
    }
/**
 * subtracts a real and an imaginary number 
 * @param c: the imaginary and the real number 
 * @return the subtraction of the two numbers 
 */
   public Complex subtract (Complex c)
    { 
        Complex tempComp = new Complex();
        tempComp.real = this.real - c.real;
        tempComp.imaginary = this.imaginary - c.imaginary;
      
        return tempComp;
      
    }

    /**
     * Multiply the real and imaginary numbers 
     * @param c the imaginary numbers 
     * @return the multiplication of the numbers 
     */

    public Complex multiply (Complex c)
    { 
        Complex tempComp = new Complex();
        int firstReal = (this.real *c.real);        
        int firstImg = (this.real * c.imaginary);        
        int secondImg = (this.imaginary * c.real);        
        int secondReal =((this.imaginary * c.imaginary) * -1);        
        tempComp.real = firstReal + secondReal;
        tempComp.imaginary = firstImg + secondImg;
        return tempComp;
    }

    /**
     * Compares two complex numbers
     * @param c the 2 complex numbers.
     * @return a boolean value 
     */
    public boolean equals(Complex c){
       return this.toString().equals(c.toString());
    }
    /*
     * finds the magnitude of a number
     */
     public double findMagnitude()
     {
         return (Math.sqrt(Math.pow(real,2) + Math.pow(imaginary,2)));
       
    }
    /*
     * prints the results
     */
   
    public String toString(   ) 
    {       
          if(this.imaginary < 0 && this.real !=0)
            {
                if(this.imaginary == -1)
                {
                   this.results = Integer.toString(this.real)+ " - " + "i";
                }
                else{
                    this.results = Integer.toString((this.real)) +" "+ Integer.toString((this.imaginary))+"i";
                }
            }
            else if (this.imaginary > 0 && this.real !=0)
            {
                if(this.imaginary == 1)
                {
                   this.results = Integer.toString(this.real)+ " + " + "i";
                }
                else{
                  this.results = Integer.toString(this.real)+ " + " + Integer.toString(this.imaginary)+ "i";
                }
            }
            else if (this.imaginary == 0)
            {
               this.results = Integer.toString(this.real);
             
             }
             else if(this.real == 0 && this.imaginary < 0)
             {
                 if(this.imaginary == -1)
                {
                   this.results =  "-i";
                }
                else{
                 this.results = Integer.toString(this.imaginary)+ "i";
                }
             }
             else if(this.real == 0 && this.imaginary > 0)
             {
                if(this.imaginary == 1)
                {
                   this.results = "i";
                }
                else{
                 this.results = Integer.toString(this.imaginary) + "i";
                }
             }
            
         
        // this.process = false;
        return results;
        

    }

}