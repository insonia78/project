<!DOCTYPE html>
<!--
To change this license header, choose License Headers in Project Properties.
To change this template file, choose Tools | Templates
and open the template in the editor.
-->

<?php
global $result;
global $status;
include_once '../view/header.php';



?>
<text>Welcome</text>
<div class="dummy">
                <table width="100%" cellpadding="0" cellspacing="0" class="video dataTable">
                  <thead style="padding-left:50px;">
                  <tr class="title">
                     <th style="display:none;" align="center">Id <img src="../images/arrow.png" /> </th>
                     <th style=" " class="active_title" align="center">Name<img src="../images/arrow.png" />       </th>
                    <th style=" " align="center">Phone (office)<img src="../images/arrow.png" />  </th>
                    <th style=" " align="center">Phone (Cell)<img src="../images/arrow.png" /> </th>
                    <th style="" align="center">Email<img src="../images/arrow.png" /> </th>
                    <th style=" " align="center">Camera <img src="../images/arrow.png" /> </th>
                    <th style=" " align="center">Transfer<img src="../images/arrow.png" /></th>
                    <th style=" " align="center">Teleprompter<img src="../images/arrow.png" /> </th>
                    <th style=" " align="center">Rate<img src="../images/arrow.png" /></th>
                    <th align="center">&nbsp;  </th>
                    <th align="center">&nbsp;  </th>
                    <th align="center"><?php if($_SESSION['login_details']['user_dept']==2){?><a href="../add_videographer.php"><img src="../images/add.png" /></a> <?php }?> </th>
                  </tr>
                  </thead>
                 <tbody>
                <?php while ($row = mysql_fetch_assoc($result)) {?>
                 <?php $lname = explode(" ",$row['Name']);if(count($lname)>1){ $lastname = $lname[1]; } else {$lastname = $lname[0]; }
	          ?>
                  <tr class="bor">
                    <td style="display:none;"><?php echo $lastname;?></td>
                    <td <?php if(strlen($row['Name'])>27){?> title="<?php echo $row['Name'];?>" <?php }?>><?php if(strlen($row['Name'])>27){ echo substr($row['Name'],0,20).'...';}else{ echo $row['Name']; }?></td>
                    <td><?php echo $row['PrimPhone'];?></td>
                    <td><?php echo $row['SecPhone'];?></td>
                    <td ><a href="mailto:<?php echo $row['Email']; ?>" style="text-decoration: underline; color: #0000EE;" <?php if(strlen($row['Email'])>15){?> title="<?php echo $row['Email'];?>" <?php }?>><?php if(strlen($row['Email'])>15){ echo substr($row['Email'],0,10).'...';}else{ echo $row['Email']; }?></a></td>
                    <td <?php if(strlen($row['Camera'])>15){?> title="<?php echo $row['Camera'];?>" <?php }?>><?php if(strlen($row['Camera'])>15){ echo substr($row['Camera'],0,10).'...';}else{ echo $row['Camera']; }?></td>
                    <td <?php if(strlen($row['Transfer'])>15){?> title="<?php echo $row['Transfer'];?>" <?php }?>><?php if(strlen($row['Transfer'])>15){ echo substr($row['Transfer'],0,10).'...';}else{ echo $row['Transfer']; }?></td>
                    <td <?php if(strlen($row['teleprompt'])>15){?> title="<?php echo $row['teleprompt'];?>" <?php }?>><?php if(strlen($row['teleprompt'])>15){ echo substr($row['teleprompt'],0,10).'...';}else{ echo $row['teleprompt']; }?></td>
                    <td><?php echo $row['Rate'];?></td>                    
                    <td width="5" bgcolor="#fff" style="background-color:#fff;border:none;"></td>
                    <td style="background-color:#fff;border:none;"></td>
                    <td class="detail_in" colspan="3" style=" width: 180px;">
                        <span class="tleft" style=" width: 32%;"><a href="../controller/main.php?status=view_videographers&edit_id=<?php echo $row['vID']; ?>">Details</a></span>
                        <span class="tleft" style=" width: 33%;"><a href="<?php if($_SESSION['login_details']['user_dept']==2){?>../controller/main.php?status=add_videographer&edit_id=<?php echo $row['vID']; ?><?php }else{?>#<?php }?>">Update</a></span>
                        <span class="tright" style=" width: 32%;"><a href="<?php if($_SESSION['login_details']['user_dept']==2){?>../controller/main.php?status=videographer&delete_id=<?php echo $row['vID']; ?><?php }else{?>#<?php }?>">Delete</a></span>
                    </td>
                    
                  </tr>
                <?php  }?>   
                  </tbody>
			</table>
            	</div><!--dummy-->
                
                
<?php

include_once '../view/footer.php';


?>