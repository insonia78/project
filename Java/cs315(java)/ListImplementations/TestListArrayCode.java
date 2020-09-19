 
 public class TestListArrayCode
{//Kevin, Narong, Dennis, Abhi  
   static public void displayList(ListArrayBased list){
        int i;
        int size = list.size();
        String dataItem;

        for(i = 0;  i < size;i++){
            dataItem= (String)list.get(i);

            System.out.println(dataItem);}
    }

    static public void main(String[] args) { 

        // create a list
        ListArrayBased ListofNames = new ListArrayBased();
        String dataItem;

        // test is Empty and size( )
        //System.out.println("TestList is Empty is = " + TestList.isEmpty());
        //System.out.println(" Number of items is list = " + TestList.size());

        ListofNames.add(0, "Cathryn");
        ListofNames.add(1, "John");
        displayList(ListofNames);   //

        ListofNames.add(0, "Bob");
        displayList(ListofNames);

        ListofNames.remove(1);
        displayList(ListofNames);

        ListofNames.removeAll();
        displayList(ListofNames);
        //System.out.println("TestList is Empty is = " + TestList.isEmpty());
        //System.out.println(" Number of items is list = " + TestList.size()); 

    }
}


