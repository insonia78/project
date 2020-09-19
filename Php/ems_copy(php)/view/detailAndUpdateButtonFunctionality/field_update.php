<?php



include '../view/header.php';
global $performQueryToDataBase; 

global $fetch ;
global $fetch_filed;
global $video_result;

?>




<script type="text/javascript">
    $(document).ready(function(){
   
    $("#videographer_details").blur(function(){
       var vID = $(this).val();
      
       var request = $.ajax
                        ({
                            type: "POST",
                            url: "../controller/main.php",
                            data: {vID :vID, status: 'field_update', ajax: 'true'},
                            dataType:'html'
                        });
                        
           request.done(function(msg){
               var result=msg.split(',');
                              
                              $('#videographer_details').val(result[0]);
                              $('#companyname').val(result[1]);
                              $('#shooterphone').val(result[2]);
                              $('#shootercell').val(result[3]);
                              $('#shooteralt').val(result[4]);
                              $('#shooteremail').val(result[5]);
                              $('#teleprompt').val(result[6]);
                             $('#Lighting').val(result[6]);
                             $('#Audio').val(result[6]);
                             $('#Monitor').val(result[6]);
                             $('#AdditionalGear').val(result[6]);
                             $('#Notes').val(result[6]);               
             
           });
           
           request.fail(function (jqXHR, textStatus) {
            alert("Request failed: " + textStatus);
        });
        
                        
    });   
});
</script>
 


               <form name="enrollment" action="../controller/main.php?status=field_update" method="post" id="myForm">
            	<div class="screen_details">
            	
                  <div class="screen_detail_top">
                    <div class="screen_top" style="width: 100%; text-align: center;">
                             
                        <h3 style="float: left;line-height: 16px;text-align: end;width: 39%;">Job No.</h3>
                        <div class="rlcon" style="float: left;width: 20%;"><?php echo $fetch['AssignID'];?></div><!--rlcon-->
                              
                            </div><!--screen top-->
               			 <div class="screen_top">
                           <div class="tlcon"><h3>Status</h3> </div>
                                <div class="rlcon" style="text-transform: capitalize;"><?php if($fetch['AssignStatus']=='pending'){echo 'Pending';}else{ echo $fetch['AssignStatus'];} ?> </div><!--rlcon-->
                           </div><!--screen top-->
                          
                	<div class="screen_top_left">
                    	   <ul>
                            <li>
                                <div class="tlcon">&nbsp;</div>
                                <div class="rlcon"><h3>Representative Information</h3></div><!--rlcon-->                             
                           </li>
                           <li>
                                <div class="tlcon">name</div>
                                <div class="rlcon"><?php echo $fetch['repname']; ?></div><!--rlcon-->                             
                           </li>
                           <li>
                                <div class="tlcon">territory</div>
                                <div class="rlcon"><?php echo $fetch['repterritory']; ?></div><!--rlcon-->                             
                           </li>
                           <li>
                                <div class="tlcon">cell</div>
                                <div class="rlcon"><?php echo $fetch['repcell']; ?></div><!--rlcon-->                             
                           </li>
                           <li>
                                <div class="tlcon">Email</div>
                                <div class="rlcon"><?php echo $fetch['repemail']; ?></div><!--rlcon-->                             
                           </li>
                          
                        </ul>
                        
                        <ul>
                            
                            <li>
                                <div class="tlcon">&nbsp;</div>
                                <div class="rlcon"><h3>Practice Information</h3></div><!--rlcon-->                             
                           </li>
                           <li>
                                <div class="tlcon">Practice name</div>
                                <div class="rlcon"><?php echo $fetch['practicename']; ?></div><!--rlcon-->                             
                           </li>
                           <li>
                                <div class="tlcon">Physician name</div>
                                <div class="rlcon"><?php echo $fetch['physname']; ?></div><!--rlcon-->                             
                           </li>
                           <li>
                                <div class="tlcon">Street</div>
                                <div class="rlcon"><?php echo $fetch['practicestreet'].', '.$fetch['practicestreet2']; ?></div><!--rlcon-->                             
                           </li>
                           <li>
                                <div class="tlcon">City</div>
                                <div class="rlcon"><?php echo $fetch['practicecity']; ?></div><!--rlcon-->                             
                           </li>
                           <li>
                                <div class="tlcon">State</div>
                                <div class="rlcon"><?php echo $fetch['practicestate']; ?></div><!--rlcon-->                             
                           </li>
                           <li>
                                <div class="tlcon">Zipcode</div>
                                <div class="rlcon"><?php echo $fetch['practicezip']; ?></div><!--rlcon-->                             
                           </li>
                           <li>
                                <div class="tlcon">Practice phone</div>
                                <div class="rlcon"><?php echo $fetch['practicephone']; ?></div><!--rlcon-->                             
                           </li>
                        </ul>
                        
                        <ul>
                            
                            <li>
                                <div class="tlcon">&nbsp;</div>
                                <div class="rlcon"><h3>Key Contact person</h3></div><!--rlcon-->                             
                           </li>
                           <li>
                                <div class="tlcon">Name</div>
                                <div class="rlcon"><?php echo $fetch['contactname']; ?></div><!--rlcon-->                             
                           </li>
                             <li>
                                <div class="tlcon">Email</div>
                                <div class="rlcon"><?php echo $fetch['contactemail']; ?></div><!--rlcon-->                             
                           </li>
                           <li>
                                <div class="tlcon">Phone</div>
                                <div class="rlcon"><?php echo $fetch['contactphone']; ?></div><!--rlcon-->                             
                           </li>
                             <li>
                                <div class="tlcon">Notes</div>
                                <div class="rlcon"><?php echo $fetch['enrollnotes']; ?></div><!--rlcon-->                             
                           </li>
                        </ul>
                          <ul>
                            
                            <li>
                                <div class="tlcon">&nbsp;</div>
                                <div class="rlcon"><h3>&nbsp;</h3></div><!--rlcon-->                             
                           </li>
                           <li>
                                <div class="tlcon">Consent received</div>
                                <div class="rlcon"><?php echo $fetch['consent_received']; ?></div><!--rlcon-->                             
                           </li>
                             <li>
                                <div class="tlcon">1 week email</div>
                                <div class="rlcon"><?php echo $fetch['one_week_email']; ?></div><!--rlcon-->                             
                           </li>
                           <li>
                                <div class="tlcon">1 day call</div>
                                <div class="rlcon"><?php echo $fetch['one_day_call']; ?></div><!--rlcon-->                             
                           </li>
                            <li>
                                <div class="tlcon">Label sent</div>
                                <div class="rlcon"><?php echo $fetch['label_sent']; ?></div><!--rlcon-->                             
                           </li> <li>
                                <div class="tlcon">Job signed into post</div>
                                <div class="rlcon"><?php echo $fetch['job_signed_into_post']; ?></div><!--rlcon-->                             
                           </li> <li>
                                <div class="tlcon">Collateral approved</div>
                                <div class="rlcon"><?php echo $fetch['collateral_approved']; ?></div><!--rlcon-->                             
                           </li>
                        </ul>    
                    </div><!--screen_top_left-->
                    <div class="screen_top_left">
                    <ul>
                           
                            <li>
                                <div class="tlcon">&nbsp;</div>
                                <div class="rlcon"><h3>Main Participant</h3></div><!--rlcon-->                             
                           </li>
                           <li>
                                <div class="tlcon">name</div>
                                <div class="rlcon"><?php echo $fetch['partname']; ?></div><!--rlcon-->                             
                           </li>
                           <li>
                                <div class="tlcon">Credentials</div>
                                <div class="rlcon"><?php echo $fetch['partcred']; ?></div><!--rlcon-->                             
                           </li>
                         
                        </ul>
                        
                        <ul>
                            
                            <li>
                                <div class="tlcon">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                <div class="rlcon"><h3>Additional Participants</h3></div><!--rlcon-->                             
                           </li>
                            <li>
                                <div class="tlcon">name</div>
                                <div class="rlcon"><?php echo $fetch['part2name']; ?></div><!--rlcon-->                             
                           </li>
                           <li>
                                <div class="tlcon">Credentials</div>
                                <div class="rlcon"><?php echo $fetch['part2cred']; ?></div><!--rlcon-->                             
                           </li>
                            <li>
                                <div class="tlcon">name</div>
                                <div class="rlcon"><?php echo $fetch['part3name']; ?></div><!--rlcon-->                             
                           </li>
                           <li>
                                <div class="tlcon">Credentials</div>
                                <div class="rlcon"><?php echo $fetch['part3cred']; ?></div><!--rlcon-->                             
                           </li>
                            <li>
                                <div class="tlcon">name</div>
                                <div class="rlcon"><?php echo $fetch['part4name']; ?></div><!--rlcon-->                             
                           </li>
                           <li>
                                <div class="tlcon">Credentials</div>
                                <div class="rlcon"><?php echo $fetch['part4cred']; ?></div><!--rlcon-->                             
                           </li>
                        </ul>
                        
                        <ul>
                            
                            <li>
                                <div class="tlcon">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                <div class="rlcon"><h3>shooting information</h3></div><!--rlcon-->                             
                           </li>
                           <li>
                                <div class="tlcon">Shoot Time</div>
                                <div class="rlcon"><?php echo $fetch['shoottimehrs'].':'.$fetch['shoottimemins'].' '.$fetch['ampm']; ?></div><!--rlcon-->                             
                           </li>
                           <li>
                                <div class="tlcon">Shoot Date</div>
                                <div class="rlcon"><?php echo date("m-d-Y", strtotime($fetch['shootdate'])); ?></div><!--rlcon-->                             
                           </li>
                           <li>
                                <div class="tlcon">Street</div>
                                <div class="rlcon"><?php echo $fetch['shootstreet'].', '.$fetch['shootstreet2']; ?></div><!--rlcon-->                             
                           </li>
                           <li>
                                <div class="tlcon">City</div>
                                <div class="rlcon"><?php echo $fetch['shootcity']; ?></div><!--rlcon-->                             
                           </li>
                           <li>
                                <div class="tlcon">State</div>
                                <div class="rlcon"><?php echo $fetch['shootstate']; ?></div><!--rlcon-->                             
                           </li>
                           <li>
                                <div class="tlcon">Zip code</div>
                                <div class="rlcon"><?php echo $fetch['shootzip']; ?></div><!--rlcon-->                             
                           </li>
                           <li>
                                <div class="tlcon">Shoot phone</div>
                                <div class="rlcon"><?php echo $fetch['shootphone']; ?></div><!--rlcon-->                             
                           </li>
                             <li>
                                <div class="tlcon">Web Code</div>
                                <div class="rlcon"><?php  echo $fetch['webcode']; ?></div><!--rlcon-->                             
                           </li>
                       </ul>
                        <a href="../../controller/main.php"></a>
                   </div><!--screen_top_left-->
                    
                </div><!--screen_detail_top-->
                </div><!--screen details-->
                <div class="screen_details videoscreen">
                <div class="screen_detail_btm">
                <div class="screen_btm_left">
                    
                    
                    	<ul>
                            <li>
                                <div class="btm_left">Videographer name</div>
                                <div class="btm_right"><input type="text" id="videographer_details" autocomplete="off" list="videographer" placeholder="Videographer name" value="<?php echo $fetch_filed['shootername']; ?>" name="shootername" required/>
                                <datalist id="videographer">
                                   
                                   
                                   <?php echo $video_result;  while($video_row = mysql_fetch_assoc($video_result,MYSQL_ASSOC)) 
                                     {?> 
                                       
                                    <option value ="<?=  $video_row['vID'] ?>"><?= $video_row['Name'] ?></option>
                                     <?php }?> 
                                   
                                </datalist>
                                </div>
                            </li>
                            <li>
                                <div class="btm_left">Company name</div>
                                <div class="btm_right"><input type="text" id="companyname" placeholder="Company name" name="companyname" value="<?php echo $fetch_filed['companyname']; ?>" required/></div>
                            </li>
                            <li>
                                <div class="btm_left">Videographer phone</div>
                                <div class="btm_right"><input type="text" id="shooterphone" placeholder="Videographer phone" name="shooterphone" value="<?php echo $fetch_filed['shooterphone']; ?>" required/></div>
                            </li>
                            <li>
                                <div class="btm_left">Videographer cell</div>
                                <div class="btm_right"><input type="text" id="shootercell" placeholder="Videographer cell" name="shootercell" value="<?php echo $fetch_filed['shootercell']; ?>" required/></div>
                            </li>
                            <li>
                                <div class="btm_left">Videographer alt</div>
                                <div class="btm_right"><input type="text" id="shooteralt" placeholder="Videographer alternate" name="shooteralt" value="<?php echo $fetch_filed['shooteralt']; ?>" /></div>
                            </li>
                            <li>
                                <div class="btm_left">Videographer email</div>
                                <div class="btm_right"><input type="text" id="shooteremail" placeholder="Videographer email" name="shooteremail" value="<?php echo $fetch_filed['shooteremail']; ?>" required/></div>
                            </li>
                            
                        </ul>
                    </div><!--screen_btm_left-->
                 <div class="screen_btm_left">
                    	<ul>
                            <li>
                                <div class="btm_left">Teleprompter no.</div>
                                <div class="btm_right"><input type="text" id="teleprompt" placeholder="Teleprompter no." name="teleprompt" value="<?php echo $fetch_filed['teleprompt']; ?>" /></div>
                            </li>
                            <li>
                                <div class="btm_left">Ship out</div>
                                <div class="btm_right"><input type="text" placeholder="Ship out" name="foshipout" value="<?php echo $fetch_filed['foshipout']; ?>" /></div>
                            </li>
                            <li>
                                <div class="btm_left">(Out track)</div>
                                <div class="btm_right"><input type="text" placeholder="(Out track)" name="foouttrack" value="<?php echo $fetch_filed['foouttrack']; ?>" /></div>
                            </li>
                            <li>
                                <div class="btm_left">Ship in</div>
                                <div class="btm_right"><input type="text" placeholder="Ship in" name="foshipin" value="<?php echo $fetch_filed['foshipin']; ?>" /></div>
                            </li>
                            <li>
                                <div class="btm_left">(In Track)</div>
                                <div class="btm_right"><input type="text" placeholder="Expected Footage In" name="fointrack" value="<?php echo $fetch_filed['fointrack']; ?>" /></div>
                            </li>
                            <li>
                                <div class="btm_left">Expected Footage In</div>
                                <div class="btm_right"><input type="text" placeholder="Expected Footage In" name="fotapeexpectin" value="<?php echo $fetch_filed['fotapeexpectin']; ?>" /></div>
                            </li>
                            <li>
                                <div class="btm_left">(Footage In)</div>
                                <div class="btm_right"><input type="text" placeholder="(Footage In)" name="fotapein" value="<?php echo $fetch_filed['fotapein']; ?>" /></div>
                            </li>
                            
                        </ul>
                    </div><!--screen_btm_left-->
                 <div class="screen_btm_left">
                    	<ul>
                             <li>
                    <div class="btm_left">Lighting</div>
                    <div class="btm_right"> <input type="text" name="Lighting" id="Lighting" value="<?php echo $fetch_filed['Lighting'];?>" /></div>
                    </li>
                       <li>
                    <div class="btm_left">Audio</div>
                    <div class="btm_right"> <input type="text" name="Audio" id="Audio" value="<?php echo $fetch_filed['Audio'];?>" /></div>
                    </li> 
                      <li>
                    <div class="btm_left">Monitor</div>
                    <div class="btm_right"> <input type="text" name="Monitor" id="Monitor" value="<?php echo $fetch_filed['Monitor'];?>" /></div>
                    </li> 
                      <li>
                    <div class="btm_left">Additional Gear</div>
                    <div class="btm_right"> <input type="text" name="AdditionalGear" id="AdditionalGear" value="<?php echo $fetch_filed['AdditionalGear'];?>" /></div>
                    </li>
                      <li>
                          <div class="btm_left" >Notes</div>
                    <div class="btm_right rlcon"style="margin-bottom: 10px;"> <textarea  name="Notes" id="Notes"><?php echo $fetch_filed['Notes'];?></textarea></div>
                    </li>
                    <li>
                    <div class="btm_left">Invoice In</div>
                    <div class="btm_right"> <input type="text" name="foinvoicein" id="foinvoicein" value="<?php echo $fetch_filed['foinvoicein'];?>" /></div>
                    </li>
                    <li>
                    <div class="btm_left">Invoice Paid</div>
                    <div class="btm_right"> <input type="text" name="foinvoicewpaid" id="foinvoicewpaid" value="<?php echo $fetch_filed['foinvoicewpaid'];?>" /></div>
                    </li>         
                 </ul>
                    </div><!--screen_btm_left-->
                </div><!--screen_detail_btm-->
                </div><!--screen details-->
                <div class="actions_list detail_action">
                <ul class="action_video">
                    <input type="hidden" name="enroll_edit_id" value="<?php echo $fetch['AssignID'];?>"/>
                    <li onclick="window.history.back()"><img src="../images/back.png"  onmouseover="this.src='../images/back_hover.png';" onmouseout="this.src='../images/back.png';"  /></li>
                    <li onclick="document.getElementById('myForm').reset();"><img src="../images/cancel.png"  onmouseover="this.src='../images/cancel_hover.png';" onmouseout="this.src='../images/cancel.png';" /></li>
                    <li><input type="image" src="../images/submit_hover.png"  onmouseover="this.src='../images/submit.png';" onmouseout="this.src='../images/submit_hover.png';" /></li>
               
                </ul><!--action video-->
                </div>
                </form> 	
                
  			</div><!--enroll text-->
        </div><!--enroll content-->
     <p class="copy">&#169; 2015 Axon communications, Inc.</p>
    </div><!--main_content-->

</div><!--main wrapper-->
 <?php unset($_SESSION['error']);unset($_SESSION['success']);?>
</body>
</html>
