<?php

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 * Description of videographer_list
 *
 * @author tzangari
 */
error_reporting(0);



class videographerList {

    //put your code here

    function getData($__POST) {
   
        if (isset($__POST['vID'])) {
            $vID = $__POST['vID'];
            $query = "select * from videographers where vID = '" . $vID . "'";
            $result = mysql_query($query);
            $fetch = mysql_fetch_assoc($result);
            echo $fetch['Name'] . ',' . $fetch['CompanyName'] . ',' . $fetch['PrimPhone'] . ',' . $fetch['SecPhone'] . ',' . $fetch['videographer_alter'] . ',' . $fetch['Email'] . ',' . $fetch['teleprompt'] . ',' . $fetch['Lighting'] . ',' . $fetch['Audio'] . ',' . $fetch['Monitor'] . ',' . $fetch['AdditionalGear'] . ',' . $fetch['Notes'];
        }
     
        if (isset($__POST['onedayreminder'])) {
            $onedayreminder = $__POST['onedayreminder'];
            $jobno = $__POST['jobno'];
            $query = "update fieldops set  onedayreminder='" . $onedayreminder . "' where assignID='" . $jobno . "'";
            mysql_query($query);
        }
        if (isset($__POST['fourdayreminder'])) {
            $fourdayreminder = $__POST['fourdayreminder'];
            $jobno = $__POST['jobno'];
            $query = "update fieldops set  fourdayreminder='" . $fourdayreminder . "' where assignID='" . $jobno . "'";
            mysql_query($query);
        }
         
         
    }

}
?>