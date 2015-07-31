   import java.util.ArrayList;      
        public class Catalog {
            private ArrayList <Item> list;
              private int itemCount;

           // Construct an empty catalog 
            public Catalog() {
                list = new ArrayList <Item>();
                itemCount = 0;
            }
 
           

              public void insert(Item obj) {
               
                 
                 list.add(obj);
                    
                   // Insert a new item into the catalog.
              


            }

            

            // Search the catalog for the item whose item number
            // is the parameter id.  Return the matching object 
            // if the search succeeds.  Throw an ItemNotFound
            // exception if the search fails.
            public Item find(int id) throws ItemNotFound {
                Item item = null;
                for(int i = 0; i < list.size();i++){
                    if( id == list.get(i).getItemNumber()){
                        item = list.get(i);
                        
                                               
                    }
                  }
                if (item == null){
                        throw new ItemNotFound(id);
                    }
                              
                  return item;
                
                 
            
                
            
		}
}
