
/**
 * Write a description of class Lab11 here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */

import java.util.*;
public class Lab11
{
    public static void main(String[] args){ 
    // instance variables - replace the example below with your own
        Scanner kbd = new Scanner(System.in);
        String withoutEs ="";
       System.out.println("Enter a phrase");
        String word = kbd.nextLine();
       for(int i = 0; i < word.length(); i++)
       {
           if(word.charAt(i) != 'e' && word.charAt(i) != 'E')
           {
              withoutEs += word.charAt(i);
            }
        }
        System.out.println(withoutEs);
      }
}