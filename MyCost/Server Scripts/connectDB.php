<?php
DEFINE('SERVER', 'server_address');
DEFINE('USERNAME', 'username');
DEFINE('PASSWORD', 'password');
DEFINE('DATABASE', 'Database_name');

$connectDB = mysqli_connect(SERVER, USERNAME, PASSWORD, DATABASE) or die("SERVER_ERROR");

?>