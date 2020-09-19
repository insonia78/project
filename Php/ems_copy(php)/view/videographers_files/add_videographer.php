<!--

add videographer.php
version:final 

the page Innerjoin on videographers on assignments




-->



<?php
require '../view/header.php';
global $fetch;
?>


               
               <h3 style="padding: 20px 0;text-align: center;"><?php if($fetch['vID']==""){?> Register <?php }else{?> Update <?php } ?> Videographer Information</h3>
                <div class="screen_details" style="margin: 0px; float: left;">
               <form name="videographer" action="../controller/main.php?status=videographer" method="post" id="myForm">
                   
            	<div class="screen_detail_top">
                    <div class="screen_top_left">
                <ul class="enter_details">
                 <li>
                    <div class="tlcon">Videographer name</div>
                    <div class="rlcon"> <input type="text" name="Name" value="<?php echo $fetch['Name'];?>" required /></div>
                    </li>
                    <li>
                    <div class="tlcon">Company name</div>
                    <div class="rlcon"> <input type="text" name="CompanyName" value="<?php echo $fetch['CompanyName'];?>" required/></div>
                    </li>
                    <li>
                    <div class="tlcon">Videographer phone</div>
                    <div class="rlcon"> <input type="text" name="PrimPhone" onpaste="return false" value="<?php echo $fetch['PrimPhone'];?>"  onkeypress="return isNumberKey(event)" required /></div>
                    </li>
                    <li>
                    <div class="tlcon">Videographer cell</div>
                    <div class="rlcon"> <input type="text" name="SecPhone" onpaste="return false"  value="<?php echo $fetch['SecPhone'];?>"  onkeypress="return isNumberKey(event)" required/></div>
                    </li>
                    <li>
                    <div class="tlcon">Videographer alternate</div>
                    <div class="rlcon"> <input type="text" name="videographer_alter" value="<?php echo $fetch['videographer_alter'];?>"/></div>
                    </li>
                    <li>
                    <div class="tlcon">videographer email</div>
                    <div class="rlcon"> <input type="email" name="Email" value="<?php echo $fetch['Email'];?>" required/></div>
                    </li>
                    <li>
                    <div class="tlcon">Street</div>
                    <div class="rlcon"> <input type="text" name="Street" value="<?php echo $fetch['Street'];?>" /></div>
                    </li>
                    <li>
                    <div class="tlcon">City</div>
                    <div class="rlcon"> <input type="text" name="City" value="<?php echo $fetch['City'];?>" /></div>
                    </li>
                    <li>
                    <div class="tlcon">State</div>
                    <div class="rlcon"> <input type="text" name="State" value="<?php echo $fetch['State'];?>" /></div>
                    </li>
                    <li>
                    <div class="tlcon">Zip</div>
                    <div class="rlcon"> <input type="text" name="Zip" onpaste="return false" value="<?php echo $fetch['Zip'];?>" onkeypress="return isNumberKey(event)" /></div>
                    </li>
                </ul>
                    </div>
                    <div class="screen_top_left">
                  <ul class="enter_details">
                 
                    <li>
                    <div class="tlcon">Camera</div>
                    <div class="rlcon"> <input type="text" name="Camera" value="<?php echo $fetch['Camera'];?>" /></div>
                    </li>
                    <li>
                    <div class="tlcon">Ring Size</div>
                    <div class="rlcon"> <input type="text" name="RingSize" value="<?php echo $fetch['RingSize'];?>" /></div>
                    </li>
                    <li>
                    <div class="tlcon">Rate</div>
                    <div class="rlcon"> <input type="text" name="Rate" value="<?php echo $fetch['Rate'];?>" /></div>
                    </li>
                    <li>
                    <div class="tlcon">Transfer</div>
                    <div class="rlcon"> <input type="text" name="Transfer" value="<?php echo $fetch['Transfer'];?>" /></div>
                    </li>
                    <li>
                    <div class="tlcon">Teleprompter no.</div>
                    <div class="rlcon"> <input type="text" name="teleprompt" value="<?php echo $fetch['teleprompt'];?>" /></div>
                    </li>
                    <li>
                    <div class="tlcon">Lighting</div>
                    <div class="rlcon"> <input type="text" name="Lighting" value="<?php echo $fetch['Lighting'];?>" /></div>
                    </li>
                       <li>
                    <div class="tlcon">Audio</div>
                    <div class="rlcon"> <input type="text" name="Audio" value="<?php echo $fetch['Audio'];?>" /></div>
                    </li> 
                      <li>
                    <div class="tlcon">Monitor</div>
                    <div class="rlcon"> <input type="text" name="Monitor" value="<?php echo $fetch['Monitor'];?>" /></div>
                    </li> 
                      <li>
                    <div class="tlcon">Additional Gear</div>
                    <div class="rlcon"> <input type="text" name="AdditionalGear" value="<?php echo $fetch['AdditionalGear'];?>" /></div>
                    </li>
                      <li>
                    <div class="tlcon">Notes</div>
                    <div class="rlcon"> <textarea  name="Notes"><?php echo $fetch['Notes'];?></textarea></div>
                    </li>
                </ul>
                      </div>  
                  </div>  
                <div class="actions_list">
                <ul class="action_video">
                    <input type="hidden" name="edit_id" value="<?php echo $fetch['vID'];?>"/>
                    <li onclick="window.history.back()"><img src="../images/back.png"  onmouseover="this.src='../images/back_hover.png';" onmouseout="this.src='../images/back.png';"  /></li>
                    <li onclick="document.getElementById('myForm').reset();"><img src="../images/cancel.png"  onmouseover="this.src='../images/cancel_hover.png';" onmouseout="this.src='../images/cancel.png';" /></li>
                    <li><input type="image" src="../images/submit_hover.png"  onmouseover="this.src='../images/submit.png';" onmouseout="this.src='../images/submit_hover.png';" /></li>
                </ul><!--action video-->
                </div>
                
                </form></div>
               <div class="jobhistoryfull">
                   <h5 style="text-align: center; padding: 12px;">Job history listing</h5>
                   <div class="jobhistory">
               <table>
                    <?php while ($row = mysql_fetch_assoc($result)) {?>
                   <tr>
                       <td><?php echo $row['shootdate'];?></td><td><a href="enrolldetails.php?edit_id=<?php echo $row['AssignID'];?>">Job No. <?php echo $row['AssignID'];?></a></td><td><?php echo $row['shootername'];?></td>
                       
                   </tr> 
                   <?php  }?> 
               </table>
                </div></div>
  		</div><!--enroll text-->
        </div><!--enroll content-->
      <p class="copy">&#169; 2015 Axon communications, Inc.</p>
    </div><!--main_content-->

</div><!--main wrapper-->
<script type="text/javascript">
function isNumberKey(evt)
 
          {
             var charCode = (evt.which) ? evt.which : event.keyCode
             if (charCode > 31 && (charCode < 44 || charCode > 57))
                return false;
 
             return true;
          }
</script>
 <?php unset($_SESSION['error']);unset($_SESSION['success']);?>
</body>
</html>
