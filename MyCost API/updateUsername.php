<?php

/*
	*this file recieves current username and new username
	*updates the current username with the new username
	*returns SUCCESS or error message
*/

require_once('connectDB.php');

if(isset($_POST['key']) && isset($_POST['token']) && isset($_POST['userid']))
{
	$key 	= mysqli_real_escape_string($connect, $_POST['key']);
	$token  = mysqli_real_escape_string($connect, $_POST['token']);
	$userid = mysqli_real_escape_string($connect, $_POST['userid']);
	
	//verify the request
	$query  = "SELECT id FROM users WHERE token = '$token' AND access_key = '$key'";
	$result = mysqli_query($connect, $query) or die('Server connection error');
	$row    = mysqli_fetch_array($result);
	$id     = $row['id'];
	
	if($id == $userid)//request verified as authentic
	{		
		$currentUsername = mysqli_real_escape_string($connect, $_POST['currentUsername']);
		$newUsername = $_POST['newUsername'];
		
		//checks if new username cotains risky characters
		$checkedNewUsername = mysqli_real_escape_string($connect, $newUsername);		
		if($checkedNewUsername != $newUsername)
			die('Please choose a different username');
		
		//checks if new username is laready taken by another user_error
		$query = "SELECT id FROM users WHERE username = '$newUsername'";
		$result = mysqli_query($connect, $query) or die('Server connection error');
		$count = mysqli_num_rows($result);
		if($count > 0)
			die('Username is already taken. Please choose a different username');
		
		//updates the current username with the new username
		$query = "UPDATE users SET username = '$newUsername' WHERE username = '$currentUsername' AND id = '$userid'";
		mysqli_query($connect, $query) or die('Server connection error');
		
		die('SUCCESS');
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