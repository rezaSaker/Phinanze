<?php

/*
	*this script recieves data that is sent from... 
	'...MyCost\ServerHandler.cs\RegisterNewUser(param1, param2)'
	*and returns the user 'id and a unique token' if the user is created
*/

require_once('connectDB.php');

if(isset($_POST['username']) && isset($_POST['password']) && isset($_POST['key']))
{
	$key = $_POST['key'];
	$username = $_POST['username'];
	$password = $_POST['password'];
	
	//check if the username contains any potential risky characters
	$checkedUsername = mysqli_real_escape_string($connect, $username);	
	if($checkedUsername != $username) 
		die('Please choose a different username');
	
	//checks if the username already exists
	$query = "SELECT * FROM users WHERE username = '$username'";
	$result = mysqli_query($connect, $query) or die('Server connection error');
	$count = mysqli_num_rows($result);
	if($count > 0) 
		die('The username already exists. Please choose a different username');
	
	//generate a random string as access token
	$token = RandomToken(70);
	
	//saves the user info
	$password = md5(base64_encode($password));
	$query = "INSERT INTO users (username, password, token, access_key) 
			  VALUES ('$username', '$password', '$token', '$key')";
	$result = mysqli_query($connect, $query) or die('Server connection error');
	
	$userid = mysqli_insert_id($connect);
	
	die($userid . '|' . $token);	
}
else{ die('Sorry, something went wrong'); }

function RandomToken($tokenLen)
{
	$charSet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
	$charSetLen = strlen($charSet);
	$randStr = "";
	
	for($i = 0; $i < $tokenLen; $i++)
	{
		$index = rand(0, $charSetLen - 1);
		$randStr .= $charSet[$index];
	}
	
	return $randStr;
}

?>