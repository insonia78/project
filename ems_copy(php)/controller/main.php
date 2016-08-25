<?php

/* * ******************************************
 * file Main.php
 * The file is the main entry point of the application
 * is decides which query to perform based on a switch statment 
 * 
 * 
 * 
 * 
 *  
 * ******************************************** */


error_reporting(0);
session_start();

require ('../model/videographerList.php');
require ('../model/performQueryToDataBase.php');




if ($_SESSION['login_details']['user_id'] == "") {
    header("Location:../index.php");
    exit;
}

$performQueryToDataBase = new performQueryToDataBase();



$status = $_REQUEST['status'];




switch ($status) {
    case 'postponed': {
            $result = $performQueryToDataBase->getPostponedData();
            break;
        }
    case 'canceled': {
            $result = $performQueryToDataBase->getCanceledData();
            break;
        }
    case 'filmed': {
            $result = $performQueryToDataBase->getFilmedData();
            break;
        }
    case 'queue': {
            $result = $performQueryToDataBase->getQueueData();

            break;
        }
    case 'reorders': {

            $result = $performQueryToDataBase->getReordersData();
            break;
        }
    case 'field_update': {

            $enroll_edit_id = $_POST['enroll_edit_id']; // getting the same id from the pending page 


            if ($_POST['ajax'] == 'true') {

                $videographer_list = new videographerList();

                $videographer_list->getData($_POST);
                $_SESSION['error'] = 'we have a problem with ajax';
            }




            if ($enroll_edit_id != '') {

                $fieldopt = $performQueryToDataBase->setDataForFieldops($_POST, $enroll_edit_id);

                $countfiled = $performQueryToDataBase->getRowsNum($fieldopt);



                if ($countfiled != 1) {

                    $response = $performQueryToDataBase->insertDataForFieldsOps();
                } else {

                    $response = $performQueryToDataBase->upDateFieldOps($enroll_edit_id);
                }



//logging
                $ipaddress = get_client_ip();
                $update = $enroll_edit_id . ' - Field Operations Queue updated';

                $response = $performQueryToDataBase->upDateLoggingTable($ipaddress, $update, $_SESSION);

                $_SESSION['success'] = 'Field Operations Queue updated successfully';
            }
            $edit_id = $_REQUEST['edit_id'];
            if ($edit_id != "") {

                $fetch = $performQueryToDataBase->getDataFromAssignmentsTable($edit_id);
                $fieldopt = $performQueryToDataBase->getDataFromAssignmentsTable($edit_id);

                $countfiled = $performQueryToDataBase->getRowsNum($fieldopt);
                if ($countfiled == 1) {
                    $fetch_filed = $performQueryToDataBase->fetching_array($fieldopt);
                } else {
                    $fetch_filed['shootername'] = '';
                    $fetch_filed['companyname'] = '';
                    $fetch_filed['shooterphone'] = '';
                    $fetch_filed['shootercell'] = '';
                    $fetch_filed['shooteralt'] = '';
                    $fetch_filed['shooteremail'] = '';
                    $fetch_filed['teleprompt'] = '';
                    $fetch_filed['foshipout'] = '';
                    $fetch_filed['foouttrack'] = '';
                    $fetch_filed['foshipin'] = '';
                    $fetch_filed['fointrack'] = '';
                    $fetch_filed['fotapeexpectin'] = '';
                    $fetch_filed['fotapein'] = '';
                    $fetch_filed['foinvoicein'] = '';
                    $fetch_filed['foinvoicewpaid'] = '';
                    $fetch_filed['Lighting'] = '';
                    $fetch_filed['Audio'] = '';
                    $fetch_filed['Monitor'] = '';
                    $fetch_filed['AdditionalGear'] = '';
                    $fetch_filed['Notes'] = '';
                }
            }

            $video_result = $performQueryToDataBase->getDataFromVideographersTable();

            if (!$video_result) {
                $_SESSION['error'] = 'Not able to retrive the data from the videographers table';
            }
            $result = true;
            break;
        }
    case 'videographer': {

            if (isset($_REQUEST['delete_id'])) {

                $response = $performQueryToDataBase->deleteFromVideographer($_REQUEST);

                if ($response) {
                    $_SESSION['success'] = 'Videographer detail deleted successfully';
                } else {
                    $_SESSION['error'] = 'Videographer detail was not deleted';
                }
            }
            $edit_id = $_POST['edit_id'];


            if (isset($_POST['edit_id'])) {
                if ($edit_id != "") {
                    $update = $performQueryToDataBase->updateVideographer($_POST, $edit_it);

                    if (!$update) {
                        $_SESSION['error'] = "Not Updated";
                    }

//logging            

                    $ipaddress = get_client_ip();
                    $update = $edit_id . ' - videographer updated';
                    $response = $performQueryToDataBase->upDateLoggingTable($ipaddress, $update, $_SESSION);

                    $_SESSION['success'] = 'Videographer details updated successfully';
                } else {


                    $update = $performQueryToDataBase->insertVideographer($_POST);

                    if (!$update) {
                        $_SESSION['error'] = "Not Inserted";
                    }

                    $inser_id = mysql_insert_id();
//logging
                    $ipaddress = get_client_ip();
                    $update = $inser_id . ' - New videographer inserted';
                    $response = $performQueryToDataBase->upDateLoggingTable($ipaddress, $update, $_SESSION);

                    if ($response) {
                        $_SESSION['success'] = 'Videographer details inserted successfully';
                    }
                }
            }
            $result = $performQueryToDataBase->getDataFromVideographersTable();
            break;
        }
    
    case 'view_videographers': {
        
            $edit_id = $_REQUEST['edit_id'];
            if ($edit_id != "") {

                $result = $performQueryToDataBase->getViewVideographer($edit_id);
            }
            break;
        }
    case 'add_videographer': {
           
            $edit_id = $_REQUEST['edit_id'];
           
    
            if ($edit_id != "") {

                $result = $performQueryToDataBase->getAddVideographer($edit_id);
                
                
    
                
            }
            break;
        }
    default : {
            $result = $performQueryToDataBase->getPendingData();
            $status = 'pending';
            break;
        }
}

try {


  

    if ($result) {
        
       
        
        switch ($status) {
            case 'queue': {
                
                    require "../view/queue_view.php";
                    break;
                }
            case 'reorders': {
                
                    require "../view/reorder_view.php";
                    break;
                }
            case 'videographer': {
                
                    require "../view/videographer_view.php";
                    break;
                }
            case'field_update': {
                
                    require'../view/detailAndUpdateButtonFunctionality/field_update.php';
                    break;
                }
            case 'view_videographers': {
                
                
                    $fetch = $result;
                    require '../view/videographers_files/view_videographer.php';
                    break;
                }
            case'add_videographer': {
                
            
                $fetch = $result;
                require '../view/videographers_files/add_videographer.php';
                break;    
                }
            default: {
                    require "../view/main_view.php";
                    break;
                }
        }
    } else {

        require "../view/main_view.php";
        echo "<h2 style ='color:red'>No query was performed</h2>";
    }
} catch (Exception $e) {
    require "../view/main_view.php";
    echo "<h2 style ='color:red'>we have a problem " . $e->getTraceAsString() . "</h2>";
}
?>