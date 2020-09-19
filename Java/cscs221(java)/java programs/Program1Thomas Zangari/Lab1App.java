
// Lab1: thomas zangari
        public class Lab1App {
               private Item[] list;


               public Lab1App( ){
                 list = new Item[4];
                list[0] = new Music(1111, "Gold", 12.00,"Abba");
                list[1] = new Movie(2222, "Mamma Mia", 16.00,"Meryl Streep");
                list[2] = new Book(3333, "DaVinci Code", 8.00,"Dan Brown");
                list[3] = new Music(4444, "Legend", 15.00,"Bob Marley");
 
                for (int posn = 0; posn < 4; ++posn) {
                    System.out.print(list[posn]);
                    System.out.println();
                }
            }
            public static void main(String[] args) {
                    Lab1App app= new Lab1App();
		}
            
        }    
