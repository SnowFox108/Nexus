$(function() {
	
	$('#slideshow').cycle({
        fx:     'fade',
        speed:  'slow',
        timeout: 5000,
        pager:  '#slider_nav',
        pagerAnchorBuilder: function(idx, slide) {
            // return sel string for existing anchor
            return '#slider_nav li:eq(' + (idx) + ') a';
        }
    });
	 
	// wrap 'span' to nav page link
	$('.topnav ul').children('li').each(function() {
		$(this).children('a').html('<span>'+$(this).children('a').text()+'</span>'); // add tags span to a href
	});
	
	// radius Box   
	$('.footer_resize a').css({"border-radius": "7px", "-moz-border-radius":"7px", "-webkit-border-radius":"7px"});
	$('.wp-pagenavi a').css({"border-radius": "5px", "-moz-border-radius":"5px", "-webkit-border-radius":"5px"});
	$('.post_leave ').css({"border-radius": "7px", "-moz-border-radius":"7px", "-webkit-border-radius":"7px"});
	$('div#slideshow').css({"border-radius": "7px", "-moz-border-radius":"7px", "-webkit-border-radius":"7px"});
	$('.blog_body a').css({"border-radius": "7px", "-moz-border-radius":"7px", "-webkit-border-radius":"7px"});
	$('.topnav li a').css({"border-radius": "7px", "-moz-border-radius":"7px", "-webkit-border-radius":"7px"});
	$('#slider_controls ul li a').css({"border-radius": "7px", "-moz-border-radius":"7px", "-webkit-border-radius":"7px"});
	$('#nav1').css({"border-radius": "7px", "-moz-border-radius":"7px", "-webkit-border-radius":"7px"});
	
});

Cufon.replace('h1, h2, h3,.topnav,.post_leave',{ hover:true } );	