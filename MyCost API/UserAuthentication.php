<?php

/*
	*this script recieves data that is sent from... 
	'...MyCost\ServerHandler.cs\AuthenticateUser(param1, param2)'
	*and returns the user id and a unique token if the user exists in DB
*/

require_once('connectDB.php');
	
if(isset($_POST['key']))
{
	$access_key = mysqli_real_escape_string($connect, $_POST['key']);
	
	//check if the access_key is valid
	$query = "SELECT * FROM users WHERE access_key = '$access_key'";
	$result = mysqli_query($connect, $query) or die('SERVER_ERROR');
	$count = mysqli_num_rows($result);
	
	if($count > 0)
	{
		$username = $_POST['username'];
		$password = $_POST['password'];
		
		//Important note: using mysqli_real_escape_string won't change anything...
		//..in the string 'username' if the username is correct...
		//...because when registering the user, we check the username with mysqli_real_escape_string...
		//...and if we found anything risky we require user to enter a different username
		
		$username = mysqli_real_escape_string($connect, $username);
		$password = md5(base64_encode($password));
			
		$query = "SELECT id FROM users WHERE username = '$username' AND password = '$password' AND access_key = '$access_key'";
		$result = mysqli_query($connect, $query) or die('Server connection error');;		
		$count = mysqli_num_rows($result);

		if($count > 0)
		{
			$row = mysqli_fetch_array($result);
			$userid = $row['id'];
			
			//for security enhancement we generate and a random string...
			//...which is passed to our app as server access token
			$token = RandomToken(70);
			$query = "UPDATE users SET token = '$token' WHERE id = '$userid'";
			$result = mysqli_query($connect, $query) or die('Server connection error');

			die($userid . '|' . $token);
			
		}
		else{ die('Invalid username or password'); }	
	}
	else{ die('Please create an account first'); }
}
else { die('Sorry, something went wrong'); }
	

function RandomToken($tokenLen)
{
	$charSet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890.,@$&^*";
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