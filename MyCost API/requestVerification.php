<?php

/*
	*Verify if a request is from MyCost app
*/

require_once('encryption.php');

function IsAuthenticRequest($connect, $userid, $token, $key)
{
	//encrypt all arguments
	$token = Encrypt($token, $key);
	
	$query  = "SELECT * FROM users WHERE token = '$token' AND id = '$userid' LIMIT 1";
	$result = mysqli_query($connect, $query) or die('Server connection error');
	$count  = mysqli_num_rows($result);
	
	if($count > 0)
	{
		return true;
	}
	else
	{
		return false;
	}
}

?>