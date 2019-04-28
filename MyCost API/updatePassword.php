<?php

/*
	*Recieve current password and new password
	*Update the current password with the new password
	*Return SUCCESS or error message
*/

require_once('connectDB.php');
require_once('requestVerification.php');

if(isset($_POST['key']) && isset($_POST['token']) && isset($_POST['userid']))
{
	$key    = mysqli_real_escape_string($connect, $_POST['key']);
	$token  = mysqli_real_escape_string($connect, $_POST['token']);
	$userid = mysqli_real_escape_string($connect, $_POST['userid']);
	
	if(IsAuthenticRequest($connect, $userid, $token, $key))//request verified as authentic
	{		
		$username        = mysqli_real_escape_string($connect, $_POST['username']);
		$currentPassword = mysqli_real_escape_string($connect, $_POST['currentPassword']);
		$newPassword     = mysqli_real_escape_string($connect, $_POST['newPassword']);
		
		//checks if the current password is valid
		$query  = "SELECT * FROM users WHERE username = '$username' AND id = '$userid' LIMIT 1";
		$result = mysqli_query($connect, $query) or die('Server connection error');
		$row    = mysqli_fetch_array($result);
		
		$hashedPass = $row['password'];
		
		if(password_verify($currentPassword, $hashedPass)) //current password is valid
		{	
			//hash the new password
			$newPassword = password_hash($newPassword, PASSWORD_DEFAULT);
			
			//update the current password
			$query  = "UPDATE users SET password = '$newPassword' WHERE username = '$username' AND id = '$userid'";
			$result = mysqli_query($connect, $query) or die('Server connection error');
			
			die('SUCCESS');
		}
		else
		{
			die('Invalid passoword. Please try again');
		}
	}
	else //request from unauthentic source
	{
		die('Server connection error');
	}
}
else
{
	die('Server connection error');
}

?>