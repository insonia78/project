$.fn.interSlider = function(options){
	
	var settings = $.extend({
		delay: 3000,
		fadeTime:1000,
		pauseOnHover : true,
		showNavigation:true,
		transitionEffect:"fadeIn"
	}, options );
	
	var images = new Array();
	var slider=this;
	this.addClass('interSlider');
	var sources = this.find('img');
	this.find('img').remove().promise().done(function(){
		slider.addClass('loading');
	});
	
	
	//lazy loading of images
	$.each(sources,function(index){
		var img = $('<img />').attr('src',$(this).attr('src')).load(function(){
			if(!this.complete || typeof this.naturalWidth == "undefined" || this.naturalWidth == 0) {
				alert('broken image!');
			}
		}).promise().done(function(){
			images.push(this);	
		});
	}).promise().done(function(){
		slider.removeClass('loading');
		$.each(images,function(index){
			slider.find('li').eq(index).append(this).hide(0);
		});
	});
	
	var repeat;
	var startSlider = function(){
		if(slider.find('li:visible').length==0){
		
			slider.find('li').first().append(images[0]).hide(0).fadeIn(settings.fadeTime,function(){
				addProgressBar(0);
				animateProgressBar(0);
			});
		} else {
		clearInterval(repeat);
		repeat = setInterval(startSlider,settings.delay+settings.fadeTime*2);
			var index = slider.find('li:visible').index();
			slider.find('li').eq(index).fadeOut(settings.fadeTime,function(){
				removeProgressBars();
				addProgressBar((index+1)%slider.find('li').length);
				slider.find('li').eq((index+1)%slider.find('li').length).fadeIn(settings.fadeTime,function(){
				animateProgressBar((index+1)%slider.find('li').length);
				});
			});
		}
	}
	var initSlider = function(){
		repeat = setInterval(startSlider,settings.delay+settings.fadeTime);
		setTimeout(startSlider,0);
	}
	setTimeout(initSlider,0);
	
	
	var removeProgressBars=function(){
		slider.find('li').find('.progressBar').remove();
	}
	var addProgressBar = function(index){
		slider.find('li').eq(index).append($('<div></div>').addClass('progressBar'));
	}
	var animateProgressBar = function(index){
		slider.find('li').eq((index)%slider.find('li').length).find('.progressBar').animate({width:"100%"},settings.delay,"linear");
	}
	
	$(document).on({
		"mouseenter":function(){
		},
		"mouseleave":function(){
		}
	},'.interSlider img');
}