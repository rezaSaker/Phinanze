<?php

/*
	*Receive data sent from MyCost app 
	*Register a new user
	*Returns the user id and an unique token 
*/

require_once('connectDB.php');

if(isset($_POST['username']) && isset($_POST['password']) && isset($_POST['activationCode']))
{	
	$username       = mysqli_real_escape_string($connect, $_POST['username']);
	$password       = mysqli_real_escape_string($connect, $_POST['password']);
	$activationCode = mysqli_real_escape_string($connect, $_POST['activationCode']);
	
	//verify the request
	$query  = "SELECT * FROM activation_codes WHERE code = '$activationCode'";
	$result = mysqli_query($connect, $query) or die('Server connection error');
	$count  = mysqli_num_rows($result);
	
	if($count < 1)
	{
		//activation code is invalid
		die('Invalid activation code');
	}
	
	//if the filtered username doesn't match the exact username as entered by the user,
	//then the username contains potential risky character and new username would be required
	if($username != $_POST['username']) 
	{
		die('Please choose a different username');
	}	
	
	//check if the username already exists
	$query  = "SELECT * FROM users WHERE username = '$username'";
	$result = mysqli_query($connect, $query) or die('Server connection error');
	$count  = mysqli_num_rows($result);
	
	if($count > 0)
	{
		die('This username already exists');
	}
	
	//generate a random string as temporary access token
	$token = RandomToken();
	
	//hash password
	$password = password_hash($password, PASSWORD_DEFAULT);
	
	//save the user info
	$query  = "INSERT INTO users (username, password, token) 
			  VALUES ('$username', '$password', '$token')";
	$result = mysqli_query($connect, $query) or die('Server connection error');	
	$userid = mysqli_insert_id($connect);
	
	//add a new row in category table with the default categories for this user
	$earningCategories = 'Pay cheque|Business|Gift|Bonus|Refund|Other';
	$expenseCategories = 'House rent|Car|Transit|Groccery|Medical expense|Eating outside|Other';
	
	$query  = "INSERT INTO categories (earningCategories, expenseCategories, userid) 
			  VALUES ('$earningCategories', '$expenseCategories', '$userid')";
	$result = mysqli_query($connect, $query) or die("Server connection error");

	//Activation code expire after one user
	//so delete the activation code
	$query  = "DELETE FROM activation_codes WHERE code = '$activationCode'";
	$result = mysqli_query($connect, $query) or die('Server connection error');
	
	//return the userid and the access token to MyCost app 
	die($userid . '|' . $token);	
}
else
{ 
	die('Server connection error'); 
}

function RandomToken()
{	
	$charSet    = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
	$charSetLen = strlen($charSet);
	$tokenLen   = mt_rand(70, 100);
	$randStr    = "";
	
	for($i = 0; $i < $tokenLen; $i++)
	{
		$index = rand(0, $charSetLen - 1);
		$randStr .= $charSet[$index];
	}
	
	return $randStr;
}

?>