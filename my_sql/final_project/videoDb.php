<?php
/*
   name Thomas Zangari
*/
$con = mysqli_connect('localhost','root','thomas78','videostore');
if (!$con) {
    die('Could not connect: ' . mysqli_error($con));
}


 $check = $_REQUEST['check'];


if($check == 1)
{
   

   $video_name = $_REQUEST['video_name'];
  
      
   $q = "Select Video_id from table_video where Title = '$video_name'";
  if($result = mysqli_query($con,$q))
  {
       	    
  }
  else
  {
        echo "Video not found";
        exit;
  
  }
  
   while ($row = mysqli_fetch_array($result))
   {
      
      $video_id = $row['Video_id'];
	  $q = "Select customer.First_Name,customer.Last_Name,table_video.Title,rental.Check_out_date,rental.Is_it_returned,rental.Returned_date,rental.rental_charges,rental.due_date From rental Inner join customer On customer.customer_id = rental.customer_id Inner Join table_video On table_video.Video_id = rental.video_id  where rental.customer_id = customer.customer_id And rental.video_id = '".$video_id."' Order By rental.Check_out_date Desc";
	
	
   if ($result=mysqli_query($con, $q)) {
    
   } else {
    echo "Error: " . $q . "<br>" . mysqli_error($con);}
   
  
   $i=0;
   while ($row = mysqli_fetch_array($result))
   {
        if($row['Returned_date'] == null)
		{
      
            echo $row[0]."\t".$row[1]."\t".$row[2]."\t".$row[3]."\t".$row[4]."\t".$row[5]."\t".$row[7]."\n";
	    }
		else
		{
		  echo "\n".$row[0]."\t".$row[1]."\t".$row[2]."\t".$row[3]."\t".$row[4]."\t".$row[5]."\t$".$row[6]."\t".$row[7]."\n";
		}
	  
   }
  }
     
 }
 else
 {
   $q = "SELECT * FROM table_video";
 
 $result = mysqli_query($con,$q);
 while($row = mysqli_fetch_array($result))
 {
     if($row == null)
	 {
	   echo "Not present";
	 }
	 else
	 {
       print "\nVideo\n";
       echo  "id\t".$row[0]."\nTitle\t".$row[1]."\nCategory\t".$row[2]."\nMinutes\t".$row[3]."\nActors\t".$row[4]."\nDirector\t".$row[5];
	 }
  }
}

?>