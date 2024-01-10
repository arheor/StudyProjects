<?php
defined('e-shop') or die('Доступ запрещён!');
$db_host		= 'localhost';
$db_user		= 'u0729485_mron';
$db_pass		= '4tG28dqT';
$db_database	= 'u0729485_db_shop'; 

$link = mysql_connect($db_host,$db_user,$db_pass);

mysql_select_db($db_database,$link) or die("Нет соединения с БД ".mysql_error());
mysql_set_charset("utf8");
?>