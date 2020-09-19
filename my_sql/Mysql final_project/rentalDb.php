<?php
/*
    name : Thomas Zangari 
*/
$con = mysqli_connect('localhost','root','thomas78','videostore');
if (!$con) {
    die('Could not connect: ' . mysqli_error($con));
}


 $check = $_REQUEST['check'];


if($check == 1)//return
{
   

   $first_name = $_REQUEST['first_name'];  
   $last_name = $_REQUEST['last_name']; 
   $video_name = $_REQUEST['video_name'];
   $returned_date = $_REQUEST['date'];    
   $q = "Select customer_id from customer where First_Name = '$first_name ' AND Last_Name ='$last_name'";
   if ($result=mysqli_query($con, $q)){
	    
   
     } else {
       echo "Error: " . $q . "<br>" . mysqli_error($con);}
   if($row = mysqli_fetch_array($result))
   {
          $customer_id = $row['customer_id'];
          	  
   }
   else
   {
        echo " Customer not found";
        exit;
   }
   $q = "Select Video_id from table_video where Title = '$video_name'";
  if ($result=mysqli_query($con, $q)) {
    
} else {
    echo "Error: " . $q . "<br>" . mysqli_error($con);}
	if($row = mysqli_fetch_array($result))
   {
       $video_id = $row['Video_id'];
	 
         
   }
   else
   {
       echo "video not found";
          exit;	
   }
	
    $q= "Select	due_date  From rental where customer_id ='".$customer_id."' And video_id = '".$video_id."'";	 
    if ($result=mysqli_query($con, $q)){
	    
   
     } else {
       echo "Error: " . $q . "<br>" . mysqli_error($con);}
   if($row = mysqli_fetch_array($result))
   {
        $due_date = $row['due_date'];
       	  
   }
   $days_count = $due_date;
   $overdue = false;
   if($due_date < $returned_date)
   {
      $count = 0;
      while($days_count < $returned_date)
	  {
	    
        $days_count = date('Y-m-d', strtotime($days_count.' + 1 days'));
		$overdue = true;
        $count++;
	  }
	  $rental_charges = (3 + ($count * 2));
	  
   }   
   $q = "UPDATE rental SET Returned_date ='".$returned_date."', Is_it_returned = 'Y' , rental_charges ='".$rental_charges."' where  video_id = '".$video_id."'";
   if ($result=mysqli_query($con, $q)){
	   echo'Record has been updated'; 
   
     } else {
       echo "Error: " . $q . "<br>" . mysqli_error($con);}
	  
   $q = "Select customer.First_Name,customer.Last_Name,table_video.Title,rental.Check_out_date,rental.Is_it_returned,rental.Returned_date,rental.rental_charges,rental.due_date From rental Inner join customer On customer.customer_id = rental.customer_id Inner Join table_video On table_video.Video_id = rental.video_id  where rental.customer_id = customer.customer_id And rental.video_id = table_video.Video_id And rental.customer_id ='".$customer_id."' Order By rental.Check_out_date Desc";
	
   if ($result=mysqli_query($con, $q)) {
       
} else {
    echo "Error: " . $q . "<br>" . mysqli_error($con);}
	
   while($row = mysqli_fetch_array($result))
   {
        if($overdue == true)
		{		       
           echo "\n".$row[0]."\t".$row[1]."\t".$row[2]."\t".$row[3]."\t".$row[4]."\t".$row[5]."\t$".$row[6]."\t".$row[7]."\tOverdue Charges\n";
		}
		else
		{
		    echo "\n".$row[0]."\t".$row[1]."\t".$row[2]."\t".$row[3]."\t".$row[4]."\t".$row[5]."\t$".$row[6]."\t".$row[7]."\n";
		}
   }
   
 }
 else//rent
 {
   $first_name = $_REQUEST['first_name'];  
   $last_name = $_REQUEST['last_name']; 
   $video_name = $_REQUEST['video_name'];
   $check_date = $_REQUEST['date'];
   $due_date = date('Y-m-d', strtotime($check_date. ' + 3 days'));
   $q = "Select customer_id from customer where First_Name = '$first_name ' AND Last_Name ='$last_name'";
  if ($result=mysqli_query($con, $q)) {
   
} else {
    echo "Error: " . $q . "<br>" . mysqli_error($con);}
   if($row = mysqli_fetch_array($result))
   {
          $customer_id = $row['customer_id'];
            
          	  
   }
   else
   {
      echo " Customer not found";
      exit;		
   }
   $q = "Select Video_id from table_video where Title = '$video_name'";
  if ($result=mysqli_query($con, $q)) {
    
} else {
    echo "Error: " . $q . "<br>" . mysqli_error($con);}
   if($row = mysqli_fetch_array($result))
   {
       
       $video_id = $row['Video_id'];         
   }
   else
   {
       echo "video not found";
          exit;	
   }
   $q = "Select Is_it_returned from rental where video_id = '".$video_id."'Order By rental.Check_out_date Desc"; 
   if ($result = mysqli_query($con, $q)) {
       
      
} else {
    echo "Error: " . $q . "<br>" . mysqli_error($con);}
	if($row = mysqli_fetch_array($result))
	{
	 
	  if($row['Is_it_returned'] == 'N')
	  {
	     echo 'Sorry the video is not available';
		 exit;
	  }
	}
   $q = "Insert into rental Values('".$customer_id."','".$video_id."','$check_date','N',null,null,'$due_date')";
   if ($result=mysqli_query($con, $q)) {
    echo "New record created successfully\n";
} else {
    echo "Error: " . $q . "<br>" . mysqli_error($con);}
   
   if($result == 1)
   {
     
     $q = "Select customer.First_Name,customer.Last_Name,table_video.Title,rental.Check_out_date,rental.Is_it_returned,rental.due_date From rental Inner join customer On customer.customer_id = rental.customer_id Inner Join table_video On table_video.Video_id = rental.video_id  where rental.customer_id = customer.customer_id And rental.video_id = table_video.Video_id And rental.customer_id ='".$customer_id."' Order By rental.Check_out_date Desc";
	
	if ($result=mysqli_query($con, $q)) {
    
} else {
    echo "Error: " . $q . "<br>" . mysqli_error($con);}
   
      while($row = mysqli_fetch_array($result))
      {
	    if($row['Is_it_returned'] == 'Y')
		{
		    continue;
		}
		else
		{
           echo $row[0]."\t".$row[1]."\t".$row[2]."\t".$row[3]."\t".$row[4]."\t".$row[5]."\n";
		}
		
      }
   }
  }
   


?>