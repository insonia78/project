  $(document).ready(function() {
	        $('#slideshow').cycle({
	        	fx: 'shuffle',
	        	speed: 500,
	        	timeout: 2000,
	        	pause: 1
	        });
			$("#email_form").hide();
			$("#form legend").toggle( function(){
			    $(this).next().slideDown(3000)},
				function(){
				$(this).next().slideUp(2000);
		      }
			);
	    });// end of ready