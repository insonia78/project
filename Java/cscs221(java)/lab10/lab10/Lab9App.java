
 // Lab 10:  Your name
  import java.util.*;
        
public class Lab9App {
     private Scanner kbd;
     
      public Lab9App ( ) {
         int i = 1;
         while( i <= 2){
         
          kbd = new Scanner(System.in);
           this.doCommands();
           extractSubstrings( );
         //  this.replaceSubstrings();
           i++;
        }
       
}
        public void doCommands() {
	      //   this.concatenate();

                // add appropriate code here
	}
	
         public void concatenate(  ){
           String str1, str2, str3;
           int len1, len2;
           str1= this.setString ("Enter the first string: ");
           str2= this.setString("Enter the second string: ");
           len1 = str1.length();
           System.out.printf("The length of str1 is %d.%n", len1);
           System.out.printf("str1 is \"%s\".%n", str1);

             len2 = str2.length();
            System.out.printf("The length of str2 is %d.%n", len2);
            System.out.printf("str2 is \"%s\".%n", str2);

              str3 = str1 + str2;
             System.out.printf("str1 + str2 is \"%s\".%n", str3);
            } 
        public String setString( String amessage) {
         System.out.printf(amessage);
         return kbd.nextLine();
                }
        public void compareStrings( ){
      String str1, str2;    
      str1 = this.setString ( " Enter the first string: ");
      str2= this.setString( "Enter the second string:  ");
      if (str1.compareTo(str2) < 0)
            System.out.printf("%s < %s%n", str1, str2);
            else if (str1.compareTo(str2) == 0){
                System.out.printf("%s = %s%n", str1, str2);
            } else if (str1.compareTo(str2) > 0)
            System.out.printf("%s > %s%n", str1, str2);
            }
      public void searchForSubstrings( ){
           String  source, target;
           int  posn;

            source = this.setString ("Enter the source string: ");          
            target =  this.setString("Enter the target string:  ");

            posn = source.indexOf(target);
            if (posn < 0)
                             System.out.printf("The target was not found.%n");
            else
                  System.out.printf
                   ("The target was found at position %d.%n", posn);
            }
            
        public void extractSubstrings( ){
        String  str, substr;
        int  start, finish;

        str = this.setString ("Enter the string: ");          
         System.out.printf("Enter the starting position: ");
         start = kbd.nextInt();
         System.out.printf("Enter the ending position: ");
         finish = kbd.nextInt();
         substr = "unhappy".substring(start, finish);
         System.out.printf("The substring is \"%s\".%n", substr);
            }




            
      

            
        

public static void main (String[] args) {
      new Lab9App( );
    	}
}


            
