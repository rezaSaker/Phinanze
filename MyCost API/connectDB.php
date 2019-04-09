<?php

/*
	*connect to the database
	*this file is used by several other files
*/


DEFINE('SERVER', 'server name');
DEFINE('USERNAME', 'username');
DEFINE('PASSWORD', 'password');
DEFINE('DATABASE', 'database name');

$connect = mysqli_connect(SERVER, USERNAME, PASSWORD, DATABASE) or die('Server connection error');

?>