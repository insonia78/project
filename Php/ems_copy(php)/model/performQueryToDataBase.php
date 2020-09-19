<?php

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 * Description of performQueryToDataBase
 *
 * @author tzangari
 */
error_reporting(0);
require ('../config.php');

class performQueryToDataBase {

    //put your code here
    private $shootername;
    private $companyname;
    private $shooterphone;
    private $shootercell;
    private $shooteralt;
    private $shooteremail;
    private $teleprompt;
    private $foshipout;
    private $foouttrack;
    private $fointrack;
    private $fotapein;
    private $foshipin;
    private $fotapeexpectin;
    private $Lighting;
    private $Audio;
    private $Monitor;
    private $AdditionalGear;
    private $Notes;
    private $foinvoicein;
    private $foinvoicewpaid;
    private $countfiled;

    function getPendingData() {
        $query = "select shootdate,shootername,AssignID,therapeuticArea,practicestate,physname,repname,AssignStatus from assignments where AssignStatus = 'pending'";
        $result = mysql_query($query);
        return $result;
    }

    function getPostponedData() {

        $query = "select shootdate,shootername,AssignID,therapeuticArea,practicestate,physname,repname,AssignStatus from assignments where AssignStatus = 'postponed'";
        $result = mysql_query($query);
        return $result;
    }

    function getCanceledData() {
        $query = "select shootdate,shootername,AssignID,therapeuticArea,practicestate,physname,repname,AssignStatus from assignments where AssignStatus = 'canceled'";
        $result = mysql_query($query);
        return $result;
    }

    function getFilmedData() {
        $query = "select shootdate,shootername,AssignID,therapeuticArea,practicestate,physname,repname,AssignStatus,ppmultidoc from assignments where AssignStatus = 'filmed'";
        $result = mysql_query($query);
        return $result;
    }

    function getQueueData() {
        $query = "select shootdate,shootername,AssignID,therapeuticArea,practicestate,physname,repname,AssignStatus from assignments where ppedited != ''";
        $result = mysql_query($query);
        return $result;
    }

    function getReordersData() {
        $query = "select * from reorders";
        $result = mysql_query($query);
        return $result;
    }

    function setDataForFieldops($__POST, $enroll_edit_id) {

        $this->shootername = addslashes($__POST['shootername']);
        $this->companyname = addslashes($__POST['companyname']);
        $this->shooterphone = addslashes($__POST['shooterphone']);
        $this->shootercell = addslashes($__POST['shootercell']);
        $this->shooteralt = addslashes($__POST['shooteralt']);
        $this->shooteremail = addslashes($__POST['shooteremail']);
        $this->teleprompt = addslashes($__POST['teleprompt']);
        $this->foshipout = addslashes($__POST['foshipout']);
        $this->foouttrack = addslashes($__POST['foouttrack']);
        $this->fointrack = addslashes($__POST['fointrack']);
        $this->fotapein = addslashes($__POST['fotapein']);
        $this->foshipin = addslashes($__POST['foshipin']);

        $this->fotapeexpectin = addslashes($__POST['fotapeexpectin']);
        $this->Lighting = addslashes($__POST['Lighting']);
        $this->Audio = addslashes($__POST['Audio']);
        $this->Monitor = addslashes($__POST['Monitor']);
        $this->AdditionalGear = addslashes($__POST['AdditionalGear']);
        $this->Notes = addslashes($__POST['Notes']);
        $this->foinvoicein = addslashes($__POST['foinvoicein']);
        $this->foinvoicewpaid = addslashes($__POST['foinvoicewpaid']);

//Field opt table insert
        $fieldopt = mysql_query("select * from fieldops where assignID = '" . $enroll_edit_id . "'");

        return $fieldopt;
    }

    function insertDataForFieldsOps() {
        $insertfld = "insert into fieldops(assignID,shootername,companyname,shooterphone,shootercell,shooteralt,shooteremail,teleprompt,foshipout,
            foouttrack,foshipin,fointrack,fotapeexpectin,fotapein,foinvoicein,foinvoicewpaid,Lighting,Audio,Monitor,AdditionalGear,Notes)
             values('" . $this->enroll_edit_id . "','" . $this->shootername . "','" . $this->companyname . "','" . $this->shooterphone . "','" . $this->shootercell . "','" . $this->shooteralt . "','" . $this->shooteremail . "','" . $this->teleprompt . "','" . $this->foshipout . "',
                '" . $this->foouttrack . "','" . $this->foshipin . "','" . $this->fointrack . "','" . $this->fotapeexpectin . "','" . $this->fotapein . "','" . $this->foinvoicein . "','" . $this->foinvoicewpaid . "','" . $this->Lighting . "','" . $this->Audio . "','" . $this->Monitor . "','" . $this->AdditionalGear . "','" . $this->Notes . "')";

        $result = mysql_query($insertfld);
        return $result;
    }

    function getRowsNum($data) {
        $this->countfiled = mysql_num_rows($fieldopt);

        return $this->countfiled;
    }

    function upDateFieldOps($enroll_edit_id) {

        $updatequery = "update assignments set 
    shootername='" . $this->shootername . "',
    companyname='" . $this->companyname . "',
    shooterphone='" . $this->shooterphone . "',
    shootercell='" . $this->shootercell . "',
    shooteralt='" . $this->shooteralt . "',
    shooteremail='" . $this->shooteremail . "',
    teleprompt='" . $this->teleprompt . "',
    foshipout='" . $this->foshipout . "',
    foouttrack='" . $this->foouttrack . "',
    foshipin='" . $this->foshipin . "',
    fointrack='" . $this->fointrack . "',
    fotapein='" . $this->fotapein . "'
   where AssignID='" . $enroll_edit_id . "'";


        $result = mysql_query($updatequery);

        return $result;
    }

    function upDateLoggingTable($ipaddress, $update, $__SESSION) {

        $insert = "insert into logging(eventUser,eventAction,eventIP) values('" . $__SESSION['login_details']['user_name'] . "','" . $update . "','" . $ipaddress . "');";
        $result = mysql_query($insert);
        return $result;
    }

    function getDataFromAssignmentsTable($edit_id) {
        $query = "select * from assignments where AssignID = '" . $edit_id . "'";
        $result = mysql_query($query);
        $fetch = mysql_fetch_assoc($result);
        return $fetch;
    }

    function getDataFromFieldops($edit_id) {
        $fieldopt = mysql_query("select * from fieldops where assignID = '" . $edit_id . "'");

        return $fieldopt;
    }

    function fetching_array($data) {

        $fetch_filed = mysql_fetch_assoc($data);


        return $fetch_filed;
    }

    function getDataFromVideographersTable() {
        $video_query = "select * from videographers where status is NULL";
        $video_result = mysql_query($video_query);

        return $video_result;
    }

    function deleteFromVideographer($__REQUEST) {
        $delete_id = $__REQUEST['delete_id'];
        $delete_query = "update videographers set status ='inactive'  WHERE vID='" . $delete_id . "'";
        $result = mysql_query($delete_query);
        return $result;
    }

    function updateVideographer($__POST, $edit_it) {
        $updatequery = "update videographers set Name='" . addslashes($__POST['Name']) . "',CompanyName='" . addslashes($__POST['CompanyName']) . "',Street='" . addslashes($__POST['Street']) . "',City='" . $__POST['City'] . "',State='" . addslashes($__POST['State']) . "',Zip='" . addslashes($__POST['Zip']) . "',PrimPhone='" . addslashes($__POST['PrimPhone']) . "',SecPhone='" . addslashes($__POST['SecPhone']) . "',Email='" . addslashes($__POST['Email']) . "',Camera='" . addslashes($__POST['Camera']) . "',RingSize='" . addslashes($__POST['RingSize']) . "',Rate='" . addslashes($__POST['Rate']) . "',Transfer='" . addslashes($__POST['Transfer']) . "',teleprompt='" . addslashes($__POST['teleprompt']) . "',videographer_alter='" . addslashes($__POST['videographer_alter']) . "',Lighting='" . addslashes($__POST['Lighting']) . "',Audio='" . addslashes($__POST['Audio']) . "',Monitor='" . addslashes($__POST['Monitor']) . "',AdditionalGear='" . addslashes($__POST['AdditionalGear']) . "',Notes='" . addslashes($__POST['Notes']) . "' where vID='" . $edit_id . "'";
        $update = mysql_query($updatequery);
    }

    function insertVideographer($__POST) {
        $insert_query = "insert into videographers(Name,CompanyName,Street,City,State,Zip,PrimPhone,SecPhone,Email,Camera,RingSize,Rate,Transfer,teleprompt,videographer_alter,Lighting,Audio,Monitor,AdditionalGear,Notes) values('" . addslashes($__POST['Name']) . "','" . addslashes($__POST['CompanyName']) . "','" . addslashes($__POST['Street']) . "','" . addslashes($__POST['City']) . "','" . addslashes($__POST['State']) . "','" . addslashes($__POST['Zip']) . "','" . addslashes($__POST['PrimPhone']) . "','" . addslashes($__POST['SecPhone']) . "','" . addslashes($__POST['Email']) . "','" . addslashes($__POST['Camera']) . "','" . addslashes($__POST['RingSize']) . "','" . addslashes($__POST['Rate']) . "','" . addslashes($__POST['Transfer']) . "','" . addslashes($__POST['teleprompt']) . "','" . addslashes($__POST['videographer_alter']) . "','" . addslashes($__POST['Lighting']) . "','" . addslashes($__POST['Audio']) . "','" . addslashes($__POST['Monitor']) . "','" . addslashes($__POST['AdditionalGear']) . "','" . addslashes($__POST['Notes']) . "')";
        $update = mysql_query($insert_query);
        return $update;
    }

    function getViewVideographer($edit_id) {
        $query = "select * from videographers where vID = '" . $edit_id . "'";
        $result = mysql_query($query);
        $fetch = mysql_fetch_assoc($result);
        return $fetch;
    }
    function getAddVideographer($edit_id)
    {             
                $query = "select * from videographers where vID = '" . $edit_id . "'";
               
                $result = mysql_query($query);
               
                $fetch = mysql_fetch_assoc($result);
                
                return $fetch;      
    }
    function getClientAssignments($edit_id)
    {
         $query = "select shootdate,shootername,AssignID from assignments INNER JOIN videographers ON assignments.shootername = videographers.Name where videographers.vID = '".$edit_id."'";

         $result = mysql_query($query);
         return $result;
        
        
    }
    function getWebCodes($assign_id)
    {
        $query = "Select code where assign_id ='". $assign_id ."'";
        $result =  mysql_query( $query );
        return $result;
         
        
    }
    function insertTokenToDataBase($token)
    {
        $query = "Insert Into(token) Values('$token')";
        $result =  mysql_query( $query );
       
            return $result;
            
      
        
        
        
    }
    

}
