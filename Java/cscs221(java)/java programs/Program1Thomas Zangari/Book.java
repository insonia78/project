
// Lab 1: thomas zangari
        public class Book extends Item {
            private String author;
            private int itemnum;
            private Item obj;

            // Construct a new book object.
            public Book(int id, String t, double p, String a) {
                super(id, t, p);
                author = a;
            }

            // Return the item type. Overrides method from class Item.
            public String getItemType() {
                return "Book";
            }


            // Return a printable String representation of this item.
            // Overrides method from class Item.
            public String toString() {
                String part1, part2, out;
                part1 = super.toString();
                part2 = String.format("Author:      %s%n", author);
                out = part1 + part2;
                return out;
            }
        }
