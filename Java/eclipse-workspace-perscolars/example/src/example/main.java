package example;

interface MyInterface{  
	 
    public default void newMethod() {  
        System.out.println("Newly added default method");  
    }  
    void existingMethod(String str);  
}  
interface MyInterface2{  
	 
    default void newMethod()
    {  
        System.out.println("Newly added default method");  
    }  
    void disp(String str);  
} 
public class main implements MyInterface, MyInterface2{ 
	// implementing abstract methods
    public void existingMethod(String str){           
        System.out.println("String is: "+str);  
    }  
    newMethod();
    public void disp(String str){
    	System.out.println("String is: "+str); 
    }
    //Implementation of duplicate default method
//    public void newMethod(){  
//        System.out.println("Implementation of default method");  
//    }  
    public static void main(String[] args) {  
    	main obj = new main().existingMethod(str);;
    	
    	//calling the default method of interface
             
  
  
    }
	
}