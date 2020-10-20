<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="ISO-8859-1">
<title>Sent Items</title>
<%
  String userName = null;
if(session.getAttribute("userName") == null)
{
	response.sendRedirect("login.jsp");
}else{
	userName = session.getAttribute("userName").toString();
}
%>
</head>
<body>
<h1 style="margin-left:40%">Sent Items</h1>
<h3>Welcome %nbsp;<%= userName %> </h3>
<a href="inbox.jsp">Inbox</a>
<a href="logout.jsp">Log out</a>
</body>
</html>