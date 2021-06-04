<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<%@ taglib prefix="form" uri="http://www.springframework.org/tags/form"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Index</title>
</head>
<body>
	<h1>Welcome to Simple Application</h1>
	<form:form action="userInfo" method="POST" modelAttribute="newUser">
		<div>
			<form:label path="username">User Name</form:label>
			<form:input type="text" id="user" path="username" />
			<form:errors path="username" />
		</div>
		<div>
			<form:label path="password">Password</form:label>
			<form:input type="password" id="pass" path="password" />
			<form:errors path="password" />
		</div>
		<div>
			<form:label path="email">Email</form:label>
			<form:input type="text" id="email" path="email" />
			<form:errors path="email" />
		</div>
		<div>
			<form:label path="dob">Date of Birth</form:label>
			<form:input type="text" id="dob" path="dob" />
			<form:errors path="dob" />
		</div>
		<div>
			<input type="submit" name="submit" value="Submit Info" />
		</div>
	</form:form>
</body>
</html>