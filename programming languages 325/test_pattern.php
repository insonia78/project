<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transition//EN"
  "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
  <head>
     <meta http-equiv ="content-type" content="text/html; charset=utf-8" />
     <title>View my Blog </title>
  </head>
  <body>
<?php
  $string='';
  $pattern='';
   if(isset($_POST['submitted'])){
     
	 $array = array('1234','23456','123e2345',   '12',' ',"+123e12f","1234.e123d","123.12e+123","-1234","123.34e-306","123.34e-305");
	   	 
	 print"<p>THe result of cheking<br /><span style=\"font-style: italic;\">$string</span><br />against<br /><span style=\"font-weight:bold\">$pattern</span><br />is";
	foreach($array as &$string)
	{
	   if(preg_match('/^[-+]?[0-9]*([fF]|[dD]|[0-9.][0-9]+[dD]|(([eE][-+]?([1-9]{1}|[1-3]{1}[1-5]{1}|0{0,})[fF])|[0-9.][0-9]+|([0-9.][0-9]+)([eE][-+]?([1-9]{1}|[1-2]{1}[0-9]{2}|[3]{1}[0]{1}[0-5]{1}|0{0,})([dD]|[\s]{0,}))))?$/',$string)){
	    print $string .' TRUE!</p>';
	   }
	   else
	  {
	     print $string . ' FALSE</p>';
	  }
	 }
	
   }   
   
  ?>
  <form action="test_pattern.php" method="post">
     
	 <input type="submit" name="submit" value="Test!" />
	 <input type="hidden" name="submitted" value="true" />
	 </form>
	 </body>
	 </html>