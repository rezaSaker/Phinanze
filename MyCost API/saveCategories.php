<?php
/*
	*this file receives category name and type
	*save the category in the database
	*return SUCEESS or error info
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
		$categoryNames = $_POST['categoryNames'];
		$categoryType = $_POST['categoryType'];			
		$query = "";
		
		if($categoryType == 'Expense')
		{			
			$query = "UPDATE categories SET expenseCategories = '$categoryNames' WHERE userid = '$userid'";
		}
		else
		{
			$query = "UPDATE categories SET earningCategories = '$categoryNames' WHERE userid = '$userid'";
		}
		
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