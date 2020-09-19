public class MadLibGame{


  private String _story;

		public String getStory(String noun,String noun2,String verb,String suffix,String title){


		_story="The *" + noun + "* and the *" + noun2 +"*\n\n"+
		        "- Hans Christian Anderson \n\n"+
		        "ONCE upon a time there was a prince who wanted to marry a *"+ noun + "*; but she would have to be a real *" + noun +"*.\n"+
		        "He *" + verb + "* all over the world to find one, but nowhere could he get what he wanted. There were *" + noun +"es* enough,\n"+
		        "but it was difficult to find out whether they were real ones. There was always something about them that was not as it should be.\n "+
		        "So he came home again and was sad, for he would have liked very much to have a real *" + noun + "*./n" +

		        "One evening a terrible storm came on; there was thunder and lightning, and the rain poured down in torrents.\n"+
		        "Suddenly a knocking was heard at the city gate, and the old king went to open it.\n"+

		        "It was a *" + noun +"* standing out there in front of the gate. But, good gracious! what a sight the rain and the wind had made his look.\n"+
		        "The water ran down from *" +verb+ "* hair and clothes; it ran down into the toes of *"+verb+"* shoes and out again at the heels.\n"+
		        "And yet she said that she was a real *" +noun+"*./n"+

		        "'Well, we'll soon find that out,' thought the old queen. But she said nothing, went into the bed-room,\n"+
		        "took all the bedding off the bedstead, and laid a *" + noun2 + "* on the bottom; then she took twenty mattresses and laid them on the *"+noun2+"*,\n"+
		        "and then twenty eider-down beds on top of the mattresses.\n"+

        		"On this the *" + noun + "* had to lie all night. In the morning she was asked how she had slept.\n"+

		        "'Oh, very badly!' said she. 'I have scarcely closed my eyes all night. Heaven only knows what was in the bed,\n"+
		        "but I was lying on something hard, so that I am black and blue all over my body. It's horrible!'\n"+

		        "Now they knew that she was a real *"+noun+"* because she had felt the *"+noun2+"* right through the twenty mattresses and the twenty eider-down beds.\n"+

		        "Nobody but a real *" + noun + "* could be as sensitive as that.\n"+

	        	"So the prince took *"+verb+"* for his *" + title +"*,for now he knew that he had a real *"+ noun+"*;\n"+
	        	"and the first was put in the museum, where it may still be seen, if no one has stolen it.\n"+

		        "There, that is a true story. ";


			return _story;


    }
}

