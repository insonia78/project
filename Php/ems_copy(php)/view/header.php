<!DOCTYPE html>
<!--
To change this license header, choose License Headers in Project Properties.
To change this template file, choose Tools | Templates
and open the template in the editor.
-->
<?php

global $status;

?>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Axon-Enrollment</title>
<link rel="stylesheet" type="text/css" href="../css/style.css" />
<link rel="stylesheet" type="text/css" href="../css/jquery-ui.css" />
<script src="../js/jquery.js" type="text/javascript"></script>
<script src="../js/jquery.dataTables.min.js" type="text/javascript"></script>
<script src="../js/jquery.dataTables.bootstrap.js" type="text/javascript"></script>
<script src="../js/custom.js" type="text/javascript"></script>
<script src="../js/jquery-ui.js"></script>
<script>
$(function() {
$( document ).tooltip();
});
</script>
 <script type="text/javascript">
        $(document).ready(function(){
          
             setInterval(function(){ $('.autohide').hide(); }, 1500);
        });
       
    </script>
<style>
 .enroll_text .dummy table tr td:nth-child(9) {
    border: medium none !important;
 }
  <?php $example = '#main_wrapper .main_content .enroll_content .'. $status;
  
  
  echo $example;?>{
   background-color:white;
   color:#333;  
  
  }




</style>
</head>

<body>
<div id="main_wrapper">
	<div class="main_content">
        <div class="header">
            <h1><?php if($_SESSION['login_details']['user_dept']==1){?>Client Services Queue<?php }else{?>Field Operations Queue<?php }?> </h1>
            <img src="../images/logo_small.png" />
        </div><!--header-->
        <div class="enroll_content">
               
        	<a href="../export.php?status=<?php $status ?>" style="float: right; margin-right: 168px; margin-top: -30px;">Export Pending</a> <a href="../expt.php" style="float: right; margin-right: 82px; margin-top: -30px;">Export All </a>          	<a href="../logout.php" style="float: right; margin-top: -30px;">+Logout</a>
        	<div class="tab_conatiner">
                <a href="main.php"><div class="tab_tit pending" id="tab1">Pending</div></a>
                <a href="main.php?status=postponed"><div class="tab_tit postponed" id="tab2">Postponed</div></a>
                <a href="main.php?status=canceled"><div class="tab_tit canceled" id="tab2">Canceled</div></a>
                <a href="main.php?status=filmed"><div class="tab_tit filmed" id="tab3">Filmed</div></a>
                <a href="main.php?status=queue"><div class="tab_tit queue">Queue</div></a>
                <a href="main.php?status=reorders"><div class="tab_tit reorders">Reorders</div></a>
                <?php if($_SESSION['login_details']['user_dept']==2){?>
               <a href="main.php?status=videographer"> <div class="tab_tit videographer" id="tab4">Videographers</div></a>
               <?php }?> 
            </div><!--tab container-->
            <div class="search_container">
            	  <div class="search_icon"><img src="../images/search_icon.png" /></div>
            </div><!--search container-->
            <div class="enroll_text">
            <div class='listmsg'>
             <?php if($_SESSION['success']!=''){?> <p class="success"><?php echo $_SESSION['success']; ?></p><?php }?>
               <?php if($_SESSION['error']!=''){?> <p class="success"><?php echo $_SESSION['error']; ?></p><?php }?>
              </div>