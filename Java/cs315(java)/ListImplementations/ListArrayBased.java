// ********************************************************
// Array-based implementation of the ADT list.
// *********************************************************
public class ListArrayBased implements ListInterface {
  private static final int MAX_LIST = 7; 
  private Object items[];  // an array of list items
  private int numItems;  // number of items in list

  public ListArrayBased() {
    items = new Object[MAX_LIST];
    numItems = 0;
  }  // end default constructor

  public boolean isEmpty() {
    return (numItems == 0);
  } // end isEmpty

  public int size() {
    return numItems;
  }  // end size

  public void removeAll() {
    // Creates a new array; marks old array for
    // garbage collection.
    items = new Object[MAX_LIST];
    numItems = 0;
  } // end removeAll

  public void add(int index, Object item)
                  throws  ListIndexOutOfBoundsException, ListException {
   //Tyler, Cendric, Tom .....
   if (index < 0 || index >= MAX_LIST)
      throw new ListIndexOutOfBoundsException("Out of List Bounds");
   else
      if (numItems == MAX_LIST)
       throw new ListException("List Full");
       else
         if (index < numItems)
          { for (int i = numItems - 1; i >= index; i--) {
               items[i+1] = items[i];
            }
            items[index] = item;
             numItems++;}
         else
             {items[index] = item;
             numItems++;}
            }

   
   
 
  public Object get(int index)
                    throws ListIndexOutOfBoundsException {
  //Gino,Allen, Malane
                        
if(index >= 0 && index < numItems){
        return items[index];
}else{
        throw new ListIndexOutOfBoundsException("List out of Bounds");
}
  } // end get

  

  public void remove(int index)
                     throws ListIndexOutOfBoundsException {
 // Jeff, Scott, Blake, Andrew
   if (index < 0 || index > MAX_LIST)
     throw new ListIndexOutOfBoundsException
     ("Index is out of bounds.");
   for (int i = index; i <= numItems - 1; i++)
    { items [i] = items [i+1];
    }
    numItems-- ;
}
  
}  // end ListArrayBased