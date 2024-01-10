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
<div id="block-info">
        
        <p align=center>Сайт разработан в качестве выпускной квалификационной работы</p>

</div>
</div>
<?php	
    include("include/block-footer.php");
?>
</div>

</body>
</html>