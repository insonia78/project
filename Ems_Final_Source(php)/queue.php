
<?php
error_reporting(0);
session_start();
include ('config.php');
if($_SESSION['login_details']['user_id']==""){
     header("Location:index.php");
       exit;
}
//$query = "select shootdate,Name,AssignID,therapeuticArea,practicecity,physname,repname,AssignStatus from assignments LEFT JOIN videographers ON assignments.shootername=videographers.vID where AssignStatus IN ('postponed','cancelled') ORDER BY AssignStatus DESC";
$query = "select shootdate,shootername,AssignID,therapeuticArea,practicestate,physname,repname,AssignStatus from assignments where ppedited != ''";

$result = mysql_query($query);

?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Axon-Enrollment</title>
<link rel="stylesheet" type="text/css" href="css/style.css" />
<link rel="stylesheet" type="text/css" href="css/jquery-ui.css" />
<script src="js/jquery.js" type="text/javascript"></script>
<script src="js/jquery.dataTables.min.js" type="text/javascript"></script>
<script src="js/jquery.dataTables.bootstrap.js" type="text/javascript"></script>
<script src="js/custom.js" type="text/javascript"></script>
<script src="js/jquery-ui.js"></script>
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
</head>

<body>
<div id="main_wrapper">
	<div class="main_content">
        <div class="header">
            <h1><?php if($_SESSION['login_details']['user_dept']==1){?>Client Services Queue<?php }else{?>Field Operations Queue<?php }?> </h1>
            <img src="images/logo_small.png" />
        </div><!--header-->
        <div class="enroll_content">
        	<a href="#" style="float: right; margin-right: 168px; margin-top: -30px;">Export Queue</a> <a href="expt.php" style="float: right; margin-right: 82px; margin-top: -30px;">Export All </a>        	<a href="logout.php" style="float: right; margin-top: -30px;">+Logout</a>
        	<div class="tab_conatiner">
                <a href="upcomming.php"><div class="tab_tit " id="tab1">Pending</div></a>
                <a href="postponed.php"><div class="tab_tit" id="tab2">Postponed</div></a>
                <a href="cancelled.php"><div class="tab_tit " id="tab2">Canceled</div></a>
                <a href="filmed.php"><div class="tab_tit" id="tab3">Filmed</div></a>
                <a href="queue.php"><div class="tab_tit active_state">Queue</div></a>
                <a href="reorder.php"><div class="tab_tit">Reorders</div></a>
                <?php if($_SESSION['login_details']['user_dept']==2){?>
               <a href="videographer.php"> <div class="tab_tit" id="tab4">Videographers</div></a>
               <?php }?> 
            </div><!--tab container-->
            <div class="search_container">
            	  <div class="search_icon"><img src="images/search_icon.png" /></div>
            </div><!--search container-->
            <div class="enroll_text">
             <div class='listmsg'>
             <?php if($_SESSION['success']!=''){?> <p class="success autohide"><?php echo $_SESSION['success']; ?></p><?php }?>
               <?php if($_SESSION['error']!=''){?> <p class="error autohide"><?php echo $_SESSION['error']; ?></p><?php }?>
               	</div>
            <div class="dummy">
                <table width="100%" cellpadding="0" cellspacing="0" class="video dataTable">
                  <thead style="padding-left:50px;">
                  <tr class="title">
                      <th class="active_title" align="center" style="">Shoot Date<img src="images/arrow.png" />       </th>
                    <th align="center" style=""> Job No.<img src="images/arrow.png" />  </th>
                    <th align="center" style="">Brand<img src="images/arrow.png" /> </th>
                    <th align="center" style="">Videographer<img src="images/arrow.png" /> </th>
                    <th align="center" style="">Location <img src="images/arrow.png" /> </th>
                    <th align="center" style="">HCP<img src="images/arrow.png" /></th>
                    <th align="center" style="">Rep<img src="images/arrow.png" /> </th>                  
                    <th align="center" style="">&nbsp;  </th>
                     <th align="center" >&nbsp; </th>
					   <th style=" display: none;"></th>
                  </tr>
                  </thead>
                 <tbody>
                <?php while ($row = mysql_fetch_assoc($result)) {?>
                         
                    
                  <tr class="bor">
                      <td style=" display: none;"><?php if($row['AssignStatus']=='postponed'){?>1<?php }else{ ?>2<?php }?></td>
                      <td ><?php echo $row['shootdate'];?></td>
                    <td><?php echo $row['AssignID'];?> </td>
                    <td><?php echo $row['therapeuticArea'];?></td>
                    <td <?php if(strlen($row['shootername'])>25){?> title="<?php echo $row['shootername'];?>" <?php }?>><?php if(strlen($row['shootername'])>25){ echo substr($row['shootername'],0,15).'...';}else{ echo $row['shootername']; }?></td>
                    <td <?php if(strlen($row['practicestate'])>20){?> title="<?php echo $row['practicestate'];?>" <?php }?>><?php if(strlen($row['practicestate'])>20){ echo substr($row['practicestate'],0,15).'...';}else{ echo $row['practicestate']; }?></td>
                    <td <?php if(strlen($row['physname'])>20){?> title="<?php echo $row['physname'];?>" <?php }?>><?php if(strlen($row['physname'])>20){ echo substr($row['physname'],0,15).'...';}else{ echo $row['physname']; }?></td>
                    <td <?php if(strlen($row['repname'])>20){?> title="<?php echo $row['repname'];?>" <?php }?>><?php if(strlen($row['repname'])>20){ echo substr($row['repname'],0,15).'...';}else{ echo $row['repname']; }?></td>
                                                     
                     <td width="5" style="background-color:#fff; border:none;"></td>
                    <td class="detail_in" colspan="2"><span class="tleft"><a href="enrolldetails.php?edit_id=<?php echo $row['AssignID'];?>">Details</a></span><span class="tright"><a href="#">Update</a></span></td>
                  </tr> 
                <?php  }?> 
                  </tbody>
			</table>
            	</div><!--dummy-->
  </div><!--enroll text-->
        </div><!--enroll content-->
        <p class="copy">&#169; 2015 Axon communications, Inc.</p>
    </div><!--main_content-->

</div><!--main wrapper-->
 <?php unset($_SESSION['error']);unset($_SESSION['success']);?>
</body>
</html>

