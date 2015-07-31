$(document).ready(function() {
	
	
	$("#email_form").validate({
		rules: {
					
			name: {
				required: true
			},
			last_name: {
				required: true
			},
			email_address: {
				required: true,
				email: true
			},
		},
		messages:{
		  email_address:{
		     required:" Please enter a email address",
			 email: "This is not a valid email"
			 },
		 last_name:{
              required:"Please enter a last name",
          }			  
			 
	   }
		
	}); // end validate
}); // end ready
