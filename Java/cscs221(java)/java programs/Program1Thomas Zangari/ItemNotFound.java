 
 // This exception is thrown when searching for an item
        // that is not in the catalog.
        public class ItemNotFound extends Exception {
            public ItemNotFound(int id) {
                super(String.format("Item %d was not found.", id));
            }
        }

