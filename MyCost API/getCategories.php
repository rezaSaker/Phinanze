<?php
/*
	*this script reads categories from database 
	*and returns the catories to MyCost app
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
	{	$data = "";
		$rowNum =  1;
		
		//get expense categories for the user from DB
		$query   = "SELECT * FROM categories WHERE userid = '$userid'";
		$result  = mysqli_query($connect, $query) or die('Server connection error');
		
		//takes the expense categories for theis user
		while($row = mysqli_fetch_array($result))
		{			
			if($rowNum > 1)
			{
				//adds a splitting character before each row except the first one
				$data .= '|';
			}
			else
			{
				$rowNum = 2;
			}
			
			$data .= $row['earningCategories'];
		}
		
		//adds a splitting character between expense categories and earning categories
		$data .= '^';
		
		$rowNum = 1;
		
		//takes earning categories for the user
		while($row = mysqli_fetch_array($result))
		{			
			if($rowNum > 1)
			{
				//adds a splitting character before each row except the first one
				$data .= '|';
			}
			else
			{
				$rowNum = 2;
			}
			
			$data .= $row['eexpenseCategories'];
		}
		
		die($data);
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