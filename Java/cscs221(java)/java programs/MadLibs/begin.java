public class MadLibController{

   private MadLibView _veiw3;
   private char userChoice;

   public MadLibController(){

   _veiw3 = new MadLibView();
   }


   public void start(){

     userChoice =_veiw3.getUserChoice();

     while(userChoice == 'Y' || userChoice == 'y'){

       _veiw3.setInput();
       printStory();
     }

   }
   public void printStory(){
	   _veiw3.setOutput();
   }



 public static void main(String[] args){
	MadLibController begin = new MadLibController();
	begin.start();
  }
}








