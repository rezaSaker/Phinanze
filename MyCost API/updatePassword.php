<?php

/*
	*this file recieves current password and new password
	*updates the current password with the new password
	*returns SUCCESS or error message
*/

require_once('connectDB.php');

if(isset($_POST['key']) && isset($_POST['token']) && isset($_POST['userid']))
{
	$key = mysqli_real_escape_string($connect, $_POST['key']);
	$token = mysqli_real_escape_string($connect, $_POST['token']);
	$userid = mysqli_real_escape_string($connect, $_POST['userid']);
	
	//verify the request
	$query = "SELECT * FROM users WHERE token = '$token' AND access_key = '$key' AND id = '$userid'";
	$result = mysqli_query($connect, $query) or die('Server connection error');
	$count = mysqli_num_rows($result);
	
	if($count > 0)//request verified as authentic
	{		
		$username = mysqli_real_escape_string($connect, $_POST['username']);
		$currentPassword = md5(base64_encode($_POST['currentPassword']));
			
		//checks if the current password is valid
		$query = "SELECT * FROM users WHERE username = '$username' AND password = '$currentPassword'
				  AND id = '$userid'";
		$result = mysqli_query($connect, $query) or die('Server connection error');
		$count = mysqli_num_rows($result);
		
		if($count > 0) //current password is valid
		{
			$newPassword = md5(base64_encode($_POST['newPassword']));
			
			//update the current password
			$query = "UPDATE users SET password = '$newPassword' WHERE username = '$username'
					  AND password = '$currentPassword' AND id = '$userid'";
			mysqli_query($connect, $query) or die('Server connection error');
			
			die('SUCCESS');
		}
		else
		{
			die('Invalid passoword');
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