window.onload = function () { 
      
    a("rent").onclick = rent;	
	a("return").onclick = Return;
}

var a = function(id) { return document.getElementById(id); }



var rent = function() {
   
    var first_name = a("first_name").value;
    var last_name = a("last_name").value;
	var video_name = a("video_name").value;
	var date = a("date").value;
	var check = 0;
	ajax_call(first_name,last_name,check,video_name,date);
   
}
var Return = function(){
    var first_name = a("first_name").value;
    var last_name = a("last_name").value;
	var video_name = a("video_name").value;
    var date = a("date").value; 
	var check = 1;
    ajax_call(first_name,last_name,check,video_name,date);

}

function ajax_call(first_name,last_name,check,video_name,date)
{
  var ajaxvariable;
  if(check == 1)
  {
    ajaxvariable ="check="+check +"&first_name="+first_name+"&last_name="+last_name+"&video_name="+video_name+"&date="+date; 
  }
  else
  {
    ajaxvariable ="check="+check +"&first_name="+first_name+"&last_name="+last_name+"&video_name="+video_name+"&date="+date;
  }    
    var xmlhttp=new XMLHttpRequest();
    xmlhttp.onreadystatechange=function() {
        if (xmlhttp.readyState==4 && xmlhttp.status==200) {
            document.getElementById("item_list").innerHTML=xmlhttp.responseText;
        }
    }
		xmlhttp.open("POST","rentalDb.php?"+ajaxvariable,true); 
        xmlhttp.send();
}
