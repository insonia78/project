
/**
 * Write a description of class test here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class test
{
    // instance variables - replace the example below with your own
   public static void main(String[] args)
   {
       int[] array = new int[2];
       int[] newarray = new int[10];
       try{
       for(int i = 0;i < (array.length + 1);i++)
       {
           array[i] = i;
        }
       
    }
    catch(IndexOutOfBoundsException e)
    {
       
        for(int i = 0; i < array.length;i++)
        {
            newarray[i]=array[i];
        }
    }
    finally
    {
        for(int i = 0; i < newarray.length;i++)
        {
            System.out.println(newarray[i]);
        }
    } 
}

}
