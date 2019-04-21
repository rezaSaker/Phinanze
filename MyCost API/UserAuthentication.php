<?php

/*
	*this script recieves data that is sent from MyCost App
	*verifies user's login credentials
	*and returns the user's id and a unique token
*/

require_once('connectDB.php');
	
if(isset($_POST['key']))
{
	$access_key = mysqli_real_escape_string($connect, $_POST['key']);
	
	//verify request
	$query = "SELECT * FROM users WHERE access_key = '$access_key'";
	$result = mysqli_query($connect, $query) or die('Server connection error');
	$count = mysqli_num_rows($result);
	
	if($count > 0)//request verified as authentic
	{
		$username = $_POST['username'];
		$password = $_POST['password'];
		
		//Important note: using mysqli_real_escape_string won't change anything
		//in the string 'username' if the username is correct
		//because when registering the user, we check the username with mysqli_real_escape_string
		//and if we found anything risky we require user to enter a different username	
		$username = mysqli_real_escape_string($connect, $username);
		$password = md5(base64_encode($password));
			
		//verify user's login credentials
		$query  = "SELECT id FROM users WHERE access_key = '$access_key' AND username = '$username' AND password = '$password'";
		$result = mysqli_query($connect, $query) or die('Server connection error');;		
		$count  = mysqli_num_rows($result);

		if($count > 0)
		{
			$row    = mysqli_fetch_array($result);
			$userid = $row['id'];
			
			//for security enhancement we generate a random string
			//which is passed to our app as server access token
			$token  = RandomToken(100);
			
			//save the token into DB
			$query  = "UPDATE users SET token = '$token' WHERE id = '$userid'";
			$result = mysqli_query($connect, $query) or die('Server connection error');

			die($userid . '|' . $token);			
		}
		else
		{ 
			die('Invalid username or password'); 
		}	
	}
	else//request sent with unknown/invalid key
	{ 
		die('Please create an account first'); 
	}
}
else 
{ 
	die('Server connection error');
}
	

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