<?php
DEFINE('SERVER', 'server name');
DEFINE('USERNAME', 'username');
DEFINE('PASSWORD', 'password');
DEFINE('DATABASE', 'database name');

$connectDB = mysqli_connect(SERVER, USERNAME, PASSWORD, DATABASE) or die("SERVER_ERROR");

?>