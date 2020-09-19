
/**
 * Write a description of class QuickSortMain here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class QuickSortMain
{
    // instance variables - replace the example below with your own
   public static void main (String[] args)
   {

      Contact[] friends = new Contact[7];
     
      friends = reset(friends);
       print("\nUnsorted list",friends);
       friends =Quicksort.quickSort(friends,0,(friends.length - 1));
       print("\nQuick Sort",friends);
      
      friends =Quicksort.quickSort(friends,0,(friends.length - 1));
      
    }
    public static Contact[] reset(Contact[] friends)
   {
      friends[0] = new Contact ("John", "Smith", "610-555-7384");
      friends[1] = new Contact ("Sarah", "Barnes", "215-555-3827");
      friends[2] = new Contact ("Mark", "Riley", "733-555-2969");
      friends[3] = new Contact ("Laura", "Getz", "663-555-3984");
      friends[4] = new Contact ("Larry", "Smith", "464-555-3489");
      friends[5] = new Contact ("Frank", "Phelps", "322-555-2284");
      friends[6] = new Contact ("Marsha", "Grant", "243-555-2837");


       return friends;

   }
   public static void print(String title,Contact[] friends)
   {
       System.out.println(title);
       for (int index = 0; index < friends.length; index++)
         System.out.println (friends[index]);
    }
}