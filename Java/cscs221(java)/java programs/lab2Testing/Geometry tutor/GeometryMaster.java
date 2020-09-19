
/**
 * LAb 3: Geometry Tutor: Thomas Zangari
 * This class is the GeometryMaster. Its job is to solve the problems.
 * @author Thomas Zangari 
 * @version 
 */
public class GeometryMaster
{
    // instance variables - replace the example below with your own
    private String name;
    

    
    public GeometryMaster()
    {
        name="geometry Guy";
    }

    public double computeCircleArea(int radius)
    {
        return Math.PI * radius* radius;
    }
    public double computeRectangleArea (int lenght,int width)
    {
        return  lenght * width;
    }
    public double computeTriangleArea (int base,int height)
    {
        return  (base * height)/2;
    }
    public String getName(){
        return name;
    }
}
