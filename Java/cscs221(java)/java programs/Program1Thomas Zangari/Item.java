
// Lab1: thomas zangari
        public class Item {
            private int itemnum;
            private String title;
            private double price;
            


            // Construct a new item object.
            public Item(int id, String t, double p) {
                itemnum = id;
                title = t;
                price = p;
            }


            // Return the item number of this item.
            public int getItemNumber() {
                return itemnum;
            }

            // Return the item type. This is overridden in subclasses.
            public String getItemType() {
                return "Item";
            }

            // Return a printable String representation of this item.
            public String toString() {
                String line1, line2, line3, line4, out;
                String itemtype = this.getItemType();
                line1 = String.format("Item number: %d%n", itemnum);
                line2 = String.format("Item type:   %s%n", itemtype);
                line3 = String.format("Item title:  %s%n", title);
                line4 = String.format("Item price:  %.2f%n", price);
                out = line1 + line2 + line3 + line4;
                return out;
            }
                    // This exception is thrown when trying to insert an item
        // when the catalog is full.
              

        }
