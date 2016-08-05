(function($) {
    "use strict";

    // **********************************************************************// 
    // ! Document Ready
    // **********************************************************************//	
    resize_fullscreen();
    wed_owlCarousel();
    wed_maximageSlider();
    wed_funfact();
	jcf.replaceAll();
	
	 // **********************************************************************// 
    // ! Browser Agent Function
    // **********************************************************************//
	location_mapcanvas();
	// 01.1 Check Chrome (Mobile / Tablet)
	var isChromeMobile = function isChromeMobile() {
		if (device.tablet() || device.mobile()) {
			if (window.navigator.userAgent.indexOf("Chrome") > 0 || window.navigator.userAgent.indexOf("CriOS") > 0){
				return 1;
			}
		}
	}		
	
	// 02. FULLSCREEN CLASS
	var fullscreen = function(){
		var fheight = $(window).height();
		$('.fullscreen').css("height",fheight);		
	}
	
	//Execute on load
	fullscreen();
		
	//Execute on window resize
	$(window).resize(function() {	
		fullscreen();	
	});
	
    // **********************************************************************// 
    // ! scrollToTop
    // **********************************************************************//
    function thememascot_scrollToTop_icon() {
        if ($(window).scrollTop() > 600) {
            $('.scrollToTop').fadeIn();
        } else {
            $('.scrollToTop').fadeOut();
        }
    }

    $(document.body).on('click', '.scrollToTop', function(e) {
        $('html, body').animate({
            scrollTop: 0
        }, 800);
        return false;
    });

    // **********************************************************************// 
    // ! Home Resize Fullscreen
    // **********************************************************************//
    function resize_fullscreen() {
        var windowHeight = $(window).height();
        $('.fullscreen, .revslider-fullscreen').height(windowHeight);
    }
    $(window).resize(function() {
        resize_fullscreen();
    });

    // **********************************************************************// 
    // ! Owl Carousel
    // **********************************************************************//
    function wed_owlCarousel() {
        $('.featured-gallery').owlCarousel({
            autoplay: true,
            autoplayTimeout: 2000,
            loop: true,
            margin: 3,
            dots: false,
            nav: true,
            navText: [
                '<i class="pe-7s-angle-left"></i>',
                '<i class="pe-7s-angle-right"></i>'
            ],
            responsive: {
                0: {
                    items: 1,
                    center: false
                },
                600: {
                    items: 2,
                    center: false
                },
                960: {
                    items: 3
                },
                1170: {
                    items: 4
                },
                1300: {
                    items: 4
                }
            }
        });        
    }
    
	// **********************************************************************// 
    // ! maximage Fullscreen Parallax Background Slider
    // **********************************************************************//
    function wed_maximageSlider() {
        $('#maximage').maximage({
            cycleOptions: {
                fx: 'fade',
                speed: 9000,
                prev: '.img-prev',
                next: '.img-next'
            }
        });
    }
	
	// **********************************************************************// 
    // ! Funfact Number Counter
    // **********************************************************************//
    function wed_funfact() {
        $('.animate-number').appear();
        $(document.body).on('appear', '.animate-number', function() {
            $('.animate-number').each(function() {
                if (!$(this).hasClass('appeared')) {
                    $(this).animateNumbers($(this).attr("data-value"), true, parseInt($(this).attr("data-animation-duration"), 10));
                    $(this).addClass('appeared');
                }
            });
        });
    }

	// **********************************************************************// 
    // ! CountDown
    // **********************************************************************//
    var endingdate = $('#clock').data("endingdate");
    $('#clock').countdown(endingdate, function(event) {
      var countdown_text = ''+
      '<ul class="countdown-timer">'+
        '<li>%D <span>Days</span></li>'+
        '<li>%H <span>Hours</span></li>'+
        '<li>%M <span>Minutes</span></li>'+
        '<li>%S <span>Seconds</span></li>'+
      '</ul>';
      $(this).html(event.strftime(countdown_text));
    });
	
	// **********************************************************************// 
    // ! Magnific Popup
    // **********************************************************************//
	$('.magnific-zoom').magnificPopup({
 		type: 'image',
		image: {
    		titleSrc: 'title'
 		},
		callbacks: {
    		open: function() {
    		},
    		afterClose: function() {
    		}
  		},
	});
		
	$('.magnific-zoom-gallery').magnificPopup({
 		type: 'image',
		image: {
    		titleSrc: 'title'
 		},
		gallery: {
         	 enabled:true
        },
		callbacks: {
    		open: function() {
    		},
    		afterClose: function() {
    		}
  		},
	});	 
	 
	$('.magnific-ajax').magnificPopup({
  		type: 'ajax',
		ajax: {
			settings: {cache:false}
		},
		callbacks: {
    		open: function() {
    		},
    		afterClose: function() {				
    		}
  		},
	});
	
	// **********************************************************************// 
    // ! Owl Carousel
    // **********************************************************************//
	$("#owl_demo_1").owlCarousel({ 
		navigation : true, // Show next and prev buttons
		paginationSpeed : 1000,
		goToFirstSpeed : 2000,
		items: 3,
		//itemsDesktop: [1024, 2],
//        itemsDesktopMedium: [900, 2],
//		itemsDesktopSmall: [800, 2],
//        itemsTablet: [600, 1],
//        itemsMobile: [320, 1],
//		itemsMobile: [360, 1],
		navigationText:["<img src\=\"images/prevbg_1.png\"\/>","<img src\=\"images/nextbg_1.png\"\/>"]
	});
	$("#owl_demo_2").owlCarousel({ 
		navigation : true, // Show next and prev buttons
		paginationSpeed : 1000,
		goToFirstSpeed : 2000,
		items: 4,
		navigationText:["<img src\=\"images/prevbg_1.png\"\/>","<img src\=\"images/nextbg_1.png\"\/>"]
	});
	$("#owl_demo_3").owlCarousel({ 
		navigation : true, // Show next and prev buttons
		paginationSpeed : 1000,
		goToFirstSpeed : 2000,
		items: 4,
		navigationText:["<img src\=\"images/prevbg_1.png\"\/>","<img src\=\"images/nextbg_1.png\"\/>"]
	});
	
	// **********************************************************************// 
    // ! Google Map
    // **********************************************************************//
	function location_mapcanvas() {
		var gmapCanvas = "#map_canvas";
		var gmColor = $(gmapCanvas).data("color");
		$(gmapCanvas).prettyMaps({
			address: $(gmapCanvas).data("address"),
			image: $(gmapCanvas).data("map-marker"),
			hue: $(gmapCanvas).data("color"),
			saturation: -40,
			zoom: 14,
			panControl: true,
			zoomControl: true,
			mapTypeControl: true,
			scaleControl: true,
			streetViewControl: true,
			overviewMapControl: true,
			scrollwheel: false,
			styles: [{"featureType": "water","elementType": "geometry","stylers": [{"color": gmColor}, {"lightness": 17}]}, {"featureType": "landscape","elementType": "geometry","stylers": [{"color": gmColor}, 
			{"lightness": 20}]}, {"featureType": "road.highway","elementType": "geometry.fill","stylers": [{"color": gmColor}, {"lightness": 17}]}, 
			{"featureType": "road.highway","elementType": "geometry.stroke","stylers": [{"color": gmColor}, {"lightness": 29}, {"weight": 0.2}]}, 
			{"featureType": "road.arterial","elementType": "geometry","stylers": [{"color": gmColor}, {"lightness": 18}]}, {"featureType": "road.local","elementType": "geometry","stylers": [{"color": gmColor}, 
			{"lightness": 16}]}, {"featureType": "poi","elementType": "geometry","stylers": [{"color": gmColor}, {"lightness": 21}]}, {"elementType": "labels.text.stroke","stylers": [{"visibility": "on"}, 
			{"color": gmColor}, {"lightness": 16}]}, {"elementType": "labels.text.fill","stylers": [{"saturation": 36}, {"color": gmColor}, {"lightness": 40}]}, 
			{"elementType": "labels.icon","stylers": [{"visibility": "off"}]}, {"featureType": "transit","elementType": "geometry","stylers": [{"color": gmColor}, {"lightness": 19}]}, 
			{"featureType": "administrative","elementType": "geometry.fill","stylers": [{"color": gmColor}, {"lightness": 20}]}, 
			{"featureType": "administrative","elementType": "geometry.stroke","stylers": [{"color": gmColor}, {"lightness": 17}, {"weight": 1.2}]}, ]
			});
		}
		location_mapcanvas();
    
})(jQuery);