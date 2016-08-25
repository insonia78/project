<!DOCTYPE html>
<!--
To change this license header, choose License Headers in Project Properties.
To change this template file, choose Tools | Templates
and open the template in the editor.
-->
<?php


global $status ;
global $result;
require 'header.php';


?>

<div class="dummy">
                <table width="100%" cellpadding="0" cellspacing="0" class="video dataTable">
                  <thead style="padding-left:50px;">
                  <tr class="title">
                  <!--  <th class="active_title" align="center" style=" width: 200px !important;">Date of Reorder<img src="images/arrow.png" />       </th>
                    <th align="center" style=" width: 100px !important;"> Job No.<img src="images/arrow.png" />  </th>
                    <th align="center" style=" width: 300px !important;">Location<img src="images/arrow.png" /> </th>
                    <th align="center" style=" width: 300px !important;">HCP<img src="images/arrow.png" /></th>
                    <th align="center" style=" width: 300px !important;">Rep<img src="images/arrow.png" /> </th> 
                    <th align="center" style=" width: 150px !important;">Shipped<img src="images/arrow.png" /> </th> 
                    <th align="center" style=" width: 10px !important;">&nbsp;  </th>
                    <th align="center" style=" width: 10px !important;">&nbsp;  </th>-->
	            <th class="active_title" align="center" style=" ">Date of Reorder<img src="../images/arrow.png" />       </th>
                    <th align="center" style=" "> Job No.<img src="../images/arrow.png" />  </th>
                    <th align="center" style="">Location<img src="../images/arrow.png" /> </th>
                    <th align="center" style="">HCP<img src="../images/arrow.png" /></th>
                    <th align="center" style=" ">Rep<img src="../images/arrow.png" /> </th> 
                    <th align="center" style=" ">Shipped<img src="../images/arrow.png" /> </th> 
                    <th align="center" style=" ">&nbsp;  </th>
                    <th align="center" style=" ">&nbsp;  </th>
                  </tr>
                  </thead>
                 <tbody>
                <?php while ($row = mysql_fetch_assoc($result)) {
                    $ass_id = $row['AssignID'];
                 $query = "select AssignID,therapeuticArea,practicestate,physname,repname,AssignStatus from assignments where AssignID =$ass_id";
                 $result = mysql_query($query);
                 if(mysql_num_rows($result)>0){
                     $reorder = mysql_fetch_assoc($result);
                 }else{
                     $reorder['AssignID'] = '';
                    $reorder['practicestate'] = '';
                     $reorder['physname'] = '';
                     $reorder['repname'] = '';
                 }
                    ?>
                  <tr class="bor">
                    <td ><?php echo date("m-d-Y", strtotime($row['thedate']));?></td>
                    <td><?php echo $reorder['AssignID'];?> </td>
                    <td><?php echo $reorder['practicestate'];?> </td>
                    <td><?php echo $reorder['physname'];?> </td>
                    <td><?php echo $reorder['repname'];?> </td>
                    <td><?php echo $row['shipped'];?></td>                                
                     <td width="5" style="background-color:#fff; border:none;"></td>
                     <td class="detail_in" colspan="2"><span class="tleft"><a href="../viewreorder.php?edit_id=<?php echo $row['reordernum'];?>">Details</a></span><span  style ="background-color:black;" class="tright"><div href="<?php if($_SESSION['login_details']['user_dept']==1){?>javascript:void(0)<?php }else{?>javascript:void(0)<?php }?>"></div></span></td>
                  </tr> 
                <?php  }?> 
                  </tbody>
			</table>
            	</div><!--dummy-->
<?php

include_once 'footer.php';

?>