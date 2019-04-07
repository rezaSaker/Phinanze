<?php

include('connectDB.php');
	
if(isset($_POST['username']) && isset($_POST['password']))
{
	$username = $_POST['username'];
	$password = $_POST['password'];
	
	$username = mysqli_real_escape_string($connectDB, $username);
	$password = md5(base64_encode($password));
		
	$query = "SELECT * FROM users WHERE username = '$username' AND password = '$password'";

	$result = mysqli_query($connectDB, $query);
		
	$count = mysqli_num_rows($result);

	if($count > 0)
	{
		$row = mysqli_fetch_array($result);
		$userid = $row['id'];
		echo $userid;
	}
	else
	{
		echo 'USER_NOT_FOUND';
	}
	
	mysqli_close($connectDB);
		
}
			
?>