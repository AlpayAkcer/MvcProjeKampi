// Document load event

"use strict";

var wrapper = $(".lx-wrapper");
var menu = $(".lx-main-menu", ".lx-wrapper");
var blocs = $(".lx-blocs", ".lx-wrapper");
var blogs = $(".lx-blogs", ".lx-wrapper");
var infoImg = $(".lx-personal-info-img", ".lx-wrapper");
var mainImg = $(".lx-personal-info-img img");

$(window).on("load",function(){
	
	window.setTimeout(function(){
		// Loader Fade Out
		$(".lx-loader", ".lx-wrapper").fadeOut();		
	},1000)
	
	return false;
});

$(document).on("ready",function(){
	
	// Resize blocs
	if($(window).width() > 768){
		menu.attr("style","height:"+wrapper.height()+"px");
		blocs.attr("style","height:"+wrapper.height()+"px;overflow:auto;");
		blogs.attr("style","height:"+wrapper.height()+"px;overflow:auto;");
		infoImg.attr("style","height:"+wrapper.height()+"px;background:url("+mainImg.attr("src")+") center no-repeat;background-size:cover;")
		mainImg.remove();
	}

	// Redirection to the requested bloc
	hashHistory();

	return false;
});

$(window).on("hashchange",function(){	
	
	// Redirection to the requested bloc
	hashHistory();
	
	return false;
});

function hashHistory(){
	
	var page = "";
	if(window.location.hash) {
		page = document.location.hash;
		page = page.replace(/\#/,"");
	}
	else{
		page = "home";
	}
	
	// Remove active class from menus
	$(".lx-main-menu ul li a").removeClass("active");
	
	// Set clicked menu active
	$(".lx-main-menu ul li a[data-url='"+page+"']").addClass("active");
			
	// Show correspondant scetion
	if($(window).width() > 768){
		blocs.fadeOut();
		$("."+$(".lx-main-menu ul li a[data-url='"+page+"']").attr("data-title")).fadeIn();		
	}
	else{
		window.setTimeout(function(){
			$('html, body').animate({scrollTop : $("."+$(".lx-main-menu ul li a[data-url='"+page+"']").attr("data-title")).offset().top-50},1000);
			$(".lx-main-menu ul").slideUp();
		},1000);
	}
	
}

$(window).on("resize",function(){
	
	// Resize blocs
	if($(window).width() > 768){
		menu.attr("style","height:"+wrapper.height()+"px");
		blocs.attr("style","height:"+wrapper.height()+"px;overflow:auto;");
		infoImg.height(wrapper.height());
	}
	else{
		menu.attr("style","height:auto");
		blocs.attr("style","height:auto");
		blogs.attr("style","height:auto");
	}
	
	return false;
});

$(".lx-skills").on("scroll",function(){
	if($(this).scrollTop() > $(".lx-bars-chart", this).position().top){
		// Loading bars
		for(var i = 0;i < $(".lx-bar", ".lx-bars-chart").length;i++){
			$(".lx-bar:eq("+i+") .lx-bar-counter", ".lx-bars-chart").text($(".lx-bar:eq("+i+")", ".lx-bars-chart").attr("data-max")+"%");
			$(".lx-bar:eq("+i+") .lx-bar-fill", ".lx-bars-chart").css("width",$(".lx-bar:eq("+i+")", ".lx-bars-chart").attr("data-max")+"%");			
		}	
	}
	
	return false;
});

$(document).on("scroll",function(){
	if($(this).scrollTop() > $(".lx-bars-chart", this).position().top){
		// Loading bars
		for(var i = 0;i < $(".lx-bar", ".lx-bars-chart").length;i++){
			$(".lx-bar:eq("+i+") .lx-bar-counter", ".lx-bars-chart").text($(".lx-bar:eq("+i+")", ".lx-bars-chart").attr("data-max")+"%");
			$(".lx-bar:eq("+i+") .lx-bar-fill", ".lx-bars-chart").css("width",$(".lx-bar:eq("+i+")", ".lx-bars-chart").attr("data-max")+"%");			
		}	
	}
	
	return false;
});

// Main menu event : show correspondant section
$(".lx-main-menu ul li a").on("click",function(){
	var patt = /Home|/;
	if(patt.test(location.pathname)){
		// Remove active class from menus
		$(".lx-main-menu ul li a").removeClass("active");
		
		// Set clicked menu active
		$(this).addClass("active");
		
        history.pushState('data', '','/Home#'+$(this).attr("data-url"));
		
		// Show correspondant scetion
		if($(window).width() > 768){
			blocs.fadeOut();
			$("."+$(this).attr("data-title")).fadeIn();		
		}
		else{
			$('html, body').animate({scrollTop : $("."+$(this).attr("data-title")).offset().top-50},1000);
			$(".lx-main-menu ul").slideUp();
		}
	}
});

// Responsive menu event
$(".lx-main-menu > i").on("click",function(){
	
	var menuUl = $(".lx-main-menu ul");
	if(menuUl.css("display") != "block"){
		menuUl.slideDown();
	}
	else{
		menuUl.slideUp();
	}
	
	return false;
});	

// Responsive color setting event
$(".lx-color-setting > i").on("click",function(){
	
	var colorSetting = $(".lx-color-setting");
	if(colorSetting.css("right") == "-145px"){
		colorSetting.css("right","0px");
	}
	else{
		colorSetting.css("right","-145px");
	}
	
	return false;
});	

// Responsive color event
$(".lx-colors a").on("click",function(){
	$("link[title='main']").attr("href","css/"+$(this).attr("data-css-link"));
	
	return false;
});


// Contact Form Errors
$(".lx-contact form input[type='button']").on("click",function(){
	
	$(".lx-contact form span").remove();
	$(".lx-contact form input[type='text']").css("border-right","0px");
	$(".lx-contact form textarea").css("border-right","0px");
	
	var fullname = $(".lx-contact form input[name='fullname']");
	if(fullname.val() == ""){
		fullname.after("<span>This field must be filled</span>").css("border-right","3px solid #a94442");
	}
	
	var email = $(".lx-contact form input[name='email']");
	var patt = /^[a-z0-9._-]+@[a-z0-9._-]{2,}\.[a-z]{2,4}$/;
	if(!patt.test(email.val())){
		email.after("<span>Invalid Email</span>").css("border-right","3px solid #a94442");
	}
	
	var txtarea = $(".lx-contact form textarea");
	if(txtarea.val() == ""){
		txtarea.after("<span>This field must be filled</span>").css("border-right","3px solid #a94442");
	}

	if($(".lx-contact form span").length == 0){
		var url = "send-contact-form.php?fullname="+fullname.val()+"&email="+email.val()+"&message="+txtarea.val();
		var posting = $.post( url );
		posting.done(function( data ) {
			$(".lx-contact-saved").html(data);	
			$(".lx-contact form input[name='fullname']").val("");
			$(".lx-contact form input[name='email']").val("");
			$(".lx-contact form textarea").val("");
		});	
	}
	
	return false;
});

$(".lx-contact form input[name='email']").on("keyup",function(){
	var patt = /^[a-z0-9._-]+@[a-z0-9._-]{2,}\.[a-z]{2,4}$/;
	if(patt.test($(this).val())){
		$(this).css("border-right","0px").next("span").remove();
	}
	
	return false;
});

$(".lx-contact form input[name='fullname']").on("keyup",function(){
	if($(this).val() != ""){
		$(this).css("border-right","0px").next("span").remove();
	}
	
	return false;
});

$(".lx-contact form textarea").on("keyup",function(){
	if($(this).val() != ""){
		$(this).css("border-right","0px").next("span").remove();
	}
	
	return false;
});