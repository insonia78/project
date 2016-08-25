<!--


ems final version 

This is the entry point to the application it differs consistently from the previous version 
if starts with the focus on the pending tab 
- it fetches the data from the assignments table to populate the fields it the lower part of the page





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
                    <th class="active_title" style="" align="center">Shoot Date<img src="../images/arrow.png" /> </th>
                    <th align="center" style=" "> Job No.<img src="../images/arrow.png" />  </th>
                    <th align="center" style="">Brand<img src="../images/arrow.png" /> </th>
                    <th align="center" style="">Videographer<img src="../images/arrow.png" /> </th>
                    <th align="center" style="">Location <img src="../images/arrow.png" /> </th>
                    <th align="center" style="">HCP<img src="../images/arrow.png" /></th>
                    <th align="center" style="">Rep<img src="../images/arrow.png" /> </th>  
                    <th align="center" style=" ">Shoot Reminder 1 day<img src="../images/arrow.png" /> </th>
                    <th align="center" style=" ">Shoot Reminder 4 day<img src="../images/arrow.png" /> </th>
                    <th align="center" style="" >&nbsp;  </th>
                     <th align="center">&nbsp;</th>
                  </tr>
                  </thead>
                 <tbody>
                     
                     
        <!--   
       
        The application populates this part by fetching the data from the assignments table 
        
        
        
                     
                     
                     
            -->         
                <?php  while ($row = mysql_fetch_assoc($result)) {
                 $fieldopt = mysql_query("select * from fieldops where assignID = '".$row['AssignID']."'");
                 
                 $countfiled = mysql_num_rows($fieldopt); 
    
                    ?>
                         
                    
                  <tr class="bor">
                      <td><?php echo date("m-d-Y", strtotime($row['shootdate']));?></td>
                    <td><?php echo $row['AssignID'];?> </td>
                    <td><?php echo $row['therapeuticArea'];?></td>
                    <td <?php if(strlen($row['shootername'])>20){?> title="<?php echo $row['shootername'];?>" <?php }?>><?php if(strlen($row['shootername'])>20){ echo substr($row['shootername'],0,15).'...';}else{ echo $row['shootername']; }?></td>
                    <td <?php if(strlen($row['practicestate'])>15){?> title="<?php echo $row['practicestate'];?>" <?php }?>><?php if(strlen($row['practicestate'])>15){ echo substr($row['practicestate'],0,10).'...';}else{ echo $row['practicestate']; }?></td>
                    <td <?php if(strlen($row['physname'])>15){?> title="<?php echo $row['physname'];?>" <?php }?>><?php if(strlen($row['physname'])>15){ echo substr($row['physname'],0,10).'...';}else{ echo $row['physname']; }?></td>
                    <td <?php if(strlen($row['repname'])>15){?> title="<?php echo $row['repname'];?>" <?php }?>><?php if(strlen($row['repname'])>15){ echo substr($row['repname'],0,10).'...';}else{ echo $row['repname']; }?></td>
                    <td><?php if($countfiled==1){ $fetch_filed = mysql_fetch_assoc($fieldopt);?>  
                        
                        <select name="onedayreminder" id="<?php echo $row['AssignID'];?>" class="onedayreminder">
                            <option value="">Select</option>
                            <option value="Phone" <?php if($fetch_filed['onedayreminder']=="Phone"){?>selected="selected" <?php }?> >Phone</option>
                            <option value="LM" <?php if($fetch_filed['onedayreminder']=="LM"){?>selected="selected" <?php }?> >LM</option>
                            <option value="Email" <?php if($fetch_filed['onedayreminder']=="Email"){?>selected="selected" <?php }?> >Email</option>
                    </select><?php }else{echo 'select';}?></td>  
                    <td><?php if($countfiled==1){ ?>
                        <select name="fourdayreminder" id="<?php echo $row['AssignID'];?>" class="fourdayreminder">
                            <option value="">Select</option>
                             <option value="Phone" <?php if($fetch_filed['fourdayreminder']=="Phone"){?>selected="selected" <?php }?> >Phone</option>
                            <option value="LM" <?php if($fetch_filed['fourdayreminder']=="LM"){?>selected="selected" <?php }?> >LM</option>
                            <option value="Email" <?php if($fetch_filed['fourdayreminder']=="Email"){?>selected="selected" <?php }?> >Email</option>
                        </select><?php }else{echo 'select';}?></td>                                     
                    <td width="5" style="background-color:#fff;border:none;"></td>
                    
                    <!--
                    
                    Is sending the data to the enrolldetails.php for updating the assignment table 
                    
                    -->
                    
                    <td class="detail_in" colspan="2"><span class="tleft"><a href="../enrolldetails.php?edit_id=<?php echo $row['AssignID'];?>">Details</a></span><span class="tright"><a href="<?php if($_SESSION['login_details']['user_dept']==1){?>../internal_update<?php }else{?>../controller/main<?php }?>.php?status=field_update&edit_id=<?php echo $row['AssignID'];?>">Update</a></span></td>
                  </tr> 
                <?php  }?> 
                  </tbody>
			</table>
            	</div><!--dummy-->
  

<script type="text/javascript">
    $(document).ready(function(){
       
    $(".onedayreminder").change(function(){
       var onedayreminder = $(this).val();
      var jobno = $(this).attr('id');
      $.ajax
                        ({
                            type: "POST",
                            url: "videographer_list.php",
                            data: {onedayreminder: onedayreminder, jobno: jobno},
                            success: function(sivaraj)
                            {
                            //alert(sivaraj);
                            }
                        });
    });
     $(".fourdayreminder").change(function(){
       var fourdayreminder = $(this).val();
      var jobno = $(this).attr('id');
     
      $.ajax
                        ({
                            type: "POST",
                            url: "videographer_list.php",
                            data: {fourdayreminder: fourdayreminder, jobno: jobno},
                            success: function(sivaraj)
                            {
                            //alert(sivaraj);
                            }
                        });
    });
});
</script>
<?php

include_once 'footer.php';

?>

