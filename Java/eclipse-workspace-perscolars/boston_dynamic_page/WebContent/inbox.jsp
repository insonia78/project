<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="ISO-8859-1" http-equiv="Content-Type" content="text/html; charset=ISO-8859-1" >
<title>Inbox</title>
</head>
<%
	String userName = null;
	if(session.getAttribute("userName") == null){
		response.sendRedirect("login.jsp");
	} else {
		userName = session.getAttribute("userName").toString();
	}
%>
<body>
<h1 style="margin-left: 40%">Inbox</h1>
<h3>Welcome &nbsp;<%=userName%></h3>
<a href="sentItems.jsp">Sent Items</a>
<br/>
<a href="logout.jsp">Log Out</a>
</body>
</html>