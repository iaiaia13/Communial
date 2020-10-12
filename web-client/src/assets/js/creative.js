$(document).ready(function(){
  if ($(document).scrollTop() == 0)
  $(".header-content").slideDown(1000);
});
(function($) {
  "use strict"; // Start of use strict
  
  // Smooth scrolling using jQuery easing
  $('a.js-scroll-trigger[href*="#"]:not([href="#"])').click(function() {
    if (location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '') && location.hostname == this.hostname) {
      var target = $(this.hash);
      target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
      if (target.length) {
        $('html, body').animate({
          scrollTop: (target.offset().top - 48)
        }, 1000, "easeInOutExpo");
        return false;
      }
    }
  });

  // Closes responsive menu when a scroll trigger link is clicked
  $('.js-scroll-trigger').click(function() {
    $('.navbar-collapse').collapse('hide');
  });

  // Activate scrollspy to add active class to navbar items on scroll
  $('body').scrollspy({
    target: '#mainNav',
    offset: 48
  });

  // Collapse the navbar when page is scrolled
  $(window).scroll(function() {
    if ($("#mainNav").offset().top > 100) {
      $("#mainNav").addClass("navbar-shrink");
    } else {
      $("#mainNav").removeClass("navbar-shrink");
    }
  });

  // Show factory detail
  $('#factories .content-group').click(function() {
    var hasClass = $(this).hasClass("active");
    $('#factories .content-group').removeClass("active");
    if (!hasClass)
      $(this).delay(0).queue(function() {
        $(this).addClass("active");
        $(this).dequeue();
      });
  });

  // Scroll reveal calls
  window.sr = ScrollReveal();
  sr.reveal('.sr-icons', {
    duration: 1000,
    scale: 0.3,
    delay: 100,
    distance: '60px',
	reset: true
  }, 400);
  sr.reveal('#logo-image', {
    duration: 2000,
    scale: 1,
    delay: 200,
	reset: true
  });
  sr.reveal('.sr-button', {
    duration: 1000,
    delay: 200,
	reset: true
  });
  sr.reveal('.sr-contact', {
    duration: 600,
    scale: 0.3,
    delay: 100,
    distance: '60px',
	reset: true
  }, 400);
  sr.reveal('.cert_img', {
	origin: 'left',
    duration: 700,
    scale: 0.9,
    delay: 100,
    distance: '60px',
	reset: true
  }, 300);

  
  // Scroll blur background
  $(window).on('scroll', function (e) {
	  var height = $("header.masthead").height();
    var pixs = $(document).scrollTop();
	if (pixs < height) {
		var rad = pixs / 5;
		$("header.masthead .header-content").css({"top": -rad + "px"});
    
    if (pixs > height * 0.8)
      $("header.masthead .header-slide").css({"-webkit-filter": "blur(10px)","filter": "blur(10px)" });
      else if (pixs > height * 0.6)
        $("header.masthead .header-slide").css({"-webkit-filter": "blur(8px)","filter": "blur(8px)" });
        else if (pixs > height * 0.4)
          $("header.masthead .header-slide").css({"-webkit-filter": "blur(6px)","filter": "blur(6px)" });
          else if (pixs > height * 0.2)
            $("header.masthead .header-slide").css({"-webkit-filter": "blur(4px)","filter": "blur(4px)" });
            else if (pixs > 0)
              $("header.masthead .header-slide").css({"-webkit-filter": "blur(2px)","filter": "blur(2px)" });
            else
            $("header.masthead .header-slide").css({"-webkit-filter": "blur(0px)","filter": "blur(0px)" });
    }

    if (pixs - 50 > height / 2)
      $(".header-content").fadeOut(300);
    else
      $(".header-content").slideDown(500);
  });

  // Owl carousel for horizontal silde of items
	$('.owl-carousel').owlCarousel({
		loop:true,
		center: true,
		autoplayHoverPause:true,
		nav: true,
		responsive:{
			0:{
			  items:1,
			  stagePadding: 50
			},
			640:{
			  items:1,
			  stagePadding: 120
			},
			870:{
			  items:1,
			  stagePadding: 190
			},
			1024:{
			  items:1,
			  stagePadding: 250
			},
			1200:{
			  items:3
			}
		}
  });
  
})(jQuery); // End of use strict
