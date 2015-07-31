window.onload = function () {
    
    a("print_list").onclick = item_add_click;
	
	a("get_customer").onclick = get_customer_status
	
    
}

var a = function(id) { return document.getElementById(id); }



var item_add_click = function() {
   
    var video_name = a("video_name").value;
    
	var check = 0;
	ajax_call(video_name,check);
   
}


var get_customer_status = function(){
    var video_name = a("video_name").value;
    
	var check = 1;
    ajax_call(video_name,check);

}

function ajax_call(video_name,check)
{
  var ajaxvariable;
  if(check == 1)
  {
    ajaxvariable ="check="+check +"&video_name="+video_name; 
  }
  else
  {
    ajaxvariable = "check="+check;
  }
  
  var xmlhttp=new XMLHttpRequest();
    xmlhttp.onreadystatechange=function() {
        if (xmlhttp.readyState==4 && xmlhttp.status==200) {
            document.getElementById("item_list").innerHTML=xmlhttp.responseText;
        }
    }
    xmlhttp.open("POST","videoDb.php?"+ajaxvariable,true);
    xmlhttp.send();
}
