

        import java.util.*;

        public class Program1 {
            public static void main(String[] args) {
                Scanner kbd = new Scanner(System.in);
                Catalog store = new Catalog(   ); 
                int itemnum;
                Item item;




               
                    store.insert
                      (new Music(1111, "Gold", 12.00, "Abba"));
                    store.insert
                      (new Movie(2222, "Mamma Mia", 16.00, "Meryl Streep"));
                    store.insert
                      (new Book(3333, "DaVinci Code", 8.00, "Dan Brown"));
                    store.insert
                      (new Music(4444, "Legend", 15.00, "Bob Marley"));
                              

                //  Insert code here to perform a sequence of
                //  interactive transactions with the user.
                //  The user enters an item number and the program
                //  either displays the item or prints an error message
                //  if the item is not found.  The program terminates
                //  when the user enters zero as the item number.

                
               
                System.out.print("Item number(0 to quit)?");
                itemnum = kbd.nextInt() ;

                while(itemnum != 0){
                     try{
                         System.out.print(store.find(itemnum));
                        }
                     catch (ItemNotFound exc)
                     {
                           System.out.println(exc);
                     }
                     System.out.print("Item number(0 to quit)?");
                     itemnum = kbd.nextInt();
                }
            }



        }
	
