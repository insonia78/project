<?php
/*
   name : Thomas Zangari  
*/
$con = mysqli_connect('localhost','root','thomas78','videostore');
if (!$con) {
    die('Could not connect: ' . mysqli_error($con));
}


 $check = $_REQUEST['check'];


if($check == 1)
{
   

   $first_name = $_REQUEST['first_name'];
  
   $last_name = $_REQUEST['last_name'];   
   $q = "Select customer_id from customer where First_Name = '$first_name ' AND Last_Name ='$last_name'";
  if( !($result = mysqli_query($con,$q)))
  {
        echo "Customer not found1";
        exit;		  
  
  }
   if($row = mysqli_fetch_array($result))
   {
         $customer_id = $row['customer_id'];	  
   }
  
  $q = "Select video_id from rental where rental.customer_id ='".$customer_id."'";
     if ($result=mysqli_query($con, $q)) {
    
   } else {
       echo "Error: " . $q . "<br>" . mysqli_error($con);}
   
  
     
   while ($row = mysqli_fetch_array($result))
   {
      
      $video_id = $row['video_id'];
	  $q = "Select customer.First_Name,customer.Last_Name,table_video.Title,rental.Check_out_date,rental.Is_it_returned,rental.Returned_date,rental.rental_charges,rental.due_date From rental Inner join customer On customer.customer_id = rental.customer_id Inner Join table_video On table_video.Video_id = rental.video_id  where rental.customer_id = customer.customer_id And rental.video_id = '".$video_id."' And rental.customer_id ='".$customer_id."' Order By rental.Check_out_date Desc";
	
	
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
   $q = "SELECT * FROM customer";
 
 $result = mysqli_query($con,$q);
 while($row = mysqli_fetch_array($result))
 {
     if($row == null)
	 {
	   echo "Not present";
	 }
	 else
	 {
       echo "\nid\tname\t\taddress\n";
       echo  $row[0]."\t".$row[1]."\t".$row[2]."\t".$row[3];
	 }
  }
}

?>