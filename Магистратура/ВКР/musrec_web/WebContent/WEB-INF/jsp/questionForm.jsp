<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<%@ taglib prefix="f" uri="http://java.sun.com/jstl/core_rt"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<video autoplay muted loop id="myVideo">
  <source src="video/Lines-min.mp4" type="video/mp4">
</video>
	<script type="text/javascript">
	
	function getRecommendations() {
		var SERVER_URL = "http://localhost:5000/"
		var END_POINT = SERVER_URL + "recommend?"

		var queryString = [];

		queryString.push(0.5);
		queryString.push(document.getElementById("acousticnessVal").textContent + 10);
		queryString.push(document.getElementById("danceabilityVal").textContent);
		queryString.push(document.getElementById("energyVal").textContent);
		queryString.push(document.getElementById("instrumentalnessVal").textContent);
		queryString.push(document.getElementById("livenessVal").textContent);
		queryString.push(document.getElementById("loudnessVal").textContent);
		//queryString.push(document.getElementById("melodityVal").textContent);
		queryString.push(document.getElementById("speechinessVal").textContent);
		queryString.push(document.getElementById("valenceVal").textContent);
		queryString.push(document.getElementById("tempoVal").textContent);

		console.log(queryString);
		
		var res = {"featureVector" : queryString}
		var REST_CALL = END_POINT +  "query=" + JSON.stringify(res);
		
		var xhttp = new XMLHttpRequest();
		xhttp.open("GET", REST_CALL, true);
		
		xhttp.onload = function(e) {
			if (xhttp.readyState === 4) {
				if (xhttp.status === 200) {
					var myobj = JSON.parse(xhttp.responseText.replace(/\bNaN\b/g, "null"));
					console.log(xhttp.responseText)
					renderTable(myobj);
				} else {
					alert("ошибка");
					console.error("Ошибка сервера: ", xhttp.statusText);
				}
			}
		};
		xhttp.onerror = function(e) {
			console.error("Ошибка поключения к: ", SERVER_URL);
		};

		xhttp.send();
	}
	
	function renderTable(children){
  		var songTableDiv = document.getElementById("song_result");
  		
  		var table = document.createElement('table');
  		table.cellspacing = "0";
  		
  		var columnSize = {
				"albumart":"100px",
				"song":"200px",
				"artist":"150px",
				"album":"200px",
				"duration_ms":"80px"
		}
  		for (var i = 0; i < Object.keys(children).length; i++) {
			
  			var interestedKeys = ['albumart','song','artist','album','duration_ms']
			
			var child = Object.keys(children)[i]; //current key
			var tr = document.createElement('tr');
			var allKeys = Object.keys(children[child]); // all keys of current object
	    	
			if(i==0){
	    		var headerRow = document.createElement('tr');
				
	    		for(var k=0;k<interestedKeys.length;k++){
	    			var eachHeader = document.createElement("th");
	    			eachHeader.innerHTML = interestedKeys[k];
	    			eachHeader.style.width = columnSize[interestedKeys[k]];
	    			if(interestedKeys[k]!='albumart'){
	    				eachHeader.style.textAlign="center";
	    			}
	    			headerRow.appendChild(eachHeader);
	    		}
	    		table.appendChild(headerRow);	    		
	    	}
			
			for(var k=0;k<interestedKeys.length;k++){
    			var eachCell = document.createElement("td");
    			if(k==0){
    				var imgTag = document.createElement("img");
    				imgTag.src = children[child][interestedKeys[k]];
    				
    				eachCell.append(imgTag);
    			}else{
    				if(interestedKeys[k]=='duration_ms'){
    					var seconds = ((children[child][interestedKeys[k]] % 60000) / 1000).toFixed(0);
    					var mins = Math.floor(children[child][interestedKeys[k]] / 60000);
    					
    					eachCell.innerHTML = mins + ":" + seconds + "min";
    				}else{
    					eachCell.innerHTML = children[child][interestedKeys[k]];    					
    				}
    			}
    			tr.appendChild(eachCell);
    		}
			
			table.appendChild(tr);	
		}
  		songTableDiv.appendChild(table);
  	}
</script>
	<title>Рекомендации музыки</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700&display=swap" rel="stylesheet">
	<link rel="stylesheet" href="css/open-iconic-bootstrap.min.css">
    <link rel="stylesheet" href="css/animate.css">
    <link rel="stylesheet" href="css/owl.carousel.min.css">
    <link rel="stylesheet" href="css/owl.theme.default.min.css">
    <link rel="stylesheet" href="css/magnific-popup.css">
	<link rel="stylesheet" href="css/aos.css">
	<link rel="stylesheet" href="css/ionicons.min.css">
	<link rel="stylesheet" href="css/bootstrap-datetimepicker.min.css">	
	<link rel="stylesheet" href="css/nouislider.css">
	<link rel="stylesheet" href="css/flaticon.css">
    <link rel="stylesheet" href="css/icomoon.css">
    <link rel="stylesheet" href="css/style.css">
	<link rel="stylesheet" href="css/online.css">
  </head>
  <body>
	<f:set var="sessionUser" value="${userinfo}" scope="session"></f:set>
	<div class="main-section">

		<nav class="navbar navbar-expand-lg navbar-dark ftco_navbar bg-dark ftco-navbar-light" id="ftco-navbar">
			<div class="container">
				<form action="validat.htm" method="POST">
					<input type="hidden" name="home"/>
					<button class="navbar-brand">Назад</button>
				</form>
			</div>
		</nav>
		
		<section class="ftco-section goto-here pb-0">
			<div class="container">
				<div class="row">
	  			</div>
			</div>
		</section>
		
		<!-- Need to keep till this -->

		<section class="ftco-section" id="inputs">
			<div class="container">
				<div class="row justify-content-center">
					<div class="col-lg-6">
						
						<!-- First Slider -->
						
						<!-- <center>
							<button type="button" class="btn btn-primary" data-container="body" data-toggle="popover" data-placement="top" data-content="Указывает модальность (мажор или минор) трека. Мажор представлен 1, а минор - 0. Чем выше этот параметр, тем больше шансов, что трек будет мелодичным. ">
									  Мелодичность</button>
							<span class="badge badge-pill badge-rose p-2 px-3" id="melodityVal">0.5</span> 
							
						</center> -->
						<div class="customDivider"></div>
						<div id="slider-1" class="no-uicustom mb-4"></div>
						
						<div class="customDivider"></div>
						
						<!-- Second Slider -->
						<center>
							<button type="button" class="btn btn-primary" data-container="body" data-toggle="popover" data-placement="top" data-content="Мера достоверности (от 0.0 до 1.0) того, что композиция является акустической. Значение 1.0 указывает на высокую вероятность акустичности трека.">
									  Акустичность</button>
							<span class="badge badge-pill badge-rose p-2 px-3" id="acousticnessVal">0.5</span> 
							
						</center>
						<div class="customDivider"></div>
						<div id="slider-2" class="no-uicustom mb-4"></div>
						
						<div class="customDivider"></div>
						
						<!-- Third Slider -->
						<center>
							<button type="button" class="btn btn-primary" data-container="body" data-toggle="popover" data-placement="top" data-content="Танцевальность описывает, насколько трек подходит для танцев на основе комбинации музыкальных элементов, включая темп, стабильность ритма, силу удара и общую регулярность. Значение 0,0 наименее танцевальный, а 1,0 - наиболее танцевальный. ">
									  Танцевальность</button>
							<span class="badge badge-pill badge-rose p-2 px-3" id="danceabilityVal">0.5</span> 
							
						</center>
						<div class="customDivider"></div>
						<div id="slider-3" class="no-uicustom mb-4"></div>
						
						<div class="customDivider"></div>
						
						<!-- Fourth Slider -->
						<center>
							<button type="button" class="btn btn-primary" data-container="body" data-toggle="popover" data-placement="top" data-content="Энергичность представляет собой воспринимаемую степень интенсивности и активности звучания. Обычно энергичные треки кажутся быстрыми, громкими и шумными. К примеру, у дэт-метала высокие показатели энергичности, а у прелюдий Баха — низкие.">
									  Энергичность</button>
							<span class="badge badge-pill badge-rose p-2 px-3" id="energyVal">0.5</span> 
							
						</center>
						<div class="customDivider"></div>
						<div id="slider-4" class="no-uicustom mb-4"></div>
						
						<div class="customDivider"></div>
						
						<!-- Fifth Slider -->
						<center>
							<button type="button" class="btn btn-primary" data-container="body" data-toggle="popover" data-placement="top" data-content=" В этом контексте звуки типа «ооо» и «ааа» рассматриваются как инструментальные. Рэп или звуковые дорожки явно «вокальные». Чем ближе значение инструментальности к 1.0, тем больше вероятность, что трек не содержит вокального содержания.">
									  Инструментальность</button>
							<span class="badge badge-pill badge-rose p-2 px-3" id="instrumentalnessVal">0.5</span> 
							
						</center>
						<div class="customDivider"></div>
						<div id="slider-5" class="no-uicustom mb-4"></div>
						
						<div class="customDivider"></div>
						
						<!-- Sixth Slider -->
						<center>
							<button type="button" class="btn btn-primary" data-container="body" data-toggle="popover" data-placement="top" data-content="Более высокие значения живучести представляют собой повышенную вероятность того, что трек был исполнен в живую. Значение выше 0,8 обеспечивает высокую вероятность того, что трек будет исполненным в живую.">
									  Живость</button>
							<span class="badge badge-pill badge-rose p-2 px-3" id="livenessVal">0.5</span> 
							
						</center>
						<div class="customDivider"></div>
						<div id="slider-6" class="no-uicustom mb-4"></div>
						
						<div class="customDivider"></div>
						
						<!-- Seventh Slider -->
						<center>
							<button type="button" class="btn btn-primary" data-container="body" data-toggle="popover" data-placement="top" data-content="Общая громкость трека в децибелах (дБ). Значения громкости усредняются по всей дорожке и полезны для сравнения относительной громкости дорожек. ">
									  Громкость</button>
							<span class="badge badge-pill badge-rose p-2 px-3" id="loudnessVal">0.5</span> 
							
						</center>
						<div class="customDivider"></div>
						<div id="slider-7" class="no-uicustom mb-4"></div>
						
						<div class="customDivider"></div>
						
						<!-- Eighth Slider -->
						<center>
							<button type="button" class="btn btn-primary" data-container="body" data-toggle="popover" data-placement="top" data-content="Определяет, сколько речи в песне. Значения от 0,33 до 0,66 представляют собой типичную песню со смесью вокала и звуков. Все, что меньше, указывает на то, что в песне больше звуков, чем речи. Значение выше 0,66 означает, что песня в первую очередь выделяется речью.">
									  Речь</button>
							<span class="badge badge-pill badge-rose p-2 px-3" id="speechinessVal">0.5</span> 
							
						</center>
						<div class="customDivider"></div>
						<div id="slider-8" class="no-uicustom mb-4"></div>
						
						<div class="customDivider"></div>
						
						<!-- Nineth Slider -->
						<center>
							<button type="button" class="btn btn-primary" data-container="body" data-toggle="popover" data-placement="top" data-content="Мера от 0,0 до 1,0, описывающая музыкальную позитивность, передаваемую треком. Треки с высокой валентностью звучат более позитивно (например, счастливые, веселые, эйфорические), а треки с низкой валентностью звучат более негативно (например, грустно, подавленно, сердито). ">
									  Настроение</button>
							<span class="badge badge-pill badge-rose p-2 px-3" id="valenceVal">0.5</span> 
							
						</center>
						<div class="customDivider"></div>
						<div id="slider-9" class="no-uicustom mb-4"></div>
						
						<div class="customDivider"></div>
						
						<!-- Tenth Slider -->
						<center>
							<button type="button" class="btn btn-primary" data-container="body" data-toggle="popover" data-placement="top" data-content="Расчетное количество ударов в минуту (BPM) всей песни.">
									  Темп</button>
							<span class="badge badge-pill badge-rose p-2 px-3" id="tempoVal">0.5</span> 
							
						</center>
						<div class="customDivider"></div>
						<div id="slider-10" class="no-uicustom mb-4"></div>
						<center>
							<button type="button" class="btn btn-outline-light" onclick="getRecommendations()">Получить рекомендации</button>
						</center>
					</div>
				</div>
			</div>
		</section>
		<section class="ftco-section ftco-section-2">
			<div class="table-users" id="song_result">
				<div class="header">Рекомендации</div>
			</div>
		</section>
	</div>
	  <!-- loader -->
  <div id="ftco-loader" class="show fullscreen"><svg class="circular" width="48px" height="48px"><circle class="path-bg" cx="24" cy="24" r="22" fill="none" stroke-width="4" stroke="#eeeeee"/><circle class="path" cx="24" cy="24" r="22" fill="none" stroke-width="4" stroke-miterlimit="10" stroke="#F96D00"/></svg></div>

  <script src="js/jquery.min.js"></script>
  <script src="js/jquery-migrate-3.0.1.min.js"></script>
  <script src="js/popper.min.js"></script>
  <script src="js/bootstrap.min.js"></script>
  <script src="js/jquery.easing.1.3.js"></script>
  <script src="js/jquery.waypoints.min.js"></script>
  <script src="js/jquery.stellar.min.js"></script>
  <script src="js/owl.carousel.min.js"></script>
  <script src="js/jquery.magnific-popup.min.js"></script>
  <script src="js/aos.js"></script>

  <script src="js/nouislider.min.js"></script>
  <script src="js/moment-with-locales.min.js"></script>
  <script src="js/bootstrap-datetimepicker.min.js"></script>
  <script src="js/main.js"></script>
  <script type="text/javascript">
		
		// document.getElementById("slider-1").noUiSlider.on("slide",function(){
			// document.getElementById("melodityVal").innerHTML = document.getElementById("slider-1").noUiSlider.get();
		// });
		
		document.getElementById("slider-2").noUiSlider.on("slide",function(){
			document.getElementById("acousticnessVal").innerHTML = document.getElementById("slider-2").noUiSlider.get();
		});
		document.getElementById("slider-3").noUiSlider.on("slide",function(){
			document.getElementById("danceabilityVal").innerHTML = document.getElementById("slider-3").noUiSlider.get();
		});
		document.getElementById("slider-4").noUiSlider.on("slide",function(){
			document.getElementById("energyVal").innerHTML = document.getElementById("slider-4").noUiSlider.get();
		});
		document.getElementById("slider-5").noUiSlider.on("slide",function(){
			document.getElementById("instrumentalnessVal").innerHTML = document.getElementById("slider-5").noUiSlider.get();
		});
		document.getElementById("slider-6").noUiSlider.on("slide",function(){
			document.getElementById("livenessVal").innerHTML = document.getElementById("slider-6").noUiSlider.get();
		});
		document.getElementById("slider-7").noUiSlider.on("slide",function(){
			document.getElementById("loudnessVal").innerHTML = document.getElementById("slider-7").noUiSlider.get();
		});
		document.getElementById("slider-8").noUiSlider.on("slide",function(){
			document.getElementById("speechinessVal").innerHTML = document.getElementById("slider-8").noUiSlider.get();
		});
		document.getElementById("slider-9").noUiSlider.on("slide",function(){
			document.getElementById("valenceVal").innerHTML = document.getElementById("slider-9").noUiSlider.get();
		});
		document.getElementById("slider-10").noUiSlider.on("slide",function(){
			document.getElementById("tempoVal").innerHTML = document.getElementById("slider-10").noUiSlider.get();
		});
	</script>
  </body>
</html>