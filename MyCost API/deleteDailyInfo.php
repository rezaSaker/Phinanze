<?php
/*
	*this file receives day, month and year
	*deletes info of that particular date for the user
	*returns success or error message
*/

require_once('connectDB.php');

if(isset($_POST['key']) && isset($_POST['token']) && isset($_POST['userid']))
{
	$key = mysqli_real_escape_string($connect, $_POST['key']);
	$token  = mysqli_real_escape_string($connect, $_POST['token']);
	$userid = mysqli_real_escape_string($connect, $_POST['userid']);
	
	//verify the request
	$query  = "SELECT id FROM users WHERE token = '$token' AND access_key = '$key'";
	$result = mysqli_query($connect, $query) or die('Server connection error');
	$row = mysqli_fetch_array($result);
	$id  = $row['id'];
	
	if($id == $userid)//request verified as authentic
	{	
		$day = $_POST['day'];
		$month = $_POST['month'];
		$year = $_POST['year'];
		
		$query = "DELETE FROM daily_info WHERE day = '$day' AND month = '$month'
				  AND year = '$year' AND userid = '$userid'";
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