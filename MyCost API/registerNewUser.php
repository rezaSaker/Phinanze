<?php

require_once('connectDb.php');

if(isset($_POST['username']) && isset($_POST['password']))
{
	$username = $_POST['username'];
	$password = $_POST['password'];
	
	//check if the username contains any potential risky characters
	$checkedUsername = mysqli_real_escape_string($connectDB, $username);	
	if($checkedUsername != $username) 
		die('Please choose a different username');
	
	//checks if the username already exists
	$query = "SELECT * FROM users WHERE username = '$username'";
	$result = mysqli_query($connectDB, $query);
	$count = mysqli_num_rows($result);
	if($count > 0) 
		die('The username already exists. Please choose a different username');
	
	//saves the user info
	$password = md5(base64_encode($password));
	$query = "INSERT INTO users (username, password) VALUES ('$username', '$password')";
	mysqli_query($connectDB, $query);
	
	echo mysqli_insert_id($connectDB);
	
	mysqli_close($connectDb);
}