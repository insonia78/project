
/**
 * Write a description of interface ComplexNumberADT here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public interface ComplexNumberADT
{
    public int getReal();
    public int getImaginary();
    public void setReal(int r);
    public void setImaginary(int i);
    public String toString(); 
    public Complex add(Complex C);
    public Complex subtract(Complex C); 
    public Complex multiply (Complex C);
    public boolean equals (Complex C);
    public double findMagnitude();

}

