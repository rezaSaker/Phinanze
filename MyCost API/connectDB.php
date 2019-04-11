<?php

/*
	*connect to the database
	*this file is used by several other files
*/

DEFINE('SERVER', 'localhost');
DEFINE('USERNAME', 'root');
DEFINE('PASSWORD', 'mysql1997');
DEFINE('DATABASE', 'mycost');

$connect = mysqli_connect(SERVER, USERNAME, PASSWORD, DATABASE) or die('Server connection error');

?>