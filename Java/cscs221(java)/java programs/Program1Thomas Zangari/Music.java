
// Lab 1: thomas zangari
        public class Music extends Item {
            private String artist;
            private int itemnum;

            // Construct a new book object.
            public Music(int id, String t, double p, String a) {
                super(id, t, p);
                artist = a;
            }

            // Return the item type. Overrides method from class Item.
            public String getItemType() {
                return "Music";
            }

            // Return a printable String representation of this item.
            // Overrides method from class Item.
            public String toString() {
                String part1, part2, out;
                part1 = super.toString();
                part2 = String.format("Artist:      %s%n", artist);
                out = part1 + part2;
                return out;
            }
        }
