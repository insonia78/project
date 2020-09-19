
/**
 * Write a description of class SortPhoneList here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
/**
 * SortPhoneList driver for testing an object selection sort.
 *
 * @author Dr. Chase
 * @author Dr. Lewis
 * @version 1.0, 8/18/08
 */

public class SortPhoneList
{
   public static void main (String[] args)
   {
      
      Contact[] friends = new Contact[10];
      friends[0] = new Contact(8);

      
      Sorting.quickSort(friends, 0, friends.length-1);
     
     
      for (int index = 0; index < friends.length; index++)
         System.out.println (friends[index]);
   }
}

