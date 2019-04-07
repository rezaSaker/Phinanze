<?php

include('connectDB.php');
	
if(isset($_POST['username']) && isset($_POST['password']))
{
	$username = $_POST['username'];
	$password = $_POST['password'];
	
	$username = mysqli_real_escape_string($connectDB, $username);
	$password = md5($password);
		
	$query = "SELECT * FROM users WHERE username = '$username' AND password = '$password'";

	$result = mysqli_query($connectDB, $query) or die($connectDB);
		
	$count = mysqli_num_rows($result);

	if($count > 0) 
		die('USER_FOUND');
	else 
		die('USER_NOT_FOUND');
}

die('ERROR');
			
?>