<?php
/*
	*this script recieves data that is sent from MyCost app
	*saves the data into the 'mycost' database
	*return 'SUCCESS' or error info
*/

require_once('connectDB.php');

if(isset($_POST['token']) && isset($_POST['key']) && isset($_POST['userid']))
{
	$token = mysqli_real_escape_string($connect, $_POST['token']);
	$key = mysqli_real_escape_string($connect, $_POST['key']);
	$userid = mysqli_real_escape_string($connect, $_POST['userid']);

	//verify request
	$query = "SELECT id FROM users WHERE token = '$token' AND access_key = '$key'";
	$result = mysqli_query($connect, $query) or die('Server connection error');
	$row = mysqli_fetch_array($result);
	$id = $row['id'];
	
	if($id == $userid)//request verified as authentic
	{
		$note = mysqli_real_escape_string($connect, $_POST['note']);
		$day = mysqli_real_escape_string($connect, $_POST['day']);
		$month = mysqli_real_escape_string($connect, $_POST['month']);
		$year = mysqli_real_escape_string($connect, $_POST['year']);
		$expenseReasons = mysqli_real_escape_string($connect, $_POST['expenseReasons']);
		$expenseAmounts = mysqli_real_escape_string($connect, $_POST['expenseAmounts']);
		$expenseCategories = mysqli_real_escape_string($connect, $_POST['expenseCategories']);
		$expenseComments = mysqli_real_escape_string($connect, $_POST['expenseComments']);
		$earningSources = mysqli_real_escape_string($connect, $_POST['earningSources']);
		$earningAmounts = mysqli_real_escape_string($connect, $_POST['earningAmounts']);
		$earningCategories = mysqli_real_escape_string($connect, $_POST['earningCategories']);
		$earningComments = mysqli_real_escape_string($connect, $_POST['earningComments']);
		$totalExpense = mysqli_real_escape_string($connect, $_POST['totalExpense']);
		$totalEarning = mysqli_real_escape_string($connect, $_POST['totalEarning']);
		
		//if any row already exists with the same day, month and year,
		//we will update that, otherwise we'll insert a new row
		
		//checks for existing rows
		$query = "SELECT id FROM daily_info WHERE day = '$day' AND month = '$month'
					AND year = '$year' AND userid = '$userid'";
		$result = mysqli_query($connect, $query) or die('Server connection error');
		$count = mysqli_num_rows($result);
		
		$id = "";
		
		if($count > 0)
		{
			$row = mysqli_fetch_array($result);
			$id = $row['id'];
			
			//update existing row
			$query = "UPDATE daily_info SET note = '$note', expenseReasons = '$expenseReasons',
						expenseAmounts = '$expenseAmounts', expenseCategories = '$expenseCategories',
						expenseComments = '$expenseComments', earningSources = '$earningSources',
						earningAmounts = '$earningAmounts', earningCategories = '$earningCategories',
						earningComments = '$earningComments', totalExpense = '$totalExpense',
						totalEarning = '$totalEarning' WHERE id = '$id'";
			$result = mysqli_query($connect, $query) or die('Server connection error');
			
			die('SUCCESS');
		}
		else
		{
			//inserts new row
			$query = "INSERT INTO daily_info (note, day, month, year, expenseReasons, expenseAmounts, 
					  expenseCategories, expenseComments, earningSources, earningAmounts, earningCategories,
					  earningComments, userid, totalExpense, totalEarning) VALUES ('$note', '$day', '$month',
					  '$year', '$expenseReasons', '$expenseAmounts', '$expenseCategories', '$expenseComments',
					  '$earningSources', '$earningAmounts', '$earningCategories', '$earningComments', '$userid',
					  '$totalExpense', '$totalEarning')";
			$result = mysqli_query($connect, $query) or die('Server connection error');
			
			die('SUCCESS');
		}
	}
	else //request from unauthentic source
	{
		die('Sorry, something went wrong');
	}
}
else
{ 
	die('Sorry, something went wrong'); 
}

?>