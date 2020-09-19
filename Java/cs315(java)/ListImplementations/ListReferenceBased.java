public class ListReferenceBased implements ListInterface {
    // reference to linked list of items
    private Node head;
    private int numItems; // number of items in list

    public ListReferenceBased() {
        numItems = 0;
        head = null;
    }  // end default constructor
    public boolean isEmpty() {
        return (numItems == 0);
    } // end isEmpty

    public int size() {
        return numItems;
    }  // end size
    public void removeAll( ) {
        head = null;
        numItems = 0;

    } // end removeAll
    public Object get(int index)   throws ListIndexOutOfBoundsException {
        //[Scott, Jeff, Andrey]
        if(index >= numItems){
            throw new ListIndexOutOfBoundsException("Index out of bounds");
        }
        
        return find(index).item;
        
        
    } // end get
    private Node find(int index){
        Node curr = head;
        for (int i = 0; i < index; i++){
            if(index==i){
                return curr;
            }
            else{
                curr=curr.next;
            }
        }
        return curr;
    }

    public void add(int index, Object item)  throws  ListIndexOutOfBoundsException, ListException{
        //Gino, Nalan, Allen] 



    } //end add
    public void remove(int index)  throws ListIndexOutOfBoundsException {
        // Kevin , Dennis, Narong, Abhi]
        if(index >=0 && index<numItems){
            if(index==0){
                head= head.next;
            }else{
                Node prev=find(index-1);
                Node curr= prev.next;
                prev.next = curr.next;
            }


        } else{ 
                throw new ListIndexOutOfBoundsException("List is out of bouns");
            }// end remove
    }
}
