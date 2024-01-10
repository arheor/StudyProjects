<?php
    define('e-shop', true);
	include("include/db_connect.php");
    include("functions/functions.php");
    session_start();
    include("include/auth_cookie.php"); 
?>
<!DOCTYPE HTML>
<html>
<head>
	<meta http-equiv="content-type" content="text/html; charset=UTF-8" />

    <link href="css/reset.css" rel="stylesheet" type="text/css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="trackbar/trackbar.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript" src="/js/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="/js/jcarousellite_1.0.1.js"></script>
    <script type="text/javascript" src="/js/shop-script.js"></script>
    <script type="text/javascript" src="/js/jquery.cookie.min.js"></script>
    <script type="text/javascript" src="/trackbar/jquery.trackbar.js"></script>
    <script type="text/javascript" src="/js/TextChange.js"></script>
    
	<title>Интернет-магазин цифровой техники</title>
</head>
<body>

<div id="block-body">
<?php
    include("include/block-header.php");
?>
<div id="block-left">
<?php
    include("include/block-category.php");
    include("include/block-parameter.php");
    include("include/block-news.php");
?>
</div>
<div id="block-content">
<div id="block-map">
    
    <script type="text/javascript" charset="utf-8" async src="https://api-maps.yandex.ru/services/constructor/1.0/js/?um=constructor%3A0004dc15a51f556fa0dff906e2339c30d196d0dcefa2c92ed955b49b446045e9&amp;width=500&amp;height=400&amp;lang=ru_RU&amp;scroll=true"></script>

</div>
<div id="block-information">
        
        <h3 align=left>Наш магазин находится по адресу:</h3>
        <p align=left>г. Краснодар, ул. Красная, 145</p>
        <h3 align=left>График работы:</h3>
        <p align=left>Пн-Пт с 9:00 до 18:00</p>
        <p align=left>Сб, Вс - выходные</p>
        
</div>
</div>
<?php	
    include("include/block-footer.php");
?>
</div>

</body>
</html>