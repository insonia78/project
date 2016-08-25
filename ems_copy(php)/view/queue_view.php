<!DOCTYPE html>
<!--
To change this license header, choose License Headers in Project Properties.
To change this template file, choose Tools | Templates
and open the template in the editor.
-->
<?php


global $status ;
global $result;
require '../view/header.php';


?>

<div class="dummy">
                <table width="100%" cellpadding="0" cellspacing="0" class="video dataTable">
                  <thead style="padding-left:50px;">
                  <tr class="title">
                      <th class="active_title" align="center" style="">Shoot Date<img src="../images/arrow.png" />       </th>
                    <th align="center" style=""> Job No.<img src="../images/arrow.png" />  </th>
                    <th align="center" style="">Brand<img src="../images/arrow.png" /> </th>
                    <th align="center" style="">Videographer<img src="../images/arrow.png" /> </th>
                    <th align="center" style="">Location <img src="../images/arrow.png" /> </th>
                    <th align="center" style="">HCP<img src="../images/arrow.png" /></th>
                    <th align="center" style="">Rep<img src="../images/arrow.png" /> </th>                  
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
                    <td class="detail_in" colspan="2"><span class="tleft"><a href="../enrolldetails.php?edit_id=<?php echo $row['AssignID'];?>">Details</a></span><span class="tright"><a href="#">Update</a></span></td>
                  </tr> 
                <?php  }?> 
                  </tbody>
			</table>
            	</div><!--dummy-->
<?php

include_once '../view/footer.php';

?>