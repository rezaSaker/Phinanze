<?php

/*
	*Recieve data sent from MyCost App
	*Verify user's login credentials
	*Return the user's id and a temporary access token
*/

require_once('connectDB.php');
require_once('encryption.php');
	
if(isset($_POST['key']) && isset($_POST['username']) && isset($_POST['password']))
{	
	$key      = mysqli_real_escape_string($connect, $_POST['key']);
	$username = mysqli_real_escape_string($connect, $_POST['username']);
	$password = mysqli_real_escape_string($connect, $_POST['password']);
			
	//verify user's login credentials
	$query  = "SELECT * FROM users WHERE username = '$username' LIMIT 1";
	$result = mysqli_query($connect, $query) or die('Server connection error');;		
	$count  = mysqli_num_rows($result);
	$hashedPass = "";
	
	if($count > 0)
	{
		$row = mysqli_fetch_array($result);
		$hashedPass = $row['password'];
		
		if(password_verify($password, $hashedPass))
		{
			$userid = $row['id'];
			
			//generate a random access token
			$token = RandomToken();
			$encToken = Encrypt($token, $key);
				
			//save the token into DB
			$query  = "UPDATE users SET token = '$encToken' WHERE id = '$userid'";
			$result = mysqli_query($connect, $query) or die('Server connection error');

			die($userid . '|' . $token);			
		}
		else
		{ 
			die('Invalid username or password'); 
		}
	}
	else
	{
		die('Invalid username or password');
	}
}
else 
{ 
	die('Server connection error');
}
	

function RandomToken()
{	
	$charSet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
	$charSetLen = strlen($charSet);
	$tokenLen = mt_rand(70, 100);
	$randStr = "";
	
	for($i = 0; $i < $tokenLen; $i++)
	{
		$index = rand(0, $charSetLen - 1);
		$randStr .= $charSet[$index];
	}
	
	return $randStr;
}
			
?>