window.onload = function () {
    
    a("print_list").onclick = item_add_click;
	
	a("get_customer").onclick = get_customer_status
	
    
}

var a = function(id) { return document.getElementById(id); }

var update_invoice = function () {
   
   
    a("first_name").value = "";
    a("last_name").value = "";
       
}    

var item_add_click = function() {
   
    var first_name = a("first_name").value;
    var last_name = a("last_name").value;
	var check = 0;
	ajax_call(first_name,last_name,check);
   
}


var get_customer_status = function(){
    var first_name = a("first_name").value;
    var last_name = a("last_name").value;
	var check = 1;
    ajax_call(first_name,last_name,check);

}

function ajax_call(first_name,last_name,check)
{
  var ajaxvariable;
  if(check == 1)
  {
    ajaxvariable ="check="+check +"&first_name="+first_name+"&last_name="+last_name; 
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
    xmlhttp.open("POST","customerDb.php?"+ajaxvariable,true);
    xmlhttp.send();
}
