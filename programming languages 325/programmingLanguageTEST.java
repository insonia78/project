
/**

Malane Thou
CS325: Programming Language
DR. RAVENSCROFT
Project I, Part II

**/

public class IntegerLiterals 
{
	public static void main(String[] args) 
	{
		//Create and fill an array of "Integers"
		String[] integerLiteralTest = 
                {" 1",   //Decimal test
                 "1 ", 
                 " 1 ", 
                 " 1341 ",
                 "1231",
                 "0", 
                 "    99999   ", 
                 "", 
                 " ", 
                 "abc",
                 "1.2",
                 "-1",
                 " 1 1",
                 "-10",
                 "10 24",
                 "0000B", //Hex test
                 "0FACA",
                 "0 00B",
                 "0Z012",
                 "01",    //Octal test
                 "010",
                 "0231",
                 "00",
                 "1L",    //Long test
                 "1234L"};
                
                
		//Calls the function "iterateArray" and passes the array "integerLiteralTest"
		iterateArray(integerLiteralTest);
	}
	
	//Function to pass each String in the Array to method "isInteger"
	public static void iterateArray(String[] arrayTest)
	{
		//counter to iterate through every item in the array
		for(int counter = 0; counter< arrayTest.length; counter++)
		{
                    
                    if (isDecimal(arrayTest[counter]))
                    System.out.println("True");
                    else if (isHexadecimal(arrayTest[counter]))
                    System.out.println("True");
                    else if (isOctal(arrayTest[counter]))
                   System.out.println("True");
                    else if (isLong(arrayTest[counter]))
                   System.out.println("True");
                    else 
                        System.out.println("False");
                       } 
		}
	
       
	//Function to determine if the string is a Decimal
	public static boolean isDecimal(String word)
	{
                word = word.trim(); //Trims spaces before and after characters
		boolean isTrue = true; 
		if (word.isEmpty()) return isTrue = false; //Return false if String is empty
		
		//Iterate through each word letter by letter
		for(int i = 0; i<word.length(); i++)
		{
			//Set/Reset the char as each character of the String
		    char letter = word.charAt(i);
			if ((letter >= '0') && (letter <= '9')) continue;
			isTrue = false;
		}
		return isTrue;
	}
        

    //Function to determine if the string is a Hexadecimal
    public static boolean isHexadecimal(String word) {
             word = word.trim();
             if (word.isEmpty()) return false;
            char[] charArray = word.toCharArray();
            char[] hexIterate = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            'a', 'b', 'c', 'd', 'e', 'f', 'A', 'B', 'C', 'D', 'E', 'F' };
            
            int hexCount = 0;
            for (int i = 0; i<charArray.length; i++){
                for (int j = 0; j<hexIterate.length; j++) {
                    if (charArray[i] == hexIterate[j]) {
                        hexCount++;
                        break;
                    }
                }
            }
           return true ? hexCount == word.length() : false;
}   
        
    //Function to determine if the string is an Octal
    public static boolean isOctal(String word)
	{
                word = word.trim();
		boolean isTrue = true;
		if (word.isEmpty()) return isTrue = false; //Return false if String is empty

		//Iterate through each word letter by letter
		for(int i = 0; i<word.length(); i++)
		{
                    //Setting character 1 to be checked to be 0
                    char preCheck = word.charAt(0);
                    //Set/Reset the char as each character of the String
		    char letter = word.charAt(i);           
                    //First character has to be a '0' and the characters have to be in between 0 and 7
			if ((preCheck == '0') && (letter >= '0') && (letter <= '7')) continue; 
			isTrue = false;
		}
		return isTrue;
	}
        
        
    //Function to determine if the string is a Long
    public static boolean isLong(String word)
	{
        word = word.trim();
		boolean isTrue = true;
		if (word.isEmpty()) return isTrue = false; //Return false if String is empty
                
		//Iterate through each word letter by letter
		for(int i = 0; i<word.length()-1; i++) //Must stop at the last character
		{
                    //Set/Reset a char as each letter of the word
		    char letter = word.charAt(i);
                    char lastLetter = word.charAt(word.length()-1);
                    //last character must be an 'L'
			if ((letter >= '0') && (letter <= '9') && (lastLetter == 'L')) continue;
			isTrue = false;
		}
		return isTrue;
	}
}